using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System._modules;
using ERP._System._Modules.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._Modules
{
    [AbpAuthorize(PermissionNames.Pages_Pages)] 
    public class WebViewsAppService : AsyncCrudAppService<Page, PagesDto, int, PagesPagedDto, PagesCreateDto, PagesEditDto>, IPagesAppService
    {
        private readonly IPageManager _pageManager;

        public WebViewsAppService(IRepository<Page, int> repository, IPageManager pageManager) : base(repository)
        {
            _pageManager = pageManager;

            GetAllPermissionName = PermissionNames.Pages_Pages;
            UpdatePermissionName = PermissionNames.Pages_Pages_Update;
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

        public async Task<Select2PagedResult> GetSelect2(long parentId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pageManager.GetSelect2(parentId, searchTerm, pageSize, pageNumber, lang);
    }
}
