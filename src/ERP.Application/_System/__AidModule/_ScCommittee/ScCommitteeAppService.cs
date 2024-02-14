using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.Notifications;
using Abp.UI;
using ERP._System.__AidModule._ScCommittee.Dto;
using ERP._System.__AidModule._ScCommittee.Proc;
using ERP._System.__AidModule._ScCommittee.ProcDto;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails;
using ERP._System._ScComityMembers;
using ERP._System._ScComityMembers.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Core;
using ERP.Core.Helpers.Extensions;
using ERP.Events.Data;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCommittee
{
    [AbpAuthorize]
    public class ScCommitteeAppService : AsyncCrudAppService<ScCommittee, ScCommitteeDto, long, ScCommitteePagedDto, ScCommitteeCreateDto, ScCommitteeEditDto>
        , IScCommitteeAppService
    {
        private readonly IRepository<ScComityMembers, long> _repoScComityMembers;
        private readonly IRepository<ScCommitteeDetail, long> _repoDetail;
        private readonly IRepository<ScCommitteeMemberDetail, long> _repoMember;
        private readonly IRepository<ScPortalRequestStudy, long> _portalStudyRepo;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;
        private readonly IRepository<ScCommitteeDetailsElectronicAid, long> _repoScCommitteeDetailsElectronicAid;
        private readonly IScCommitteePostRepository _scCommitteePostRepository;
        private readonly IScCommitteeManager _scCommitteeManager;
        private readonly IScCommitteeDetailDeliverRepository _scCommitteeDetailDeliverRepository;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IGetScCommitteesScreenDataRepository _getScCommitteesScreenDataRepository;
        private readonly IConfiguration _config;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IPermissionManager _permissionManager;
        private readonly INotificationPublisher _notificationPublisher;
        private readonly UserManager _userManager;

        public IEventBus EventBus { get; set; }

        public ScCommitteeAppService(IRepository<ScCommittee, long> repository,
            IRepository<ScCommitteeDetail, long> repoDetail, IRepository<ScCommitteeDetailsElectronicAid, long> repoScCommitteeDetailsElectronicAid,
            IRepository<ScCommitteeMemberDetail, long> repoMember, IRepository<ScPortalRequestStudy, long> portalStudyRepo,
            IRepository<FndLookupValues, long> repoFndLookupValues, IRepository<ScComityMembers, long> repoScComityMembers,
            IScCommitteePostRepository scCommitteePostRepository,
            IScCommitteeManager scCommitteeManager, IScCommitteeDetailDeliverRepository scCommitteeDetailDeliverRepository,
            IGetCounterRepository repoProcCounter, IGlCodeComDetailsManager glCodeComDetailsManager,
            UserManager userManager, IPermissionManager permissionManager,
            INotificationPublisher notificationPublisher,
            IGetScCommitteesScreenDataRepository getScCommitteesScreenDataRepository
            , IConfiguration config
) : base(repository)
        {
            _repoDetail = repoDetail;
            _repoMember = repoMember;
            _repoScComityMembers = repoScComityMembers;
            _scCommitteeManager = scCommitteeManager;
            _scCommitteeDetailDeliverRepository = scCommitteeDetailDeliverRepository;
            _portalStudyRepo = portalStudyRepo;
            _repoFndLookupValues = repoFndLookupValues;
            _scCommitteePostRepository = scCommitteePostRepository;
            _repoProcCounter = repoProcCounter;
            _getScCommitteesScreenDataRepository = getScCommitteesScreenDataRepository;
            _config = config;
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _userManager = userManager;
            _repoScCommitteeDetailsElectronicAid = repoScCommitteeDetailsElectronicAid;
            _permissionManager = permissionManager;
            _notificationPublisher = notificationPublisher;
        }

        public override async Task<ScCommitteeDto> Create(ScCommitteeCreateDto input)
        {
            CheckCreatePermission();

            if (input.ListStudies.Select(d => d.RequestStudyId).Distinct().Count() != input.ListStudies.Count())
                throw new UserFriendlyException("There are duplicate studies in the list for this Committee");

            foreach (var item in input.ListStudies)
            {
                var itemStudy = await _portalStudyRepo.GetAsync(item.RequestStudyId);

                if (itemStudy.StatusLkpId.Value != (long)FndEnum.FndLkps.ScPortalRequestStudy_TransferedToCommittee)
                    throw new UserFriendlyException("There are studies in the list that must not be included");
            }

            input.CommitteeNumber = await GetCommitteeNumber();

            var committee = await base.Create(input);

            if (input.ListStudies?.Count > 0)
                foreach (var item in input.ListStudies)
                {
                    item.TenantId = committee.TenantId;
                    item.CommitteeId = committee.Id;

                    var committeeDetail = await _repoDetail.InsertAsync(ObjectMapper.Map<ScCommitteeDetail>(item));

                    if (item.DetailsElectronicAids != null)
                    {
                        item.DetailsElectronicAids.ToList().ForEach(async aid =>
                        {
                            await InsertScCommitteeDetailsElectronicAidData(aid, committeeDetail.Id);
                        });
                    }
                }

            if (input.ListMembers?.Count > 0)
                foreach (var item in input.ListMembers)
                {
                    item.TenantId = committee.TenantId;
                    item.CommitteeId = committee.Id;

                    _ = await _repoMember.InsertAsync(ObjectMapper.Map<ScCommitteeMemberDetail>(item));
                }

            return committee;
        }

        public override async Task<ScCommitteeDto> Update(ScCommitteeEditDto input)
        {
            CheckUpdatePermission();

            var committee = await Repository.GetAsync(input.Id);

            if (committee.StatusLkpId != (long)FndEnum.FndLkps.New_ScCommittee)
                throw new UserFriendlyException("Committee data can not be changed!");

            ObjectMapper.Map(input, committee);

            _ = await Repository.UpdateAsync(committee);

            if (input.ListEditStudies?.Count > 0)
            {
                foreach (var item in input.ListEditStudies)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var scCommitteeDetail = await _repoDetail.GetAsync((long)item.Id);

                        item.TenantId = committee.TenantId;
                        item.CommitteeId = input.Id;
                        item.RequestStudyId = scCommitteeDetail.RequestStudyId;
                        item.FndStatusLkp = null;

                        ObjectMapper.Map(item, scCommitteeDetail);

                        _ = await _repoDetail.UpdateAsync(scCommitteeDetail);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.TenantId = committee.TenantId;
                        item.CommitteeId = input.Id;
                        var mapped = ObjectMapper.Map<ScCommitteeDetail>(item);

                        mapped.SetStatusId(290);

                        _ = await _repoDetail.InsertAsync(mapped);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        var electronicAids = await _repoScCommitteeDetailsElectronicAid.CountAsync(x => x.ScCommitteeDetailsId == item.Id);

                        if (electronicAids > 0) throw new UserFriendlyException("لا يمكن حذف الحالة لوجود اجهزه اليكترونية");

                        await _repoDetail.DeleteAsync((long)item.Id);
                    }

                    await CRUD_ScCommitteeDetailsElectronicAid(item.DetailsElectronicAids, item.Id);
                }
            }
            if (input.ListEditMembers?.Count > 0)
            {
                foreach (var item in input.ListEditMembers)
                {
                    item.CommitteeId = committee.Id;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var scCommitteeMember = await _repoMember.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, scCommitteeMember);

                        _ = await _repoMember.UpdateAsync(scCommitteeMember);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        _ = await _repoMember.InsertAsync(ObjectMapper.Map<ScCommitteeMemberDetail>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoMember.DeleteAsync((long)item.Id);
                    }
                }
            }
            return new ScCommitteeDto { };
        }

        public async override Task Delete(EntityDto<long> input)
        {
            CheckDeletePermission();

            var committee = await Repository.GetAsync(input.Id);

            if (committee.StatusLkpId != (long)FndEnum.FndLkps.New_ScCommittee)
                throw new UserFriendlyException("Committee can not be deleted!");

            long newCommitteeStatusId = 290;

            var committeeDetails = _repoDetail.GetAllIncluding(x => x.ScCommitteeDetailsElectronicAid)
                           .Where(z => z.CommitteeId == input.Id);

            if (committeeDetails.Where(z => z.StatusLkpId != newCommitteeStatusId).Count() > 0)
                throw new UserFriendlyException("لا يمكن حذف اللجنة لوجود حلات معتمدة!!");
            else
            {
                if (committeeDetails.Any(z => z.ScCommitteeDetailsElectronicAid.Any()))
                    throw new UserFriendlyException("لا يمكن حذف اللجنة لوجود مساعدات اليكترونية!!");
            }
            await base.Delete(input);
        }

        protected override IQueryable<ScCommittee> CreateFilteredQuery(ScCommitteePagedDto input)
        {
            try
            {
                var queryable = Repository.GetAllIncluding(z => z.CommitteeDetails, z => z.CommitteeMembersDetails, z => z.FndLookupStatusValues); //.GetAll();
                if (!string.IsNullOrEmpty(input.Params.CommitteeName))
                    queryable = queryable.Where(q => q.CommitteeName.Contains(input.Params.CommitteeName));

                if (!string.IsNullOrEmpty(input.Params.CommitteeNumber))
                    queryable = queryable.Where(q => q.CommitteeNumber.Contains(input.Params.CommitteeNumber));

                if (input.Params.StatusLkpId > 0)
                    queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

                if (input.Params != null && !string.IsNullOrEmpty(input.Params.CommitteeDateFrom))
                {
                    var dt = DateTimeController.ConvertToDateTime(input.Params.CommitteeDateFrom);
                    queryable = queryable.Where(c => dt <= c.CommitteeDate);
                }

                if (input.Params != null && !string.IsNullOrEmpty(input.Params.CommitteeDateTo))
                {
                    var dt = DateTimeController.ConvertToDateTime(input.Params.CommitteeDateTo);
                    queryable = queryable.Where(c => dt >= c.CommitteeDate);
                }

                queryable = queryable.OrderByDescending(x => x.CreationTime);

                return queryable;
            }
            catch (System.Exception ex)
            {
                return base.CreateFilteredQuery(input);
            }
        }

        public async Task<ScCommitteeDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll()
                .Include(x => x.CommitteeDetails).ThenInclude(l => l.RequestStudy).ThenInclude(l => l.GlCodeComDetails)
                .Include(z => z.CommitteeDetails).ThenInclude(i => i.RequestStudy).ThenInclude(l => l.ScPortalRequest).ThenInclude(p => p.PortalUser)
                .Include(z => z.CommitteeDetails).ThenInclude(i => i.RequestStudy).ThenInclude(l => l.ScPortalRequest).ThenInclude(p => p.AidRequestType)
                .Include(z => z.CommitteeDetails).ThenInclude(i => i.FndStatusLkp)
                .Include(z => z.CommitteeDetails).ThenInclude(i => i.FndOtherAidLkp)
                .Include(z => z.CommitteeMembersDetails).ThenInclude(i => i.Member).ThenInclude(l => l.FndLookupValues)
                .Include(z => z.FndLookupStatusValues)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ScCommitteeDto>(current);


            foreach (var item in mapped.CommitteeDetails)
            {
                var currentCodeComEntity = current.CommitteeDetails.Where(z => z.Id == item.Id).FirstOrDefault().RequestStudy.GlCodeComDetails;

                var currentCodeCom = await _glCodeComDetailsManager.GetCodeComTextsIds(currentCodeComEntity, _app.Reqlanguage);

                item.CodeComUtilityTexts = currentCodeCom.texts;

                if (current.CommitteeDetails.Where(z => item.Id == z.Id).FirstOrDefault().RequestStudy.ScPortalRequest.AidRequestType.AidRequestTypeLkpId == 609 /* electronic request */)
                    item.IsElectronic = true;
            }

            return mapped;
        }

        public override async Task<PagedResultDto<ScCommitteeDto>> GetAll(ScCommitteePagedDto input)
        {
            var list = await base.GetAll(input);
            foreach (var item in list.Items)
            {
                var currentLkp = await _repoFndLookupValues.GetAsync(item.StatusLkpId);

                item.FndLookupStatusValues = new FndLookupValuesDto
                {
                    NameAr = currentLkp.NameAr,
                    NameEn = currentLkp.NameEn
                };
            }
            return list;
        }

        public async Task<PostOutput> PostScCommittee(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCommitteePostRepository.Execute(postDto, "ScCommitteesPost");
            var storedOutput = result.FirstOrDefault();

            return storedOutput;
        }

        public async Task<PostOutput> RefuseCommittee(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCommitteePostRepository.Execute(postDto, "ScCommitteesRefuse");

            var returnVal = result.FirstOrDefault();

            return returnVal;
        }

        public async Task<Select2PagedResult> GetScCommitteeNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await Repository.GetAll()
                    .Where(z => (string.IsNullOrEmpty(searchTerm) || z.CommitteeName.Contains(searchTerm)) || z.StatusLkpId == 157)
                    .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.CommitteeName : z.CommitteeName, altText = z.CommitteeName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetScCommitteeForChecksSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
                 => await _scCommitteeManager.GetScCommitteeForChecksSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<PostOutputWithId> PostScCommitteeDetail(PostDto postDto)
        {
            CheckPermission(PermissionNames.Pages_ScCommittee_Detail_Post);

            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCommitteeDetailDeliverRepository.Execute(postDto, "ScCommitteeDetailsPost");

            var storedOutput = result.FirstOrDefault();

            if (storedOutput != null && storedOutput.FinalStatues.ToLower() == "s")
            {
                var scCommitteeDetail = _repoDetail.GetAllIncluding(pr => pr.RequestStudy.ScPortalRequest).FirstOrDefault(sc => sc.Id == postDto.Id);
                var encId = CipherStringController.Encrypt(storedOutput.Id.ToString());
                var userIds = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_ApMiscPaymentHeaders).Select(p => new UserIdentifier(AbpSession.TenantId, p.Id)).ToArray();
                var link = NotifyFor30DaysRemainOnContractWorker.GenerateFormViewLinkForEmailBody("ApMiscPaymentHeaders", encId, _config: _config);
                var msg = $"تم عمل سند صرف عام للطلب رقم <u>{scCommitteeDetail?.RequestStudy?.ScPortalRequest?.PortalRequestNumber}</u> اسم الحالة <u>{scCommitteeDetail?.RequestStudy?.ScPortalRequest?.Name}</u> ويصرف باسم <u>{scCommitteeDetail?.CashingTo}</u>.<br>";
                var notif = new MessageNotificationData(msg);
                notif.Properties.Add("link", link);

                EventBus.Trigger(new ScCommitteeDetailPostedEventData()
                {
                    scCommitteeDetail = scCommitteeDetail
                    , encId = encId
                });
                await _notificationPublisher.PublishAsync("ApMiscPaymentHeaders", notif, new EntityIdentifier(typeof(ApMiscPaymentHeaders), storedOutput.Id), userIds: userIds);
            }

            return storedOutput;
        }

        public async Task<PostOutputWithId> PostponeScCommitteeDetail(PostDto postDto, string refuseDescription)
        {
            CheckPermission(PermissionNames.Pages_ScCommittee_Detail_Postpone);

            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCommitteeDetailDeliverRepository.Execute(postDto, "ScCommitteeDetailsDelay");

            var current = await _repoDetail.GetAsync(postDto.Id);

            current.SetRefuseData(refuseDescription: refuseDescription);

            var returnVal = result.FirstOrDefault();

            if (returnVal.FinalStatues != "F") _ = await _repoDetail.UpdateAsync(current);

            return returnVal;
        }

        public async Task<PostOutputWithId> RejectScCommitteeDetail(PostDto postDto, string refuseDescription)
        {
            CheckPermission(PermissionNames.Pages_ScCommittee_Detail_Reject);

            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCommitteeDetailDeliverRepository.Execute(postDto, "ScCommitteeDetailsrefuse");

            var current = await _repoDetail.GetAsync(postDto.Id);

            current.SetRefuseData(refuseDescription: refuseDescription);

            var returnVal = result.FirstOrDefault();

            if (returnVal.FinalStatues != "F") _ = await _repoDetail.UpdateAsync(current);

            return returnVal;
        }

        public async Task<List<ScCommitteeScreenDataOutput>> GetScCommitteesScreenData(IdLangInputDto input)
        {
            var result = await _getScCommitteesScreenDataRepository.Execute(input, "GetScCommitteesScreenData");

            return result.ToList();
        }

        public ICollection<Permission> GetCommitteeDetailsPermissions()
        {
            return _permissionManager.GetAllPermissions().Where(p => p.Name.Contains("ScCommittee.Detail")).ToList();
        }

        public async Task<bool> AlterCommitteeDetailPermission(CommitteeDetailPermissionInputDto input)
        {
            try
            {
                var user = await _userManager.GetUserByIdAsync(input.UserId);
                foreach (var grantedPermission in input.AllowedPermissions)
                {
                    if (grantedPermission.Contains("ScCommittee.Detail"))
                    {
                        var granted = _permissionManager.GetPermissionOrNull(grantedPermission);

                        await _userManager.GrantPermissionAsync(user, granted);
                    }
                    else
                    {
                        return false;
                    }
                }
                foreach (var ProhibitedPermission in input.DeniedPermissions)
                {
                    if (ProhibitedPermission.Contains("ScCommittee.Detail"))
                    {
                        var granted = _permissionManager.GetPermissionOrNull(ProhibitedPermission);

                        await _userManager.ProhibitPermissionAsync(user, granted);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<IReadOnlyList<ScComityMembersDto>> GetAllScCommittteeMembers()
        {
            var data = await _repoScComityMembers.GetAllIncluding(z => z.FndLookupValues)
                            .Where(z => z.IsActive)
                            .OrderByDescending(z => z.MemberCategoryLkpId)
                            .ToListAsync();

            return ObjectMapper.Map<IReadOnlyList<ScComityMembersDto>>(data);
        }

        private async Task<string> GetCommitteeNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ScCommittee", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result.FirstOrDefault().OutputStr;
        }

        public async Task<IReadOnlyList<ScCommitteeDetailsElectronicAidDto>> GetAllScCommitteeDetailsElectronicAid(EntityDto<long> input)
        {
            var data = await _repoScCommitteeDetailsElectronicAid.GetAllIncluding(x => x.FndElectronicTypeLkp)
                .Where(z => z.ScCommitteeDetailsId == input.Id).ToListAsync();

            return ObjectMapper.Map<IReadOnlyList<ScCommitteeDetailsElectronicAidDto>>(data);
        }

        private async Task InsertScCommitteeDetailsElectronicAidData(ScCommitteeDetailsElectronicAidDto electronicAidDto, long parentId)
        {
            electronicAidDto.ScCommitteeDetailsId = parentId;

            var decisionElectronic = ObjectMapper.Map<ScCommitteeDetailsElectronicAid>(electronicAidDto);

            _ = await _repoScCommitteeDetailsElectronicAid.InsertAsync(decisionElectronic);
        }

        private async Task CRUD_ScCommitteeDetailsElectronicAid(ICollection<ScCommitteeDetailsElectronicAidDto> electronicAidDtos, long parentId)
        {
            if (electronicAidDtos?.Count > 0)
            {
                foreach (var item in electronicAidDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoScCommitteeDetailsElectronicAid.GetAsync((long)item.Id);

                        item.ScCommitteeDetailsId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoScCommitteeDetailsElectronicAid.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertScCommitteeDetailsElectronicAidData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScCommitteeDetailsElectronicAid.DeleteAsync((long)item.Id);
                    }
                }
            }
        }
    }
}
