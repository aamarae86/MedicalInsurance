using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__AccountModule._GlMainAccounts.Dto;
using ERP._System._GlCodeComDetails;
using ERP._System._GlMainAccounts.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._GlMainAccounts
{
    [AbpAuthorize]
    public class GlMainAccountsAppService : AsyncCrudAppService<GlMainAccounts, GlMainAccountsDto, long, PagedGlMainAccountsResultRequestDto, CreateGlMainAccountsDto, GlMainAccountsEditDto>,
         IGlMainAccountsAppService
    {
        private readonly IGlMainAccountsManager _glMainAccountsManager;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;

        public GlMainAccountsAppService(IRepository<GlMainAccounts, long> repository, IGlMainAccountsManager glMainAccountsManager,
            IGlCodeComDetailsManager glCodeComDetailsManager)
            : base(repository)
        {
            _glMainAccountsManager = glMainAccountsManager;
            _glCodeComDetailsManager = glCodeComDetailsManager;

            CreatePermissionName = PermissionNames.Pages_GlMainAccounts_Insert;
            UpdatePermissionName = PermissionNames.Pages_GlMainAccounts_Update;
            DeletePermissionName = PermissionNames.Pages_GlMainAccounts_Delete;
            GetAllPermissionName = PermissionNames.Pages_GlMainAccounts;
        }

        public override Task<GlMainAccountsDto> Create(CreateGlMainAccountsDto input) => throw new UserFriendlyException("Invalid");

        public override Task Delete(EntityDto<long> input) => throw new UserFriendlyException("Invalid");

        public async Task<Select2PagedResult> GetGlMainAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _glMainAccountsManager.GetGlMainAccountsSelect2(searchTerm, pageSize, pageNumber, lang);

        public async override Task<PagedResultDto<GlMainAccountsDto>> GetAll(PagedGlMainAccountsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.GlCodeComDetails,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr1,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr2,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr3,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr4,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr5,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr6,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr7,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr8,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr9,
                                        z => z.GlCodeComDetails.GlAccounts);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ReferenceCode))
                queryable = queryable.Where(q => q.ReferenceCode.Contains(input.Params.ReferenceCode));

            if (input.Params != null && input.Params.DescriptionSearchId != null)
                queryable = queryable.Where(q => q.Id == input.Params.DescriptionSearchId);

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var dataMapped = ObjectMapper.Map(data, new List<GlMainAccountsDto>());

            var PagedResultDto = new PagedResultDto<GlMainAccountsDto>()
            {
                Items = dataMapped as IReadOnlyList<GlMainAccountsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<GlMainAccountsDto> Update(GlMainAccountsEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            long? currentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            current.SetAccountId(currentCodeComId);

            _ = await Repository.UpdateAsync(current);

            return new GlMainAccountsDto();
        }

        public async Task<GlMainAccountsDto> GetDetailAsync(EntityDto<long> input)
        {
            var currentENtity = await Repository.GetAllIncluding(z => z.GlCodeComDetails,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr1,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr2,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr3,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr4,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr5,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr6,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr7,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr8,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr9,
                                        z => z.GlCodeComDetails.GlAccounts)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map(currentENtity, new GlMainAccountsDto());
        }
    }
}
