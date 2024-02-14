using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ApBankAccounts;
using ERP.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._ApUserBankAccess
{
    public class ApUserBankAccess : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public long? BankAccountId { get; protected set; }
        [Column(TypeName = "bit")]
        public bool IsPrimaryCash { get; protected set; }
        public long UserId { get; protected set; }
        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; protected set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; protected set; }
        public bool IsActive { get; set; }
        public int TenantId { get; set; }

        protected ApUserBankAccess()
        { }

        protected ApUserBankAccess(long? BankAccountId, bool IsPrimaryCash, long UserId, bool isActive = true)
        {
            this.BankAccountId = BankAccountId;
            this.IsPrimaryCash = IsPrimaryCash;
            this.UserId = UserId;
            this.IsActive = isActive;
        }

        public static ApUserBankAccess
        Create(long? BankAccountId, bool IsPrimaryCash, long UserId)
            =>
        new ApUserBankAccess(BankAccountId, IsPrimaryCash, UserId);
    }
}
