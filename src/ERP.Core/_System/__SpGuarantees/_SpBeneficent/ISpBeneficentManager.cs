using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpBeneficent
{
    public interface ISpBeneficentManager : IDomainService
    {
        Task<Select2PagedResult> GetSpBeneficentSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetSpBeneficentBanksSelect2(long Id, string searchTerm, int pageSize, int pageNumber, string lang);

        //Task<Select2PagedResult> GetSpBeneficentForChecksSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
