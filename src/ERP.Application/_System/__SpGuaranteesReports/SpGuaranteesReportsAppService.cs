using Abp.UI;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP._System.__SpGuaranteesReports.Inputs;
using ERP._System.__SpGuaranteesReports.Outputs;
using ERP._System.__SpGuaranteesReports.Proc;
using ERP.Authorization;
using ERP.Authorization.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuaranteesReports
{
    [Abp.Authorization.AbpAuthorize]
    public class SpGuaranteesReportsAppService : ERPAppServiceBase, ISpGuaranteesReportsAppService
    {
        private readonly ISpCaseOperationsDataListRepository _spCaseOperationsDataListRepository;
        private readonly IGetSpCaseListrptRepository _spCaseListrptRepository;
        private readonly IGetSpCaseListUpTo18YearrptRepository _getSpCaseListUpTo18YearrptRepository;
        private readonly UserManager _userManager;
        private readonly IVendorItemReportRepository _itemReportRepository;
        public SpGuaranteesReportsAppService(
            UserManager userManager,
            ISpCaseOperationsDataListRepository spCaseOperationsDataListRepository,
            IGetSpCaseListUpTo18YearrptRepository getSpCaseListUpTo18YearrptRepository,
            IGetSpCaseListrptRepository spCaseListrptRepository,
            IVendorItemReportRepository itemReportRepository)
        {
            _getSpCaseListUpTo18YearrptRepository = getSpCaseListUpTo18YearrptRepository;
            _userManager = userManager;
            _spCaseOperationsDataListRepository = spCaseOperationsDataListRepository;
            _spCaseListrptRepository = spCaseListrptRepository;
            _itemReportRepository = itemReportRepository;
        }

        public async Task<List<SpCaseOperationsDataListOutput>> GetCaseOperationsDataList(SpCaseOperationsDataListInputHelper input)
        {
            var userPermissions = await _userManager.GetGrantedPermissionsAsync(await _userManager.GetUserByIdAsync((long)AbpSession.UserId));

            if (input.TypeId != 711 && input.TypeId != 710 && input.TypeId != 724)
                throw new UserFriendlyException("Invalid");

            if (input.TypeId == 711 && !userPermissions.Any(x => x.Name.Contains(PermissionNames.Pages_SpCaseCancelOperationReport)))
                throw new UserFriendlyException("لا يوجد صلاحية لك قائمة الأيتام الملغية");

            if (input.TypeId == 710 && !userPermissions.Any(x => x.Name.Contains(PermissionNames.Pages_SpCaseTurnOffOperationReport)))
                throw new UserFriendlyException("لا يوجد صلاحية لك قائمة الأيتام المتوقفة");

            if (input.TypeId == 724 && !userPermissions.Any(x => x.Name.Contains(PermissionNames.Pages_SpCaseReplaceOperationReport)))
                throw new UserFriendlyException("لا يوجد صلاحية لك  قائمة الإستبدالات");

            input.TenantId = ((int)AbpSession.TenantId);

            var inputProc = ObjectMapper.Map<SpCaseOperationsDataListInput>(input);

            var result = await _spCaseOperationsDataListRepository.Execute(inputProc, "GetSpCaseOperationsrpt");

            return result.ToList();
        }

        public async Task<List<GetSpCaseListrptOutput>> GetIGetSpCaseListrpt(GetSpCaseListrptInput input)
        {
            input.TenantId = ((int)AbpSession.TenantId);

            var result = await _spCaseListrptRepository.Execute(input, "GetSpCaseListrpt");

            return result.ToList();
        }

        public async Task<List<GetSpCaseListUpTo18YearrptOutput>> GetSpCaseListUpTo18Yearrpt(GetSpCaseListUpTo18YearrptInput input)
        {
            input.TenantId = ((int)AbpSession.TenantId);

            var result = await _getSpCaseListUpTo18YearrptRepository.Execute(input, "GetSpCaseListUpTo18Yearrpt");

            return result.ToList();
        }

        public async Task<List<GetVendorItemReportDataOutput>> GetrptApDebitCredit(VendorItemReportInput input)
        {
            input.TenantId = ((int)AbpSession.TenantId);

            var result = await _itemReportRepository.Execute(input, "rptApDebitCredit");

            return result.ToList();
        }
    }
}
