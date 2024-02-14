using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.Notifications;
using ERP._System.__AidModule._PortalUserData;
using ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto;
using ERP._System.__AidModule._ScPortalRequestMgrDecision.Procs;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Core;
using ERP.Core.Helpers.Extensions;
using ERP.Events.Data;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision
{
    [AbpAuthorize]
    public class ScPortalRequestMgrDecisionAppService : AsyncCrudAppService<ScPortalRequestMgrDecision, ScPortalRequestMgrDecisionDto, long, PagedScPortalRequestMgrDecisionResultRequestDto, CreateScPortalRequestMgrDecisionDto, ScPortalRequestMgrDecisionEditDto>, IScPortalRequestMgrDecisionAppService
    {
        private readonly IScPortalRequestMgrDecisionRefuseRepository _scPortalRequestMgrDecisionRefuseRepository;
        private readonly IScScPortalRequestMgrDecisionPostRepository _scScPortalRequestMgrDecisionPostRepository;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IRepository<ScPortalRequestStudy, long> _repoScPortalRequestStudy;
        private readonly IRepository<PortalUserData, long> _repoPortalUserData;
        private readonly IRepository<ScPRMgrDecisionElectronicAid, long> _repoScPRMgrDecisionElectronicAid;
        private readonly UserManager _userManager;
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IConfiguration _config;

        public IEventBus EventBus { get; set; }

        public ScPortalRequestMgrDecisionAppService(IScPortalRequestMgrDecisionRefuseRepository scPortalRequestMgrDecisionRefuseRepository,
            IScScPortalRequestMgrDecisionPostRepository scScPortalRequestMgrDecisionPostRepository,
            IGlCodeComDetailsManager glCodeComDetailsManager, IRepository<PortalUserData, long> repoPortalUserData,
            IRepository<ScPortalRequestStudy, long> repoScPortalRequestStudy,
            IRepository<ScPRMgrDecisionElectronicAid, long> repoScPRMgrDecisionElectronicAid,
            UserManager userManager,
            INotificationPublisher notificationPublisher
            , IConfiguration config
            , IRepository<ScPortalRequestMgrDecision, long> repository) : base(repository)
        {
            _scPortalRequestMgrDecisionRefuseRepository = scPortalRequestMgrDecisionRefuseRepository;
            _scScPortalRequestMgrDecisionPostRepository = scScPortalRequestMgrDecisionPostRepository;
            _repoPortalUserData = repoPortalUserData;
            _repoScPRMgrDecisionElectronicAid = repoScPRMgrDecisionElectronicAid;
            _userManager = userManager;
            _notificationPublisher = notificationPublisher;
            _config = config;
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoScPortalRequestStudy = repoScPortalRequestStudy;

            CreatePermissionName = PermissionNames.Pages_ScPortalRequestMgrDecision_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScPortalRequestMgrDecision_Update;
            DeletePermissionName = PermissionNames.Pages_ScPortalRequestMgrDecision_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScPortalRequestMgrDecision;
        }

        public async override Task<PagedResultDto<ScPortalRequestMgrDecisionDto>> GetAll(PagedScPortalRequestMgrDecisionResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndLookupValuesStatusLkpId, x => x.FndLookupValuesRefuseLkpId, x => x.ScPortalRequestStudy, x => x.ScPortalRequestStudy.ScPortalRequest, x => x.ScPortalRequestStudy.ScPortalRequest.PortalUser);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDecisionDate))
                queryable = queryable.Where(q => q.DecisionDate >= DateTimeController.ConvertToDateTime(input.Params.FromDecisionDate));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDecisionDate))
                queryable = queryable.Where(q => q.DecisionDate <= DateTimeController.ConvertToDateTime(input.Params.ToDecisionDate));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.DecisionNumer))
                queryable = queryable.Where(q => q.DecisionNumer.Contains(input.Params.DecisionNumer));

            if (input.Params != null && input.Params.PortalRequestStudyId != null)
                queryable = queryable.Where(q => q.PortalRequestStudyId == input.Params.PortalRequestStudyId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.CaseNameId != null)
                queryable = queryable.Where(q => q.ScPortalRequestStudy.ScPortalRequest.PortalUsersId == input.Params.CaseNameId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScPortalRequestMgrDecisionDto>());

            foreach (var item in data2)
            {
                var portalUserData = await _repoPortalUserData.FirstOrDefaultAsync(z => z.PortalUserId == item.ScPortalRequestStudy.ScPortalRequest.PortalUsersId);

                item.ScPortalRequestStudy.ScPortalRequest.PortalUser.EncPortalUserDataId = portalUserData == null ? string.Empty : CipherStringController.Encrypt(portalUserData.Id.ToString());
            }

            var PagedResultDto = new PagedResultDto<ScPortalRequestMgrDecisionDto>()
            {
                Items = data2 as IReadOnlyList<ScPortalRequestMgrDecisionDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<ScPortalRequestMgrDecisionDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndLookupValuesStatusLkpId, x => x.FndLookupValuesRefuseLkpId,
                               x => x.ScPortalRequestStudy, x => x.ScPortalRequestStudy.ScPortalRequest,
                                x => x.ScPortalRequestStudy.ScPortalRequest.AidRequestType, x => x.FndOtherAidLkp,
                               x => x.ScPortalRequestStudy.GlCodeComDetails, x => x.ScPortalRequestStudy.ScPortalRequest.PortalUser)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<ScPortalRequestMgrDecisionDto>(current);

            if (current.ScPortalRequestStudy.GlCodeComDetails != null)
            {
                var currentCodeCom = await _glCodeComDetailsManager.GetCodeComTextsIds(current.ScPortalRequestStudy.GlCodeComDetails, _app.Reqlanguage);

                currentDto.codeComUtilityTexts = currentCodeCom.texts;
            }

            currentDto.IsElectronic = current.ScPortalRequestStudy.ScPortalRequest.AidRequestType.IsElectronics;

            return currentDto;
        }

        public async Task<PostOutput> PostRefuse(RefuseDto refuseDto)
        {
            PostDto postDto = new PostDto
            {
                Id = refuseDto.Id,
                UserId = AbpSession.UserId ?? 0
            };

            var res = await ScPortalRequestMgrDecisionRefuse(postDto);

            if (res.FinalStatues == "F") return res;

            var current = Repository.Get(refuseDto.Id);

            var currentDto = ObjectMapper.Map<ScPortalRequestMgrDecisionDto>(current);

            currentDto.RefuseLkpId = refuseDto.RefuseLkpId;
            currentDto.RefuseDescription = refuseDto.RefuseDescription;

            ObjectMapper.Map(currentDto, current);

            Repository.Update(current);

            return res;
        }

        public async Task<PostOutput> ScPortalRequestMgrDecisionRefuse(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scPortalRequestMgrDecisionRefuseRepository.Execute(postDto, "ScPortalRequestMgrDecisionRefuse");
            var storedOutput = result.FirstOrDefault();

            return storedOutput;
        }

        public async Task<PostOutputWithId> ScScPortalRequestMgrDecisionPost(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scScPortalRequestMgrDecisionPostRepository.Execute(postDto, "ScScPortalRequestMgrDecisionPost");
            var storedOutput = result.FirstOrDefault();

            if (storedOutput != null && storedOutput.FinalStatues.ToLower() == "s")
            {
                var scPortalRequestMgrDecision = Repository.GetAllIncluding(pr => pr.ScPortalRequestStudy.ScPortalRequest).FirstOrDefault(pr => pr.Id == postDto.Id);
                var encId = CipherStringController.Encrypt(storedOutput.Id.ToString());
                var userIds = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_ScPortalRequestMgrDecision).Select(p => new UserIdentifier(AbpSession.TenantId, p.Id)).ToArray();
                var link = NotifyFor30DaysRemainOnContractWorker.GenerateFormViewLinkForEmailBody("ApMiscPaymentHeaders", encId, _config: _config);
                var msg = $"تم عمل سند صرف عام للطلب رقم <u>{scPortalRequestMgrDecision?.ScPortalRequestStudy?.ScPortalRequest?.PortalRequestNumber}</u> اسم الحالة <u>{scPortalRequestMgrDecision?.ScPortalRequestStudy?.ScPortalRequest?.Name}</u> ويصرف باسم <u>{scPortalRequestMgrDecision?.CashingTo}</u>";
                var notif = new MessageNotificationData(msg);
                notif.Properties.Add("link", link);

                EventBus.Trigger(new ScPortalRequestStudyPostedFromManagerEventData()
                {
                    scPortalRequestMgrDecision = scPortalRequestMgrDecision
                    , encId = encId
                });
                await _notificationPublisher.PublishAsync("ApMiscPaymentHeaders", notif, new EntityIdentifier(typeof(ApMiscPaymentHeaders), storedOutput.Id), userIds: userIds);
            }

            return storedOutput;
        }

        public async override Task<ScPortalRequestMgrDecisionDto> Update(ScPortalRequestMgrDecisionEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAllIncluding(x => x.ScPortalRequestStudy.ScPortalRequest.AidRequestType).FirstOrDefaultAsync(z => z.Id == input.Id);

            bool isElctronic = input.MgrDecisionElectronicAids?.Count > 0 && current.ScPortalRequestStudy.ScPortalRequest.AidRequestType.IsElectronics;

            current.UpdateDate(isElctronic ? input.MgrDecisionElectronicAids.Sum(z => z.Amount) : input.Amount, input.DecisionDate, input.CashingTo, (isElctronic ? null : input.OtherAidLkpId), (isElctronic ? null : input.OtherMonthNo), (isElctronic ? current.IsMedicine : input.IsMedicine), (isElctronic ? 1 : input.NumberOfMonths), input.Notes);

            await Repository.UpdateAsync(current);

            var currentStudy = await _repoScPortalRequestStudy.GetAsync((long)input.PortalRequestStudyId);

            if (currentStudy != null)
            {
                currentStudy.UpdateManagerData(input.ScPortalRequestStudy.StudyDetails, input.ScPortalRequestStudy.ResearcherDecision);
                await _repoScPortalRequestStudy.UpdateAsync(currentStudy);
            }

            if (isElctronic) await CRUD_ScPRMgrDecisionElectronicAid(input.MgrDecisionElectronicAids, input.Id);

            return null;
        }

        public async Task<PostOutputWithId> PostManagerRefuseReason(ManagerRefuseReasonInput input)
        {
            PostDto postDto = new PostDto
            {
                Lang = "ar-EG",
                Id = input.Id,
                UserId = AbpSession.UserId ?? 0
            };

            var result = await _scScPortalRequestMgrDecisionPostRepository.Execute(postDto, "ScPortalRequestMgrDecRefuseForUpdate");

            if (result?.FirstOrDefault()?.FinalStatues == "F") return result.FirstOrDefault();

            var current = await Repository.GetAsync(input.Id);

            current.UpdateRefuseForUpdateReason(input.ManagerRefuseResaon);

            _ = await Repository.UpdateAsync(current);

            return result.FirstOrDefault();
        }

        public async Task<IReadOnlyList<ScPRMgrDecisionElectronicAidDto>> GetAllScPRMgrDecisionElectronicAid(EntityDto<long> input)
        {
            var data = await _repoScPRMgrDecisionElectronicAid.GetAllIncluding(x => x.FndElectronicTypeLkp)
                .Where(z => z.ScPortalRequestMgrDecisionId == input.Id).ToListAsync();

            return ObjectMapper.Map<IReadOnlyList<ScPRMgrDecisionElectronicAidDto>>(data);
        }

        private async Task InsertScPRMgrDecisionElectronicAidData(ScPRMgrDecisionElectronicAidDto electronicAidDto, long parentId)
        {
            electronicAidDto.ScPortalRequestMgrDecisionId = parentId;

            var scPRMgrDecisionElectronic = ObjectMapper.Map<ScPRMgrDecisionElectronicAid>(electronicAidDto);

            _ = await _repoScPRMgrDecisionElectronicAid.InsertAsync(scPRMgrDecisionElectronic);
        }

        private async Task CRUD_ScPRMgrDecisionElectronicAid(ICollection<ScPRMgrDecisionElectronicAidDto> electronicAidDtos, long parentId)
        {
            if (electronicAidDtos?.Count > 0)
            {
                foreach (var item in electronicAidDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoScPRMgrDecisionElectronicAid.GetAsync((long)item.Id);

                        item.ScPortalRequestMgrDecisionId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoScPRMgrDecisionElectronicAid.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertScPRMgrDecisionElectronicAidData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScPRMgrDecisionElectronicAid.DeleteAsync((long)item.Id);
                    }
                }
            }
        }
    }
}
