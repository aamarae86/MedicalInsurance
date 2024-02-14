using Abp.Domain.Repositories;
using ERP._System._GlAccHeaders;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._FndLookupValues
{
    public class FndLookupValuesManager : IFndLookupValuesManager
    {
        private readonly IGlAccHeadersManager _glAccHeadersManager;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;

        public FndLookupValuesManager(
            IRepository<FndLookupValues, long> repoFndLookupValues,
            IGlAccHeadersManager glAccHeadersManager)
        {
            _repoFndLookupValues = repoFndLookupValues;
            _glAccHeadersManager = glAccHeadersManager;
        }

        public async Task<string> GetAttributeLkpName(long lkpId)
        {
            var data = await _repoFndLookupValues.GetAsync(lkpId);

            return data.NameEn;
        }

        public async Task<Select2PagedResult> GetAttributesFndLookupValuesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var headerIds = await _glAccHeadersManager.LoadGlAccAttributeAllIDs();

            var data = _repoFndLookupValues.GetAll()
                 .Where(z => z.YesNo && z.LookupType == "AccAttributes" && !headerIds.Contains(z.Id) && string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.NameAr.Contains(searchTerm) : z.NameEn.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.NameAr : z.NameEn })
                .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetFndLookupValuesSelect2(string type, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoFndLookupValues.GetAll()
                    .Where(z => z.YesNo && z.LookupType == type && (string.IsNullOrEmpty(searchTerm) || z.NameAr.Contains(searchTerm) || z.NameEn.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data
                        .OrderBy(q => q.Id)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.NameAr : z.NameEn })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetFndLookupValuesExcludingIdsSelect2(string type, string ids, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var numbers = ids.Split(',').Select(long.Parse).ToList();

            var data = _repoFndLookupValues.GetAll()
                    .Where(z => z.YesNo && z.LookupType == type && !numbers.Contains(z.Id) && (string.IsNullOrEmpty(searchTerm) || z.NameAr.Contains(searchTerm) || z.NameEn.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data
                        .OrderBy(q => q.Id)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.NameAr : z.NameEn })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetFndLookupValuesCampainsDetailsSelect2(string type, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoFndLookupValues.GetAll()
                    .Where(z => z.YesNo && !string.IsNullOrEmpty(searchTerm) ? (z.NameAr.Contains(searchTerm) && z.LookupType == type && z.Id != 145) || (z.NameEn.Contains(searchTerm) && z.LookupType == type && z.Id != 145) : z.LookupType == type && z.Id != 145);

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.NameAr : z.NameEn })
                .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetFndLookupValuesWithParentIdSelect2(string parentId, string type, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoFndLookupValues.GetAll()
                    .Where(z => z.YesNo && z.LookupType == type && z.ParentId.ToString() == parentId && (string.IsNullOrEmpty(searchTerm) || z.NameAr.Contains(searchTerm) || z.NameEn.Contains(searchTerm)));

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

        //public async Task<long> GetIdFndLookup(long typeLkpId)
        //    => await _repoFndLookupValues
        //             .GetAll().Where(z => z.Id == typeLkpId)
        //             .Select(z => z.Id)
        //             .FirstOrDefaultAsync();
    }
}
