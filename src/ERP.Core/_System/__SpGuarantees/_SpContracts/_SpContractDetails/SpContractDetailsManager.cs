using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpContracts._SpContractDetails
{
    public class SpContractDetailsManager : ISpContractDetailsManager
    {
        private readonly IRepository<SpContractDetails, long> _repoSpContractDetails;

        public SpContractDetailsManager(IRepository<SpContractDetails, long> repoSpContractDetails)
        {
            _repoSpContractDetails = repoSpContractDetails;
        }

        public async Task<Select2PagedResult> GetSpCasesWithSpContractDetailsSearchSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoSpContractDetails.GetAllIncluding(x => x.SpCases, x => x.SpContracts)
                    .Where(z => (string.IsNullOrEmpty(searchTerm) || z.SpCases.CaseName.Contains(searchTerm) || z.SpCases.CaseName.Contains(searchTerm)))
                    .GroupBy(z => z.SpCaseId)
                    .Select(z => z.FirstOrDefault())
                    .ToList();

            long count = data.LongCount();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.SpCases.CaseName, altText = z.SpCases.CaseNumber })
                        .ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSpCasesWithSpContractDetailsSelect2(long beneficentId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            long statusGrandtedLkpId = 687;
            var data = _repoSpContractDetails.GetAllIncluding(x => x.SpCases, x => x.SpContracts)
                    .Where(z => (z.SpContracts.SpBeneficentId == beneficentId &&
                                 z.SpCaseId == z.SpCases.Id &&
                                 z.Id == z.SpCases.SpContractDetailsId &&
                                 z.CaseStatusLkpId == statusGrandtedLkpId
                                 ) && (string.IsNullOrEmpty(searchTerm) || z.SpCases.CaseName.Contains(searchTerm) || z.SpCases.CaseName.Contains(searchTerm)))
                    .GroupBy(z => z.SpCaseId)
                    .Select(z => z.FirstOrDefault())
                    .ToList();

            long count = data.LongCount();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.SpCases.CaseName, altText = z.SpCases.CaseNumber })
                        .ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }
    }
}
