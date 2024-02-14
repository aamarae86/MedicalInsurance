using Abp.Application.Services.Dto;
using ERP._System.__SalesModule._ItemSalesMonthlyAnalysis;
using ERP._System.__SalesModule._ItemSalesMonthlyAnalysis.Proc;
using ERP._System.__SalesModule._ItemSalesMonthlyAnalysis.ProcDto;
using ERP._System._ItemSalesMonthlyAnalysis.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ItemSalesMonthlyAnalysis
{
   public class ItemSalesMonthlyAnalysisAppService : ERPAppServiceBase, IItemSalesMonthlyAnalysisAppService
    {
        private readonly IItemSalesMonthlyAnalysisReportRepository _itemSalesMonthlyAnalysisReportRepository;


        public ItemSalesMonthlyAnalysisAppService(
             IItemSalesMonthlyAnalysisReportRepository itemSalesMonthlyAnalysisReportRepository
             )
        {

            _itemSalesMonthlyAnalysisReportRepository = itemSalesMonthlyAnalysisReportRepository;
        }


        public async Task<PagedResultDto<ItemSalesMonthlyAnalysisDto>> GetItemSalesMonthlyAnalysis(ItemSalesMonthlyAnalysisPagedDto input)
        {
            try
            {
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.TenantId = AbpSession.TenantId.Value;
                MyDynamic.Year = input.Params.Year;
                MyDynamic.IvItemsTypesConfigureId = input.Params.IvItemsTypesConfigureId;
                MyDynamic.TrItemId = input.Params.TrItemId;
                MyDynamic.Lang = "en";

                var mapped = ObjectMapper.Map<ItemSalesMonthlyAnalysisInput>(MyDynamic);

                mapped.TenantId = AbpSession.TenantId.Value;

                var result = await _itemSalesMonthlyAnalysisReportRepository.Execute(mapped, "rptIvItemSalesMonthlyAnalysis");

                List<ItemSalesMonthlyAnalysisOutput> listItems = new List<ItemSalesMonthlyAnalysisOutput>();
                foreach (var item in result)
                {
                    
                    listItems.Add((ItemSalesMonthlyAnalysisOutput)item);
                }

                var items = ObjectMapper.Map<List<ItemSalesMonthlyAnalysisDto>>(listItems);
                items[0].JanTotal = items.Sum(x => (x.JanuaryValue));
                items[0].FebTotal = items.Sum(x => (x.FebruaryValue));
                items[0].MarchTotal = items.Sum(x => (x.MarchValue));
                items[0].AprilTotal = items.Sum(x => (x.AprilValue));
                items[0].MayTotal = items.Sum(x => (x.MayValue));
                items[0].JunTotal = items.Sum(x => (x.JunValue));
                items[0].JulyTotal = items.Sum(x => (x.JulValue));
                items[0].AugTotal = items.Sum(x => (x.AugustValue));
                items[0].SepTotal = items.Sum(x => (x.SeptemberValue));
                items[0].OctTotal = items.Sum(x => (x.OctoberValue));
                items[0].NovTotal = items.Sum(x => (x.NovemberValue));
                items[0].DecTotal = items.Sum(x => (x.DecemberValue));
                items[0].GrandTotal = items.Sum(x => (x.TotalValue));
                 var count = items.Count;
               //foreach(var itm in items)
               // {
               //     itm.MarchTotal=items.Sum(x => (x.MarchValue));
               // }

               items = items.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

                var PagedResultDto = new PagedResultDto<ItemSalesMonthlyAnalysisDto>()
                {
                    Items = items as IReadOnlyList<ItemSalesMonthlyAnalysisDto>,
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
