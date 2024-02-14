using Abp.Domain.Repositories;
using ERP._System._AffliateAccount.Dto;
using System.Threading.Tasks;

namespace ERP._System._AffliateAccount
{
    public class AffliateAccountAppService : ERPAppServiceBase, IAffliateAccountAppService
    {
        private readonly IRepository<AffliateAccount, long> _repoAffliateAccount;

        public AffliateAccountAppService(IRepository<AffliateAccount, long> repoAffliateAccount)
        {
            _repoAffliateAccount = repoAffliateAccount;
        }

        public async Task<AffliateAccountDto> Create(AffliateAccountDto affliateAccountDto)
        {
            var mapped = ObjectMapper.Map<AffliateAccount>(affliateAccountDto);
         
            await _repoAffliateAccount.InsertAsync(mapped);

            return ObjectMapper.Map<AffliateAccountDto>(mapped);
        }
    }
}
