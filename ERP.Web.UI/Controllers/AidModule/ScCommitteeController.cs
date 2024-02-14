using ERP.Authorization;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Web.UI.Models.ResultModels;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ERP._System.__AidModule._ScCommittee.Dto;
using ERP.Web.UI.Models.ViewModels.AidModule;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Accounts;
using System;
using ERP.ResourcePack.AidModule;
using ERP._System.PostRecords.Dto;
using ERP.Web.UI.Models.ReportModels;
using CrystalDecisions.CrystalReports.Engine;

namespace ERP.Web.UI.Controllers.AidModule
{
    public class ScCommitteeController : BaseController
    {
        public ScCommitteeController() : base("ScCommittee", PermissionNames.Pages_ScCommittee_Insert) { }

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_ScCommittee_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                var committeeVM = Helper<ScCommitteeVM>.Convert(JsonConvert.SerializeObject(response2.result));

                ViewData["DetailAsync"] = committeeVM;
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_ScCommittee_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }

        public PartialViewResult ScCommitteeSearch() => PartialView();

        public PartialViewResult ScCommitteeData() => PartialView();

        public PartialViewResult ScCommitteeForm(long? id, string trigger, ScCommitteeVM ScCommitteeVM)
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

                return PartialView(ScCommitteeVM);
            }

            return PartialView();
        }

        public PartialViewResult ScCommitteeDataDetail() => PartialView();

        public PartialViewResult ScCommitteeFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public PartialViewResult ScCommitteeDataMemberDetail() => PartialView();

        public PartialViewResult ScCommitteeFormMemberDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public PartialViewResult ScCommitteeElectronicAidsData() => PartialView();

        public PartialViewResult ScCommitteeElectronicAidsForm(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(ScCommitteeSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ScCommitteeSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ScCommitteeVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ScCommitteeVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateOrUpdateScCommittee(ScCommitteeVM vm)
        {
            if (string.IsNullOrEmpty(vm.ListScCommitteeDetail))
            {
                var result = new RestResult
                {
                    success = false,
                    customRestResult = new CustomRestResult
                    {
                        message = ScCommittee.PleaseAddLeastOneCommitteDetail
                    }
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            if (vm.Id == 0)
            {
                vm.ListStudies = Helper<List<ScCommitteeDetailCreateDto>>.Convert(vm.ListScCommitteeDetail);
                if (!string.IsNullOrEmpty(vm.ListScCommitteeMemberDetail))
                {
                    vm.ListMembers = Helper<List<ScCommitteeMemberDetailCreateDto>>.Convert(vm.ListScCommitteeMemberDetail);
                }
                vm.StatusLkpId = 156;
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
                vm.ListEditStudies = Helper<List<ScCommitteeDetailEditDto>>.Convert(vm.ListScCommitteeDetail);
                if (!string.IsNullOrEmpty(vm.ListScCommitteeMemberDetail))
                    vm.ListEditMembers = Helper<List<ScCommitteeMemberDetailEditDto>>.Convert(vm.ListScCommitteeMemberDetail);
                //vm.StatusLkpId = 156;
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

        public PartialViewResult Refuse(long id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        public PartialViewResult Postpone(long id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        public async Task<JsonResult> PrintScCommitteeScreen(string id, string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetScCommitteesScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptScCommitteeScreenData>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/Reports/rptCommitteesScreen.rpt") : Server.MapPath("~/Reports/rptCommitteesScreen.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", "اللجنه تفصيلى");

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}