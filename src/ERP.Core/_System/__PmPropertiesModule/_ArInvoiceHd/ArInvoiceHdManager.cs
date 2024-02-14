using Abp.Domain.Repositories;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._ArInvoiceHd
{
    public class ArInvoiceHdManager : IArInvoiceHdManager
    {
        private readonly IRepository<ArInvoiceTr, long> _arInvoiceTrRepository;
        private readonly IRepository<ArInvoiceSettlementDr, long> _repoArInvoiceSettlementDr;
        public ArInvoiceHdManager
            (
            IRepository<ArInvoiceTr, long> arInvoiceTrRepository
            , IRepository<ArInvoiceSettlementDr, long> repoArInvoiceSettlementDr
            )
        {
            _arInvoiceTrRepository = arInvoiceTrRepository;
            _repoArInvoiceSettlementDr = repoArInvoiceSettlementDr;
        }

        public async Task<Select2PagedResult> GetArInvoiceHd_ArInvoiceTr_NumSelect2(string searchTerm, long ArCustomerId, int pageSize, int pageNumber, string lang)
        {
            try
            {
               
                var queryable = _arInvoiceTrRepository.GetAll()
                                                       .Include(x => x.ArInvoiceHd)
                                                       .Where(z => z.ArInvoiceHd.StatusLkpId == 252 && z.ArInvoiceHd.ArCustomerId == ArCustomerId
                                                                   && (z.ArInvoiceHd.SourceLkpId == 11564 || z.ArInvoiceHd.SourceLkpId == 11565)
                                                                   && (string.IsNullOrEmpty(searchTerm) || z.ArInvoiceHd.HdInvoiceNo.Contains(searchTerm)))
                                                       .GroupBy(x => new { x.ArInvoiceHd.HdInvoiceNo, x.ArInvoiceHd.HdDate, x.ArInvoiceHd.SourceNo, x.ArInvoiceHd.Id })
                                                       .Select(x => new { Id = x.Key.Id, HdInvoiceNo = x.Key.HdInvoiceNo, Date = x.Key.HdDate.Value.Date.ToString(), Amount = x.Sum(s => s.TaxPercent != null ? (s.Amount + ((s.TaxPercent.Value / 100) * s.Amount)) : (s.Amount)), SourceNo = x.Key.SourceNo })
                                                       .AsQueryable();


                var data = await queryable.Where(z => _repoArInvoiceSettlementDr
                                                                .GetAll()
                                                                .All(v => v.SourceId != z.Id))
                                          .ToListAsync();


                var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.HdInvoiceNo, altText = JsonConvert.SerializeObject(z) }).ToList();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = data.Count(),
                    Results = result
                };

                return select2pagedResult;
            }
            catch( Exception e) {
                throw;
            }
            

           
        }
    }
}
