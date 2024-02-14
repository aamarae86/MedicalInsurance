using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CRM._ActivityTasks;
using ERP._System.__CRM._ActivityTasks.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CRM.Leads
{
    [AbpAuthorize]
    public class ActivityTasksAppService : AsyncCrudAppService<ActivityTasks, ActivityTasksDto, long, ActivityTasksPagedDto, ActivityTasksCreateDto, ActivityTasksEditDto>, IActivityTasksAppService
    {
        private readonly IRepository<CrmLeadsPersons, long> _crmLeadsPersonsRepo;

        public ActivityTasksAppService(IRepository<ActivityTasks, long> repository, IRepository<CrmLeadsPersons, long> crmLeadsPersonsRepo) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_CrmLeadsPersons_Insert; /*PermissionNames.Pages_ActivityTasks_Insert;*/
            UpdatePermissionName = PermissionNames.Pages_CrmLeadsPersons_Update; /*PermissionNames.Pages_ActivityTasks_Update;*/
            DeletePermissionName = PermissionNames.Pages_CrmLeadsPersons_Delete; /*PermissionNames.Pages_ActivityTasks_Delete;*/
            GetAllPermissionName = PermissionNames.Pages_CrmLeadsPersons; /*PermissionNames.Pages_ActivityTasks;*/
            _crmLeadsPersonsRepo = crmLeadsPersonsRepo;
        }



        protected override IQueryable<ActivityTasks> CreateFilteredQuery(ActivityTasksPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.PriorityLkps, x => x.CrmDeals, x => x.RelatedToLkps,
                x => x.StatuesLkps, x => x.CrmLeadsPersons);   
 
            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Subject))
                iqueryable = iqueryable.Where(z => z.Subject.Contains(input.Params.Subject));

          
            if (input.Params != null && input.Params.RelatedToLkpId != null)
                iqueryable = iqueryable.Where(z => z.RelatedToLkpId == input.Params.RelatedToLkpId);

            if (input.Params != null && input.Params.CrmLeadsPersonsId != null)
                iqueryable = iqueryable.Where(z => z.CrmLeadsPersonsId == input.Params.CrmLeadsPersonsId);
            iqueryable.ForEachAsync(x => x.Lang = input.Params.Lang);

            return iqueryable;
        }

        public async override Task<ActivityTasksDto> Get(EntityDto<long> input)
        {
            var res= await Repository
                .GetAllIncluding(x => x.PriorityLkps, x => x.CrmDeals, x => x.RelatedToLkps,
                x => x.StatuesLkps, x => x.CrmLeadsPersons )
                .Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            var mapped = ObjectMapper.Map<ActivityTasksDto>(res);
            return mapped;

        }
        
        public async Task<ActivityTasksDto> GetSingle(EntityDto<long> input, string lang)
        {
             
            var res= await Repository
                .GetAllIncluding(x => x.PriorityLkps, x => x.CrmDeals, x => x.RelatedToLkps,
                x => x.StatuesLkps, x => x.CrmLeadsPersons )
                .Where(x => x.Id == input.Id).FirstOrDefaultAsync();
                res.Lang = lang;
                var mapped = ObjectMapper.Map<ActivityTasksDto>(res);
            return mapped;

        }
 
        public async override Task<ActivityTasksDto> Create(ActivityTasksCreateDto input)
        { 
            CheckCreatePermission();
            return await base.Create(input);
        }

        public async override Task<ActivityTasksDto> Update(ActivityTasksEditDto input)
        { 
            CheckUpdatePermission();
            return await base.Update(input);
        }

       
        public async Task<Select2PagedResult> GetCrmLeadsPersonsSelect2(long id, string searchTerm, int pageSize, int pageNumber, string lang)
        {
 
            var data = _crmLeadsPersonsRepo.GetAll()
                     .Where(z =>  (z.Id != id) && (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) ));

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
