using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmRegions
{
    public class TmRegionsManager : ITmRegionsManager
    {
        private readonly IRepository<TmRegions, long> _repoTmRegions;

        public TmRegionsManager(IRepository<TmRegions, long> repoTmRegions)
        {
            _repoTmRegions = repoTmRegions;
        }

        public async Task<Select2PagedResult> GetTmRegionsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoTmRegions.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (z.RegionName.Contains(searchTerm) || z.RegionNumber.Contains(searchTerm))).Include(z=>z.FndLookupValues)
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = $"{z.RegionName} - {(lang == "ar-EG" ? z.FndLookupValues.NameAr : z.FndLookupValues.NameEn)}" }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }

}
