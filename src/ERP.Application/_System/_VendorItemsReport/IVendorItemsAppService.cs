using Abp.Application.Services.Dto;
using ERP._System._VendorItemsReport.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._VendorItemsReport
{
    public interface IVendorItemsAppService
    {
        Task<PagedResultDto<VendorItemDto>> GetItemMovementsForVendor(VendorItemPagedDto input);
    }
}
