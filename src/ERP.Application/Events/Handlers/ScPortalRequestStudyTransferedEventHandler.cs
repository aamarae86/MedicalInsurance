using Abp.Authorization;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Abp.Net.Mail;
using ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers;
using ERP.Authorization;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Core;
using ERP.Events.Data;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Events.Handlers
{
    public class ScPortalRequestStudyTransferedEventHandler :
        IEventHandler<ScPortalRequestStudyTransferedToManagerEventData>
        , IEventHandler<ScPortalRequestStudyPostedToCommitteeEventData>
        , ITransientDependency
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private static IConfiguration _config;

        public IEmailSender EmailSender { get; set; }


        public ScPortalRequestStudyTransferedEventHandler(
            UserManager userManager
            , RoleManager roleManager
            , IPermissionManager permissionManager
            , IPermissionChecker permissionChecker
            , IConfiguration config
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            ScPortalRequestStudyTransferedEventHandler._config = config;
        }

        public void HandleEvent(ScPortalRequestStudyTransferedToManagerEventData eventData)
        {
            var mails = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_ScPortalRequestMgrDecision);
            string link = NotifyFor30DaysRemainOnContractWorker.GenerateFormViewLinkForEmailBody("ScPortalRequestMgrDecision", eventData.encId); //CipherStringController.Encrypt(eventData.scPortalRequestStudy.Id.ToString()));
            foreach (var mail in mails)
            {
                var message = $"<div style='font-size:24px;'><strong>السيد/ {mail.Name} المحترم </strong><br> يرجى العلم انه تم دراسة الطلب رقم <u>{eventData.scPortalRequestStudy?.ScPortalRequest?.PortalRequestNumber}</u> باسم <u>{eventData.scPortalRequestStudy?.ScPortalRequest?.Name}</u> واعتماده لاتخاذ القرار المناسب<br>الرجاء مراجعة <a href='{link}'>شاشة قرار المدير </a> لاتخاذ القرار المناسب</div>";
                SendMail(mail.EmailAddress, message);
            }
        }

        public void HandleEvent(ScPortalRequestStudyPostedToCommitteeEventData eventData)
        {
            var mails = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_ScCommittee);
            //string link = GenerateLinkForEmailBody("ScCommittee", eventData.encId); //CipherStringController.Encrypt(eventData.scPortalRequestStudy.Id.ToString()));
            foreach (var mail in mails)
            {
                var message = $"<div style='font-size:24px;'><strong>السيد/ {mail.Name} المحترم </strong><br> يرجى العلم انه تم دراسة الطلب رقم <u>{eventData.scPortalRequestStudy?.ScPortalRequest?.PortalRequestNumber}</u> باسم <u>{eventData.scPortalRequestStudy?.ScPortalRequest?.Name}</u> واعتماده لاتخاذ القرار المناسب<br>الرجاء مراجعة شاشة لجنة المساعدات لاتخاذ القرار المناسب</div>";
                SendMail(mail.EmailAddress, message);
            }
        }

        //public static string GenerateLinkForEmailBody(string module, string encId, string baseURL = "")
        //{
        //    string baseLink = string.IsNullOrEmpty(baseURL) ?
        //        "https://erpcharity.uaq.ae" : baseURL;
        //    return $"{baseLink}/{module}/FormView?id={encId}&t=28HR9KALoSpLQg3Lbhs-5A,,";
        //}

        private bool SendMail(string Email, string MessageBody)
        {
            try
            {
                EmailSender.Send(Email, "طلب مساعدة جديد", $"{MessageBody}");
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw;
            }
        }

    }
}
