using ERP._System._Modules.Dto;
using ERP._System._TenantFreeModules.Dto;
using ERP._System.TenantFreeModulesInput.Dto;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels;
using ERP.Web.UI.Models.ViewModels.Tenant;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers
{
    public class TenantFreeModulesController : BaseController
    {
        public TenantFreeModulesController() : base("TenantFreeModules", string.Empty) { }

        public PartialViewResult TenantFreeModulesSearch() => PartialView();

        public PartialViewResult TenantFreeModulesData() => PartialView();

        public async Task<PartialViewResult> TenantFreeModulesForm(int id, string trigger)
        {
            if (trigger == "chgPaymentValues")
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetTenantAppModules?id={id}", RestSharp.Method.GET);
                var dataConverted = Helper<TenantModuleVM>.Convert(JsonConvert.SerializeObject(response.result));
                return PartialView("ChangePaymentValues", dataConverted);
            }
            else if (trigger != "chgPaymentValues")
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetTenantAppModules?id={id}", RestSharp.Method.GET);
                var dataConverted = Helper<TenantModuleVM>.Convert(JsonConvert.SerializeObject(response.result));
                return PartialView(dataConverted);
            }
            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(TenantFreeModulesSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<TenantFreeModulesSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAllTenants", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<TenantDetailEditVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<TenantDetailEditVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        
       
    }
}