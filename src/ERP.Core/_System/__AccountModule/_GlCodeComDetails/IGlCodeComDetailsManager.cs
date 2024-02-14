using Abp.Domain.Services;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlCodeComDetails
{
    public interface IGlCodeComDetailsManager : IDomainService
    {
        Task<List<long>> CreateAndRetrieveCodeComListId(List<string> codeComUtilityIds);
        Task<long?> CreateAndRetrieveCodeComOneId(string codeComUtilityIds);
        Task<(string ids, string texts)> GetCodeComTextsIds(GlCodeComDetails glCodeComDetails, string lang = "ar-EG");
        Task<(string namesAr, string namesEn, string codes)> GetAttrNamesCodesNames(GlCodeComDetails glCodeComDetails);
        Task<bool> GetACCIDBool(long Id);
    }
}



//Task<List<long>> CreateAndRetrieveCodeComIds<T>(List<T> codeComsUtilites) where T : class;

