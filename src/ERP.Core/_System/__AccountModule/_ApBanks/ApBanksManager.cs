using Abp.Domain.Repositories;
using ERP._System._ApBankAccounts;
using ERP._System._ApUserBankAccess;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApBanks
{
    public class ApBanksManager: IApBanksManager
    {
        private readonly IRepository<ApBanks, long> _repoApBanks;
        private readonly IRepository<ApUserBankAccess, long> _userBank;
        private readonly IRepository<FndLookupValues, long> _repoLookup;
        private readonly IRepository<ApBankAccounts, long> _repoApBanksAccount;
        private readonly IRepository<ApUserBankAccess, long> _userBankAccess;
        public ApBanksManager(IRepository<ApBanks, long> repoApBanks,
            IRepository<FndLookupValues, long> repoLookup,
            IRepository<ApBankAccounts, long> repoApBanksAccount,
            IRepository<ApUserBankAccess, long> userBankAccess,
            IRepository<ApUserBankAccess, long> userBank)
        {
            _repoApBanks = repoApBanks;
            _repoLookup= repoLookup;
            _repoApBanksAccount= repoApBanksAccount;
            _userBankAccess = userBankAccess;
        }
        public async Task<Select2PagedResult> ApBanksSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            
            var data = await _repoApBanks.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.BankNameAr.Contains(searchTerm) : z.BankNameEn.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.BankNameAr : z.BankNameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPaymentMethod(string searchTerm, int pageSize, int pageNumber, string lang,long? userId,long?tenantId,long? BankAccountId)
        {
            //var getUserBankAccess = _userBankAccess.GetAllList(x => x.UserId == userId)
            //    .Select(x => x.ApBankAccounts)
            //    .Select(x=>x.ApBanks.BankTypeLkpId);

            var getUserBankAccess = _userBankAccess.GetAllIncluding(x => x.ApBankAccounts,a=>a.ApBankAccounts.ApBanks)
                .Where(x=>x.UserId==userId&&x.TenantId==tenantId &&x.BankAccountId== BankAccountId);
            var lv2 = getUserBankAccess.Select(x => x.ApBankAccounts);
            var lv3 = lv2.Select(x => x.ApBanks.BankTypeLkpId);




            var data=  _repoLookup.GetAllList(x=> lv3.Contains(x.Id));

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.NameAr : z.NameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }




    }
}
