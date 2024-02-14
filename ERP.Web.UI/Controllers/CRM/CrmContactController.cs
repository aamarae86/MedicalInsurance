using ERP._System.__CRM._CrmLeadsPersons.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.CRM.Leads;
using ERP.Web.UI.Models.ViewModels.PmPropertiesModule;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.CRM
{
    public class CrmContactController : BaseController
    {
        public CrmContactController() : base("CrmLeadsPersons", PermissionNames.Pages_CrmLeadsPersons_Insert)
        { }

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_CrmLeadsPersons_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                //var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={decId}", RestSharp.Method.GET);
                var Lang = Thread.CurrentThread.CurrentCulture.Name; //ar-EG
                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get1?Id={decId}&lang={Lang}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<CrmLeadsPersonsVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }

            return View();
        }

        public PartialViewResult CrmContactSearch() => PartialView();

        public PartialViewResult CrmContactData() => PartialView();

        public PartialViewResult CrmContactForm(int? id, string trigger, CrmLeadsPersonsVM CrmLeadsPersonsVM)
        {
            ViewBag.trigger = trigger;

            return PartialView(CrmLeadsPersonsVM);
        }

        public async Task<ActionResult> LoadDataGrid(CrmLeadsPersonsSearchDto searchParms)
        {
            searchParms.IsLead = 0;
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);
            searchParms.Lang = Thread.CurrentThread.CurrentCulture.Name;
            var parameters = new GetAllPagedAndSortedWithParams<CrmLeadsPersonsSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<CrmLeadsPersonsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<CrmLeadsPersonsVM>();
            var jsonResult = Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostCrmContact(CrmLeadsPersonsVM vm)
        {
            vm.AnnualRevenue = 0;
            vm.IsLead = 0;
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
    }
}
