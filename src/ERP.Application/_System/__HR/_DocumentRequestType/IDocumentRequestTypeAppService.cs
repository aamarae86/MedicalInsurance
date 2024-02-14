using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._DocumentRequestType
{
   public  interface IDocumentRequestTypeAppService : IDomainService
    {
        Task<Select2PagedResult> GetDocumentRequestTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    
    }
}
