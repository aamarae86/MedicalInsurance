#region usings
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApMiscPaymentHeaders;
using ERP._System.__AccountModule._ArMiscPayment._ApMiscPaymentHeaders.Dto;
using ERP._System._ApMiscPaymentDetails;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ApMiscPaymentHeaders.ProcDto;
using ERP._System._ApMiscPaymentHeaders.Procs;
using ERP._System._ApMiscPaymentLines;
using ERP._System._ArMiscPayment._ApMiscPaymentDetails.Dto;
using ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto;
using ERP._System._ArMiscPayment._ApMiscPaymentLines.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System._FndTaxType;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
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

namespace ERP._System._ArMiscPayment._ApMiscPaymentHeaders
{
    [AbpAuthorize]
    public class ApMiscPaymentHeadersAppService : AsyncCrudAppService<ApMiscPaymentHeaders, ApMiscPaymentHeadersDto, long, PagedArMiscPaymentHeadersRequestDto, CreateApMiscPaymentHeadersDto, ApMiscPaymentHeadersEditDto>,
                 IApMiscPaymentHeadersAppService
    {
        private readonly IRepository<ApMiscPaymentDetails, long> _repoArMiscPaymentDetails;
        private readonly IRepository<ApMiscPaymentLines, long> _repoArMiscPaymentLines;
        private readonly IRepository<PortalUser, long> _repoPortalUser;
        private readonly IApMiscPaymentHeadersRepository _repoForStored;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGetMiscPaymentScreenDataRepository _repoMiscPaymentScreen;
        private readonly IApMiscPaymentHeadersManager _apMiscPaymentHeadersManager;
        private readonly IRepository<FndTaxType, long> _repoFndTaxTypes;

        public ApMiscPaymentHeadersAppService(IRepository<ApMiscPaymentHeaders, long> repository,
            IRepository<ApMiscPaymentDetails, long> repoArMiscPaymentDetails,
            IRepository<ApMiscPaymentLines, long> repoArMiscPaymentLines,
            IRepository<PortalUser, long> repoPortalUser, IApMiscPaymentHeadersManager apMiscPaymentHeadersManager,
            IApMiscPaymentHeadersRepository repoForStored, IGlCodeComDetailsManager glCodeComDetailsManager,
            IRepository<FndTaxType, long> repoFndTaxTypes,
            IGetCounterRepository repoProcCounter, IGetMiscPaymentScreenDataRepository repoMiscPaymentScreen)
            : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoArMiscPaymentDetails = repoArMiscPaymentDetails;
            _repoArMiscPaymentLines = repoArMiscPaymentLines;
            _repoForStored = repoForStored;
            _repoPortalUser = repoPortalUser;
            _repoProcCounter = repoProcCounter;
            _repoMiscPaymentScreen = repoMiscPaymentScreen;
            _apMiscPaymentHeadersManager = apMiscPaymentHeadersManager;
            _repoFndTaxTypes = repoFndTaxTypes;

            CreatePermissionName = PermissionNames.Pages_ApMiscPaymentHeaders_Insert;
            UpdatePermissionName = PermissionNames.Pages_ApMiscPaymentHeaders_Update;
            DeletePermissionName = PermissionNames.Pages_ApMiscPaymentHeaders_Delete;
            GetAllPermissionName = PermissionNames.Pages_ApMiscPaymentHeaders;
        }


        public async override Task<PagedResultDto<ApMiscPaymentHeadersDto>> GetAll(PagedArMiscPaymentHeadersRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.ApMiscPaymentLines, z => z.FndLookupValuesPostedPaymentLkp,
                                       x => x.ApMiscPaymentLines, x => x.ApMiscPaymentDetails, x => x.FndLookupValuesSourceCodePaymentLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CaseNumber))
                queryable = queryable.Where(q => q.ApMiscPaymentLines.Any(z => z.PoratlCaseNumber.Contains(input.Params.CaseNumber)));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PaymentNumber))
                queryable = queryable.Where(q => q.PaymentNumber.Contains(input.Params.PaymentNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.BeneficentName))
                queryable = queryable.Where(q => q.BeneficiaryName.Contains(input.Params.BeneficentName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CheckNumber))
                queryable = queryable.Where(q => q.ApMiscPaymentDetails.Select(x => x.CheckNumber).Contains(input.Params.CheckNumber));

            if (input.Params != null && input.Params.PortalUsersId != null)
                queryable = queryable.Where(q => q.ApMiscPaymentLines.Any(z => z.PortalUsersId == input.Params.PortalUsersId));

            if (input.Params != null && input.Params.Amount != null)
                queryable = queryable.Where(q => q.Amount == input.Params.Amount);

            if (input.Params != null && input.Params.PostedLkpId != null)
                queryable = queryable.Where(q => q.PostedlkpId == input.Params.PostedLkpId);

            if (input.Params != null && input.Params.SourceCodeLkpId != null)
                queryable = queryable.Where(q => q.SourceCodeLkpId == input.Params.SourceCodeLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
            {
                DateTime dtFrom = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);

                queryable = queryable.Where(q => dtFrom <= q.MiscPaymentDate);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
            {
                DateTime dtTo = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);

                queryable = queryable.Where(q => dtTo >= q.MiscPaymentDate);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ApMiscPaymentHeadersDto>());

            // -- --
            foreach (var item in data2)
            {
                if (item.FirstLinePortalUserId == 0) continue;

                var currentPortalUser = await _repoPortalUser.GetAsync(item.FirstLinePortalUserId);

                item.PortalUserName = currentPortalUser.Name;
            }

            var PagedResultDto = new PagedResultDto<ApMiscPaymentHeadersDto>()
            {
                Items = data2 as IReadOnlyList<ApMiscPaymentHeadersDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<ApMiscPaymentHeadersDto> Create(CreateApMiscPaymentHeadersDto input)
        {
            CheckCreatePermission();

            input.PaymentNumber = await GetApMiscPaymentNumber(input.Lang);

            var current = await base.Create(input);

            if (input.ListApMiscPaymentLinesVM.Count > 0)
            {
                foreach (var item in input.ListApMiscPaymentLinesVM)
                {
                    var currentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                    var currentCodeComTaxId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);

                    item.FndTaxTypeLkpId = item.TaxPercentageLkpId;

                    decimal? taxPercnt = null;
                    taxPercnt = await GetTaxPercent(item.FndTaxTypeLkpId);

                    var currentLine = ApMiscPaymentLines.Create(currentCodeComTaxId, currentCodeComId, current.Id, item.FndTaxTypeLkpId,
                                                                item.miscPaymentAmount, taxPercnt, item.taxNo, item.invoiceNumber, item.notes);

                    _ = await _repoArMiscPaymentLines.InsertAsync(currentLine);
                }
            }

            if (input.ListApMiscPaymentDetailsVM.Count > 0)
            {
                foreach (var item in input.ListApMiscPaymentDetailsVM)
                {
                    var dt = string.IsNullOrEmpty(item.maturityDate) ? null : (DateTime?)DateTimeController.ConvertToDateTime(item.maturityDate);

                    var currentDetail = ApMiscPaymentDetails
                        .Create(item.checkNumber, item.beneficiaryName, item.amount, dt, current.Id, item.notes);

                    _ = await _repoArMiscPaymentDetails.InsertAsync(currentDetail);
                }
            }

            return new ApMiscPaymentHeadersDto();
        }

        public async override Task<ApMiscPaymentHeadersDto> Update(ApMiscPaymentHeadersEditDto input)
        {
            CheckUpdatePermission();

            if (await CheckPostedStatus(input.Id)) return new ApMiscPaymentHeadersDto { };

            _ = await base.Update(input);

            #region Lines


            foreach (var item in input.ListApMiscPaymentLinesVM)
            {
                var currentCodeComId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                var currentCodeComTaxId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds_alt1);
                item.FndTaxTypeLkpId = item.TaxPercentageLkpId;

                decimal? taxPercnt = null;
                taxPercnt = await GetTaxPercent(item.FndTaxTypeLkpId);

                if (item.apMiscPaymentLinesId != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                {
                    var currentline = await _repoArMiscPaymentLines.GetAsync((long)item.apMiscPaymentLinesId);                  
                    var mappedDto = ObjectMapper.Map(currentline, new ApMiscPaymentLinesDto());

                    mappedDto.MiscPaymentAmount = item.miscPaymentAmount;
                    mappedDto.AccountId = currentCodeComId;
                    mappedDto.TaxAccountId = currentCodeComTaxId;
                    mappedDto.TaxPercentageLkpId = item.TaxPercentageLkpId;
                    mappedDto.FndTaxTypeLkpId = item.FndTaxTypeLkpId;
                    mappedDto.Notes = item.notes;
                    mappedDto.TaxNo = item.taxNo;
                    mappedDto.TaxPercent = taxPercnt;// ApMiscPaymentLines.SetTaxPercent(item.TaxPercentageLkpId);
                    mappedDto.TrTax = item.trTax;
                    mappedDto.TaxPercentageLkpId = null;

                    var mappedEntity = ObjectMapper.Map(mappedDto, currentline);

                    _ = await _repoArMiscPaymentLines.UpdateAsync(mappedEntity);
                }
                else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                {
                    var line = ApMiscPaymentLines.Create(currentCodeComTaxId, currentCodeComId, input.Id, item.FndTaxTypeLkpId,
                        item.miscPaymentAmount, taxPercnt, item.taxNo, item.invoiceNumber, item.notes);

                    _ = await _repoArMiscPaymentLines.InsertAsync(line);
                }
                else if (item.apMiscPaymentLinesId != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                {
                    await _repoArMiscPaymentLines.DeleteAsync((long)item.apMiscPaymentLinesId);
                }
            }

            #endregion

            #region details

            foreach (var item in input.ListApMiscPaymentDetailsVM)
            {
                if (item.apMiscDetailId != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                {
                    var currentDetail = await _repoArMiscPaymentDetails.GetAsync((long)item.apMiscDetailId);

                    var mappedDto = ObjectMapper.Map(currentDetail, new ApMiscPaymentDetailsDto());

                    mappedDto.MaturityDate = string.IsNullOrEmpty(item.maturityDate) ? null : (DateTime?)DateTimeController.ConvertToDateTime(item.maturityDate);
                    mappedDto.Amount = item.amount;
                    mappedDto.BeneficiaryName = item.beneficiaryName;
                    mappedDto.CheckNumber = item.checkNumber;
                    mappedDto.Notes = item.notes;

                    var mappedEntity = ObjectMapper.Map(mappedDto, currentDetail);

                    _ = await _repoArMiscPaymentDetails.UpdateAsync(mappedEntity);
                }
                else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                {
                    var dtDetail = string.IsNullOrEmpty(item.maturityDate) ? null : (DateTime?)DateTimeController.ConvertToDateTime(item.maturityDate);

                    var currentDetail = ApMiscPaymentDetails
                         .Create(item.checkNumber, item.beneficiaryName, item.amount, dtDetail, input.Id, item.notes);

                    _ = await _repoArMiscPaymentDetails.InsertAsync(currentDetail);
                }
                else if (item.apMiscDetailId != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                {
                    await _repoArMiscPaymentDetails.DeleteAsync((long)item.apMiscDetailId);
                }
            }

            #endregion

            return new ApMiscPaymentHeadersDto();
        }

        private async  Task<decimal?> GetTaxPercent(long? fndTaxtypeid)
        {
            try
            {
                long id = fndTaxtypeid.HasValue ? fndTaxtypeid.Value : -1;
                decimal? result = null;

                var fndtaxType = await _repoFndTaxTypes.FirstOrDefaultAsync(id);

                if (fndtaxType != null)
                    result = fndtaxType.Percentage;

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ListApMiscPaymentDetailsVM>> GetAllApMiscPaymentDetails(long miscPaymentId)
        {
            var data = await _repoArMiscPaymentDetails.GetAllIncluding().Where(z => z.MiscPaymentId == miscPaymentId)
                                                      .ToListAsync();

            var list = new List<ListApMiscPaymentDetailsVM>();
            int counter = 0;

            for (int i = 0; i < data.Count; i++)
            {
                var current = data[i];

                list.Add(new ListApMiscPaymentDetailsVM
                {
                    index = ++counter,
                    amount = current.Amount,
                    miscId = (long)current.MiscPaymentId,
                    apMiscDetailId = current.Id,
                    checkNumber = current.CheckNumber,
                    beneficiaryName = current.BeneficiaryName,
                    notes = current.Notes,
                    maturityDate = current.MaturityDate == null ? string.Empty : current.MaturityDate.Value.ToString(Formatters.DateFormat)
                });

            }

            return list;
        }

        public async Task<List<ListApMiscPaymentLinesVM>> GetAllApMiscPaymentLines(long miscPaymentId)
        {
            var output = new List<ListApMiscPaymentLinesVM>();

            var lines = await _repoArMiscPaymentLines.GetAllIncluding(z => z.GlCodeComDetails, x => x.GlCodeComDetailsTaxAccount,x=>x.FndTaxTypeLkp)
                .Where(z => z.MiscPaymentId == miscPaymentId).ToListAsync();

            int counter = 0;

            foreach (var item in lines)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);
                (string idTaxs, string textTaxs) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetailsTaxAccount, _app.Reqlanguage);

                var current = new ListApMiscPaymentLinesVM();

                current.notes = item.Notes;
                current.index = ++counter;
                current.apMiscPaymentLinesId = item.Id;
                current.TaxPercentageLkpId = item.FndTaxTypeLkpId;
                current.FndTaxTypeLkpId = item.FndTaxTypeLkpId;


                current.miscId = item.MiscPaymentId;
                current.taxNo = item.TaxNo;
                //current.TaxPercentageNameEn = $"{item.TaxPercent ?? 0} %";
                current.TaxPercentageNameEn = item.FndTaxTypeLkp != null ? item.FndTaxTypeLkp.TaxNameEn : "";// $"{item.TaxPercent ?? 0} %";
                current.TaxPercentageNameAr = item.FndTaxTypeLkp != null ? item.FndTaxTypeLkp.TaxNameAr : "";
                //current.FndTaxTypeNameEn = $"{item.TaxPercent ?? 0} %";
                current.miscId = item.MiscPaymentId;
                current.invoiceNumber = item.InvoiceNumber;
                current.miscPaymentAmount = item.MiscPaymentAmount;
                current.codeComUtilityIds = ids;
                current.codeComUtilityIds_alt1 = idTaxs;
                current.codeComUtilityTexts = texts;
                current.codeComUtilityTexts_alt1 = textTaxs;
                
                output.Add(current);
            }

            return output;
        }

        public async Task<ApMiscPaymentHeadersDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValuesPostedPaymentLkp, x => x.FndLookupValuesSourceCodePaymentLkp, x => x.FndLookupValuesPaymentTypeLkp, x => x.ApBankAccounts)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map(current, new ApMiscPaymentHeadersDto());
        }

        public async override Task Delete(EntityDto<long> input)
        {
            if (await CheckPostedStatus(input.Id)) return;

            var listDetails = await _repoArMiscPaymentDetails.GetAll().Where(z => z.MiscPaymentId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var id in listDetails)
                await _repoArMiscPaymentDetails.DeleteAsync(id);

            var listLines = await _repoArMiscPaymentLines.GetAll().Where(z => z.MiscPaymentId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var id in listLines)
                await _repoArMiscPaymentLines.DeleteAsync(id);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<PostOutput> PostApMiscReceiptHeader(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }
            var postResult = await _repoForStored.Execute(input, "ApPostMiscPayment");
            return postResult.FirstOrDefault();
        }

        public async Task<List<MiscPaymentScreenDataOutput>> GetMiscPaymentScreenData(IdLangInputDto input)
        {
            var result = await _repoMiscPaymentScreen.Execute(input, "GetMiscPaymentScreenData");

            return result.ToList();
        }

        public async Task<Select2PagedResult> GetBeneficiaryNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _apMiscPaymentHeadersManager.GetBeneficiaryNamesSelect2(searchTerm, pageSize, pageNumber, lang);

        private async Task<bool> CheckPostedStatus(long id)
        {
            var current = await Repository.GetAsync(id);

            return current.PostedlkpId == Convert.ToInt64(FndLkps.Posted_ApMiscPaymentHeadersPost);
        }

        private async Task<string> GetApMiscPaymentNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ApMiscPaymentHeaders", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }
    }
}
