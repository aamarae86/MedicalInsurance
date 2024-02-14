using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders
{
    public interface IGlJeIntegrationHeadersManager : IDomainService
    {
        Task<Select2PagedResult> GetGlJeIntegration_Headers_Line_Cr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetGlJeIntegration_Headers_Line_Dr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang);
    }
}
