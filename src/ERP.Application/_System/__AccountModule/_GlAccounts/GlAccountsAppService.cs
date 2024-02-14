using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._GlAccounts.Proc;
using ERP._System.__AccountModule._GlAccounts.ProcDto;
using ERP._System._GlAccounts.Dto;
using ERP._System._GlCodeComDetails;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._GlAccounts
{
    [AbpAuthorize]
    public class GlAccountsAppService : AsyncCrudAppService<GlAccounts, GlAccountDto, long, PagedGlAccountsResultRequestDto, CreateGlAccountsDto, GlAccountsEditDto>, IGlAccountsAppService
    {
        private readonly IGlAccountsManager _glAccountsManager;
        private readonly IGlCodeComDetailsManager _GlCodeComDetailsManager;
        private readonly IGlAccountsScreenDataRepository _glAccountsScreenDataRepository;

        public GlAccountsAppService(IGlAccountsScreenDataRepository glAccountsScreenDataRepository, IRepository<GlAccounts, long> repository, IGlAccountsManager glAccountsManager, IGlCodeComDetailsManager GlCodeComDetailsManager) : base(repository)
        {
            _glAccountsManager = glAccountsManager;
            _GlCodeComDetailsManager = GlCodeComDetailsManager;
            _glAccountsScreenDataRepository = glAccountsScreenDataRepository;

            CreatePermissionName = PermissionNames.Pages_GlAccounts_Insert;
            UpdatePermissionName = PermissionNames.Pages_GlAccounts_Update;
            DeletePermissionName = PermissionNames.Pages_GlAccounts_Delete;
            GetAllPermissionName = PermissionNames.Pages_GlAccounts;
        }

        public async Task<Select2PagedResult> GetGlAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string filterTrigger = null)
            => await _glAccountsManager.GetGlAccountsSelect2(searchTerm, pageSize, pageNumber, lang, filterTrigger);

        public async Task<List<CustomTreeReturn>> GetMyTreeAsync(string lang, long id)
        {
            var current = await Repository.GetAll().Where(x => x.Id != id).ToListAsync();

            var result = current.OrderBy(q => q.Id).Select(z => new CustomTreeReturn { id = z.Id.ToString(), parent = z.ParentId != null ? z.ParentId.ToString() : "#", text = lang == "ar-EG" ? z.Code + " " + z.DescriptionAr : z.Code + " " + z.DescriptionEn }).ToList();

            return result;
        }

        public async Task<GlAccountDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues, z => z.GlAccount)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<GlAccountDto>(current);

            return mapped;
        }

        public async override Task<PagedResultDto<GlAccountDto>> GetAll(PagedGlAccountsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAll();

            if (!string.IsNullOrEmpty(input.Params.DescriptionAr))
            {
                queryable = queryable.Where(q => q.DescriptionAr.Contains(input.Params.DescriptionAr));
            }
            if (!string.IsNullOrEmpty(input.Params.DescriptionEn))
            {
                queryable = queryable.Where(q => q.DescriptionEn.Contains(input.Params.DescriptionEn));
            }
            if (!string.IsNullOrEmpty(input.Params.Code))
            {
                queryable = queryable.Where(q => q.Code.Contains(input.Params.Code));
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<GlAccountDto>());

            var PagedResultDto = new PagedResultDto<GlAccountDto>()
            {
                Items = data2 as IReadOnlyList<GlAccountDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<bool> GetExistCodeAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.Code.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistDescriptionArAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.DescriptionAr.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistDescriptionEnAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.DescriptionEn.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetGlAccountBoolAsync(long Id)
        {
            bool current = await _GlCodeComDetailsManager.GetACCIDBool(Id);

            return current;
        }

        public async Task<List<GlAccountsScreenDataOutput>> GetGlAccountsScreenData(GlAccountsScreenDataInput glAccountsScreenDataInput)
        {
            try
            {
                glAccountsScreenDataInput.TenantId = AbpSession.TenantId.Value;

                var result = await _glAccountsScreenDataRepository.Execute(glAccountsScreenDataInput, "GetGlAccountsScreenData");

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Select2PagedResult> GetGlAccountsForAccMappingSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _glAccountsManager.GetGlAccountsForAccMappingSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
