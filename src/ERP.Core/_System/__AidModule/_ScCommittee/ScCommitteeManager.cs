using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System.__AidModule._ScCommittee
{
    public class ScCommitteeManager : IScCommitteeManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IRepository<ScCommittee, long> _scCommitteeRepository;

        public ScCommitteeManager  (   IRepository<ScCommittee, long> scCommitteeRepository   )
        {
            _scCommitteeRepository = scCommitteeRepository;
        }

        public async Task<Select2PagedResult> GetScCommitteeForChecksSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data =  _scCommitteeRepository.GetAll()
                    .Where(z => (string.IsNullOrEmpty(searchTerm) || z.CommitteeName.Contains(searchTerm)) && (z.StatusLkpId == 157));
                    //.ToListAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.CommitteeName }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
