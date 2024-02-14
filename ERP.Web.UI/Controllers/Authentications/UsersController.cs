using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.Parameters.Users;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Authentications;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.Authentications
{
    public class UsersController : BaseController
    {
        public UsersController() : base("User", PermissionNames.Pages_Users_Insert) { }

        public PartialViewResult UsersSearch() => PartialView();

        public PartialViewResult UsersData() => PartialView();
        public async Task<PartialViewResult> UsersChangePassword() => PartialView();

        public async Task<PartialViewResult> UsersForm(int? id, string trigger)
        {
            if (id == null && trigger == Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == Front.Helpers.Enums.Common.FormTriggers.Update.ToString() || trigger == Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<UsersVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(UsersParms searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);


            var parameters = new GetAllPagedAndSortedWithParams<UsersParms>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };


            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<UsersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<UsersVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostUsers(UsersVM vm)
        {
            
            //if (vm.Id == 0) 
            //{
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
                    message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

            //    response.customRestResult = new CustomRestResult()
            //    {
            //        trigger =ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
            //        message = response.success ? "Updated Successfully" : $"Error : {response.error.message}"
            //    };

            //    return Json(response, JsonRequestBehavior.AllowGet);
            //}

        }

        public async Task<ActionResult> UpdateUser(UsersEditVM vm)
        {
            //if (vm.Id == 0)
            //{
            //    var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

            //    response.customRestResult = new CustomRestResult()
            //    {
            //        trigger =ERP.Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
            //        message = response.success ? "Added Successfully" : $"Error : {response.error.message}"
            //    };

            //    return Json(response, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),

                    message = response.success ? Settings.UpdatedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            //}

        }

        public async Task<ActionResult> ChangePassword(ChangePasswordParms passwordParms)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/ChangePassword", RestSharp.Method.POST, passwordParms);

            response.customRestResult = new CustomRestResult()
            {
                trigger = Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
                message = response.success ? Settings.UpdatedSuccessfully : $"{response.error.message}"
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