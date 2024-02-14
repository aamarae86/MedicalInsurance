using Abp.Application.Services;
using ERP._System.__CRM._CrmProducts.Dto;

namespace ERP._System.__CRM._CrmProducts
{
    public interface ICrmProductsAppService : IAsyncCrudAppService<CrmProductsDto, long, CrmProductsPagedDto, CrmProductsCreateDto, CrmProductsEditDto>
    {

    }
}
