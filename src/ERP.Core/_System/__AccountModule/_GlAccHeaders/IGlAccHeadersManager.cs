using Abp.Domain.Services;
using ERP.Core.Helpers.Parameters;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlAccHeaders
{
    public interface IGlAccHeadersManager : IDomainService
    {
        Task<List<GlAccHeaders>> GetAllGlHeadersOrderd();

        Task<List<long>> LoadGlAccAttributeAllIDs();

        Task<Select2PagedResult> GetGlAccHeadersSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string trigger, long? UpdatedId);

    }
}
