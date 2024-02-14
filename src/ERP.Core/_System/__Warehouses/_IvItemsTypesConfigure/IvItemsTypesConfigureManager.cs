using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvItemsTypesConfigure
{
    public class IvItemsTypesConfigureManager : IIvItemsTypesConfigureManager
    {
        private readonly IRepository<IvItemsTypesConfigure, long> _repoIvItemsTypesConfigure;

        public IvItemsTypesConfigureManager(IRepository<IvItemsTypesConfigure, long> repoIvItemsTypesConfigure)
        {
            _repoIvItemsTypesConfigure = repoIvItemsTypesConfigure;
        }

        public async Task<Select2PagedResult> GetIvItemsTypesConfigureSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoIvItemsTypesConfigure.GetAll()
                 .Where(z => (string.IsNullOrEmpty(searchTerm) || z.NameAr.Contains(searchTerm) || z.NameEn.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.NameAr : z.NameEn })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetIvItemsTypesConfigureWithParentSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = (from Child in _repoIvItemsTypesConfigure.GetAll()
                        join Parent in _repoIvItemsTypesConfigure.GetAll() on Child.ParentId equals Parent.Id
                        where Child.ParentId != null
                        select new { Child = Child, Parent = Parent }).Where(z => (string.IsNullOrEmpty(searchTerm) || z.Child.NameAr.Contains(searchTerm) || z.Child.NameEn.Contains(searchTerm) || z.Parent.NameAr.Contains(searchTerm) || z.Parent.NameEn.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Child.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Child.Id, text = lang == "ar-EG" ? z.Parent.NameAr+"-"+z.Child.NameAr : z.Parent.NameEn+"-"+z.Child.NameEn })
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
