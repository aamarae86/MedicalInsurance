using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ArDrCrHd.Dto;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._ArDrCrHd.Dto;
using ERP._System._ArDrCrTr;
using ERP._System._ArDrCrTr.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
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

namespace ERP._System._ArDrCrHd
{
    [AbpAuthorize]
    public class ArDrCrHdAppService : AsyncCrudAppService<ArDrCrHd, ArDrCrHdDto, long, PagedArDrCrHdResultRequestDto, CreateArDrCrHdDto, ArDrCrHdEditDto>,
        IArDrCrHdAppService
    {
        private readonly IRepository<ArDrCrTr, long> _repoArDrCrTr;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IArInvoiceHdRepository _repoForStored;

        public ArDrCrHdAppService(IRepository<ArDrCrHd, long> repository,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IGetCounterRepository repoProcCounter,
            IArInvoiceHdRepository arInvoiceHdRepository,
            IRepository<ArDrCrTr, long> repoArDrCrTr) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoArDrCrTr = repoArDrCrTr;
            _repoProcCounter = repoProcCounter;
            _repoForStored = arInvoiceHdRepository;

            CreatePermissionName = PermissionNames.Pages_ArDrCrHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArDrCrHd_Update;
            DeletePermissionName = PermissionNames.Pages_ArDrCrHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArDrCrHd;
        }

        public async override Task<PagedResultDto<ArDrCrHdDto>> GetAll(PagedArDrCrHdResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndLookupValuesHdTypeLkp, x => x.FndLookupValuesStatusLkp, x => x.FndLookupValuesSourceLkp, x => x.Currency, x => x.ArCustomers, x => x.ArDrCrTr);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdDrCrNumber))
                queryable = queryable.Where(q => q.HdDrCrNumber.Contains(input.Params.HdDrCrNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdDate))
                queryable = queryable.Where(q => q.HdDate == DateTimeController.ConvertToDateTime(input.Params.HdDate));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.HdTypeLkpId != null)
                queryable = queryable.Where(q => q.HdTypeLkpId == input.Params.HdTypeLkpId);

            if (input.Params != null && input.Params.ArCustomerId != null)
                queryable = queryable.Where(q => q.ArCustomerId == input.Params.ArCustomerId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArDrCrHdDto>());

            var PagedResultDto = new PagedResultDto<ArDrCrHdDto>()
            {
                Items = data2 as IReadOnlyList<ArDrCrHdDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<ArDrCrHdDto> Create(CreateArDrCrHdDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "ArDrCrHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };
            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.HdDrCrNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;

            var current = await base.Create(input);

            foreach (var item in input.ArDrCrTrList)
            {
                var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);

                item.AccountId = currentComCodeId;
                item.ArDrCrHdId = current.Id;

                var currentDetail = ObjectMapper.Map<ArDrCrTr>(item);
                await _repoArDrCrTr.InsertAsync(currentDetail);
            }

            return new ArDrCrHdDto();
        }

        public async Task<ArDrCrHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.Currency,
                           x => x.FndLookupValuesHdTypeLkp,
                           v => v.FndLookupValuesStatusLkp,
                           vv => vv.FndLookupValuesSourceLkp,
                           vv => vv.ArCustomers, vv => vv.ArDrCrTr)
                                       .Where(z => z.Id == input.Id)
                                       .FirstOrDefaultAsync();

            return ObjectMapper.Map<ArDrCrHdDto>(current);
        }

        public async Task<List<ArDrCrTrVM>> GetAllArDrCrHdDetails(long gljeheaderId)
        {
            var output = new List<ArDrCrTrVM>();

            var gljeLines = await _repoArDrCrTr.GetAllIncluding(x => x.GlCodeComDetails, x => x.ArDrCrHd).Where(x => x.ArDrCrHdId == gljeheaderId).ToListAsync();
            int counter = 0;

            foreach (var item in gljeLines)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);

                var current = new ArDrCrTrVM();

                current.index = ++counter;
                current.Amount = item.Amount;
                current.Description = item.Description;
                current.Id = item.Id;
                current.codeComUtilityIds = ids;
                current.codeComUtilityTexts = texts;
                current.ArDrCrHdId = item.ArDrCrHdId;
                current.rowStatus = DetailRowStatus.RowStatus.NoAction.ToString();
                current.Tax = item.Tax;
                output.Add(current);
            }

            return output;
        }

        public async override Task<ArDrCrHdDto> Update(ArDrCrHdEditDto input)
        {
            try
            {

                CheckUpdatePermission();

                await base.Update(input);

                foreach (var item in input.ArDrCrTrList)
                {

                    if (item.Id != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var currentGeJeLine = await _repoArDrCrTr.GetAsync((long)item.Id);
                        var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);

                        var mappedDto = ObjectMapper.Map(currentGeJeLine, new ArDrCrTrVM());

                        mappedDto.AccountId = (long)currentComCodeId;
                        mappedDto.Amount = item.Amount;
                        mappedDto.Description = item.Description;
                        mappedDto.Tax = item.Tax;

                        var mappedEntity = ObjectMapper.Map(mappedDto, currentGeJeLine);

                        _ = await _repoArDrCrTr.UpdateAsync(mappedEntity);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                        item.ArDrCrHdId = input.Id;
                        item.AccountId = currentComCodeId;
                        var currentDetail = ObjectMapper.Map<ArDrCrTr>(item);

                        _ = await _repoArDrCrTr.InsertAsync(currentDetail);
                    }
                    else if (item.Id != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoArDrCrTr.DeleteAsync((long)item.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return new ArDrCrHdDto { };
        }

        public async override Task Delete(EntityDto<long> input)
        {
            CheckDeletePermission();

            var Details = await _repoArDrCrTr.GetAll().Where(x => x.ArDrCrHdId == input.Id).ToListAsync();

            foreach (var item in Details) await _repoArDrCrTr.DeleteAsync(item.Id);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<PostOutput> PostArDrCrHd(PostDto postDto)
        {
            if (AbpSession.UserId.HasValue) { postDto.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoForStored.Execute(postDto, "ArDrCrHdPost");

            return postResult.FirstOrDefault();
        }
    }
}
