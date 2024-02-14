using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvUnits
{
    public class IvUnitsManager : IIvUnitsManager
    {
        private readonly IRepository<IvUnits, long> _repoIvUnits;

        public IvUnitsManager(IRepository<IvUnits, long> repoIvUnits)
        {
            _repoIvUnits = repoIvUnits;
        }

        public async Task<Select2PagedResult> GetIvUnitsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoIvUnits.GetAll().Where(z => string.IsNullOrEmpty(searchTerm) || z.UnitName.Contains(searchTerm));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.UnitName })
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
