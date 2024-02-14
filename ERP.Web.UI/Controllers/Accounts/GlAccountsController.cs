using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AccountModule._GlAccounts.ProcDto;
using ERP._System._GlAccounts.Dto;
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

namespace ERP.Web.UI.Controllers.Accounts
{
    public class GlAccountsController : BaseController
    {
        public GlAccountsController() : base("GlAccounts", PermissionNames.Pages_GlAccounts_Insert) { }

        public PartialViewResult GlAccountsSearch() => PartialView();

        public PartialViewResult GlAccountsData() => PartialView();

        public async Task<PartialViewResult> GlAccountsForm(int? id, string trigger)
        {
            if (id == null && trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
                trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<GlAccountsVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(GlAccountsSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);


            var parameters = new GetAllPagedAndSortedWithParams<GlAccountsSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };


            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<GlAccountsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<GlAccountsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostGlAccounts(GlAccountsVM vm)
        {
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

        [HttpPost]
        public async Task<ActionResult> CheckIsExistsCode(string Code, string Id)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistCodeAsync?input={Code}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CheckIsExistsDescriptionAr(string DescriptionAr, string Id)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistDescriptionArAsync?input={DescriptionAr}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
     
        [HttpPost]
        public async Task<ActionResult> CheckIsExistsDescriptionEn(string DescriptionEn, string Id)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistDescriptionEnAsync?input={DescriptionEn}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> PrintGlAccountsScreen(string id, string lang)
        {
            GlAccountsScreenDataInputDto glAccountsScreenDataInput = new GlAccountsScreenDataInputDto() { TenantId = 0, Lang = lang };
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetGlAccountsScreenData", RestSharp.Method.GET, glAccountsScreenDataInput.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptGlAccountsScreenData>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptGlAccountsScreen_En.rpt") : Server.MapPath("~/Reports/rptGlAccountsScreen.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptGlAccountsScreenTitle);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}