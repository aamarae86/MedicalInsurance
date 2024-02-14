using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ArCustomers
{
    public interface IArCustomersManager : IDomainService
    {
        #region Check if this code is redundant
        Task<ArCustomers> GetAsync(int id);

        Task<ArCustomers> CreateAsync(ArCustomers arCustomers);
        #endregion

        //Task<decimal> GetRate(int id, DateTime? date);
        Task<Select2PagedResult> GetArCustomersBytypeSelect2(string searchTerm, string lang,bool IsCash ,int pageSize, int pageNumber);
        Task<Select2PagedResult> GetArCustomersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetPOSCustomersBytypeSelect2(string searchTerm, string lang, bool IsCash, int pageSize, int pageNumber);
    }
}
