using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ArSecurityDepositInterface
{
    public interface IArSecurityDepositInterfaceManager : IDomainService
    {
        Task<(string text, long id)> GetNewArSecurityDepositInterfaceStatusSelect2Option(long lkpId);
    }
}
