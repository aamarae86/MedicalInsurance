using Abp.Domain.Repositories;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCases
{
    public class SpCasesManager : ISpCasesManager
    {
        private readonly IRepository<SpCases, long> _repoSpCases;
        private readonly IRepository<SpContractDetails, long> _repoSpContractDetails;

        public SpCasesManager(
            IRepository<SpCases, long> repoSpCases,
            IRepository<SpContractDetails, long> repoSpContractDetails)
        {
            _repoSpCases = repoSpCases;
            _repoSpContractDetails = repoSpContractDetails;
        }

        public async Task<Select2PagedResult> GetSpCasesForContractsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var cntrctDetailsIds = await _repoSpContractDetails.GetAll()
                .Where(z => z.CaseStatusLkpId == 694).Select(z => z.SpCaseId).ToListAsync();

            var data = _repoSpCases.GetAll()
                    .Where(z =>
                            !cntrctDetailsIds.Contains(z.Id) &&
                            (z.StatusLkpId == 686 || z.StatusLkpId == 688) &&
                            (string.IsNullOrEmpty(searchTerm) || z.CaseName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.CaseName })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSpCasesForReplaceNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoSpCases.GetAll()
                         .Where(z => (z.StatusLkpId == 686 || z.StatusLkpId == 688) && (string.IsNullOrEmpty(searchTerm) || z.CaseName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.CaseName, altText = z.CaseNumber })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSpCasesForReplaceNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoSpCases.GetAll()
                      .Where(z => (z.StatusLkpId == 686 || z.StatusLkpId == 688) && (string.IsNullOrEmpty(searchTerm) || z.CaseName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.CaseNumber, altText = z.CaseName })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSpCasesGrantedSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoSpCases.GetAll()
                   .Where(z => z.StatusLkpId == 687 && (string.IsNullOrEmpty(searchTerm) || z.CaseName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.CaseName })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSpCasesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoSpCases.GetAll()
                    .Where(z => (string.IsNullOrEmpty(searchTerm) || z.CaseName.Contains(searchTerm) || z.CaseNumber.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.CaseName, altText = z.CaseNumber })
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
