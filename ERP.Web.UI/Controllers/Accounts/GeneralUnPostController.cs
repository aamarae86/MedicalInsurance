using ERP._System.__AccountModule._GeneralUnPost.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class GeneralUnPostController : BaseController
    {
        public GeneralUnPostController() : base("GeneralUnPost", PermissionNames.Pages_GeneralUnPost_Insert) { }

        public PartialViewResult GeneralUnPostSearch() => PartialView();

        public PartialViewResult GeneralUnPostData() => PartialView();

        public async Task<PartialViewResult> GeneralUnPostForm(int? id, string trigger)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<GeneralUnPostVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(GeneralUnPostSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<GeneralUnPostSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<GeneralUnPostVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<GeneralUnPostVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostGeneralUnPost(GeneralUnPostVM vm)
        {
            if (vm.SourceLkpId == 936)
            {
                vm.ApMiscPaymentHeadersId = vm.Select2Temp;
            }
            else if (vm.SourceLkpId == 937)
            {
                vm.ArMiscReceiptHeadersId = vm.Select2Temp;
            }
            else if (vm.SourceLkpId == 944)
            {
                vm.PmContractId = vm.Select2Temp;
            }
            else if (vm.SourceLkpId == 945)
            {
                vm.ScCommitteesId = vm.Select2Temp;
            }
            else if (vm.SourceLkpId == 946)
            {
                vm.ScPortalRequestMgrDecisionId = vm.Select2Temp;
            }
            else if (vm.SourceLkpId == 11475)
            {
                vm.GlJeHeaderId = vm.Select2Temp;
            }
            else if (vm.SourceLkpId == 31623)
            {
                vm.ArJobCardHdId = vm.Select2Temp;
            }

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/CreateFromPost", RestSharp.Method.POST, vm);

            var responseConverted = Helper<PostOutput>.Convert(JsonConvert.SerializeObject(response.result));

            if (responseConverted != null && responseConverted.FinalStatues.Equals("F")) {                
                    response.success = false;
            }

            response.customRestResult = new CustomRestResult()
            {
                trigger = FormTriggers.Insert.ToString(),
                message = responseConverted != null ? responseConverted.Reason : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
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