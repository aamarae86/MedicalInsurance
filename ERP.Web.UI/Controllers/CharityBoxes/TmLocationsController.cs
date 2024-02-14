using ERP._System.__CharityBoxes._TmLocations.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.CharityBoxes;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.CharityBoxes
{
    [CustomPermissionFilter(PermissionNames.Pages_TmLocations)]
    public class TmLocationsController : BaseController
    {
        public TmLocationsController() : base("TmLocations", PermissionNames.Pages_TmLocations_Insert) { }

        #region Views
        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_TmLocations_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                TmLocationsVM TmLocationsVM = Helper<TmLocationsVM>.Convert(JsonConvert.SerializeObject(response2.result));
                ViewData["DetailAsync"] = TmLocationsVM;
            }

            return View();
        }

        public PartialViewResult TmLocationsSearch() => PartialView();
        public PartialViewResult TmLocationsData() => PartialView();
        public PartialViewResult TmLocationsForm(long? id, string trigger, TmLocationsVM TmLocationsVM)
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

                return PartialView(TmLocationsVM);
            }

            return PartialView();
        }
        public PartialViewResult TmLocationsFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;

            return PartialView();
        }
        public PartialViewResult TmLocationsDataDetail() => PartialView();
        public PartialViewResult TmLocationsFormDetail2(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }
        public PartialViewResult TmLocationsDataDetail2() => PartialView();
        #endregion

        #region Actions
        public async Task<ActionResult> LoadDataGrid(TmLocationsSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<TmLocationsSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<TmLocationsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<TmLocationsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateOrUpdateTmLocations(TmLocationsVM vm)
        {

            //if (string.IsNullOrEmpty(vm.ListOfSubLocationsStr))
            //{
            //    var result = new RestResult
            //    {
            //        success = false,
            //        customRestResult = new CustomRestResult
            //        {
            //            message = TmLocations.FillDetailTable
            //        }
            //    };

            //    return Json(result, JsonRequestBehavior.AllowGet);
            //}

            //vm.InputCollection = 
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

        [HttpPost]
        public async Task<ActionResult> GetExistLocationNameAsync(string LocationName, string Id)
        {
            try
            {
                //var x = IsExists(input).Result;
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistLocationNameAsync?input={LocationName}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetExistSubLocationNameAsync(string SubLocationName, string Id)
        {
            try
            {
                //var x = IsExists(input).Result;
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistSubLocationNameAsync?input={SubLocationName}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
        #endregion
    }
}