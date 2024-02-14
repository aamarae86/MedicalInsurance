using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes
{
    public class PmOtherPaymentTypesManager: IPmOtherPaymentTypesManager
    {
        private readonly IRepository<PmOtherPaymentTypes, long> _repoPmOtherPaymentTypes;

        public PmOtherPaymentTypesManager(IRepository<PmOtherPaymentTypes, long> repoPmOtherPaymentTypes)
        {
            _repoPmOtherPaymentTypes = repoPmOtherPaymentTypes;
        }

        public async Task<Select2PagedResult> GetPmOtherPaymentTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoPmOtherPaymentTypes.GetAll()
               .Where(z =>
                string.IsNullOrEmpty(searchTerm) || z.PaymentTypeName.Contains(searchTerm))
               .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.PaymentTypeName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
