using Microsoft.Extensions.Configuration;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScMaintenanceQuotations.Dto;
using ERP.Authorization;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Proc;
using System.Linq;
using ERP.Helpers.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ERP._System.PostRecords.Dto;

namespace ERP._System.__AidModule._ScMaintenanceQuotations
{
    [AbpAuthorize]
    public class ScMaintenanceQuotationsAppService : AttachBaseAsyncCrudEditedEntityAppService<ScMaintenanceQuotations, ScMaintenanceQuotationsDto, long, ScMaintenanceQuotationsPagedDto, ScMaintenanceQuotationsCreateDto, ScMaintenanceQuotationsEditDto, ScMaintenanceQuotationAttachments>,
        IScMaintenanceQuotationsAppService
    {
        private readonly IRepository<ScMaintenanceQuotationAttachments, long> _repoScMaintenanceQuotationAttachments;
        private readonly IRepository<ScMaintenanceQuotationDetails, long> _repoScMaintenanceQuotationDetails;
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly IScMaintenanceTechnicalReportPostRepository _repoPost;

        public ScMaintenanceQuotationsAppService(IRepository<ScMaintenanceQuotations, long> repository,
            IRepository<ScMaintenanceQuotationAttachments, long> repoScMaintenanceQuotationAttachments,
            IRepository<ScMaintenanceQuotationDetails, long> repoScMaintenanceQuotationDetails,
            IConfiguration config, IEntityCounterManager entityCounterManager,
            IScMaintenanceTechnicalReportPostRepository ScMaintenanceQuotationsPostRepository) : base(repository, config)
        {
            _repoScMaintenanceQuotationAttachments = repoScMaintenanceQuotationAttachments;
            _repoScMaintenanceQuotationDetails = repoScMaintenanceQuotationDetails;
            _entityCounterManager = entityCounterManager;
            _repoPost = ScMaintenanceQuotationsPostRepository;

            CreatePermissionName = PermissionNames.Pages_ScMaintenanceQuotations_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScMaintenanceQuotations_Update;
            DeletePermissionName = PermissionNames.Pages_ScMaintenanceQuotations_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScMaintenanceQuotations;

            PreFileName = "Sc-Attchs";
            ServiceFolder = "ScMaintenanceQuotations";
        }

        protected override async Task<ScMaintenanceQuotationAttachments> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
               => await _repoScMaintenanceQuotationAttachments.FirstOrDefaultAsync(att => att.Id == Id && att.ScMaintenanceQuotationId == ParentId && att.FilePath == filePath);

        protected override IQueryable<ScMaintenanceQuotations> CreateFilteredQuery(ScMaintenanceQuotationsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.ApVendors, x => x.ScMaintenanceTechnicalReport.PortalRequest.PortalUser);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.QuotationNumber))
                iqueryable = iqueryable.Where(z => z.QuotationNumber.Contains(input.Params.QuotationNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PortalRequestNumber))
                iqueryable = iqueryable.Where(z => z.ScMaintenanceTechnicalReport.PortalRequest.PortalRequestNumber.Contains(input.Params.PortalRequestNumber));

            if (input.Params != null && input.Params.PortalUserId != null)
                iqueryable = iqueryable.Where(z => z.ScMaintenanceTechnicalReport.PortalRequest.PortalUsersId == input.Params.PortalUserId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.VendorId != null)
                iqueryable = iqueryable.Where(z => z.VendorId == input.Params.VendorId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.QuotationDate))
                iqueryable = iqueryable.Where(z => z.QuotationDate == DateTimeController.ConvertToDateTime(input.Params.QuotationDate));

            return iqueryable;
        }

        public async override Task<ScMaintenanceQuotationsDto> Get(EntityDto<long> input)
            => ObjectMapper.Map<ScMaintenanceQuotationsDto>(await Repository.GetAllIncluding(z => z.ApVendors, z => z.ScMaintenanceTechnicalReport.PortalRequest.PortalUser, z => z.FndStatusLkp)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<List<ScMaintenanceQuotationDetailsDto>> GetAllScMaintenanceQuotationDetailsData(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<ScMaintenanceQuotationDetailsDto>>(
                await _repoScMaintenanceQuotationDetails.GetAllIncluding(x => x.ScMaintenanceTechnicalReportDetail)
                                .Where(d => d.ScMaintenanceQuotationId == input.Id).ToListAsync()
                                );
        }

        public async Task<List<ScMaintenanceQuotationAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<ScMaintenanceQuotationAttachmentsDto>>(
                 await _repoScMaintenanceQuotationAttachments.GetAllIncluding().Where(d => d.ScMaintenanceQuotationId == input.Id).ToListAsync()
                );
        }

        public async Task<PostOutput> PostScMaintenanceQuotations(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _repoPost.Execute(postDto, "ScMaintenanceQuotationsPost");

            return result.FirstOrDefault();
        }

        #region Assets Methods

        private async Task InsertScMaintenanceQuotationDetailsData(ScMaintenanceQuotationDetailsDto detailsDto, long parentId)
        {
            detailsDto.ScMaintenanceQuotationId = parentId;

            var scMaintenanceQuotationDetails = ObjectMapper.Map<ScMaintenanceQuotationDetails>(detailsDto);

            _ = await _repoScMaintenanceQuotationDetails.InsertAsync(scMaintenanceQuotationDetails);
        }

        private async Task InsertAttachmentsData(ScMaintenanceQuotationAttachmentsDto attachmentsDto, long parentId)
        {
            attachmentsDto.ScMaintenanceQuotationId = parentId;

            var scMaintenanceQuotationAttachments = ObjectMapper.Map<ScMaintenanceQuotationAttachments>(attachmentsDto);

            _ = await _repoScMaintenanceQuotationAttachments.InsertAsync(scMaintenanceQuotationAttachments);
        }

        private async Task CRUD_ScMaintenanceQuotationDetails(ICollection<ScMaintenanceQuotationDetailsDto> detailsDtos, long parentId)
        {
            if (detailsDtos?.Count > 0)
            {
                foreach (var item in detailsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoScMaintenanceQuotationDetails.GetAsync((long)item.Id);

                        item.ScMaintenanceQuotationId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoScMaintenanceQuotationDetails.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertScMaintenanceQuotationDetailsData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScMaintenanceQuotationDetails.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_Attachment(ICollection<ScMaintenanceQuotationAttachmentsDto> attachmentsDtos, long parentId)
        {
            if (attachmentsDtos?.Count > 0)
            {
                foreach (var item in attachmentsDtos)
                {
                    if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertAttachmentsData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScMaintenanceQuotationAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        internal override async Task EntityCreatePreExecute(ScMaintenanceQuotationsCreateDto input)
        {
            if (input.MaintenanceQuotationDetails?.Count == 0)
                throw new Abp.UI.UserFriendlyException("Maintenance Quotation Details Required !!");

            input.QuotationNumber = await _entityCounterManager.GetEntityNumber("ScMaintenanceQuotations", (int)AbpSession.TenantId);
        }

        internal override async Task EntityCreatePostExecute(ScMaintenanceQuotationsCreateDto input, long EntityId)
        {
            if (input.MaintenanceQuotationDetails?.Count > 0)
                await CRUD_ScMaintenanceQuotationDetails(input.MaintenanceQuotationDetails, EntityId);
            if (input.MaintenanceQuotationAttachments?.Count > 0)
                await CRUD_Attachment(input.MaintenanceQuotationAttachments, EntityId);
        }

        internal override async Task EntityUpdatePreExecute(ScMaintenanceQuotationsEditDto input)
        {
            if (input.MaintenanceQuotationDetails?.Count == 0)
                throw new Abp.UI.UserFriendlyException("Maintenance Quotation Details Required !!");

            await CRUD_ScMaintenanceQuotationDetails(input.MaintenanceQuotationDetails, input.Id);
            await CRUD_Attachment(input.MaintenanceQuotationAttachments, input.Id);
        }

        internal override async Task EntityDeletePreExecute(EntityDto<long> input) { }

        #endregion
    }
}
