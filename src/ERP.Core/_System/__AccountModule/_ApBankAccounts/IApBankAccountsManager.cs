using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApBankAccounts
{
    public interface IApBankAccountsManager:IDomainService
    {
        Task<Select2PagedResult> ApBankAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetUserAccessedApBankAccountsSelect2(long? bankLkpId , string searchTerm, int pageSize, int pageNumber, string lang);
        Task<bool> Create(ApBankAccounts ListApBankAccounts);
        Task<List<ApBankAccounts>> GetAllApBankAccountsByBankId(long bankId);
        Task<Select2PagedResult> GetApBankAccountsByBankIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long BankId);
    }
}
