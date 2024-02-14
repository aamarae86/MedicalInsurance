using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScMaintenanceContract.Dto;
using ERP._System.__AidModule._ScMaintenanceContract.Proc;
using ERP._System.__AidModule._ScMaintenanceContract.ProcDto;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Proc;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceContract
{
    [AbpAuthorize]
    public class ScMaintenanceContractAppService : BaseAsyncCrudEditedEntityAppService<ScMaintenanceContract, ScMaintenanceContractDto, long, ScMaintenanceContractPagedDto, ScMaintenanceContractCreateDto, ScMaintenanceContractEditDto>,
        IScMaintenanceContractAppService
    {
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly IScMaintenanceQuotationsManager _scMaintenanceQuotationsManager;
        private readonly IScMaintenanceContractManager _scMaintenanceContractManager;
        private readonly IScMaintenanceTechnicalReportPostRepository _repoPost;
        private readonly IGetScMaintenanceContractScreenDataRepository _getScMaintenanceContractScreenDataRepository;
        private readonly IRepository<ScMaintenanceContractPayments, long> _repoScMaintenanceContractPayments;

        public ScMaintenanceContractAppService(IRepository<ScMaintenanceContract, long> repository,
            IRepository<ScMaintenanceContractPayments, long> repoScMaintenanceContractPayments,
            IScMaintenanceContractManager scMaintenanceContractManager, IGetScMaintenanceContractScreenDataRepository getScMaintenanceContractScreenDataRepository,
            IEntityCounterManager entityCounterManager, IScMaintenanceQuotationsManager scMaintenanceQuotationsManager,
            IScMaintenanceTechnicalReportPostRepository scMaintenanceTechnicalReportPostRepository) : base(repository)
        {
            _entityCounterManager = entityCounterManager;
            _scMaintenanceContractManager = scMaintenanceContractManager;
            _repoPost = scMaintenanceTechnicalReportPostRepository;
            _scMaintenanceQuotationsManager = scMaintenanceQuotationsManager;
            _repoScMaintenanceContractPayments = repoScMaintenanceContractPayments;
            _getScMaintenanceContractScreenDataRepository = getScMaintenanceContractScreenDataRepository;

            CreatePermissionName = PermissionNames.Pages_ScMaintenanceContract_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScMaintenanceContract_Update;
            DeletePermissionName = PermissionNames.Pages_ScMaintenanceContract_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScMaintenanceContract;
        }

        protected override IQueryable<ScMaintenanceContract> CreateFilteredQuery(ScMaintenanceContractPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.ScMaintenanceQuotations);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MaintenanceContractNumber))
                iqueryable = iqueryable.Where(z => z.MaintenanceContractNumber.Contains(input.Params.MaintenanceContractNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.ScMaintenanceQuotationId != null)
                iqueryable = iqueryable.Where(z => z.ScMaintenanceQuotationId == input.Params.ScMaintenanceQuotationId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MaintenanceContractDate))
                iqueryable = iqueryable.Where(z => z.MaintenanceContractDate == DateTimeController.ConvertToDateTime(input.Params.MaintenanceContractDate));

            return iqueryable;
        }

        public async override Task<ScMaintenanceContractDto> Get(EntityDto<long> input)
            => ObjectMapper.Map<ScMaintenanceContractDto>(await Repository.GetAllIncluding(z => z.FndStatusLkp, x => x.ScMaintenanceQuotations, x => x.ScMaintenanceQuotations.ScMaintenanceQuotationDetails, x => x.ScMaintenanceQuotations.ApVendors, x => x.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalUser)
                    .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<IReadOnlyList<ScMaintenanceContractPaymentsDto>> GetAllPaymentsData(EntityDto<long> input)
        {
            return ObjectMapper.Map<IReadOnlyList<ScMaintenanceContractPaymentsDto>>(
                await _repoScMaintenanceContractPayments.GetAllListAsync(d => d.ScMaintenanceContractId == input.Id));
        }

        public async Task<PostOutput> PostScMaintenanceContract(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _repoPost.Execute(postDto, "ScMaintenanceContractPost");

            return result.FirstOrDefault();
        }

        public async Task<IReadOnlyList<GetScMaintenanceContractScreenDataOutputDto>> GetScMaintenanceContractScreenData(IdLangInputDto idLangInputDto)
        {
            var result = await _getScMaintenanceContractScreenDataRepository.Execute(idLangInputDto, "GetScMaintenanceContractScreenData");

            return result.ToList();
        }

        public async Task<Select2PagedResult> GetScMaintenanceQuotationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scMaintenanceQuotationsManager.GetScMaintenanceQuotationsSelect2(searchTerm, pageSize, pageNumber, lang);

        internal async override Task EntityCreatePreExecute(ScMaintenanceContractCreateDto input)
        {
            input.MaintenanceContractNumber = await _entityCounterManager.GetEntityNumber("ScMaintenanceContract", (int)AbpSession.TenantId);
        }

        internal async override Task EntityCreatePostExecute(ScMaintenanceContractCreateDto input, long EntityId)
        {
            if (input.MaintenanceContractPayments?.Count > 0)
                input.MaintenanceContractPayments.ToList()
                    .ForEach(async item =>
                {
                    await InsertPaymentsData(item, EntityId);
                });
        }

        internal async override Task EntityUpdatePreExecute(ScMaintenanceContractEditDto input)
        {
            await CRUD_Payments(input.MaintenanceContractPayments, input.Id);
        }

        private async Task InsertPaymentsData(ScMaintenanceContractPaymentsDto paymentsDto, long parentId)
        {
            paymentsDto.ScMaintenanceContractId = parentId;

            var payments = ObjectMapper.Map<ScMaintenanceContractPayments>(paymentsDto);

            _ = await _repoScMaintenanceContractPayments.InsertAsync(payments);
        }

        private async Task CRUD_Payments(ICollection<ScMaintenanceContractPaymentsDto> paymentsDtos, long parentId)
        {
            if (paymentsDtos?.Count > 0)
            {
                foreach (var item in paymentsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoScMaintenanceContractPayments.GetAsync((long)item.Id);

                        item.ScMaintenanceContractId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoScMaintenanceContractPayments.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertPaymentsData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScMaintenanceContractPayments.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        public async Task<Select2PagedResult> GetScMaintenanceContractPaymentsSelect2(long contractId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scMaintenanceContractManager.GetScMaintenanceContractPaymentsSelect2(contractId, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScMaintenanceContractPaymentsByContractNumberSelect2(string contractNumber, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scMaintenanceContractManager.GetScMaintenanceContractPaymentsByContractNumberSelect2(contractNumber, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScMaintenanceContractSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scMaintenanceContractManager.GetScMaintenanceContractSelect2(searchTerm, pageSize, pageNumber, lang);

    }
}
