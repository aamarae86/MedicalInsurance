using ERP._System.__SpGuarantees._SpCases.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.SpGuarantees;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.SpGuarantees
{
    public class SpCasesController : BaseController
    {
        public SpCasesController() : base("SpCases", PermissionNames.Pages_SpCases_Insert) { }

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                bool AllowedToEditOrView = allPermissions.Contains(PermissionNames.Pages_SpCases_Update)
                        | allPermissions.Contains(PermissionNames.Pages_SpCases);

                if (!AllowedToEditOrView)
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                var CasesVM = Helper<SpCasesVM>.Convert(JsonConvert.SerializeObject(response2.result));

                ViewData["DetailAsync"] = CasesVM;
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_SpCases_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }

        public PartialViewResult SpCasesSearch() => PartialView();

        public PartialViewResult SpCasesData() => PartialView();

        public PartialViewResult SpCasesForm(long? id, string trigger, SpCasesVM SpCasesVM)
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

                return PartialView(SpCasesVM);
            }

            return PartialView();
        }

        public PartialViewResult SpCasesFormSupervisorCommentsDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public PartialViewResult SpCasesDataMemberDetail() => PartialView();

        public PartialViewResult SpCasesFormMemberDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(SpCasesSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);


            var parameters = new GetAllPagedAndSortedWithParams<SpCasesSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };


            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<SpCasesVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<SpCasesVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateOrUpdateSpCases(SpCasesVM vm)
        {
            if (vm.Id == 0)
            {
                return Json("Not Allowed", JsonRequestBehavior.AllowGet);
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
    }

}