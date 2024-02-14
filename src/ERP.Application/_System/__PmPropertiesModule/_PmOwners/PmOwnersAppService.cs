using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__PmPropertiesModule._PmOwners.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlCodeComDetails;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmOwners
{
    [AbpAuthorize]
    public class PmOwnersAppService : AsyncCrudAppService<PmOwners, PmOwnersDto, long, PagedPmOwnersResultRequestDto, PmOwnersCreateDto, PmOwnersEditDto>, IPmOwnersAppService
    {
        private readonly IRepository<PmOwnersTaxDetails, long> _repoDetail;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IPmOwnersManager _pmOwnersManager;

        public PmOwnersAppService(IRepository<PmOwners, long> repository,
            IRepository<PmOwnersTaxDetails, long> repoDetail,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IGetCounterRepository repoProcCounter,
            IPmOwnersManager pmOwnersManager) : base(repository)
        {
            this._repoDetail = repoDetail;
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoProcCounter = repoProcCounter;
            _pmOwnersManager = pmOwnersManager;

            CreatePermissionName = PermissionNames.Pages_PmOwners_Insert;
            UpdatePermissionName = PermissionNames.Pages_PmOwners_Update;
            DeletePermissionName = PermissionNames.Pages_PmOwners_Delete;
            GetAllPermissionName = PermissionNames.Pages_PmOwners;
        }

        

        protected override IQueryable<PmOwners> CreateFilteredQuery(PagedPmOwnersResultRequestDto input)
        {
            try
            {
                var queryable = Repository.GetAllIncluding(o => o.FndStatusLkp, o => o.FndCountryLkp, o => o.FndCityLkp, o => o.FndNationalityLkp);

                if (input.Params.CityLkpId.HasValue)
                    queryable = queryable.Where(o => o.CityLkpId == input.Params.CityLkpId.Value);

                if (input.Params.NationalityLkpId.HasValue)
                    queryable = queryable.Where(o => o.NationalityLkpId == input.Params.NationalityLkpId.Value);

                if (input.Params.StatusLkpId.HasValue)
                    queryable = queryable.Where(o => o.StatusLkpId == input.Params.StatusLkpId.Value);

                if (input.Params.Id > 0)
                    queryable = queryable.Where(o => o.Id == input.Params.Id);

                if (!string.IsNullOrEmpty(input.Params.IdNumber))
                    queryable = queryable.Where(o => o.IdNumber.Contains(input.Params.IdNumber));

                if (!string.IsNullOrEmpty(input.Params.HomePhoneNumber))
                    queryable = queryable.Where(o => o.HomePhoneNumber.Contains(input.Params.HomePhoneNumber));

                queryable = queryable.OrderByDescending(x => x.CreationTime);

                return queryable;
            }
            catch (Exception)
            {
                return base.CreateFilteredQuery(input);
            }
        }

        public async override Task<PmOwnersDto> Create(PmOwnersCreateDto input)
        {
            CheckCreatePermission();

            var accountId = await GetAccountId(input.Account);
            var currentAccountId = await GetAccountId(input.CurrentAccount);

            input.AccountId = accountId.HasValue ? accountId.Value : 0;
            input.CurrentAccountId = currentAccountId.HasValue ? currentAccountId.Value : 0;

            input.OwnerNumber = await GetOwnerNumber();

            var current = MapToEntity(input);

            _ = await Repository.InsertAsync(current);

            foreach (var item in input.POTaxDetailsList)
            {
                item.PmOwnerId = current.Id;
                await _repoDetail.InsertAsync(ObjectMapper.Map(item, new PmOwnersTaxDetails()));
            }

            return new PmOwnersDto();
        }

        public async override Task<PmOwnersDto> Update(PmOwnersEditDto input)
        {
            CheckUpdatePermission();

            var accountId = await GetAccountId(input.Account);
            var currentAccountId = await GetAccountId(input.CurrentAccount);

            input.AccountId = accountId.Value;
            input.CurrentAccountId = currentAccountId.Value;

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            if (input.POTaxDetailsList.Count > 0)
            {
                foreach (var item in input.POTaxDetailsList)
                {
                    item.PmOwnerId = current.Id;
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var pmOwnersTaxDetails = await _repoDetail.GetAsync(item.Id);

                        var mapped = ObjectMapper.Map(item, pmOwnersTaxDetails);

                        _ = _repoDetail.Update(pmOwnersTaxDetails);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var taxDetail = ObjectMapper.Map<PmOwnersTaxDetails>(item);

                        _ = await _repoDetail.InsertAsync(taxDetail);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoDetail.DeleteAsync(item.Id);
                    }
                }
            }

            return new PmOwnersDto();
        }

        public async Task<PmOwnersDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll().Include(z => z.FndStatusLkp).Include(z => z.FndNationalityLkp)
                .Include(z => z.FndCountryLkp).Include(z => z.FndCityLkp)
                .Include(z => z.GlCodeComAccount).Include(z => z.GlCodeComCurrentAccount)
                .Include(z => z.BankAccount).Include(z => z.CashAccount)
                .Include(z => z.PmOwnersTaxesDetails).ThenInclude(z => z.FndPmActivityTypeLkp)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();



            var pmOwnersDto = new PmOwnersDto();

            (string Ids, string Texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComAccount, _app.Reqlanguage);

            pmOwnersDto.Account = new CodeComUtility()
            {
                codeComUtilityIds = Ids,
                codeComUtilityTexts = Texts
            };

            (Ids, Texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComCurrentAccount, _app.Reqlanguage);

            pmOwnersDto.CurrentAccount = new CodeComUtility()
            {
                codeComUtilityIds = Ids,
                codeComUtilityTexts = Texts
            };

       
            return ObjectMapper.Map(current, pmOwnersDto);
        }

        public async override Task Delete(EntityDto<long> input)
        {
            var listDetails = await _repoDetail.GetAll().Where(z => z.PmOwnerId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var taxDetailId in listDetails)
                await _repoDetail.DeleteAsync(taxDetailId);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<decimal> GetOwnerActivityTaxPercentage(long ownerId, long activityLkpId)
        {
            var perc = await _repoDetail.GetAll()
                .Where(z => z.PmOwnerId == ownerId && z.PmActivityTypeLkpId == activityLkpId)
                .Select(z => z.TaxPercentage).FirstOrDefaultAsync();

            return perc;
        }

        private async Task<string> GetOwnerNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "PmOwners", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

        public async Task<Select2PagedResult> GetPmOwnersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pmOwnersManager.PmOwnersSelect2(searchTerm, pageSize, pageNumber, lang);

        private async Task<long?> GetAccountId(CodeComUtility input)
             => await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);
    }

}
