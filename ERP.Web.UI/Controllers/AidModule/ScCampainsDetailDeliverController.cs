using ERP._System.__AidModule._ScCampains.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.AidModule;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.AidModule
{
    public class ScCampainsDetailDeliverController : BaseController
    {
        public ScCampainsDetailDeliverController() :  base("ScCampainsDetailDeliver", PermissionNames.Pages_ScCampainsDetailDeliver_Insert)
        { }

        public PartialViewResult ScCampainsDetailDeliverSearch() => PartialView();

        public PartialViewResult ScCampainsDetailDeliverData() => PartialView();

        public async Task<ActionResult> LoadDataGrid(MasterDetailSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);


            var parameters = new GetAllPagedAndSortedWithParams<MasterDetailSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };


            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAllForDetials", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ScCampainsDetailDeliverVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ScCampainsDetailDeliverVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }
    }
}