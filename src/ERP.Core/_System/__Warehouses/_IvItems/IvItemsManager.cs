using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvItems
{
    public class IvItemsManager : IIvItemsManager
    {
        private readonly IRepository<IvItems, long> _repoIvItems;

        public IvItemsManager(IRepository<IvItems, long> repoIvItems)
        {
            _repoIvItems = repoIvItems;
        }

        public async Task<Select2PagedResult> GetIvItemsForReceiveSelect2(long IvReceiveHdReceiveTypeId, string searchTerm, int pageSize, int pageNumber, string lang)
        {

            bool? IsDonationItem = (IvReceiveHdReceiveTypeId == 765) ? true : false;

            var data = _repoIvItems.GetAll()
               .Where(z => (!z.IsItemObsolete ?? false) && (z.IsDonationItem == null || z.IsDonationItem == IsDonationItem)
                           && (string.IsNullOrEmpty(searchTerm) || z.ItemName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.ItemName, altText = z.ItemNumber, additional=z.TaxPercentageLkpId.ToString()})
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetIvItemsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoIvItems.GetAll()
                .Where(z => (!z.IsItemObsolete ?? false) && (string.IsNullOrEmpty(searchTerm) || z.ItemName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.ItemName, altText = z.ItemNumber })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }


    }
}
