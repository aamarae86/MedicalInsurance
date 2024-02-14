﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptPmPropertiesUnitsUnoccupiedOutput
    {
        public string OwnerNumber { get; set; }
        public string OwnerName { get; set; }
        public string PropertyNumber { get; set; }
        public string PropertyName { get; set; }
        public string UnitNo { get; set; }
        public string UnitTypeName { get; set; }
        public decimal AreaSize { get; set; }
        public string FinishesName { get; set; }
        public string FloorLevel { get; set; }
        public decimal YearlyRent { get; set; }
    }
}