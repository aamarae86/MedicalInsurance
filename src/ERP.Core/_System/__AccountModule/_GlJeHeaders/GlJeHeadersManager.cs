using Abp.Domain.Repositories;
using ERP.Core.Helpers.Extensions;
using ERP.Core.Helpers.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlJeHeaders
{
    public class GlJeHeadersManager : IGlJeHeadersManager
    {
        private readonly IRepository<GlJeHeaders, long> _repoGlJeHeaders;

        public GlJeHeadersManager(IRepository<GlJeHeaders, long> repoGlJeHeaders)
        {
            _repoGlJeHeaders = repoGlJeHeaders;
        }

        public async Task<(string, int)> GetJVNNumber(DateTime transDate, long periodId)
        {
            //int month = transDate.Month;
            //string year = transDate.ToString("yy");

            //string JVNNumber = $"{month}{year}0000";

            //var data = _repoGlJeHeaders.GetAll().Where(z => z.PeriodId == periodId).ToList();

            //if (data == null || data.Count() == 0)
            //{
            //    JVNNumber += "1";

            //    return (JVNNumber, 1);
            //}
            //else
            //{
            //    int maxJeNumberKey =  data.Max(z=>z.JeNumberKey);

            //    var lastJVNNumber =  data.Where(z => z.JeNumberKey == maxJeNumberKey).LastOrDefault();

            //    string[] separator = { "0000" };
            //    string key = lastJVNNumber.JeNumber.Split(separator, StringSplitOptions.None)[1];

            //    int newKey = Convert.ToInt32(key) + 1;

            //    JVNNumber += (newKey);

            //    return (JVNNumber, newKey);
            //}
           return (string.Empty, 1);
        }

        //public async Task<List<GlJeHeaders>> LoadPaggedGlAccHeaders(GetAllPagedAndSortedWithParams<GlJeHeaders> parms)
        //{
        //    var data = _repoGlJeHeaders.GetAll();

        //    if (!string.IsNullOrEmpty(parms.Params.JeName))  data = data.Where(z => z.JeName.Contains(parms.Params.JeName));

        //    if (!string.IsNullOrEmpty(parms.Params.JeNumber))  data = data.Where(z => z.JeNumber.Contains(parms.Params.JeNumber));

        //    if (parms.Params.JeDate.Year > 1800)
        //    {
        //        data = data.Where(z => z.JeDate == parms.Params.JeDate);
        //    }

        //    if (parms.Params.StatusLkpId !=null)  data = data.Where(z => z.StatusLkpId == parms.Params.StatusLkpId);

        //    if (parms.Params.JeSourceLkpId !=null) data = data.Where(z => z.JeSourceLkpId == parms.Params.JeSourceLkpId);

        //    if (parms.Params.CurrencyId > 0) data = data.Where(z => z.CurrencyId == parms.Params.CurrencyId);

        //    parms.TotalRecords = data.Count();

        //    var list = await data.DynamicOrderBy(parms.OrderByValue).Skip(parms.PageNumber)
        //                                                     .Take(parms.PageSize)
        //                                                     .ToListAsync();
        //    return list;
        //}
    }
}
