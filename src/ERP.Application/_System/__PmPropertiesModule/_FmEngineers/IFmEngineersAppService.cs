using Abp.Application.Services;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;

namespace ERP._System.__PmPropertiesModule._FmEngineers
{
    public interface IFmEngineersAppService : IAsyncCrudAppService<FmEngineersDto, long, FmEngineersPagedDto, FmEngineersCreateDto, FmEngineersEditDto>
    {

    }
}
