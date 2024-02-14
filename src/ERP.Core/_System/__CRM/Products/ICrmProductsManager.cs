using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CRM.Products
{
    public interface ICrmProductsManager : IDomainService
    {
        Task<Select2PagedResult> GetCrmProductsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
