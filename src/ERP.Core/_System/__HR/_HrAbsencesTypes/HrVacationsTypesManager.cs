using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrAbsencesTypes
{
    public class HrVacationsTypesManager : IHrVacationsTypesManager
    {
        private readonly IRepository<HrVacationsTypes, long> _repoHrVacationsTypes;

        public HrVacationsTypesManager(IRepository<HrVacationsTypes, long> repoHrVacationsTypes)
        {
            _repoHrVacationsTypes = repoHrVacationsTypes;
        }

        public async Task<Select2PagedResult> GetHrVacationsTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrVacationsTypes.GetAll()
                   .Where(z => (string.IsNullOrEmpty(searchTerm) || z.VacationsTypeName.Contains(searchTerm) || z.VacationsTypeNumber.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.VacationsTypeName, altText = z.VacationsTypeNumber })
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
