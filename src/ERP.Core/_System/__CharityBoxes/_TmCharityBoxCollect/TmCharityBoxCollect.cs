using Abp.Domain.Entities;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectDetails;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectMembersDetail;
using ERP._System._ApBankAccounts;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect
{
    public class TmCharityBoxCollect : PostAuditedEntity<long>, IMustHaveTenant
    {
        public DateTime CollectDate { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string CollectNumber { get; protected set; }

        public string Notes { get; protected set; }

        #region Coins Category
        public long? Value25F { get; protected set; }

        public long? Value50F { get; protected set; }

        public long? Value1Dh { get; protected set; }

        public long? Value5Dh { get; protected set; }

        public long? Value10Dh { get; protected set; }

        public long? Value20Dh { get; protected set; }

        public long? Value50Dh { get; protected set; }

        public long? Value100Dh { get; protected set; }

        public long? Value200Dh { get; protected set; }

        public long? Value500Dh { get; protected set; }

        public long? Value1000Dh { get; protected set; }
        #endregion

        public long StatusLkpId { get; protected set; }

        public long BankAccountId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLookup { get; protected set; }

        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; protected set; }

        public virtual ICollection<TmCharityBoxCollectMembersDetail> TmCharityBoxCollectMembersDetails { get; protected set; }

        public virtual ICollection<TmCharityBoxCollectDetails> TmCharityBoxCollectDetails { get; protected set; }

        public int TenantId { get; set; }
    }
}
