using Abp.Application.Services;
using ERP._System.__CRM._CrmDeals.Dto;
using ERP._System.__CRM.Deals;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__CRM._CrmDeals
{
    public interface ICrmDealsAppService : IAsyncCrudAppService<CrmDealsDto, long, CrmDealsPagedDto, CrmDealsCreateDto, CrmDealsEditDto>
    {
    }
}
 