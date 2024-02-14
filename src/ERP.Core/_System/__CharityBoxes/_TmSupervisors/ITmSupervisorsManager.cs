using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmSupervisors
{
    public interface ITmSupervisorsManager:IDomainService
    {
        Task<Select2PagedResult> GetTmSupervisorsBoxesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
