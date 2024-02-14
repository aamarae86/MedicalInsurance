using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP.Core.Helpers.Parameters;
using ERP.Core.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using ERP.Helpers.Core;
using System.Linq;
using ERP._System._FndLookupValues;

namespace ERP._System._GlAccHeaders
{
    public class GlAccHeadersManager : IGlAccHeadersManager
    {
        private readonly IRepository<GlAccHeaders, long> _repoGlAccHeaders;

        public GlAccHeadersManager(IRepository<GlAccHeaders, long> repoGlAccHeaders)
        {
            _repoGlAccHeaders = repoGlAccHeaders;
        }

        public async Task<Select2PagedResult> GetGlAccHeadersSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string trigger, long? updatedId)
        {
            var data = await _repoGlAccHeaders.GetAll()
                  .Where(z =>
                   (trigger == "Update" && updatedId != null ? z.Id != updatedId && z.ParentId != updatedId : true) &&
                   string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.NameAr.Contains(searchTerm) : z.NameEn.Contains(searchTerm)))
                  .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.NameAr : z.NameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<List<long>> LoadGlAccAttributeAllIDs()
            => await _repoGlAccHeaders.GetAll().GroupBy(z => z.AttributeLkpId).Select(z => z.First().AttributeLkpId).ToListAsync<long>();

        public async Task<List<GlAccHeaders>> GetAllGlHeadersOrderd()
        {
            var data = await _repoGlAccHeaders.GetAllListAsync();
            var orderdData = data.OrderBy(z => z.ShowOrder).ToList();

            return orderdData;
        }


    }
}
