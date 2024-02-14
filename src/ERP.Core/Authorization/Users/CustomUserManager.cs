using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP.Authorization.Users
{
    public class CustomUserManager : ICustomUserManager
    {
        private readonly IRepository<User, long> _repoCustomUser;

        public CustomUserManager(IRepository<User, long> repoCustomUser)
        {
            _repoCustomUser = repoCustomUser;
        }

       

        public async Task<Select2PagedResult> GetUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoCustomUser.GetAll()
                 .Where(z =>
                  string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.UserName.Contains(searchTerm) : z.UserName.Contains(searchTerm)))
                 .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.UserName : z.UserName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
