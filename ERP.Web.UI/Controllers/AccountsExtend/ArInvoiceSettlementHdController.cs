using ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.AccountsExtend;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.AccountsExtend
{
    public class ArInvoiceSettlementHdController : BaseController
    {
        public ArInvoiceSettlementHdController() : base("ArInvoiceSettlementHd", PermissionNames.Pages_ArInvoiceSettlementHd_Insert) { }

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_ArInvoiceSettlementHd_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<ArInvoiceSettlementHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_ArInvoiceSettlementHd_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }
        public PartialViewResult ArInvoiceSettlementHdSearch() => PartialView();
        public PartialViewResult ArInvoiceSettlementHdData() => PartialView();
        public PartialViewResult ArInvoiceSettlementHdForm(long? id, string trigger, ArInvoiceSettlementHdVM ArInvoiceSettlementHdVM)
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

                return PartialView(ArInvoiceSettlementHdVM);
            }

            return PartialView();
        }

        public PartialViewResult InvoicesFormDetail() => PartialView();
        public PartialViewResult InvoicesDataDetail() => PartialView();
        public PartialViewResult RecepitsAndJournalesFormDetail() => PartialView();
        public PartialViewResult RecepitsAndJournalesDataDetail() => PartialView();

        #region Actions

        public async Task<ActionResult> LoadDataGrid(ArInvoiceSettlementHdSearchDto searchParms)
        {
            
            //SettlementNumber
            //StatusLkpId #
            //SettlementAmount
            //SettlementDate
            //ArCustomerId #
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ArInvoiceSettlementHdSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ArInvoiceSettlementHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ArInvoiceSettlementHdVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SaveArInvoiceSettlementHd(ArInvoiceSettlementHdVM vm)
        {
            if (vm.Id == 0)
            {
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

        #endregion

    }
}