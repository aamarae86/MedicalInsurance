using Abp.Application.Services;
using ERP._System._modules;
using ERP._System.Home.Ouput;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.Home
{
    public interface IHomeAppService : IApplicationService
    {
        Task<List<GetTopGraphHomePageOutput>> GetTopGraphHomePage(string lang);
        Task<List<GetBarChartItemSoldbyValueOutput>> GetBarChartItemSoldbyValue(string lang = "ar-EG");
        Task<List<GetBarChartItemSoldbyValueOutput>> GetBarChartSalesBySaleManMonthly(int PeriodId, string lang = "ar-EG");
        Task<List<GetBarChartItemSoldbyValueOutput>> GetBarChartSalesCurrentMonthDaily(int? PeriodId, string lang = "ar-EG");
        Task<bool> IsPageFavorite(string pageName);

        Task<Page> GetFileVideoPage(string pageName);

        Task<bool> ToggleFavoritePage(string pageName);
    }
}
