using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr
{
    [AbpAuthorize]
    public class FmMaintRequisitionsHdrAppService
         : AsyncCrudAppService<FmMaintRequisitionsHdr, FmMaintRequisitionsHdrDto, long, FmMaintRequisitionsHdrPagedDto, FmMaintRequisitionsHdrCreateDto, FmMaintRequisitionsHdrEditDto>, IFmMaintRequisitionsHdrAppService
    {
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly IPmPropertiesManager _pmPropertiesManager;

        public FmMaintRequisitionsHdrAppService(IRepository<FmMaintRequisitionsHdr, long> repository,
            IEntityCounterManager entityCounterManager, IPmPropertiesManager pmPropertiesManager) : base(repository)
        {

            _entityCounterManager = entityCounterManager;
            _pmPropertiesManager = pmPropertiesManager;

            CreatePermissionName = PermissionNames.Pages_FmMaintRequisitionsHdr_Insert;
            UpdatePermissionName = PermissionNames.Pages_FmMaintRequisitionsHdr_Update;
            DeletePermissionName = PermissionNames.Pages_FmMaintRequisitionsHdr_Delete;
            GetAllPermissionName = PermissionNames.Pages_FmMaintRequisitionsHdr;
        }

        protected override IQueryable<FmMaintRequisitionsHdr> CreateFilteredQuery(FmMaintRequisitionsHdrPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndComplaintTypeLkp, x => x.FndRequisitionStatusLkp, x => x.PmProperties);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.RequisitionNumber))
                iqueryable = iqueryable.Where(z => z.RequisitionNumber.Contains(input.Params.RequisitionNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.RequisitionDate))
                iqueryable = iqueryable.Where(z => z.RequisitionDate == DateTimeController.ConvertToDateTime(input.Params.RequisitionDate));

            if (input.Params != null && input.Params.RequisitionStatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.RequisitionStatusLkpId == input.Params.RequisitionStatusLkpId);

            if (input.Params != null && input.Params.PmPropertiesId != null)
                iqueryable = iqueryable.Where(z => z.PmPropertiesId == input.Params.PmPropertiesId);

            return iqueryable;
        }

        public async override Task<FmMaintRequisitionsHdrDto> Get(EntityDto<long> input)
            => ObjectMapper.Map<FmMaintRequisitionsHdrDto>(await Repository.GetAllIncluding(x => x.FndComplaintTypeLkp, x => x.FndRequisitionStatusLkp, x => x.PmProperties, x => x.FndUnitTypeLkp, x => x.PmPropertiesUnits)
                                          .Where(x => x.Id == input.Id).FirstOrDefaultAsync());

        public async override Task<FmMaintRequisitionsHdrDto> Create(FmMaintRequisitionsHdrCreateDto input)
        {
            input.RequisitionNumber = await _entityCounterManager.GetEntityNumber("FmMaintRequisitionsHdr", (int)AbpSession.TenantId);

            return await base.Create(input);
        }

        public async Task<Select2PagedResult> GetPmPropertiesUnitsByPmPropIdSelect2(long propertyId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pmPropertiesManager.GetPmPropertiesUnitsByPmPropIdSelect2(propertyId, searchTerm, pageSize, pageNumber, lang);
    }
}
