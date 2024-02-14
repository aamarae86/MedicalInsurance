using Abp.UI;
using ERP._System.__ReportsAids.Input;
using ERP._System.__ReportsAids.Output;
using ERP._System.__ReportsAids.Proc;
using ERP.Authorization;
using ERP.Authorization.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__ReportsAids
{
    public class ReportsAidsAppService : ERPAppServiceBase, IReportsAidsAppService
    {
        private readonly UserManager _userManager;
        private readonly IRptScPortalAidsRepository _rptScPortalAidsRepository;
        private readonly IGetrptScPortalAidsPerNationalityRepository _getrptScPortalAidsPerNationalityRepository;
        private readonly IGeSCCasesListScreenDataRepository _geSCCasesListScreenDataRepository;

        public ReportsAidsAppService(IRptScPortalAidsRepository rptScPortalAidsRepository,
            IGeSCCasesListScreenDataRepository geSCCasesListScreenDataRepository,
            IGetrptScPortalAidsPerNationalityRepository getrptScPortalAidsPerNationalityRepository,
            UserManager userManager)
        {
            _geSCCasesListScreenDataRepository = geSCCasesListScreenDataRepository;
            _getrptScPortalAidsPerNationalityRepository = getrptScPortalAidsPerNationalityRepository;
            _rptScPortalAidsRepository = rptScPortalAidsRepository;
            _userManager = userManager;
        }

        public async Task<List<rptScPortalAidsPerNationalityOutput>> GetrptScPortalAidsPerNationality(rptScPortalAidsPerNationalityHelperInput input)
        {
            input.TenantId = AbpSession.TenantId.Value;

            var inputProc = ObjectMapper.Map<rptScPortalAidsPerNationalityInput>(input);

            var result = await _getrptScPortalAidsPerNationalityRepository.Execute(inputProc, "rptScPortalAidsPerNationality");

            return result.ToList<rptScPortalAidsPerNationalityOutput>();
        }

        public async Task<List<RptScPortalAidsOutput>> GetRptScPortalAids(RptScPortalAidsInputHelper inputHelper)
        {
            var userPermissions = await _userManager.GetGrantedPermissionsAsync(await _userManager.GetUserByIdAsync((long)AbpSession.UserId));

            if (!userPermissions.Any(x => x.Name.Contains(PermissionNames.Pages_ReportsAids)))
                throw new UserFriendlyException("not authorized!!");

            inputHelper.TenantId = AbpSession.TenantId.Value;

            var input = ObjectMapper.Map<RptScPortalAidsInput>(inputHelper);

            var result = await _rptScPortalAidsRepository.Execute(input, "rptScPortalAids");

            return result.ToList();
        }

        public async Task<List<GeSCCasesListScreenDataOutput>> GetSCCasesListScreenData(GeSCCasesListScreenDataInput input)
        {
            input.TenantId = AbpSession.TenantId.Value;

            var result = await _geSCCasesListScreenDataRepository.Execute(input, "GeSCCasesListScreenData");

            return result.ToList<GeSCCasesListScreenDataOutput>();
        }
    }
}
