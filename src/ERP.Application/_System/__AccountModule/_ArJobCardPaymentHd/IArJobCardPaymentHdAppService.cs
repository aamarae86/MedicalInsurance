using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArJobCardPaymentHd.Dto;
using ERP._System.__AccountModule._ArJobCardPaymentTr.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd
{  

    public interface IArJobCardPaymentHdAppService : IAsyncCrudAppService<ArJobCardPaymentHdDto, long, PagedArJobCardPaymentHdResultRequestDto, ArJobCardPaymentHdCreateDto, ArJobCardPaymentHdEditDto>
    {
        Task<ArJobCardPaymentHdDto> GetDetailAsync(EntityDto<long> input);
        Task<List<ArJobCardPaymentHdDetailsDto>> GetAllArJobCardPaymentTrByArJobCardId(EntityDto<long> input);
        Task<Object> GetArCustomersDetails(long jobNumLkpId);
        Task<PostOutput> PostArJobCardPayment(PostDto input);
        Task<Select2PagedResult> GetArJobCardHdJobNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
