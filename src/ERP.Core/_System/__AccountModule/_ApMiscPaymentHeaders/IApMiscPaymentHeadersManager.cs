using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ApMiscPaymentHeaders
{
    public interface IApMiscPaymentHeadersManager : IDomainService
    {
        Task<Select2PagedResult> GetBeneficiaryNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
