using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__Warehouses._PoPurchaseOrder.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Warehouses;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.Warehouses
{
    public class PoPurchaseOrderController : BaseController
    {
        public PoPurchaseOrderController() : base("PoPurchaseOrder", PermissionNames.Pages_PoPurchaseOrder_Insert) { }

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                bool AllowedToEditOrView = allPermissions.Contains(PermissionNames.Pages_PoPurchaseOrder_Update)
                        | allPermissions.Contains(PermissionNames.Pages_PoPurchaseOrder);

                if (!AllowedToEditOrView)
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                var CasesVM = Helper<PoPurchaseOrderVM>.Convert(JsonConvert.SerializeObject(response2.result));

                ViewData["DetailAsync"] = CasesVM;
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_PoPurchaseOrder_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }

        public PartialViewResult PoPurchaseOrderSearch() => PartialView();

        public PartialViewResult PoPurchaseOrderData() => PartialView();

        public PartialViewResult PoPurchaseOrderForm(long? id, string trigger, PoPurchaseOrderVM PoPurchaseOrderVM)
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

                return PartialView(PoPurchaseOrderVM);
            }

            return PartialView();
        }

        public PartialViewResult PoPurchaseOrderFormSupervisorCommentsDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public PartialViewResult PoPurchaseOrderDataDetail() => PartialView();

        public PartialViewResult PoPurchaseOrderFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(PoPurchaseOrderSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<PoPurchaseOrderSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };


            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<PoPurchaseOrderVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<PoPurchaseOrderVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateOrUpdatePoPurchaseOrder(PoPurchaseOrderVM vm)
        {
            if (vm.Id == 0)
            {
                if (!string.IsNullOrEmpty(vm.ListPoPurchaseOrderDetails))
                    vm.ListOfCreateDetails = Helper<List<PoPurchaseOrderDetailsCreateDto>>.Convert(vm.ListPoPurchaseOrderDetails);
                
                 var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
                    message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (!string.IsNullOrEmpty(vm.ListPoPurchaseOrderDetails))
                    vm.ListOfEditDetails = Helper<List<PoPurchaseOrderDetailsEditDto>>.Convert(vm.ListPoPurchaseOrderDetails);

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
                    message = response.success ? Settings.UpdatedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Delete?Id={id}", RestSharp.Method.DELETE);

            response.customRestResult = new CustomRestResult()
            {
                message = response.success ? Settings.DeletedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> PrintPoPurchaseOrderScreen(string id, string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetPoPurchaseOrderScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptPoPurchaseOrderScreenData>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptPoPurchaseOrderScreen_En.rpt") : Server.MapPath("~/Reports/rptPoPurchaseOrderScreen.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptPoPurchaseOrderScreenTitle);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}