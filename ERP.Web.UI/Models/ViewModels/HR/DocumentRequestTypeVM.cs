using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class DocumentRequestTypeVM : BaseAuditedEntityVM<long>
    {

        public string DocumentRequestName { get; set; }
    }
}