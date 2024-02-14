#region usings
using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.Notifications;
using Abp.UI;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__AidModule._ScPortalRequestStudy.Dto;
using ERP._System.__AidModule._ScPortalRequestStudy.Proc;
using ERP._System.__AidModule._ScPortalRequestStudy.ProcDto;
using ERP._System.__AidModule._ScPortalRequestStudyAttachment;
using ERP._System.__AidModule._ScPortalRequestStudyAttachment.Dto;
using ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Core;
using ERP.Core.Helpers.Extensions;
using ERP.Events.Data;
using ERP.Events.Handlers;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
#endregion
namespace ERP._System.__AidModule._ScPortalRequestStudy
{
    [AbpAuthorize]
    public class ScPortalRequestStudyAppService : AttachBaseAsyncCrudAppService<ScPortalRequestStudy, ScPortalRequestStudyDto, long, PagedScPortalRequestStudyResultRequestDto, CreateScPortalRequestStudyDto, ScPortalRequestStudyEditDto, ScPortalRequestStudyAttachment>,
        IScPortalRequestStudyAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<User, long> _repoUser;
        private readonly IRepository<ScPortalRequestStudyAttachment, long> _repoScPortalRequestStudyAttachment;
        private readonly IRepository<ScCommitteeDetail, long> _repoCommitteeDetail;
        private readonly IRepository<ScPortalRequestMgrDecision, long> _repoScPortalRequestMgrDecision;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IScPortalRequestStudyProcRepository _scPortalRequestStudyProcRepository;
        private readonly IScPortalRequestStudyPostRepository _scPortalRequestStudyPostRepository;
        private readonly INotificationPublisher _notificationPublisher;
        private readonly UserManager _userManager;
        private readonly IGetScPortalRequestStudyScreenDataRepository _getScPortalRequestStudyScreenDataRepository;

        public IEventBus EventBus { get; set; }

        public ScPortalRequestStudyAppService(IGetCounterRepository repoProcCounter,
            IRepository<ScPortalRequestStudyAttachment, long> repoScPortalRequestStudyAttachment,
            IRepository<ScPortalRequestStudy, long> repository,
            IRepository<ScCommitteeDetail, long> repoCommitteeDetail,
            IRepository<ScPortalRequestMgrDecision, long> repoScPortalRequestMgrDecision,
            IRepository<User, long> repoUser,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IScPortalRequestStudyProcRepository scPortalRequestStudyProcRepository,
            IScPortalRequestStudyPostRepository scPortalRequestStudyPostRepository,
            IConfiguration config,
            INotificationPublisher notificationPublisher,
            UserManager userManager,
            IGetScPortalRequestStudyScreenDataRepository getScPortalRequestStudyScreenDataRepository) : base(repository, config)
        {
            _repoProcCounter = repoProcCounter;
            _repoScPortalRequestStudyAttachment = repoScPortalRequestStudyAttachment;
            _repoCommitteeDetail = repoCommitteeDetail;
            _scPortalRequestStudyProcRepository = scPortalRequestStudyProcRepository;
            _scPortalRequestStudyPostRepository = scPortalRequestStudyPostRepository;
            _notificationPublisher = notificationPublisher;
            _userManager = userManager;
            _repoUser = repoUser;
            _getScPortalRequestStudyScreenDataRepository = getScPortalRequestStudyScreenDataRepository;
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoScPortalRequestMgrDecision = repoScPortalRequestMgrDecision;

            CreatePermissionName = PermissionNames.Pages_ScPortalRequestStudy_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScPortalRequestStudy_Update;
            DeletePermissionName = PermissionNames.Pages_ScPortalRequestStudy_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScPortalRequestStudy;

            PreFileName = "Request-Studied";
            ServiceFolder = "PortalRequests/Studied";
            baseURL = _config.GetValue<string>("FrontURL");
        }

        string baseURL; // = _config.GetValue<string>("FrontURL");

        protected override async Task<ScPortalRequestStudyAttachment> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return await _repoScPortalRequestStudyAttachment.FirstOrDefaultAsync(att => att.Id == Id && att.PortalRequestStudyId == ParentId && att.FilePath == filePath); ;
        }

        public async override Task<ScPortalRequestStudyDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndOtherAidLkp).Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<ScPortalRequestStudyDto>(current);
        }

        public async override Task<PagedResultDto<ScPortalRequestStudyDto>> GetAll(PagedScPortalRequestStudyResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.ScPortalRequest.AidRequestType ,x=> x.FndLookupValuesStatusLkp, x => x.FndLookupValuesRefuseLkp, x => x.ScPortalRequest, x => x.ScPortalRequestStudyAttachment, x => x.FndLookupValuesStudyLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromStudyDate))
                queryable = queryable.Where(q => q.StudyDate >= DateTimeController.ConvertToDateTime(input.Params.FromStudyDate));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToStudyDate))
                queryable = queryable.Where(q => q.StudyDate <= DateTimeController.ConvertToDateTime(input.Params.ToStudyDate));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.StudyNumber))
                queryable = queryable.Where(q => q.StudyNumber.Contains(input.Params.StudyNumber));

            if (input.Params != null && input.Params.PortalRequestId != null)
                queryable = queryable.Where(q => q.PortalRequestId == input.Params.PortalRequestId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.CaseNameId != null)
                queryable = queryable.Where(q => q.ScPortalRequest.PortalUsersId == input.Params.CaseNameId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScPortalRequestStudyDto>());

            var PagedResultDto = new PagedResultDto<ScPortalRequestStudyDto>()
            {
                Items = data2 as IReadOnlyList<ScPortalRequestStudyDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<ScPortalRequestStudyDto> Create(CreateScPortalRequestStudyDto input)
        {
            CheckCreatePermission();

            input.StudyNumber = await GetPortalRequestStudyNumber();

            if (AbpSession.TenantId != null && AbpSession.TenantId != Convert.ToInt32(TenantsEnum.Tenants.Um_Quiain_Khairiah) &&
                !string.IsNullOrEmpty(input.codeComUtilityIds))
            {
                var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

                if (currentComCodeId == null) throw new UserFriendlyException("حساب الصرف مطلوب");

                input.AccountId = currentComCodeId;
            }

            var currentScCampains = await base.Create(input);

            if (input.ListAttachments.Count > 0)
            {
                foreach (var item in input.ListAttachments)
                {
                    item.PortalRequestStudyId = currentScCampains.Id;

                    _ = await _repoScPortalRequestStudyAttachment.InsertAsync(ObjectMapper.Map<ScPortalRequestStudyAttachment>(item));
                }
            }

            return new ScPortalRequestStudyDto { };
        }

        public async override Task<ScPortalRequestStudyDto> Update(ScPortalRequestStudyEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequestStudyStatus) &&
                current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.Postponed_ScPortalRequestStudy) &&
                current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.RefuseForUpdateReason_ScPortalRequestStudy))
                throw new UserFriendlyException("Can not update request, it is not new.");

            if (AbpSession.TenantId != null && AbpSession.TenantId != Convert.ToInt32(TenantsEnum.Tenants.Um_Quiain_Khairiah) &&
                !string.IsNullOrEmpty(input.codeComUtilityIds))
            {
                var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

                if (currentComCodeId == null) throw new UserFriendlyException("حساب الصرف مطلوب");

                input.AccountId = (long)currentComCodeId;

                ObjectMapper.Map(input, current);

                _ = await Repository.UpdateAsync(current);

                current.SetAccountId((long)currentComCodeId);
            }
            else
            {
                _ = await base.Update(input);
            }

            if (input.ListAttachments.Count > 0)
            {
                foreach (var item in input.ListAttachments)
                {
                    if (item.Id != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var scCampainsDetail = await _repoScPortalRequestStudyAttachment.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, scCampainsDetail);

                        _ = await _repoScPortalRequestStudyAttachment.UpdateAsync(scCampainsDetail);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.PortalRequestStudyId = input.Id;

                        _ = await _repoScPortalRequestStudyAttachment.InsertAsync(ObjectMapper.Map<ScPortalRequestStudyAttachment>(item));
                    }
                    else if (item.Id != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScPortalRequestStudyAttachment.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new ScPortalRequestStudyDto { };
        }

        public async Task<ScPortalRequestStudyDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndLookupValuesStatusLkp, x => x.FndLookupValuesRefuseLkp,
                               x => x.ScPortalRequest.PortalUser, x => x.FndLookupValuesStudyLkp, x => x.FndOtherAidLkp,
                               x => x.GlCodeComDetails, x => x.ScPortalRequest)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<ScPortalRequestStudyDto>(current);


            if (current.CreatorUserId != null)
            {
                var creatorUser = await _repoUser.GetAsync((long)current.CreatorUserId);

                currentDto.ResearcherName = creatorUser.UserName;
            }

            var currentCodeCom = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetails, _app.Reqlanguage);

            currentDto.codeComUtilityIds = currentCodeCom.ids;
            currentDto.codeComUtilityTexts = currentCodeCom.texts;

            currentDto.CaseName = current.ScPortalRequest.Name;

            if (current.StatusLkpId == 168)
            {
                long postedCommittedId = 157; // Convert.ToInt64(FndEnum.FndLkps.Posted_ScCommittee);
                long postedCommittedDetailId = 291;// Convert.ToInt64(FndEnum.FndLkps.Posted_ScCommitteeDetailsStatus);

                var currentCommitteeDetail = await _repoCommitteeDetail.GetAllIncluding(x => x.Committee)
                                              .Where(z => z.RequestStudyId == input.Id && z.StatusLkpId == postedCommittedDetailId && z.Committee.StatusLkpId == postedCommittedId)
                                              .FirstOrDefaultAsync();

                currentDto.DecisionInfo = currentCommitteeDetail != null && currentCommitteeDetail.AidAmount.HasValue ? $" تم صرف مساعده ماليه بقيمه  {currentCommitteeDetail.AidAmount.Value.ToString("0.##") }  درهم لمده  {currentCommitteeDetail.NoOfMonths} شهر" : string.Empty;

                if (string.IsNullOrEmpty(currentDto.DecisionInfo))
                {
                    long postedManagerDecisionId = 173;

                    var currentMngr = await _repoScPortalRequestMgrDecision.GetAll()
                                          .Where(z => z.PortalRequestStudyId == input.Id && z.StatusLkpId == postedManagerDecisionId).FirstOrDefaultAsync();

                    currentDto.DecisionInfo = currentMngr == null ? string.Empty : $"تم صرف مساعده ماليه بقيمه   {(currentMngr.Amount == null ? string.Empty : currentMngr.Amount.Value.ToString("0.##"))}  درهم لمده 1 شهر ";
                }
            }

            return currentDto;
        }

        public async override Task Delete(EntityDto<long> input)
        {
            CheckDeletePermission();

            var current = await Repository.GetAsync(input.Id);

            if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequestStudyStatus))
                throw new UserFriendlyException("Can not delete request, it is not new.");

            var ids = await _repoScPortalRequestStudyAttachment.GetAll().Where(z => z.PortalRequestStudyId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var id in ids) await _repoScPortalRequestStudyAttachment.DeleteAsync(id);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<List<ScPortalRequestStudyAttachmentDto>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<ScPortalRequestStudyAttachmentDto>>(
                await _repoScPortalRequestStudyAttachment
                .GetAllIncluding()
                .Where(d => d.PortalRequestStudyId == input.Id).ToListAsync()
                );
        }

        public async Task<PostOutputWithId> ScPortalRequestStudyPostCommittee(PostDto idLangInputDto)
        {
            idLangInputDto.UserId = (long)AbpSession.UserId;

            var result = await _scPortalRequestStudyPostRepository.Execute(idLangInputDto, "ScPortalRequestStudyPostCommittee");
            var storedOutput = result.FirstOrDefault();

            if (storedOutput != null && storedOutput.FinalStatues.ToLower() == "s")
            {
                var scPortalRequestStudy = Repository.GetAllIncluding(pr => pr.ScPortalRequest).FirstOrDefault(pr => pr.Id == idLangInputDto.Id);
                var encId = CipherStringController.Encrypt(storedOutput.Id.ToString());
                var userIds = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_ScPortalRequestMgrDecision).Select(p => new UserIdentifier(AbpSession.TenantId, p.Id)).ToArray();
                var link = $"{baseURL}/ScCommittee/";
                var msg = $"تم دراسة الطلب رقم <u>{scPortalRequestStudy?.ScPortalRequest?.PortalRequestNumber}</u> باسم <u>{scPortalRequestStudy?.ScPortalRequest?.Name}</u>";
                var notif = new MessageNotificationData(msg);
                notif.Properties.Add("link", link);

                EventBus.Trigger(new ScPortalRequestStudyPostedToCommitteeEventData()
                {
                    scPortalRequestStudy = scPortalRequestStudy // Repository.GetAllIncluding(pr => pr.ScPortalRequest).FirstOrDefault(pr => pr.Id == idLangInputDto.Id)
                    //, encId = CipherStringController.Encrypt(Repository.GetAllIncluding(pr => pr.ScCommitteeDetail).Where(pr => pr.Id == idLangInputDto.Id).SelectMany(pr => pr.ScCommitteeDetail).OrderByDescending(mgr => mgr.CreationTime).FirstOrDefault().CommitteeId.ToString())
                });
                await _notificationPublisher.PublishAsync("Committee", notif, new EntityIdentifier(typeof(ScPortalRequestMgrDecision), storedOutput.Id), userIds: userIds);
            }
            return storedOutput;
        }

        public async Task<PostOutput> ScPortalRequestStudyRefuse(PostDto postDto, long? refuseLkpId, string refuseDescription)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scPortalRequestStudyProcRepository.Execute(postDto, "ScPortalRequestStudyRefuse");

            var current = await Repository.GetAsync(postDto.Id);

            current.SetRefuseData(refuseLkpId: refuseLkpId, refuseDescription: refuseDescription);

            if (result.FirstOrDefault().FinalStatues != "F") _ = await Repository.UpdateAsync(current);

            return result.FirstOrDefault();
        }

        public async Task<PostOutputWithId> ScPortalRequestStudyPostManager(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _scPortalRequestStudyPostRepository.Execute(postDto, "ScPortalRequestStudyPostManager");

            var storedOutput = result.FirstOrDefault();

            if (storedOutput != null && storedOutput.FinalStatues.ToLower() == "s")
            {
                var scPortalRequestStudy = Repository.GetAllIncluding(pr => pr.ScPortalRequest).FirstOrDefault(pr => pr.Id == postDto.Id);
                var encId = CipherStringController.Encrypt(storedOutput.Id.ToString());
                var userIds = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_ScPortalRequestMgrDecision).Select(p => new UserIdentifier(AbpSession.TenantId, p.Id)).ToArray();
                //var dataProps = new Dictionary<string, object>();
                var link = NotifyFor30DaysRemainOnContractWorker.GenerateFormViewLinkForEmailBody("ScPortalRequestMgrDecision", encId, _config: _config);
                var msg = $"تم دراسة الطلب رقم <u>{scPortalRequestStudy?.ScPortalRequest?.PortalRequestNumber}</u> باسم <u>{scPortalRequestStudy?.ScPortalRequest?.Name}</u>";
                var notif = new MessageNotificationData(msg);
                notif.Properties.Add("link", link);

                //await _notificationPublisher.PublishAsync("Manger Descision", new MessageNotificationData($"تم دراسة الطلب رقم <u>{scPortalRequestStudy?.ScPortalRequest?.PortalRequestNumber}</u> باسم <u>{scPortalRequestStudy?.ScPortalRequest?.Name}</u> <a href='{link}'>شاشة قرار المدير </a>") { Properties } , new EntityIdentifier(typeof(ScPortalRequestMgrDecision), storedOutput.Id), userIds: userIds);
                EventBus.Trigger(new ScPortalRequestStudyTransferedToManagerEventData()
                {
                    scPortalRequestStudy = scPortalRequestStudy, //Repository.GetAllIncluding(pr => pr.ScPortalRequest).FirstOrDefault(pr => pr.Id == postDto.Id),
                    encId = encId
                });
                await _notificationPublisher.PublishAsync("Manger Descision", notif, new EntityIdentifier(typeof(ScPortalRequestMgrDecision), storedOutput.Id), userIds: userIds);
            }
            return storedOutput;
        }

        public async Task<PostOutputWithId> UnPostScPortalRequestStudy(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _scPortalRequestStudyPostRepository.Execute(postDto, "ScPortalRequestStudyUnpost");

            return result.FirstOrDefault();
        }

        public async Task<List<ScPortalRequestStudyScreenDataOutput>> GetScPortalRequestStudyScreenData(IdLangInputDto input)
        {
            var result = await _getScPortalRequestStudyScreenDataRepository.Execute(input, "GetScPortalRequestStudyScreenData");

            return result.ToList();
        }

        public void getMailingList()
        {
            EventBus.Trigger(new ScPortalRequestStudyPostedToCommitteeEventData() { scPortalRequestStudy = null });
        }

        public async Task<Select2PagedResult> GetScPortalRequestStudyByNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await GetPortalRequestStudies("number", searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScPortalRequestStudyByUserSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await GetPortalRequestStudies("name", searchTerm, pageSize, pageNumber, lang);

        private async Task<string> GetPortalRequestStudyNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "ScPortalRequestStudy", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }

        private async Task<Select2PagedResult> GetPortalRequestStudies(string trigger, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var studyIds = _repoCommitteeDetail.GetAll().Where(z => z.StatusLkpId != (long)FndEnum.FndLkps.PostponedToStudy_ScCommitteeDetailsStatus).Select(s => s.RequestStudyId);

            var data = Repository.GetAllIncluding(z => z.ScPortalRequest.PortalUser, z => z.ScPortalRequest.AidRequestType)
                    .Where(z => (string.IsNullOrEmpty(searchTerm) || z.ScPortalRequest.Name.Contains(searchTerm) || z.ScPortalRequest.IdNumber.Contains(searchTerm))
                      && !studyIds.Contains(z.Id) && z.StatusLkpId.Value == (long)FndEnum.FndLkps.ScPortalRequestStudy_TransferedToCommittee);

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(z => new Select2OptionModel { id = z.Id, altText = $"{ (trigger == "number" ? z.ScPortalRequest.PortalUser.Name : z.ScPortalRequest.PortalRequestNumber)}-{ z.ScPortalRequest.AidRequestType.IsElectronics}-{ z.ScPortalRequest.AidRequestType.IsMaintenance}", text = $"{ (trigger == "name" ? z.ScPortalRequest.PortalUser.Name : z.ScPortalRequest.PortalRequestNumber)}" })
                .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
