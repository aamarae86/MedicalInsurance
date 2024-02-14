using Abp.Domain.Services;
using ERP._System._GlAccHeaders;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlAccDetails
{
    public interface IGlAccDetailsManager : IDomainService
    {
        Task<List<GlAccHeaders>> DrawGlAccController();

        Task<(long[] ids, string[] texts, bool[] isDefArr)> GetDefaultGlAccDetails(string lang = "ar-EG");

        Task<Select2PagedResult> GlAccDetailsSelect2(long glheaderId, long? parentId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<string> RetrieveGlGeHeaderAttr(long glAccDetailsId);

        Task<Select2PagedResult> GetGlAccHeaderDetailsSelect2(long glheaderId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<(string, bool)> NameExist(long? id, string nameAr, string nameEn);

        Task<(string, bool)> CodeExist(long? id, string code, long GlAccHeaderId, long? parentId);

    }

}
