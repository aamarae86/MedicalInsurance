using Abp.Domain.Repositories;
using ERP._System._FndLookupValues;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ERP._System._ArSecurityDepositInterface
{
    public class ArSecurityDepositInterfaceManager : IArSecurityDepositInterfaceManager
    {
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;

        public ArSecurityDepositInterfaceManager(IRepository<FndLookupValues, long> repoFndLookupValues)
        {
            _repoFndLookupValues = repoFndLookupValues;
        }

        public async System.Threading.Tasks.Task<(string text, long id)> GetNewArSecurityDepositInterfaceStatusSelect2Option(long lkpId)
        {
            var data = await _repoFndLookupValues.GetAll().Where(z => z.Id == lkpId).FirstOrDefaultAsync();

            return (data.NameAr, data.Id);
        }
    }
}
