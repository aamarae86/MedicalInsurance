using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrAbsencesTypes
{
    public interface IHrVacationsTypesManager : IDomainService
    {
        Task<Select2PagedResult> GetHrVacationsTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
