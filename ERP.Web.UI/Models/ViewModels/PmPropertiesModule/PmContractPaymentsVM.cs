using ERP.ResourcePack.PmPropertiesModule;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmContractPaymentsVM : Abp.Domain.Entities.Entity<long>
    {
        [MaxLength(30)]
        [Display(Name = nameof(PmContract.CheckNumber), ResourceType = typeof(PmContract))]
        public string CheckNumber { get;  set; }

        [Display(Name = nameof(PmContract.PaymentNo), ResourceType = typeof(PmContract))]
        public int? PaymentNo { get;  set; }

        [Display(Name = nameof(PmContract.PayAmount), ResourceType = typeof(PmContract))]
        public decimal PayAmount { get;  set; }

        [Display(Name = nameof(PmContract.PaymentDate), ResourceType = typeof(PmContract))]
        public string PaymentDate { get;  set; }

        [Display(Name = nameof(PmContract.MaturityDate), ResourceType = typeof(PmContract))]
        public string MaturityDate { get;  set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PmContract.Comments), ResourceType = typeof(PmContract))]
        public string Comments { get;  set; }

        [Display(Name = nameof(PmContract.PaymentTypeLkpId), ResourceType = typeof(PmContract))]
        public long PaymentTypeLkpId { get;  set; }

        public string PaymentTypeLkp { get;  set; }

        [Display(Name = nameof(PmContract.PaymentSourceLkpId), ResourceType = typeof(PmContract))]
        public long PaymentSourceLkpId { get;  set; }

        public string PaymentSourceLkp { get;  set; }

        [Display(Name = nameof(PmContract.BankLkpId), ResourceType = typeof(PmContract))]
        public long? BankLkpId { get;  set; }

        public string BankLkp { get;  set; }


        [Display(Name = nameof(PmContract.OtherPaymentTypesId), ResourceType = typeof(PmContract))]
        public long OtherPaymentTypesId { get; set; }

        [Display(Name = nameof(PmContract.Notes), ResourceType = typeof(PmContract))]
        public string Notes { get; set; }
        
    }
}