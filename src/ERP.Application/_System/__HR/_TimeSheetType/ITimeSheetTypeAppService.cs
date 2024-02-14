using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._TimeSheetType
{
   public  interface ITimeSheetTypeAppService :IDomainService
    {
        Task<Select2PagedResult> GetTimeSheetTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
