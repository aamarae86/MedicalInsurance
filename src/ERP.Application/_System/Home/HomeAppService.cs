using Abp.Application.Services;
using ERP._System._modules;
using ERP._System.Home.Dto;
using ERP._System.Home.Input;
using ERP._System.Home.Ouput;
using ERP._System.Home.Proc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.Home
{
    public class HomeAppService : ApplicationService, IHomeAppService
    {
        private readonly IGetTopGraphHomePageRepository _getTopGraphHomePage;
        private readonly IGetBarChartItemSoldbyValueRepository _getBarChartItemSoldbyValueRepository;
        private readonly IGetBarChartItemSoldRepository _getBarChartItemSoldRepository;
        private readonly IGetBarChartMonthlyExpenseRepository _getBarChartMonthlyExpenseRepository;
        private readonly IGetBarChartSalesBySaleManMonthlyRepository _getBarChartSalesBySaleManMonthlyRepository;
        
        public readonly IFavoritePageManager _favoritePageManager;

        public HomeAppService(IGetTopGraphHomePageRepository getTopGraphHomePage,
            IGetBarChartSalesBySaleManMonthlyRepository getBarChartSalesBySaleManMonthlyRepository, IGetBarChartItemSoldRepository getBarChartItemSoldRepository, IGetBarChartMonthlyExpenseRepository getBarChartMonthlyExpenseRepository,
        IGetBarChartItemSoldbyValueRepository getBarChartItemSoldbyValueRepository, IFavoritePageManager favoritePageManager)
        {
            _getTopGraphHomePage = getTopGraphHomePage;
            _favoritePageManager = favoritePageManager;
            _getBarChartItemSoldbyValueRepository= getBarChartItemSoldbyValueRepository;
            _getBarChartSalesBySaleManMonthlyRepository= getBarChartSalesBySaleManMonthlyRepository;
            _getBarChartItemSoldRepository = getBarChartItemSoldRepository;
            _getBarChartMonthlyExpenseRepository = getBarChartMonthlyExpenseRepository;
        }

        public async Task<List<GetTopGraphHomePageOutput>> GetTopGraphHomePage(string lang = "ar-EG")//GetTopGraphHomePageInput input)
        {
            var input = new GetTopGraphHomePageInput()
            {
                userId = AbpSession.UserId.HasValue ?
                    AbpSession.UserId.Value.ToString() : "0",
                lang = lang
            };
            var ouptut = await _getTopGraphHomePage.Execute(input, "GetTopGraphHomePage");

            return ouptut.ToList();
        }
        public async Task<List<GetBarChartItemSoldbyValueOutput>> GetBarChartItemSoldbyValue(string lang = "ar-EG")
        {
            var input = new GetTopGraphHomePageInput()
            {
                userId = AbpSession.UserId.HasValue ?
                    AbpSession.UserId.Value.ToString() : "0",
                lang = lang
            };           
            var ouptut2 = await _getBarChartItemSoldbyValueRepository.Execute(input, "GetBarChartItemSoldbyValue");
            return ouptut2.Take(10).ToList();
        }

        public async Task<List<GetBarChartItemSoldbyValueOutput>> GetBarChartSalesCurrentMonthDaily(int? PeriodId, string lang = "ar-EG")
        {
            var input = new GetTopGraphHomePageSaleInput()
            {
                userId = AbpSession.UserId.HasValue ?
                    AbpSession.UserId.Value.ToString() : "0",
                lang = lang,
                PeriodId = PeriodId

            };

            var ouptut2 = await _getBarChartItemSoldRepository.Execute(input, "GetBarChartSalesCurrentMonthDaily");
            return ouptut2.ToList();
        }

        public async Task<List<GetBarChartItemSoldbyValueOutput>> GetBarChartSaleByCategory(int? PeriodId, string lang = "ar-EG")
        {
            var input = new GetTopGraphHomePageSaleInput()
            {
                userId = AbpSession.UserId.HasValue ?
                    AbpSession.UserId.Value.ToString() : "0",
                lang = lang,
                PeriodId = PeriodId
            };
            var ouptut2 = await _getBarChartItemSoldRepository.Execute(input, "GetBarChartSaleByCategory");
            return ouptut2.ToList();
        }

        public async Task<List<GetBarChartItemSoldbyValueOutput>> GetBarChartPeriodRevVSExp(string lang = "ar-EG")
        {
            var input = new GetTopGraphHomePageInput()
            {
                userId = AbpSession.UserId.HasValue ?
                    AbpSession.UserId.Value.ToString() : "0",
                lang = lang
            };
            var ouptut2 = await _getBarChartItemSoldbyValueRepository.Execute(input, "GetBarChartPeriodRevVSExp");
            return ouptut2.ToList();
        }

        public async Task<List<GetBarChartItemSoldbyValueOutput>> GetBarChartSalesBySaleManMonthly(int PeriodId,string lang = "ar-EG")
        {
            var input = new GetBarChartSalesBySaleManInput()
            {
                userId = AbpSession.UserId.HasValue ?
                    AbpSession.UserId.Value.ToString() : "0",
                lang = lang,
                PeriodId=PeriodId
            };
            var ouptut2 = await _getBarChartSalesBySaleManMonthlyRepository.Execute(input, "GetBarChartSalesBySaleManMonthly");
            return ouptut2.ToList();
        }

        //amri
        public async Task<List<GetBarChartMonthlyExpenseOutput>> GetBarChartMonthlyExpense(string year, string lang = "ar-EG")
        {
            var input = new GetBarChartMonthlyExpenseInput()
            {
                userId = AbpSession.UserId.HasValue ?
                    AbpSession.UserId.Value.ToString() : "0",
                lang = lang,
                 Year = year
            };
            var ouptut2 = await _getBarChartMonthlyExpenseRepository.Execute(input, "GetBarChartMonthlyExpense");
            return ouptut2.Take(12).ToList();
        }


        public async Task<FavoritePageDto> Add(FavoritePageCreateDto favoritePageCreateDto)
            => MapToEntityDto(await _favoritePageManager.Add(MapToEntity(favoritePageCreateDto)));

        public async Task<List<FavoritePageDto>> GetAll(string lang)
            => MapToEntityListDto(await _favoritePageManager.GetAll(AbpSession.UserId.Value));

        public async Task Remove(long id) => await _favoritePageManager.Remove(id, AbpSession.UserId);

        [HttpGet]
        public async Task<bool> IsPageFavorite(string pageName) => await _favoritePageManager.IsPageFavorite(pageName, (long)AbpSession.UserId);

        [HttpGet]
        public async Task<bool> ToggleFavoritePage(string pageName)
            => await _favoritePageManager.ToggleFavoritePage(pageName, (long)AbpSession.UserId, (int)AbpSession.TenantId);

        public async Task<Page> GetFileVideoPage(string pageName) => await _favoritePageManager.GetFileVideoPage(pageName);


        protected virtual FavoritePage MapToEntity(FavoritePageCreateDto createInput)
        {
            return ObjectMapper.Map<FavoritePage>(createInput);
        }

        protected virtual FavoritePage MapToEntity(FavoritePageDto createInput)
        {
            return ObjectMapper.Map<FavoritePage>(createInput);
        }

        protected virtual FavoritePageDto MapToEntityDto(FavoritePage entity)
        {
            return ObjectMapper.Map<FavoritePageDto>(entity);
        }

        protected virtual List<FavoritePageDto> MapToEntityListDto(List<FavoritePage> favoritePages)
        {
            return ObjectMapper.Map<List<FavoritePageDto>>(favoritePages);
        }

    }
}
