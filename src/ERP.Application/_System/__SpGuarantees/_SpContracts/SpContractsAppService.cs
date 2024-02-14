#region usings
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System.__SpGuarantees._SpBeneficent;
using ERP._System.__SpGuarantees._SpBeneficent._SpBeneficentBanks;
using ERP._System.__SpGuarantees._SpContracts._SpContractAttachments;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System.__SpGuarantees._SpContracts.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
#endregion

namespace ERP._System.__SpGuarantees._SpContracts
{
    [AbpAuthorize]
    public class SpContractsAppService : AttachBaseAsyncCrudEditedEntityAppService<SpContracts, SpContractsDto, long, PagedSpContractsResultRequestDto, SpContractsCreateDto, SpContractsEditDto, SpContractAttachments>,
        ISpContractsAppService
    {
        private readonly ISpBeneficentBankManager _spBeneficentBankManager;
        private readonly ITmCharityBoxReceiveRepository _repoPost;
        private readonly IRepository<SpBeneficent, long> _repoSpBeneficent;
        private readonly IRepository<SpBeneficentBanks, long> _repoSpBeneficentBanks;
        private readonly IRepository<SpContractAttachments, long> _repoSpContractAttachments;
        private readonly IRepository<SpContractDetails, long> _repoSpContractDetails;
        private readonly IEntityCounterManager _entityCounterManager;

        public SpContractsAppService(
            IRepository<SpContracts, long> repository
            ,IRepository<SpBeneficent, long> repoSpBeneficent
            ,IRepository<SpBeneficentBanks, long> repoSpBeneficentBanks
            ,IRepository<SpContractDetails, long> repoSpContractDetails
            ,IRepository<SpContractAttachments, long> repoSpContractAttachments
            ,ISpBeneficentBankManager spBeneficentBankManager
            ,ITmCharityBoxReceiveRepository tmCharityBoxReceiveRepository
            ,IConfiguration config
            , IEntityCounterManager entityCounterManager
            ) : base(repository, config)
        {
            _repoSpContractDetails = repoSpContractDetails;
            _spBeneficentBankManager = spBeneficentBankManager;
            _repoSpBeneficent = repoSpBeneficent;
            _repoPost = tmCharityBoxReceiveRepository;
            _repoSpBeneficentBanks = repoSpBeneficentBanks;
            _repoSpContractAttachments = repoSpContractAttachments;
            _entityCounterManager = entityCounterManager;

            CreatePermissionName = PermissionNames.Pages_SpContracts_Insert;
            UpdatePermissionName = PermissionNames.Pages_SpContracts_Update;
            DeletePermissionName = PermissionNames.Pages_SpContracts_Delete;
            GetAllPermissionName = PermissionNames.Pages_SpContracts;

            PreFileName = "Sp-Attchs";
            ServiceFolder = "SpContracts";
        }

        protected override async Task<SpContractAttachments> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return await _repoSpContractAttachments.FirstOrDefaultAsync(att => att.Id == Id && att.SpContractId == ParentId && att.FilePath == filePath); ;
        }

        public async Task<List<SpContractAttachments>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<SpContractAttachments>>(
                 await _repoSpContractAttachments.GetAllIncluding().Where(d => d.SpContractId == input.Id).ToListAsync()
                );
        }

        protected override IQueryable<SpContracts> CreateFilteredQuery(PagedSpContractsResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.SpContractDetails, x => x.FndStatusLkp, x => x.SpBeneficent, x => x.FndPaymentTypeLkp, x => x.FndDeductedLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ContractNumber))
                iqueryable = iqueryable.Where(z => z.ContractNumber.Contains(input.Params.ContractNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.BeneficentNumber))
                iqueryable = iqueryable.Where(z => z.SpBeneficent.BeneficentNumber.Contains(input.Params.BeneficentNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.SpBeneficentId != null)
                iqueryable = iqueryable.Where(z => z.SpBeneficentId == input.Params.SpBeneficentId);

            if (input.Params != null && input.Params.SpCaseId != null)
                iqueryable = iqueryable.Where(z => z.SpContractDetails.Any(c => c.SpCaseId == input.Params.SpCaseId));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ContractDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.ContractDate);

                iqueryable = iqueryable.Where(z => z.ContractDate == dt);
            }

            return iqueryable;
        }

        internal override async Task EntityCreatePreExecute(SpContractsCreateDto input)
        {
            input.ContractNumber = await _entityCounterManager.GetEntityNumber("SpContracts", (int)AbpSession.TenantId);
        }

        //public async override Task<SpContractsDto> Create(SpContractsCreateDto input)
        //{
        //    CheckCreatePermission();

        //    input.ContractNumber = await GetSpContractNumber();

        //    var spContracts = await base.Create(input);

        //    if (input.ContractAttachments != null && input.ContractAttachments.Count > 0)
        //    {
        //        foreach (var item in input.ContractAttachments)
        //        {
        //            item.SpContractId = spContracts.Id;

        //            _ = await _repoSpContractAttachments.InsertAsync(ObjectMapper.Map<SpContractAttachments>(item));
        //        }
        //    }

        //    if (input.ContractDetails != null && input.ContractDetails.Count > 0)
        //    {
        //        foreach (var item in input.ContractDetails)
        //        {
        //            item.SpContractId = spContracts.Id;
        //            item.AccountNumber = item.AccountOwnerName = null;
        //            item.BankLkpId = null;
        //            item.CaseStatusLkpId = 694;

        //            _ = await _repoSpContractDetails.InsertAsync(ObjectMapper.Map<SpContractDetails>(item));
        //        }
        //    }

        //    return new SpContractsDto { };
        //}

        internal override async Task EntityCreatePostExecute(SpContractsCreateDto input, long EntityId)
        {
            if (input.ContractAttachments != null && input.ContractAttachments.Count > 0)
            {
                foreach (var item in input.ContractAttachments)
                {
                    item.SpContractId = EntityId;

                    _ = await _repoSpContractAttachments.InsertAsync(ObjectMapper.Map<SpContractAttachments>(item));
                }
            }

            if (input.ContractDetails != null && input.ContractDetails.Count > 0)
            {
                foreach (var item in input.ContractDetails)
                {
                    item.SpContractId = EntityId;
                    item.AccountNumber = item.AccountOwnerName = null;
                    item.BankLkpId = null;
                    item.CaseStatusLkpId = 694;

                    _ = await _repoSpContractDetails.InsertAsync(ObjectMapper.Map<SpContractDetails>(item));
                }
            }

        }

        //public async override Task<SpContractsDto> Update(SpContractsEditDto input)
        //{
        //    CheckUpdatePermission();

        //    await CheckIsPosted(input);

        //    await CheckIsModified(input);

        //    _ = await base.Update(input);

        //    if (input.ContractAttachments != null && input.ContractAttachments.Count > 0)
        //    {
        //        foreach (var item in input.ContractAttachments)
        //        {
        //            if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
        //            {
        //                var concAttachments = await _repoSpContractAttachments.GetAsync((long)item.Id);

        //                item.SpContractId = input.Id;

        //                ObjectMapper.Map(item, concAttachments);

        //                _ = await _repoSpContractAttachments.UpdateAsync(concAttachments);

        //            }
        //            else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
        //            {
        //                item.SpContractId = input.Id;

        //                _ = await _repoSpContractAttachments.InsertAsync(ObjectMapper.Map<SpContractAttachments>(item));
        //            }
        //            else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
        //            {
        //                await _repoSpContractAttachments.DeleteAsync((long)item.Id);
        //            }
        //        }
        //    }

        //    if (input.ContractDetails != null && input.ContractDetails.Count > 0)
        //    {
        //        foreach (var item in input.ContractDetails)
        //        {
        //            if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
        //            {
        //                item.SpContractId = input.Id;

        //                var spContractDetails = await _repoSpContractDetails.GetAsync((long)item.Id);

        //                item.CaseStatusLkpId = spContractDetails.CaseStatusLkpId;
        //                item.AccountNumber = spContractDetails.AccountNumber;
        //                item.AccountOwnerName = spContractDetails.AccountOwnerName;
        //                item.BankLkpId = spContractDetails.BankLkpId;

        //                ObjectMapper.Map(item, spContractDetails);

        //                _ = await _repoSpContractDetails.UpdateAsync(spContractDetails);
        //            }
        //            else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
        //            {
        //                item.AccountNumber = item.AccountOwnerName = null;
        //                item.BankLkpId = null;
        //                item.SpContractId = input.Id;
        //                item.CaseStatusLkpId = 694;

        //                _ = await _repoSpContractDetails.InsertAsync(ObjectMapper.Map<SpContractDetails>(item));
        //            }
        //            else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
        //            {
        //                await _repoSpContractDetails.DeleteAsync((long)item.Id);
        //            }
        //        }
        //    }

        //    return new SpContractsDto { };
        //}

        internal override async Task EntityUpdatePreExecute(SpContractsEditDto input)
        {
            if (input.ContractAttachments != null && input.ContractAttachments.Count > 0)
            {
                foreach (var item in input.ContractAttachments)
                {
                    item.SpContractId = input.Id;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var concAttachments = await _repoSpContractAttachments.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, concAttachments);

                        _ = await _repoSpContractAttachments.UpdateAsync(concAttachments);
                    }
                    else if (item.Id == 0 || item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        _ = await _repoSpContractAttachments.InsertAsync(ObjectMapper.Map<SpContractAttachments>(item));
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        await _repoSpContractAttachments.DeleteAsync((long)item.Id);
                }
            }

            if (input.ContractDetails != null && input.ContractDetails.Count > 0)
            {
                foreach (var item in input.ContractDetails)
                {
                    item.SpContractId = input.Id;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var spContractDetails = await _repoSpContractDetails.GetAsync((long)item.Id);

                        item.CaseStatusLkpId = spContractDetails.CaseStatusLkpId;
                        item.AccountNumber = spContractDetails.AccountNumber;
                        item.AccountOwnerName = spContractDetails.AccountOwnerName;
                        item.BankLkpId = spContractDetails.BankLkpId;

                        ObjectMapper.Map(item, spContractDetails);

                        _ = await _repoSpContractDetails.UpdateAsync(spContractDetails);
                    }
                    else if (item.Id == 0 || item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.AccountNumber = item.AccountOwnerName = null;
                        item.BankLkpId = null;
                        item.CaseStatusLkpId = 694;

                        _ = await _repoSpContractDetails.InsertAsync(ObjectMapper.Map<SpContractDetails>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        await _repoSpContractDetails.DeleteAsync((long)item.Id);
                }
            }
        }

        //public override async Task Delete(EntityDto<long> input)
        //{
        //    await CheckIsPosted(input);
        //    //CheckIsModified(input);
        //    await base.Delete(input);
        //}

        internal override async Task EntityDeletePreExecute(EntityDto<long> input)
        {
            foreach (var item in _repoSpContractAttachments.GetAllList(z=>z.SpContractId==input.Id).ToList())
                await _repoSpContractAttachments.DeleteAsync((long)item.Id);
            foreach (var item in _repoSpContractDetails.GetAllList(z => z.SpContractId == input.Id).ToList())
                await _repoSpContractDetails.DeleteAsync((long)item.Id);
        }

        public async Task<SpContractsDto> GetDetailAsync(EntityDto<long> input)
        {
            try
            {
                var current = await Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.SpBeneficent, x => x.FndPaymentTypeLkp, x => x.FndDeductedLkp)
                               .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

                var currentDto = ObjectMapper.Map<SpContractsDto>(current);

                return currentDto;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public async Task<List<SpContractAttachmentsDto>> GetAllSpAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<SpContractAttachmentsDto>>(
                await _repoSpContractAttachments.GetAllIncluding().Where(d => d.SpContractId == input.Id).ToListAsync()
                );
        }

        public async Task<List<SpContractDetailsDto>> GetAllSpContractsDetails(EntityDto<long> input)
        {
            var output = new List<SpContractDetailsDto>();

            var listData = await _repoSpContractDetails.GetAllIncluding(x => x.SpCases,
                        x => x.SpContracts, x => x.SpCases.FndLookupValuesSponsorCategoryLkp,
                        x => x.SpBeneficentBanks, x => x.FndCaseStatusLkp,
                        x => x.SpBeneficentBanks.LookupBankValues)
                .Where(d => d.SpContractId == input.Id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new SpContractDetailsDto
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    AccountNumber = item.SpContracts!=null && item.SpBeneficentBanks!=null && item.SpContracts.StatusLkpId == /* NEW */ 691 ? item.SpBeneficentBanks.AccountNumber : item.AccountNumber,
                    BankLkpId = item.BankLkpId,
                    AccountOwnerName = item.SpContracts != null && item.SpBeneficentBanks != null && item.SpContracts.StatusLkpId == /* NEW */ 691 ? item.SpBeneficentBanks.AccountOwnerName : item.AccountOwnerName,
                    StartDate = item.StartDate.ToString(Formatters.DateFormat),
                    EndDate = item.EndDate == null ? string.Empty : item.EndDate.Value.ToString(Formatters.DateFormat),
                    SpBeneficentBankId = item.SpBeneficentBankId,
                    SpCaseId = item.SpCaseId,
                    SpCase = item.SpCases.CaseName,
                    SponsFor = item.SponsFor,
                    caseNumber = item.SpCases.CaseNumber,
                    CaseStatus = item.FndCaseStatusLkp!=null? item.FndCaseStatusLkp.NameAr:"",
                    SpBeneficentBank = item.SpBeneficentBanks!=null&& item.SpBeneficentBanks.LookupBankValues!=null? item.SpBeneficentBanks.LookupBankValues.NameAr:"",
                    sponsorCategory = item.SpCases!=null&& item.SpCases.FndLookupValuesSponsorCategoryLkp!=null? item.SpCases.FndLookupValuesSponsorCategoryLkp.NameAr:"",
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }
            return output;
        }

        public async Task<(SpBeneficent, SpBeneficentBanks)> GetSpBeneficentForContract(long id)
        {
            var spBeneficent = await _repoSpBeneficent.GetAll().Where(z => z.Id == id).FirstOrDefaultAsync();

            var spBeneficentBank = await _repoSpBeneficentBanks.GetAllIncluding(x => x.LookupBankValues)
                                      .Where(z => z.SpBeneficentId == id && z.IsDefault).FirstOrDefaultAsync();

            return (spBeneficent, spBeneficentBank);
        }

        public async Task<PostOutput> PostSpContracts(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(postDto, "SpContractsPost");

            return result.FirstOrDefault();
        }

        public async Task<SpBeneficentBanks> GetSpBeneficentBanksForContract(long id)
            => await _repoSpBeneficentBanks.GetAsync(id);

        public async Task<Select2PagedResult> GetSpBeneficentBanksSelect2(long spBeneficentId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spBeneficentBankManager.GetSpBeneficentBanksSelect2(spBeneficentId, searchTerm, pageSize, pageNumber, lang);

        //private async Task<string> GetSpContractNumber(string lang = "ar-EG", int year = 0)
        //{
        //    var counterInput = new GetCounterInputDto { CounterName = "SpContracts", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

        //    var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

        //    return result?.FirstOrDefault()?.OutputStr ?? "0";
        //}
    }
}
