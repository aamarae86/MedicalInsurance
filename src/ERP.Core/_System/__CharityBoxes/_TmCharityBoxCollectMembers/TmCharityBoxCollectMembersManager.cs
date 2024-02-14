using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers
{
    public class TmCharityBoxCollectMembersManager : ITmCharityBoxCollectMembersManager
    {
        private readonly IRepository<TmCharityBoxCollectMembers, long> _repoTmCharityBoxCollectMembers;

        public TmCharityBoxCollectMembersManager(IRepository<TmCharityBoxCollectMembers, long> repoTmCharityBoxCollectMembers)
        {
            _repoTmCharityBoxCollectMembers = repoTmCharityBoxCollectMembers;
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoTmCharityBoxCollectMembers.GetAllIncluding(x => x.FndMemberCategoryValues)
               .Where(z =>
                z.IsActive &&
                (string.IsNullOrEmpty(searchTerm) || (z.MemberName.Contains(searchTerm))));

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(z => new Select2OptionModel
                { id = z.Id, text = z.MemberName, altText = $"{z.MemberNumber}__{z.FndMemberCategoryValues.NameAr}" }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
