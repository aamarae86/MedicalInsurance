using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes
{
    public interface IPmOtherPaymentTypesManager : IDomainService
    {
        Task<Select2PagedResult> GetPmOtherPaymentTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
