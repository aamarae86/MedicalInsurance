using Abp.Application.Services;
using ERP._System._ApBankAccounts.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApBankAccounts
{
    public interface IApBankAccountsAppService:
        IAsyncCrudAppService<ApBankAccountsDto, long, PagedApBankAccountsResultRequestDto, CreateApBankAccountsDto, ApBankAccountsDto>
    {
        Task<Select2PagedResult> GetApBankAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetUserAccessedApBankAccountsSelect2(long? bankLkpId , string searchTerm, int pageSize, int pageNumber, string lang);

        Task<List<ApBankAccounts>> GetAllApBankAccountsByBankId(long bankId);
        Task<Select2PagedResult> GetApBankAccountsByBankIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long BankId);

        Task<ApBankAccountsDto> GetBankAccountByNameAsync(string name);
    }
}
