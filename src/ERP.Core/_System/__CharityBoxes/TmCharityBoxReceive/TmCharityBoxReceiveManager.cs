using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive
{
    public class TmCharityBoxReceiveManager : ITmCharityBoxReceiveManager
    {
        private readonly IRepository<TmCharityBoxReceive, long> _repoTmCharityBoxReceive;

        public TmCharityBoxReceiveManager(IRepository<TmCharityBoxReceive, long> repoTmCharityBoxReceive)
        {
            _repoTmCharityBoxReceive = repoTmCharityBoxReceive;
        }

        //public async Task<Select2PagedResult> GetTmCharityBoxReceiveSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        //{

        //    var data = await _repoTmCharityBoxReceive.GetAll()
        //        .Where(z =>
        //         string.IsNullOrEmpty(searchTerm) || (z.RegionName.Contains(searchTerm) || z.RegionNumber.Contains(searchTerm))).Include(z=>z.FndLookupValues)
        //        .ToListAsync();

        //    var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = $"{z.RegionName} - {(lang == "ar-EG" ? z.FndLookupValues.NameAr : z.FndLookupValues.NameEn)}" }).ToList();

        //    var select2pagedResult = new Select2PagedResult
        //    {
        //        Total = data.Count(),
        //        Results = result
        //    };

        //    return select2pagedResult;
        //}
    }

}
