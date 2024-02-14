using Abp.Application.Services;
using ERP._System.__CRM._CrmProjects.Dto;

namespace ERP._System.__CRM._CrmProjects
{
    public interface ICrmProjectsAppService : IAsyncCrudAppService<CrmProjectsDto, long, CrmProjectsPagedDto, CrmProjectsCreateDto, CrmProjectsEditDto>
    {

    }
}
