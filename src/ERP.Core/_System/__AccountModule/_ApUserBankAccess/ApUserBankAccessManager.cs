using Abp.Domain.Repositories;
using Abp.Events.Bus;
using ERP._System._ApBankAccounts;
using ERP._System._ApBanks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApUserBankAccess
{
    public class ApUserBankAccessManager : IApUserBankAccessManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IRepository<ApUserBankAccess, long> _repoApUserBankAccess;
        private readonly IRepository<ApBanks, long> _repoApBanks;

        public ApUserBankAccessManager(
            IRepository<ApUserBankAccess, long> repoApUserBankAccess,
            IRepository<ApBanks, long> repoApBanks)
        {
            _repoApUserBankAccess = repoApUserBankAccess;
            _repoApBanks = repoApBanks;
        }

        public async Task<List<ApBankAccounts>> GetUserAccessBankAccounts(long userId, long? bankLkpId)
        {
            var bnkAccs = await _repoApUserBankAccess
                   .GetAllIncluding(z => z.ApBankAccounts)
                   .Where(z => z.UserId == userId && z.IsActive)
                   .Select(z => z.ApBankAccounts)
                   .ToListAsync();

            var validBnkAccs = bnkAccs.Where(z => bankLkpId == null || _repoApBanks.Get(z.BankId).BankTypeLkpId == bankLkpId).ToList();

            return validBnkAccs;
        }
    }
}
