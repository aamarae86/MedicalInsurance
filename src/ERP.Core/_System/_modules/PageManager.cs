using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._modules
{
    public class PageManager : IPageManager
    {
        private readonly IRepository<Page> _repoPages;

        public PageManager(IRepository<Page> repoPagess)
        {
            _repoPages = repoPagess;
        }

        public async Task<Select2PagedResult> GetSelect2(long parentId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoPages.GetAll().Where(z => parentId!=null && z.ModuleId==(int)parentId && string.IsNullOrEmpty(searchTerm) || z.NameAr.Contains(searchTerm) || z.NameEn.Contains(searchTerm));

            long count = await data.CountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = (lang=="ar-EG") ? z.NameAr : z.NameEn, altText = z.Selector })
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
