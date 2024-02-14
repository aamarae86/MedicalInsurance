using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmCancellationContracts
{
    public interface IPmCancellationContractsAppService :
        IAsyncCrudAppService<PmCancellationContractsDto, long, PagedPmCancellationContractsResultRequestDto, CreatePmCancellationContractsDto, PmCancellationContractsEditDto>
    {
        Task<PmCancellationContractsDto> GetDetailAsync(EntityDto<long> input);
    }
}
