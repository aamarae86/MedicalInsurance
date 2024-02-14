using Abp.Application.Services;
using ERP._System.__AidModule._ScMaintenancePayments.Dto;

namespace ERP._System.__AidModule._ScMaintenancePayments
{
    public interface IScMaintenancePaymentsAppService : IAsyncCrudAppService<ScMaintenancePaymentsDto, long, ScMaintenancePaymentsPagedDto, ScMaintenancePaymentsCreateDto, ScMaintenancePaymentsEditDto>
    {
    }
}
