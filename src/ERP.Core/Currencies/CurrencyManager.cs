using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using ERP.Core.Helpers.Extensions;
using ERP.Core.Helpers.Parameters;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Currencies
{
    public class CurrencyManager : ICurrencyManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IRepository<Currency, int> _currencyRepository;

        public CurrencyManager
            (
            IRepository<Currency, int> currencyRepository
            )
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<decimal> GetRate(int id, DateTime? date)
        {
            var currency = await _currencyRepository.GetAsync(id);
            return currency.Rate;
        }

        public async Task<Select2PagedResult> GetCurrenciesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _currencyRepository.GetAll()
                         .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.DescriptionAr.Contains(searchTerm) : z.DescriptionEn.Contains(searchTerm)))
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.DescriptionAr : z.DescriptionEn, additional=z.IsLocalCurrency.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
