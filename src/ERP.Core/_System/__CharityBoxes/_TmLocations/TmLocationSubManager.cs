using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails;
using ERP._System.__CharityBoxes._TmCharityBoxes;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System.__CharityBoxes._TmLocations
{
    public class TmLocationSubManager : ITmLocationSubManager
    {
        private readonly IRepository<TmLocationSub, long> _repoTmLocationSub;
        private readonly IRepository<TmLocations, long> _repoTmLocations;
        private readonly IRepository<TmCharityBoxes, long> _repoTmCharityBoxes;
        private readonly IRepository<TmCharityBoxActionDetails, long> _repoTmCharityBoxActionDetails;

        public TmLocationSubManager(
            IRepository<TmLocationSub, long> repoTmLocationSub,
            IRepository<TmLocations, long> repoTmLocations,
            IRepository<TmCharityBoxes, long> repoTmCharityBoxes,
            IRepository<TmCharityBoxActionDetails, long> repoTmCharityBoxActionDetails)
        {
            _repoTmLocationSub = repoTmLocationSub;
            _repoTmLocations = repoTmLocations;
            _repoTmCharityBoxes = repoTmCharityBoxes;
            _repoTmCharityBoxActionDetails = repoTmCharityBoxActionDetails;
        }

        public async Task<Select2PagedResult> GetLoactionForBoxesSelect2(long actionLkpId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoTmLocationSub.GetAllIncluding(
                        z => z.TmLocation,
                        z => z.TmLocation.Region,
                        z => z.TmLocation.Region.FndLookupValues);

            if (actionLkpId == 619)
            {
                var locationsInCharityBox = _repoTmCharityBoxes.GetAll().Where(z => z.TmSubLocationId != null).Select(z => z.TmSubLocationId);
                var locationsInActionDetails = _repoTmCharityBoxActionDetails.GetAllIncluding(x => x.TmCharityBoxActions)
                                 .Where(z => z.TmCharityBoxActions.StatusLkpId == 617).Select(z => z.TmLocationSubId);

                data = data.Where(z => !locationsInCharityBox.Contains(z.Id) && !locationsInActionDetails.Contains(z.Id)
                                  && (string.IsNullOrEmpty(searchTerm) || (z.TmLocationSubName.Contains(searchTerm))));
            }
            else if (actionLkpId == 620 || actionLkpId == 621 || actionLkpId == 622 || actionLkpId == 623)
            {
                var locationsInCharityBox = _repoTmCharityBoxes.GetAll().Where(z => z.StatusLkpId == 597)
                                                               .Select(z => z.TmSubLocationId);

                data = data.Where(z => locationsInCharityBox.Contains(z.Id)
                                  && (string.IsNullOrEmpty(searchTerm) || (z.TmLocationSubName.Contains(searchTerm))));
            }
            else return new Select2PagedResult { };


            long count = await data.LongCountAsync();

            var result = await data
                        .OrderBy(q => q.Id)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(z => new Select2OptionModel
                        {
                            id = z.Id,
                            text =
                                $"{z.TmLocation.Region.FndLookupValues.NameAr}-" +
                                $"{z.TmLocation.Region.RegionName}-" +
                                $"{z.TmLocation.LocationName}-" +
                                $"{z.TmLocationSubName}",
                        })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<Select2PagedResult> GetTmLocationSubSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoTmLocationSub.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (z.TmLocationSubName.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.TmLocationSubName}).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<Select2PagedResult> GetTmLocationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoTmLocations.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (z.LocationName.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.LocationName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
