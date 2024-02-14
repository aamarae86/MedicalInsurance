using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._modules
{
    public class ModuleManager : IModuleManager
    {
        private readonly IRepository<Module> _repoModules;

        public ModuleManager(IRepository<Module> repoModuless)
        {
            _repoModules = repoModuless;
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoModules.GetAll()
                .Where(z => string.IsNullOrEmpty(searchTerm) || z.NameAr.Contains(searchTerm) || z.NameEn.Contains(searchTerm))
                .Include(z=>z.Pages)
                ;

            long count = await data.CountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = (lang == "ar-EG") ? z.NameAr : z.NameEn, 
                            
                            altText = string.Join(",", z.Pages.Select(p=>p.Selector).ToList().ToArray()) })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<List<Module>> GetModules()
        {
            var data =await _repoModules.GetAll()
                .Include(z => z.Pages)
                .Include(z => z.TenantFreeModules).ToListAsync();
             
            return data;
        }


    }
}
