using ERP._System.__AidModule._ScMaintenanceContract.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System.__AidModule._ScMaintenanceContract.Proc
{
    public interface IGetScMaintenanceContractScreenDataRepository
        : IExecuteProcedure<ScMaintenanceContract, long, IdLangInputDto, GetScMaintenanceContractScreenDataOutputDto>
    {
    }
}
