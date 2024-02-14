using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__HR._HrPersonsDeduction.Dto;
using ERP._System.__Warehouses._IvPriceListHd.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvPriceListHd
{
    public interface IIvPriceListHdAppService : IAsyncCrudAppService<IvPriceListHdDto, long, IvPriceListHdPagedDto, IvPriceListHdCreateDto, IvPriceListHdEditDto>
    {
        Task<IvPriceListHdDto> GetDetailAsync(EntityDto<long> input);
        Task<List<IvPriceListTrDto>> GetSalesPriceData(bool AllOrganizationcheck, decimal percentage,long IvItemsTypesConfigureId);
    }
}
