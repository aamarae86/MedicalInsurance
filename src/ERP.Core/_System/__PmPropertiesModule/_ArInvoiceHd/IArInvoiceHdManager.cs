using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._ArInvoiceHd
{
    public interface IArInvoiceHdManager : IDomainService
    {
        Task<Select2PagedResult> GetArInvoiceHd_ArInvoiceTr_NumSelect2(string searchTerm, long ArCustomerId, int pageSize, int pageNumber, string lang);
    }
}
