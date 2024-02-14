using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvStoreIssue
{
    public class IvStoreIssueHdManager : IIvStoreIssueHdManager
    {
        private readonly IRepository<IvStoreIssueHd, long> _repoIvStoreIssueHd;

        public IvStoreIssueHdManager(IRepository<IvStoreIssueHd, long> repoIvStoreIssueHd)
        {
            _repoIvStoreIssueHd = repoIvStoreIssueHd;
        }

        public async Task<Select2PagedResult> GetStoreIssueSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoIvStoreIssueHd.GetAll().Where(z => string.IsNullOrEmpty(searchTerm) || z.StoreIssueNumber.Contains(searchTerm));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.StoreIssueNumber })
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
