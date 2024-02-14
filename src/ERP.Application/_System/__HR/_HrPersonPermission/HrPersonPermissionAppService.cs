using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPersonPermission.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersonPermission
{
    [AbpAuthorize]
   public class HrPersonPermissionAppService : AsyncCrudAppService<HrPersonPermission, HrPersonPermissionDto, long, HrPersonPermissionPagedDto, HrPersonPermissionCreateDto, HrPersonPermissionEditDto>, IHrPersonPermissionAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        public HrPersonPermissionAppService(IRepository<HrPersonPermission, long> repository,
          IGetCounterRepository getCounterRepository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_HrPersonPermission_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPersonPermission_Update;
            DeletePermissionName = PermissionNames.Pages_HrPersonPermission_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPersonPermission;
        }

        protected override IQueryable<HrPersonPermission> CreateFilteredQuery(HrPersonPermissionPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.HrPermissionType,x=>x.FndStatusLkp,x=>x.HrPersons);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OperationNumber))
                iqueryable = iqueryable.Where(z => z.OperationNumber.Contains(input.Params.OperationNumber));

            //if (input.Params != null && !string.IsNullOrEmpty(input.Params.AccountNumber))
            //    iqueryable = iqueryable.Where(z => z.EmployeeNumber.Contains(input.Params.AccountNumber));

            if (input.Params != null && input.Params.HrPersonId != null && input.Params.HrPersonId !=0)
                iqueryable = iqueryable.Where(z => z.HrPersonId == input.Params.HrPersonId);

            if (input.Params != null && input.Params.PermissionTypeId != null && input.Params.PermissionTypeId != 0)
                iqueryable = iqueryable.Where(z => z.PermissionTypeId == input.Params.PermissionTypeId);

           


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PermissionDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.PermissionDate);

                iqueryable = iqueryable.Where(z => z.PermissionDate == dt);
            }
            return iqueryable;
        }
        public async Task<HrPersonPermissionDto> GetDetailAsync(EntityDto<long> input)
             => ObjectMapper.Map<HrPersonPermissionDto>(await Repository.GetAllIncluding(z => z.HrPermissionType, x => x.HrPersons)
                 .Where(z => z.Id == input.Id)
                 .FirstOrDefaultAsync());

        public async override Task<HrPersonPermissionDto> Create(HrPersonPermissionCreateDto input)
        {
            //CheckCreatePermission();

            //input.VacationBalance = await GetVacationsBalance(input.HrPersonId, input.HrVacationsTypeId);

            //if (input.NoOfDays > input.VacationBalance) throw new UserFriendlyException("عدد الايام اكبر من الرصيد !!");

            input.OperationNumber = await GetHrPersonPermissionNumber();

            return await base.Create(input);
        }

        public async override Task<HrPersonPermissionDto> Update(HrPersonPermissionEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            //if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_HrPersonVacationsStatues))
            //    throw new UserFriendlyException(" لا يمكن التعديل");

            //input.VacationBalance = await GetVacationsBalance(input.HrPersonId, input.HrVacationsTypeId);

            //if (input.NoOfDays > input.VacationBalance) throw new UserFriendlyException("عدد الايام اكبر من الرصيد !!");

            return await base.Update(input);
        }

        public async override Task Delete(EntityDto<long> input)
        {
            var current = await Repository.GetAsync(input.Id);

            //if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_HrPersonVacationsStatues))
            //    throw new UserFriendlyException(" لا يمكن التعديل");

            await base.Delete(input);
        }

        private async Task<string> GetHrPersonPermissionNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "HrPersonPermission", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }




    }
}
