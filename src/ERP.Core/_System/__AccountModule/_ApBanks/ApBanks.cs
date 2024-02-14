using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System._ApBankAccounts;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._ApBanks
{
    public class ApBanks : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [Column(TypeName = "nvarchar(200)")]
        [Required]
        [MaxLength(200)]
        public string BankNameAr { get; protected set; }
        [Column(TypeName = "nvarchar(200)")]
        [Required]
        [MaxLength(200)]
        public string BankNameEn { get; protected set; }
        public long BankTypeLkpId { get; protected set; }
        [ForeignKey(nameof(BankTypeLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }
        public virtual ICollection<ApBankAccounts> ApBankAccounts { get; protected set; }
        public bool IsActive { get; set; }
        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        protected ApBanks(string bankNameAr, string bankNameEn, long bankTypeLkpId, bool isActive)
        {
            this.BankNameAr = bankNameAr;
            this.BankNameEn = bankNameEn;
            this.BankTypeLkpId = bankTypeLkpId;
            this.IsActive = isActive;
        }

        public static ApBanks Create(string bankNameAr, string bankNameEn, long bankTypeLkpId, bool isActive)
            =>  new ApBanks(bankNameAr, bankNameEn, bankTypeLkpId, isActive);
    }
}
