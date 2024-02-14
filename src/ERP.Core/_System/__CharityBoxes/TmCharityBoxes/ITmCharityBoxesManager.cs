using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxes
{
    public interface ITmCharityBoxesManager : IDomainService
    {
        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long? statuslkpId = null);

        Task<(long id, string text)> GetCharityBoxByLocation(long locationId);
    }

}
