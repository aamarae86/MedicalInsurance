using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System._ApVendors;
using ERP._System._ArCustomers;
using ERP._System._ItemMovementsReport.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ItemMovementsReport
{
    public class ItemMovementsAppService : ERPAppServiceBase, IItemMovementsAppService
    {
        private readonly IRepository<IvSaleTr, long> _ivSaleHd;
        private readonly IRepository<IvReceiveTr, long> _ivReceive; 
        private readonly IRepository<ArCustomers, long> _customers;
        private readonly IRepository<ApVendors, long> _vendors;
        private readonly IItemMovementReportRepository _itemReportRepository;
        private readonly IItemStockReportRepository _itemStockReportRepository;
        

        public ItemMovementsAppService(IRepository<IvSaleTr, long> ivSaleHd,
            IRepository<IvReceiveTr, long> ivReceive,
            IRepository<ArCustomers, long> customers,
            IItemMovementReportRepository itemReportRepository,
             IItemStockReportRepository itemStockReportRepository,
            IRepository<ApVendors, long> vendors)
        {
            _ivReceive= ivReceive;
            _ivSaleHd= ivSaleHd;
            _customers= customers;
            _vendors= vendors;
            _itemReportRepository = itemReportRepository;
            _itemStockReportRepository= itemStockReportRepository;
        }

        public async Task<PagedResultDto<ItemMovementDto>> GetItemMovements(ItemMovementPagedDto input)
        {
            dynamic MyDynamic = new System.Dynamic.ExpandoObject();
            MyDynamic.TenantId = AbpSession.TenantId.Value;
            MyDynamic.FromDate = input.Params.FromDate;
            MyDynamic.ToDate = input.Params.ToDate;
            MyDynamic.IvWarehouseId = input.Params.IvWarehouseId;
            MyDynamic.TrItemId = input.Params.IvItemId;
            MyDynamic.Lang = "en";

            var mapped = ObjectMapper.Map<ItemMovementInput>(MyDynamic);

            if (!string.IsNullOrEmpty(input.Params.ToDate)) mapped.ToDate = DateTimeController.ConvertToDateTime(input.Params.ToDate);
            if (!string.IsNullOrEmpty(input.Params.FromDate)) mapped.FromDate = DateTimeController.ConvertToDateTime(input.Params.FromDate);

            try {

                var result = await _itemReportRepository.Execute(mapped, "rptIvItemMovement");
                List<GetItemMovementDataOutput> listItems= new List<GetItemMovementDataOutput>();
                foreach (var item in result)
                {
                    listItems.Add((GetItemMovementDataOutput)item);
                }
                listItems = listItems.OrderBy(x => x.HdDate).ToList();
                decimal cBalance = 0;
                List<ItemMovementDto> items = new List<ItemMovementDto>();
                string typeStr = "";
                foreach (var item in listItems)
                {
                    ItemMovementDto obj = new ItemMovementDto()
                    {
                        Id=CipherStringController.Encrypt(item.HdInvId.ToString()),
                        Date = item.HdDate!=null? item.HdDate.Value.ToString("MM/dd/yyyy HH:mm"):"",
                        Customer = item.CustVend,
                        QtyIn = item.TRQTYSIN,
                        QtyOut = item.TrQtysOut,
                        TranType = item.TranType,
                        Balance = cBalance + item.TRQTYSIN - item.TrQtysOut,
                        InvNo=item.HdInno,
                        TotalAmount=item.TotalAmount

                    };
                    cBalance = obj.Balance;
                    items.Add(obj);
                }
                //var list = result.ToList<GetItemMovementDataOutput>();

                var count = items.Count();

                var PagedResultDto = new PagedResultDto<ItemMovementDto>()
                {
                    Items = items as IReadOnlyList<ItemMovementDto>,
                    TotalCount = count
                };

                return PagedResultDto;
                //return items;
            }
            catch (Exception ex)
            {
                return null;
                //return new List<ItemMovementDto>();
            
            }
           
        }

        public async Task<PagedResultDto<dynamic>> GetItemStock(ItemStockPagedDto input)
        {
            dynamic MyDynamic = new System.Dynamic.ExpandoObject();
            MyDynamic.TenantId = AbpSession.TenantId.Value;
            MyDynamic.ShowZero = input.Params.ShowZero;
           
            MyDynamic.IvWarehouseId = input.Params.IvWarehouseId;
            MyDynamic.ItemId = input.Params.ItemId;
            MyDynamic.Lang = "en";

            var mapped = ObjectMapper.Map<ItemStockInput>(MyDynamic);

            try
            {
                var result = await _itemStockReportRepository.Execute(mapped, "rptIvItemStock");
                List<GetItemStockDataOutput> listItems = new List<GetItemStockDataOutput>();
                foreach (var item in result)
                {
                    listItems.Add((GetItemStockDataOutput)item);
                }
               
                decimal cBalance = 0;
               
               

                var PagedResultDto = new PagedResultDto<dynamic>()
                {
                    Items = listItems as IReadOnlyList<dynamic>,
                    TotalCount = listItems.Count
                };

                return PagedResultDto;
                //return items;
            }
            catch (Exception ex)
            {
                return null;
                //return new List<ItemMovementDto>();

            }

        }

        public async Task<PagedResultDto<ItemMovementDto>> GetItemsMovementsReport(ItemMovementPagedDto obj)
        {

            var recItems = _ivReceive.GetAllIncluding(x=>x.IvReceiveHd).Where(x =>x.IvItemId== obj.Params.IvItemId).ToList();
            var saleItems= _ivSaleHd.GetAllIncluding(x=>x.IvSaleHd).Where(x => x.IvItemId == obj.Params.IvItemId).ToList();

            var customers = _customers.GetAll();
            var vendor = _vendors.GetAll();

            List<ItemMovementDto> items = new List<ItemMovementDto>();
            foreach (var item in recItems)
            {
                items.Add(new ItemMovementDto()
                {
                    QtyIn = item.Qty,
                    QtyOut = 0,
                    Customer = vendor.FirstOrDefault(x=>x.Id==item.IvReceiveHd.VendorId).VendorNameEn,
                    TranType ="RCVD",
                    InvNo=item.IvReceiveHd.HdReceiveNumber.ToString(),
                    Date =item.CreationTime+"",
                    Balance = 0
                }) ;
            }

            foreach (var item in saleItems)
            {
                items.Add(new ItemMovementDto()
                {
                    QtyOut = item.Qty,
                    QtyIn = 0,
                    Customer = customers.FirstOrDefault(x=>x.Id==item.IvSaleHd.ArCustomerId).CustomerNameEn,
                    TranType = "SALS",
                    InvNo = item.IvSaleHd.IvSaleNumber.ToString(),
                    Date = item.CreationTime+"",
                    Balance=0
                });
            }

            items = items.OrderBy(x => x.Date).ToList();
            var cBalance = 0;
            foreach (var item in items)
            {
                item.Balance = cBalance + item.QtyIn - item.QtyOut;
            }
            var count =  items.Count();

            var PagedResultDto = new PagedResultDto<ItemMovementDto>()
            {
                Items = items as IReadOnlyList<ItemMovementDto>,
                TotalCount = count
            };

            return PagedResultDto;

            
        }

        //public async Task<IReadOnlyList<GetApPdcInterfaceDataOutput>> GetData(ItemMovementPagedDto input)
        //{

        //    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
        //    MyDynamic.TenantId = AbpSession.TenantId.Value;
        //    MyDynamic.FromDate = input.Params.FromDate;
        //    MyDynamic.ToDate = input.Params.ToDate;
        //    MyDynamic.IvWarehouseId = input.Params.IvWarehouseId;
        //    MyDynamic.TrItemId = input.Params.IvItemId;
        //    MyDynamic.Lang = "en";

        //    var mapped = ObjectMapper.Map<GetApPdcInterfaceDataInput>(input);

        //    mapped.TenantId = AbpSession.TenantId.Value;

        //    var result = await _getApPdcInterfaceDataRepository.Execute(mapped, "GetApPdcInterfaceData");

        //    return result.ToList();
        //}

       
    }
}
