using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__HR._HrAbsencesTypes;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.__HR._HrPersonVacations.Dto;
using ERP._System.__HR._HrPersonVacations.Input;
using ERP._System.__HR._HrPersonVacations.Proc;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersonVacations
{
    [AbpAuthorize]
    public class HrPersonVacationsAppService : AsyncCrudAppService<HrPersonVacations, HrPersonVacationsDto, long, HrPersonVacationsPagedDto, HrPersonVacationsCreateDto, HrPersonVacationsEditDto>, IHrPersonVacationsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IHrVacationsTypesManager _hrVacationsTypesManager;
        private readonly IGetVacationsBalanceRepository _getVacationsBalanceRepository;
        private readonly IHrPersonsAdditionPostRepository _hrPersonsAdditionPostRepository;

        public HrPersonVacationsAppService(IRepository<HrPersonVacations, long> repository,
            IHrVacationsTypesManager hrVacationsTypesManager,
            IGetVacationsBalanceRepository getVacationsBalanceRepository,
            IHrPersonsAdditionPostRepository hrPersonsAdditionPostRepository,
            IGetCounterRepository getCounterRepository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;
            _hrVacationsTypesManager = hrVacationsTypesManager;
            _getVacationsBalanceRepository = getVacationsBalanceRepository;
            _hrPersonsAdditionPostRepository = hrPersonsAdditionPostRepository;

            CreatePermissionName = PermissionNames.Pages_HrPersonVacations_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPersonVacations_Update;
            DeletePermissionName = PermissionNames.Pages_HrPersonVacations_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPersonVacations;
        }

        protected override IQueryable<HrPersonVacations> CreateFilteredQuery(HrPersonVacationsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.HrPersons, x => x.FndStatusLkp, x => x.HrVacationsTypes);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OperationNumber))
                iqueryable = iqueryable.Where(z => z.OperationNumber.Contains(input.Params.OperationNumber));

            if (input.Params != null && input.Params.HrPersonId != null)
                iqueryable = iqueryable.Where(z => z.HrPersonId == input.Params.HrPersonId);

            if (input.Params != null && input.Params.HrVacationsTypeId != null && input.Params.HrVacationsTypeId !=0)
                iqueryable = iqueryable.Where(z => z.HrVacationsTypeId == input.Params.HrVacationsTypeId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OperationDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.OperationDate);

                iqueryable = iqueryable.Where(z => z.OperationDate == dt);
            }

            return iqueryable;
        }

        public async override Task<HrPersonVacationsDto> Create(HrPersonVacationsCreateDto input)
        {
            CheckCreatePermission();

            input.VacationBalance = await GetVacationsBalance(input.HrPersonId, input.HrVacationsTypeId);

            if (input.NoOfDays > input.VacationBalance) throw new UserFriendlyException("عدد الايام اكبر من الرصيد !!");

            input.OperationNumber = await GetHrPersonVacationsNumber();

            return await base.Create(input);
        }

        public async override Task<HrPersonVacationsDto> Update(HrPersonVacationsEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_HrPersonVacationsStatues))
                throw new UserFriendlyException(" لا يمكن التعديل");

            input.VacationBalance = await GetVacationsBalance(input.HrPersonId, input.HrVacationsTypeId);

            if (input.NoOfDays > input.VacationBalance) throw new UserFriendlyException("عدد الايام اكبر من الرصيد !!");

            return await base.Update(input);
        }

        public async override Task Delete(EntityDto<long> input)
        {
            var current = await Repository.GetAsync(input.Id);

            if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_HrPersonVacationsStatues))
                throw new UserFriendlyException(" لا يمكن التعديل");

            await base.Delete(input);
        }

        public async Task<HrPersonVacationsDto> GetDetailAsync(EntityDto<long> input)
              => ObjectMapper.Map<HrPersonVacationsDto>(await Repository.GetAllIncluding(z => z.FndStatusLkp, x => x.HrVacationsTypes, x => x.HrPersons)
                  .Where(z => z.Id == input.Id)
                  .FirstOrDefaultAsync());

        public async Task<decimal> GetVacationsBalance(long hrPersonId, long hrVacationsTypeId)
        {
            var getVacationsBalanceInput = new GetVacationsBalanceInput { HrPersonId = hrPersonId, HrVacationsTypeId = hrVacationsTypeId };

            var result = await _getVacationsBalanceRepository.Execute(getVacationsBalanceInput, "GetVacationsBalance");

            return result?.FirstOrDefault()?.Balance ?? 0;
        }

        public async Task<PostOutput> PostHrPersonVacations(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _hrPersonsAdditionPostRepository.Execute(postDto, "HrPersonVacationsPost");

            return result.FirstOrDefault();
        }

        public async Task<Select2PagedResult> GetHrVacationsTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _hrVacationsTypesManager.GetHrVacationsTypesSelect2(searchTerm, pageSize, pageNumber, lang);

        private async Task<string> GetHrPersonVacationsNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "HrPersonVacations", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }
    }
}
