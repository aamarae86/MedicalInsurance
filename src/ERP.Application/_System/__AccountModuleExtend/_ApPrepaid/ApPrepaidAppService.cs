using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__AccountModuleExtend._ApPrepaid.Dto;
using ERP._System.__AidModule._ScCampainsDetail.Procs;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._ApPrepaid
{
    [AbpAuthorize]
    public class ApPrepaidAppService : AsyncCrudAppService<ApPrepaid, ApPrepaidDto, long, PagedApPrepaidResultRequestDto, ApPrepaidCreateDto, ApPrepaidEditDto>,
        IApPrepaidAppService
    {
        private readonly ITmCharityBoxReceiveRepository _repoPost;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;

        public ApPrepaidAppService(ITmCharityBoxReceiveRepository idLangPostRepository,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IRepository<ApPrepaid, long> repository) : base(repository)
        {
            _repoPost = idLangPostRepository;
            _glCodeComDetailsManager = glCodeComDetailsManager;

            GetAllPermissionName = PermissionNames.Pages_ApPrepaid;
        }

        public async override Task<PagedResultDto<ApPrepaidDto>> GetAll(PagedApPrepaidResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.DrGlCodeComDetails, x => x.CrGlCodeComDetails, x => x.FndStatusLkp, x => x.FndSourceCodeLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.SourceNo))
                queryable = queryable.Where(z => z.SourceNo.Contains(input.Params.SourceNo));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.SourceCodeLkpId != null)
                queryable = queryable.Where(z => z.SourceCodeLkpId == input.Params.SourceCodeLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TransactionDate))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.TransactionDate);
                queryable = queryable.Where(z => z.TransactionDate == dt);
            }

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ApPrepaidDto>());

            foreach (var item in data2)
            {
                if (item.DrGlCodeComDetails != null)
                {
                    (string ids, string txts) = await _glCodeComDetailsManager.GetCodeComTextsIds(ObjectMapper.Map<GlCodeComDetails>(item.DrGlCodeComDetails), _app.Reqlanguage);

                    item.codeComUtilityIds = ids;
                    item.codeComUtilityTexts = txts;
                }

                if (item.CrGlCodeComDetails != null)
                {
                    (string ids1, string txts1) = await _glCodeComDetailsManager.GetCodeComTextsIds(ObjectMapper.Map<GlCodeComDetails>(item.CrGlCodeComDetails), _app.Reqlanguage);

                    item.codeComUtilityIds_alt1 = ids1;
                    item.codeComUtilityTexts_alt1 = txts1;
                }
            }

            var PagedResultDto = new PagedResultDto<ApPrepaidDto>()
            {
                Items = data2 as IReadOnlyList<ApPrepaidDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<ApPrepaidDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(
                                                x => x.FndStatusLkp,
                                                x => x.FndSourceCodeLkp,
                                                x => x.DrGlCodeComDetails,
                                                x => x.CrGlCodeComDetails)
                                    .Where(z => z.Id == input.Id)
                                    .FirstOrDefaultAsync();

            (string ids, string txts) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.DrGlCodeComDetails, _app.Reqlanguage);
            (string ids1, string txts1) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.CrGlCodeComDetails, _app.Reqlanguage);

            var mapped = ObjectMapper.Map<ApPrepaidDto>(current);

            mapped.codeComUtilityIds = ids;
            mapped.codeComUtilityIds_alt1 = ids1;
            mapped.codeComUtilityTexts = txts;
            mapped.codeComUtilityTexts_alt1 = txts1;

            return mapped;
        }

        public async Task<PostOutput> PostApPrepaid(PostDto UserIdLangInput)
        {
            UserIdLangInput.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(UserIdLangInput, "ApPrepaidPost");

            return result.FirstOrDefault();
        }

        public override Task<ApPrepaidDto> Create(ApPrepaidCreateDto input) => throw new UserFriendlyException("Invalid!!");

        public override Task<ApPrepaidDto> Update(ApPrepaidEditDto input) => throw new UserFriendlyException("Invalid!!");

        public override Task Delete(EntityDto<long> input) => throw new UserFriendlyException("Invalid!!");
    }
}
