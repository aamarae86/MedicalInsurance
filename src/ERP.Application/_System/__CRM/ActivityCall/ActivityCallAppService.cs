using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CRM._ActivityCall;
using ERP._System.__CRM._ActivityCall.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CRM.Leads
{
    [AbpAuthorize]
    public class ActivityCallAppService : AsyncCrudAppService<ActivityCall, ActivityCallDto, long, ActivityCallPagedDto, ActivityCallCreateDto, ActivityCallEditDto>, IActivityCallAppService
    {
        private readonly IRepository<CrmLeadsPersons, long> _crmLeadsPersonsRepo;

        public ActivityCallAppService(IRepository<ActivityCall, long> repository, IRepository<CrmLeadsPersons, long> crmLeadsPersonsRepo) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_CrmLeadsPersons_Insert;
            UpdatePermissionName = PermissionNames.Pages_CrmLeadsPersons_Update;
            DeletePermissionName = PermissionNames.Pages_CrmLeadsPersons_Delete;
            GetAllPermissionName = PermissionNames.Pages_CrmLeadsPersons;
            _crmLeadsPersonsRepo = crmLeadsPersonsRepo;
        }



        protected override IQueryable<ActivityCall> CreateFilteredQuery(ActivityCallPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.CallDetailsLkps, x => x.CallPurposeLkps,
                x => x.CallResultLkps, x => x.CrmDeals, x => x.CrmLeadsPersons, x => x.CallTypeLkps, x => x.RelatedToLkps);  //.Where(s => s.CrmLeadsPersons.TypeLkpId == 11121);//contact only  
 
            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Subject))
                iqueryable = iqueryable.Where(z => z.Subject.Contains(input.Params.Subject));

          
            if (input.Params != null && input.Params.RelatedToLkpId != null)
                iqueryable = iqueryable.Where(z => z.RelatedToLkpId == input.Params.RelatedToLkpId);

            if (input.Params != null && input.Params.CrmLeadsPersonsId != null)
                iqueryable = iqueryable.Where(z => z.CrmLeadsPersonsId == input.Params.CrmLeadsPersonsId);
            iqueryable.ForEachAsync(x => x.Lang = input.Params.Lang);


            return iqueryable;
        }

        public async override Task<ActivityCallDto> Get(EntityDto<long> input)
        {
            var res = await Repository
                .GetAllIncluding(x => x.CallDetailsLkps, x => x.CallPurposeLkps,
                x => x.CallResultLkps, x => x.CrmLeadsPersons, x => x.CrmDeals, x => x.CallTypeLkps, x => x.RelatedToLkps)
                .Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            var mapped = ObjectMapper.Map<ActivityCallDto>(res);
            return mapped;

        }
        public async Task<ActivityCallDto> GetSingle(EntityDto<long> input, string lang)
        {
            var res = await Repository
                .GetAllIncluding(x => x.CallDetailsLkps, x => x.CallPurposeLkps,
                x => x.CallResultLkps, x => x.CrmLeadsPersons, x => x.CrmDeals, x => x.CallTypeLkps, x => x.RelatedToLkps)
                .Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            res.Lang = lang;
            var mapped = ObjectMapper.Map<ActivityCallDto>(res);
            return mapped;

        }

         
        public async  Task<List<ActivityCallDto>> GetByLead_ContactId(EntityDto<long> input)
        {
            var res = await Repository
                .GetAllIncluding(x => x.CallDetailsLkps, x => x.CallPurposeLkps,
                x => x.CallResultLkps, x => x.CrmLeadsPersons, x => x.CrmDeals, x => x.CallTypeLkps, x => x.RelatedToLkps)
            
                .Where(x => x.CrmLeadsPersonsId == input.Id).ToListAsync();
            var mapped = ObjectMapper.Map<List< ActivityCallDto> >(res);
            return mapped;

        }



        public async override Task<ActivityCallDto> Create(ActivityCallCreateDto input)
        { 
            CheckCreatePermission();
            return await base.Create(input);
        }

        public async override Task<ActivityCallDto> Update(ActivityCallEditDto input)
        { 
            CheckUpdatePermission();
            return await base.Update(input);
        }

       
        public async Task<Select2PagedResult> GetCrmLeadsPersons_ByTypeSelect2(long id, string searchTerm, int pageSize, int pageNumber, string lang,long TypeLkpId)
        {
 
            var data = _crmLeadsPersonsRepo.GetAll()
                     .Where(z => z.TypeLkpId == TypeLkpId && (z.Id != id) && (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) ));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.FirstName} {z.LastName}", altText = z.Id.ToString() })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }



    }
}
