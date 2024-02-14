using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._FndLookupValues
{
    public interface IFndLookupValuesManager : IDomainService
    {

        // Task<long> GetIdFndLookup(long typeLkp);

        Task<string> GetAttributeLkpName(long lkpId);

        Task<Select2PagedResult> GetFndLookupValuesExcludingIdsSelect2(string type, string ids, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetFndLookupValuesSelect2(string type, string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetFndLookupValuesCampainsDetailsSelect2(string type, string searchTerm, int pageSize, int pageNumber, string lang);


        Task<Select2PagedResult> GetAttributesFndLookupValuesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetFndLookupValuesWithParentIdSelect2(string parentId, string type, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
