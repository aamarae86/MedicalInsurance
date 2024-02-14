using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.Parameters.Roles;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Authentications;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Authentications
{
    public class RolesController : BaseController
    {
        public RolesController() : base("Role", PermissionNames.Pages_Roles_Insert) { }

        public PartialViewResult RolesSearch() => PartialView();

        public PartialViewResult RolesData() => PartialView();

        public async Task<PartialViewResult> RolesForm(int? id, string trigger)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<RolesVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<PartialViewResult> PermissionsForm(int id)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetRoleForEdit?Id={id}", RestSharp.Method.GET);
            var rolePermissions = Helper<RolePermissionsVM>.Convert(JsonConvert.SerializeObject(response.result));

            rolePermissions.SetRoleId(id);
            rolePermissions.FillPages();

            return PartialView(rolePermissions);
        }

        public async Task<PartialViewResult> UsersInRoleForm(int Id)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetUsersForRole?id={Id}", RestSharp.Method.GET);

            var dataConverted = Helper<RoleUsersVM>.Convert(JsonConvert.SerializeObject(response.result));

            return PartialView(dataConverted);
        }

        public async Task<ActionResult> LoadDataGrid(RolesParms searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);


            var parameters = new GetAllPagedAndSortedWithParams<RolesParms>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };


            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<RolesVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<RolesVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostRoles(RolesVM vm)
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

        public async Task<ActionResult> PostUsersToRole(RoleUsersVM vm)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/AddUsersToRole", RestSharp.Method.POST, vm);

            response.customRestResult = new CustomRestResult()
            {
                trigger = FormTriggers.Update.ToString(),
                message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteUserFromRole(int roleId, int userId)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/DeleteUserFromRole?userId={userId}&roleId={roleId}", RestSharp.Method.DELETE);

            response.customRestResult = new CustomRestResult()
            {
                trigger = FormTriggers.Update.ToString(),
                message = response.success ? Settings.DeletedSuccessfully : $"{Settings.Error} : {response.error.message}"
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

        public async Task<ActionResult> PostPermissionsToRole(RolePermissionsVM vm)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/UpdatePermissions", RestSharp.Method.PUT, vm);

            response.customRestResult = new CustomRestResult()
            {
                trigger = FormTriggers.Update.ToString(),
                message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public  PartialViewResult RoleKpiForm(long id)
        {
            ViewBag.roleId = id.ToString();
            return PartialView();
        }

        public async Task<ActionResult> PostRoleKpi(RoleKpiVM vm)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/UpdateRoleKpis", RestSharp.Method.PUT, vm);

            response.customRestResult = new CustomRestResult()
            {
                trigger = FormTriggers.Update.ToString(),
                message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }

}