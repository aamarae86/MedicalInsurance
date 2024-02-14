using Abp.Application.Services;
using ERP._System.__CRM._CrmContactUs.Dto;

namespace ERP._System.__CRM._CrmContactUs
{
    public interface ICrmContactUsAppService : IAsyncCrudAppService<CrmContactUsDto, long, CrmContactUsPagedDto, CrmContactUsCreateDto, CrmContactUsEditDto>
    {
    }
}
