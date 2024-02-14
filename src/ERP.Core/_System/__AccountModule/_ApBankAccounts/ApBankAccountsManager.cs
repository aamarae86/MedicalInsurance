using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using ERP._System._ApUserBankAccess;
using ERP.Authorization.Users;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System._ApBankAccounts
{
    public class ApBankAccountsManager : IApBankAccountsManager
    {
        private readonly IRepository<ApBankAccounts, long> _repoApBankAccounts;
        private readonly IApUserBankAccessManager _apUserBankAccessManager;


        private readonly IRepository<ApUserBankAccess, long> _repoApUserBankAccounts;

        public IAbpSession AbpSession { get; set; }

        public ApBankAccountsManager(
            IRepository<ApBankAccounts, long> repoApBankAccounts,
            IRepository<ApUserBankAccess, long> repoApUserBankAccounts,
            IApUserBankAccessManager apUserBankAccessManager)
        {
            _repoApBankAccounts = repoApBankAccounts;
            _apUserBankAccessManager = apUserBankAccessManager;
            _repoApUserBankAccounts=repoApUserBankAccounts;
            AbpSession = NullAbpSession.Instance;
        }

        public async Task<Select2PagedResult> ApBankAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoApBankAccounts.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.BankAccountNameAr.Contains(searchTerm) : z.BankAccountNameEn.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.BankAccountNameAr : z.BankAccountNameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<Select2PagedResult> GetApBankAccountsByBankIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang,long BankId)
        {

            var data = await _repoApBankAccounts.GetAll()
                .Where(z => !string.IsNullOrEmpty(searchTerm) ? (z.BankAccountNameAr.Contains(searchTerm) && z.BankId == BankId) || (z.BankAccountNameEn.Contains(searchTerm) && z.BankId == BankId) : z.BankId == BankId)
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.BankAccountNameAr : z.BankAccountNameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }


        //public async Task<Select2PagedResult> GetApBanksByUserIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        //{
        //    var availableUserBank = _repoApUserBankAccounts.GetAll().Where(x => x.UserId == AbpSession.UserId).Select(x => x.BankAccountId);

        //    //var availabelBanks= _repoApBankAccounts.GetAll().Select()
        //    var data = await _repoApBankAccounts.GetAll()
        //        .Where(z => !string.IsNullOrEmpty(searchTerm) ? (z.BankAccountNameAr.Contains(searchTerm) && z.BankId == BankId) || (z.BankAccountNameEn.Contains(searchTerm) && z.BankId == BankId) : z.BankId == BankId)
        //        .ToListAsync();

        //    var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.BankAccountNameAr : z.BankAccountNameEn }).ToList();

        //    var select2pagedResult = new Select2PagedResult
        //    {
        //        Total = data.Count(),
        //        Results = result
        //    };

        //    return select2pagedResult;
        //}


        public async Task<bool> Create(ApBankAccounts apBankAccounts)
        {
            await _repoApBankAccounts.InsertAsync(apBankAccounts);

            return true;
        }
 
        public async Task<List<ApBankAccounts>> GetAllApBankAccountsByBankId(long bankId)
            =>
             await _repoApBankAccounts.GetAllIncluding(
                 bb=>bb.Currency,
                 z => z.GlCodeComDetails,
                 x=>x.GlCodeComDetailsApPdcCollAccount,
                 v=>v.GlCodeComDetailscPdcAccount,
                 b=>b.GlCodeComDetailsPdcCollAccount)
            .Where(z => z.BankId == bankId).ToListAsync();

      

        public async Task<Select2PagedResult> GetUserAccessedApBankAccountsSelect2(long? bankLkpId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var currentUserId = AbpSession.UserId;

            var bnkAccounts = await _apUserBankAccessManager.GetUserAccessBankAccounts((long)currentUserId, bankLkpId);

            var data = bnkAccounts
               .Where(z =>
                string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.BankAccountNameAr.Contains(searchTerm) : z.BankAccountNameEn.Contains(searchTerm)))
               .ToList();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.BankAccountNameAr : z.BankAccountNameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
