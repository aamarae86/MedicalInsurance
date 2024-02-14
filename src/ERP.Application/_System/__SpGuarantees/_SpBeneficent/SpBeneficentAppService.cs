using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__SpGuarantees._SpBeneficent.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpBeneficent
{
    [AbpAuthorize]
    public class SpBeneficentAppService : AttachBaseAsyncCrudAppService<SpBeneficent, SpBeneficentDto, long, SpBeneficentPagedDto, SpBeneficentCreateDto, SpBeneficentEditDto, SpBeneficentAttachments>
        , ISpBeneficentAppService
    {
        private readonly IRepository<SpBeneficentBanks, long> _repoBanks;
        private readonly IRepository<SpBeneficentAttachments, long> _repoAttachments;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;
        private readonly ISpBeneficentManager _SpBeneficentManager;
        private readonly IGetCounterRepository _repoProcCounter;

        public SpBeneficentAppService(IRepository<SpBeneficent, long> repository,
            IRepository<SpBeneficentBanks, long> repoDetail,
            IRepository<SpBeneficentAttachments, long> repoMember,
            IRepository<FndLookupValues, long> repoFndLookupValues,
            ISpBeneficentManager SpBeneficentManager, IConfiguration config, IGetCounterRepository repoProcCounter
            ) : base(repository, config)
        {
            _repoBanks = repoDetail;
            _repoAttachments = repoMember;
            _SpBeneficentManager = SpBeneficentManager;
            _repoFndLookupValues = repoFndLookupValues;
            _repoProcCounter = repoProcCounter;


            CreatePermissionName = PermissionNames.Pages_SpBeneficent_Insert;
            UpdatePermissionName = PermissionNames.Pages_SpBeneficent_Update;
            DeletePermissionName = PermissionNames.Pages_SpBeneficent_Delete;
            GetAllPermissionName = PermissionNames.Pages_SpBeneficent;

            PreFileName = "SpBenef-Attchs";
            ServiceFolder = "SpBeneficents";
        }

        protected override async Task<SpBeneficentAttachments> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return await _repoAttachments.FirstOrDefaultAsync(att => att.Id == Id && att.SpBeneficentId == ParentId && att.FilePath == filePath); ;
        }

        public async Task<List<SpBeneficentAttachments>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<SpBeneficentAttachments>>(
                 await _repoAttachments.GetAllIncluding().Where(d => d.SpBeneficentId == input.Id).ToListAsync()
                );
        }

        public async Task<SpBeneficentDto> CreateShortCut(SpBeneficentCreateDto input)
        {
            CheckCreatePermission();

            input.BeneficentNumber = await GetBeneficentNumber();

            return await base.Create(input);
        }

        public override async Task<SpBeneficentDto> Create(SpBeneficentCreateDto input)
        {
            CheckCreatePermission();

            input.BeneficentNumber = await GetBeneficentNumber();

            var Beneficent = await base.Create(input);

            if (input.ListOfBanks?.Count > 0)
                foreach (var item in input.ListOfBanks)
                {
                    item.BeneficentId = Beneficent.Id;

                    var BeneficentBank = ObjectMapper.Map<SpBeneficentBanks>(item);

                    _ = await _repoBanks.InsertAsync(BeneficentBank);
                }

            if (input.ListOfAttachments?.Count > 0)
                foreach (var item in input.ListOfAttachments)
                {
                    item.BeneficentId = Beneficent.Id;

                    var SpBeneficentAttachment = ObjectMapper.Map<SpBeneficentAttachments>(item);

                    _ = await _repoAttachments.InsertAsync(SpBeneficentAttachment);

                }

            return Beneficent;
        }

        public override async Task<SpBeneficentDto> Update(SpBeneficentEditDto input)
        {
            CheckUpdatePermission();

            var Beneficent = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, Beneficent);

            _ = await Repository.UpdateAsync(Beneficent);

            if (input.ListOfEditBanks?.Count > 0)
            {
                foreach (var item in input.ListOfEditBanks)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var spBeneficentBank = await _repoBanks.GetAsync(item.Id);

                        item.BeneficentId = input.Id;

                        var mapped = ObjectMapper.Map(item, spBeneficentBank);

                        _ = await _repoBanks.UpdateAsync(spBeneficentBank);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.BeneficentId = input.Id;

                        var BeneficentBank = ObjectMapper.Map<SpBeneficentBanks>(item);

                        _ = await _repoBanks.InsertAsync(BeneficentBank);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoBanks.DeleteAsync(item.Id);
                    }
                }
            }

            if (input.ListOfAttachments?.Count > 0)
            {
                foreach (var item in input.ListOfAttachments)
                {
                    item.BeneficentId = Beneficent.Id;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {

                        var SpBeneficentMember = await _repoAttachments.GetAsync((long)item.Id);

                        var mapped = ObjectMapper.Map(item, SpBeneficentMember);

                        _ = await _repoAttachments.UpdateAsync(SpBeneficentMember);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var SpBeneficentMember = ObjectMapper.Map<SpBeneficentAttachments>(item);

                        _ = await _repoAttachments.InsertAsync(SpBeneficentMember);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new SpBeneficentDto { };
        }

        protected override IQueryable<SpBeneficent> CreateFilteredQuery(SpBeneficentPagedDto input)
        {
            try
            {
                var queryable = Repository.GetAllIncluding(z => z.SpBeneficentBanks
                    , z => z.SpBeneficentAttachments
                    , z => z.FndLookupCityValues
                    , z => z.FndLookupFirstTitleValues
                    , z => z.FndLookupGenderValues
                    , z => z.FndLookupLastTitleValues
                    , z => z.FndLookupNationalityValues);

                if (input.Params.BeneficentId.HasValue)
                {
                    queryable = queryable.Where(q => q.Id == input.Params.BeneficentId.Value);
                }

                if (!string.IsNullOrEmpty(input.Params.BeneficentNumber))
                {
                    queryable = queryable.Where(q => q.BeneficentNumber.Contains(input.Params.BeneficentNumber));
                }
                if (!string.IsNullOrEmpty(input.Params.Mobile))
                {
                    queryable = queryable.Where(q => q.MobileNumber1.Contains(input.Params.Mobile) || q.MobileNumber2.Contains(input.Params.Mobile));
                }
                if (input.Params.CityLkpId > 0)
                {
                    queryable = queryable.Where(q => q.CityLkpId == input.Params.CityLkpId);
                }

                queryable = queryable.OrderByDescending(x => x.CreationTime);

                return queryable;
            }
            catch (System.Exception ex)
            {
                return base.CreateFilteredQuery(input);
            }
        }

        public async Task<SpBeneficentDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll()
                .Include(z => z.SpBeneficentBanks).ThenInclude(i => i.LookupBankValues)
                //.Include(z => z.SpBeneficentAttachments)
                .Include(z => z.FndLookupCityValues)
                .Include(z => z.FndLookupFirstTitleValues)
                .Include(z => z.FndLookupGenderValues)
                .Include(z => z.FndLookupLastTitleValues)
                .Include(z => z.FndLookupNationalityValues)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<SpBeneficentDto>(current);

            return mapped;
        }

        private async Task<string> GetBeneficentNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "SpBeneficent", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result.FirstOrDefault().OutputStr;
        }

        public async Task<Select2PagedResult> GetSpBeneficentNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await Repository.GetAll()
                    .Where(z => string.IsNullOrEmpty(searchTerm) || z.BeneficentName.Contains(searchTerm))
                    .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.BeneficentName/*, altText = z.BeneficentName*/ }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSpBeneficentSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
              => await _SpBeneficentManager.GetSpBeneficentSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetSpBeneficentBanksSelect2(long BenefId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var benef = await Repository.GetAll()
                .Include(d => d.SpBeneficentBanks).ThenInclude(d => d.LookupBankValues)
                .FirstOrDefaultAsync(z => z.Id == BenefId);

            var data = benef.SpBeneficentBanks
                   .Where(z => (string.IsNullOrEmpty(searchTerm)
                   || z.LookupBankValues.NameAr.Contains(searchTerm)
                   || z.LookupBankValues.NameEn.Contains(searchTerm)));

            var result = data.OrderBy(q => q.BankLkpId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(z =>
                new Select2OptionModel
                {
                    id = z.BankLkpId,
                    text = lang == "ar-EG" ? z.LookupBankValues?.NameAr : z.LookupBankValues?.NameEn,
                    altText = $"{z.AccountNumber}__{z.AccountOwnerName}"
                }
                ).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
