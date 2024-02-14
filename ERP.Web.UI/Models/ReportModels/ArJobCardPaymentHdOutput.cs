using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class ArJobCardPaymentHdOutput
    {
        public string TransactionDate { get; set; }
        public string TransactionNumber { get; set; }

        public FndLookupValuesVM FndJobCardPaymenStatusLkp { get; set; }

    }
}