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

namespace ERP._System.__AccountModule._ArReceipts
{
    public class ArReceiptsManager : IArReceiptsManager
    {
        private readonly IRepository<ArReceiptsOnAccount, long> _arReceiptsOnAccountRepository;

        private readonly IRepository<ArInvoiceSettlementCr, long> _repoArInvoiceSettlementCr;

        public ArReceiptsManager
            (
            IRepository<ArReceiptsOnAccount, long> arReceiptsOnAccountRepository
            , IRepository<ArInvoiceSettlementCr, long> repoArInvoiceSettlementCr
            )
        {
            _arReceiptsOnAccountRepository = arReceiptsOnAccountRepository;
            _repoArInvoiceSettlementCr = repoArInvoiceSettlementCr;
        }

        public async Task<Select2PagedResult> GetArReceipts_ReceiptsOnAccount_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
        {
            var data = await _arReceiptsOnAccountRepository.GetAll().Include(x => x.ArReceipts)
                                                .Where(z => z.ArReceipts.StatusLkpId == 279 && z.ArReceipts.ArCustomerId == ArCustomerId 
                                                && !_repoArInvoiceSettlementCr.GetAll().Select(q=>q.SourceId).Contains(z.ArReceipts.Id))
                                                .GroupBy(x => new { x.ArReceipts.ReceiptNumber, x.ArReceipts.ReceiptDate ,x.ArReceipts.Id })
                                    .Select(x => new { Id = x.Key.Id, ReceiptNumber = x.Key.ReceiptNumber, Date = x.Key.ReceiptDate.Date.ToString() , Amount = x.Sum(s => s.Amount) }) //, 
                                    .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.ReceiptNumber, altText = JsonConvert.SerializeObject(z) }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
