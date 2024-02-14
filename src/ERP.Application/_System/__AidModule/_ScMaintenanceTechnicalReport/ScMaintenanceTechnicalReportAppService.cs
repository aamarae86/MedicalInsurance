using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using ERP._System.__AidModule._ScMaintenanceQuotations.Dto;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Proc;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport
{
    [AbpAuthorize]
    public class ScMaintenanceTechnicalReportAppService : AttachBaseAsyncCrudEditedEntityAppService<ScMaintenanceTechnicalReport, ScMaintenanceTechnicalReportDto, long, ScMaintenanceTechnicalReportPagedDto, ScMaintenanceTechnicalReportCreateDto, ScMaintenanceTechnicalReportEditDto, ScMaintenanceTechnicalReportAttachments>,
        IScMaintenanceTechnicalReportAppService
    {
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly IScMaintenanceTechnicalReportPostRepository _repoPost;
        private readonly IScMaintenanceTechnicalReportManager _scMaintenanceTechnicalReportManager;
        private readonly IRepository<ScMaintenanceTechnicalReportAttachments, long> _repoAttachments;
        private readonly IRepository<ScMaintenanceTechnicalReportDetail, long> _repoScMaintenanceTechnicalReportDetail;
        private readonly IRepository<ScMaintenanceQuotations, long> _repoScMaintenanceQuotations;

        public ScMaintenanceTechnicalReportAppService(IRepository<ScMaintenanceTechnicalReport, long> repository,
            IRepository<ScMaintenanceTechnicalReportDetail, long> repoScMaintenanceTechnicalReportDetail,
            IRepository<ScMaintenanceQuotations, long> repoScMaintenanceQuotations,
            IEntityCounterManager entityCounterManager, IScMaintenanceTechnicalReportPostRepository repoPost,
            IScMaintenanceTechnicalReportManager scMaintenanceTechnicalReportManager,
            IRepository<ScMaintenanceTechnicalReportAttachments, long> repoAttachments,
            IConfiguration config) : base(repository, config)
        {
            _repoScMaintenanceTechnicalReportDetail = repoScMaintenanceTechnicalReportDetail;
            _scMaintenanceTechnicalReportManager = scMaintenanceTechnicalReportManager;
            _repoScMaintenanceQuotations = repoScMaintenanceQuotations;
            _entityCounterManager = entityCounterManager;
            _repoAttachments = repoAttachments;
            _repoPost = repoPost;

            CreatePermissionName = PermissionNames.Pages_ScMaintenanceTechnicalReport_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScMaintenanceTechnicalReport_Update;
            DeletePermissionName = PermissionNames.Pages_ScMaintenanceTechnicalReport_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScMaintenanceTechnicalReport;

            PreFileName = "Sc-Attchs";
            ServiceFolder = "ScMaintenanceTechnicalReport";
        }

        protected override IQueryable<ScMaintenanceTechnicalReport> CreateFilteredQuery(ScMaintenanceTechnicalReportPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.PortalRequest, x => x.Details, x => x.Attachments);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TechnicalReportNumber))
                iqueryable = iqueryable.Where(z => z.TechnicalReportNumber.Contains(input.Params.TechnicalReportNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PortalRequestNumber))
                iqueryable = iqueryable.Where(z => z.PortalRequest.PortalRequestNumber.Contains(input.Params.PortalRequestNumber));

            if (input.Params != null && input.Params.PortalUserId != null)
                iqueryable = iqueryable.Where(z => z.PortalRequest.PortalUsersId == input.Params.PortalUserId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TechnicalReportDate))
                iqueryable = iqueryable.Where(z => z.TechnicalReportDate == DateTimeController.ConvertToDateTime(input.Params.TechnicalReportDate));

            return iqueryable;
        }

        public async override Task<ScMaintenanceTechnicalReportDto> Get(EntityDto<long> input)
            => ObjectMapper.Map<ScMaintenanceTechnicalReportDto>(await Repository
                           .GetAllIncluding(z => z.Details, z => z.Attachments, z => z.PortalRequest, z => z.FndStatusLkp)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<List<ScMaintenanceTechnicalReportDetailDto>> GetAllAccountLineData(EntityDto<long> input)
        {
            var listData = await _repoScMaintenanceTechnicalReportDetail.GetAllIncluding()
                                .Where(d => d.ScMaintenanceTechnicalReportId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<ScMaintenanceTechnicalReportDetailDto>>(listData);
        }

        public async Task<List<ScMaintenanceTechnicalReportAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<ScMaintenanceTechnicalReportAttachmentsDto>>(
                 await _repoAttachments.GetAllIncluding().Where(d => d.ScMaintenanceTechnicalReportId == input.Id).ToListAsync()
                );
        }

        public async Task<PostOutput> PostScMaintenanceTechnicalReport(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _repoPost.Execute(postDto, "ScMaintenanceTechnicalReportPost");

            return result.FirstOrDefault();
        }

        public async Task<List<ScMaintenanceTechnicalReportDetailDto>> GetMaintenanceTechnicalReportDetailForMaintenanceQuotations(EntityDto<long> input)
        {
            var listData = await _repoScMaintenanceTechnicalReportDetail.GetAllIncluding()
                              .Where(d => d.ScMaintenanceTechnicalReportId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<ScMaintenanceTechnicalReportDetailDto>>(listData);
        }

        public async Task<IReadOnlyList<ScMaintenanceTechnicalReportQuotationsDto>> GetAllScMaintenanceTechnicalReportQuotations(EntityDto<long> input)
        {
            var data = await _repoScMaintenanceQuotations.GetAllIncluding(x => x.FndStatusLkp, x => x.ApVendors, x => x.ScMaintenanceQuotationDetails)
                                                   .Where(x => x.ScMaintenanceTechnicalReportId == input.Id)
                                                   .ToListAsync();

            return ObjectMapper.Map<IReadOnlyList<ScMaintenanceTechnicalReportQuotationsDto>>(data);
        }

        public async Task<Select2PagedResult> GetScMaintenanceTechnicalReportSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scMaintenanceTechnicalReportManager.GetScMaintenanceTechnicalReportSelect2(searchTerm, pageSize, pageNumber, lang);

        #region Assets Methods

        private async Task InsertAccountLineData(ScMaintenanceTechnicalReportDetailDto scMaintenanceTechnicalReportDetailsDto, long parentId)
        {
            scMaintenanceTechnicalReportDetailsDto.ScMaintenanceTechnicalReportId = parentId;

            var scMaintenanceTechnicalReportDetail = ObjectMapper.Map<ScMaintenanceTechnicalReportDetail>(scMaintenanceTechnicalReportDetailsDto);

            _ = await _repoScMaintenanceTechnicalReportDetail.InsertAsync(scMaintenanceTechnicalReportDetail);
        }

        private async Task InsertAttachmentsData(ScMaintenanceTechnicalReportAttachmentsDto scMaintenanceTechnicalReportAttachmentsDto, long parentId)
        {
            scMaintenanceTechnicalReportAttachmentsDto.ScMaintenanceTechnicalReportId = parentId;

            var Attachs = ObjectMapper.Map<ScMaintenanceTechnicalReportAttachments>(scMaintenanceTechnicalReportAttachmentsDto);

            _ = await _repoAttachments.InsertAsync(Attachs);
        }

        private async Task CRUD_AccountLine(ICollection<ScMaintenanceTechnicalReportDetailDto> accountsLinesDtos, long parentId)
        {
            if (accountsLinesDtos?.Count > 0)
            {
                foreach (var item in accountsLinesDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoScMaintenanceTechnicalReportDetail.GetAsync((long)item.Id);

                        item.ScMaintenanceTechnicalReportId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoScMaintenanceTechnicalReportDetail.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertAccountLineData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScMaintenanceTechnicalReportDetail.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_Attachment(ICollection<ScMaintenanceTechnicalReportAttachmentsDto> customersLinesDtos, long parentId)
        {
            if (customersLinesDtos?.Count > 0)
            {
                foreach (var item in customersLinesDtos)
                {
                    if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertAttachmentsData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        internal override async Task EntityCreatePreExecute(ScMaintenanceTechnicalReportCreateDto input)
        {
            input.TechnicalReportNumber = await _entityCounterManager.GetEntityNumber("ScMaintenanceTechnicalReport", (int)AbpSession.TenantId);
        }

        internal override async Task EntityCreatePostExecute(ScMaintenanceTechnicalReportCreateDto input, long EntityId)
        {
            if (input.ListOfDetails?.Count > 0)
                //foreach (var item in input.ListOfDetails)
                await CRUD_AccountLine(input.ListOfDetails, EntityId);
            if (input.ListOfAttachs?.Count > 0)
                //foreach (var item in input.ListOfAttachs)
                await CRUD_Attachment(input.ListOfAttachs, EntityId);
        }

        internal override async Task EntityUpdatePreExecute(ScMaintenanceTechnicalReportEditDto input)
        {
            await CRUD_AccountLine(input.ListOfDetails, input.Id);
            await CRUD_Attachment(input.ListOfAttachs, input.Id);
        }

        internal override async Task EntityDeletePreExecute(EntityDto<long> input)
        {

        }

        #endregion
    }
}
