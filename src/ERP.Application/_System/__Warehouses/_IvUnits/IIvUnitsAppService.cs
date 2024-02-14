using Abp.Application.Services;
using ERP._System.__Warehouses._IvUnits.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvUnits
{
    public interface IIvUnitsAppService : IAsyncCrudAppService<IvUnitsDto, long, IvUnitsPagedDto, IvUnitsCreateDto, IvUnitsEditDto>
    {
        Task<Select2PagedResult> GetIvUnitsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
