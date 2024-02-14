using Abp.Runtime.Security;
using ERP._System.__AccountModule._GlAccDetails.Dto;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.Parameters.Login;
using ERP.Front.Helpers.Repository;
using ERP.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers.Authentications
{
    public class LoginController : AnonymousBaseController
    {
        private readonly RestClientContainer restClientContainer;
        private const string _apiService = "TokenAuth";
        private const string _apiPermission = "services/app/User";
        private const string _apiGlAccDetails = "services/app/GlAccDetails";

        public LoginController()
        {
            System.Web.HttpContext.Current.Session["IsTestSrv"] = ConfigurationManager.AppSettings["IsTestServer"] != null ?
                                                                    (ConfigurationManager.AppSettings["IsTestServer"] == "true") : false;

            restClientContainer = new RestClientContainer(BaseApiAuthUrL);
        }
        

        public ActionResult Index(string returnUrl)
        {
            //string url = ControllerContext.HttpContext.Request.Url.Scheme + "://" + ControllerContext.HttpContext.Request.Url.Authority;
            //FrontEndUrlResolver.BaseURL = url;

            //So that the user can be referred back to where they were when they click logon
            if (string.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null)
                returnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);

            if (/*Url.IsLocalUrl(returnUrl) &&*/ !string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = returnUrl.ToLower().Contains("login") ? returnUrl.ToLower().Replace("login", "home") : returnUrl;
                ViewBag.ReturnURL = returnUrl;
            }

            //var IsTenantExist = false;
            
            //if(!IsTenantExist)
            //    return View("TenancyNotFound");

            return View();
        }

        public ActionResult ForgetPassword(int? TenantId = null, string Email = null, string ResetToken = null) { 
        
            return View();
        }

        //public ActionResult TenancyNotFound()
        //{

        //    return View();
        //}


        [HttpPost]
        public async Task<ActionResult> Index(LoginParms loginParms, string returnUrl)
        {
            if (loginParms.RememberClient) { }

            var response = await restClientContainer.SendRequest<RestResult>($"{_apiService}/Authenticate", RestSharp.Method.POST, loginParms);

            if (response?.success ?? false)
            {
                var data = Helper<AuthToken>.Convert(JsonConvert.SerializeObject(response.result));

                Session["userId"] = CipherStringController.Encrypt(data?.UserId.ToString());
                Session["userName"] = data.UserName;
                Session["token"] = data.AccessToken;
                Session["tenantDetail"] = data.TenantDetail;
                Session["TenantId"] = loginParms.TenantId;

                string permissionsStr = string.Empty;

                var menuPermissionResponse = await restClientContainer.SendRequest<RestResult>($"{_apiPermission}/GetMenuPermissions", RestSharp.Method.GET);

                if (menuPermissionResponse.success)
                {
                    var menuData = Helper<PermissionsResult>.Convert(JsonConvert.SerializeObject(menuPermissionResponse.result));
                    permissionsStr = menuData.ToString();
                }




                Session["UserMenuPermissions"] = permissionsStr;

                var cookie = Request.Cookies["Lang"];

                var lang = (cookie == null || cookie.Value.Trim() == string.Empty) ? "ar-EG" : cookie.Value;

               
                await SetGlAccDetailsInfo(lang);

                if (!data.IsHost && (!permissionsStr.Contains("TenentSubscriptionValid") || !permissionsStr.Contains("UserSubscriptionValid")) && permissionsStr.Contains("TenentAdmin"))
                {
                    return RedirectToAction("Index", "Tenant");
                }




                string decodedUrl = "";
                if (!string.IsNullOrEmpty(returnUrl))
                    decodedUrl = Server.UrlDecode(returnUrl);

                if (!string.IsNullOrEmpty(decodedUrl) && !decodedUrl.ToLower().Contains("login"))
                {
                    if (decodedUrl == "/Login")
                        return RedirectToAction("Index", "Home");
                    else
                        return Redirect(decodedUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["FailedMessage"] = $"{response?.error?.message ?? "Server ERROR!"}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            Session.Abandon();

            var response = await restClientContainer.SendRequest<RestResult>($"{_apiPermission}/ResetUserPermissions", RestSharp.Method.POST);

          //  if (response?.success ?? false)

              return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ChangeLanguage()
        {
            var cookie = Request.Cookies["Lang"];

            var lang = (cookie == null || cookie.Value.Trim() == string.Empty) ? "ar-EG" : cookie.Value == "ar-EG" ? "en-US" : "ar-EG";

            Callback(lang);

            await SetGlAccDetailsInfo(lang);

            return Redirect(this.Request.UrlReferrer.AbsoluteUri);
        }

        private async Task SetGlAccDetailsInfo(string lang)
        {
            var responseGlAccDefualtDetails = await restClientContainer
                    .SendRequest<RestResult>($"{_apiGlAccDetails}/GetDefaultGlAccDetails?lang={lang}", RestSharp.Method.GET);

            if (responseGlAccDefualtDetails.result != null)
            {
                var defData = Helper<DefaulGlAccDetailsInfo>.Convert(JsonConvert.SerializeObject(responseGlAccDefualtDetails.result));

                Session["DefaulGlAccDetailsInfo"] = defData;
            }
            else
            {
                Session["DefaulGlAccDetailsInfo"] = null;
            }

        }

            private void Callback(string Lang)
        {
            if (Lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            }

            HttpCookie cookie = new HttpCookie("Lang")
            {
                Value = Lang,
                Expires = DateTime.Now.AddDays(90)
            };

            Response.Cookies.Add(cookie);
        }
    }

}