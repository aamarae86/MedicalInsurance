using Abp.Authorization;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Abp.Net.Mail;
using ERP.Authorization;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.Events.Data;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Events.Handlers
{
    public class ScCommitteePostedEventHandler :
        IEventHandler<ScCommitteePostedEventData>
        , ITransientDependency
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public IEmailSender EmailSender { get; set; }


        public ScCommitteePostedEventHandler(
            UserManager userManager
            , RoleManager roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void HandleEvent(ScCommitteePostedEventData eventData)
        {
            var mails = _userManager.GetUsersForPermissionByPermissionName(PermissionNames.Pages_ApMiscPaymentHeaders);
            var cases = eventData.scCommitteeDetails;//.Include(s=>s.RequestStudy);
            if (cases.Count() > 0)
            {
                StringBuilder table = new StringBuilder("<table style='font-family: arial, sans-serif; border-collapse: collapse; width: 100%;'><tr><th>رقم الطلب </th><th>اسم الحالة</th><th>يصرف باسم</th><th>المبلغ</th></tr>");
                foreach (var item in cases)
                {
                    table.Append($"<tr><td>{item.RequestStudy?.ScPortalRequest?.PortalRequestNumber}</td><td>{item.RequestStudy?.ScPortalRequest?.Name}</td><td>{item.RequestStudy?.CashingTo}</td><td>{item.AidAmount}</td></tr>");
                }
                table.Append("</table>");
                foreach (var mail in mails)
                {
                    var message = $"<div style='font-size:24px;'><strong>السيد/ {mail.Name} المحترم </strong><br>تم إعتماد لجنة المساعدات رقم <u>{eventData.scCommittee?.CommitteeNumber}</u> بتاريخ <u>{eventData.scCommittee?.CommitteeDate.ToString(Formatters.DateFormat)}</u><br>وتم عمل سند صرف عام للحالات التالية<br>{table.ToString()}<br>الرجاء مراجعة شاشة سند صرف عام</div>";
                    SendMail(mail.EmailAddress, message);
                }
            }
        }

        private bool SendMail(string Email, string MessageBody)
        {
            try
            {
                EmailSender.Send(Email, "سندات صرف عام جديدة", $"{MessageBody}");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
