using Abp.Domain.Repositories;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScFndAidRequestType
{
    public class ScFndAidRequestTypeManager : IScFndAidRequestTypeManager
    {

        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;
        private readonly IRepository<ScFndAidRequestType, long> _repoScFndAidRequestType;

        public ScFndAidRequestTypeManager(IRepository<FndLookupValues, long> repoFndLookupValues,
            IRepository<ScFndAidRequestType, long> repoScFndAidRequestType)
        {
            _repoFndLookupValues = repoFndLookupValues;
            _repoScFndAidRequestType = repoScFndAidRequestType;
        }


        public async Task<Select2PagedResult> GetAidRequestTypeLkp(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoScFndAidRequestType.GetAllIncluding(z => z.FndLookupValues)
                     .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.FndLookupValues.NameAr.Contains(searchTerm) : z.FndLookupValues.NameEn.Contains(searchTerm)));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.FndLookupValues.NameAr : z.FndLookupValues.NameEn }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
