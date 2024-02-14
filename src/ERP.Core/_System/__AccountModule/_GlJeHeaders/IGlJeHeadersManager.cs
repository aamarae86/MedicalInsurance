using Abp.Domain.Services;
using ERP.Core.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlJeHeaders
{
    public interface IGlJeHeadersManager:IDomainService
    {
        Task<(string, int)> GetJVNNumber(DateTime transDate, long periodId);

        //Task<List<GlJeHeaders>> LoadPaggedGlAccHeaders(GetAllPagedAndSortedWithParams<GlJeHeaders> parms);

    }
}
