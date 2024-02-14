using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.POS;
using ERP.Web.UI.Models.ViewModels.Sales;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Pos
{
    public class IvPosHdController : BaseController
    {
        // GET: IvPosHd
        public IvPosHdController() : base("IvSaleHd", PermissionNames.Pages_IvSaleHd_Insert) { }

        public PartialViewResult IvPosHdSearch() => PartialView();

        public PartialViewResult IvPosHdData() => PartialView();
        public PartialViewResult IvPosHdDataDetail() => PartialView();

        public PartialViewResult IvPosHdFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public async Task<ActionResult> FormView(string id, string t)
        {

            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(Front.Helpers.Core.CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_IvSaleHd_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<IvSaleHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_IvSaleHd_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();


        }

        public PartialViewResult IvPosHdForm(long? id, string trigger, IvSaleHdVM IvPosHdVM)
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

                return PartialView(IvPosHdVM);
            }

            return PartialView();
        }

        public async Task<ActionResult> PostIvPosHd(IvPosHdVM vm)
        {
           
            if (vm.Id == 0)
            {
                vm.IsPOS= true;
                vm.SaleDateToday = DateTime.Now.ToString(ERP.Helpers.Core.Formatters.DateTimeFormat);
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);


                if (response != null)
                {


                    var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/PostHrSales", RestSharp.Method.POST, response.result);


                    
                    dynamic serialized = JsonConvert.SerializeObject(response.result);
                    var ivSale=JsonConvert.DeserializeObject<dynamic>(serialized);

                    dynamic serialized2 = JsonConvert.SerializeObject(response2);
                    var ivSale2 = JsonConvert.DeserializeObject<dynamic>(serialized2);

                    var oo = ivSale;
                    string id = oo.id+"";
                    var encId = CipherStringController.Encrypt(id);
                    var trigger = "28HR9KALoSpLQg3Lbhs-5A,,";//CipherStringController.Encrypt(FormTriggers.Show.ToString());

                    response.customRestResult = new CustomRestResult()
                    {
                        trigger = Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
                        message = response.success ? encId : $"{Settings.Error} : {response.error.message}"
                    };

                    return Json(response, JsonRequestBehavior.AllowGet);
                }

                response.customRestResult = new CustomRestResult()
                {
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
                    message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
                    message = response.success ? Settings.UpdatedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<string> RenderPrintView(string id,string salesMan)
        {
            string html = "";

            if (!string.IsNullOrEmpty(id))
            {
                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var model = Helper<IvSaleHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
                model.FndSalesMen.SalesManNameEn=salesMan;

                var total = model.IvSaleTrList.Sum(x => x.UnitPrice * x.Qty) - (model.Discount != null ? model.Discount : 0) + (model.DeliveryCharges != null ? model.DeliveryCharges : 0);
                model.Comments = total.Value.ToString("N");
                html = RenderViewToString(ControllerContext, "~/views/IvPosHd/Print.cshtml", model, true);
            }


            return html;
        }
        static string RenderViewToString(ControllerContext context, string viewPath, object model = null, bool partial = false)
        {
            // first find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath);
            else
                viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);

            if (viewEngineResult == null)
                throw new FileNotFoundException("View cannot be found.");

            // get the view and attach the model to view data
            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }

        //public async Task<ActionResult> LoadDataGrid(IvPosHdSearchDto searchParms)
        //{
        //    try
        //    {
        //        var dtParms = DataTableParmsHelper.GetParms(Request.Form);

        //        var parameters = new GetAllPagedAndSortedWithParams<IvPosHdSearchDto>()
        //        {
        //            Params = searchParms,
        //            Sorting = dtParms.sort.PairAsSqlExpression,
        //            OrderByValue = dtParms.sort,
        //            MaxResultCount = dtParms.pageSize,
        //            SkipCount = dtParms.skip
        //        };

        //        var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

        //        var dataConverted = Helper<ListResultBaseWithTotalRecords<IvPosHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

        //        int recordsTotal = dataConverted?.totalCount ?? 0;
        //        var data = dataConverted?.Items ?? new List<IvPosHdVM>();

        //        return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<ActionResult> PostIvPosHd(IvPosHdVM vm)
        //{
        //    if (vm.Id == 0)
        //    {
        //        var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);


        //        if (response != null)
        //        {


        //            var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/PostHrSales", RestSharp.Method.POST, response.result);

        //        }

        //        response.customRestResult = new CustomRestResult()
        //        {
        //            trigger = Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
        //            message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
        //        };

        //        return Json(response, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

        //        response.customRestResult = new CustomRestResult()
        //        {
        //            trigger = Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
        //            message = response.success ? Settings.UpdatedSuccessfully : $"{Settings.Error} : {response.error.message}"
        //        };

        //        return Json(response, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Delete?Id={id}", RestSharp.Method.DELETE);

            response.customRestResult = new CustomRestResult()
            {
                message = response.success ? Settings.DeletedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> index(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;            
            TempData["InsertPermission"] = insertPermission;

            if (string.IsNullOrEmpty(id))
            {
                ViewData["TotalDiscount"] = 0;
                return View();
            }
            try
            {
                ViewBag.trigger = CipherStringController.Decrypt(t);
            }
            catch {
                ViewBag.trigger = FormTriggers.Show.ToString();
            }
           
            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_IvSaleHd_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                var obj = Helper<IvSaleHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
                ViewData["DetailAsync"] = obj;
                ViewData["DeliveryCharges"] = obj.DeliveryCharges==null?0:obj.DeliveryCharges;
                ViewData["IsCash"] = obj.FndLookupPaymentMethodLkp.NameEn.ToLower()=="cash";
                ViewData["TotalDiscount"] = obj.Discount == null ? 0 : obj.Discount;
                ViewData["CreditCardRef"] = obj.CreditCardRef;
            }
            else
            {
                ViewData["TotalDiscount"] = 0;
                if (!insertPermission.Contains(PermissionNames.Pages_IvSaleHd_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();


        }
    }
}