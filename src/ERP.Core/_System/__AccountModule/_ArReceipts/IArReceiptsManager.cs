using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ArReceipts
{
    public interface IArReceiptsManager : IDomainService
    {
        Task<Select2PagedResult> GetArReceipts_ReceiptsOnAccount_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang);
    }
}
