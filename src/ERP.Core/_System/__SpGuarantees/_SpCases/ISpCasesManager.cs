using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCases
{
    public interface ISpCasesManager : IDomainService
    {
        Task<Select2PagedResult> GetSpCasesForContractsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetSpCasesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetSpCasesForReplaceNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetSpCasesForReplaceNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetSpCasesGrantedSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
