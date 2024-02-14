using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System
{
    public class EntityCounterManager : IEntityCounterManager
    {
        private readonly IGetCounterRepository _repoProcCounter;

        public EntityCounterManager(IGetCounterRepository repoProcCounter)
        {
            _repoProcCounter = repoProcCounter;
        }

        public async Task<string> GetEntityNumber(string CounterName, int tenantId, string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = CounterName, TenantId = tenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
