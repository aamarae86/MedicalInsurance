using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._ApBankAccounts.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._ApBankAccounts
{
    [AbpAuthorize]
    public class ApBankAccountsAppService : AsyncCrudAppService<ApBankAccounts, ApBankAccountsDto, long, PagedApBankAccountsResultRequestDto, CreateApBankAccountsDto, ApBankAccountsDto>,
        IApBankAccountsAppService
    {
        private readonly IApBankAccountsManager _apBankAccountsManager;

        public ApBankAccountsAppService(
            IRepository<ApBankAccounts, long> repository,
            IApBankAccountsManager apBankAccountsManager)
            : base(repository)
        {
            _apBankAccountsManager = apBankAccountsManager;
        }

        public async Task<Select2PagedResult> GetApBankAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            return await _apBankAccountsManager.ApBankAccountsSelect2(searchTerm, pageSize, pageNumber, lang);
        }
        public async Task<Select2PagedResult> GetApBankAccountsByBankIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long BankId)
        {
            return await _apBankAccountsManager.GetApBankAccountsByBankIdSelect2(searchTerm, pageSize, pageNumber, lang, BankId);
        }

        public async Task<List<ApBankAccounts>> GetAllApBankAccountsByBankId(long bankId)
            => await _apBankAccountsManager.GetAllApBankAccountsByBankId(bankId);

        public async Task<ApBankAccountsDto> GetBankAccountByNameAsync(string name)
        {
            var current = await Repository.FirstOrDefaultAsync(z => z.TenantId == AbpSession.TenantId&& z.BankAccountNameEn == name);

            var mapped = ObjectMapper.Map<ApBankAccountsDto>(current);

            return mapped;
        }

        public async Task<Select2PagedResult> GetUserAccessedApBankAccountsSelect2(long? bankLkpId, string searchTerm, int pageSize, int pageNumber, string lang)
        => await _apBankAccountsManager.GetUserAccessedApBankAccountsSelect2(bankLkpId, searchTerm, pageSize, pageNumber, lang);
    }
}
