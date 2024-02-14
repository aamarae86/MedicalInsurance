using Abp.Domain.Services;
using System.Threading.Tasks;

namespace ERP._System
{
    public interface IEntityCounterManager : IDomainService
    {
        Task<string> GetEntityNumber(string CounterName, int tenantId, string lang = "ar-EG", int year = 0);
    }
}
