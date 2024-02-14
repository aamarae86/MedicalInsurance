using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmLocations
{
    public interface ITmLocationSubManager : IDomainService
    {
        Task<Select2PagedResult> GetLoactionForBoxesSelect2(long actionLkpId, string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetTmLocationSubSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetTmLocationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
