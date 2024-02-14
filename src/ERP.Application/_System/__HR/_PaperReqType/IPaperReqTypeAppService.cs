using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._PaperReqType
{
  public  interface IPaperReqTypeAppService : IDomainService
    {
        Task<Select2PagedResult> GetPaperReqTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
