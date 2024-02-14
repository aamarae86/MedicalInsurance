using ERP._System.__AidModule._ScPortalRequest.Proc.Dto;

namespace ERP._System.__AidModule._ScPortalRequest.Proc
{
    public interface IScPortalRequestTenantsRepository
        : IExecuteProcedure<ScPortalRequest, long, AvailableTenantsDto, TenantsOutput>
    { }
}
