using CrystalDecisions.CrystalReports.Engine;
using ERP._System._ArInvoiceHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ArInvoiceHdController : BaseController
    {
        public ArInvoiceHdController() : base("ArInvoiceHd", PermissionNames.Pages_ArInvoiceHd_Insert) { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_ArInvoiceHd_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });


            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            var response = await _restClientContainer.SendRequest<RestResult>($"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

            ViewBag.IsNotPosted = true;

            ViewData["ListGlAccHeadersVM"] = response.result == null ? null : Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                var glJeHeaders = Helper<ArInvoiceHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
                ViewData["DetailAsync"] = glJeHeaders;
            }

            return View();
        }

        public PartialViewResult ArInvoiceHdSearch() => PartialView();
        public PartialViewResult ArInvoiceHdData() => PartialView();
        public PartialViewResult ArInvoiceHdForm(long? id, string trigger, ArInvoiceHdVM glJeHeadersVM)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() ||
                trigger == FormTriggers.Show.ToString())
            {

                ViewBag.trigger = trigger;

                return PartialView(glJeHeadersVM);
            }

            return PartialView();
        }
        public PartialViewResult ArInvoiceHdDataDetail() => PartialView();
        public PartialViewResult ArInvoiceHdFormDetail(long? id, string trigger, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewBag.trigger = trigger;
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;
            return PartialView();
        }

        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(ArInvoiceHdSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ArInvoiceHdSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ArInvoiceHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ArInvoiceHdVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> CreateArInvoiceHd(ArInvoiceHdVM vm)
        {
            if (string.IsNullOrEmpty(vm.ListArInvoiceTr))
            {
                var result = new RestResult
                {
                    success = false,
                    customRestResult = new CustomRestResult
                    {
                        message = GlJeHeaders.MustAddAtLeastOneGlLine
                    }
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            if (vm.Id == 0)
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = FormTriggers.Insert.ToString(),
                    message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = FormTriggers.Update.ToString(),
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

        public async Task<JsonResult> PrintArInvoiceHdScreen(string id, string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));
            var langu = Request.Cookies["Lang"].Value;

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetArInvoiceHdScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<ArInvoiceHdScreenDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));


                var path = langu == "en-US" ? Server.MapPath("~/ReportsEn/rptArInvoiceHdScreen_En.rpt") : Server.MapPath("~/Reports/rptArInvoiceHdScreen.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptArInvoiceHdScreenTitle);
                Session["DocumentRpt"] = cryRpt;

                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}