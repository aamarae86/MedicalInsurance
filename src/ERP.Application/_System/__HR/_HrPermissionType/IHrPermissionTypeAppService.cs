using Abp.Application.Services;
using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPermissionType
{
   public interface IHrPermissionTypeAppService : IDomainService
    {
        Task<Select2PagedResult> GetPermissionTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
