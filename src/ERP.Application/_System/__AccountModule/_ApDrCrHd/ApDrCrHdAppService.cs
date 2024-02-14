using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApDrCrHd.Dto;
using ERP._System.__AccountModule._ApDrCrTr;
using ERP._System.__AccountModule._ApDrCrTr.Dto;
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

namespace ERP._System.__AccountModule._ApDrCrHd
{
    [AbpAuthorize]
    public class ApDrCrHdAppService : AsyncCrudAppService<ApDrCrHd, ApDrCrHdDto, long, PagedApDrCrHdResultRequestDto, ApDrCrHdCreateDto, ApDrCrHdEditDto>,
        IApDrCrHdAppService
    {
        private readonly IRepository<ApDrCrTr, long> _repoApDrCrTr;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IArInvoiceHdRepository _repoForStored;

        public ApDrCrHdAppService(IRepository<ApDrCrHd, long> repository,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IGetCounterRepository repoProcCounter,
            IArInvoiceHdRepository arInvoiceHdRepository,
            IRepository<ApDrCrTr, long> repoApDrCrTr) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoApDrCrTr = repoApDrCrTr;
            _repoProcCounter = repoProcCounter;
            _repoForStored = arInvoiceHdRepository;

            CreatePermissionName = PermissionNames.Pages_ApDrCrHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_ApDrCrHd_Update;
            DeletePermissionName = PermissionNames.Pages_ApDrCrHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_ApDrCrHd;
        }

        public async override Task<ApDrCrHdDto> Create(ApDrCrHdCreateDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "ApDrCrHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };
            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.HdDrCrNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;
            input.SourceLkpId = 31608; //31608 - Manual(ApDrCrHdSource)

            var current = await base.Create(input);

            foreach (var item in input.ApDrCrTrList)
            {
                var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);

                item.AccountId = currentComCodeId;
                item.ApDrCrHdId = current.Id;

                var currentDetail = ObjectMapper.Map<ApDrCrTr>(item);
                await _repoApDrCrTr.InsertAsync(currentDetail);
            }

            return new ApDrCrHdDto();
        }

        public async override Task<ApDrCrHdDto> Update(ApDrCrHdEditDto input)
        {
            try
            {
                CheckUpdatePermission();
                await base.Update(input);

                foreach (var item in input.ApDrCrTrList)
                {

                    if (item.Id != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var currentGeJeLine = await _repoApDrCrTr.GetAsync((long)item.Id);
                        var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);

                        var mappedDto = ObjectMapper.Map(currentGeJeLine, new ApDrCrTrDto());

                        mappedDto.AccountId = (long)currentComCodeId;
                        mappedDto.Amount = item.Amount;
                        mappedDto.Description = item.Description;
                        mappedDto.Tax = item.Tax;

                        var mappedEntity = ObjectMapper.Map(mappedDto, currentGeJeLine);

                        _ = await _repoApDrCrTr.UpdateAsync(mappedEntity);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                        item.ApDrCrHdId = input.Id;
                        item.AccountId = currentComCodeId;
                        var currentDetail = ObjectMapper.Map<ApDrCrTr>(item);

                        _ = await _repoApDrCrTr.InsertAsync(currentDetail);
                    }
                    else if (item.Id != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoApDrCrTr.DeleteAsync((long)item.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return new ApDrCrHdDto { };
        }

        public async override Task Delete(EntityDto<long> input)
        {
            CheckDeletePermission();

            var Details = await _repoApDrCrTr.GetAll().Where(x => x.ApDrCrHdId == input.Id).ToListAsync();

            foreach (var item in Details) await _repoApDrCrTr.DeleteAsync(item.Id);

            await Repository.DeleteAsync(input.Id);
        }

        public async override Task<PagedResultDto<ApDrCrHdDto>> GetAll(PagedApDrCrHdResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndLookupValuesHdTypeLkp, x => x.FndLookupValuesStatusLkp, x => x.FndLookupValuesSourceLkp, x => x.Currency, x => x.Vendors, x => x.ApDrCrTr);


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdDrCrNumber))
                queryable = queryable.Where(q => q.HdDrCrNumber.Contains(input.Params.HdDrCrNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdDate))
                queryable = queryable.Where(q => q.HdDate == DateTimeController.ConvertToDateTime(input.Params.HdDate));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.HdTypeLkpId != null)
                queryable = queryable.Where(q => q.HdTypeLkpId == input.Params.HdTypeLkpId);

            if (input.Params != null && input.Params.VendorId != null)
                queryable = queryable.Where(q => q.VendorId == input.Params.VendorId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ApDrCrHdDto>());

            var PagedResultDto = new PagedResultDto<ApDrCrHdDto>()
            {
                Items = data2 as IReadOnlyList<ApDrCrHdDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<ApDrCrHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.Currency,
                            x => x.FndLookupValuesHdTypeLkp,
                            v => v.FndLookupValuesStatusLkp,
                            vv => vv.FndLookupValuesSourceLkp,
                            vv => vv.Vendors, vv => vv.ApDrCrTr)
                                        .Where(z => z.Id == input.Id)
                                        .FirstOrDefaultAsync();

            return ObjectMapper.Map<ApDrCrHdDto>(current);
        }

        public async Task<List<ApDrCrTrDto>> GetAllApDrCrHdDetails(long gljeheaderId)
        {
            var output = new List<ApDrCrTrDto>();

            var gljeLines = await _repoApDrCrTr.GetAllIncluding(x => x.GlCodeComDetails, 
                                                                x => x.ApDrCrHd)
                                                                .Where(x => x.ApDrCrHdId == gljeheaderId)
                                                                .ToListAsync();
            int counter = 0;

            foreach (var item in gljeLines)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);

                var current = new ApDrCrTrDto();

                current.index = ++counter;
                current.Amount = item.Amount;
                current.Description = item.Description;
                current.Id = item.Id;
                current.codeComUtilityIds = ids;
                current.codeComUtilityTexts = texts;
                current.ApDrCrHdId = item.ApDrCrHdId;
                current.rowStatus = DetailRowStatus.RowStatus.NoAction.ToString();
                current.Tax = item.Tax;
                output.Add(current);
            }

            return output;
        }

        public async Task<PostOutput> PostApDrCrHd(PostDto postDto)
        {
            if (AbpSession.UserId.HasValue) { postDto.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoForStored.Execute(postDto, "ApDrCrHdPost");

            return postResult.FirstOrDefault();
        }
    }
}
