using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApBanks.Dto;
using ERP._System._ApBankAccounts;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._ApBanks.Dto;
using ERP._System._GlAccDetails;
using ERP._System._GlAccounts;
using ERP._System._GlCodeComDetails;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._ApBanks
{
    [AbpAuthorize]
    public class ApBanksAppService :
        AsyncCrudAppService<ApBanks, ApBanksDto, long, PagedApBanksResultRequestDto, CreateApBanksDto, ApBanksEditDto>,
        IApBanksAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IApBankAccountsManager _apBankAccountsManager;
        private readonly IApBanksManager _apBanksManager;
        private readonly IRepository<ApBankAccounts, long> _repoApBankAccounts;

        public ApBanksAppService(IRepository<ApBanks, long> repository,
            IGlCodeComDetailsManager glCodeComDetailsManager, IApBankAccountsManager apBankAccountsManager,
            IRepository<GlAccounts, long> repoGlAccounts, IRepository<GlAccDetails, long> repoGlAccDetails,
            IRepository<ApBankAccounts, long> repoApBankAccounts,
            IApBanksManager apBanksManager) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _apBankAccountsManager = apBankAccountsManager;
            _repoApBankAccounts = repoApBankAccounts;
            _apBanksManager = apBanksManager;

            CreatePermissionName = PermissionNames.Pages_ApBanks_Insert;
            UpdatePermissionName = PermissionNames.Pages_ApBanks_Update;
            DeletePermissionName = PermissionNames.Pages_ApBanks_Delete;
            GetAllPermissionName = PermissionNames.Pages_ApBanks;
        }

        public async Task<Select2PagedResult> GetApBanksSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _apBanksManager.ApBanksSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetPaymentMethod(string searchTerm, int pageSize, int pageNumber, string lang,long? bankAccountId)
        {
            var userId = AbpSession.UserId;
            var tenant = AbpSession.TenantId;
            return await _apBanksManager.GetPaymentMethod(searchTerm, pageSize, pageNumber, lang, userId, tenant, bankAccountId);        
        }

        public async override Task<ApBanksDto> Create(CreateApBanksDto input)
        {
            CheckCreatePermission();

            var current = ApBanks.Create(input.BankNameAr, input.BankNameEn, input.BankTypeLkpId, input.IsActive);

            _ = await Repository.InsertAsync(current);

            foreach (var item in input.ListApBankAccountsDetails)
            {
                var currentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                var currentCodeComCpdcId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);
                var currentCodeComPdcCollId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt2);
                var currentCodeComapPdcCollId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt3);

                var currentBankAcc = ApBankAccounts
                                        .Create(
                                        item.bankAccountNameAr,
                                        item.bankAccountNameEn,
                                        item.currencyId, item.currencyRate,
                                        currentCodeComId,
                                        currentCodeComCpdcId,
                                        currentCodeComPdcCollId,
                                        currentCodeComapPdcCollId,
                                        current.Id,
                                        item.IsActive);

                await _apBankAccountsManager.Create(currentBankAcc);
            }

            return new ApBanksDto();
        }

        public async override Task<ApBanksDto> Update(ApBanksEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            foreach (var item in input.ListApBankAccountsDetails)
            {
                var currentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                var currentCodeComCpdcId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);
                var currentCodeComPdcCollId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt2);
                var currentCodeComapPdcCollId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt3);

                if (item.apBankAccId != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                {
                    var currentAccUpdated = await _repoApBankAccounts.GetAsync((long)item.apBankAccId);

                    var dtoMapped = ObjectMapper.Map(currentAccUpdated, new ApBankAccountsDto());

                    dtoMapped.BankAccountNameAr = item.bankAccountNameAr;
                    dtoMapped.BankAccountNameEn = item.bankAccountNameEn;
                    dtoMapped.CurrencyId = item.currencyId;
                    dtoMapped.BankId = current.Id;
                    dtoMapped.IsActive = item.IsActive;
                    dtoMapped.AccountId = currentCodeComId;
                    dtoMapped.cPdcAccountId = currentCodeComCpdcId;
                    dtoMapped.PdcCollAccountId = currentCodeComPdcCollId;
                    dtoMapped.ApPdcCollAccountId = currentCodeComapPdcCollId;

                    var entityMapped = ObjectMapper.Map(dtoMapped, currentAccUpdated);

                    await _repoApBankAccounts.UpdateAsync(entityMapped);
                }
                else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                {
                    var currentBankAcc = ApBankAccounts
                                         .Create(
                                                 item.bankAccountNameAr,
                                                 item.bankAccountNameEn,
                                                 item.currencyId, item.currencyRate,
                                                 currentCodeComId,
                                                 currentCodeComCpdcId,
                                                 currentCodeComPdcCollId,
                                                 currentCodeComapPdcCollId,
                                                 current.Id,
                                                 item.IsActive);

                    await _apBankAccountsManager.Create(currentBankAcc);
                }
                else if (item.apBankAccId != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                {
                    await _repoApBankAccounts.DeleteAsync((long)item.apBankAccId);
                }

            }

            return new ApBanksDto();
        }

        public async override Task<PagedResultDto<ApBanksDto>> GetAll(PagedApBanksResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.FndLookupValues);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.BankNameAr))
                queryable = queryable.Where(q => q.BankNameAr.Contains(input.Params.BankNameAr));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.BankNameEn))
                queryable = queryable.Where(q => q.BankNameEn.Contains(input.Params.BankNameEn));

            if (input.Params != null && input.Params.BankTypeLkpId != null)
                queryable = queryable.Where(q => q.BankTypeLkpId == input.Params.BankTypeLkpId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ApBanksDto>());

            var PagedResultDto = new PagedResultDto<ApBanksDto>()
            {
                Items = data2 as IReadOnlyList<ApBanksDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<List<ListApBankAccounts>> GetAllApBankAccountsDetails(long bankId)
        {
            var output = new List<ListApBankAccounts>();

            var bankAccounts = await _apBankAccountsManager.GetAllApBankAccountsByBankId(bankId);
            int counter = 0;

            foreach (var item in bankAccounts)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);
                (string idsPdc, string textsPdc) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetailscPdcAccount, _app.Reqlanguage);
                (string idsPdcColl, string textsPdcColl) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetailsPdcCollAccount, _app.Reqlanguage);
                (string idsApPdcColl, string textsApPdcColl) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetailsApPdcCollAccount, _app.Reqlanguage);

                var current = new ListApBankAccounts();

                current.index = ++counter;
                current.apBankAccId = item.Id;
                current.bankAccountNameAr = item.BankAccountNameAr;
                current.bankAccountNameEn = item.BankAccountNameEn;
                current.currencyId = item.CurrencyId;
                current.currencyRate = item.CurrencyRate;
                current.currency = item.Currency.DescriptionEn;
                current.rowStatus = DetailRowStatus.RowStatus.NoAction.ToString();

                current.codeComUtilityIds = ids;
                current.codeComUtilityTexts = texts;

                current.codeComUtilityIds_alt1 = idsPdc;
                current.codeComUtilityTexts_alt1 = textsPdc;

                current.codeComUtilityIds_alt2 = idsPdcColl;
                current.codeComUtilityTexts_alt2 = textsPdcColl;

                current.codeComUtilityIds_alt3 = idsApPdcColl;
                current.codeComUtilityTexts_alt3 = textsApPdcColl;

                output.Add(current);
            }

            return output;
        }

        public async Task<ApBanksDetailDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues).Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map(current, new ApBanksDetailDto());
        }

        public async Task<bool> addingBoolAsync(ApUserBankAccessCustomParmsDto apUserBankAccessCustomParmsDto)
        {
            var bank = _repoApBankAccounts.GetAll().Where(z => z.Id == apUserBankAccessCustomParmsDto.BankId).FirstOrDefaultAsync().Result;
            var current = await Repository.GetAll().Where(z => z.Id == bank.BankId).FirstOrDefaultAsync();
            if (current.BankTypeLkpId == 35 && apUserBankAccessCustomParmsDto.IsPrimaryCash == true)
            {
                return false;
            }
            return true;
        }

        public async Task<ApBanksDto> GetBankByNameAsync(string name)
        {
            var current = await Repository.FirstOrDefaultAsync(z => z.TenantId == AbpSession.TenantId && z.BankNameEn == name);

            var mapped = ObjectMapper.Map<ApBanksDto>(current);

            return mapped;
        }
        public async Task<List<ApBanksDto>> GetBankListByType(long typeId)
        {
            var current = await Repository.GetAllListAsync(z => z.TenantId == AbpSession.TenantId && z.BankTypeLkpId == typeId);

            var mapped = ObjectMapper.Map<List<ApBanksDto>>(current);

            return mapped;
        }
        public async override Task Delete(EntityDto<long> input)
        {
            var listDetails = await _repoApBankAccounts.GetAll().Where(z => z.BankId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var bankAccId in listDetails)
                await _repoApBankAccounts.DeleteAsync(bankAccId);

            await Repository.DeleteAsync(input.Id);
        }
    }
}
