using ERP._System.__SalesModule._FndSalesMen.Dto;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.Repository;
using ERP.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Sales;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace ERP.Web.UI.Controllers.Sales
{
    public class IvSaleHdInQueryController : BaseController
    {
        // GET: IvSaleHdQuery
        // GET: IvSaleHd
        public IvSaleHdInQueryController() : base("IvSaleHd", PermissionNames.Pages_IvSaleHdInQuery_Audit) { }

        public PartialViewResult IvSaleHdInQuerySearch() => PartialView();

        public PartialViewResult IvSaleHdInQueryData() => PartialView();

        public async Task<ActionResult> FormView(string id, string t)
        {

            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetSalesInQueryDetailAsync?Id={decId}", RestSharp.Method.GET);

                //ViewData["DetailAsync"] = Helper<IvSaleHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
                var obj = Helper<IvSaleHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
                ViewData["DetailAsync"] = obj;
                ViewData["PaymentMethodLkpId"] = obj.PaymentMethodLkpId;
            }
           
            return View();
        }

        public PartialViewResult IvSaleHdInQueryDataDetail() => PartialView();

        public PartialViewResult IvSaleHdInQueryFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }


        public PartialViewResult IvSaleHdInQueryForm(long? id, string trigger, IvSaleHdVM IvSaleHdVM)
        {
            if (id == null && trigger == Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
                trigger == Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
            {

                ViewBag.trigger = trigger;

                return PartialView(IvSaleHdVM);
            }

            return PartialView();
        }


        public async Task<ActionResult> LoadDataGrid(IvSaleHdSearchDto searchParms)
        {
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<IvSaleHdSearchDto>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAllInQuerySales", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<IvSaleHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<IvSaleHdVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}