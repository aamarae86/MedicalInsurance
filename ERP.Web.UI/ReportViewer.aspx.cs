using CrystalDecisions.CrystalReports.Engine;
using ERP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP.Web.UI
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TenantDetailDto tenantDetail = new  TenantDetailDto();
            var tenantDetail = Session["tenantDetail"] as TenantDetailDto;
            ReportDocument cryRpt = Session["DocumentRpt"] as ReportDocument;
            cryRpt.SetParameterValue("LogoPath", !string.IsNullOrEmpty( tenantDetail.LogoPath) ?
                tenantDetail.LogoPath : Server.MapPath("~/AssetsPack/assets/images/img-previewer.png"));
            cryRpt.SetParameterValue("TenantName", tenantDetail.TenantNameAr??"Tenant Name");
            cryRpt.SetParameterValue("BoxNo", tenantDetail.BoxNo?? "BoxNo");
            cryRpt.SetParameterValue("Tel", tenantDetail.Tel??"Tel");
            cryRpt.SetParameterValue("Fax", tenantDetail.Fax??"Fax");
            cryRpt.SetParameterValue("Email", tenantDetail.Email??"Email");
            cryRpt.SetParameterValue("WebSite", tenantDetail.WebSite??"Website");
            cryRpt.SetParameterValue("UserName", Session["userName"]);
            CrystalReportViewer1.ReportSource = cryRpt;

        }
    }
}