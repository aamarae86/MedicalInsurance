using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._TmCharityBoxesType
{
    public interface ITmCharityBoxesTypeManager : IDomainService
    {
        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
