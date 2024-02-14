using Abp.Domain.Entities;
using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Authorization.Users
{
    public interface ICustomUserManager : IDomainService
    {
        Task<Select2PagedResult> GetUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
