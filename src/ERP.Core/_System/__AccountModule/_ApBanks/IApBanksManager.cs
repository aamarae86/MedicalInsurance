using Abp.Domain.Services;
using ERP.Helpers.Core;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApBanks
{
    public interface IApBanksManager : IDomainService
    {
        Task<Select2PagedResult> ApBanksSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetPaymentMethod(string searchTerm, int pageSize, int pageNumber, string lang, long? userId, long? tenantId,long? BankAccountId);
    }
}
