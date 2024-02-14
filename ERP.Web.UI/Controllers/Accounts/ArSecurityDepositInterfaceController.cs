using CrystalDecisions.CrystalReports.Engine;
using ERP._System._ArSecurityDepositInterface.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ArSecurityDepositInterfaceController : BaseController
    {
        public ArSecurityDepositInterfaceController() : base("ArSecurityDepositInterface", PermissionNames.Pages_ArSecurityDepositInterface_Insert) { }

        public PartialViewResult ArSecurityDepositInterfaceSearch() => PartialView();

        public PartialViewResult ArSecurityDepositInterfaceData() => PartialView();

        public async Task<PartialViewResult> ArSecurityDepositInterfaceForm(long? id, string trigger)
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

                var currentRow = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<ArSecurityDepositInterfaceVM>.Convert(JsonConvert.SerializeObject(currentRow.result));

                var response = await _restClientContainer.SendRequest<RestResult>($"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

                ViewData["ListGlAccHeadersVM"] = response.result == null ? null : Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(ArSecurityDepositInterfaceSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ArSecurityDepositInterfaceSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ArSecurityDepositInterfaceVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ArSecurityDepositInterfaceVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostArSecurityDepositInterface(ArSecurityDepositInterfaceVM vm)
        {
            if (vm.Id == 0)
            {
                var response = new RestResult
                {
                    success = false,
                    customRestResult = new CustomRestResult()
                    {
                        trigger = FormTriggers.Insert.ToString(),
                        message = $"{Settings.Error}"
                    }
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

        public async Task<JsonResult> PrintArSecurityDepositInterfaceScreen(string id, string lang)
        {
            //long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id =Convert.ToInt64(id), Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetArSecurityDepositInterfaceScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptArSecurityDepositInterfaceScreenDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptArSecurityDepositInterfaceScreen_En.rpt") : Server.MapPath("~/Reports/rptArSecurityDepositInterfaceScreen.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ArSecurityDepositInterface.rptArSecurityDepositInterfaceScreenTitle);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}