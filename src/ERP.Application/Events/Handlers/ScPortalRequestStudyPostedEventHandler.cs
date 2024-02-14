using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Abp.Net.Mail;
using ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers;
using ERP.Authorization;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.Events.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Events.Handlers
{
    public class ScPortalRequestStudyPostedEventHandler :
        IEventHandler<ScPortalRequestStudyPostedFromManagerEventData>
        , ITransientDependency
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public IEmailSender EmailSender { get; set; }


        public ScPortalRequestStudyPostedEventHandler(
            UserManager userManager
            , RoleManager roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void HandleEvent(ScPortalRequestStudyPostedFromManagerEventData eventData)
        {
            var mails = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_ApMiscPaymentHeaders);
            var link = NotifyFor30DaysRemainOnContractWorker.GenerateFormViewLinkForEmailBody("ApMiscPaymentHeaders", eventData.encId);
            foreach (var mail in mails)
            {
                var message = $"<div style='font-size:24px;'><strong>السيد/ {mail.Name} المحترم </strong><br> يرجى العلم انه تم عمل سند صرف عام للطلب رقم <u>{eventData.scPortalRequestMgrDecision?.ScPortalRequestStudy?.ScPortalRequest?.PortalRequestNumber}</u> اسم الحالة <u>{eventData.scPortalRequestMgrDecision?.ScPortalRequestStudy?.ScPortalRequest?.Name}</u> ويصرف باسم <u>{eventData.scPortalRequestMgrDecision?.CashingTo}</u>.<br>الرجاء مراجعة <a href={link}>شاشة سند صرف عام</a></div>";
                SendMail(mail.EmailAddress, message);
            }
        }

        private bool SendMail(string Email, string MessageBody)
        {
            try
            {
                EmailSender.Send(Email, "سند صرف عام جديد", $"{MessageBody}");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
