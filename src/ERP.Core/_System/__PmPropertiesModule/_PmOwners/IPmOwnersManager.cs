using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmOwners
{
    public interface IPmOwnersManager : IDomainService
    {
        Task<Select2PagedResult> PmOwnersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> PmOwnersNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
