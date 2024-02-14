using ERP._System.__CRM._ActivityCall.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.CRM.ActivityCall;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.CRM
{
    public class ActivityCallController : BaseController
    {
        public ActivityCallController() : base("ActivityCall", PermissionNames.Pages_CrmLeadsPersons_Insert)
        { }

        public async Task<ActionResult> FormView(string id, string t, long? LeadContactId, string Name, string type)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions("CrmLeadsPersons");
            var Lang = Thread.CurrentThread.CurrentCulture.Name; //ar-EG

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_CrmLeadsPersons_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });

            ViewBag.trigger = CipherStringController.Decrypt(t);
            ViewBag.LeadId = LeadContactId;
            ViewBag.Leadname = Name;

            if (type == "lead")
            {
                ViewBag.RelLkpId = 11119;
                ViewBag.RelLkpVal = "Leads";
            }
            else if (type == "contact")
            {
                ViewBag.RelLkpId = 11121;
                ViewBag.RelLkpVal = "Contact";
            }
            else
            {
                ViewBag.RelLkpId = 11471;
                ViewBag.RelLkpVal = type;
            }

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (CipherStringController.Decrypt(t) == FormTriggers.Update.ToString() && !string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                //var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={decId}", RestSharp.Method.GET);
              
                //var Lang = Thread.CurrentThread.CurrentCulture.Name; //ar-EG
                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetSingle?Id={decId}&lang={Lang}", RestSharp.Method.GET);
                ViewData["DetailAsync"] = Helper<ActivityCallVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else if (!string.IsNullOrEmpty(id) && LeadContactId > 0)
            {
                Console.WriteLine($"{id} From lead or contact");
            }
            else if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                //var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={decId}", RestSharp.Method.GET);

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetSingle?Id={decId}&lang={Lang}", RestSharp.Method.GET);
                ViewData["DetailAsync"] = Helper<ActivityCallVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else { Console.WriteLine($"No Matched Condition"); }

            return View();
        }

        public PartialViewResult ActivityCallSearch() => PartialView();

        public PartialViewResult ActivityCallData() => PartialView();

        public PartialViewResult ActivityCallForm(int? id, string trigger, ActivityCallVM ActivityCallVM)
        {
            ViewBag.trigger = trigger;

            return PartialView(ActivityCallVM);
        }

        public async Task<ActionResult> LoadDataGrid(ActivityCallSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);
            searchParms.Lang = Thread.CurrentThread.CurrentCulture.Name;
            var parameters = new GetAllPagedAndSortedWithParams<ActivityCallSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ActivityCallVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ActivityCallVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostActivityCall(ActivityCallVM vm)
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