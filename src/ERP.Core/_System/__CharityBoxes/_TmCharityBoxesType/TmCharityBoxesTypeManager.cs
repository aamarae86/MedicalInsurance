using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._TmCharityBoxesType
{
    public class TmCharityBoxesTypeManager : ITmCharityBoxesTypeManager
    {
        private readonly IRepository<TmCharityBoxesType, long> _repoTmCharityBoxesType;

        public TmCharityBoxesTypeManager(IRepository<TmCharityBoxesType, long> repoTmCharityBoxesType)
        {
            _repoTmCharityBoxesType = repoTmCharityBoxesType;
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = _repoTmCharityBoxesType.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (z.CharityBoxTypeName.Contains(searchTerm)));
                
            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(z => new Select2OptionModel { id = z.Id, text = z.CharityBoxTypeName, altText= z.TypeCode }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
