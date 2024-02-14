using Abp.Application.Services.Dto;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP._System._ArJobSurveyHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.Warehouses;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ArJobSurveyHdController : BaseController
    {
        public ArJobSurveyHdController() : base("ArJobSurveyHd", PermissionNames.Pages_ArJobSurveyHd_Insert) { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_ArJobSurveyHd_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });


            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

             

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                var glJeHeaders = Helper<ArJobSurveyHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
                ViewData["DetailAsync"] = glJeHeaders;
            }

            return View();
        }

        public PartialViewResult ArJobSurveyHdSearch() => PartialView();
        public PartialViewResult ArJobSurveyHdData() => PartialView();
        public PartialViewResult ArJobSurveyHdForm(long? id, string trigger, ArJobSurveyHdVM glJeHeadersVM)
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

                return PartialView(glJeHeadersVM);
            }

            return PartialView();
        }
        public PartialViewResult ArJobSurveyHdDataDetail() => PartialView();
        public PartialViewResult ArJobSurveyHdFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(ArJobSurveyHdSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ArJobSurveyHdSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ArJobSurveyHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ArJobSurveyHdVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> CreateArJobSurveyHd(ArJobSurveyHdVM vm)
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

        //public async Task<JsonResult> PrintArJobSurveyHdScreen(string id, string lang)
        //{
        //    long longId = Convert.ToInt64(CipherStringController.Decrypt(id));
        //    var langu = Request.Cookies["Lang"].Value;

        //    var input = new IdLangInputDto { Id = longId, Lang = lang };

        //    var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetArJobSurveyHdScreenData", RestSharp.Method.GET, input.ToString());

        //    if (response.success)
        //    {
        //        var dataConverted = Helper<List<ArJobSurveyHdScreenDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));


        //        var path = langu == "en-US" ? Server.MapPath("~/ReportsEn/rptArJobSurveyHdScreen_En.rpt") : Server.MapPath("~/Reports/rptArJobSurveyHdScreen.rpt");

        //        ReportDocument cryRpt = new ReportDocument();
        //        cryRpt.Load(path);
        //        cryRpt.SetDataSource(dataConverted);
        //        cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptArJobSurveyHdScreenTitle);
        //        Session["DocumentRpt"] = cryRpt;

        //        return Json(dataConverted, JsonRequestBehavior.AllowGet);
        //    }



        //    return Json(false, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult SearchGetrptArJobSurvey(string typeid)
        {
            return View();
        }
        public async Task<ActionResult> PrintGetrptArJobSurvey(string id)
        {
            try
            {
                GetrptArJobSurveyInputReportVM input = new GetrptArJobSurveyInputReportVM
                {
                    Id = System.Convert.ToInt32(id),
                    TenantId = 1,
                    Lang = "ar-EG"
                };
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetrptArJobSurvey", RestSharp.Method.GET, input.ToString());

                if (response.success)
                {
                    var dataConverted = Helper<List<Models.ReportModels.GetrptArJobSurveyOutputReportVM>>.Convert(JsonConvert.SerializeObject(response.result));
                    var langu = Request.Cookies["Lang"].Value;
                    var path = input.Lang == "en-US" ? Server.MapPath("~/Reports/rptArJobSurvey1.rpt") : Server.MapPath("~/Reports/rptArJobSurvey1.rpt");
                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(path);

                    List<GetrptArJobSurveyOutputReportVM> modelList = new List<GetrptArJobSurveyOutputReportVM>();
                    int ReportRowCount = 11;
                    int DifferenceCount = ReportRowCount - (dataConverted.Count % ReportRowCount);

                    List<string> extraPartsNames = new List<string>();

                    for (int i = 0; i < dataConverted.Count; i++)
                    {
                        GetrptArJobSurveyOutputReportVM model = new GetrptArJobSurveyOutputReportVM();

                        model.ClaimDate = string.IsNullOrEmpty(dataConverted[i].ClaimDate) ? dataConverted[i].ClaimDate : Convert.ToDateTime(dataConverted[i].ClaimDate).ToString(Formatters.DateFormat);
                        model.ClaimNo = dataConverted[i].ClaimNo;
                        model.InsuredVehicle = dataConverted[i].InsuredVehicle;
                        model.TPVehicle = dataConverted[i].TPVehicle;
                        model.VehicleMake = dataConverted[i].VehicleMake;
                        model.VehicleModel = dataConverted[i].VehicleModel;
                        model.PlateNo = dataConverted[i].PlateNo;
                        model.Comments = dataConverted[i].Comments;
                        model.TenantId = dataConverted[i].TenantId;
                        model.PartsCategoryName = dataConverted[i].PartsCategoryName;
                        model.PartsName = dataConverted[i].PartsName;
                        model.LumpsumAmount = dataConverted[i].LumpsumAmount;


                        //if (!string.IsNullOrEmpty(dataConverted[i].PartsName))
                        //{
                        //    string[] parts = dataConverted[i].PartsName.Split(',');
                        //    if (parts.Length > 15)
                        //    {
                        //        model.PartsName = string.Join(", ", parts.Take(15));
                        //        model.PartsName1 = string.Join(", ", parts.Skip(15));
                        //    }
                        //    else
                        //    {
                        //        model.PartsName = dataConverted[i].PartsName;
                        //        model.PartsName1 = string.Empty; // Leave PartsName1 empty
                        //    }
                        //}
                        //else
                        //{
                        //    model.PartsName = string.Empty;
                        //    model.PartsName1 = string.Empty;
                        //}
                        //model.VehicleConditionRepair = (dataConverted[i]?.IsRepair.Value==true)? "True" : "";
                        //model.VehicleConditionReplace = (dataConverted[i]?.IsReplace.Value == true) ? "True" : "";

                        model.VehicleConditionRepair = dataConverted[i].IsRepair ? "Yes" : "";
                        model.VehicleConditionReplace = dataConverted[i].IsReplace ? "Yes" : "";
                        model.ContactNumber = dataConverted[i].ContactNumber;
                        model.ContactName = dataConverted[i].ContactName;
                        model.VehicleColor = dataConverted[i].VehicleColor;
                        model.LabourAmount = dataConverted[i].LabourAmount;
                        model.PartAmount = dataConverted[i].PartAmount;
                        model.TotalAmount = dataConverted[i].TotalAmount;
                        model.Days = dataConverted[i].Days;
                        model.PartsName1 = dataConverted[i].AmountInWords;

                        modelList.Add(model);
                    }
                    for (int i = 0; i < DifferenceCount; i++)
                    {
                        GetrptArJobSurveyOutputReportVM model = new GetrptArJobSurveyOutputReportVM();

                        model.ClaimNo = "";
                        model.ClaimDate = "";
                        model.ClaimNo = "";
                        model.VehicleMake = "";
                        model.VehicleModel = "";
                        model.PlateNo = "";
                        model.Comments = "";
                        model.PartsCategoryName = "";
                        model.PartsName = "";
                        model.ContactNumber = "";
                        model.ContactName = "";
                        model.VehicleColor = "";
                        model.LabourAmount = dataConverted[0].LabourAmount;
                        model.PartAmount = dataConverted[0].PartAmount;
                        model.TotalAmount = dataConverted[0].TotalAmount;
                        model.LumpsumAmount = dataConverted[0].LumpsumAmount;
                        model.PartsName1 = dataConverted[0].AmountInWords;
                        model.VehicleConditionReplace = "";
                        model.VehicleConditionReplace = "";
                        model.Days = "";

                        modelList.Add(model);
                    }
                    cryRpt.SetDataSource(modelList);
                    var stream = cryRpt.ExportToStream(ExportFormatType.PortableDocFormat);
                    byte[] buf;
                    buf = new byte[stream.Length];
                    stream.Read(buf, 0, buf.Length);
                    string base64EncodedPDF = System.Convert.ToBase64String(buf);
                    return Json(base64EncodedPDF, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}