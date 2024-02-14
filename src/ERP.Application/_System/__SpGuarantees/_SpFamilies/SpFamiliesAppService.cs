using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__SpGuarantees._SpCaseHistory;
using ERP._System.__SpGuarantees._SpCaseHistory.Dto;
using ERP._System.__SpGuarantees._SpCases;
using ERP._System.__SpGuarantees._SpFamilies.Dto;
using ERP._System.__SpGuarantees._SpFamilyDuties;
using ERP._System.__SpGuarantees._SpFamilyIncomes;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpFamilies
{
    [AbpAuthorize]
    public class SpFamiliesAppService : AsyncCrudAppService<SpFamilies, SpFamiliesDto, long, PagedSpFamiliesResultRequestDto, SpFamiliesCreateDto, SpFamiliesEditDto>,
        ISpFamiliesAppService
    {
        private readonly IRepository<SpFamilyDuties, long> _repoSpFamilyDuties;
        private readonly IRepository<SpFamilyIncomes, long> _repoSpFamilyIncomes;
        private readonly IRepository<SpCaseHistory, long> _repoSpCaseHistory;
        private readonly IRepository<SpCases, long> _repoSpCases;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly ISpFamiliesManager _spFamiliesManager;

        public SpFamiliesAppService(IRepository<SpFamilies, long> repository,
            IRepository<SpCaseHistory, long> repoSpCaseHistory,
            IRepository<SpFamilyDuties, long> repoSpFamilyDuties,
            IRepository<SpFamilyIncomes, long> repoSpFamilyIncomes,
            IRepository<SpCases, long> repoSpCases,
            IGetCounterRepository getCounterRepository,
            ISpFamiliesManager spFamiliesManager) : base(repository)
        {
            _repoSpFamilyDuties = repoSpFamilyDuties;
            _repoSpFamilyIncomes = repoSpFamilyIncomes;
            _spFamiliesManager = spFamiliesManager;
            _repoSpCaseHistory = repoSpCaseHistory;
            _repoProcCounter = getCounterRepository;
            _repoSpCases = repoSpCases;

            CreatePermissionName = PermissionNames.Pages_SpFamilies_Insert;
            UpdatePermissionName = PermissionNames.Pages_SpFamilies_Update;
            DeletePermissionName = PermissionNames.Pages_SpFamilies_Delete;
            GetAllPermissionName = PermissionNames.Pages_SpFamilies;
        }

        protected override IQueryable<SpFamilies> CreateFilteredQuery(PagedSpFamiliesResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndRelativesTypeLkp, x => x.FndNationalityLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IdNumber))
                iqueryable = iqueryable.Where(z => z.IdNumber.Contains(input.Params.IdNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FamilyNumber))
                iqueryable = iqueryable.Where(z => z.FamilyNumber.Contains(input.Params.FamilyNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FamilyName))
                iqueryable = iqueryable.Where(z => z.FamilyName.Contains(input.Params.FamilyName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.GuardianName))
                iqueryable = iqueryable.Where(z => z.GuardianName.Contains(input.Params.GuardianName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.RegistrationDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.RegistrationDate);

                iqueryable = iqueryable.Where(z => z.RegistrationDate == dt);
            }

            return iqueryable;
        }

        public override async Task<SpFamiliesDto> Create(SpFamiliesCreateDto input)
        {
            CheckCreatePermission();

            input.FamilyNumber = await GetFamilyNumberCounter();

            var current = await base.Create(input);

            if (input.FamilyIncomes != null && input.FamilyIncomes.Count > 0)
            {
                foreach (var item in input.FamilyIncomes)
                {
                    item.SpFamilyId = current.Id;
                    _ = await _repoSpFamilyIncomes.InsertAsync(ObjectMapper.Map<SpFamilyIncomes>(item));
                }
            }

            if (input.FamilyDuties != null && input.FamilyDuties.Count > 0)
            {
                foreach (var item in input.FamilyDuties)
                {
                    item.SpFamilyId = current.Id;

                    var spFamilyDuties = ObjectMapper.Map<SpFamilyDuties>(item);

                    _ = await _repoSpFamilyDuties.InsertAsync(spFamilyDuties);
                }
            }

            if (input.FamilyCases != null && input.FamilyCases.Count > 0)
                foreach (var item in input.FamilyCases)
                    await InsertSpCaseWithHistory(item, current.Id);

            return new SpFamiliesDto { };
        }

        public override async Task<SpFamiliesDto> Update(SpFamiliesEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.FamilyIncomes != null && input.FamilyIncomes.Count > 0)
            {
                foreach (var item in input.FamilyIncomes)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var spFamilyIncomes = await _repoSpFamilyIncomes.GetAsync((long)item.Id);

                        item.SpFamilyId = input.Id;

                        ObjectMapper.Map(item, spFamilyIncomes);

                        _ = await _repoSpFamilyIncomes.UpdateAsync(spFamilyIncomes);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.SpFamilyId = input.Id;

                        _ = await _repoSpFamilyIncomes.InsertAsync(ObjectMapper.Map<SpFamilyIncomes>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoSpFamilyIncomes.DeleteAsync((long)item.Id);
                    }
                }
            }

            if (input.FamilyDuties != null && input.FamilyDuties.Count > 0)
            {
                foreach (var item in input.FamilyDuties)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var spFamilyDuties = await _repoSpFamilyDuties.GetAsync((long)item.Id);

                        item.SpFamilyId = input.Id;

                        ObjectMapper.Map(item, spFamilyDuties);

                        _ = await _repoSpFamilyDuties.UpdateAsync(spFamilyDuties);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.SpFamilyId = input.Id;

                        _ = await _repoSpFamilyDuties.InsertAsync(ObjectMapper.Map<SpFamilyDuties>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoSpFamilyDuties.DeleteAsync((long)item.Id);
                    }
                }
            }

            if (input.FamilyCases != null && input.FamilyCases.Count > 0)
            {
                foreach (var item in input.FamilyCases)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var spCases = await _repoSpCases.GetAsync((long)item.Id);

                        item.SpFamilyId = input.Id;
                        item.CaseNumber = spCases.CaseNumber;
                        item.StatusLkpId = spCases.StatusLkpId;

                        ObjectMapper.Map(item, spCases);

                        _ = await _repoSpCases.UpdateAsync(spCases);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertSpCaseWithHistory(item, input.Id);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoSpCases.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new SpFamiliesDto { };
        }

        public async Task<List<SpFamilyIncomesDto>> GetAllIncomesDetails(long id)
        {
            var output = new List<SpFamilyIncomesDto>();

            var listData = await _repoSpFamilyIncomes.GetAllIncluding().Where(d => d.SpFamilyId == id)
                                     .ToListAsync();

            foreach (var item in listData)
            {
                var current = new SpFamilyIncomesDto
                {
                    Id = item.Id,
                    IncomeSourceName = item.IncomeSourceName,
                    MonthlyIncomeAmount = item.MonthlyIncomeAmount,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<SpFamilyDutiesDto>> GetAllDutiesDetails(long id)
        {
            var output = new List<SpFamilyDutiesDto>();

            var listData = await _repoSpFamilyDuties.GetAllIncluding().Where(d => d.SpFamilyId == id)
                                     .ToListAsync();

            foreach (var item in listData)
            {
                var current = new SpFamilyDutiesDto
                {
                    Id = item.Id,
                    DutyDescription = item.DutyDescription,
                    MonthlyAmount = item.MonthlyAmount,
                    TotalAmount = item.TotalAmount,
                    DutyType = item.DutyType,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<SpFamilyCasesDto>> GetAllCasesDetails(long id)
        {
            var output = new List<SpFamilyCasesDto>();

            var listData = await _repoSpCases.GetAllIncluding(x => x.FndLookupValuesSponsorCategoryLkp,
                                             x => x.FndLookupValuesRelativesTypeLkp).Where(d => d.SpFamilyId == id)
                                     .ToListAsync();

            foreach (var item in listData)
            {
                var current = new SpFamilyCasesDto
                {
                    Id = item.Id,
                    CaseName = item.CaseName,
                    CaseNumber = item.CaseNumber,
                    SponsorCategoryLkpId = item.SponsorCategoryLkpId,
                    RelativesTypeLkpId = item.RelativesTypeLkpId,
                    SponsorCategoryLkp = item?.FndLookupValuesSponsorCategoryLkp?.NameAr ?? string.Empty,
                    RelativesTypeLkp = item?.FndLookupValuesRelativesTypeLkp.NameAr ?? string.Empty,
                    BirthDate = item.BirthDate.HasValue ? item.BirthDate.Value.ToString(Formatters.DateFormat) : string.Empty,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<SpFamiliesDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndRelativesTypeLkp,
                                        x => x.FndNationalityLkp, x => x.FndMaritalStatusLkp,
                                        x => x.FndHousingStatusLkp, x => x.FndHousingTypeLkp,
                                        x => x.FndBankLkp, x => x.FndCityLkp)
                                    .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<SpFamiliesDto>(current);
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spFamiliesManager.GetSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetGaurdiantSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spFamiliesManager.GetGaurdiantSelect2(searchTerm, pageSize, pageNumber, lang);

        private async Task InsertSpCaseWithHistory(SpFamilyCasesDto spFamilyCasesDto, long familyId)
        {
            long spCaseId = await InsertSpCases(spFamilyCasesDto, familyId);
            await InsertSpCaseHistory(new SpCaseHistoryDto { SourceId = familyId, SpCaseId = spCaseId });
        }

        private async Task<long> InsertSpCases(SpFamilyCasesDto spFamilyCasesDto, long familyId)
        {
            long newStatusId = 685;

            var counterInputCases = new GetCounterInputDto { CounterName = "SpCases", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var resultCases = await _repoProcCounter.Execute(counterInputCases, "GetCounter");

            spFamilyCasesDto.CaseNumber = resultCases?.FirstOrDefault()?.OutputStr ?? string.Empty;
            spFamilyCasesDto.StatusLkpId = newStatusId;
            spFamilyCasesDto.SpFamilyId = familyId;

            var spCases = ObjectMapper.Map<SpCases>(spFamilyCasesDto);

            _ = await _repoSpCases.InsertAsync(spCases);

            return spCases.Id;
        }

        private async Task InsertSpCaseHistory(SpCaseHistoryDto spCaseHistoryDto)
        {
            long familySourceId = 784, newStatusId = 685, enterCaseId = 783;

            spCaseHistoryDto.SourceCodeLkpId = familySourceId;
            spCaseHistoryDto.CaseStatusLkpId = newStatusId;
            spCaseHistoryDto.OperationTypeLkpId = enterCaseId;
            spCaseHistoryDto.OperationNotes = "إضافة ملف جديد";

            var spCaseHistory = ObjectMapper.Map<SpCaseHistory>(spCaseHistoryDto);

            _ = await _repoSpCaseHistory.InsertAsync(spCaseHistory);
        }

        private async Task<string> GetFamilyNumberCounter(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "SpFamilies", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
