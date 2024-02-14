#region usings
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ApInvoiceHd;
using ERP._System.__AccountModule._FaAssetCategory;
using ERP._System.__AccountModule._FaAssetDeprn;
using ERP._System.__AccountModuleExtend._ApPrepaid;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System.__PmPropertiesModule._PmCancellationContracts;
using ERP._System.__PmPropertiesModule._PmOtherPaymentTypes;
using ERP._System.__Warehouses._PyElements;
using ERP._System._ApBankAccounts;
using ERP._System._ApMiscPaymentLines;
using ERP._System._ArDrCrTr;
using ERP._System._ArMiscReceiptLines;
using ERP._System._ArSecurityDepositInterface;
using ERP._System._GlAccDetails;
using ERP._System._GlAccounts;
using ERP._System._GlJeLines;
using ERP._System._GlMainAccounts;
using ERP._System._GlPeriods;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
#endregion

namespace ERP._System._GlCodeComDetails
{
    public class GlCodeComDetails : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        public long? Attribute1 { get; protected set; }
        public long? Attribute2 { get; protected set; }
        public long? Attribute3 { get; protected set; }
        public long? Attribute4 { get; protected set; }
        public long? Attribute5 { get; protected set; }
        public long? Attribute6 { get; protected set; }
        public long? Attribute7 { get; protected set; }
        public long? Attribute8 { get; protected set; }
        public long? Attribute9 { get; protected set; }

        public long? AccId { get; set; }

        [ForeignKey(nameof(Attribute1)), Column(Order = 0)]
        public GlAccDetails GlAccDetailsAttr1 { get; protected set; }

        [ForeignKey(nameof(Attribute2)), Column(Order = 1)]
        public GlAccDetails GlAccDetailsAttr2 { get; protected set; }

        [ForeignKey(nameof(Attribute3)), Column(Order = 2)]
        public GlAccDetails GlAccDetailsAttr3 { get; protected set; }

        [ForeignKey(nameof(Attribute4)), Column(Order = 3)]
        public GlAccDetails GlAccDetailsAttr4 { get; protected set; }

        [ForeignKey(nameof(Attribute5)), Column(Order = 4)]
        public GlAccDetails GlAccDetailsAttr5 { get; protected set; }

        [ForeignKey(nameof(Attribute6)), Column(Order = 5)]
        public GlAccDetails GlAccDetailsAttr6 { get; protected set; }

        [ForeignKey(nameof(Attribute7)), Column(Order = 6)]
        public GlAccDetails GlAccDetailsAttr7 { get; protected set; }

        [ForeignKey(nameof(Attribute8)), Column(Order = 7)]
        public GlAccDetails GlAccDetailsAttr8 { get; protected set; }

        [ForeignKey(nameof(Attribute9)), Column(Order = 8)]
        public GlAccDetails GlAccDetailsAttr9 { get; protected set; }

        [ForeignKey(nameof(AccId))]
        public GlAccounts GlAccounts { get; protected set; }

        public virtual ICollection<GlJeIntegrationLines> GlJeIntegrationLines { get; protected set; }

        public virtual ICollection<FaAssetDeprnTrDtl> FaAssetDeprnTrDtl { get; protected set; }

        public virtual ICollection<ArSecurityDepositInterface> ArSecurityDepositInterface { get; protected set; }

        public virtual ICollection<GlJeLines> GlJeLines { get; protected set; }

        [InverseProperty(nameof(ApBankAccounts.GlCodeComDetails))]
        public virtual ICollection<ApBankAccounts> ApBankAccountsDtl { get; protected set; }

        [InverseProperty(nameof(ApBankAccounts.GlCodeComDetailscPdcAccount))]
        public virtual ICollection<ApBankAccounts> ApBankAccountscPdcAccount { get; protected set; }

        [InverseProperty(nameof(ApBankAccounts.GlCodeComDetailsPdcCollAccount))]
        public virtual ICollection<ApBankAccounts> ApBankAccountsPdcCollAccount { get; protected set; }

        [InverseProperty(nameof(PyElements.CrGlCodeComDetailsDebitAccount))]
        public virtual ICollection<PyElements> PyElementsDebitAccount { get; protected set; }

        [InverseProperty(nameof(FaAssetCategory.GlCodeComDetailsAccDeprenAccount))]
        public virtual ICollection<FaAssetCategory> GlCodeComDetailsAccDeprenAccount { get; protected set; }

        [InverseProperty(nameof(FaAssetCategory.GlCodeComDetailsAssetClearingAccount))]
        public virtual ICollection<FaAssetCategory> GlCodeComDetailsAssetClearingAccount { get; protected set; }

        [InverseProperty(nameof(FaAssetCategory.GlCodeComDetailsAssetCostAccount))]
        public virtual ICollection<FaAssetCategory> GlCodeComDetailsAssetCostAccount { get; protected set; }

        [InverseProperty(nameof(FaAssetCategory.GlCodeComDetailsDeprenAccount))]
        public virtual ICollection<FaAssetCategory> GlCodeComDetailsDeprenAccount { get; protected set; }

        [InverseProperty(nameof(ApBankAccounts.GlCodeComDetailsApPdcCollAccount))]
        public virtual ICollection<ApBankAccounts> ApBankAccountsApPdcCollAccount { get; protected set; }

        public virtual ICollection<GlMainAccounts> GlMainAccounts { get; protected set; }

        [InverseProperty(nameof(ArMiscReceiptLines.GlCodeComDetails))]
        public virtual ICollection<ArMiscReceiptLines> AccountArMiscReceiptLines { get; protected set; }

        [InverseProperty(nameof(ArMiscReceiptLines.AdminGlCodeComDetails))]
        public virtual ICollection<ArMiscReceiptLines> AdminAccountArMiscReceiptLines { get; protected set; }

        [InverseProperty(nameof(ApMiscPaymentLines.GlCodeComDetails))]
        public virtual ICollection<ApMiscPaymentLines> ApMiscPaymentLinesAccount { get; protected set; }

        [InverseProperty(nameof(ApMiscPaymentLines.GlCodeComDetailsTaxAccount))]
        public virtual ICollection<ApMiscPaymentLines> ApMiscPaymentLinesTaxAccount { get; protected set; }

        public virtual ICollection<GlPeriodsYears> GlPeriodsYears { get; protected set; }

        public virtual ICollection<ArDrCrTr> ArDrCrTr { get; protected set; }

        public virtual ICollection<PmOtherPaymentTypes> PmOtherPaymentTypes { get; protected set; }

        public virtual ICollection<ArInvoiceTr> ArInvoiceTr { get; protected set; }

        public virtual ICollection<PmCancellationContracts> PmCancellationContracts { get; protected set; }

        public virtual ICollection<ScPortalRequestStudy> ScPortalRequestStudy { get; protected set; }

        [InverseProperty(nameof(ApInvoiceHd.FromGlCodeComDetails))]
        public virtual ICollection<ApInvoiceHd> FromGlCodeComDetails { get; protected set; }

        [InverseProperty(nameof(ApInvoiceHd.ToGlCodeComDetails))]
        public virtual ICollection<ApInvoiceHd> ToGlCodeComDetails { get; protected set; }

        [InverseProperty(nameof(ApPrepaid.CrGlCodeComDetails))]
        public virtual ICollection<ApPrepaid> CrGlCodeComDetails { get; protected set; }

        [InverseProperty(nameof(ApPrepaid.DrGlCodeComDetails))]
        public virtual ICollection<ApPrepaid> DrGlCodeComDetails { get; protected set; }

        public int TenantId { get; set; }

        public long? TenxMigrationId { get; set; }

        #endregion

        protected GlCodeComDetails(long? attribute1, long? attribute2, long? attribute3, long? attribute4, long? attribute5,
            long? attribute6, long? attribute7, long? attribute8, long? attribute9,
            long? accId)
        {
            this.Attribute1 = attribute1;
            this.Attribute2 = attribute2;
            this.Attribute3 = attribute3;
            this.Attribute4 = attribute4;
            this.Attribute5 = attribute5;
            this.Attribute6 = attribute6;
            this.Attribute7 = attribute7;
            this.Attribute8 = attribute8;
            this.Attribute9 = attribute9;
            this.AccId = accId;
        }

        public static GlCodeComDetails Create(long? attribute1, long? attribute2, long? attribute3,
            long? attribute4, long? attribute5, long? attribute6, long? attribute7, long? attribute8, long? attribute9, long? accId)
        {
            return new GlCodeComDetails(attribute1,
             attribute2, attribute3, attribute4, attribute5, attribute6, attribute7, attribute8, attribute9, accId);
        }

        public (string, string, string) GetAttrNamesCodesNames()
        {
            string namesAr = string.Empty, namesEn = string.Empty, codes = string.Empty;

            if (this.GlAccDetailsAttr1 != null)
            {
                var attr = this.GlAccDetailsAttr1;

                namesAr += $"{attr.NameAr}";
                namesEn += $"{attr.NameEn}";
                codes += $"{attr.Code}";
            }

            if (this.GlAccDetailsAttr2 != null)
            {
                var attr = this.GlAccDetailsAttr2;

                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (this.GlAccDetailsAttr3 != null)
            {
                var attr = this.GlAccDetailsAttr3;

                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (this.GlAccDetailsAttr4 != null)
            {
                var attr = this.GlAccDetailsAttr4;

                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (this.GlAccDetailsAttr5 != null)
            {
                var attr = this.GlAccDetailsAttr5;

                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (this.GlAccDetailsAttr6 != null)
            {
                var attr = this.GlAccDetailsAttr6;

                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (this.GlAccDetailsAttr7 != null)
            {
                var attr = this.GlAccDetailsAttr7;

                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (this.GlAccDetailsAttr8 != null)
            {
                var attr = this.GlAccDetailsAttr8;

                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (this.GlAccDetailsAttr9 != null)
            {
                var attr = this.GlAccDetailsAttr9;

                namesAr += $".{attr.NameAr}";
                namesEn += $".{attr.NameEn}";
                codes += $".{attr.Code}";
            }

            if (this.GlAccounts != null)
            {
                var acc = this.GlAccounts;

                namesAr += $".{acc.DescriptionAr}";
                namesEn += $".{acc.DescriptionEn}";
                codes += $".{acc.Code}";
            }

            return (namesAr, namesEn, codes);
        }

        public (string ids, string texts) GetCodeComTextsIds(string lang = "ar-EG")
        {
            string ids = string.Empty, texts = string.Empty;

            const char symbol = ',';

            if (this.GlAccDetailsAttr1 != null)
            {
                var attrCom = this.GlAccDetailsAttr1;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccDetailsAttr2 != null)
            {
                var attrCom = this.GlAccDetailsAttr2;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccDetailsAttr3 != null)
            {
                var attrCom = this.GlAccDetailsAttr3;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccDetailsAttr4 != null)
            {
                var attrCom = this.GlAccDetailsAttr4;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccDetailsAttr5 != null)
            {
                var attrCom = this.GlAccDetailsAttr5;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccDetailsAttr6 != null)
            {
                var attrCom = this.GlAccDetailsAttr6;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccDetailsAttr7 != null)
            {
                var attrCom = this.GlAccDetailsAttr7;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccDetailsAttr8 != null)
            {
                var attrCom = this.GlAccDetailsAttr8;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccDetailsAttr9 != null)
            {
                var attrCom = this.GlAccDetailsAttr9;

                ids += $"{attrCom.Id}{symbol}";
                texts += (lang == "ar-EG" ? $"{attrCom.NameAr}{symbol}" : $"{attrCom.NameEn}{symbol}");
            }

            if (this.GlAccounts != null)
            {
                var currentAccount = this.GlAccounts;

                ids += $"{currentAccount.Id}";
                texts += (lang == "ar-EG" ? $"{currentAccount.DescriptionAr}" : $"{currentAccount.DescriptionEn}");
            }

            return (ids, texts);
        }

    }
}
