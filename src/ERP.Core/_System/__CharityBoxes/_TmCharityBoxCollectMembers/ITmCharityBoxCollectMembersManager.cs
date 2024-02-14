using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers
{
    public interface ITmCharityBoxCollectMembersManager : IDomainService
    {
        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
