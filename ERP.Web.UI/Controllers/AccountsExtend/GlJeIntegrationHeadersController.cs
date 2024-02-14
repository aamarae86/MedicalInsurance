using ERP._System.__AccountModule._GlAccDetails.Dto;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.AccountsExtend;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.AccountsExtend
{
    public class GlJeIntegrationHeadersController : BaseController
    {
        private const string _apiGlAccDetails = "services/app/GlAccDetails";

        public GlJeIntegrationHeadersController() : base("GlJeIntegrationHeaders", PermissionNames.Pages_GlJeIntegrationHeaders_Insert) { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_GlJeIntegrationHeaders_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            var response = await _restClientContainer.SendRequest<RestResult>($"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

            ViewData["ListGlAccHeadersVM"] = response.result == null ? null : Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));


            var cookie = Request.Cookies["Lang"];

            var lang = (cookie == null || cookie.Value.Trim() == string.Empty) ? "ar-EG" : cookie.Value;

            var responseGlAccDefualtDetails = await _restClientContainer
                                .SendRequest<RestResult>($"GlAccDetails/GetDefaultGlAccDetails?lang={lang}", RestSharp.Method.GET);

            if (responseGlAccDefualtDetails.result != null)
            {
                var defData = Helper<DefaulGlAccDetailsInfo>.Convert(JsonConvert.SerializeObject(responseGlAccDefualtDetails.result));

                Session["DefaulGlAccDetailsInfo"] = defData;
            }


            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<GlJeIntegrationHeadersVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }

            return View();
        }

        public PartialViewResult GlJeIntegrationHeadersSearch() => PartialView();
        public PartialViewResult GlJeIntegrationHeadersData() => PartialView();
        public PartialViewResult GlJeIntegrationHeadersForm(long? id, string trigger, GlJeIntegrationHeadersVM glJeIntegrationHeadersVM)
        {

            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView(glJeIntegrationHeadersVM);
            }

            return PartialView();
        }
        public PartialViewResult AccountsLinesDataDetail() => PartialView();
        public PartialViewResult AccountsLinesFormDetail(long? id, string trigger, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;
            ViewBag.trigger = trigger;
            return PartialView();
        }
        public PartialViewResult CustomersLinesDataDetail() => PartialView();
        public PartialViewResult CustomersLinesFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }
        public PartialViewResult VendorsLinesDataDetail() => PartialView();
        public PartialViewResult VendorsLinesFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }
        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(GlJeIntegrationHeadersSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<GlJeIntegrationHeadersSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<GlJeIntegrationHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<GlJeIntegrationHeadersVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateGlJeIntegrationHeaders(GlJeIntegrationHeadersVM vm)
        {
            try
            {
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
            catch(Exception ex)
            {
                throw;
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