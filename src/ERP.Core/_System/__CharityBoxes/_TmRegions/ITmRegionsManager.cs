using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmRegions
{
    public interface ITmRegionsManager : IDomainService
    {
        Task<Select2PagedResult> GetTmRegionsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }

}
