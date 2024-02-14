using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System._VendorItemsReport.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._VendorItemsReport
{
    public class VendorItemsAppService : ERPAppServiceBase, IVendorItemsAppService
    {
        private readonly IVendorItemReportRepository _itemReportRepository;

        public VendorItemsAppService(IVendorItemReportRepository itemReportRepository)
        {
            _itemReportRepository = itemReportRepository;
        }

        public async Task<PagedResultDto<VendorItemDto>> GetItemMovementsForVendor(VendorItemPagedDto input)
        {
            string fromDate = "";
            if (!string.IsNullOrEmpty(input.Params.FromDate))
            {
                var newFromDateArr = input.Params.FromDate.Split('/');
                fromDate = newFromDateArr[1] + '-' + newFromDateArr[0] + '-' + newFromDateArr[2];
            }
            string toDate = "";
            if (!string.IsNullOrEmpty(input.Params.ToDate))
            {
                var newToDateArr = input.Params.ToDate.Split('/');
                toDate = newToDateArr[1] + '-' + newToDateArr[0] + '-' + newToDateArr[2];
            }

            dynamic MyDynamic = new System.Dynamic.ExpandoObject();
            MyDynamic.TenantId = AbpSession.TenantId.Value;
            MyDynamic.FromDate = fromDate;//input.Params.FromDate;
            MyDynamic.ToDate = toDate;//input.Params.ToDate;

            MyDynamic.IsNotSettled = input.Params.IsNotSettled;
            MyDynamic.VendorId = input.Params.VendorId;
            MyDynamic.Lang = "en";



            var mapped = ObjectMapper.Map<VendorItemReportInput>(MyDynamic);

            

            //if (!string.IsNullOrEmpty(input.Params.ToDate)) mapped.ToDate = DateTimeController.ConvertToDateTime(input.Params.ToDate);
            //if (!string.IsNullOrEmpty(input.Params.FromDate)) mapped.FromDate = DateTimeController.ConvertToDateTime(input.Params.FromDate);

            try
            {

                var result = await _itemReportRepository.Execute(mapped, "rptApDebitCredit");
                List<GetVendorItemReportDataOutput> listItems = new List<GetVendorItemReportDataOutput>();
                foreach (var item in result)
                {
                    listItems.Add((GetVendorItemReportDataOutput)item);
                }
                listItems = listItems.OrderBy(x => x.DocDate).ToList();
                decimal cBalance = 0;
                List<VendorItemDto> items = new List<VendorItemDto>();
                foreach (var item in listItems)
                {
                    VendorItemDto obj = new VendorItemDto()
                    {
                        DocDate = item.HdDate != null ? item.HdDate.Value.ToString("dd/MM/yyyy") : "",
                        Address = item.Address,
                        Comments = item.Comments,
                        CrAmount = item.CrAmount,
                        DrAmount = item.DrAmount,
                        Fax = item.Fax,
                        Source = item.Source,
                        tel = item.tel,
                        VendorId = item.VendorId,
                        VendorNameAr = item.VendorNameAr,
                        VendorNumber = item.VendorNumber,
                        SourceId = CipherStringController.Encrypt(item.SourceId.ToString()),
                        SourceType = item.SourceType,

                    Balance = cBalance + item.DrAmount - item.CrAmount,

                         

                    };
                    cBalance = obj.Balance;
                    items.Add(obj);
                }
                //var list = result.ToList<GetItemMovementDataOutput>();

                var count = items.Count();

                var PagedResultDto = new PagedResultDto<VendorItemDto>()
                {
                    Items = items as IReadOnlyList<VendorItemDto>,
                    TotalCount = count
                };

                return PagedResultDto;
                //return items;
            }
            catch (Exception ex)
            {
                return null;               
            }

        }

        
    }
}
