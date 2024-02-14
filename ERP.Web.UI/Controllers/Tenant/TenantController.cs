using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Web.UI.Models.ViewModels.Tenant;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.Tenant
{
    public class TenantController : BaseController
    {
        public TenantController() : base("TenantData", null)  {}

        public async override Task<ActionResult> Index()
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetTenantDetailDto", RestSharp.Method.GET);

            var data = response.result == null ? null : Helper<TenantDetailEditVM>.Convert(JsonConvert.SerializeObject(response.result));

            return View(data);
        }


        [Route("success")]
        public ActionResult success()
        { 
            return View();
        }



    }
}