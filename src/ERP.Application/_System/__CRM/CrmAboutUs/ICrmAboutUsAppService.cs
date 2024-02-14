using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CRM._CrmAboutUs.Dto;
using ERP._System.__CRM.AboutUs;
using ERP._System.__CRM.AboutUs.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__CRM._CrmAboutUs
{
    public interface ICrmAboutUsAppService : IAsyncCrudAppService<CrmAboutUsDto, long, PagedCrmAboutUsResultRequestDto, CrmAboutUsCreateDto, CrmAboutUsEditDto>
    {
        Task<IEnumerable<AboutUSSliderDto>> GetAllAttachments(EntityDto<long> input);

    }
}
