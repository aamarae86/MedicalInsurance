using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System.__SpGuarantees._SpCases.Dto;
using ERP._System.__SpGuarantees._SpCasesAttachments;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCases
{
    [Authorize]
    public class SpCasesAppService : AttachBaseAsyncCrudAppService<SpCases, SpCasesDto, long, SpCasesPagedDto, SpCasesCreateDto, SpCasesEditDto, SpCasesAttachments>
        , ISpCasesAppService
    {
        private readonly IRepository<SpCasesAttachments, long> _repoAttachments;
        private readonly ISpCasesManager _spCasesManager;
        private readonly IImageConfig _imageConfig;
        private readonly ITmCharityBoxReceiveRepository _repoPost;

        public SpCasesAppService(ISpCasesManager spCasesManager,
            IRepository<SpCases, long> repoSpCases,
            IRepository<SpCasesAttachments, long> repoMember,
            IImageConfig imageConfig, IConfiguration config,
            ITmCharityBoxReceiveRepository tmCharityBoxReceiveRepository) : base(repoSpCases, config)
        {
            _repoAttachments = repoMember;
            _spCasesManager = spCasesManager;
            _imageConfig = imageConfig;
            _repoPost = tmCharityBoxReceiveRepository;

            CreatePermissionName = PermissionNames.Pages_SpCases_Insert;
            UpdatePermissionName = PermissionNames.Pages_SpCases_Update;
            DeletePermissionName = PermissionNames.Pages_SpCases_Delete;
            GetAllPermissionName = PermissionNames.Pages_SpCases;

            PreFileName = "SpCases-Attchs";
            ServiceFolder = "SpCases";
        }

        protected override async Task<SpCasesAttachments> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return await _repoAttachments.FirstOrDefaultAsync(att => att.Id == Id && att.SpCaseId == ParentId && att.FilePath == filePath); ;
        }

        public override Task<SpCasesDto> Create(SpCasesCreateDto input) => throw new UserFriendlyException("Invalid");

        public override Task Delete(EntityDto<long> input) => throw new UserFriendlyException("Invalid");

        public override async Task<SpCasesDto> Update(SpCasesEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.ListOfAttachments?.Count > 0)
            {
                foreach (var item in input.ListOfAttachments)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        item.SpCaseId = input.Id;

                        var SpCasesMember = await _repoAttachments.GetAsync((long)item.Id);

                        var mapped = ObjectMapper.Map(item, SpCasesMember);

                        _ = await _repoAttachments.UpdateAsync(SpCasesMember);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.SpCaseId = input.Id;

                        _ = await _repoAttachments.InsertAsync(ObjectMapper.Map<SpCasesAttachments>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }
            return new SpCasesDto { };
        }

        protected override IQueryable<SpCases> CreateFilteredQuery(SpCasesPagedDto input)
        {
            try
            {
                var queryable = Repository.GetAllIncluding(z => z.FndLookupValuesStatusLkp, z => z.FndLookupValuesEducationalLevelLkp
                    , z => z.FndLookupValuesEducationalStageLkp, z => z.FndLookupValuesGenderLkp
                    , z => z.FndLookupValuesHealthStatusLkp, z => z.FndLookupValuesMaritalStatusLkp, z => z.FndLookupValuesNationalityLkp
                    , z => z.FndLookupValuesRelativesTypeLkp, z => z.FndLookupValuesSponsorCategoryLkp
                    , z => z.SpFamilies, z => z.SpCasesAttachments, z => z.SpContractDetails
                    , z => z.SpContractDetails.SpContracts, z => z.SpContractDetails.SpContracts.SpBeneficent
                    );

                if (input.Params.SpCaseId.HasValue)
                    queryable = queryable.Where(q => q.Id == input.Params.SpCaseId.Value);

                if (input.Params.SpBeneficentId.HasValue)
                    queryable = queryable.Where(q => q.SpContractDetails.SpContracts.SpBeneficentId == input.Params.SpBeneficentId.Value);

                if (!string.IsNullOrEmpty(input.Params.CaseNumber))
                    queryable = queryable.Where(q => q.CaseNumber.Contains(input.Params.CaseNumber));

                if (!string.IsNullOrEmpty(input.Params.FamilyNumber))
                    queryable = queryable.Where(q => q.SpFamilies.FamilyNumber.Contains(input.Params.FamilyNumber));

                if (input.Params.SpFamilyId.HasValue)
                    queryable = queryable.Where(q => q.SpFamilyId == input.Params.SpFamilyId.Value);

                if (input.Params.NationallityLkpId.HasValue)
                    queryable = queryable.Where(q => q.NationalityLkpId == input.Params.NationallityLkpId.Value);

                if (input.Params.SponsorCategoryLkpId.HasValue)
                    queryable = queryable.Where(q => q.SponsorCategoryLkpId == input.Params.SponsorCategoryLkpId.Value);

                if (input.Params.StatusLkpId.HasValue)
                    queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId.Value);

                if (input.Params != null && !string.IsNullOrEmpty(input.Params.RegistrationDate))
                {
                    var dt = DateTimeController.ConvertToDateTime(input.Params.RegistrationDate);
                    queryable = queryable.Where(q => q.RegistrationDate.Value.Date == dt);
                }

                queryable = queryable.OrderByDescending(x => x.CreationTime);

                return queryable;
            }
            catch (Exception ex)
            {
                return base.CreateFilteredQuery(input);
            }
        }

        public async Task<SpCasesDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll()
                .Include(z => z.SpFamilies).Include(z => z.FndLookupValuesEducationalLevelLkp)
                .Include(z => z.FndLookupValuesEducationalStageLkp).Include(z => z.FndLookupValuesGenderLkp)
                .Include(z => z.FndLookupValuesHealthStatusLkp)
                .Include(z => z.FndLookupValuesMaritalStatusLkp)
                .Include(z => z.FndLookupValuesNationalityLkp)
                .Include(z => z.FndLookupValuesRelativesTypeLkp)
                .Include(z => z.FndLookupValuesSponsorCategoryLkp)
                .Include(z => z.FndLookupValuesStatusLkp)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<SpCasesDto>(current);

            mapped.base64Str = string.IsNullOrEmpty(mapped.Casephoto) ? string.Empty : _imageConfig.ConvertToBase64String(mapped.Casephoto, Path.GetExtension(mapped.Casephoto), "AppAttachments/SpCases-Profile");
            mapped.fileExt = Path.GetExtension(mapped.Casephoto);

            return mapped;
        }

        private string GetProfilePictureFilePath(string base64, string fileExtension = ".jpeg")
        {
            return _imageConfig.SaveImage(base64, $"SpCases-Profile-{Guid.NewGuid().ToString()}", fileExtension, "AppAttachments/SpCases-Profile");
        }

        public async Task<SpCases> GetSpCaseForContract(long id)
        {
            var data = await Repository.GetAllIncluding(x => x.FndLookupValuesSponsorCategoryLkp, x => x.FndLookupValuesStatusLkp)
                             .Where(z => z.Id == id && (z.StatusLkpId == 686 || z.StatusLkpId == 688))
                             .FirstOrDefaultAsync();
            return data;
        }

        public async Task<PostOutput> PostSpCases(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(postDto, "SpCasesPost");

            return result.FirstOrDefault();
        }

        public async Task<Select2PagedResult> GetSpCasesForContractsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spCasesManager.GetSpCasesForContractsSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetSpCasesGrantedSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spCasesManager.GetSpCasesGrantedSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetSpCasesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _spCasesManager.GetSpCasesSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetSpCasesForReplaceNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spCasesManager.GetSpCasesForReplaceNamesSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetSpCasesForReplaceNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _spCasesManager.GetSpCasesForReplaceNumbersSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<List<SpCasesAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<SpCasesAttachmentsDto>>(
                 await _repoAttachments.GetAllIncluding().Where(d => d.SpCaseId == input.Id).ToListAsync()
                );
        }
    }
}
