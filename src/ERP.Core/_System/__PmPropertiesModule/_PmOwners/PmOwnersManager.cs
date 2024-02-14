using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmOwners
{
    public class PmOwnersManager : IPmOwnersManager
    {
        private readonly IRepository<PmOwners, long> _repoPmOwners;

        public PmOwnersManager(IRepository<PmOwners, long> repoPmOwners)
        {
            _repoPmOwners = repoPmOwners;
        }
        public async Task<Select2PagedResult> PmOwnersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoPmOwners.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.OwnerNameAr.Contains(searchTerm) : z.OwnerNameEn.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.OwnerNameAr : z.OwnerNameEn,altText=z.OwnerNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> PmOwnersNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoPmOwners.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.OwnerNumber.Contains(searchTerm) : z.OwnerNumber.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.OwnerNumber : z.OwnerNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
