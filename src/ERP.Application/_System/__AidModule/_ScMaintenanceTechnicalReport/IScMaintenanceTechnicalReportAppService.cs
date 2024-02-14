using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScMaintenanceQuotations.Dto;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport
{
    public interface IScMaintenanceTechnicalReportAppService : IAsyncCrudAppService<ScMaintenanceTechnicalReportDto, long, ScMaintenanceTechnicalReportPagedDto, ScMaintenanceTechnicalReportCreateDto, ScMaintenanceTechnicalReportEditDto>
    {
        Task<IReadOnlyList<ScMaintenanceTechnicalReportQuotationsDto>> GetAllScMaintenanceTechnicalReportQuotations(EntityDto<long> input);

        Task<Select2PagedResult> GetScMaintenanceTechnicalReportSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<PostOutput> PostScMaintenanceTechnicalReport(PostDto postDto);

        Task<List<ScMaintenanceTechnicalReportDetailDto>> GetAllAccountLineData(EntityDto<long> input);

        Task<List<ScMaintenanceTechnicalReportDetailDto>> GetMaintenanceTechnicalReportDetailForMaintenanceQuotations(EntityDto<long> input);
    }
}
