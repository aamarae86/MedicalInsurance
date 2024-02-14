using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlMainAccounts
{
    public interface IGlMainAccountsManager:IDomainService
    {
        Task<Select2PagedResult> GetGlMainAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
