using Abp.Domain.Repositories;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders
{

    public class GlJeIntegrationHeadersManager : IGlJeIntegrationHeadersManager
    {
        private readonly IRepository<GlJeIntegrationLines, long> _glJeIntegrationLinesRepository;
        private readonly IRepository<ArInvoiceSettlementCr, long> _repoArInvoiceSettlementCr;
        private readonly IRepository<ArInvoiceSettlementDr, long> _repoArInvoiceSettlementDr;

        public GlJeIntegrationHeadersManager
            (
            IRepository<GlJeIntegrationLines, long> glJeIntegrationLinesRepository
            , IRepository<ArInvoiceSettlementCr, long> repoArInvoiceSettlementCr
            , IRepository<ArInvoiceSettlementDr, long> repoArInvoiceSettlementDr
            )
        {
            _glJeIntegrationLinesRepository = glJeIntegrationLinesRepository;
            _repoArInvoiceSettlementCr = repoArInvoiceSettlementCr;
            _repoArInvoiceSettlementDr = repoArInvoiceSettlementDr;
        }

        public async Task<Select2PagedResult> GetGlJeIntegration_Headers_Line_Cr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
        {
            var data = await _glJeIntegrationLinesRepository.GetAll().Include(x=>x.GlJeIntegrationHeaders)
                                                .Where(z => z.IsSettled == false && z.GlJeIntegrationHeaders.StatusLkpId == 10977 
                                                             && z.ArCustomerId == ArCustomerId && z.CreditAmount > 0 
                                                             && !_repoArInvoiceSettlementCr.GetAll().Select(q=> q.SourceId).Contains(z.Id))
                                    .Select(x => new { Id = x.Id, GlJeIntegrationNumber= x.GlJeIntegrationHeaders.GlJeIntegrationNumber, Date= x.GlJeIntegrationHeaders.GlJeIntegrationDate.Date.ToString(), Amount= x.CreditAmount }).ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.GlJeIntegrationNumber, altText = JsonConvert.SerializeObject(z) }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetGlJeIntegration_Headers_Line_Dr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
        {
            var data = await _glJeIntegrationLinesRepository.GetAll().Include(x => x.GlJeIntegrationHeaders)
                                                .Where(z => z.IsSettled == false && z.GlJeIntegrationHeaders.StatusLkpId == 10977
                                                             && z.ArCustomerId == ArCustomerId && z.DebitAmount > 0 
                                                             && !_repoArInvoiceSettlementDr.GetAll().Select(q=>q.Id).Contains(z.Id))
                                    .Select(x => new { Id= x.Id, GlJeIntegrationNumber= x.GlJeIntegrationHeaders.GlJeIntegrationNumber, Date= x.GlJeIntegrationHeaders.GlJeIntegrationDate.Date.ToString(), Amount= x.DebitAmount }).ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.GlJeIntegrationNumber, altText = JsonConvert.SerializeObject(z) }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
