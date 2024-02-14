using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Proc;
using ERP._System.__SpGuarantees._SpPayments.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpPayments
{
    [AbpAuthorize]
    public class SpPaymentsAppService : BaseAsyncCrudEditedEntityAppService<SpPayments, SpPaymentsDto, long, SpPaymentsPagedDto, SpPaymentsCreateDto, SpPaymentsEditDto>,
        ISpPaymentsAppService
    {
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly IScMaintenanceTechnicalReportPostRepository _repoPost;
        private readonly IRepository<SpPaymentPersons, long> _repoSpPaymentPersons;
        private readonly IRepository<SpPaymentPersonDetails, long> _repoSpPaymentPersonDetails;

        public SpPaymentsAppService(IRepository<SpPayments, long> repository,
            IRepository<SpPaymentPersons, long> repoSpPaymentPersons, IRepository<SpPaymentPersonDetails, long> repoSpPaymentPersonDetails,
            IEntityCounterManager entityCounterManager, IScMaintenanceTechnicalReportPostRepository scMaintenanceTechnicalReportPostRepository) : base(repository)
        {
            _entityCounterManager = entityCounterManager;
            _repoSpPaymentPersons = repoSpPaymentPersons;
            _repoSpPaymentPersonDetails = repoSpPaymentPersonDetails;
            _repoPost = scMaintenanceTechnicalReportPostRepository;

            CreatePermissionName = PermissionNames.Pages_SpPayments_Insert;
            UpdatePermissionName = PermissionNames.Pages_SpPayments_Update;
            DeletePermissionName = PermissionNames.Pages_SpPayments_Delete;
            GetAllPermissionName = PermissionNames.Pages_SpPayments;
        }

        protected override IQueryable<SpPayments> CreateFilteredQuery(SpPaymentsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.SpCases, x => x.FromPeriod, x => x.ToPeriod, x => x.FndSponsorCategoryLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PaymentNumber))
                iqueryable = iqueryable.Where(z => z.PaymentNumber.Contains(input.Params.PaymentNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.SpCasesId != null)
                iqueryable = iqueryable.Where(z => z.SpCaseId == input.Params.SpCasesId);

            return iqueryable;
        }

        public async override Task<SpPaymentsDto> Get(EntityDto<long> input)
        {
            return ObjectMapper.Map<SpPaymentsDto>(await Repository.GetAllIncluding(x => x.SpCases, x => x.FndStatusLkp, x => x.FromPeriod, x => x.ToPeriod, x => x.FndSponsorCategoryLkp)
                    .Where(z => z.Id == input.Id).FirstOrDefaultAsync());
        }

        internal async override Task EntityCreatePreExecute(SpPaymentsCreateDto input)
              => input.PaymentNumber = await _entityCounterManager.GetEntityNumber("SpPayments", (int)AbpSession.TenantId);

        internal async override Task EntityUpdatePreExecute(SpPaymentsEditDto input) { }

        internal async override Task EntityCreatePostExecute(SpPaymentsCreateDto input, long EntityId) { }

        public async Task<PostOutput> SpPaymentsApprove(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _repoPost.Execute(postDto, "SpPaymentsApprove");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> SpPaymentsUnApprove(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _repoPost.Execute(postDto, "SpPaymentsUnApprove");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> SpPaymentsPost(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _repoPost.Execute(postDto, "SpPaymentsPost");

            return result.FirstOrDefault();
        }

        public async Task<IReadOnlyList<SpPaymentPersonsDto>> GetSpPaymentsPersonData(EntityDto<long> input)
        {
            return ObjectMapper.Map<IReadOnlyList<SpPaymentPersonsDto>>
                (await _repoSpPaymentPersons.GetAllIncluding(x => x.SpCases, x => x.SpCases.FndLookupValuesStatusLkp, x => x.FndSponsorCategoryLkp)
                   .Where(z => z.SpPaymentId == input.Id).ToListAsync());
        }

        public async Task<IReadOnlyList<SpPaymentPersonDetailsDto>> GetSpPaymentsPersonDetailsData(EntityDto<long> input)
        {
            return ObjectMapper.Map<IReadOnlyList<SpPaymentPersonDetailsDto>>
                (await _repoSpPaymentPersonDetails.GetAllIncluding(x => x.Period, x => x.SpContractDetails.FndCaseStatusLkp, x => x.SpContractDetails.SpCases)
                   .Where(z => z.SpPaymentPersonId == input.Id).ToListAsync());
        }
    }

}
