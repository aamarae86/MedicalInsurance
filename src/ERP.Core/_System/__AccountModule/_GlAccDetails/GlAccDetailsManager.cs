using Abp.Domain.Repositories;
using ERP._System._FndLookupValues;
using ERP._System._GlAccHeaders;
using ERP._System._GlAccounts;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlAccDetails
{
    public class GlAccDetailsManager : IGlAccDetailsManager
    {
        private readonly IGlAccHeadersManager _glAccHeadersManager;
        private readonly IRepository<GlAccDetails, long> _repoGlAccDetails;
        private readonly IRepository<GlAccHeaders, long> _repoGlAccHeaders;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;

        public GlAccDetailsManager(
            IRepository<GlAccDetails, long> repoGlAccDetails,
            IRepository<GlAccHeaders, long> repoGlAccHeaders,
            IRepository<GlAccounts, long> repoGlAccounts,
            IRepository<FndLookupValues, long> repoFndLookupValues,
            IGlAccHeadersManager glAccHeadersManager)
        {
            _repoGlAccDetails = repoGlAccDetails;
            _glAccHeadersManager = glAccHeadersManager;
            _repoGlAccHeaders = repoGlAccHeaders;
            _repoFndLookupValues = repoFndLookupValues;
        }

        public async Task<List<GlAccHeaders>> DrawGlAccController() => await _glAccHeadersManager.GetAllGlHeadersOrderd();

        public async Task<Select2PagedResult> GetGlAccHeaderDetailsSelect2(long glheaderId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var headerRow = await _repoGlAccHeaders.GetAsync(glheaderId);

            if (headerRow == null || headerRow.ParentId == null)
                return new Select2PagedResult { Total = 0, Results = null };

            var data = await _repoGlAccDetails.GetAllIncluding(x => x.GlAccDetail,
                vv => vv.GlAccDetail.GlAccDetail, v => v.GlAccDetail.GlAccDetail.GlAccDetail)
            .Where(z =>
             z.GlAccHeaderId == headerRow.ParentId &&
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.NameAr.Contains(searchTerm) : z.NameEn.Contains(searchTerm)))
            .Select(z => new
            {
                z.Id,
                z.NameAr,
                z.NameEn,
                z.GlAccDetail,
                p1 = z.GlAccDetail.GlAccDetail,
                p2 = z.GlAccDetail.GlAccDetail.GlAccDetail,
                p3 = z.GlAccDetail.GlAccDetail.GlAccDetail.GlAccDetail,
            })
            .ToListAsync();

            var result = data
                .OrderBy(q => q.Id)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(z => new Select2OptionModel
                {
                    id = z.Id,
                    text = lang == "ar-EG" ?
                (z.GlAccDetail == null ? z.NameAr :
                (z.p1 == null ? $"{z.GlAccDetail.NameAr}-{z.NameAr}" : (z.p2 == null ? $"{z.p1.NameAr} - {z.GlAccDetail.NameAr} - {z.NameAr}" : $"{z.p2.NameAr} - {z.p1.NameAr} - {z.GlAccDetail.NameAr} - {z.NameAr}"))) :
                (z.GlAccDetail == null ? z.NameAr :
                (z.p1 == null ? $"{z.GlAccDetail.NameEn}-{z.NameEn}" : (z.p2 == null ? $"{z.p1.NameEn} - {z.GlAccDetail.NameEn} - {z.NameEn}" : $"{z.p2.NameEn} - {z.p1.NameEn} - {z.GlAccDetail.NameEn} - {z.NameEn}")))
                })
                .ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GlAccDetailsSelect2(long glheaderId, long? parentId, string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoGlAccDetails.GetAll()
                .Where(z =>
                 z.GlAccHeaderId == glheaderId &&
                 (parentId == null || z.ParentId == parentId) &&
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

        public async Task<(string, bool)> NameExist(long? id, string nameAr, string nameEn)
        {
            var isExsit = await
                  _repoGlAccDetails.GetAll()
                  .Where(z =>
                  (
                  (string.IsNullOrEmpty(nameEn) || z.NameEn.ToLower() == nameEn.ToLower())
                  )
                  &&
                  (id == null || z.Id != id)
                  )
                  .AnyAsync();

            var isExsit2 = await
                 _repoGlAccDetails.GetAll()
                 .Where(z =>
                 (
                 (string.IsNullOrEmpty(nameAr) || z.NameAr.ToLower() == nameAr.ToLower())
                 )
                 &&
                 (id == null || z.Id != id)
                 )
                 .AnyAsync();

            return (isExsit && isExsit2 ? "ExistBefore" : "valid", isExsit && isExsit2);
        }

        public async Task<(string, bool)> CodeExist(long? id, string code, long GlAccHeaderId, long? parentId)
        {
            var isExsit = await
                       _repoGlAccDetails.GetAll()
                       .Where(z =>
                       z.Code.ToLower().Equals(code.ToLower()) &&
                       (parentId == null || z.ParentId == parentId) &&
                       z.GlAccHeaderId == GlAccHeaderId &&
                       (id == null || z.Id != id)
                       ).AnyAsync();

            return (isExsit ? "CodeBefore" : "valid", isExsit);
        }

        public async Task<string> RetrieveGlGeHeaderAttr(long glAccDetailsId)
        {
            var current = await _repoGlAccDetails.GetAsync(glAccDetailsId);

            var data = await _repoGlAccHeaders.GetAsync(current.GlAccHeaderId);

            var currentAttrLkp = await _repoFndLookupValues.GetAsync(data.AttributeLkpId);

            return currentAttrLkp.NameEn;
        }

        public async Task<(long[] ids, string[] texts, bool[] isDefArr)> GetDefaultGlAccDetails(string lang = "ar-EG")
        {
            var data = await _repoGlAccDetails
                .GetAll()
                .Where(z=>z.IsDefault)
                .GroupBy(z => z.GlAccHeaderId)
                .Select(z => z.FirstOrDefault())
                .ToListAsync();

            long[] ids = new long[9]; bool[] isDefArr = new bool[9]; string[] texts = new string[9];

            for (int i = 0; i < 9; i++)
            {
                if (i < data.Count)
                {
                    var current = data[i];

                    ids[i] = current.Id;
                    texts[i] = lang == "ar-EG" ? current.NameAr : current.NameEn;
                    isDefArr[i] = current.IsDefault;
                }
                else
                {
                    ids[i] = 0;
                    texts[i] = string.Empty;
                    isDefArr[i] = false;
                }
            }

            return (ids, texts, isDefArr);
        }
    }
}
