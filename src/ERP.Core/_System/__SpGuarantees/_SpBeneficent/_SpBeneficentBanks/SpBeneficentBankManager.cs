using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpBeneficent._SpBeneficentBanks
{
    public class SpBeneficentBankManager : ISpBeneficentBankManager
    {
        private readonly IRepository<SpBeneficentBanks, long> _repoSpBeneficentBanks;

        public SpBeneficentBankManager(IRepository<SpBeneficentBanks, long> repoSpBeneficentBanks)
        {
            _repoSpBeneficentBanks = repoSpBeneficentBanks;
        }

        public async Task<Select2PagedResult> GetSpBeneficentBanksSelect2(long spBeneficentId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoSpBeneficentBanks.GetAllIncluding(x => x.LookupBankValues)
                    .Where(z => (z.SpBeneficentId == spBeneficentId) && (string.IsNullOrEmpty(searchTerm) || z.AccountOwnerName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.LookupBankValues.NameAr : z.LookupBankValues.NameEn })
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
