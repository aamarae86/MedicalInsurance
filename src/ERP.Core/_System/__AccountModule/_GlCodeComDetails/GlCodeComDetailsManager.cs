using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP._System._GlAccDetails;
using ERP._System._GlAccounts;
using ERP._System._GlPeriods;
using ERP.Helpers.Parameters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ERP._System._GlCodeComDetails
{
    public class GlCodeComDetailsManager : IGlCodeComDetailsManager
    {
        private readonly IGlAccDetailsManager _glAccDetailsManager;
        private readonly IRepository<GlCodeComDetails, long> _repoGlCodeComDetails;
        private readonly IRepository<GlAccDetails, long> _repoGlAccDetails;
        private readonly IRepository<GlAccounts, long> _repoGlAccounts;

        public GlCodeComDetailsManager(
            IGlAccDetailsManager glAccDetailsManager,
            IRepository<GlCodeComDetails, long> repoGlCodeComDetails,
            IRepository<GlAccDetails, long> repoGlAccDetails,
            IRepository<GlAccounts, long> repoGlAccounts)
        {
            _glAccDetailsManager = glAccDetailsManager;
            _repoGlCodeComDetails = repoGlCodeComDetails;
            _repoGlAccDetails = repoGlAccDetails;
            _repoGlAccounts = repoGlAccounts;
        }



        #region Create and retreive codeComId
        public async Task<List<long>> CreateAndRetrieveCodeComListId(List<string> codeComUtilityIds)
        {
            var output = new List<long>();

            foreach (var item in codeComUtilityIds)
            {
                List<long> ids = item.Split(',').Select(id => Convert.ToInt64(id)).ToList<long>();

                if (ids.Count == 0) break;

                var current = await GetCodeComId(ids);

                output.Add(current);
            }

            return output;
        }

        public async Task<long?> CreateAndRetrieveCodeComOneId(string codeComUtilityIds)
        {
            if (string.IsNullOrEmpty(codeComUtilityIds)) return null;

            List<long> ids = codeComUtilityIds.Split(',').Select(id => Convert.ToInt64(id)).ToList<long>();

            if (ids.Count == 0) return null;

            var current = await GetCodeComId(ids);

            return current;
        }

        private async Task<long> GetCodeComId(List<long> ids)
        {
            var defDic = GetAttrDictionaryDefault();

            long accId = ids.LastOrDefault();

            ids.RemoveAt(ids.Count - 1);

            foreach (var attrId in ids)
            {
                var attrName = await _glAccDetailsManager.RetrieveGlGeHeaderAttr(attrId);

                if (defDic.Any(z => z.Key == attrName)) defDic[attrName] = attrId;
            }

            var currentCodeComId = await CheckIfCodeComIsExist(
                                        defDic[nameof(GlCodeComDetails.Attribute1)],
                                        defDic[nameof(GlCodeComDetails.Attribute2)],
                                        defDic[nameof(GlCodeComDetails.Attribute3)],
                                        defDic[nameof(GlCodeComDetails.Attribute4)],
                                        defDic[nameof(GlCodeComDetails.Attribute5)],
                                        defDic[nameof(GlCodeComDetails.Attribute6)],
                                        defDic[nameof(GlCodeComDetails.Attribute7)],
                                        defDic[nameof(GlCodeComDetails.Attribute8)],
                                        defDic[nameof(GlCodeComDetails.Attribute9)],
                                        accId);

            if (currentCodeComId != null) return (long)currentCodeComId;
            else
            {
                var newRow = GlCodeComDetails.Create(defDic[nameof(GlCodeComDetails.Attribute1)],
                                          defDic[nameof(GlCodeComDetails.Attribute2)],
                                          defDic[nameof(GlCodeComDetails.Attribute3)],
                                          defDic[nameof(GlCodeComDetails.Attribute4)],
                                          defDic[nameof(GlCodeComDetails.Attribute5)],
                                          defDic[nameof(GlCodeComDetails.Attribute6)],
                                          defDic[nameof(GlCodeComDetails.Attribute7)],
                                          defDic[nameof(GlCodeComDetails.Attribute8)],
                                          defDic[nameof(GlCodeComDetails.Attribute9)],
                                          accId);

                _ = await _repoGlCodeComDetails.InsertAsync(newRow);

                return newRow.Id;
            }
        }
        #endregion

        #region GetCodeComTextsIds

        public async Task<(string ids, string texts)> GetCodeComTextsIds(GlCodeComDetails glCodeComDetails, string lang = "ar-EG")
        {
            string ids = string.Empty, texts = string.Empty;

            lang = string.IsNullOrEmpty(lang) ? "ar-EG" : lang;

            if (glCodeComDetails == null) return (ids, texts);

            const char symbol = ',';

            var current = glCodeComDetails;

            if (current.Attribute1 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute1);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar")? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.Attribute2 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute2);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar") ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.Attribute3 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute3);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar") ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.Attribute4 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute4);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar") ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.Attribute5 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute5);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar") ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.Attribute6 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute6);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar") ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.Attribute7 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute7);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar") ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.Attribute8 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute8);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar") ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.Attribute9 != null)
            {
                var attrCom = await _repoGlAccDetails.GetAsync((long)current.Attribute9);

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang.Contains("ar") ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (current.AccId != null)
            {
                var currentAccount = await _repoGlAccounts.GetAsync((long)current.AccId);

                ids += $"{currentAccount.Id}";
                texts += (lang.Contains("ar") ? $"{currentAccount.DescriptionAr}" : $"{currentAccount.DescriptionEn}");
            }

            return (ids, texts);
        }

        #endregion

        #region CodeComDictionaryHelpers

        private Dictionary<string, long?> GetAttrDictionaryDefault()
        {
            Dictionary<string, long?> keyValuePairs = new Dictionary<string, long?>();

            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute1), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute2), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute3), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute4), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute5), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute6), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute7), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute8), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.Attribute9), null);
            keyValuePairs.Add(nameof(GlCodeComDetails.AccId), null);

            return keyValuePairs;
        }

        private async Task<long?> CheckIfCodeComIsExist(long? attr1, long? attr2, long? attr3, long? attr4,
            long? attr5, long? attr6, long? attr7, long? attr8, long? attr9, long accId)
        {
            var data = await _repoGlCodeComDetails
                        .GetAll()
                        .Where(z =>
                        z.Attribute1 == attr1 &&
                        z.Attribute2 == attr2 &&
                        z.Attribute3 == attr3 &&
                        z.Attribute4 == attr4 &&
                        z.Attribute5 == attr5 &&
                        z.Attribute6 == attr6 &&
                        z.Attribute7 == attr7 &&
                        z.Attribute8 == attr8 &&
                        z.Attribute9 == attr9 &&
                        z.AccId == accId)
                        .FirstOrDefaultAsync();

            return data == null ? null : (long?)data.Id;
        }

        #endregion

        public async Task<(string, string, string)> GetAttrNamesCodesNames(GlCodeComDetails glCodeComDetails)
        {
            string namesAr = string.Empty, namesEn = string.Empty, codes = string.Empty;

            if (glCodeComDetails.Attribute1 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute1);
                namesAr += $"{attr.NameAr}";
                namesEn += $"{attr.NameEn}";
                codes += $"{attr.Code}";
            }

            if (glCodeComDetails.Attribute2 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute2);
                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (glCodeComDetails.Attribute3 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute3);
                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (glCodeComDetails.Attribute4 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute4);
                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (glCodeComDetails.Attribute5 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute5);
                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (glCodeComDetails.Attribute6 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute6);
                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (glCodeComDetails.Attribute7 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute7);
                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (glCodeComDetails.Attribute8 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute8);
                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (glCodeComDetails.Attribute9 != null)
            {
                var attr = await _repoGlAccDetails.GetAsync((long)glCodeComDetails.Attribute9);
                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (glCodeComDetails.AccId != null)
            {
                var acc = await _repoGlAccounts.GetAsync((long)glCodeComDetails.AccId);
                namesAr += $".{acc.DescriptionAr}";
                namesEn += $".{acc.DescriptionEn}";
                codes += $".{acc.Code}";
            }

            return (namesAr, namesEn, codes);
        }

        public async Task<bool> GetACCIDBool(long Id)
        {
            var entity = await _repoGlCodeComDetails.FirstOrDefaultAsync(x => x.AccId == Id);
            return entity == null;
        }

    }
}
