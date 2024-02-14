using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class TmCharityBoxListOutput
    {
        public string CharityBoxBarcode { get; set; }
        public string CharityBoxName { get; set; }
        public string StatusName { get; set; }
        public string Locations { get; set; }
        public string CharityBoxTypeName { get; set; }
    }
}