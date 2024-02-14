using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyPayrollTypes
{
    public class PyPayrollTypesManager : IPyPayrollTypesManager
    {
        private readonly IRepository<PyPayrollTypes, long> _repoPyPayrollTypes;

        public PyPayrollTypesManager(IRepository<PyPayrollTypes, long> repoPyPayrollTypes)
        {
            _repoPyPayrollTypes = repoPyPayrollTypes;
        }

        public async Task<Select2PagedResult> GetPyPayrollTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoPyPayrollTypes.GetAll()
                      .Where(z => (string.IsNullOrEmpty(searchTerm) || z.PyPayrollTypeName.Contains(searchTerm) || z.PayrollTypeNumber.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.PyPayrollTypeName, altText = z.PayrollTypeNumber })
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
