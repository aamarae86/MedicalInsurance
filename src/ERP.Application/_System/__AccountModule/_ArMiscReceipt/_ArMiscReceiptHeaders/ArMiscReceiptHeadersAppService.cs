#region USINGS
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ArMiscReceipt._ArMiscReceiptHeaders.Dto;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System._ArMiscReceipt._ArMiscReceiptDetails.Dto;
using ERP._System._ArMiscReceipt._ArMiscReceiptHeaders.Dto;
using ERP._System._ArMiscReceipt._ArMiscReceiptLines.Dto;
using ERP._System._ArMiscReceiptDetails;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._ArMiscReceiptHeaders.ProcDto;
using ERP._System._ArMiscReceiptHeaders.Procs;
using ERP._System._ArMiscReceiptLines;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ERP._System._FndLookupValues.Dto.FndEnum;
#endregion

namespace ERP._System._ArMiscReceipt._ArMiscReceiptHeaders
{
    [AbpAuthorize]
    public class ArMiscReceiptHeadersAppService : AsyncCrudAppService<ArMiscReceiptHeaders, ArMiscReceiptHeadersDto, long, PagedArMiscReceiptHeadersRequestDto, CreateArMiscReceiptHeadersDto, ArMiscReceiptHeadersEditDto>
        , IArMiscReceiptHeadersAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly ISpContractDetailsManager _spContractDetailsManager;
        private readonly IRepository<ArMiscReceiptDetails, long> _repoArMiscReceiptDetails;
        private readonly IRepository<ArMiscReceiptLines, long> _repoArMiscReceiptLines;
        private readonly IArMiscReceiptHeadersRepository _repoForStored;
        private readonly IGetMiscReceiptScreenDataRepository _repoMiscReceiptScreen;

        public ArMiscReceiptHeadersAppService(IRepository<ArMiscReceiptHeaders, long> repository,
            IRepository<ArMiscReceiptDetails, long> repoArMiscReceiptDetails,
            IRepository<ArMiscReceiptLines, long> repoArMiscReceiptLines,
            ISpContractDetailsManager spContractDetailsManager,
            IArMiscReceiptHeadersRepository repoForStored, IGlCodeComDetailsManager glCodeComDetailsManager,
            IGetCounterRepository repoProcCounter, IGetMiscReceiptScreenDataRepository repoMiscReceiptScreen
            ) : base(repository)
        {
            _spContractDetailsManager = spContractDetailsManager;
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoForStored = repoForStored;
            _repoArMiscReceiptDetails = repoArMiscReceiptDetails;
            _repoArMiscReceiptLines = repoArMiscReceiptLines;
            _repoProcCounter = repoProcCounter;
            _repoMiscReceiptScreen = repoMiscReceiptScreen;

            CreatePermissionName = PermissionNames.Pages_ArMiscReceiptHeaders_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArMiscReceiptHeaders_Update;
            DeletePermissionName = PermissionNames.Pages_ArMiscReceiptHeaders_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArMiscReceiptHeaders;
        }

        public async override Task<PagedResultDto<ArMiscReceiptHeadersDto>> GetAll(PagedArMiscReceiptHeadersRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.FndLookupValuesPostedLkp, x => x.ArMiscReceiptDetails,
                          x => x.ArMiscReceiptLines, x => x.SpBeneficent);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ReceiptNumber))
                queryable = queryable.Where(q => q.ReceiptNumber.Contains(input.Params.ReceiptNumber));

            if (input.Params != null && input.Params.Amount != null)
                queryable = queryable.Where(q => q.Amount == input.Params.Amount);

            if (input.Params != null && input.Params.PostedLkpId != null)
                queryable = queryable.Where(q => q.PostedLkpId == input.Params.PostedLkpId);

            if (input.Params != null && input.Params.SourceCodeLkpId != null)
                queryable = queryable.Where(q => q.SourceCodeLkpId == input.Params.SourceCodeLkpId);

            if (input.Params != null && input.Params.BeneficentId != null)
                queryable = queryable.Where(q => q.BeneficentId == input.Params.BeneficentId);

            if (input.Params != null && input.Params.SpContractDetailsId != null)
                queryable = queryable.Where(q => q.ArMiscReceiptLines.Any(z => z.SpContractDetailsId == input.Params.SpContractDetailsId));

            if (input.Params != null && input.Params.CheckNumber != null)
                queryable = queryable.Where(q => q.ArMiscReceiptDetails != null && q.ArMiscReceiptDetails.Select(v => v.CheckNumber).Contains(input.Params.CheckNumber));

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArMiscReceiptHeadersDto>());

            var PagedResultDto = new PagedResultDto<ArMiscReceiptHeadersDto>()
            {
                Items = data2 as IReadOnlyList<ArMiscReceiptHeadersDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<ArMiscReceiptHeadersDto> Create(CreateArMiscReceiptHeadersDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "ArMiscReceiptHeaders", TenantId = (int)AbpSession.TenantId, Lang = input.Lang, year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.ReceiptNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;

            var current = await base.Create(input);

            if (input.ListArMiscReceiptLinesVM.Count > 0)
            {
                foreach (var item in input.ListArMiscReceiptLinesVM)
                {
                    var currentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                    var adminCurrentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);

                    var currentLine = ArMiscReceiptLines
                        .Create(current.Id, item.miscReceiptAmount, item.AdministrativePercent,
                         item.receiptTypeLkpId, null, currentCodeComId,
                         item.manualReceiptNumber, item.sourceCodeLkpId, null, adminCurrentCodeComId, item.notes, item.SpContractDetailsId);

                    _ = await _repoArMiscReceiptLines.InsertAsync(currentLine);
                }
            }

            if (input.ListArMiscReceiptDetailsVM.Count > 0)
            {
                foreach (var item in input.ListArMiscReceiptDetailsVM)
                {
                    var currentDetail = ArMiscReceiptDetails
                        .Create(current.Id, item.checkNumber,
                        string.IsNullOrEmpty(item.maturityDate) ? null : (DateTime?)DateTimeController.ConvertToDateTime(item.maturityDate),
                        item.bankLkpId, item.amount, item.bankAccountId);

                    _ = await _repoArMiscReceiptDetails.InsertAsync(currentDetail);
                }
            }

            return new ArMiscReceiptHeadersDto();
        }

        public async override Task<ArMiscReceiptHeadersDto> Update(ArMiscReceiptHeadersEditDto input)
        {
            CheckUpdatePermission();

            if (await CheckPostedStatus(input.Id)) return new ArMiscReceiptHeadersDto();

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            #region Lines

            foreach (var item in input.ListArMiscReceiptLinesVM)
            {
                if (item.arMiscReceiptLinesId != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                {
                    var currentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                    var adminCurrentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);

                    var currentGeJeLine = await _repoArMiscReceiptLines.GetAsync((long)item.arMiscReceiptLinesId);

                    var mappedDto = ObjectMapper.Map(currentGeJeLine, new ArMiscReceiptLinesDto());

                    mappedDto.ManualReceiptNumber = item.manualReceiptNumber;
                    mappedDto.MiscReceiptAmount = item.miscReceiptAmount;
                    mappedDto.Notes = item.notes;
                    mappedDto.ReceiptTypeLkpId = item.receiptTypeLkpId;
                    mappedDto.SourceCodeLkpId = item.sourceCodeLkpId;
                    mappedDto.AdministrativePercent = item.AdministrativePercent;
                    mappedDto.AccountId = currentCodeComId;
                    mappedDto.AdminAccountID = adminCurrentCodeComId;
                    mappedDto.SpContractDetailsId = item.SpContractDetailsId;

                    var mappedEntity = ObjectMapper.Map(mappedDto, currentGeJeLine);

                    _ = await _repoArMiscReceiptLines.UpdateAsync(mappedEntity);
                }
                else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                {
                    var currentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                    var adminCurrentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);

                    var line = ArMiscReceiptLines
                        .Create(input.Id, item.miscReceiptAmount, item.AdministrativePercent,
                         item.receiptTypeLkpId, null, currentCodeComId,
                         item.manualReceiptNumber, item.sourceCodeLkpId, null, adminCurrentCodeComId, item.notes, item.SpContractDetailsId);

                    _ = await _repoArMiscReceiptLines.InsertAsync(line);
                }
                else if (item.arMiscReceiptLinesId != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                {
                    await _repoArMiscReceiptLines.DeleteAsync((long)item.arMiscReceiptLinesId);
                }
            }

            #endregion

            #region details

            foreach (var item in input.ListArMiscReceiptDetailsVM)
            {
                if (item.arMiscDetailId != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                {
                    var currentDetail = await _repoArMiscReceiptDetails.GetAsync((long)item.arMiscDetailId);

                    var mappedDto = ObjectMapper.Map(currentDetail, new ArMiscReceiptDetailsDto());

                    mappedDto.Amount = item.amount;
                    mappedDto.BankAccountId = item.bankAccountId;
                    mappedDto.CheckNumber = item.checkNumber;
                    mappedDto.BankLkpId = item.bankLkpId;
                    mappedDto.MaturityDate = string.IsNullOrEmpty(item.maturityDate) ? null : (DateTime?)DateTimeController.ConvertToDateTime(item.maturityDate);

                    var mappedEntity = ObjectMapper.Map(mappedDto, currentDetail);

                    _ = await _repoArMiscReceiptDetails.UpdateAsync(mappedEntity);
                }
                else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                {
                    var dtDetail = string.IsNullOrEmpty(item.maturityDate) ? null : (DateTime?)DateTimeController.ConvertToDateTime(item.maturityDate);

                    var currentDetail = ArMiscReceiptDetails
                         .Create(input.Id, item.checkNumber, dtDetail,
                         item.bankLkpId, item.amount, item.bankAccountId);

                    _ = await _repoArMiscReceiptDetails.InsertAsync(currentDetail);
                }
                else if (item.arMiscDetailId != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                {
                    await _repoArMiscReceiptDetails.DeleteAsync((long)item.arMiscDetailId);
                }
            }
            #endregion

            return new ArMiscReceiptHeadersDto();
        }

        public async Task<List<ListArMiscReceiptDetailsVM>> GetAllArMiscReceiptDetails(long miscReceiptId)
        {
            var data = await _repoArMiscReceiptDetails.GetAllIncluding(z => z.ApBankAccounts, x => x.FndLookupValues)
                                .Where(z => z.MiscReceiptId == miscReceiptId)
                                .ToListAsync();

            var list = new List<ListArMiscReceiptDetailsVM>();
            int counter = 0;

            for (int i = 0; i < data.Count; i++)
            {
                var current = data[i];

                list.Add(new ListArMiscReceiptDetailsVM
                {
                    index = ++counter,
                    amount = current.Amount,
                    miscId = (long)current.MiscReceiptId,
                    arMiscDetailId = current.Id,
                    bankAccountId = current.BankAccountId,
                    bankLkpId = current.BankLkpId,
                    checkNumber = current.CheckNumber,
                    bank = current.FndLookupValues?.NameAr ?? string.Empty,
                    bankAccount = current.ApBankAccounts?.BankAccountNameAr ?? string.Empty,
                    maturityDate = current.MaturityDate == null ? string.Empty : current.MaturityDate.Value.ToString(Formatters.DateFormat),
                });

            }

            return list;
        }

        public async Task<List<ListArMiscReceiptLinesVM>> GetAllArMiscReceiptLines(long miscReceiptId)
        {
            var output = new List<ListArMiscReceiptLinesVM>();

            var lines = await _repoArMiscReceiptLines.GetAllIncluding(z =>
                  z.GlCodeComDetails, x => x.AdminGlCodeComDetails,
                  x => x.SpContractDetails.SpCases,
                x => x.FndLookupValuesReceiptTypeLkp).Where(z => z.MiscReceiptId == miscReceiptId).ToListAsync();

            int counter = 0;

            foreach (var item in lines)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);
                (string adminids, string admintexts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.AdminGlCodeComDetails, _app.Reqlanguage);

                var current = new ListArMiscReceiptLinesVM();

                current.receiptTypeLkpId = item.ReceiptTypeLkpId;
                current.notes = item.Notes;
                current.miscReceiptAmount = item.MiscReceiptAmount;
                current.manualReceiptNumber = item.ManualReceiptNumber;
                current.AdministrativePercent = item.AdministrativePercent;
                current.receiptTypeLkp = item.FndLookupValuesReceiptTypeLkp == null ? string.Empty : item.FndLookupValuesReceiptTypeLkp.NameAr;
                current.index = ++counter;
                current.arMiscReceiptLinesId = item.Id;
                current.miscId = item.MiscReceiptId;
                current.codeComUtilityIds = ids;
                current.codeComUtilityTexts = texts;
                current.codeComUtilityIds_alt1 = adminids;
                current.codeComUtilityTexts_alt1 = admintexts;
                current.SpContractDetailsId = item.SpContractDetailsId;
                current.CaseName = item.SpContractDetails?.SpCases?.CaseName ?? string.Empty;
                current.CaseNumber = item.SpContractDetails?.SpCases?.CaseNumber ?? string.Empty;

                output.Add(current);
            }

            return output;
        }

        public async Task<ArMiscReceiptHeadersDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValuesPostedLkp, x => x.FndReceiptTypeLkp,
                                    x => x.FndLookupValuesSourceCodeLkp, x => x.FndLookupValuesTransactionTypeLkp,
                                    x => x.FndCollectors, x => x.SpBeneficent, x => x.ApBankAccounts)
                              .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map(current, new ArMiscReceiptHeadersDto());
        }

        public async override Task Delete(EntityDto<long> input)
        {
            if (await CheckPostedStatus(input.Id)) return;

            var listDetails = await _repoArMiscReceiptDetails.GetAll().Where(z => z.MiscReceiptId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var id in listDetails)
                await _repoArMiscReceiptDetails.DeleteAsync(id);

            var listLines = await _repoArMiscReceiptLines.GetAll().Where(z => z.MiscReceiptId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var id in listLines)
                await _repoArMiscReceiptLines.DeleteAsync(id);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<PostOutput> PostArMiscReceiptHeader(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }
            var postResult = await _repoForStored.Execute(input, "ArPostMiscReceipt");
            return postResult.FirstOrDefault();
        }

        public async Task<List<MiscReceiptScreenDataOutput>> GetMiscReceipttScreenData(IdLangInputDto input)
        {
            var result = await _repoMiscReceiptScreen.Execute(input, "GetMiscreceipttScreenData");

            return result.ToList();
        }

        private async Task<bool> CheckPostedStatus(long id)
        {
            var current = await Repository.GetAsync(id);

            return current.PostedLkpId == Convert.ToInt64(FndLkps.Posted_ArMiscReceiptHeadersPost);
        }

        public async Task<Select2PagedResult> GetSpCasesWithSpContractDetailsSearchSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spContractDetailsManager.GetSpCasesWithSpContractDetailsSearchSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetSpCasesWithSpContractDetailsSelect2(long beneficentId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spContractDetailsManager.GetSpCasesWithSpContractDetailsSelect2(beneficentId, searchTerm, pageSize, pageNumber, lang);

    }
}
