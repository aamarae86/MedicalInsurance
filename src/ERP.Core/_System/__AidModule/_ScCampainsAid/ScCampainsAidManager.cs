using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System._ScCampainsAid
{
    public class ScCampainsAidManager : IScCampainsAidManager
    {
        private readonly IRepository<ScCampainsAid, long> _repoScCampainsAid;

        public ScCampainsAidManager(IRepository<ScCampainsAid, long> repoScCampainsAid)
        {
            _repoScCampainsAid = repoScCampainsAid;
        }

        public async Task<Select2PagedResult> GetScCampainsAidSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoScCampainsAid.GetAll()
              .Where(z =>
               string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.AidName.Contains(searchTerm) : z.AidName.Contains(searchTerm)))
              .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.AidName : z.AidName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
