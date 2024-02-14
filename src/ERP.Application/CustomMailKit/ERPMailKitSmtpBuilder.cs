using Abp.Configuration;
using Abp.MailKit;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.CustomMailKit
{
    public class ERPMailKitSmtpBuilder : DefaultMailKitSmtpBuilder
    {
        public ERPMailKitSmtpBuilder(ISmtpEmailSenderConfiguration smtpEmailSenderConfiguration, IAbpMailKitConfiguration abpMailKitConfiguration)
            : base(smtpEmailSenderConfiguration, abpMailKitConfiguration)
        {
        }

        protected override void ConfigureClient(SmtpClient client)
        {

            try
            {
                client.Connect("uscentral417.accountservergroup.com", 465, true);
                client.Authenticate("no-reply@tenxerp.com", "W1bWH5%Ii(op");
                //base.ConfigureClient(client);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
