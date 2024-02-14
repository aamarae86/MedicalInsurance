using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Castle.DynamicProxy.Generators;
using ERP._System.__AccountModule._GlJeHeaders.Dto;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails;
using ERP._System._GlJeHeaders.Dto;
using ERP._System._GlJeHeaders.ProcDto;
using ERP._System._GlJeHeaders.Procs;
using ERP._System._GlJeLines;
using ERP._System._GlJeLines.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using static ERP._System._FndLookupValues.Dto.FndEnum;

namespace ERP._System._GlJeHeaders
{
    [AbpAuthorize]
    public class GlJeHeadersAppService : AsyncCrudAppService<GlJeHeaders, GlJeHeadersDto, long, PagedGlJeHeadersResultRequestDto, CreateGlJeHeadersDto, GlJeHeadersEditDto>,
         IGlJeHeadersAppService
    {
        private readonly IGlJeLinesManager _glJeLinesManager;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGlJeHeadersRepository _repoGljeHeaders;
        private readonly IJeNumberRepository _jeNumberProcRepository;
        private readonly IGetGlJeScreenDataRepository _repoGlJeScreen;
        private readonly IRepository<GlJeLines, long> _repoGlJeLines;
        private readonly IRepository<GlCodeComDetails, long> _glCodeComDetailsRepo;
        
        public GlJeHeadersAppService(IRepository<GlJeHeaders, long> repository,
            IRepository<GlCodeComDetails, long> glCodeComDetailsRepo,
            IRepository<GlJeLines, long> repoGlJeLines, IGlJeHeadersRepository glJeHeadersRepository,
            IGlJeLinesManager glJeLinesManager, IGlCodeComDetailsManager glCodeComDetailsManager,
            IJeNumberRepository jeNumberRepository, IGetGlJeScreenDataRepository repoGlJeScreen) : base(repository)
        {
            _glJeLinesManager = glJeLinesManager;
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoGlJeLines = repoGlJeLines;
            _jeNumberProcRepository = jeNumberRepository;
            _repoGljeHeaders = glJeHeadersRepository;
            _repoGlJeScreen = repoGlJeScreen;
            _glCodeComDetailsRepo = glCodeComDetailsRepo;

            CreatePermissionName = PermissionNames.Pages_GlJeHeaders_Insert;
            UpdatePermissionName = PermissionNames.Pages_GlJeHeaders_Update;
            DeletePermissionName = PermissionNames.Pages_GlJeHeaders_Delete;
            GetAllPermissionName = PermissionNames.Pages_GlJeHeaders;
        }

        public async override Task<GlJeHeadersDto> Create(CreateGlJeHeadersDto input)
        {
            CheckCreatePermission();

            if (input.PeriodId == null) throw new UserFriendlyException("الفترة مطلوبة!!");

            input.JeNumber = await GetJeNumber(DateTimeController.ConvertToDateTime(input.JeDate), (long)input.PeriodId);

            var current = await base.Create(input);

            var lines = new List<GlJeLines>();

            foreach (var item in input.GlJeLinesDetailsVM)
            {
                var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);

                lines.Add(GlJeLines.Create(item.debitAmount, item.creditAmount, (long)currentComCodeId, current.Id, null, null, item.Notes));
            }

            _ = await _glJeLinesManager.CreateListGlJeLines(lines);

            return new GlJeHeadersDto();
        }

        public async override Task<GlJeHeadersDto> Update(GlJeHeadersEditDto input)
        {
            CheckUpdatePermission();

            if (await CheckPostedStatus(input.Id)) return new GlJeHeadersDto { ValidActionAfterPostStatus = false };

            var current = await Repository.GetAsync(input.Id);
            if(DateTimeController.ConvertToDateTime(input.JeDate) != current.JeDate)
            {
                input.JeNumber = await GetJeNumber(DateTimeController.ConvertToDateTime(input.JeDate), (long)input.PeriodId);
            }
           

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            foreach (var item in input.GlJeLinesDetailsVM)
            {
                var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);

                if (item.glJeLineId != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                {
                    var currentGeJeLine = await _repoGlJeLines.GetAsync((long)item.glJeLineId);

                    var mappedDto = ObjectMapper.Map(currentGeJeLine, new GlJeLinesDto());

                    mappedDto.AccountId = (long)currentComCodeId;
                    mappedDto.DebitAmount = item.debitAmount;
                    mappedDto.CreditAmount = item.creditAmount;
                    mappedDto.Notes = item.Notes;

                    var mappedEntity = ObjectMapper.Map(mappedDto, currentGeJeLine);

                    _ = await _repoGlJeLines.UpdateAsync(mappedEntity);

                }
                else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                {
                    var currentLine = GlJeLines.Create(item.debitAmount, item.creditAmount, (long)currentComCodeId, current.Id, null, null, item.Notes);

                    _ = await _repoGlJeLines.InsertAsync(currentLine);
                }
                else if (item.glJeLineId != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                {
                    await _repoGlJeLines.DeleteAsync((long)item.glJeLineId);
                }
            }

            return new GlJeHeadersDto { ValidActionAfterPostStatus = true };
        }

        public async Task<GlJeHeadersDetailDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.Currency,
                           x => x.StatusFndLookupValues, v => v.JeSourceFndLookupValues,
                           vv => vv.GlPeriodsDetails)
           .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<GlJeHeadersDetailDto>(current);
        }

        public async override Task Delete(EntityDto<long> input)
        {
            if (await CheckPostedStatus(input.Id)) return;

            //What if status is 'posted'?!!
            var listDetails = await _glJeLinesManager.DeleteGlJeLines(input.Id);
            if (listDetails) await Repository.DeleteAsync(input.Id);
        }

        public async Task<List<GlJeLinesDetailsVM>> GetAllGlJeHeaderLinesDetails(long gljeheaderId)
        {
            var output = new List<GlJeLinesDetailsVM>();

            var gljeLines = await _glJeLinesManager.GetJeLineByJeHeader(gljeheaderId);
            int counter = 0;

            foreach (var item in gljeLines)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);
                var codeCom = await _glCodeComDetailsManager.GetAttrNamesCodesNames(item.GlCodeComDetails);

                var current = new GlJeLinesDetailsVM();

                current.index = ++counter;
                current.debitAmount = item.DebitAmount;
                current.creditAmount = item.CreditAmount;
                current.Notes = item.Notes;
                current.glJeLineId = item.Id;
                current.codeComUtilityIds = ids;
                current.codeComUtilityTexts = texts;
                current.AccountNumber = codeCom.codes;
                current.rowStatus = DetailRowStatus.RowStatus.NoAction.ToString();

                output.Add(current);
            }

            return output;
        }

        public async override Task<PagedResultDto<GlJeHeadersDto>> GetAll(PagedGlJeHeadersResultRequestDto input)
         {

            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(zz => zz.Currency, cc => cc.GlPeriodsDetails,
                                      vv => vv.StatusFndLookupValues, bb => bb.JeSourceFndLookupValues);

            if (!string.IsNullOrEmpty(input.Params.JeName))
                queryable = queryable.Where(q => q.JeName.Contains(input.Params.JeName));

            if (!string.IsNullOrEmpty(input.Params.JeNumber))
                queryable = queryable.Where(q => q.JeNumber.Contains(input.Params.JeNumber));

            if (!string.IsNullOrEmpty(input.Params.JeDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.JeDate);
                queryable = queryable.Where(q => q.JeDate == dt);
            }

            if (input.Params.CurrencyId != null)
                queryable = queryable.Where(q => q.CurrencyId == input.Params.CurrencyId);

            if (input.Params.JeSourceLkpId != null)
                queryable = queryable.Where(q => q.JeSourceLkpId == input.Params.JeSourceLkpId);

            if (input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<GlJeHeadersDto>());

            var PagedResultDto = new PagedResultDto<GlJeHeadersDto>()
            {
                Items = data2 as IReadOnlyList<GlJeHeadersDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<PostOutput> PostGlJeHeader(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoGljeHeaders.Execute(input, "GlPostJe");

            return postResult.FirstOrDefault();
        }

        public async Task<List<GlJeScreenDataOutput>> GetGlJeScreenData(IdLangInputDto input)
        {
            var result = await _repoGlJeScreen.Execute(input, "GetGlJeScreenData");

            return result.ToList();
        }

        public async Task<PostOutput> CopyGlJeHeader(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoGljeHeaders.Execute(input, "GlCopytJe");

            return postResult.FirstOrDefault();
        }

        private async Task<bool> CheckPostedStatus(long id)
        {
            var current = await Repository.GetAsync(id);

            return current.StatusLkpId == Convert.ToInt64(FndLkps.Posted_GlJeHeadersStatues);
        }

        private async Task<string> GetJeNumber(DateTime? jeDate, long periodId)
        {
            var jeNumberProcInput = new JeNumberPostDto { TransDate = jeDate ?? DateTime.MinValue, PeriodId = periodId, TenantId = (int)AbpSession.TenantId };

            var jvNum = await _jeNumberProcRepository.Execute(jeNumberProcInput, "GetJeNumber");

            return jvNum?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }
    }
}
