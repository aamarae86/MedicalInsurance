using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._FndUsers
{
    public interface IFndUsersManager : IDomainService
    {
        Task<Select2PagedResult> GetFndUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
