using Abp.Domain.Services;
using ERP.Core.Helpers.Parameters;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Currencies;

namespace ERP.Currencies
{
    public interface ICurrencyManager : IDomainService
    {
        Task<decimal> GetRate(int id, DateTime? date);

        Task<Select2PagedResult> GetCurrenciesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
