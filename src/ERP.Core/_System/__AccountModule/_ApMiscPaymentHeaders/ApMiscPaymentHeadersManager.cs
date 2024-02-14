using Abp.Domain.Repositories;
using ERP._System._ApMiscPaymentHeaders;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ApMiscPaymentHeaders
{
    public class ApMiscPaymentHeadersManager : IApMiscPaymentHeadersManager
    {
        private readonly IRepository<ApMiscPaymentHeaders, long> _repoApMiscPaymentHeaders;

        public ApMiscPaymentHeadersManager(IRepository<ApMiscPaymentHeaders, long> repoApMiscPaymentHeaders)
        {
            _repoApMiscPaymentHeaders = repoApMiscPaymentHeaders;
        }

        public async Task<Select2PagedResult> GetBeneficiaryNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoApMiscPaymentHeaders.GetAll()
                               .Where(z => string.IsNullOrEmpty(searchTerm) || z.BeneficiaryName.Contains(searchTerm))
                               .GroupBy(z => z.BeneficiaryName)
                               .Select(z => z.FirstOrDefault())
                               .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel
            {
                id = z.Id,
                text = z.BeneficiaryName,
            }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
