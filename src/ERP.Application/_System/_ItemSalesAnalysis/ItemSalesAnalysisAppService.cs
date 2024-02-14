using Abp.Application.Services.Dto;
using ERP._System.__SalesModule._ItemSalesAnalysis.Proc;
using ERP._System.__SalesModule._ItemSalesAnalysis.ProcDto;
using ERP._System._ItemSalesAnalysis.Dto;
using ERP._System._ItemSalesMonthlyAnalysis.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ItemSalesAnalysis
{
   public class ItemSalesAnalysisAppService : ERPAppServiceBase, IItemSalesAnalysisAppService
    {
        private readonly IItemSalesAnalysisReportRepository _itemSalesAnalysisReportRepository;


        public ItemSalesAnalysisAppService(
             IItemSalesAnalysisReportRepository itemSalesAnalysisReportRepository
             )
        {

            _itemSalesAnalysisReportRepository = itemSalesAnalysisReportRepository;
        }


    

        public async Task<PagedResultDto<ItemSalesAnalysisDto>> GetItemSalesAnalysis(ItemSalesAnalysisPagedDto input)
        {
            try
            {
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.TenantId = AbpSession.TenantId.Value;
                MyDynamic.FromDate = DateTimeController.ConvertToDateTime(input.Params.FromDate);
                MyDynamic.ToDate = DateTimeController.ConvertToDateTime(input.Params.ToDate);
                MyDynamic.IvItemsTypesConfigureId = input.Params.IvItemsTypesConfigureId;
                MyDynamic.TrItemId = input.Params.TrItemId;
                MyDynamic.Lang = "en";

                var mapped = ObjectMapper.Map<ItemSalesAnalysisInput>(MyDynamic);

                mapped.TenantId = AbpSession.TenantId.Value;

                var result = await _itemSalesAnalysisReportRepository.Execute(mapped, "rptIvItemSalesAnalysis");

                List<ItemSalesAnalysisOutput> listItems = new List<ItemSalesAnalysisOutput>();
                foreach (var item in result)
                {

                    listItems.Add((ItemSalesAnalysisOutput)item);
                }

                var items = ObjectMapper.Map<List<ItemSalesAnalysisDto>>(listItems);
                 
                items[0].GTotalValue = items.Sum(x => (x.TotalValue));
                items[0].GTotalCost = items.Sum(x => (x.TotalCost));
                items[0].TotalProfit = items.Sum(x => (x.NetProfit));
                var count = items.Count;
                items = items.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

                var PagedResultDto = new PagedResultDto<ItemSalesAnalysisDto>()
                {
                    Items = items as IReadOnlyList<ItemSalesAnalysisDto>,
                    TotalCount = count
                };

                return PagedResultDto;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
