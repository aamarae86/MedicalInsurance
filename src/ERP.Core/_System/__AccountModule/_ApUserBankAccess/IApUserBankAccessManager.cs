using Abp.Domain.Services;
using ERP._System._ApBankAccounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApUserBankAccess
{
    public interface IApUserBankAccessManager : IDomainService
    {
        Task<List<ApBankAccounts>> GetUserAccessBankAccounts(long userId,long ?bankLkpId);
    }
}
