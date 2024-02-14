using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrOrganizations
{
    public class HrOrganizationsManager : IHrOrganizationsManager
    {
        private readonly IRepository<HrOrganizations, long> _repoHrOrganizations;

        public HrOrganizationsManager(IRepository<HrOrganizations, long> repoHrOrganizations)
        {
            _repoHrOrganizations = repoHrOrganizations;
        }

        public async Task<Select2PagedResult> GetHrOrganizationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrOrganizations.GetAll()
                    .Where(z => (string.IsNullOrEmpty(searchTerm) || z.OrganizationName.Contains(searchTerm) || z.ShortName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.OrganizationName })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetHrOrganizationsWithParentSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = (from Child in _repoHrOrganizations.GetAll()
                        join Parent in _repoHrOrganizations.GetAll() on Child.ParentId equals Parent.Id
                        where Child.ParentId != null
                        select new { Child, Parent }).Where(z => (string.IsNullOrEmpty(searchTerm) || z.Child.OrganizationName.Contains(searchTerm) || z.Child.ShortName.Contains(searchTerm) || z.Parent.OrganizationName.Contains(searchTerm) || z.Parent.ShortName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Child.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Child.Id, text = $"{z.Parent.OrganizationName}-{z.Child.OrganizationName}" })
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
