using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts
{
    public interface IPmTerminateContractsAppService
        : IAsyncCrudAppService<PmTerminateContractsDto, long, PagedPmTerminateContractsResultRequestDto, CreatePmTerminateContractsDto, PmTerminateContractsEditDto>
    {
        Task<PmTerminateContractsDto> GetDetailAsync(EntityDto<long> input);
    }
}
