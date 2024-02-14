using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CRM._CrmContactUs.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ERP._System.__CRM._CrmContactUs
{
    [AbpAuthorize(PermissionNames.Pages_CrmContactUs)]
    public class CrmContactUsAppService : AttachBaseAsyncCrudAppService<CrmContactUs, CrmContactUsDto, long, CrmContactUsPagedDto, CrmContactUsCreateDto, CrmContactUsEditDto, AttachAuditedEntity>, ICrmContactUsAppService
    {
        public CrmContactUsAppService(IRepository<CrmContactUs, long> repository, IConfiguration config) : base(repository, config)
        {
            CreatePermissionName = PermissionNames.Pages_CrmContactUs_Insert;
            UpdatePermissionName = PermissionNames.Pages_CrmContactUs_Update;
            DeletePermissionName = PermissionNames.Pages_CrmContactUs_Delete;
            GetAllPermissionName = PermissionNames.Pages_CrmContactUs;

            PreFileName = "CrmContactUs";
            ServiceFolder = "CrmContactUs";
        }

        protected override IQueryable<CrmContactUs> CreateFilteredQuery(CrmContactUsPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HeaderNameAr))
                iqueryable = iqueryable.Where(z => z.HeaderNameAr.Contains(input.Params.HeaderNameAr));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HeaderNameEn))
                iqueryable = iqueryable.Where(z => z.HeaderNameEn.Contains(input.Params.HeaderNameEn));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Email))
                iqueryable = iqueryable.Where(z => z.Email.Contains(input.Params.Email));

            return iqueryable;
        }
    }
}
