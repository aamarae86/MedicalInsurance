using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScFndAidRequestType
{
    public interface IScFndAidRequestTypeManager:IDomainService
    {
        Task<Select2PagedResult> GetAidRequestTypeLkp(string searchTerm, int pageSize, int pageNumber, string lang);
     }
}
