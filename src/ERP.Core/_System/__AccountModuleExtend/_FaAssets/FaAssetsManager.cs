using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._FaAssets
{
    public class FaAssetsManager : IFaAssetsManager
    {
        private readonly IRepository<FaAssets, long> _repoFaAssets;

        public FaAssetsManager(IRepository<FaAssets, long> repoFaAssets)
        {
            _repoFaAssets = repoFaAssets;
        }

        public async Task<Select2PagedResult> GetSelect2FaAssets(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoFaAssets.GetAll().Where(z => string.IsNullOrEmpty(searchTerm) || z.Description.Contains(searchTerm));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.Description })
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
