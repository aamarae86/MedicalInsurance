//using ERP._System.__HR._Notifications.Dto;
using Abp.Notifications;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Users.Dto;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.HR;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Users.UserAppService;

namespace ERP.Web.UI.Controllers
{
    public class NotificationsController : BaseController
    {
        public NotificationsController() : base("User", PermissionNames.Pages_Users_Insert) 
        { }

        #region Views

        //public async Task<ActionResult> FormView(string id, string t)
        //{
        //    var (allPermissions, insertPermission) = await GetMainPermissions();

        //    TempData["Permissions"] = allPermissions;

        //    ViewBag.trigger = CipherStringController.Decrypt(t);

        //    ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

        //        if (!allPermissions.Contains(PermissionNames.Pages_Notifications_Update))
        //            return RedirectToAction("Index", "Home", new { area = string.Empty });

        //        var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

        //        ViewData["DetailAsync"] = Helper<NotificationsVM>.Convert(JsonConvert.SerializeObject(response2.result));
        //    }
        //    else
        //    {
        //        if (!insertPermission.Contains(PermissionNames.Pages_Notifications_Insert))
        //            return RedirectToAction("Index", "Home", new { area = string.Empty });
        //    }

        //    return View();
        //}

        public PartialViewResult NotificationsSearch() => PartialView();

        public PartialViewResult NotificationsData() => PartialView();

        //public PartialViewResult NotificationsForm(long? id, string trigger, NotificationsVM NotificationsVM)
        //{
        //    if (id == null && trigger == Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
        //    {
        //        ViewBag.trigger = trigger;

        //        return PartialView();
        //    }
        //    else if (id != null && trigger == Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
        //        trigger == Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
        //    {

        //        ViewBag.trigger = trigger;

        //        return PartialView(NotificationsVM);
        //    }

        //    return PartialView();
        //}

        //public PartialViewResult VisaDataDetail() => PartialView();

        //public PartialViewResult VisaFormDetail(long? id, string trigger)
        //{
        //    ViewBag.trigger = trigger;
        //    return PartialView();
        //}

        //public PartialViewResult PassportDataDetail() => PartialView();

        //public PartialViewResult PassportFormDetail(long? id, string trigger)
        //{
        //    ViewBag.trigger = trigger;
        //    return PartialView();
        //}

        //public PartialViewResult IdentityCardDataDetail() => PartialView();

        //public PartialViewResult IdentityCardFormDetail(long? id, string trigger)
        //{
        //    ViewBag.trigger = trigger;
        //    return PartialView();
        //}

        //public PartialViewResult SalaryElementsDataDetail() => PartialView();

        //public PartialViewResult SalaryElementsFormDetail(long? id, string trigger)
        //{
        //    ViewBag.trigger = trigger;
        //    return PartialView();
        //}

        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(NotificationSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<NotificationSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetNotificationsList", RestSharp.Method.GET, parameters);

            try
            {
                var dataConverted = Helper<ListResultBaseWithTotalRecords<UserNotificationDto>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<UserNotificationDto>();

                var json =  Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch (Exception x)
            {

                throw;
            }       
        }

        public async Task<ActionResult> ChangeNotificationState(UserNotification vm)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/ChangeNotificationState?NotificationId={vm.Id.ToString()}", RestSharp.Method.POST, null);

            response.customRestResult = new CustomRestResult()
            {
                trigger = ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
                message = response.success ? Settings.UpdatedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Delete(string id)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/DeleteNotification?notificationId={id}", RestSharp.Method.DELETE);

            response.customRestResult = new CustomRestResult()
            {
                message = response.success ? Settings.DeletedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}