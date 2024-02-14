using Abp.Application.Services;
using ERP._System.__PmPropertiesModule._FmContracts.Dto;

namespace ERP._System.__PmPropertiesModule._FmContracts
{
    public interface IFmContractsAppService : IAsyncCrudAppService<FmContractsDto, long, FmContractsPagedDto, FmContractsCreateDto, FmContractsEditDto>
    {

    }
}
