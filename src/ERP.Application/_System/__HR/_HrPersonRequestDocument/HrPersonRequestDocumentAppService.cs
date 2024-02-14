using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPersonRequestDocument.Dto;
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

namespace ERP._System.__HR._HrPersonRequestDocument
{
    //[AbpAuthorize]
    public  class HrPersonRequestDocumentAppService : AsyncCrudAppService<HrPersonRequestDocument, HrPersonRequestDocumentDto, long, HrPersonRequestDocumentPagedDto, HrPersonRequestDocumentCreateDto, HrPersonRequestDocumentEditDto>, IHrPersonRequestDocumentAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        public HrPersonRequestDocumentAppService(IRepository<HrPersonRequestDocument, long> repository,
          IGetCounterRepository getCounterRepository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_HrPersonRequestDocument_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPersonRequestDocument_Update;
            DeletePermissionName = PermissionNames.Pages_HrPersonRequestDocument_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPersonRequestDocument;
        }




        protected override IQueryable<HrPersonRequestDocument> CreateFilteredQuery(HrPersonRequestDocumentPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.DocumentRequestType, x => x.FndStatusLkp,x=>x.HrPersons); ;

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.RequestNumber))
                iqueryable = iqueryable.Where(z => z.RequestNumber.Contains(input.Params.RequestNumber));

            //if (input.Params != null && !string.IsNullOrEmpty(input.Params.AccountNumber))
            //    iqueryable = iqueryable.Where(z => z.EmployeeNumber.Contains(input.Params.AccountNumber));

            if (input.Params != null && input.Params.HrPersonId != 0)
                iqueryable = iqueryable.Where(z => z.HrPersonId == input.Params.HrPersonId);

            //if (input.Params != null && input.Params. != null && input.Params.PermissionTypeId != 0)
            //    iqueryable = iqueryable.Where(z => z.PermissionTypeId == input.Params.PermissionTypeId);




            if (input.Params != null && !string.IsNullOrEmpty(input.Params.DocRequestDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.DocRequestDate);

                iqueryable = iqueryable.Where(z => z.DocRequestDate == dt);
            }
            return iqueryable;
        }
        public async Task<HrPersonRequestDocumentDto> GetDetailAsync(EntityDto<long> input)
        {
          var s=  ObjectMapper.Map<HrPersonRequestDocumentDto>(await Repository.GetAllIncluding(z => z.DocumentRequestType, x => x.HrPersons)
                    .Where(z => z.Id == input.Id)
                    .FirstOrDefaultAsync());
            return s;
        }
            

        public async override Task<HrPersonRequestDocumentDto> Create(HrPersonRequestDocumentCreateDto input)
        {
            //CheckCreatePermission();

            //input.VacationBalance = await GetVacationsBalance(input.HrPersonId, input.HrVacationsTypeId);

            //if (input.NoOfDays > input.VacationBalance) throw new UserFriendlyException("عدد الايام اكبر من الرصيد !!");

            input.RequestNumber = await GetHrPersontDocumentRequestNumber();

            return await base.Create(input);
        }

        public async override Task<HrPersonRequestDocumentDto> Update(HrPersonRequestDocumentEditDto input)
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

        private async Task<string> GetHrPersontDocumentRequestNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "HrPersonRequestDocument", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }



    }
}
