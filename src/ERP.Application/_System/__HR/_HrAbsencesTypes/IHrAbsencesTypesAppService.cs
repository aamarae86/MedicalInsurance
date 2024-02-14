using Abp.Application.Services;
using ERP._System.__HR._HrAbsencesTypes.Dto;

namespace ERP._System.__HR._HrAbsencesTypes
{
    public interface IHrAbsencesTypesAppService : IAsyncCrudAppService<HrVacationsTypesDto, long, HrVacationsTypesPagedDto, HrVacationsTypesCreateDto, HrVacationsTypesEditDto>
    {
    }
}
