using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__PmPropertiesModule._PmProperties.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesAttachments;
using ERP._System.__PmPropertiesModule._PmPropertiesAttachments.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts;
using ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmProperties
{
    public class PmPropertiesAppService : AttachBaseAsyncCrudAppService<PmProperties, PmPropertiesDto, long, PagedPmPropertiesRequestDto, CreatePmPropertiesDto, PmPropertiesEditDto, PmPropertiesAttachments>,
                 IPmPropertiesAppService
    {
        private readonly IPmPropertiesManager _pmPropertiesManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IRepository<PmPropertiesAttachments, long> _repoPmPropertiesAttachments;
        private readonly IRepository<PmPropertiesRevenueAccounts, long> _repoPmPropertiesRevenueAccounts;
        private readonly IRepository<PmPropertiesUnits, long> _repoPmPropertiesUnits;
        private readonly IRepository<PmPropertiesUnitsAttachments, long> _repoPmPropertiesUnitsAttachments;

        public PmPropertiesAppService(IRepository<PmProperties, long> repository,
            IRepository<PmPropertiesAttachments, long> repoPmPropertiesAttachments,
            IRepository<PmPropertiesRevenueAccounts, long> repoPmPropertiesRevenueAccounts,
            IRepository<PmPropertiesUnits, long> repoPmPropertiesUnits,
            IRepository<PmPropertiesUnitsAttachments, long> repoPmPropertiesUnitsAttachments,
            IPmPropertiesManager pmPropertiesManager, IGlCodeComDetailsManager glCodeComDetailsManager,
            IConfiguration config, IGetCounterRepository getCounterRepository) : base(repository, config)
        {
            _pmPropertiesManager = pmPropertiesManager;
            _repoProcCounter = getCounterRepository;
            _repoPmPropertiesUnitsAttachments = repoPmPropertiesUnitsAttachments;
            _repoPmPropertiesAttachments = repoPmPropertiesAttachments;
            _repoPmPropertiesRevenueAccounts = repoPmPropertiesRevenueAccounts;
            _repoPmPropertiesUnits = repoPmPropertiesUnits;
            _glCodeComDetailsManager = glCodeComDetailsManager;

            CreatePermissionName = PermissionNames.Pages_PmProperties_Insert;
            UpdatePermissionName = PermissionNames.Pages_PmProperties_Update;
            DeletePermissionName = PermissionNames.Pages_PmProperties_Delete;
            GetAllPermissionName = PermissionNames.Pages_PmProperties;

            PreFileName = "PmProp-Attchs";
            ServiceFolder = "PmProperties";

        }

        protected override async Task<PmPropertiesAttachments> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return await _repoPmPropertiesAttachments.FirstOrDefaultAsync(att => att.Id == Id && att.PropertyId == ParentId && att.FilePath == filePath); ;
        }

        public async override Task<PagedResultDto<PmPropertiesDto>> GetAll(PagedPmPropertiesRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndCityLkp, x => x.FndStatusLkp, x => x.PmOwners);

            if (input.Params != null && input.Params.CityLkpId != null)
                queryable = queryable.Where(q => q.CityLkpId == input.Params.CityLkpId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.PropertyId != null)
                queryable = queryable.Where(q => q.Id == input.Params.PropertyId);

            if (input.Params != null && input.Params.PmOwnerId != null)
                queryable = queryable.Where(q => q.PmOwnerId == input.Params.PmOwnerId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            queryable = queryable.OrderByDescending(x => x.CreationTime);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<PmPropertiesDto>());

            var PagedResultDto = new PagedResultDto<PmPropertiesDto>()
            {
                Items = data2 as IReadOnlyList<PmPropertiesDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<PmPropertiesDto> Create(CreatePmPropertiesDto input)
        {
            CheckCreatePermission();

            if (input.PropRevenues.Count == 0) throw new UserFriendlyException("Revenues Required");

            input.PropertyNumber = await GetPmProperityNumber();

            var pmProperties = await base.Create(input);

            if (input.PropAttachments.Count > 0)
            {
                foreach (var item in input.PropAttachments)
                {
                    item.PropertyId = pmProperties.Id;

                    var currentPropAttachments = ObjectMapper.Map<PmPropertiesAttachments>(item);

                    _ = await _repoPmPropertiesAttachments.InsertAsync(currentPropAttachments);
                }
            }

            if (input.PropRevenues.Count > 0)
            {
                foreach (var item in input.PropRevenues)
                {
                    var accId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                    var advanceAccId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);

                    item.PropertyId = pmProperties.Id;
                    item.AccountId = (long)accId;
                    item.AdvanceAccountId = (long)advanceAccId;

                    var currentPropRevenues = ObjectMapper.Map<PmPropertiesRevenueAccounts>(item);

                    _ = await _repoPmPropertiesRevenueAccounts.InsertAsync(currentPropRevenues);
                }
            }

            if (input.PropUnits.Count > 0)
            {
                foreach (var item in input.PropUnits)
                {
                    item.PropertyId = pmProperties.Id;
                    item.StatusLkpId = Convert.ToInt64(FndEnum.FndLkps.Vacant_PmPropertiesUnitsStatues);

                    var currentPropUnits = ObjectMapper.Map<PmPropertiesUnits>(item);

                    var addedUnit = await _repoPmPropertiesUnits.InsertAsync(currentPropUnits);

                    if (item.PmUnitsAttachments != null)
                        item.PmUnitsAttachments.ToList().ForEach(async attch => await InsertPmPropertiesUnitsAttachments(attch, addedUnit.Id));
                }
            }

            return new PmPropertiesDto { };
        }

        public async override Task<PmPropertiesDto> Update(PmPropertiesEditDto input)
        {
            CheckUpdatePermission();

            if (input.PropRevenues.Count == 0) throw new UserFriendlyException("Revenues Required");

            _ = await base.Update(input);

            if (input.PropAttachments.Count > 0)
            {
                foreach (var item in input.PropAttachments)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {

                        var propAttachments = await _repoPmPropertiesAttachments.GetAsync((long)item.Id);

                        item.PropertyId = input.Id;

                        var mapped = ObjectMapper.Map(item, propAttachments);

                        _ = await _repoPmPropertiesAttachments.UpdateAsync(propAttachments);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.PropertyId = input.Id;

                        _ = await _repoPmPropertiesAttachments.InsertAsync(ObjectMapper.Map<PmPropertiesAttachments>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPmPropertiesAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }

            if (input.PropRevenues.Count > 0)
            {
                foreach (var item in input.PropRevenues)
                {

                    if (item.id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var accId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                        var advanceAccId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);

                        item.AccountId = (long)accId;
                        item.AdvanceAccountId = (long)advanceAccId;
                        item.PropertyId = input.Id;

                        var propRevenues = await _repoPmPropertiesRevenueAccounts.GetAsync((long)item.id);

                        ObjectMapper.Map(item, propRevenues);

                        _ = await _repoPmPropertiesRevenueAccounts.UpdateAsync(propRevenues);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var accId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                        var advanceAccId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);

                        item.AccountId = (long)accId;
                        item.AdvanceAccountId = (long)advanceAccId;
                        item.PropertyId = input.Id;

                        _ = await _repoPmPropertiesRevenueAccounts.InsertAsync(ObjectMapper.Map<PmPropertiesRevenueAccounts>(item));
                    }
                    else if (item.id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPmPropertiesRevenueAccounts.DeleteAsync((long)item.id);
                    }
                }
            }

            if (input.PropUnits.Count > 0)
            {
                foreach (var item in input.PropUnits)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var propUnits = await _repoPmPropertiesUnits.GetAsync((long)item.Id);

                        item.StatusLkpId = propUnits.StatusLkpId;
                        item.PropertyId = input.Id;

                        ObjectMapper.Map(item, propUnits);

                        _ = await _repoPmPropertiesUnits.UpdateAsync(propUnits);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var statusLkpId = Convert.ToInt64(FndEnum.FndLkps.Vacant_PmPropertiesUnitsStatues);

                        item.PropertyId = input.Id;
                        item.StatusLkpId = statusLkpId;

                        _ = await _repoPmPropertiesUnits.InsertAsync(ObjectMapper.Map<PmPropertiesUnits>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPmPropertiesUnits.DeleteAsync((long)item.Id);
                    }

                    await CRUD_PmPropertiesUnitsAttachments(item.PmUnitsAttachments, item.Id);
                }
            }

            return new PmPropertiesDto { };
        }

        public async Task<PmPropertiesDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.ApBankAccounts,
                                           x => x.PmOwners, x => x.FndStatusLkp,
                                           x => x.FndCountryLkp, x => x.FndPmPurposeLkp,
                                           x => x.FndCommissionTypeLkp, x => x.FndCityLkp,
                                           x => x.FndPmPurposeLkp)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<PmPropertiesDto>(current);

            return currentDto;
        }

        public async Task<List<PmPropertiesAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<PmPropertiesAttachmentsDto>>(
                await _repoPmPropertiesAttachments.GetAllIncluding().Where(d => d.PropertyId == input.Id).ToListAsync()
                );
        }

        public async Task<Select2PagedResult> GetPmPropertiesNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
                => await _pmPropertiesManager.GetPmPropertiesNumberSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<List<PmPropertiesUnitsDto>> GetAllPmPropertiesUnits(EntityDto<long> input)
        {
            var output = new List<PmPropertiesUnitsDto>();

            var listData = await _repoPmPropertiesUnits.GetAllIncluding(x => x.FndViewLkp, x => x.FndPmUnitDescLkp, x => x.FndFinishesLkp, x => x.FndStatusLkp, x => x.FndUnitTypeLkp)
                        .Where(d => d.PropertyId == input.Id).OrderBy(Z => Z.UnitNo).ToListAsync();

            foreach (var item in listData)
            {
                var current = new PmPropertiesUnitsDto
                {
                    Id = item.Id,
                    StatusLkpId = item.StatusLkpId,
                    AreaSize = item.AreaSize,
                    Description = item.Description,
                    ElectricityNumber = item.ElectricityNumber,
                    FinishesLkp = item.FndFinishesLkp == null ? string.Empty : item.FndFinishesLkp.GetLookupValue(),
                    
                    FndStatusLkp = item.FndStatusLkp == null ? string.Empty :  item.FndStatusLkp.GetLookupValue(),
                    
                    ViewLkp = item.FndViewLkp == null ? string.Empty : item.FndViewLkp.GetLookupValue(),
                    FloorLevel = item.FloorLevel,
                    FinishesLkpId = item.FinishesLkpId,
                    PmUnitTypeLkp = item.FndUnitTypeLkp.GetLookupValue(),
                    PmUnitTypeLkpId = item.PmUnitTypeLkpId,
                    PropertyId = item.PropertyId,
                    SewerageNumber = item.SewerageNumber,
                    StatusLkp = item.FndStatusLkp.NameAr,
                    UnitNo = item.UnitNo,
                    ViewLkpId = item.ViewLkpId,
                    YearlyRent = item.YearlyRent,
                    PmUnitDescLkpId = item.PmUnitDescLkpId,
                    PmUnitDescLkpNameAr = item.FndPmUnitDescLkp?.GetLookupValue() ?? string.Empty,
                    PmUnitDescLkpNameEn = item.FndPmUnitDescLkp?.GetLookupValue() ?? string.Empty,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<PmPropertiesRevenueAccountsDto>> GetAllRevenues(EntityDto<long> input)
        {
            var output = new List<PmPropertiesRevenueAccountsDto>();

            var listData = await _repoPmPropertiesRevenueAccounts.GetAllIncluding(
                x => x.AccountGlCodeComDetails, x => x.AdvanceAccountGlCodeComDetails)
                .Where(d => d.PropertyId == input.Id).ToListAsync();

            foreach (var item in listData)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.AccountGlCodeComDetails, _app.Reqlanguage);
                (string advids, string advtexts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.AdvanceAccountGlCodeComDetails, _app.Reqlanguage);

                var current = new PmPropertiesRevenueAccountsDto
                {
                    id = item.Id,
                    AccountId = item.AccountId,
                    AdvanceAccountId = item.AdvanceAccountId,
                    Percentage = item.Percentage,
                    codeComUtilityIds = ids,
                    codeComUtilityTexts = texts,
                    codeComUtilityIds_alt1 = advids,
                    codeComUtilityTexts_alt1 = advtexts,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<PmPropertiesUnitsAttachmentsDto>> GetAllPmPropertiesAttachmentsUnits(EntityDto<long> input)
        {
            var data = await _repoPmPropertiesUnitsAttachments.GetAllListAsync(z => z.PmPropertiesUnitstId == input.Id);

            return ObjectMapper.Map<List<PmPropertiesUnitsAttachmentsDto>>(data);
        }

        public async Task<Select2PagedResult> GetPmPropertiesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pmPropertiesManager.GetPmPropertiesSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<(string ownerName, string propertyNumber, long ownerId)> GetPmPropertiesInfo(EntityDto<long> input, string lang = "ar-EG")
            => await _pmPropertiesManager.GetPmPropertiesInfo(input.Id, lang);

        public async Task<Select2PagedResult> GetUnitNumbersForContractsSelect2(long propertyId, long pmUnitTypeLkpId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pmPropertiesManager.GetUnitNumbersForContractsSelect2(propertyId, pmUnitTypeLkpId, searchTerm, pageSize, pageNumber, lang);

        private async Task<string> GetPmProperityNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "PmProperties", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }

        private async Task InsertPmPropertiesUnitsAttachments(PmPropertiesUnitsAttachmentsDto dto, long parentId)
        {
            dto.PmPropertiesUnitstId = parentId;

            await _repoPmPropertiesUnitsAttachments.InsertAsync(ObjectMapper.Map<PmPropertiesUnitsAttachments>(dto));
        }

        private async Task CRUD_PmPropertiesUnitsAttachments(ICollection<PmPropertiesUnitsAttachmentsDto> dtos, long parentId)
        {
            if (dtos?.Count > 0)
            {
                foreach (var item in dtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var pmPropertiesUnitsAttachments = await _repoPmPropertiesUnitsAttachments.GetAsync((long)item.Id);

                        item.PmPropertiesUnitstId = parentId;

                        ObjectMapper.Map(item, pmPropertiesUnitsAttachments);

                        _ = await _repoPmPropertiesUnitsAttachments.UpdateAsync(pmPropertiesUnitsAttachments);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertPmPropertiesUnitsAttachments(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPmPropertiesUnitsAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

    }
}
