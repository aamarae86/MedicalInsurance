using Abp.Domain.Repositories;
using ERP._System.__Warehouses._PyElements;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyElements
{
    public class PyElementsManager : IPyElementsManager
    {

        private readonly IRepository<PyElements, long> _repoElements;

        public PyElementsManager(IRepository<PyElements, long> repoElements)
        {
            _repoElements = repoElements;
        }

        public async Task<Select2PagedResult> GetPyElementsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoElements.GetAll()
                     .Where(z => (string.IsNullOrEmpty(searchTerm) || z.ElementName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.ElementName, altText = z.ElementSerial.ToString() })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }
    }
}
