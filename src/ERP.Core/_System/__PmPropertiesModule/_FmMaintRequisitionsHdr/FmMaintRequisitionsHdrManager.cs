using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr
{
    public class FmMaintRequisitionsHdrManager : IFmMaintRequisitionsHdrManager
    {
        private readonly IRepository<FmMaintRequisitionsHdr, long> _repoFmMaintRequisitionsHdr;

        public FmMaintRequisitionsHdrManager(IRepository<FmMaintRequisitionsHdr, long> repoFmMaintRequisitionsHdr)
        {
            _repoFmMaintRequisitionsHdr = repoFmMaintRequisitionsHdr;
        }

        public async Task<Select2PagedResult> GetFmMaintRequisitionsNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            long newStatusLkpId = 11048;

            var data = _repoFmMaintRequisitionsHdr.GetAll().Where(z => z.RequisitionStatusLkpId == newStatusLkpId &&
                      (string.IsNullOrEmpty(searchTerm) || z.CallerName.Contains(searchTerm) || z.RequisitionNumber.Contains(searchTerm)));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.RequisitionNumber }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
