using Abp.Application.Services;
using ERP._System.__CRM._CrmLeadsPersons.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._CrmLeadsPersons
{
    public interface ICrmLeadsPersonsAppService : IAsyncCrudAppService<CrmLeadsPersonsDto, long, CrmLeadsPersonsPagedDto, CrmLeadsPersonsCreateDto, CrmLeadsPersonsEditDto>
    {
    }
}
 