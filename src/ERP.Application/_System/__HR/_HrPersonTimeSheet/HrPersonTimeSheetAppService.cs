using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPersonTimeSheet.Dto;
using ERP._System.__HR._HrPersonVacations.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersonTimeSheet
{
    [AbpAuthorize]
    public  class HrPersonTimeSheetAppService : AsyncCrudAppService<HrPersonTimeSheet, HrPersonTimeSheetDto, long, HrPersonTimeSheetPagedDto, HrPersonTimeSheetCreateDto, HrPersonTimeSheetEditDto>, IHrPersonTimeSheetAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        public HrPersonTimeSheetAppService(IRepository<HrPersonTimeSheet, long> repository,
          IGetCounterRepository getCounterRepository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_HrPersonTimeSheet_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPersonTimeSheet_Update;
            DeletePermissionName = PermissionNames.Pages_HrPersonTimeSheet_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPersonTimeSheet;
        }


        protected override IQueryable<HrPersonTimeSheet> CreateFilteredQuery(HrPersonTimeSheetPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.HrPersons,x=>x.TimeSheetType);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TimeSheetNumber))
                iqueryable = iqueryable.Where(z => z.TimeSheetNumber.Contains(input.Params.TimeSheetNumber));

            if (input.Params != null && input.Params.HrPersonId != null && input.Params.HrPersonId != 0)
                iqueryable = iqueryable.Where(z => z.HrPersonId == input.Params.HrPersonId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TimeSheetDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.TimeSheetDate);

                iqueryable = iqueryable.Where(z => z.TimeSheetDate == dt);
            }

            return iqueryable;
        }

        public async override Task<HrPersonTimeSheetDto> Create(HrPersonTimeSheetCreateDto input)
        {
            CheckCreatePermission();
            input.TimeSheetNumber = await GetHrPersonTimeSheetNumber();

            return await base.Create(input);
        }

        public async override Task<HrPersonTimeSheetDto> Update(HrPersonTimeSheetEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

           
            return await base.Update(input);
        }

        public async override Task Delete(EntityDto<long> input)
        {
            var current = await Repository.GetAsync(input.Id);

           
            await base.Delete(input);
        }

        public async Task<HrPersonTimeSheetDto> GetDetailAsync(EntityDto<long> input)
              => ObjectMapper.Map<HrPersonTimeSheetDto>(await Repository.GetAllIncluding( x => x.HrPersons,x=>x.TimeSheetType)
                  .Where(z => z.Id == input.Id)
                  .FirstOrDefaultAsync());

       

        //public async Task<PostOutput> PostHrPersonVacations(PostDto postDto)
        //{
        //    postDto.UserId = AbpSession.UserId ?? 0;

        //    var result = await _hrPersonsAdditionPostRepository.Execute(postDto, "HrPersonVacationsPost");

        //    return result.FirstOrDefault();
        //}

        //public async Task<Select2PagedResult> GetHrVacationsTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        //    => await _hrVacationsTypesManager.GetHrVacationsTypesSelect2(searchTerm, pageSize, pageNumber, lang);

        private async Task<string> GetHrPersonTimeSheetNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "HrPersonTimeSheet", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }
    }
}
