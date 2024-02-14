using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ArInvoiceHd.Dto;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__PmPropertiesModule._ArInvoiceHd.Proc;
using ERP._System.__PmPropertiesModule._ArInvoiceHd.ProcDto;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System._ArInvoiceHd.Dto;
using ERP._System._ArInvoiceTr.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._ArInvoiceHd
{
    [AbpAuthorize]
    public class ArInvoiceHdAppService : AsyncCrudAppService<ArInvoiceHd, ArInvoiceHdDto, long, PagedArInvoiceHdResultRequestDto, CreateArInvoiceHdDto, ArInvoiceHdEditDto>,
        IArInvoiceHdAppService
    {
        private readonly IRepository<ArInvoiceTr, long> _repoArInvoiceTr;
        private readonly IArInvoiceHdRepository _repoForStored;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IGetArInvoiceHdScreenDataRepository _getArInvoiceHdScreenDataRepository;
        private readonly IArInvoiceHdManager _arInvoiceHdManager;

        public ArInvoiceHdAppService(IRepository<ArInvoiceHd, long> repository,
            IGetArInvoiceHdScreenDataRepository getArInvoiceHdScreenDataRepository,
            IGlCodeComDetailsManager glCodeComDetailsManager
            , IGetCounterRepository repoProcCounter
            , IArInvoiceHdManager arInvoiceHdManager
            , IRepository<ArInvoiceTr, long> repoArInvoiceTr, IArInvoiceHdRepository repoPost) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _getArInvoiceHdScreenDataRepository = getArInvoiceHdScreenDataRepository;
            _repoArInvoiceTr = repoArInvoiceTr;
            _repoForStored = repoPost;
            _repoProcCounter = repoProcCounter;
            _arInvoiceHdManager = arInvoiceHdManager;

            CreatePermissionName = PermissionNames.Pages_ArInvoiceHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArInvoiceHd_Update;
            DeletePermissionName = PermissionNames.Pages_ArInvoiceHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArInvoiceHd;
        }

        public async override Task<PagedResultDto<ArInvoiceHdDto>> GetAll(PagedArInvoiceHdResultRequestDto input)
        {
            var queryable = Repository.GetAllIncluding(x => x.FndLookupValuesArInvoiceHdStatusLkp, x => x.FndLookupValuesArInvoiceHdSourceLkp, x => x.Currency, x => x.ArCustomers, x => x.ArInvoiceTr);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdInvoiceNo))
                queryable = queryable.Where(q => q.HdInvoiceNo.Contains(input.Params.HdInvoiceNo));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdDate))
                queryable = queryable.Where(q => q.HdDate == DateTimeController.ConvertToDateTime(input.Params.HdDate));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.ArCustomerId != null)
                queryable = queryable.Where(q => q.ArCustomerId == input.Params.ArCustomerId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArInvoiceHdDto>());

            var PagedResultDto = new PagedResultDto<ArInvoiceHdDto>()
            {
                Items = data2 as IReadOnlyList<ArInvoiceHdDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<ArInvoiceHdDto> Create(CreateArInvoiceHdDto input)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ArInvoiceHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.HdInvoiceNo = result?.FirstOrDefault()?.OutputStr ?? string.Empty;

            var current = await base.Create(input);

            foreach (var item in input.ArInvoiceTrList)
            {
                var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);

                item.AccountId = currentComCodeId;
                item.ArInvoiceHdId = current.Id;

                await _repoArInvoiceTr.InsertAsync(ObjectMapper.Map<ArInvoiceTr>(item));
            }

            return new ArInvoiceHdDto();
        }

        public async Task<ArInvoiceHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndLookupValuesArInvoiceHdStatusLkp,
                                       v => v.FndLookupValuesArInvoiceHdSourceLkp, vv => vv.Currency,
                                       vv => vv.ArCustomers, vv => vv.ArInvoiceTr).Where(z => z.Id == input.Id)
                                   .FirstOrDefaultAsync();

            return ObjectMapper.Map<ArInvoiceHdDto>(current);
        }

        public async Task<ArInvoiceHdDto> GetDetailBySourceId(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndLookupValuesArInvoiceHdStatusLkp,
                                       v => v.FndLookupValuesArInvoiceHdSourceLkp, vv => vv.Currency,
                                       vv => vv.ArCustomers, vv => vv.ArInvoiceTr).Where(z => z.SourceId == input.Id)
                                   .FirstOrDefaultAsync();

            return ObjectMapper.Map<ArInvoiceHdDto>(current);
        }

        public async Task<List<ArInvoiceTrDto>> GetAllArInvoiceHdDetails(long gljeheaderId)
        {
            var output = new List<ArInvoiceTrDto>();

            var gljeLines = await _repoArInvoiceTr
                .GetAllIncluding(x => x.GlCodeComDetails,
                x => x.ArInvoiceHd).Where(x => x.ArInvoiceHdId == gljeheaderId).ToListAsync();
         
            foreach (var item in gljeLines)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);

                var current = new ArInvoiceTrDto();

                current.Id = item.Id;
                current.Amount = item.Amount;
                current.Description = item.Description;
                current.codeComUtilityIds = ids;
                current.codeComUtilityTexts = texts;
                current.TaxPercent = item.TaxPercent;
                current.ArInvoiceHdId = item.ArInvoiceHdId;
                current.rowStatus = DetailRowStatus.RowStatus.NoAction.ToString();

                output.Add(current);
            }

            return output;
        }

        public async override Task<ArInvoiceHdDto> Update(ArInvoiceHdEditDto input)
        {
            await base.Update(input);

            foreach (var item in input.ArInvoiceTrList)
            {
                if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                {
                    var currentGeJeLine = await _repoArInvoiceTr.GetAsync((long)item.Id);
                    var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);

                    var mappedDto = ObjectMapper.Map(currentGeJeLine, new ArInvoiceTrDto());

                    mappedDto.AccountId = (long)currentComCodeId;
                    mappedDto.Amount = item.Amount;
                    mappedDto.Description = item.Description;
                    mappedDto.TaxPercent = item.TaxPercent;

                    var mappedEntity = ObjectMapper.Map(mappedDto, currentGeJeLine);

                    _ = await _repoArInvoiceTr.UpdateAsync(mappedEntity);
                }
                else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                {
                    var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                  
                    item.ArInvoiceHdId = input.Id;
                    item.AccountId = currentComCodeId;
                 
                    _ = await _repoArInvoiceTr.InsertAsync(ObjectMapper.Map<ArInvoiceTr>(item));
                }
                else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                {
                    await _repoArInvoiceTr.DeleteAsync((long)item.Id);
                }
            }

            return new ArInvoiceHdDto { };
        }

        public async Task<PostOutput> PostArInvoice(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoForStored.Execute(input, "ArPostInvoice");

            return postResult.FirstOrDefault();
        }

        public async Task<IReadOnlyList<ArInvoiceHdScreenDataOutput>> GetArInvoiceHdScreenData(IdLangInputDto input)
        {
            var result = await _getArInvoiceHdScreenDataRepository.Execute(input, "GetArInvoiceHdScreenData");

            return result.ToList();
        }
        public async Task<Select2PagedResult> GetArInvoiceHd_ArInvoiceTr_NumSelect2(string searchTerm, long ArCustomerId, int pageSize, int pageNumber, string lang)
                 => await _arInvoiceHdManager.GetArInvoiceHd_ArInvoiceTr_NumSelect2(searchTerm, ArCustomerId, pageSize, pageNumber, lang);
    }
}
