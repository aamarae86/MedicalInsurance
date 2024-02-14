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
using ERP.Authorization;
using ERP._System.PostRecords.Dto;
using ERP.Web.UI.Models.ReportModels;
using CrystalDecisions.CrystalReports.Engine;
using ERP.Web.UI.Models.ViewModels.PmPropertiesModule;
using ERP._System.__PmPropertiesModule._FmContracts.Dto;

namespace ERP.Web.UI.Controllers.PmPropertiesModule
{ 
    public class FmContractsController : BaseController
    {
        public FmContractsController() : base("FmContracts", PermissionNames.Pages_FmContracts_Insert) { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);


            //
            var response = await _restClientContainer.SendRequest<RestResult>(
                $"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

            ViewData["ListGlAccHeadersVM"] = response.result == null ?
                null :
                Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));
            //





            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_FmContracts_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<FmContractsVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_FmContracts_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }

        public PartialViewResult FmContractsSearch() => PartialView();

        public PartialViewResult FmContractsData() => PartialView();
 
        public PartialViewResult FmContractsForm(long? id, string trigger, FmContractsVM FmContractsVM, List<GlAccHeadersVM> glAccHeadersVMs)
        {

            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;





            if (id == null && trigger == Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
                trigger == Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
            {

                ViewBag.trigger = trigger;

                return PartialView(FmContractsVM);
            }

            return PartialView();
        }

      
        public PartialViewResult FmContractsDataDetail() => PartialView();

        public PartialViewResult FmContractsFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }
            public PartialViewResult FmContractsDataDetail2() => PartialView();

            public PartialViewResult FmContractsFormDetail2(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }



        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(FmContractsSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<FmContractsSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<FmContractsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<FmContractsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostFmContracts(FmContractsVM vm)
        {
            
            vm.AdvAccountId = 0;
            vm.AccountId = 0;
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

        #endregion
    }



}