﻿using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class TimeSheetTypeVM : BaseAuditedEntityVM<long>
    {
        public string TimeSheetTypeName { get; set; }
    }
}