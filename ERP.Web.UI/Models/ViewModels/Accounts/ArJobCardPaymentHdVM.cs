using ERP._System.__AccountModule._ArJobCardHd.Dto;
using ERP._System.__AccountModule._ArJobCardPaymentTr.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using ERP.Web.UI.Models.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArJobCardPaymentHdVM : BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
       

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.TransactionDate), ResourceType = typeof(ArJobCardPaymentHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string TransactionDate { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.TransactionNumber), ResourceType = typeof(ArJobCardPaymentHd))]       
        public string TransactionNumber { get; set; }

        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.Status), ResourceType = typeof(ArJobCardPaymentHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? StatusLkpId { get; set; }
        public long? ArJobCardHdId { get; set; }

        #region  Details Properties

            [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.JobNumber), ResourceType = typeof(ArJobCardPaymentHd))]
            [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
            public long? JobNumberLkpId { get; set; }


            [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.InvoiceNumberLkpId), ResourceType = typeof(ArJobCardPaymentHd))]
            public long? InvoiceNumberLkpId { get; set; }


            [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.CustomerName), ResourceType = typeof(ArJobCardPaymentHd))]
            public long? ArCustomerLkpId { get; set; }
            public ArCustomersVM ArCustomers { get; set; }
            public ArJobCardHdVM ArJobCardHd { get; set; }

            [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.CustomerName), ResourceType = typeof(ArJobCardPaymentHd))]
            public string CustomerNameEn { get; set; }
            [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.CustomerName), ResourceType = typeof(ArJobCardPaymentHd))]
            public string CustomerNameAr { get; set; }

            [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.OriginalAmount), ResourceType = typeof(ArJobCardPaymentHd))]
            public decimal? OriginalAmount { get; set; }

            [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobCardPaymentHd.SourceLkpId), ResourceType = typeof(ArJobCardPaymentHd))]
            public long? SourceLkpId { get; set; }
            public string PaymentDate { get; set; }
            public string Notes { get; set; }
            public decimal? Amount { get; set; }
            public FndLookupValuesVM FndJobCardPaymenStatusLkp { get; set; }
            public string ListArJobCardPaymentTr { get; set; }
            public long? ArJobCardPaymentHdId { get; set; }

            public List<ArJobCardPaymentTrDto> ArJobCardPaymentTrList => string.IsNullOrEmpty(ListArJobCardPaymentTr) ? new List<ArJobCardPaymentTrDto>() :
               Helper<List<ArJobCardPaymentTrDto>>.Convert(ListArJobCardPaymentTr);


        #endregion


    }
}