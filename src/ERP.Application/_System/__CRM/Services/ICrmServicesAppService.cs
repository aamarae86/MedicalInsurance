using Abp.Application.Services;
using ERP._System.__CRM._CrmServices.Dto;

namespace ERP._System.__CRM._CrmServices
{
    public interface ICrmServicesAppService : IAsyncCrudAppService<CrmServicesDto, long, CrmServicesPagedDto, CrmServicesCreateDto, CrmServicesEditDto>
    {

    }
}
