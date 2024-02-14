using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__AccountModuleExtend._FaAssets.Proc;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlCodeComDetails;
using ERP._System._GlMainAccounts;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders
{
    [AbpAuthorize]
    public class GlJeIntegrationHeadersAppService : AsyncCrudAppService<GlJeIntegrationHeaders, GlJeIntegrationHeadersDto, long, GlJeIntegrationHeadersPagedDto, GlJeIntegrationHeadersCreateDto, GlJeIntegrationHeadersEditDto>,
        IGlJeIntegrationHeadersAppService
    {
        private readonly IRepository<GlMainAccounts, long> _repoGlMainAccounts;
        private readonly IRepository<GlJeIntegrationLines, long> _repoGlJeIntegrationLines;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IFaAssetsPostRepository _faAssetsPostRepository;
        private readonly GlJeIntegrationHeadersManager _glJeIntegrationHeadersManager;
        private const string customerAccountTrigger = "Customer", vendorAccountTrigger = "Vendor";

        public GlJeIntegrationHeadersAppService(IRepository<GlJeIntegrationHeaders, long> repository,
            IRepository<GlJeIntegrationLines, long> repoGlJeIntegrationLines,
            IRepository<GlMainAccounts, long> repoGlMainAccounts,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IFaAssetsPostRepository faAssetsPostRepository,
            GlJeIntegrationHeadersManager glJeIntegrationHeadersManager,
            IGetCounterRepository getCounterRepository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;
            _repoGlMainAccounts = repoGlMainAccounts;
            _repoGlJeIntegrationLines = repoGlJeIntegrationLines;
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _faAssetsPostRepository = faAssetsPostRepository;
            _glJeIntegrationHeadersManager = glJeIntegrationHeadersManager;

            CreatePermissionName = PermissionNames.Pages_GlJeIntegrationHeaders_Insert;
            UpdatePermissionName = PermissionNames.Pages_GlJeIntegrationHeaders_Update;
            DeletePermissionName = PermissionNames.Pages_GlJeIntegrationHeaders_Delete;
            GetAllPermissionName = PermissionNames.Pages_GlJeIntegrationHeaders;
        }

        protected override IQueryable<GlJeIntegrationHeaders> CreateFilteredQuery(GlJeIntegrationHeadersPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.FndGlJeIntegrationSourceLkp, x => x.GlPeriodsDetails, x => x.Currency);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.JeName))
                iqueryable = iqueryable.Where(z => z.JeName.Contains(input.Params.JeName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.GlJeIntegrationNumber))
                iqueryable = iqueryable.Where(z => z.GlJeIntegrationNumber.Contains(input.Params.GlJeIntegrationNumber));

            if (input.Params != null && input.Params.GlJeIntegrationSourceLkpId != null)
                iqueryable = iqueryable.Where(z => z.GlJeIntegrationSourceLkpId == input.Params.GlJeIntegrationSourceLkpId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.CurrencyId != null)
                iqueryable = iqueryable.Where(z => z.CurrencyId == input.Params.CurrencyId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.GlJeIntegrationDate))
                iqueryable = iqueryable.Where(z => z.GlJeIntegrationDate == DateTimeController.ConvertToDateTime(input.Params.GlJeIntegrationDate));

            return iqueryable;
        }

        public async override Task<GlJeIntegrationHeadersDto> Create(GlJeIntegrationHeadersCreateDto input)
        {
            CheckCreatePermission();

            if (input.GlJeIntegrationAccountsLines?.Count == 0) throw new UserFriendlyException("حساب القيد مطلوب !!");

            input.GlJeIntegrationNumber = await GetGlJeIntegrationHeadersNumber();

            var glJeIntegrationHeaders = await base.Create(input);

            if (input.GlJeIntegrationAccountsLines?.Count > 0)
                foreach (var item in input.GlJeIntegrationAccountsLines)
                    await InsertAccountLineData(item, glJeIntegrationHeaders.Id);

            if (input.GlJeIntegrationCustomersLines?.Count > 0)
                foreach (var item in input.GlJeIntegrationCustomersLines)
                    await InsertCustomerLineData(item, glJeIntegrationHeaders.Id);

            if (input.GlJeIntegrationVendorsLines.Count > 0)
                foreach (var item in input.GlJeIntegrationVendorsLines)
                    await InsertVendorLineData(item, glJeIntegrationHeaders.Id);

            return new GlJeIntegrationHeadersDto { };
        }

        public async override Task<GlJeIntegrationHeadersDto> Update(GlJeIntegrationHeadersEditDto input)
        {
            CheckUpdatePermission();

            if (input.GlJeIntegrationAccountsLines?.Count == 0) throw new UserFriendlyException("حساب القيد مطلوب !!");

            _ = await base.Update(input);

            await CRUD_AccountLine(input.GlJeIntegrationAccountsLines, input.Id);
            await CRUD_CustomerLine(input.GlJeIntegrationCustomersLines, input.Id);
            await CRUD_VendorLine(input.GlJeIntegrationVendorsLines, input.Id);

            return new GlJeIntegrationHeadersDto { };
        }

        public async override Task<GlJeIntegrationHeadersDto> Get(EntityDto<long> input)
            => ObjectMapper.Map<GlJeIntegrationHeadersDto>(await Repository
                           .GetAllIncluding(z => z.Currency, z => z.GlPeriodsDetails, z => z.FndGlJeIntegrationSourceLkp, z => z.FndStatusLkp)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<List<GlJeIntegrationAccountsLinesDto>> GetAllAccountLineData(EntityDto<long> input, string lang)
        {
            
            var listData = await _repoGlJeIntegrationLines.GetAllIncluding(z => z.GlCodeComDetails,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr1,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr2,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr3,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr4,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr5,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr6,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr7,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr8,
                                        z => z.GlCodeComDetails.GlAccDetailsAttr9,
                                        z => z.GlCodeComDetails.GlAccounts)
                                .Where(d => d.GlJeIntegrationHeaderId == input.Id && d.ArCustomerId == null && d.ApVendorId == null).ToListAsync();

            foreach (var item in listData)           
                item.Lang = lang;

            return ObjectMapper.Map<List<GlJeIntegrationAccountsLinesDto>>(listData);
        }

        public async Task<List<GlJeIntegrationCustomersLinesDto>> GetAllCustomerLineData(EntityDto<long> input)
        {
            var listData = await _repoGlJeIntegrationLines.GetAllIncluding(z => z.ArCustomers)
                                .Where(d => d.GlJeIntegrationHeaderId == input.Id && d.ArCustomerId != null && d.ApVendorId == null).ToListAsync();

            return ObjectMapper.Map<List<GlJeIntegrationCustomersLinesDto>>(listData);
        }

        public async Task<List<GlJeIntegrationVendorsLinesDto>> GetAllVendorLineData(EntityDto<long> input)
        {
            var listData = await _repoGlJeIntegrationLines.GetAllIncluding(z => z.ApVendors)
                                 .Where(d => d.GlJeIntegrationHeaderId == input.Id && d.ArCustomerId == null && d.ApVendorId != null).ToListAsync();

            return ObjectMapper.Map<List<GlJeIntegrationVendorsLinesDto>>(listData);
        }

        public async Task<PostOutput> PostGlJeIntegrationHeaders(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _faAssetsPostRepository.Execute(postDto, "GlJeIntegrationHeadersPost");

            return result.FirstOrDefault();
        }

        public async Task<Select2PagedResult> GetGlJeIntegration_Headers_Line_Cr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
                   => await _glJeIntegrationHeadersManager.GetGlJeIntegration_Headers_Line_Cr_NumSelect2(ArCustomerId, pageSize, pageNumber, lang);
        public async Task<Select2PagedResult> GetGlJeIntegration_Headers_Line_Dr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
                   => await _glJeIntegrationHeadersManager.GetGlJeIntegration_Headers_Line_Dr_NumSelect2(ArCustomerId, pageSize, pageNumber, lang);
        

        #region Assets Methods

        private async Task InsertAccountLineData(GlJeIntegrationAccountsLinesDto accountsLinesDto, long parentId)
        {
            accountsLinesDto.JeIntegrationLineTypeLkpId = 919; // AccountType
            accountsLinesDto.GlJeIntegrationHeaderId = parentId;
            accountsLinesDto.AccountId = await GetAccountLineCodeComAccountId(accountsLinesDto.codeComUtilityIds);

            var glJeIntegrationAccounts = ObjectMapper.Map<GlJeIntegrationLines>(accountsLinesDto);

            _ = await _repoGlJeIntegrationLines.InsertAsync(glJeIntegrationAccounts);
        }

        private async Task InsertCustomerLineData(GlJeIntegrationCustomersLinesDto customersLinesDto, long parentId)
        {
            customersLinesDto.JeIntegrationLineTypeLkpId = 920; // CustomerType
            customersLinesDto.GlJeIntegrationHeaderId = parentId;
            customersLinesDto.AccountId = await GetAccountIdFromGlMainAccount(customerAccountTrigger);

            var glJeIntegrationCustomers = ObjectMapper.Map<GlJeIntegrationLines>(customersLinesDto);

            _ = await _repoGlJeIntegrationLines.InsertAsync(glJeIntegrationCustomers);
        }

        private async Task InsertVendorLineData(GlJeIntegrationVendorsLinesDto vendorsLinesDto, long parentId)
        {
            vendorsLinesDto.JeIntegrationLineTypeLkpId = 921; // VendorType
            vendorsLinesDto.GlJeIntegrationHeaderId = parentId;
            vendorsLinesDto.AccountId = await GetAccountIdFromGlMainAccount(vendorAccountTrigger);

            var glJeIntegrationLines = ObjectMapper.Map<GlJeIntegrationLines>(vendorsLinesDto);

            _ = await _repoGlJeIntegrationLines.InsertAsync(glJeIntegrationLines);
        }

        private async Task CRUD_AccountLine(ICollection<GlJeIntegrationAccountsLinesDto> accountsLinesDtos, long parentId)
        {
            try
            {
                if (accountsLinesDtos?.Count > 0)
                {
                    foreach (var item in accountsLinesDtos)
                    {
                        if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var line = await _repoGlJeIntegrationLines.GetAsync((long)item.Id);

                            item.GlJeIntegrationHeaderId = parentId;
                            item.JeIntegrationLineTypeLkpId = 919;
                            item.AccountId = await GetAccountLineCodeComAccountId(item.codeComUtilityIds);

                            ObjectMapper.Map(item, line);

                            _ = await _repoGlJeIntegrationLines.UpdateAsync(line);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            await InsertAccountLineData(item, parentId);
                        }
                        else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoGlJeIntegrationLines.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private async Task CRUD_CustomerLine(ICollection<GlJeIntegrationCustomersLinesDto> customersLinesDtos, long parentId)
        {
            try
            {
                if (customersLinesDtos?.Count > 0)
                {
                    foreach (var item in customersLinesDtos)
                    {
                        if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var line = await _repoGlJeIntegrationLines.GetAsync((long)item.Id);

                            item.GlJeIntegrationHeaderId = parentId;
                            item.JeIntegrationLineTypeLkpId = 920;
                            item.AccountId = await GetAccountIdFromGlMainAccount(customerAccountTrigger);

                            ObjectMapper.Map(item, line);

                            _ = await _repoGlJeIntegrationLines.UpdateAsync(line);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            await InsertCustomerLineData(item, parentId);
                        }
                        else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoGlJeIntegrationLines.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task CRUD_VendorLine(ICollection<GlJeIntegrationVendorsLinesDto> vendorsLinesDtos, long parentId)
        {
            try
            {
                if (vendorsLinesDtos?.Count > 0)
                {
                    foreach (var item in vendorsLinesDtos)
                    {
                        if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var line = await _repoGlJeIntegrationLines.GetAsync((long)item.Id);

                            item.GlJeIntegrationHeaderId = parentId;
                            item.JeIntegrationLineTypeLkpId = 921;
                            item.AccountId = await GetAccountIdFromGlMainAccount(vendorAccountTrigger);

                            ObjectMapper.Map(item, line);

                            _ = await _repoGlJeIntegrationLines.UpdateAsync(line);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            await InsertVendorLineData(item, parentId);
                        }
                        else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoGlJeIntegrationLines.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<long> GetAccountLineCodeComAccountId(string codeComUtilityIds)
        {
            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(codeComUtilityIds);

            if (currentComCodeId == null) throw new UserFriendlyException("Account Required!!");

            return (long)currentComCodeId;
        }

        private async Task<long> GetAccountIdFromGlMainAccount(string trigger)
        {
            var current = await _repoGlMainAccounts
                           .FirstOrDefaultAsync(z => z.TenantId == (int)AbpSession.TenantId && z.IsActive && z.ReferenceCode == trigger);

            if (current == null || current.AccountId == null) throw new UserFriendlyException($"{trigger} Account Required!!");

            return (long)current.AccountId;
        }

        private async Task<string> GetGlJeIntegrationHeadersNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "GlJeIntegrationHeaders", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }

        #endregion
    }
}
