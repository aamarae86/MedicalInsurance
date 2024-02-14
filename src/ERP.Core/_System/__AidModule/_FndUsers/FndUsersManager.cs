using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System.__AidModule._FndUsers
{
    public class FndUsersManager : IFndUsersManager
    {
        private readonly IRepository<FndUsers, long> _repoFndUsers;

        public FndUsersManager(IRepository<FndUsers, long> repoFndUsers)
        {
            _repoFndUsers = repoFndUsers;
        }

        public async Task<Select2PagedResult> GetFndUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoFndUsers.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.Name.Contains(searchTerm) : z.Name.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.Name : z.Name }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
