using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.Repository;
using ERP.Helpers.Core;
using ERP.Users.Dto;
using ERP.Web.UI.Models.ViewModels.General;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers.Base
{
    [CustomActionFilter]
    public class BaseController : Controller
    {
        protected string BaseApiAppServiceUrL
        {
            get
            {
                return $"{ConfigurationManager.AppSettings["ApiUrl"]}services/app/";
            }
        }

        protected readonly RestClientContainer _restClientContainer;

        protected const string _apiPermission = "User";

        protected readonly string _apiAppService;
        protected readonly string _insertPermissionName;

        public BaseController(string apiAppService, string insertPermissionName)
        {
            _apiAppService = apiAppService;
            _insertPermissionName = insertPermissionName;
            _restClientContainer = new RestClientContainer(BaseApiAppServiceUrL);
        }

        public virtual async Task<ActionResult> Index()
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();
           

            TempData["Permissions"] = allPermissions;
            TempData["InsertPermission"] = insertPermission;

            return View();
        }

        protected async Task<(string allPermissions, string insertPermission)> GetMainPermissions(string apiAppServicePlus = null)
        {
            string actionPermissionsUrl = _apiAppService == "Role" | _apiAppService == "User" ?
                $"{_apiPermission}/GetActionPermissions?ActionName={apiAppServicePlus ?? _apiAppService}s" :
                $"{_apiPermission}/GetActionPermissions?ActionName={apiAppServicePlus ?? _apiAppService}";

            var response = await _restClientContainer.SendRequest<RestResult>(actionPermissionsUrl, RestSharp.Method.GET);
            string permissionsStr = null;

            if (response.success)
            {
                var actionData = Helper<PermissionsResult>.Convert(JsonConvert.SerializeObject(response.result));
                permissionsStr = actionData.ToString();

            }
            return (permissionsStr,
               permissionsStr.Contains(_insertPermissionName) ?
                  permissionsStr.Substring(
                      permissionsStr.IndexOf(_insertPermissionName), _insertPermissionName.Length)
                  : string.Empty);
        }


        #region Special_Permissions
        public virtual async Task<ActionResult> SpecialPermissionsManagement(string UserId, string apiAppServicePlus = null)
        {
            string actionPermissionsUrl = _apiAppService == "Role" | _apiAppService == "User" ?
                $"{_apiPermission}/GetActionSpecialPermissionsForUserToUpdate?ActionName={apiAppServicePlus ?? _apiAppService}s&UserId={UserId}" :
                $"{_apiPermission}/GetActionSpecialPermissionsForUserToUpdate?ActionName={apiAppServicePlus ?? _apiAppService}&UserId={UserId}";

            var response = await _restClientContainer.SendRequest<RestResult>(actionPermissionsUrl, RestSharp.Method.GET);
            if (response.success)
            {
                var actionData = Helper<ICollection<string>>.Convert(JsonConvert.SerializeObject(response.result));
                TempData["SpecialPermissions"] = actionData;
            }
            return View();
        }

        public async Task<ActionResult> PostSpecialPermissions(SpecialPermissionVM vm)
        {
            List<string> allowedPermissions = new List<string>();
            List<string> deniedPermissions = new List<string>();
            if (vm.PostAction==true)
                allowedPermissions.Add(PermissionNames.Pages_ScCommittee_Detail_Post);
            else
                deniedPermissions.Add(PermissionNames.Pages_ScCommittee_Detail_Post);
            if (vm.PostponeAction==true)
                allowedPermissions.Add(PermissionNames.Pages_ScCommittee_Detail_Postpone);
            else
                deniedPermissions.Add(PermissionNames.Pages_ScCommittee_Detail_Postpone);
            if (vm.RejectAction==true)
                allowedPermissions.Add(PermissionNames.Pages_ScCommittee_Detail_Reject);
            else
                deniedPermissions.Add(PermissionNames.Pages_ScCommittee_Detail_Reject);
            SpecialPermissionInputDto model = new SpecialPermissionInputDto()
            {
                UserId = vm.UserId,
                ActionName = _apiAppService,
                AllowedPermissions = allowedPermissions,
                DeniedPermissions = deniedPermissions
            };
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiPermission}/UpdateSpecialPermissionsForUseInAction", RestSharp.Method.PUT, model);

            response.customRestResult = new CustomRestResult()
            {
                trigger = ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
                message = response.success ? "Permissions Added To Role Successfully" : $"Error : {response.error.message}"
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        protected async Task<string> GetSpecialPermissionsForEdit(string UserId, string apiAppServicePlus = null)
        {
            string actionPermissionsUrl = _apiAppService == "Role" | _apiAppService == "User" ?
                $"{_apiPermission}/GetActionSpecialPermissionsForUserToUpdate?ActionName={apiAppServicePlus ?? _apiAppService}s&UserId={UserId}" :
                $"{_apiPermission}/GetActionSpecialPermissionsForUserToUpdate?ActionName={apiAppServicePlus ?? _apiAppService}&UserId={UserId}";

            var response = await _restClientContainer.SendRequest<RestResult>(actionPermissionsUrl, RestSharp.Method.GET);
            string specialPermissions = null;

            if (response.success)
            {
                var actionData = Helper<PermissionsResult>.Convert(JsonConvert.SerializeObject(response.result));
                specialPermissions = actionData.ToString();

            }
            return (specialPermissions);
        }
        #endregion
    }
}