#region unsings
using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__AidModule._PortalUserData;
using ERP._System.__AidModule._PortalUserData.Dto;
using ERP._System.__AidModule._ScFndAidRequestType.Dto;
using ERP._System.__AidModule._ScFndProtalAttachmentSetting;
using ERP._System.__AidModule._ScFndProtalAttachmentSetting.Dto;
using ERP._System.__AidModule._ScPortalRequest.Dto;
using ERP._System.__AidModule._ScPortalRequest.Proc;
using ERP._System.__AidModule._ScPortalRequest.Proc.Dto;
using ERP._System.__AidModule._ScPortalRequestVisited;
using ERP._System.__AidModule._ScPortalRequestVisited.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace ERP._System.__AidModule._ScPortalRequest
{
    [AbpAuthorize]
    public class ScPortalRequestAppService : AttachBaseAsyncCrudAppService<ScPortalRequest, ScPortalRequestDto, long, ScPortalRequestPagedDto, ScPortalRequestCreateDto, ScPortalRequestEditDto, ScPortalRequestAttachment>
        , IScPortalRequestAppService
    {
        private readonly IRepository<ScPortalRequestAttachment, long> _attachmentRepo;
        private readonly IRepository<ScPortalRequestVisited, long> _repoScPortalRequestVisited;
        private readonly IRepository<ScPortalRequestIncome, long> _repoScPortalRequestIncome;
        private readonly IRepository<ScPortalRequestDuties, long> _repoScPortalRequestDuties;
        private readonly IRepository<PortalUser, long> _portalUserRepo;
        private readonly IRepository<PortalUserData, long> _repoPortalUserData;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;
        private readonly IRepository<ScFndProtalAttachmentSetting, long> _repoScFndProtalAttachmentSetting;
        private readonly IImageConfig _imageConfig;
        private readonly IScPortalRequestManager _scPortalRequestManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IScPortalRequestPostRepository _scPortalRequestPostRepository;
        private readonly IScPortalRequestTenantsRepository _scPortalRequestTenantsRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ScPortalRequestAppService(IRepository<ScPortalRequest, long> repository,
            IRepository<ScPortalRequestIncome, long> repoScPortalRequestIncome,
            IRepository<ScPortalRequestDuties, long> repoScPortalRequestDuties,
            IRepository<ScPortalRequestAttachment, long> AttachmentRepo,
            IRepository<PortalUser, long> PortalUserRepo,
            IRepository<PortalUserData, long> repoPortalUserData,
            IRepository<ScPortalRequestVisited, long> repoScPortalRequestVisited,
            IRepository<FndLookupValues, long> repoFndLookupValues,
            IRepository<ScFndProtalAttachmentSetting, long> repoScFndProtalAttachmentSetting,
            IScPortalRequestManager scPortalRequestManager, IConfiguration config,
            IImageConfig ImageConfig, IGetCounterRepository repoProcCounter,
            IScPortalRequestPostRepository scPortalRequestPostRepository,
            IScPortalRequestTenantsRepository scPortalRequestTenantsRepository,
            IHostingEnvironment hostingEnvironment) : base(repository, config)
        {
            _repoScFndProtalAttachmentSetting = repoScFndProtalAttachmentSetting;
            _scPortalRequestManager = scPortalRequestManager;
            _attachmentRepo = AttachmentRepo;
            _portalUserRepo = PortalUserRepo;
            _imageConfig = ImageConfig;
            _repoProcCounter = repoProcCounter;
            _repoScPortalRequestVisited = repoScPortalRequestVisited;
            _hostingEnvironment = hostingEnvironment;
            _repoFndLookupValues = repoFndLookupValues;
            _scPortalRequestPostRepository = scPortalRequestPostRepository;
            _scPortalRequestTenantsRepository = scPortalRequestTenantsRepository;
            _repoScPortalRequestIncome = repoScPortalRequestIncome;
            _repoScPortalRequestDuties = repoScPortalRequestDuties;
            _repoPortalUserData = repoPortalUserData;

            CreatePermissionName = PermissionNames.Pages_ScPortalRequests_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScPortalRequests_Update;
            DeletePermissionName = PermissionNames.Pages_ScPortalRequests_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScPortalRequests;
        }

        #region Dashboard System

        protected async override Task<ScPortalRequestAttachment> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return await _attachmentRepo.FirstOrDefaultAsync(att => att.Id == Id && att.PortalRequestId == ParentId && att.FilePath == filePath); ;
        }

        public override async Task<ScPortalRequestDto> Create(ScPortalRequestCreateDto input)
        {
            CheckCreatePermission();

            input.PortalRequestNumber = await GetProtalRequestNumber();

            var current = await base.Create(input);

            if (input.RequestAttachments != null && input.RequestAttachments.Count > 0)
            {
                foreach (var item in input.RequestAttachments)
                {
                    item.PortalRequestId = current.Id;

                    await _attachmentRepo.InsertAsync(ObjectMapper.Map<ScPortalRequestAttachment>(item));
                }
            }

            if (input.RequestVisits != null && input.RequestVisits.Count > 0)
            {
                var newVisitStatusLkpId = Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequestVisited);

                foreach (var item in input.RequestVisits)
                {
                    item.visitStatusLkpId = newVisitStatusLkpId;
                    item.PortalRequestId = current.Id;

                    await _repoScPortalRequestVisited.InsertAsync(ObjectMapper.Map<ScPortalRequestVisited>(item));
                }
            }

            return current;
        }

        public override async Task<ScPortalRequestDto> Update(ScPortalRequestEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            if (current.StatusLkpId == Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequest))
            {
                input.TenantId = current.TenantId;

                ObjectMapper.Map(input, current);

                _ = await Repository.UpdateAsync(current);

                if (input.RequestAttachments != null)
                {
                    foreach (var item in input.RequestAttachments)
                    {
                        item.PortalRequestId = input.Id;

                        if (item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var entity = await _attachmentRepo.GetAsync(item.Id);

                            ObjectMapper.Map(item, entity);

                            await _attachmentRepo.UpdateAsync(entity);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            await _attachmentRepo.InsertAsync(ObjectMapper.Map<ScPortalRequestAttachment>(item));
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _attachmentRepo.DeleteAsync(item.Id);
                        }
                    }
                }

                if (input.RequestVisits != null && input.RequestVisits.Count > 0)
                {
                    var newVisitStatusLkpId = Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequestVisited);

                    foreach (var item in input.RequestVisits)
                    {
                        if (item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            await _repoScPortalRequestVisited.DeleteAsync((long)item.id);

                            item.PortalRequestId = input.Id;
                            item.visitStatusLkpId = newVisitStatusLkpId;

                            await _repoScPortalRequestVisited.InsertAsync(ObjectMapper.Map(item, new ScPortalRequestVisited()));
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            item.PortalRequestId = input.Id;
                            item.visitStatusLkpId = newVisitStatusLkpId;

                            await _repoScPortalRequestVisited.InsertAsync(ObjectMapper.Map(item, new ScPortalRequestVisited()));
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoScPortalRequestVisited.DeleteAsync((long)item.id);
                        }
                    }
                }

                if (current.SourceLkpId == Convert.ToInt64(FndEnum.FndLkps.Portal_ScPortalRequestSource) && input.RequestDuties != null && input.RequestDuties.Count > 0)
                {
                    foreach (var item in input.RequestDuties)
                    {
                        if (item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var currentEntity = await _repoScPortalRequestDuties.GetAsync((long)item.Id);

                            item.PortalRequestId = input.Id;

                            ObjectMapper.Map(item, currentEntity);

                            await _repoScPortalRequestDuties.UpdateAsync(currentEntity);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            item.PortalRequestId = input.Id;

                            var entityMapped = ObjectMapper.Map(item, new ScPortalRequestDuties());

                            await _repoScPortalRequestDuties.InsertAsync(entityMapped);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoScPortalRequestDuties.DeleteAsync((long)item.Id);
                        }
                    }
                }

                if (current.SourceLkpId == Convert.ToInt64(FndEnum.FndLkps.Portal_ScPortalRequestSource) && input.RequestIncomes != null && input.RequestIncomes.Count > 0)
                {
                    foreach (var item in input.RequestIncomes)
                    {
                        if (item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var currentEntity = await _repoScPortalRequestIncome.GetAsync((long)item.Id);

                            item.PortalRequestId = input.Id;

                            ObjectMapper.Map(item, currentEntity);

                            await _repoScPortalRequestIncome.UpdateAsync(currentEntity);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            item.PortalRequestId = input.Id;

                            var entityMapped = ObjectMapper.Map(item, new ScPortalRequestIncome());

                            await _repoScPortalRequestIncome.InsertAsync(entityMapped);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoScPortalRequestIncome.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }
            else throw new UserFriendlyException("Can not delete request, it is not new.");

            return MapToEntityDto(current);
        }

        public async Task<ScPortalRequestDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndLookupValuesStatusLkp,
                               x => x.Researcher, x => x.FndLookupValuesSourceLkp, x => x.PortalUser, x => x.AidRequestType)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<ScPortalRequestDto>(current);


            var currentLkp = await _repoFndLookupValues.GetAsync(currentDto.AidRequestType.AidRequestTypeLkpId);

            currentDto.AidRequestType = new ScFndAidRequestTypeDto
            {
                NameAr = currentLkp.NameAr,
                NameEn = currentLkp.NameEn
            };

            return currentDto;
        }

        public async override Task<PagedResultDto<ScPortalRequestDto>> GetAll(ScPortalRequestPagedDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.AidRequestType, x => x.FndLookupValuesStatusLkp, x => x.PortalUser);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PortalRequestNumber))
                queryable = queryable.Where(q => q.PortalRequestNumber.Contains(input.Params.PortalRequestNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.AidRequestTypeId != null)
                queryable = queryable.Where(q => q.AidRequestTypeId == input.Params.AidRequestTypeId);

            if (input.Params != null && input.Params.SourceLkpId != null)
                queryable = queryable.Where(q => q.SourceLkpId == input.Params.SourceLkpId);

            if (input.Params != null && input.Params.PortalUsersId != null)
                queryable = queryable.Where(q => q.PortalUsersId == input.Params.PortalUsersId);

            if (input.Params != null && input.Params.ResearcherId != null)
                queryable = queryable.Where(q => q.ResearcherId == input.Params.ResearcherId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
            {
                DateTime dtFrom = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);

                queryable = queryable.Where(q => dtFrom <= q.PortalRequestDate);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
            {
                DateTime dtTo = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);

                queryable = queryable.Where(q => dtTo >= q.PortalRequestDate);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScPortalRequestDto>());

            foreach (var item in data2)
            {
                var currentLkp = await _repoFndLookupValues.GetAsync(item.AidRequestType.AidRequestTypeLkpId);

                item.AidRequestType = new ScFndAidRequestTypeDto
                {
                    NameAr = currentLkp.NameAr,
                    NameEn = currentLkp.NameEn
                };
            }

            var PagedResultDto = new PagedResultDto<ScPortalRequestDto>()
            {
                Items = data2 as IReadOnlyList<ScPortalRequestDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<List<ScPortalRequestVisitedDto>> GetAllVisitsDetails(long id)
        {
            var output = new List<ScPortalRequestVisitedDto>();

            var listData = await _repoScPortalRequestVisited.GetAllIncluding(z => z.FndLookupValues)
                                  .Where(d => d.PortalRequestId == id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new ScPortalRequestVisitedDto
                {
                    id = item.Id,
                    PortalRequestId = item.PortalRequestId,
                    mobileNumber = item.MobileNumber,
                    visitDate = item.VisitDate.ToString(Formatters.DateTimeFormat_AM_PM),
                    visitStatusLkpId = item.VisitStatusLkpId,
                    visitTime = $"{item.VisitDate.Hour}:{item.VisitDate.Minute}",
                    visitStatusLkp = $"{item.FndLookupValues.NameAr}",
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<ScPortalRequestIncomeDto>> GetAllIncomesDetails(EntityDto<long> input)
        {
            var output = new List<ScPortalRequestIncomeDto>();

            var listData = await _repoScPortalRequestIncome.GetAll().Where(d => d.PortalRequestId == input.Id)
                                        .ToListAsync();

            foreach (var item in listData)
            {
                var current = new ScPortalRequestIncomeDto
                {
                    Id = item.Id,
                    PortalRequestId = item.PortalRequestId,
                    IncomeSourceName = item.IncomeSourceName,
                    MonthlyIncomeAmount = item.MonthlyIncomeAmount,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<ScPortalRequestDutiesDto>> GetAllDutiesDetails(EntityDto<long> input)
        {
            var output = new List<ScPortalRequestDutiesDto>();

            var listData = await _repoScPortalRequestDuties.GetAll().Where(d => d.PortalRequestId == input.Id)
                                        .ToListAsync();

            foreach (var item in listData)
            {
                var current = new ScPortalRequestDutiesDto
                {
                    Id = item.Id,
                    PortalRequestId = item.PortalRequestId,
                    DutyDescription = item.DutyDescription,
                    DutyType = item.DutyType,
                    MonthlyAmount = item.MonthlyAmount,
                    TotalAmount = item.TotalAmount,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<ScPortalRequestAttachmentDto>> GetAllAttachmentsDetails(long id, long aidRequestId)
        {
            var output = new List<ScPortalRequestAttachmentDto>();

            var listData = await _attachmentRepo
                .GetAllIncluding(z => z.GetScFndProtalAttachmentSetting)
                .Where(d => d.PortalRequestId == id)
                .ToListAsync();

            foreach (var item in listData)
            {
                var attchSetting = ObjectMapper.Map<ScFndProtalAttachmentSettingDto>(item.GetScFndProtalAttachmentSetting);

                attchSetting.attchId = item.Id;
                attchSetting.filePath = item.FilePath;
                attchSetting.fileName = attchSetting.AttachmentNameAr;
                attchSetting.rowStatus = DetailRowStatus.RowStatus.NoAction.ToString();

                var current = new ScPortalRequestAttachmentDto { GetScFndProtalAttachmentSetting = attchSetting };

                output.Add(current);
            }

            var idsInDetails = listData.Select(z => z.ProtalAttachmentSettingId).ToList();

            var reminded = await _repoScFndProtalAttachmentSetting.GetAll().Where(z => !idsInDetails.Contains(z.Id) && z.IsActive && z.RequestTypeId == aidRequestId).ToListAsync();

            foreach (var item in reminded)
            {
                var attchSetting = ObjectMapper.Map<ScFndProtalAttachmentSettingDto>(item);
                var current = new ScPortalRequestAttachmentDto
                {
                    GetScFndProtalAttachmentSetting = attchSetting,
                    rowStatus = DetailRowStatus.RowStatus.New.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async override Task Delete(EntityDto<long> input)
        {
            CheckDeletePermission();

            var current = Repository.Get(input.Id);

            if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequest))
                throw new UserFriendlyException("Can not delete request, it is not new.");

            var listVisited = await _repoScPortalRequestVisited.GetAll().Where(z => z.PortalRequestId == input.Id).ToListAsync();

            if (listVisited.Count > 0)
                foreach (var visit in listVisited)
                    await _repoScPortalRequestVisited.DeleteAsync(visit.Id);

            var attachments = await _attachmentRepo.GetAll().Where(z => z.PortalRequestId == input.Id).ToListAsync();

            if (attachments.Count > 0)
                foreach (var attch in attachments)
                {
                    await _attachmentRepo.DeleteAsync(attch.Id);

                    if (!string.IsNullOrEmpty(attch.FilePath))
                    {
                        string filePath = $"{_hostingEnvironment.ContentRootPath}/PortalRequests/{attch.FilePath}";

                        try
                        {
                            File.Delete(filePath);
                        }
                        catch (Exception x)
                        {
                            throw new UserFriendlyException(x.InnerException?.Message ?? x.Message);
                        }
                    }
                }

            await base.Delete(input);
        }

        #endregion

        #region Portal

        public async Task<IList<TenantsOutput>> GetAvailableTenants()
        {
            AvailableTenantsDto availableTenantsDto = new AvailableTenantsDto()
            {
                FromDate = DateTime.Now,
                TenantId = -1
            };

            return await _scPortalRequestTenantsRepository.Execute(availableTenantsDto, "ScGetAvailableTeneants");
        }

        public async Task<ScPortalRequestDto> PortalCreate(ScPortalRequestCreateDto input)
        {
            var portalUser = _portalUserRepo.FirstOrDefault(p => p.UserId == AbpSession.UserId);

            if (portalUser == null) throw new UserFriendlyException("Action not allowed!");

            input.PortalRequestDate = DateTime.Now.ToString(Formatters.DateFormat);

            input.PortalUsersId = portalUser.Id;

            CurrentUnitOfWork.SetTenantId(input.TenantId);

            input.PortalRequestNumber = await GetProtalRequestNumber(tenantId: input.TenantId);

            var portalUserData = await _repoPortalUserData.FirstOrDefaultAsync(z => z.PortalUserId == portalUser.Id);

            if (portalUserData == null)
            {
                var mapped = ObjectMapper.Map<PortalUserDataCreateDto>(portalUser);

                mapped.PortalUserId = portalUser.Id;

                await _repoPortalUserData.InsertAsync(ObjectMapper.Map<PortalUserData>(mapped));
            }

            var currentEntity = await Repository.InsertAsync(MapToEntity(input));

            if (input.RequestAttachments != null)
            {
                foreach (var item in input.RequestAttachments)
                {
                    item.PortalRequestId = currentEntity.Id;

                    var entity = ObjectMapper.Map<ScPortalRequestAttachment>(item);

                    await _attachmentRepo.InsertAsync(entity);
                }
            }

            if (input.RequestIncomes != null && input.RequestIncomes.Count > 0)
            {
                foreach (var item in input.RequestIncomes)
                {
                    item.PortalRequestId = currentEntity.Id;

                    var entity = ObjectMapper.Map<ScPortalRequestIncome>(item);

                    await _repoScPortalRequestIncome.InsertAsync(entity);
                }
            }

            if (input.RequestDuties != null && input.RequestDuties.Count > 0)
            {
                foreach (var item in input.RequestDuties)
                {
                    item.PortalRequestId = currentEntity.Id;

                    var entity = ObjectMapper.Map<ScPortalRequestDuties>(item);

                    await _repoScPortalRequestDuties.InsertAsync(entity);
                }
            }

            return MapToEntityDto(currentEntity);
        }

        public async Task<ScPortalRequestDto> PortalUpdate(ScPortalRequestEditDto input)
        {
            var portalUser = await _portalUserRepo.FirstOrDefaultAsync(p => p.UserId == AbpSession.UserId);

            CurrentUnitOfWork.SetTenantId(input.TenantId);

            var current = await Repository.GetAsync(input.Id);

            if (current.PortalUsersId != portalUser?.Id) throw new UserFriendlyException("Action not allowed!");

            input.PortalUsersId = portalUser.Id;

            input.PortalRequestDate = current.PortalRequestDate.ToString(Formatters.DateFormat);

            if (current.StatusLkpId == Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequest))
            {
                ObjectMapper.Map(input, current);

                _ = await Repository.UpdateAsync(current);

                foreach (var item in input.RequestAttachments)
                {
                    item.PortalRequestId = input.Id;

                    if (item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var entity = await _attachmentRepo.GetAsync(item.Id);

                        ObjectMapper.Map(item, entity);

                        await _attachmentRepo.UpdateAsync(entity);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await _attachmentRepo.InsertAsync(ObjectMapper.Map<ScPortalRequestAttachment>(item));
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _attachmentRepo.DeleteAsync(item.Id);
                    }
                }

                if (input.RequestDuties != null && input.RequestDuties.Count > 0)
                {
                    foreach (var item in input.RequestDuties)
                    {
                        if (item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var currentEntity = await _repoScPortalRequestDuties.GetAsync((long)item.Id);

                            item.PortalRequestId = input.Id;

                            ObjectMapper.Map(item, currentEntity);

                            await _repoScPortalRequestDuties.UpdateAsync(currentEntity);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            item.PortalRequestId = input.Id;

                            var entityMapped = ObjectMapper.Map(item, new ScPortalRequestDuties());

                            await _repoScPortalRequestDuties.InsertAsync(entityMapped);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoScPortalRequestDuties.DeleteAsync((long)item.Id);
                        }
                    }
                }

                if (input.RequestIncomes != null && input.RequestIncomes.Count > 0)
                {
                    foreach (var item in input.RequestIncomes)
                    {
                        if (item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var currentEntity = await _repoScPortalRequestIncome.GetAsync((long)item.Id);

                            item.PortalRequestId = input.Id;

                            ObjectMapper.Map(item, currentEntity);

                            await _repoScPortalRequestIncome.UpdateAsync(currentEntity);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            item.PortalRequestId = input.Id;

                            var entityMapped = ObjectMapper.Map(item, new ScPortalRequestIncome());

                            await _repoScPortalRequestIncome.InsertAsync(entityMapped);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoScPortalRequestIncome.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }
            else throw new UserFriendlyException("Can not edit request, it is not new.");

            return MapToEntityDto(current);
        }

        public async Task PortalDelete(EntityDto<long> input, int TenantId)
        {
            var portalUser = await _portalUserRepo.FirstOrDefaultAsync(p => p.UserId == AbpSession.UserId);

            var current = await Repository.GetAsync(input.Id);

            if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequest))
                throw new UserFriendlyException("Can not delete request, it is not new.");

            if (portalUser?.Id != current.PortalUsersId)
                throw new UserFriendlyException("Action not allowed.");

            CurrentUnitOfWork.SetTenantId(TenantId);

            DeletePermissionName = string.Empty;

            await base.Delete(input);
        }

        public async Task<ScPortalRequestDto> PortalGet(EntityDto<long> input, int TenantId)
        {
            var portalUser = await _portalUserRepo.FirstOrDefaultAsync(p => p.UserId == AbpSession.UserId);

            if (portalUser == null) throw new UserFriendlyException("Action not allowed!");

            CurrentUnitOfWork.SetTenantId(TenantId);

            long portaluserId = portalUser?.Id ?? -1;

            var entityList = await Repository.GetAllListAsync(item => item.Id == input.Id && item.PortalUsersId == portaluserId);// portalUser.Id);

            var entity = entityList.Find(i => i.Id == input.Id);

            var result = MapToEntityDto(entity);

            if (result.Attachments != null)
            {
                if (result.Attachments.Count == 0)
                {
                    var attachments = await _attachmentRepo.GetAllListAsync(a => a.PortalRequestId == result.Id);

                    result.Attachments = ObjectMapper.Map(attachments, new List<ScPortalRequestAttachmentDto>());
                }

            }

            var duties = await _repoScPortalRequestDuties.GetAllListAsync(z => z.PortalRequestId == result.Id);
            var incomes = await _repoScPortalRequestIncome.GetAllListAsync(z => z.PortalRequestId == result.Id);

            result.RequestDuties = ObjectMapper.Map<List<ScPortalRequestDutiesDto>>(duties);
            result.RequestIncomes = ObjectMapper.Map<List<ScPortalRequestIncomeDto>>(incomes);

            return result;
        }

        public async Task<PagedResultDto<ScPortalRequestDto>> PortalGetAll(ScPortalRequestPagedDto input)
        {
            var portalUser = _portalUserRepo.FirstOrDefault(p => p.UserId == AbpSession.UserId);

            long portaluserId = portalUser?.Id ?? -1;

            CurrentUnitOfWork.SetTenantId(null);

            var requests = await Repository.GetAllIncluding(pr => pr.FndLookupValuesStatusLkp).Where(l => l.PortalUsersId == portaluserId).ToListAsync();

            var data2 = ObjectMapper.Map(requests, new List<ScPortalRequestDto>());

            var PagedResultDto = new PagedResultDto<ScPortalRequestDto>()
            {
                Items = data2 as IReadOnlyList<ScPortalRequestDto>,
                TotalCount = requests.Count
            };

            return PagedResultDto;
        }

        public async Task<PostOutput> PostPortalRequest(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scPortalRequestPostRepository.Execute(postDto, "ScPortalRequestPost");

            if (result.FirstOrDefault().FinalStatues != "F")
            {
                var current = await Repository.GetAsync(postDto.Id);

                var currentPortalUser = await _repoPortalUserData.GetAllIncluding(x => x.PortalUser, x => x.PortalUserIncomes, x => x.PortalUserDuties,
                                                        x => x.CityFndLookupValues, x => x.PortalUser.NationalityFndLookupValues, x => x.QualificationFndLookupValues,
                                                        x => x.MaritalStatusFndLookupValues)
                    .Where(z => z.PortalUserId == current.PortalUsersId).FirstOrDefaultAsync();

                current.SetSharedProps(currentPortalUser);

                if (current.SourceLkpId == Convert.ToInt64(FndEnum.FndLkps.Manual_ScPortalRequestSource))
                {
                    var incomeDto = ObjectMapper.Map<List<ScPortalRequestIncomeDto>>(currentPortalUser.PortalUserIncomes);
                    var dutiesDto = ObjectMapper.Map<List<ScPortalRequestDutiesDto>>(currentPortalUser.PortalUserDuties);

                    dutiesDto.ForEach(item => item.PortalRequestId = current.Id);
                    incomeDto.ForEach(item => item.PortalRequestId = current.Id);

                    var dutiesEnitity = ObjectMapper.Map<List<ScPortalRequestDuties>>(dutiesDto);
                    var incomesEityty = ObjectMapper.Map<List<ScPortalRequestIncome>>(incomeDto);

                    if (dutiesEnitity != null && dutiesEnitity.Count > 0) current.SetDutiesCollection(dutiesEnitity);

                    if (incomesEityty != null && incomesEityty.Count > 0) current.SetIncomesCollection(incomesEityty);
                }

                await Repository.UpdateAsync(current);
            }

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> RefusePortalRequest(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scPortalRequestPostRepository.Execute(postDto, "ScPortalRequestRefuse");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> UnPostScPortalRequests(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scPortalRequestPostRepository.Execute(postDto, "ScPortalRequestUnPost");

            return result.FirstOrDefault();
        }

        #endregion

        public async Task<Select2PagedResult> GetScPortalRequestSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scPortalRequestManager.GetScPortalRequestSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScPortalRequestMaintenanceSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scPortalRequestManager.GetScPortalRequestMaintenanceSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScPortalRequestMaintenanceNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _scPortalRequestManager.GetScPortalRequestMaintenanceNameSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScPortalRequestForMgrSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scPortalRequestManager.GetScPortalRequestForMgrSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScPortalRequestForStudySelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _scPortalRequestManager.GetScPortalRequestForStudySelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScPortalRequestForStudyByNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _scPortalRequestManager.GetScPortalRequestForStudyByNameSelect2(searchTerm, pageSize, pageNumber, lang);

        private string GetFilePath(string base64, string fileExtension = ".jpeg")
            => _imageConfig.SaveImage(base64, $"Request-{Guid.NewGuid().ToString()}", fileExtension, "PortalRequests");

        private async Task<string> GetProtalRequestNumber(string lang = "ar-EG", int year = 0, int tenantId = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ScPortalRequest", TenantId = (tenantId != 0) ? tenantId : (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
