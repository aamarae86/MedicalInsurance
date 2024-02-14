using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses._IvItemsTypesConfigure.Dto;
using ERP._System._GlAccounts.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvItemsTypesConfigure
{
    [AbpAuthorize]
    public class IvItemsTypesConfigureAppService : AsyncCrudAppService<IvItemsTypesConfigure, IvItemsTypesConfigureDto, long, IvItemsTypesConfigurePagedDto, IvItemsTypesConfigureCreateDto, IvItemsTypesConfigureEditDto>,
        IIvItemsTypesConfigureAppService
    {
        private readonly IIvItemsTypesConfigureManager _ivItemsTypesConfigureManager;

        public IvItemsTypesConfigureAppService(IIvItemsTypesConfigureManager ivItemsTypesConfigureManager,
            IRepository<IvItemsTypesConfigure, long> repository) : base(repository)
        {
            _ivItemsTypesConfigureManager = ivItemsTypesConfigureManager;

            CreatePermissionName = PermissionNames.Pages_IvItemsTypesConfigure_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvItemsTypesConfigure_Update;
            DeletePermissionName = PermissionNames.Pages_IvItemsTypesConfigure_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvItemsTypesConfigure;
        }

        protected override IQueryable<IvItemsTypesConfigure> CreateFilteredQuery(IvItemsTypesConfigurePagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.NameAr))
                iqueryable = iqueryable.Where(z => z.NameAr.Contains(input.Params.NameAr));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.NameEn))
                iqueryable = iqueryable.Where(z => z.NameEn.Contains(input.Params.NameEn));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ConfigureCode))
                iqueryable = iqueryable.Where(z => z.ConfigureCode.Contains(input.Params.ConfigureCode));

            return iqueryable;
        }

        public async Task<List<CustomTreeReturn>> GetItemsTree(long id, string lang = "ar-EG")
        {
            var data = await Repository.GetAll().Where(x => x.Id != id).ToListAsync();

            var result = data.OrderBy(q => q.Id)
                                .Select(z => new CustomTreeReturn { id = z.Id.ToString(), parent = z.ParentId != null ? z.ParentId.ToString() : "#", text = lang == "ar-EG" ? $"{z.ConfigureCode}-{z.NameAr}" : $"{z.ConfigureCode}-{z.NameEn}" })
                                .ToList();

            return result;
        }

        public async Task<bool> GetExistConfigureCodeAsync(string input, long Id)
            => await Repository.GetAll().Where(x => x.ConfigureCode.ToLower() == input.ToLower() && x.Id != Id).AnyAsync();

        public async Task<bool> GetExistNameArAsync(string input, long Id)
            => await Repository.GetAll().Where(x => x.NameAr.ToLower() == input.ToLower() && x.Id != Id).AnyAsync();

        public async Task<bool> GetExistNameEnAsync(string input, long Id)
            => await Repository.GetAll().Where(x => x.NameEn.ToLower() == input.ToLower() && x.Id != Id).AnyAsync();

        public async Task<IvItemsTypesConfigureDto> GetDetailAsync(EntityDto<long> input)
            => ObjectMapper.Map<IvItemsTypesConfigureDto>(await Repository.GetAllIncluding(z => z.Parent).Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<Select2PagedResult> GetIvItemsTypesConfigureSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _ivItemsTypesConfigureManager.GetIvItemsTypesConfigureSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetIvItemsTypesConfigureWithParentSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _ivItemsTypesConfigureManager.GetIvItemsTypesConfigureWithParentSelect2(searchTerm, pageSize, pageNumber, lang);

        
    }
}
