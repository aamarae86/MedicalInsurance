using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails
{
    public interface ITmCharityBoxActionDetailsMananger : IDomainService
    {
        
        Task<Select2PagedResult> GetCharityBoxActionDetailsForCollectSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetCharityBoxActionDetailsForDamagedSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
