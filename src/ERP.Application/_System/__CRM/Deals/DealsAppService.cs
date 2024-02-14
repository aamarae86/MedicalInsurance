using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__CRM._CrmDeals;
using ERP._System.__CRM._CrmDeals.Dto;
using ERP._System.__CRM.Deals;
using ERP._System.__CRM.Leads;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using ERP._System.__CRM.Deals.Dto;
using System.Collections.Generic;

namespace ERP._System.__CRM.Leads
{
    [AbpAuthorize]
    public class CrmDealsAppService : AttachBaseAsyncCrudAppService<CrmDeals, CrmDealsDto, long, CrmDealsPagedDto, CrmDealsCreateDto, CrmDealsEditDto, AttachAuditedEntity>, ICrmDealsAppService
    {
        private readonly IRepository<CrmLeadsPersons, long> _crmLeadsPersonsRepo;
        private readonly IRepository<CrmDealsAttachments, long> _repoCrmDealsAttachments;
        public CrmDealsAppService(IRepository<CrmDeals, long> repository, 
            IRepository<CrmLeadsPersons, long> crmLeadsPersonsRepo,
            IConfiguration config, 
            IRepository<CrmDealsAttachments, long> repoCrmDealsAttachments
            ) : base(repository, config)
        {
            CreatePermissionName = PermissionNames.Pages_CrmDeals_Insert;
            UpdatePermissionName = PermissionNames.Pages_CrmDeals_Update;
            DeletePermissionName = PermissionNames.Pages_CrmDeals_Delete;
            GetAllPermissionName = PermissionNames.Pages_CrmDeals;
            _crmLeadsPersonsRepo = crmLeadsPersonsRepo;
            _repoCrmDealsAttachments = repoCrmDealsAttachments;
        }

        private async Task InsertCrmDealsAttachmentsData(CrmDealsAttachmentsDto attachmentsDto, long crmDealsId)
        {
            attachmentsDto.CrmDealsId = crmDealsId;

            var attachments = ObjectMapper.Map<CrmDealsAttachments>(attachmentsDto);

            _ = await _repoCrmDealsAttachments.InsertAsync(attachments);
        }


        public async Task<List<CrmDealsAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            var listData = await _repoCrmDealsAttachments.GetAllListAsync(d => d.CrmDealsId == input.Id);

            return ObjectMapper.Map<List<CrmDealsAttachmentsDto>>(listData);
        }

        private async Task CRUD_CrmDealsAttachments(ICollection<CrmDealsAttachmentsDto> attachmentsDtos, long crmDealsId)
        {
            if (attachmentsDtos?.Count > 0)
            {
                foreach (var item in attachmentsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var attachments = await _repoCrmDealsAttachments.GetAsync((long)item.Id);

                        item.CrmDealsId = crmDealsId;

                        ObjectMapper.Map(item, attachments);

                        _ = await _repoCrmDealsAttachments.UpdateAsync(attachments);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertCrmDealsAttachmentsData(item, crmDealsId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoCrmDealsAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }
        }



        protected override IQueryable<CrmDeals> CreateFilteredQuery(CrmDealsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.DealTypeLkps, x => x.LeadSourceLkps,
                x => x.StageLkps, x => x.CrmLeadsPersons); 


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.DealName))
                iqueryable = iqueryable.Where(z => z.DealName.Contains(input.Params.DealName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.DealDate))
                iqueryable = iqueryable.Where(z => z.DealDate== DateTimeController.ConvertToDateTime(input.Params.DealDate));

            if (input.Params != null && input.Params.DealTypeLkpId != null)
                iqueryable = iqueryable.Where(z => z.DealTypeLkpId == input.Params.DealTypeLkpId);

            if (input.Params != null && input.Params.CrmLeadsPersonsId != null)
                iqueryable = iqueryable.Where(z => z.CrmLeadsPersonsId == input.Params.CrmLeadsPersonsId);   
            
            if (input.Params != null && input.Params.StageLkpID != null)
                iqueryable = iqueryable.Where(z => z.StageLkpID == input.Params.StageLkpID);

            if (input.Params != null && input.Params.Company != null)
                iqueryable = iqueryable.Where(z => z.Company.Contains(input.Params.Company));
            iqueryable.ForEachAsync(x => x.Lang = input.Params.Lang);


            return iqueryable;
        }

        public async override Task<CrmDealsDto> Get(EntityDto<long> input)
        {
            var res= await Repository
                .GetAllIncluding(x => x.DealTypeLkps, x => x.LeadSourceLkps,
                x => x.StageLkps, x => x.CrmLeadsPersons).Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            var mapped = ObjectMapper.Map<CrmDealsDto>(res);
            return mapped;

        }
        

        public async Task<CrmDealsDto> GetSingle(EntityDto<long> input, string lang)
        {
            var res= await Repository
                .GetAllIncluding(x => x.DealTypeLkps, x => x.LeadSourceLkps,
                x => x.StageLkps, x => x.CrmLeadsPersons).Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            var mapped = ObjectMapper.Map<CrmDealsDto>(res);
            res.Lang = lang;
            return mapped;
        }

    



        public async override Task<CrmDealsDto> Create(CrmDealsCreateDto input)
        { 
            CheckCreatePermission();
           // return await base.Create(input);

            var crmDeals = await base.Create(input);


            if (input.Attachments?.Count > 0)
                foreach (var item in input.Attachments)
                    await InsertCrmDealsAttachmentsData(item, crmDeals.Id);


            return new CrmDealsDto { };
        }

        public async override Task<CrmDealsDto> Update(CrmDealsEditDto input)
        { 
            CheckUpdatePermission();
            _ = await base.Update(input);
            await CRUD_CrmDealsAttachments(input.Attachments, input.Id);

            return new CrmDealsDto { };
        }

       
        public async Task<Select2PagedResult> GetCrmLeadsPersons_ContactSelect2(long id, string searchTerm, int pageSize, int pageNumber, string lang)
        {
 
            var data = _crmLeadsPersonsRepo.GetAll()
                     .Where(z => (z.Id != id) && (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) && z.TypeLkpId== 11121));

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
