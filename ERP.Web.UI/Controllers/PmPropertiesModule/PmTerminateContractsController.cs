using ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;
using ERP.Web.UI.Models.ViewModels.PmPropertiesModule;

namespace ERP.Web.UI.Controllers.PmPropertiesModule
{
    public class PmTerminateContractsController : BaseController
    {
        public PmTerminateContractsController() : base("PmTerminateContracts", PermissionNames.Pages_PmTerminateContracts_Insert) { }

        public PartialViewResult PmTerminateContractsSearch() => PartialView();

        public PartialViewResult PmTerminateContractsData() => PartialView();

        public async Task<PartialViewResult> PmTerminateContractsForm(int? id, string trigger)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<PmTerminateContractsVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(PmTerminateContractsSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<PmTerminateContractsSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<PmTerminateContractsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<PmTerminateContractsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostPmTerminateContracts(PmTerminateContractsVM vm)
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