using Abp.Domain.Repositories;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmProperties
{
    public class PmPropertiesManager : IPmPropertiesManager
    {
        private IRepository<PmProperties, long> _repoPmProperties;
        private IRepository<PmPropertiesUnits, long> _repoPmPropertiesUnits;

        public PmPropertiesManager(
            IRepository<PmProperties, long> repoPmProperties,
            IRepository<PmPropertiesUnits, long> repoPmPropertiesUnits)
        {
            _repoPmProperties = repoPmProperties;
            _repoPmPropertiesUnits = repoPmPropertiesUnits;
        }

        public async Task<(string ownerName, string propertyNumber, long ownerId)> GetPmPropertiesInfo(long propId, string lang = "ar-EG")
        {
            var data = await _repoPmProperties.GetAllIncluding(z => z.PmOwners)
                                              .Where(z => z.Id == propId)
                                              .Select(z => new
                                              {
                                                  OwnerName = lang == "ar-EG" ? z.PmOwners.OwnerNameAr : z.PmOwners.OwnerNameEn,
                                                  z.PropertyNumber,
                                                  z.PmOwnerId
                                              }).FirstOrDefaultAsync();

            if (data == null) return (string.Empty, string.Empty, 0);

            return (ownerName: data.OwnerName, propertyNumber: data.PropertyNumber, ownerId: data.PmOwnerId);
        }

        public async Task<Select2PagedResult> GetPmPropertiesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoPmProperties.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? (z.PropertyNameAr.Contains(searchTerm) || z.PropertyNumber.Contains(searchTerm)) : (z.PropertyNameEn.Contains(searchTerm) || z.PropertyNumber.Contains(searchTerm))))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? $"{z.PropertyNameAr} - {z.PropertyNumber}" : $"{z.PropertyNameEn} - {z.PropertyNumber}", altText = z.PropertyNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPmPropertiesNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoPmProperties.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? (z.PropertyNumber.Contains(searchTerm) || z.PropertyNumber.Contains(searchTerm)) : (z.PropertyNumber.Contains(searchTerm) || z.PropertyNumber.Contains(searchTerm))))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.PropertyNumber : z.PropertyNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetUnitNumbersForContractsSelect2(long propertyId, long pmUnitTypeLkpId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoPmPropertiesUnits.GetAll()
               .Where(z =>
                  (z.StatusLkpId == 205 && z.PropertyId == propertyId && z.PmUnitTypeLkpId == pmUnitTypeLkpId) &&
                  (string.IsNullOrEmpty(searchTerm) || z.UnitNo.Contains(searchTerm))
                  );

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.UnitNo, altText = $"{z.AreaSize}-{z.YearlyRent}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPmPropertiesUnitsByPmPropIdSelect2(long propertyId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoPmPropertiesUnits.GetAll()
               .Where(z =>
                  ( z.PropertyId == propertyId )&& 
                  (string.IsNullOrEmpty(searchTerm) || z.UnitNo.Contains(searchTerm))
                  );

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.UnitNo, altText = $"{z.AreaSize}-{z.YearlyRent}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
