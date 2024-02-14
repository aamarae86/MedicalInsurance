using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersons
{
    public interface IHrPersonsManager : IDomainService
    {
        Task<Select2PagedResult> GetPersonsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetPersonsNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetPersonSupervisorSelect2(long id, string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetPersonsForPayRollSelect2(long pyPayrollTypeId, string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetPersonsJobsForPayRollSelect2(long pyPayrollTypeId, string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetPersonsNumbersForEngineersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
