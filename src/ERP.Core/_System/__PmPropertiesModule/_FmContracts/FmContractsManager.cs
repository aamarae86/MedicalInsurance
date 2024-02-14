using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmContracts
{
    public class FmContractsManager : IFmContractsManager
    {
        private readonly IRepository<FmContracts, long> _repoFmContracts;
        private readonly IRepository<FmContractVisits, long> _repoFmContractVisits;

        public FmContractsManager(IRepository<FmContracts, long> repoFmContracts, IRepository<FmContractVisits, long> repoFmContractVisits)
        {
            _repoFmContracts = repoFmContracts;
            _repoFmContractVisits = repoFmContractVisits;
        }

        public async Task<Select2PagedResult> GetFmContractsNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            long postedStatusLkpId = 11057;

            var data = _repoFmContracts.GetAll().Where(z => z.StatusLkpId == postedStatusLkpId &&
             (string.IsNullOrEmpty(searchTerm) || z.ContractNumber.Contains(searchTerm) || z.VendorContractNumber.Contains(searchTerm)));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.ContractNumber }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetFmContractsVisitsNumberSelect2(long contactId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoFmContractVisits.GetAllIncluding(x => x.FmEngineers).Where(
                z => z.ContractId == contactId &&
               (string.IsNullOrEmpty(searchTerm) || z.VisitNumber.Contains(searchTerm)));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.VisitNumber ,altText  = JsonConvert.SerializeObject(z.FmEngineers) }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
