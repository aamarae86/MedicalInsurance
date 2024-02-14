using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._FndLookupValues;
using ERP._System._FndTaxType;
using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ApMiscPaymentLines
{
    public class ApMiscPaymentLines : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [MaxLength(30)]
        public string InvoiceNumber { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? MiscPaymentAmount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [MaxLength(100)]
        public string TaxNo { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? TaxPercent { get; protected set; }

        public long? TaxPercentageLkpId { get; protected set; }
        public long?  FndTaxTypeLkpId{ get; protected set; }

        public long? TaxAccountId { get; protected set; }

        public long? AccountId { get; protected set; }

        public long? MiscPaymentId { get; protected set; }

        public string PoratlCaseNumber { get; protected set; }

        public long? PortalUsersId { get; protected set; }

        [ForeignKey(nameof(TaxPercentageLkpId))]
        public FndLookupValues FndTaxPercentageLkp { get; protected set; }

        [ForeignKey(nameof(FndTaxTypeLkpId))]
        public FndTaxType FndTaxTypeLkp { get; protected set; }

        [ForeignKey(nameof(PortalUsersId))]
        public Authorization.Users.PortalUser PortalUser { get; protected set; }

        [ForeignKey(nameof(AccountId)), Column(Order = 0)]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(TaxAccountId)), Column(Order = 1)]
        public GlCodeComDetails GlCodeComDetailsTaxAccount { get; protected set; }

        [ForeignKey(nameof(MiscPaymentId))]
        public ApMiscPaymentHeaders ApMiscPaymentHeaders { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }
        #endregion

        protected ApMiscPaymentLines(long? taxAccountId, long? accountId, long? miscPaymentId, long? taxPercentageLkpId,
            decimal? miscPaymentAmount, decimal? taxPercent, string taxNo, string invoiceNumber, string notes)
        {
            ;

            this.TaxAccountId = taxAccountId;
            this.AccountId = accountId;
            this.MiscPaymentAmount = miscPaymentAmount;
            this.TaxNo = taxNo;
            this.InvoiceNumber = invoiceNumber;
            this.Notes = notes;
            this.TaxPercent = taxPercent;// SetTaxPercent(taxPercentageLkpId);
            this.MiscPaymentId = miscPaymentId;
            this.FndTaxTypeLkpId = taxPercentageLkpId;
        }

        public static ApMiscPaymentLines Create(long? taxAccountId, long? accountId, long? miscPaymentId, long? taxPercentageLkpId, decimal? miscPaymentAmount, decimal? taxPercent, string taxNo, string invoiceNumber, string notes)
        {
            return new ApMiscPaymentLines(taxAccountId, accountId, miscPaymentId, taxPercentageLkpId, miscPaymentAmount, taxPercent, taxNo, invoiceNumber, notes);
        }

    //    public static decimal? SetTaxPercent(long? taxPercentageLkpId)
    //    {
    //        decimal? TaxPercent;

    //        switch (taxPercentageLkpId)
    //        {
    //            //case 10997: TaxPercent = null; break;
    //            //case 10996: TaxPercent = 5; break;
    //            //case 10995: TaxPercent = 0; break;
    //            //default: TaxPercent = null; break;                

    //            case 9: TaxPercent = 0; break;
    //            case 10: TaxPercent = 5; break;
    //            default: TaxPercent = null; break;
    //        }

    //        return TaxPercent;
    //    }       
    }
}
