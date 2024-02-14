using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System.__SpGuarantees._SpBeneficent
{
    public class SpBeneficentManager : ISpBeneficentManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IRepository<SpBeneficent, long> _SpBeneficentRepository;

        public SpBeneficentManager(IRepository<SpBeneficent, long> SpBeneficentRepository)
        {
            _SpBeneficentRepository = SpBeneficentRepository;
        }

        public async Task<Select2PagedResult> GetSpBeneficentForChecksSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _SpBeneficentRepository.GetAll()
                    .Where(z => string.IsNullOrEmpty(searchTerm) || z.BeneficentName.Contains(searchTerm));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.BeneficentName }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSpBeneficentSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _SpBeneficentRepository.GetAll()
                   .Where(z => (string.IsNullOrEmpty(searchTerm) || z.BeneficentName.Contains(searchTerm) || z.BeneficentNumber.Contains(searchTerm)));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.BeneficentName, altText = $"{z.BeneficentNumber}__{z.MobileNumber1}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSpBeneficentBanksSelect2(long Id, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var benef = await _SpBeneficentRepository.GetAllIncluding(z => z.SpBeneficentBanks).FirstOrDefaultAsync(z => z.Id == Id);

            var data = benef.SpBeneficentBanks
                   .Where(z => (string.IsNullOrEmpty(searchTerm)
                   || z.LookupBankValues.NameAr.Contains(searchTerm)
                   || z.LookupBankValues.NameEn.Contains(searchTerm)));

            var result = data.OrderBy(q => q.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(z =>
                new Select2OptionModel
                {
                    id = z.Id,
                    text = lang == "ar-EG" ? z.LookupBankValues?.NameAr : z.LookupBankValues?.NameEn,
                    altText = $"{z.AccountNumber}__{z.AccountOwnerName}"
                }
                ).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
