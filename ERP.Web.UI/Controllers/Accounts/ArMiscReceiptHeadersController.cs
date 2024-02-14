using ERP._System._ArMiscReceipt._ArMiscReceiptHeaders.Dto;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.WebUI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ERP.Front.Helpers.Core;
using ERP.Web.UI.Models.ViewModels.Accounts;
using Newtonsoft.Json;
using ERP.ResourcePack.Accounts;
using ERP.Authorization;
using static ERP.Front.Helpers.Enums.Common;
using ERP._System.PostRecords.Dto;
using ERP.Web.UI.Models.ReportModels;
using CrystalDecisions.CrystalReports.Engine;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ArMiscReceiptHeadersController : BaseController
    {
        public ArMiscReceiptHeadersController() : base("ArMiscReceiptHeaders", PermissionNames.Pages_ArMiscReceiptHeaders_Insert) { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_ArMiscReceiptHeaders_Insert))
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

                var arMiscReceiptHeadersVM = Helper<ArMiscReceiptHeadersVM>.Convert(JsonConvert.SerializeObject(response2.result));

                ViewData["DetailAsync"] = arMiscReceiptHeadersVM;
            }

            return View();
        }

        public PartialViewResult ArMiscReceiptHeadersSearch() => PartialView();
        public PartialViewResult ArMiscReceiptHeadersData() => PartialView();
        public PartialViewResult ArMiscReceiptHeadersForm(long? id, string trigger, ArMiscReceiptHeadersVM ArMiscReceiptHeadersVM)
        {

            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {

                ViewBag.trigger = trigger;

                return PartialView(ArMiscReceiptHeadersVM);
            }

            return PartialView();
        }
        public PartialViewResult ArMiscReceiptHeadersFormDetail(long? id, string trigger, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewBag.trigger = trigger;
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;

            return PartialView();
        }
        public PartialViewResult ArMiscReceiptHeadersDataDetail() => PartialView();
        public PartialViewResult ArMiscReceiptHeadersFormDetail2(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }
        public PartialViewResult ArMiscReceiptHeadersDataDetail2() => PartialView();
        #endregion

        #region Actions
        public async Task<ActionResult> LoadDataGrid(ArMiscReceiptHeadersSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ArMiscReceiptHeadersSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ArMiscReceiptHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ArMiscReceiptHeadersVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateArMiscReceiptHeaders(ArMiscReceiptHeadersVM vm)
        {

            if (string.IsNullOrEmpty(vm.ListArMiscReceiptLines))
            {
                var result = new RestResult
                {
                    success = false,
                    customRestResult = new CustomRestResult
                    {
                        message = ArMiscReceiptHeaders.FillDetailTable
                    }
                };

                return Json(result, JsonRequestBehavior.AllowGet);
            }

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
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
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

        //public async Task<ActionResult> PostArMiscReceiptHeaders(string id)
        //{
        //    PostDto postArMiscReceiptHeadersDto = new PostDto();
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        postArMiscReceiptHeadersDto.Id = Convert.ToInt64(CipherStringController.Decrypt(id));
        //    }
        //    if (postArMiscReceiptHeadersDto.Id <= 0)
        //    {
        //        var result = new RestResult
        //        {
        //            success = false,
        //            customRestResult = new CustomRestResult
        //            {
        //                message = Settings.Error
        //            }
        //        };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        postArMiscReceiptHeadersDto.Lang = HttpContext.Request.Cookies.Get("Lang") == null ? "ar-EG" : HttpContext.Request.Cookies.Get("Lang").Value;

        //        var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/PostArMiscReceiptHeader", RestSharp.Method.POST, postArMiscReceiptHeadersDto);

        //        if (response.success)
        //        {
        //            var storedResult = Helper<PostOutput>.Convert(JsonConvert.SerializeObject(response.result));
        //            var posted = storedResult.FinalStatues == "F" ? false : true;
        //            response.success = posted;
        //            response.customRestResult = new CustomRestResult()
        //            {
        //                trigger = posted ? FormTriggers.Post.ToString() : "",
        //                message = storedResult.Reason
        //            };
        //        }
        //        else
        //        {
        //            response.customRestResult = new CustomRestResult()
        //            {
        //                message = $"{Settings.Error} : {response.error.message}"
        //            };

        //        }

        //        return Json(response, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public async Task<JsonResult> PrintMiscreceiptScreen(string id, string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetMiscReceipttScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptMiscreceiptScreenData>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptMiscReceiveScreen_En.rpt") : Server.MapPath("~/Reports/rptMiscReceiveScreen.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", "سند قبض عام");

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}