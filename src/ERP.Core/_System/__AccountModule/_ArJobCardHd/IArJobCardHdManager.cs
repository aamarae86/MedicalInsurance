using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;


namespace ERP._System.__AccountModule._ArJobCardHd
{
    public interface IArJobCardHdManager : IDomainService
    {
      
        Task<Select2PagedResult> GetArJobCardHdJobNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
