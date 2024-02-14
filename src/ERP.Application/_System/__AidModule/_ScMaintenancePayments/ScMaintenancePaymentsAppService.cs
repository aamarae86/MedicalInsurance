using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScMaintenanceContract;
using ERP._System.__AidModule._ScMaintenanceContract.Dto;
using ERP._System.__AidModule._ScMaintenancePayments;
using ERP._System.__AidModule._ScMaintenancePayments.Dto;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Proc;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenancePayments
{
    [AbpAuthorize]
    public class ScMaintenancePaymentsAppService : BaseAsyncCrudEditedEntityAppService<ScMaintenancePayments, ScMaintenancePaymentsDto, long, ScMaintenancePaymentsPagedDto, ScMaintenancePaymentsCreateDto, ScMaintenancePaymentsEditDto>,
        IScMaintenancePaymentsAppService
    {
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly IScMaintenanceTechnicalReportPostRepository _repoPost;

        public ScMaintenancePaymentsAppService(IRepository<ScMaintenancePayments, long> repository,
            IEntityCounterManager entityCounterManager, IScMaintenanceTechnicalReportPostRepository repoPost) : base(repository)
        {
            _entityCounterManager = entityCounterManager;
            _repoPost = repoPost;

            CreatePermissionName = PermissionNames.Pages_ScMaintenancePayments_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScMaintenancePayments_Update;
            DeletePermissionName = PermissionNames.Pages_ScMaintenancePayments_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScMaintenancePayments;
        }

        protected override IQueryable<ScMaintenancePayments> CreateFilteredQuery(ScMaintenancePaymentsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.ScMaintenanceContractPayments.ScMaintenanceContract.ScMaintenanceQuotations.ApVendors);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MaintenancePaymentNumber))
                iqueryable = iqueryable.Where(z => z.MaintenancePaymentNumber.Contains(input.Params.MaintenancePaymentNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MaintenanceContractNumber))
                iqueryable = iqueryable.Where(z => z.ScMaintenanceContractPayments.ScMaintenanceContract.MaintenanceContractNumber.Contains(input.Params.MaintenanceContractNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.VendorId != null)
                iqueryable = iqueryable.Where(z => z.ScMaintenanceContractPayments.ScMaintenanceContract.ScMaintenanceQuotations.VendorId == input.Params.VendorId);

            if (input.Params != null && input.Params.ScMaintenanceContractPaymentId != null)
                iqueryable = iqueryable.Where(z => z.ScMaintenanceContractPaymentId == input.Params.ScMaintenanceContractPaymentId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MaintenancePaymentDate))
                iqueryable = iqueryable.Where(z => z.MaintenancePaymentDate == DateTimeController.ConvertToDateTime(input.Params.MaintenancePaymentDate));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MaturityDate))
                iqueryable = iqueryable.Where(z => z.ScMaintenanceContractPayments.MaturityDate == DateTimeController.ConvertToDateTime(input.Params.MaturityDate));

            return iqueryable;
        }

        public async override Task<ScMaintenancePaymentsDto> Get(EntityDto<long> input)
        {
            var mapped = ObjectMapper.Map<ScMaintenancePaymentsDto>(await Repository.GetAllIncluding(z => z.FndStatusLkp,
                x => x.ScMaintenanceContractPayments.ScMaintenanceContract.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalUser,
                x => x.ScMaintenanceContractPayments.ScMaintenanceContract.ScMaintenanceQuotations.ApVendors)
                    .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

            return mapped;
        }

        public async Task<IReadOnlyList<ScMaintenanceContractPaymentsDto>> GetAllPaymentsData(EntityDto<long> input)
        {
            long paymentPostedLkpId = 10948;

            var data = await Repository.GetAllIncluding(x => x.ScMaintenanceContractPayments).Where(d => d.StatusLkpId == paymentPostedLkpId && d.ScMaintenanceContractPayments.ScMaintenanceContractId == input.Id).ToListAsync();

            return ObjectMapper.Map<IReadOnlyList<ScMaintenanceContractPaymentsDto>>(data);
        }

        public async Task<PostOutput> PostScMaintenancePayments(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _repoPost.Execute(postDto, "ScMaintenancePaymentsPost");

            return result.FirstOrDefault();
        }

        internal async override Task EntityCreatePreExecute(ScMaintenancePaymentsCreateDto input)
              => input.MaintenancePaymentNumber = await _entityCounterManager.GetEntityNumber("ScMaintenancePayments", (int)AbpSession.TenantId);

        internal async override Task EntityCreatePostExecute(ScMaintenancePaymentsCreateDto input, long EntityId) { }

        internal async override Task EntityUpdatePreExecute(ScMaintenancePaymentsEditDto input) { }
    }
}
