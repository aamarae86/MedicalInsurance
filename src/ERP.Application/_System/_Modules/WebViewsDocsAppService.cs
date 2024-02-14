using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System._modules;
using ERP._System._Modules.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._Modules
{
    [AbpAuthorize(PermissionNames.Pages_PagesDocs)]
    public class WebViewsDocsAppService : AttachBaseAsyncCrudAppService<Page, PagesDto, int, PagesPagedDto, PagesCreateDto, PagesDocsEditDto, AttachEntity>, IPagesDocsAppService
    {
        public WebViewsDocsAppService(IRepository<Page, int> repository, IConfiguration config) : base(repository, config)
        {
            GetAllPermissionName = PermissionNames.Pages_PagesDocs;
            UpdatePermissionName = PermissionNames.Pages_PagesDocs_Update;
        }

        public override Task<PagesDto> Create(PagesCreateDto input) => throw new UserFriendlyException("Invalid!!");

        public override Task Delete(EntityDto<int> input) => throw new UserFriendlyException("Invalid!!");

        protected override IQueryable<Page> CreateFilteredQuery(PagesPagedDto input)
        {
            var query = Repository.GetAllIncluding(z => z.Module);

            if (input.Params != null && input.Params.ModuleId != null && input.Params.ModuleId != 0)
                query = query.Where(z => z.ModuleId == input.Params.ModuleId);

            return query;
        }

        public override async Task<PagesDto> Update(PagesDocsEditDto input)
        {
            try
            {
                var curent = await Repository.GetAsync(input.Id);
              //  input.ModuleId= curent.ModuleId;
                ObjectMapper.Map(input, curent);

                _ = await Repository.UpdateAsync(curent);
               
                return new PagesDto { };
            }
            catch (System.Exception ex)
            {

                throw;
            }
            
        }
    }
}
