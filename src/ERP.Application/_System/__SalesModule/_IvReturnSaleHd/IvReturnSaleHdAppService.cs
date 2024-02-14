using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScCampains.Procs;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._HrPersonsDeduction.Dto;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses.__IvInventorySetting.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP.Authorization.Users;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP.Core.Helpers.Extensions;
using ERP._System.__Warehouses._IvWarehouseItems;
using ERP._System.__SalesModule._IvSaleHd.Proc;
using ERP._System.__SalesModule._IvSaleHd.ProcDto;
using ERP._System.__SalesModule._IvReturnSaleHd.Dto;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System.__SalesModule._IvReturnSaleHd.Proc;
using ERP._System._FndTaxType;
using Newtonsoft.Json;

namespace ERP._System.__SalesModule._IvReturnSaleHd
{
    [AbpAuthorize]
    public class IvReturnSaleHdAppService : AsyncCrudAppService<IvReturnSaleHd, IvReturnSaleHdDto, long, IvReturnSaleHdPagedDto, IvReturnSaleHdCreateDto, IvReturnSaleHdEditDto>, IIvReturnSaleHdAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<IvReturnSaleTr, long> _repoIvReturnSaleTr;
        private readonly IRepository<IvSaleTr, long> _repoIvSaleTr;
        private readonly IRepository<IvItems, long> _repoIvItems;
        private readonly IRepository<FndTaxType, long> _repoFndTaxType;
        private readonly IRepository<IvSaleHd, long> _repoIvSaleHd;
        private readonly IRepository<IvPriceListHd, long> _repoIvPriceListHd;
        private readonly IRepository<IvPriceListTr, long> _repoIvPriceListTr;



        private readonly IIvReturnSaleHdPostRepository _ivReturnSaleHdPostRepository;
        private readonly IGetSalesScreenDataRepository _repoSalesScreen;



        public IvReturnSaleHdAppService(IRepository<IvReturnSaleHd, long> repository,
             IRepository<IvReturnSaleTr, long> repoIvReturnSaleTr,
             IGetCounterRepository getCounterRepository,
             IIvReturnSaleHdPostRepository ivReturnSaleHdPostRepository,
             IRepository<FndTaxType, long> repoFndTaxType,
             IRepository<IvSaleTr, long> repoIvSaleTr,
             IRepository<IvItems, long> repoIvItems,
             IRepository<IvSaleHd, long> repoIvSaleHd,
             IRepository<IvPriceListHd, long> repoIvPriceListHd,
             IRepository<IvPriceListTr, long> repoIvPriceListTr,
             IGetSalesScreenDataRepository repoSalesScreen) : base(repository)
        {

            _ivReturnSaleHdPostRepository = ivReturnSaleHdPostRepository;
            _repoProcCounter = getCounterRepository;
            _repoIvReturnSaleTr = repoIvReturnSaleTr;
            _repoIvSaleTr = repoIvSaleTr;
            _repoIvItems = repoIvItems;
            _repoIvSaleHd = repoIvSaleHd;
            _repoIvPriceListHd = repoIvPriceListHd;
            _repoIvPriceListTr = repoIvPriceListTr;
            _repoFndTaxType = repoFndTaxType;


            CreatePermissionName = PermissionNames.Pages_IvReturnSaleHd_Insert;
            GetAllPermissionName = PermissionNames.Pages_IvReturnSaleHd;
        }

        public override async Task<PagedResultDto<IvReturnSaleHdDto>> GetAll(IvReturnSaleHdPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.IvSaleHd, x => x.Currency, x => x.FndLookupStatusLkp, x => x.IvReturnSaleTrs,x=>x.IvSaleHd.ArCustomers,x=>x.IvSaleHd.IvWarehouses);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IvReturnSaleNumber))
                iqueryable = iqueryable.Where(z => z.IvReturnSaleNumber.Contains(input.Params.IvReturnSaleNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IvReturnSaleDate))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.IvReturnSaleDate);
                iqueryable = iqueryable.Where(z => z.IvReturnSaleDate == dt);
            }
            if (input.Params != null && input.Params.IvSaleHdId != 0)
                iqueryable = iqueryable.Where(z => z.IvSaleHdId == input.Params.IvSaleHdId);

            //if (input.Params != null && !string.IsNullOrEmpty(input.Params.LpoNo))
            //    iqueryable = iqueryable.Where(z => z.LpoNo.Contains(input.Params.LpoNo));

            //if (input.Params != null && input.Params.ArCustomerId != 0)
            //    iqueryable = iqueryable.Where(z => z.ArCustomerId == input.Params.ArCustomerId);


            if (input.Params != null && input.Params.StatusLkpId != 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);


            var count = await iqueryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            iqueryable = iqueryable.DynamicOrderBy(listOrder);
            iqueryable = iqueryable.Skip(input.SkipCount);
            var data = await iqueryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<IvReturnSaleHdDto>());
            foreach (var item in data2)
            {
                //(Qty*unitprice)+taxamount
                item.Amount = item.IvReturnSaleTrdetails?.Sum(x => (x.RQty * x.UnitPrice + x.TaxAmount))??0;
            }
            var PagedResultDto = new PagedResultDto<IvReturnSaleHdDto>()
            {
                Items = data2 as IReadOnlyList<IvReturnSaleHdDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public  override async Task<IvReturnSaleHdDto> Create(IvReturnSaleHdCreateDto input)
        {
            try
            {
                CheckCreatePermission();
                input.IvReturnSaleNumber = await GetReturnSaleNumber();
                var IvReturnSaleHdList = ObjectMapper.Map<IvReturnSaleHd>(input);

                _ = await Repository.InsertAsync(IvReturnSaleHdList);


                if (input.IvReturnSaleTrdetails != null && input.IvReturnSaleTrdetails.Count > 0)
                    foreach (var item in input.IvReturnSaleTrdetails)
                        await InsertReturnSalesListData(item, IvReturnSaleHdList.Id);

                return new IvReturnSaleHdDto { };

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task InsertReturnSalesListData(IvReturnSaleTrDto IvReturnSaleTrListDto, long masterId)
        {
            try
            {
                IvReturnSaleTrListDto.IvReturnSaleHdId = masterId;
                var IvReturnSaleList = ObjectMapper.Map<IvReturnSaleTr>(IvReturnSaleTrListDto);

                _ = await _repoIvReturnSaleTr.InsertAsync(IvReturnSaleList);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        private async Task<string> GetReturnSaleNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "IvReturnSaleHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

        public async Task<PostOutput> PostReturnSale(PostDto postDto)
        {
            try
            {
                long saleid = Repository.GetAll().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
                var saleHd = new PostDto()
                {
                    Id = saleid,
                    UserId = AbpSession.UserId ?? 0,
                    Lang = _app.Reqlanguage
                };
                var result = await _ivReturnSaleHdPostRepository.Execute(saleHd, "IvReturnSaleHdPost");

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<IvReturnSaleTrDto>> GetAllReturnSaleslistDetails(EntityDto<long> input)
        {
            var listData = await _repoIvReturnSaleTr.GetAllIncluding(x=>x.IvSaleTr,x=>x.IvSaleTr.IvItems)
                               .Where(d => d.IvReturnSaleHdId == input.Id).ToListAsync();

            var listDto = ObjectMapper.Map<List<IvReturnSaleTrDto>>(listData);
            foreach (var item in listDto)
            {
                item.ItemName = item.IvSaleTr.IvItems.ItemName;
                item.IvItemId = item.IvSaleTr.IvItemId;
                //(Qty*unitprice)+taxamount
                item.totbeforetax = item.RQty * item.UnitPrice;
                item.Totalamount = item.totbeforetax + item.TaxAmount;
            }

            return listDto;

        }
        public async Task<IvReturnSaleTrDto> GetItemDatasaledetails(long Id, long IvSaleHdId)
        {
            var result = (from a in _repoIvSaleTr.GetAll()
                          join pg in _repoIvSaleHd.GetAll() 
                          on a.IvSaleHdId equals pg.Id into pgs
                          from m in pgs.DefaultIfEmpty()
                          join rs in _repoIvReturnSaleTr.GetAll() 
                          on a.Id equals rs.IvSaleTrId into drocs
                          from drocst in drocs.DefaultIfEmpty()
                          join rs in _repoIvItems.GetAll()
                          on a.IvItemId equals rs.Id into droc
                          from dro in droc.DefaultIfEmpty()
                          join rss in _repoFndTaxType.GetAll()
                          on a.FndTaxtypeId equals rss.Id into drocss
                          from dros in drocss.DefaultIfEmpty()
                          where a.IvSaleHdId== IvSaleHdId && a.IvItemId==Id
                          select new IvReturnSaleTrDto
                          {
                            Id = a.IvItemId,
                            UnitPrice=a.UnitPrice,
                            IvSaleTrId=a.Id,
                            AvailableQty = a.Qty,
                            TrCost=a.TrCost,
                            FndTaxtypeId=dro.FndTaxtypeId.Value,
                            Percentage= dros.Percentage

                          }).AsQueryable().FirstOrDefault();
            var sumQty = _repoIvReturnSaleTr.GetAll().Where(x => x.IvSaleTrId == result.IvSaleTrId).Sum(x => x.RQty);
            result.AvailableQty = result.AvailableQty - sumQty;
            
            var listDto = ObjectMapper.Map<IvReturnSaleTrDto>(result);


            return listDto;

        }

        //public async Task<IvReturnSaleHdDto> GetDetailAsync(EntityDto<long> input)
        //{
        //    var ivsaleDetails = await Repository.GetAllIncluding(x => x.FndLookupStatusLkp, x => x.Currency, x => x.Currency, x => x.IvSaleHd, x => x.IvReturnSaleTrs)
        //                                            .Where(z => z.Id == input.Id).FirstOrDefaultAsync();
        //    var IvSaleTrId = ivsaleDetails.IvReturnSaleTrs.Select(x => x.IvSaleTrId).FirstOrDefault();
        //    var items = _repoIvSaleTr.FirstOrDefault(x => x.Id == IvSaleTrId);
        //    var ivsaleDetailsDto = ObjectMapper.Map<IvReturnSaleHdDto>(ivsaleDetails);
        //    ivsaleDetailsDto.IvReturnSaleTrdetails.FirstOrDefault().IvItemId = items.IvItemId;
        //    return ivsaleDetailsDto;
        //}




        public async Task<Select2PagedResult> GetReturnSale_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
        {

            var data = await Repository.GetAll().Include(x => x.IvSaleHd)
                                                .Where(z => z.StatusLkpId == 31625 && z.IvSaleHd.ArCustomerId == ArCustomerId)
                                                .GroupBy(x => new { x.IvReturnSaleNumber, x.IvReturnSaleDate, x.Id })
                                    .Select(x => new { Id = x.Key.Id, ReturnSaleNumber = x.Key.IvReturnSaleNumber, Date = x.Key.IvReturnSaleDate.Date.ToString(), Amount = x.Sum(s => s.IvReturnSaleTrs.Sum(m=>m.UnitPrice*m.RQty+m.TaxAmount)) }) //, 
                                    .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.ReturnSaleNumber, altText = JsonConvert.SerializeObject(z) }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
        //public async Task<Select2PagedResult> GetReturnSale_ReceiptsOnAccount_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
        //{
        //    var data = await _arReceiptsOnAccountRepository.GetAll().Include(x => x.ArReceipts)
        //                                        .Where(z => z.ArReceipts.StatusLkpId == 279 && z.ArReceipts.ArCustomerId == ArCustomerId
        //                                        && !_repoArInvoiceSettlementCr.GetAll().Select(q => q.SourceId).Contains(z.ArReceipts.Id))
        //                                        .GroupBy(x => new { x.ArReceipts.ReceiptNumber, x.ArReceipts.ReceiptDate, x.ArReceipts.Id })
        //                            .Select(x => new { Id = x.Key.Id, ReceiptNumber = x.Key.ReceiptNumber, Date = x.Key.ReceiptDate.Date.ToString(), Amount = x.Sum(s => s.Amount) }) //, 
        //                            .ToListAsync();

        //    var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.ReceiptNumber, altText = JsonConvert.SerializeObject(z) }).ToList();

        //    var select2pagedResult = new Select2PagedResult
        //    {
        //        Total = data.Count(),
        //        Results = result
        //    };

        //    return select2pagedResult;
        //}

        public async Task<IvReturnSaleHdDto> GetDetailAsync(EntityDto<long> input)
        { 
            var data = ObjectMapper.Map<IvReturnSaleHdDto>(await Repository.GetAllIncluding(x => x.FndLookupStatusLkp, x => x.Currency, x => x.Currency, x => x.IvSaleHd, x => x.IvSaleHd.FndLookupPaymentMethodLkp, x => x.IvReturnSaleTrs)
                                                    .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

            data.PaymentMethodLkpId = data.IvSaleHd.PaymentMethodLkpId;
            data.FndLookupPaymentMethodLkp = data.IvSaleHd.FndLookupPaymentMethodLkp;

            data.BankAccountId = data.IvSaleHd.BankAccountId;
            data.ApBankAccounts = data.IvSaleHd.ApBankAccounts;
            return data;
        }
       


    }
}
