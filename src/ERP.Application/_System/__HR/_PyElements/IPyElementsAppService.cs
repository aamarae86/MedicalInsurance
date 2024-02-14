using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__HR._PyElements.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyElements
{
    public interface IPyElementsAppService : IAsyncCrudAppService< PyElementsDto, long, PyElementsPagedDto, PyElementsCreateDto, PyElementsEditDto>
    {
        Task<PyElementsDto> GetDetailAsync(EntityDto<long> input);

        Task<bool> GetExistElementNameAsync(string input, string Id);

        Task<bool> GetExistElementSerialAsync(string input, string Id);
    }
}
