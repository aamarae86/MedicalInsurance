using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._TmCharityBoxesType.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._TmCharityBoxesType
{
    [AbpAuthorize]
    public class TmCharityBoxesTypeAppService : AsyncCrudAppService<TmCharityBoxesType, TmCharityBoxesTypeDto, long, PagedTmCharityBoxesTypeResultRequestDto, CreateTmCharityBoxesTypeDto, TmCharityBoxesTypeEditDto>, ITmCharityBoxesTypeAppService
    {
        private readonly ITmCharityBoxesTypeManager _tmCharityBoxesTypeManager;

        public TmCharityBoxesTypeAppService(IRepository<TmCharityBoxesType, long> repository
            , ITmCharityBoxesTypeManager tmCharityBoxesTypeManager) : base(repository)
        {
            _tmCharityBoxesTypeManager = tmCharityBoxesTypeManager;

            CreatePermissionName = PermissionNames.Pages_TmCharityBoxesType_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmCharityBoxesType_Update;
            DeletePermissionName = PermissionNames.Pages_TmCharityBoxesType_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmCharityBoxesType;
        }


        public async override Task<PagedResultDto<TmCharityBoxesTypeDto>> GetAll(PagedTmCharityBoxesTypeResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TypeCode))
            {
                queryable = queryable.Where(q => q.TypeCode.Contains(input.Params.TypeCode));
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CharityBoxTypeName))
            {
                queryable = queryable.Where(q => q.CharityBoxTypeName.Contains(input.Params.CharityBoxTypeName));
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<TmCharityBoxesTypeDto>());

            var PagedResultDto = new PagedResultDto<TmCharityBoxesTypeDto>()
            {
                Items = data2 as IReadOnlyList<TmCharityBoxesTypeDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _tmCharityBoxesTypeManager.GetSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
