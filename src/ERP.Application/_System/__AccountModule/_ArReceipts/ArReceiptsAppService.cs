using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ArReceipts.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ArReceipts
{
    public class ArReceiptsAppService : AsyncCrudAppService<ArReceipts, ArReceiptsDto, long, PagedArReceiptsResultRequestDto, ArReceiptsCreateDto, ArReceiptsEditDto>,
        IArReceiptsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<ArReceiptDetails, long> _repoDetail;
        private readonly IRepository<ArReceiptsOnAccount, long> _repoOnAccount;
        private readonly IArReceiptsRepository _repoForStored;
        private readonly IGetReceiptScreenDataRepository _getReceiptScreenDataRepository;
        private readonly IArReceiptsManager _arReceiptsManager;

        public ArReceiptsAppService(IGetCounterRepository repoProcCounter, IArReceiptsRepository repoForStored,
                        IRepository<ArReceipts, long> repository, IRepository<ArReceiptDetails, long> repoDetail,
                       IGetReceiptScreenDataRepository getReceiptScreenDataRepository,
                       IArReceiptsManager arReceiptsManager,
                        IRepository<ArReceiptsOnAccount, long> repoOnAccount) : base(repository)
        {
            _getReceiptScreenDataRepository = getReceiptScreenDataRepository;
            _repoProcCounter = repoProcCounter;
            _repoForStored = repoForStored;
            _repoDetail = repoDetail;
            _repoOnAccount = repoOnAccount;
            _arReceiptsManager = arReceiptsManager;
        }

        public async override Task<ArReceiptsDto> Create(ArReceiptsCreateDto input)
        {
            CheckCreatePermission();

            input.ReceiptNumber = await GetReceiptNumber();

            var current = await base.Create(input);

            if (input.ListReceiptDetails.Count > 0)
            {
                foreach (var item in input.ListReceiptDetails)
                {
                    item.ReceiptId = current.Id;

                    _ = await _repoDetail.InsertAsync(ObjectMapper.Map<ArReceiptDetails>(item));
                }
            }

            if (input.ListReceiptsOnAccount.Count > 0)
            {
                foreach (var item in input.ListReceiptsOnAccount)
                {
                    item.ReceiptId = current.Id;

                    _ = await _repoOnAccount.InsertAsync(ObjectMapper.Map<ArReceiptsOnAccount>(item));
                }
            }

            return new ArReceiptsDto();
        }

        public async override Task<ArReceiptsDto> Update(ArReceiptsEditDto input)
        {
            CheckUpdatePermission();

            await base.Update(input);

            if (input.ListReceiptDetails.Count > 0)
            {
                foreach (var item in input.ListReceiptDetails)
                {
                    item.ReceiptId = input.Id;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var ArReceiptDetails = await _repoDetail.GetAsync(item.Id);

                        ObjectMapper.Map(item, ArReceiptDetails);

                        _ = await _repoDetail.UpdateAsync(ArReceiptDetails);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.ReceiptId = input.Id;

                        _ = await _repoDetail.InsertAsync(ObjectMapper.Map<ArReceiptDetails>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoDetail.DeleteAsync((long)item.Id);
                    }
                }
            }

            if (input.ListReceiptsOnAccount.Count > 0)
            {
                foreach (var item in input.ListReceiptsOnAccount)
                {
                    item.ReceiptId = input.Id;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var ArReceiptOnAccount = await _repoOnAccount.GetAsync(item.Id);

                        ObjectMapper.Map(item, ArReceiptOnAccount);

                        _ = await _repoOnAccount.UpdateAsync(ArReceiptOnAccount);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.ReceiptId = input.Id;

                        _ = await _repoOnAccount.InsertAsync(ObjectMapper.Map<ArReceiptsOnAccount>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoOnAccount.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new ArReceiptsDto();
        }

        public async Task<ArReceiptsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll().Include(z => z.FndStatusLkp)
                .Include(z => z.ArCustomer).Include(z => z.BankAccount)
                .Include(z => z.Currency)
                .Include(z => z.RemitanceBank)
                .Include(z => z.ArReceiptDetails).ThenInclude(z => z.Bank)
                .Include(z => z.ArReceiptsOnAccount).ThenInclude(z => z.FndReceiptTypeLkp)

                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<ArReceiptsDto>(current);
        }

        public async override Task<PagedResultDto<ArReceiptsDto>> GetAll(PagedArReceiptsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(o => o.FndStatusLkp, o => o.ArCustomer, o => o.ArReceiptDetails, o => o.BankAccount, o => o.Currency, o => o.RemitanceBank, o => o.ArReceiptsOnAccount);

            if (input.Params.ArCustomerId.HasValue)
                queryable = queryable.Where(o => o.ArCustomerId == input.Params.ArCustomerId.Value);

            if (input.Params.CurrencyId.HasValue)
                queryable = queryable.Where(o => o.CurrencyId == input.Params.CurrencyId.Value);

            if (input.Params.StatusLkpId.HasValue)
                queryable = queryable.Where(o => o.StatusLkpId == input.Params.StatusLkpId.Value);

            if (!string.IsNullOrEmpty(input.Params.ReceiptNumber))
                queryable = queryable.Where(o => o.ReceiptNumber == input.Params.ReceiptNumber);

            if (!string.IsNullOrEmpty(input.Params.ReceiptDateFrom))
            {
                var dateFrom = DateTimeController.ConvertToDateTime(input.Params.ReceiptDateFrom);
                queryable = queryable.Where(o => o.ReceiptDate >= dateFrom);
            }

            if (!string.IsNullOrEmpty(input.Params.ReceiptDateTo))
            {
                var dateTo = DateTimeController.ConvertToDateTime(input.Params.ReceiptDateTo);
                queryable = queryable.Where(o => o.ReceiptDate <= dateTo);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArReceiptsDto>());

            var PagedResultDto = new PagedResultDto<ArReceiptsDto>()
            {
                Items = data2 as IReadOnlyList<ArReceiptsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public override Task Delete(EntityDto<long> input)
        {
            _repoDetail.Delete(d => d.ReceiptId == input.Id);
            _repoOnAccount.Delete(d => d.ReceiptId == input.Id);

            return base.Delete(input);
        }

        public async Task<PostOutput> PostArReceipt(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoForStored.Execute(input, "ArPostReceipt");

            return postResult.FirstOrDefault();
        }

        public async Task<List<receipttScreenDataOutput>> GetreceipttScreenData(IdLangInputDto input)
        {
            var postResult = await _getReceiptScreenDataRepository.Execute(input, "GetreceipttScreenData");

            return postResult.ToList();
        }

        private async Task<string> GetReceiptNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ArReceipts", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result.FirstOrDefault().OutputStr;
        }

        public async Task<Select2PagedResult> GetArReceipts_ReceiptsOnAccount_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
                  => await _arReceiptsManager.GetArReceipts_ReceiptsOnAccount_NumSelect2(ArCustomerId, pageSize, pageNumber, lang);
    }
}
