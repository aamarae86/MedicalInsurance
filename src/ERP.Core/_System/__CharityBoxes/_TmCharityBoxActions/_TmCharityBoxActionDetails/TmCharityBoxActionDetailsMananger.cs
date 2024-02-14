using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails
{
    public class TmCharityBoxActionDetailsMananger : ITmCharityBoxActionDetailsMananger
    {
        private readonly IRepository<TmCharityBoxActionDetails, long> _repoTmCharityBoxActionDetails;

        public TmCharityBoxActionDetailsMananger(IRepository<TmCharityBoxActionDetails, long> repoTmCharityBoxActionDetails)
        {
            _repoTmCharityBoxActionDetails = repoTmCharityBoxActionDetails;
        }

        public async Task<Select2PagedResult> GetCharityBoxActionDetailsForCollectSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoTmCharityBoxActionDetails
                .GetAllIncluding(
                        x => x.OldTmCharityBoxes,
                        x => x.TmLocationSub,
                        x => x.TmLocationSub.TmLocation,
                        x => x.TmLocationSub.TmLocation.Region,
                        x => x.TmLocationSub.TmLocation.Region.FndLookupValues)
              .Where(z =>
                    z.ActionLkpId !=  /* Missed Box */ 622 && z.StatusLkpId == /* Posted */ 625 && z.OldCharityBoxid != null
                    && (string.IsNullOrEmpty(searchTerm) || (z.OldTmCharityBoxes.CharityBoxName.Contains(searchTerm))));

            var result = data
                .OrderBy(q => q.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(z => new Select2OptionModel
                {
                    //  __ for seperation purpose (JS usage)

                    id = z.Id,
                    text = z.OldTmCharityBoxes.CharityBoxBarcode,
                    altText = $"{z.OldTmCharityBoxes.CharityBoxName}__" +
                    $"{z.TmLocationSub.TmLocation.Region.FndLookupValues.NameAr}-" +
                    $"{z.TmLocationSub.TmLocation.Region.RegionName}-" +
                    $"{z.TmLocationSub.TmLocation.LocationName}-" +
                    $"{z.TmLocationSub.TmLocationSubName}"
                })
                .ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetCharityBoxActionDetailsForDamagedSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoTmCharityBoxActionDetails
                            .GetAllIncluding(  x => x.OldTmCharityBoxes)
                          .Where(z => 
                            ((z.ActionLkpId ==  /* Missed Box */ 622 && z.StatusLkpId ==  /* NEW */ 625) ||
                            (z.ActionLkpId ==  /* Broken Box */ 621 && z.StatusLkpId == /* POSTED */ 626))
                             && z.OldCharityBoxid != null &&
                               (string.IsNullOrEmpty(searchTerm) || (z.OldTmCharityBoxes.CharityBoxName.Contains(searchTerm))));

            var result = data
                .OrderBy(q => q.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(z => new Select2OptionModel
                {
                    id = z.Id,
                    text = z.OldTmCharityBoxes.CharityBoxBarcode,
                    altText = $"{z.OldTmCharityBoxes.CharityBoxName}"
                })
                .ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
