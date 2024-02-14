using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxes
{
    public class TmCharityBoxesManager : ITmCharityBoxesManager
    {
        private readonly IRepository<TmCharityBoxes, long> _repoTmCharityBoxes;

        public TmCharityBoxesManager(IRepository<TmCharityBoxes, long> repoTmCharityBoxes)
        {
            _repoTmCharityBoxes = repoTmCharityBoxes;
        }

        public async Task<(long id, string text)> GetCharityBoxByLocation(long locationId)
        {
            var data = await _repoTmCharityBoxes.GetAll().Where(z => z.StatusLkpId == 597 && z.TmSubLocationId == locationId).FirstOrDefaultAsync();

            return data == null ? (0, string.Empty) : (data.Id, $"{data.CharityBoxBarcode}-{data.CharityBoxName}");
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long? statuslkpId = null)
        {
            var data = _repoTmCharityBoxes.GetAll()
                .Where(z => (statuslkpId == null || z.StatusLkpId == statuslkpId) &&
                 (string.IsNullOrEmpty(searchTerm) || z.CharityBoxName.Contains(searchTerm) || z.CharityBoxNumber.Contains(searchTerm)));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.CharityBoxBarcode}-{z.CharityBoxName}", altText = z.CharityBoxNumber }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
