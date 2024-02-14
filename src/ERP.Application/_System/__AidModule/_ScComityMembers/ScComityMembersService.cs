using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._ScComityMembers.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._ScComityMembers
{
    [AbpAuthorize]
    public class ScComityMembersAppService : AsyncCrudAppService<ScComityMembers, ScComityMembersDto, long, PagedScComityMembersResultRequestDto, CreateScComityMembersDto, ScComityMembersEditDto>,
        IScComityMembersAppService
    {
        public ScComityMembersAppService(IRepository<ScComityMembers, long> repository) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_ScComityMembers_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScComityMembers_Update;
            DeletePermissionName = PermissionNames.Pages_ScComityMembers_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScComityMembers;
        }

        public async override Task<PagedResultDto<ScComityMembersDto>> GetAll(PagedScComityMembersResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.FndLookupValues);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MemberName))
            {
                queryable = queryable.Where(q => q.MemberName.Contains(input.Params.MemberName));
            }
            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MemberNumber))
            {
                queryable = queryable.Where(q => q.MemberNumber.Contains(input.Params.MemberNumber));
            }
            if (input.Params != null && input.Params.MemberCategoryLkpId != null && input.Params.MemberCategoryLkpId != 0)
            {
                queryable = queryable.Where(q => q.MemberCategoryLkpId == input.Params.MemberCategoryLkpId);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScComityMembersDto>());
            var PagedResultDto = new PagedResultDto<ScComityMembersDto>()
            {
                Items = data2 as IReadOnlyList<ScComityMembersDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<Select2PagedResult> GetCommitteeMembersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await Repository.GetAll().Include(m => m.FndLookupValues).Where(z => string.IsNullOrEmpty(searchTerm) ||
                   (z.MemberName.Contains(searchTerm) || z.MemberNumber.Contains(searchTerm))
                    ).ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = $"{z.MemberNumber}-{z.MemberName}", altText = lang == "ar-Eg" ? z.FndLookupValues.NameAr : z.FndLookupValues.NameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<ScComityMembersDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ScComityMembersDto>(current);

            return mapped;
        }
    }
}
