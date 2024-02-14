using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPersons;
using ERP._System.__HR._PyPayrollOperations.Dto;
using ERP._System.__HR._PyPayrollOperations.Input;
using ERP._System.__HR._PyPayrollOperations.Proc;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyPayrollOperations
{
    [AbpAuthorize]
    public class PyPayrollOperationsAppService : AsyncCrudAppService<PyPayrollOperations, PyPayrollOperationsDto, long, PyPayrollOperationsPagedDto, PyPayrollOperationsCreateDto, PyPayrollOperationsEditDto>,
        IPyPayrollOperationsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IHrPersonsManager _hrPersonsManager;
        private readonly IPyPayrollOperationsRepository _idLangPostRepository;
        private readonly IRepository<PyPayrollOperationPersons, long> _repoPyPayrollOperationPersons;
        private readonly IRepository<PyPayrollOperationPersonDetails, long> _repoPyPayrollOperationPersonDetails;

        public PyPayrollOperationsAppService(IRepository<PyPayrollOperations, long> repository,
            IGetCounterRepository getCounterRepository,
            IHrPersonsManager hrPersonsManager, IPyPayrollOperationsRepository idLangPostRepository,
            IRepository<PyPayrollOperationPersonDetails, long> repoPyPayrollOperationPersonDetails,
            IRepository<PyPayrollOperationPersons, long> repoPyPayrollOperationPersons) : base(repository)
        {
            _repoProcCounter = getCounterRepository;
            _hrPersonsManager = hrPersonsManager;
            _idLangPostRepository = idLangPostRepository;
            _repoPyPayrollOperationPersons = repoPyPayrollOperationPersons;
            _repoPyPayrollOperationPersonDetails = repoPyPayrollOperationPersonDetails;

            CreatePermissionName = PermissionNames.Pages_PyPayrollOperations_Insert;
            UpdatePermissionName = PermissionNames.Pages_PyPayrollOperations_Update;
            DeletePermissionName = PermissionNames.Pages_PyPayrollOperations_Delete;
            GetAllPermissionName = PermissionNames.Pages_PyPayrollOperations;
        }

        public async override Task<PagedResultDto<PyPayrollOperationsDto>> GetAll(PyPayrollOperationsPagedDto input)
        {
            CheckGetAllPermission();

            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.Periods, x => x.HrPersons, x => x.PyPayrollTypes);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HrPersonNumber))
                iqueryable = iqueryable.Where(z => z.HrPersons.EmployeeNumber.Contains(input.Params.HrPersonNumber));

            if (input.Params != null && input.Params.PyPayrollTypeId != null)
                iqueryable = iqueryable.Where(z => z.PyPayrollTypeId == input.Params.PyPayrollTypeId);

            if (input.Params != null && input.Params.HrPersonId != null)
                iqueryable = iqueryable.Where(z => z.HrPersonId == input.Params.HrPersonId);

            if (input.Params != null && input.Params.PeriodId != null)
                iqueryable = iqueryable.Where(z => z.PeriodId == input.Params.PeriodId);

            var count = await iqueryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            iqueryable = iqueryable.DynamicOrderBy(listOrder);

            iqueryable = iqueryable.Skip(input.SkipCount);

            var data = await iqueryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<PyPayrollOperationsDto>());

            for (int i = 0; i < data2.Count; i++)
                data2[i].OperationDate = data[i].OperationDate.ToString(Formatters.DateFormat);

            var PagedResultDto = new PagedResultDto<PyPayrollOperationsDto>()
            {
                Items = data2 as IReadOnlyList<PyPayrollOperationsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<PyPayrollOperationsDto> Create(PyPayrollOperationsCreateDto input)
        {
            CheckCreatePermission();

            input.OperationNumber = await GetOperationNumber();

            if (input.HrPersonId.HasValue) input.JobLkpId = null;
            else if (input.JobLkpId.HasValue) input.HrPersonId = null;

            return await base.Create(input);
        }

        public async override Task<PyPayrollOperationsDto> Update(PyPayrollOperationsEditDto input)
        {
            CheckUpdatePermission();

            if (input.HrPersonId.HasValue) input.JobLkpId = null;
            else if (input.JobLkpId.HasValue) input.HrPersonId = null;

            return await base.Update(input);
        }

        public async Task<PyPayrollOperationsDto> GetDetailAsync(EntityDto<long> input)
        {
            var data = await Repository.GetAllIncluding(x => x.FndJobLkp, x => x.HrPersons, x => x.Periods, x => x.PyPayrollTypes, x => x.FndStatusLkp)
                            .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<PyPayrollOperationsDto>(data);

            mapped.OperationDate = data.OperationDate.ToString(Formatters.DateFormat);

            return mapped;
        }

        public async Task<List<PyPayrollOperationPersonsDto>> GetAllPyPayrollOperationsPersons(EntityDto<long> input)
        {
            var listData = await _repoPyPayrollOperationPersons
                            .GetAllIncluding(x => x.HrPersons, x => x.PyPayrollOperationPersonDetails)
                            .Where(d => d.PyPayrollOperationId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<PyPayrollOperationPersonsDto>>(listData);
        }

        public async Task<List<PyPayrollOperationPersonDetailsDto>> GetAllPyPayrollOperationsPersonsDetails(EntityDto<long> input)
        {
            var listData = await _repoPyPayrollOperationPersonDetails
                            .GetAllIncluding(
                                   x => x.PyPayrollOperationPersons.HrPersons,
                                   x => x.PyPayrollOperationPersons.FndBankLkp,
                                   x => x.PyPayrollOperationPersons.PyPayrollOperations.Periods,
                                   x => x.PyPayrollOperationPersons.PyPayrollOperations.PyPayrollTypes
                                   )
                            .Where(d => d.PyPayrollOperationPersonId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<PyPayrollOperationPersonDetailsDto>>(listData);
        }

        public async Task<PostOutput> PostPyPayrollOperations(StoredInput idLangInputDto)
        {
            idLangInputDto.UserId = (long)AbpSession.UserId;

            var result = await _idLangPostRepository.Execute(idLangInputDto, "PyPayrollOperationsPost");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> ApprovalPyPayrollOperations(StoredInput idLangInputDto)
        {
            idLangInputDto.UserId = (long)AbpSession.UserId;

            var result = await _idLangPostRepository.Execute(idLangInputDto, "PyPayrollOperationsApproval");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> UnApprovedPyPayrollOperations(StoredInput idLangInputDto)
        {
            idLangInputDto.UserId = (long)AbpSession.UserId;

            var result = await _idLangPostRepository.Execute(idLangInputDto, "PyPayrollOperationsUnapproved");

            return result.FirstOrDefault();
        }

        public async Task<Select2PagedResult> GetPersonsForPayRollSelect2(long pyPayrollTypeId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _hrPersonsManager.GetPersonsForPayRollSelect2(pyPayrollTypeId, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetPersonsJobsForPayRollSelect2(long pyPayrollTypeId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _hrPersonsManager.GetPersonsJobsForPayRollSelect2(pyPayrollTypeId, searchTerm, pageSize, pageNumber, lang);

        private async Task<string> GetOperationNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "PyPayrollOperations", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }
    }
}
