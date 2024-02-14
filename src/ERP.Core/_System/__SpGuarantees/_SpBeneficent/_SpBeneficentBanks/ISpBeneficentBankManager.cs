using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpBeneficent._SpBeneficentBanks
{
    public interface ISpBeneficentBankManager : IDomainService
    {
        Task<Select2PagedResult> GetSpBeneficentBanksSelect2(long spBeneficentId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
