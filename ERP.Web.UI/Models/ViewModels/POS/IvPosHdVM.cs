using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.POS
{
    public class IvPosHdVMOld
    { 
        public string InvoiceNumber { get; set; }

        //[Display(Name = nameof(IvItems.ItemName), ResourceType = typeof(IvItems))]
        //[Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        //[MaxLength(200)]
        public string CreateDate { get; set; }

        public string CustomerName { get; set; }
        public string CreditCardRef { get; set; }

    }
}