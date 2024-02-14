using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ApBanks.Dto;
using ERP._System._ApBanks.Dto;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApBanks
{
    public interface IApBanksAppService : IAsyncCrudAppService<ApBanksDto, long, PagedApBanksResultRequestDto, CreateApBanksDto, ApBanksEditDto>
    {
        Task<List<ListApBankAccounts>> GetAllApBankAccountsDetails(long bankId);

        Task<ApBanksDetailDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetApBanksSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<bool> addingBoolAsync(ApUserBankAccessCustomParmsDto apUserBankAccessCustomParmsDto);
        Task<ApBanksDto> GetBankByNameAsync(string name);
        Task<List<ApBanksDto>> GetBankListByType(long typeId);
        Task<Select2PagedResult> GetPaymentMethod(string searchTerm, int pageSize, int pageNumber, string lang, long? bankAccountId);
    }
}
