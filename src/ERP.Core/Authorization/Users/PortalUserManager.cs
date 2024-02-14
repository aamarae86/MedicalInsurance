using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.Net.Mail;
using Abp.UI;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP.Authorization.Users
{
    public class PortalUserManager : IPortalUserManager
    {
        public IEventBus EventBus { get; set; }
        public IEmailSender EmailSender { get; set; }
        public ISettingManager SettingManager { get; set; }

        private readonly IRepository<PortalUser, long> _portalUserRepository;

        public PortalUserManager
            (
            IRepository<PortalUser, long> portalUserRepository
            )
        {
            _portalUserRepository = portalUserRepository;
        }

        private async Task<bool> IdNumberNotRepeatedInDB(PortalUser input)
        {
            CheckIdNumbers checkIdNumbersDto = new CheckIdNumbers()
            {
                id = input.Id,
                IdNumber = input.IdNumber,
                idNumberWifeHusband1 = input.IdNumberWifeHusband1,
                idNumberWife2 = input.IdNumberWife2,
                idNumberWife3 = input.IdNumberWife3,
                idNumberWife4 = input.IdNumberWife4
            };
            var valid = await IdNumberNotRepeatedInDB(checkIdNumbersDto);
            return valid;
        }

        private async Task<bool> IdNumberNotRepeatedInDB(CheckIdNumbers input)
        {
            var valid = await _portalUserRepository.LongCountAsync(u => u.Id != input.id &&
               ((
                   (input.IdNumber != null &&
                   (
                    u.IdNumber == input.IdNumber
                   || u.IdNumberWifeHusband1 == input.IdNumber
                   || u.IdNumberWife2 == input.IdNumber
                   || u.IdNumberWife3 == input.IdNumber
                   || u.IdNumberWife4 == input.IdNumber)
                   )
               )
               ||
               (
                   (input.idNumberWifeHusband1 != null && (u.IdNumberWifeHusband1 == input.idNumberWifeHusband1 || u.IdNumber == input.idNumberWifeHusband1
                   || u.IdNumberWife2 == input.idNumberWifeHusband1 || u.IdNumberWife3 == input.idNumberWifeHusband1 || u.IdNumberWife4 == input.idNumberWifeHusband1))
               )
               ||
               (
                   (input.idNumberWife2 != null && (u.IdNumberWife2 == input.idNumberWife2 || u.IdNumber == input.idNumberWife2 || u.IdNumberWifeHusband1 == input.idNumberWife2
                   || u.IdNumberWife3 == input.idNumberWife2 || u.IdNumberWife4 == input.idNumberWife2))
               )
               ||
               (
                   (input.idNumberWife3 != null && (u.IdNumberWife3 == input.idNumberWife3 || u.IdNumber == input.idNumberWife3 || u.IdNumberWifeHusband1 == input.idNumberWife3 || u.IdNumberWife2 == input.idNumberWife3
                    || u.IdNumberWife4 == input.idNumberWife3))
               )
               ||
               (
                   (input.idNumberWife4 != null && (u.IdNumberWife4 == input.idNumberWife4 || u.IdNumber == input.idNumberWife4 || u.IdNumberWifeHusband1 == input.idNumberWife4 || u.IdNumberWife2 == input.idNumberWife4
                   || u.IdNumberWife3 == input.idNumberWife4))
               ))
            ) != 0;

            return valid;
        }

        public async Task<PortalUser> CreateAsync(PortalUser portalUser)
        {
            if (portalUser.RepeatedIdNumberForUser() || await IdNumberNotRepeatedInDB(portalUser))
            {
                throw new UserFriendlyException("Invalid Data, IdNumber Exist.");
            }

            return await _portalUserRepository.InsertAsync(portalUser);
        }
        public async Task<Select2PagedResult> GetPortalUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _portalUserRepository.GetAll()
                 .Where(z =>
                  string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.IdNumber.Contains(searchTerm) : z.IdNumber.Contains(searchTerm)))
                 .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.IdNumber : z.IdNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<Select2PagedResult> GetPortalUsersNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _portalUserRepository.GetAll()
                 .Where(z =>
                  string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.Name.Contains(searchTerm) : z.Name.Contains(searchTerm)))
                 .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.Name : z.Name }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<bool> TestSendMail(string Email, string ResetLink)
        {
            try
            {
                string username = string.Empty;
                //string mailBody = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /> <title>Demystifying Email Design</title> <meta name='viewport' content='width=device-width, initial-scale=1.0'/> <link href='https://fonts.googleapis.com/css2?family=Balsamiq+Sans&display=swap' rel='stylesheet'> <style> *{ font - family: 'Balsamiq Sans', cursive; } .red-head{ color:#bc2643; font-style: italic; font-weight: bold; } .blue-text{ color:#231f51; } .info-data{ color: #bc2643; font-style: italic; font-size: 14px; font-weight: bold; background: #23245c; display: inline-block; padding: 10px; border-radius: 8px; } </style></head><body style='margin: 0; padding: 0;'> <table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td style='padding: 10px 0 30px 0;'> <table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border: 1px solid #cccccc; border-collapse: collapse;'> <tr> <td align='center' bgcolor='#70bbd9' style='padding: 40px 0 30px 0; color: #153643; font-size: 28px; font-weight: bold; font-family: Arial, sans-serif;'> <img src='https://s3-us-west-2.amazonaws.com/s.cdpn.io/210284/h1.gif' alt='Creating Email Magic' width='300' height='230' style='display: block;' /> </td> </tr> <tr> <td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'> <table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td style='color: #153643;font-size: 24px;'> <h3 style='margin:0;text-align:center;'>Hi,</h3> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <p class='red-head'>Welcome to TenXERP</p> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <p class='blue-text' style='padding: 0px 25px;'>We are glad to have you! You can now start managing your business using our effective ERP system and grow business</p> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <p class='red-head'>Here is your login information: </p> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <a href='#'><p class='info-data'>Custom URL</p></a> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <a href='" + ResetLink + "'><p class='info-data'>Set-up Password</p></a> </td> </tr> <tr> <td style='color: #153643;font-family: Arial, sans-serif;font-size: 16px;line-height: 20px;text-align: center;'> <p class='blue-text' style='padding: 0px 25px;'>Thank you for choosing TenXERP</p> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <p style='color: #bc2643;text-align: right;'>-The TenXERP Team</p> </td> </tr> </table> </td> </tr> <tr> <td bgcolor='#f11739' style='padding: 20px 10px 20px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td width='25%'> <table border='0' cellpadding='0' cellspacing='0'> <tr> <td style='font-family: Arial, sans-serif; font-size: 12px; font-weight: bold;'> <a href='http://www.facebook.com/' style='display:inline-block;'> <img src='http://demo.tenxerp.com/TenxIco/facebook_link.svg' alt='Facebook' width='38' height='38' border='0' /> </a> <a href='http://www.instagram.com/' style='display:inline-block;margin:0px 3px;'> <img src='http://demo.tenxerp.com/TenxIco/instagram.svg' alt='Instagram' width='38' height='38' border='0' /> </a> <a href='http://www.whatsapp.com/' style='display:inline-block;'> <img src='http://demo.tenxerp.com/TenxIco/whatsapp_link.svg' alt='Whatsapp' width='38' height='38' border='0' /> </a> </td> </tr> </table> </td> <td style='color: #ffffff; font-family: Arial, sans-serif;font-style: italic;font-size: 13px;' width='25%'> 308-4265 Village Center Mississauya, Ontario </td> <td style='color: #ffffff; font-family: Arial, sans-serif;font-style: italic;font-size: 13px;border-right: 1px solid;border-left: 1px solid;text-align: center;' width='25%'> (+1)-6476737084 </td> <td style='color: #ffffff; font-family: Arial, sans-serif;font-style: italic;font-size: 13px;text-align: center;' width='25%'>  sales@tenxerp.com </td> </tr> </table> </td> </tr> </table> </td> </tr> </table></body></html>";

                string mailBody = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /> <title>Demystifying Email Design</title> <meta name='viewport' content='width=device-width, initial-scale=1.0'/> <link href='https://fonts.googleapis.com/css2?family=Balsamiq+Sans&display=swap' rel='stylesheet'> <style> *{ font - family: 'Balsamiq Sans', cursive; } .red-head{ color:#bc2643; font-style: italic; font-weight: bold; } .blue-text{ color:#231f51; } .info-data{ color: #bc2643; font-style: italic; font-size: 14px; font-weight: bold; background: #23245c; display: inline-block; padding: 10px; border-radius: 8px; } </style></head><body style='margin: 0; padding: 0;'> <table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td style='padding: 10px 0 30px 0;'> <table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border: 1px solid #cccccc; border-collapse: collapse;'> <tr> <td align='center' bgcolor='#70bbd9' style='padding: 40px 0 30px 0; color: #153643; font-size: 28px; font-weight: bold; font-family: Arial, sans-serif;'> <img src='https://s3-us-west-2.amazonaws.com/s.cdpn.io/210284/h1.gif' alt='Creating Email Magic' width='300' height='230' style='display: block;' /> </td> </tr> <tr> <td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'> <table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td style='color: #153643;font-size: 24px;'> <h3 style='margin:0;text-align:center;'>Hi,</h3> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <p class='red-head'>Welcome to TenXERP</p> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <p class='blue-text' style='padding: 0px 25px;'>We are glad to have you! You can now start managing your business using our effective ERP system and grow business</p> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <p class='red-head'>Here is your login information: </p> </td> </tr>  <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <a href='" + ResetLink + "'><p class='info-data' style='color: white;'>Set-up Password</p></a> </td> </tr> <tr> <td style='color: #153643;font-family: Arial, sans-serif;font-size: 16px;line-height: 20px;text-align: center;'> <p class='blue-text' style='padding: 0px 25px;'>Thank you for choosing TenXERP</p> </td> </tr> <tr> <td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'> <p style='color: #bc2643;text-align: right;'>-The TenXERP Team</p> </td> </tr> </table> </td> </tr> <tr> <td bgcolor='#f11739' style='padding: 20px 10px 20px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td width='25%'> <table border='0' cellpadding='0' cellspacing='0'> <tr> <td style='font-family: Arial, sans-serif; font-size: 12px; font-weight: bold;'> <a href='http://www.facebook.com/' style='display:inline-block;'> <img src='http://demo.tenxerp.com/TenxIco/facebook_link.svg' alt='Facebook' width='38' height='38' border='0' /> </a> <a href='http://www.instagram.com/' style='display:inline-block;margin:0px 3px;'> <img src='http://demo.tenxerp.com/TenxIco/instagram.svg' alt='Instagram' width='38' height='38' border='0' /> </a> <a href='http://www.whatsapp.com/' style='display:inline-block;'> <img src='http://demo.tenxerp.com/TenxIco/whatsapp_link.svg' alt='Whatsapp' width='38' height='38' border='0' /> </a> </td> </tr> </table> </td> <td style='color: #ffffff; font-family: Arial, sans-serif;font-style: italic;font-size: 13px;' width='25%'> 308-4265 Village Center Mississauya, Ontario </td> <td style='color: #ffffff; font-family: Arial, sans-serif;font-style: italic;font-size: 13px;border-right: 1px solid;border-left: 1px solid;text-align: center;' width='25%'> (+1)-6476737084 </td> <td style='color: #ffffff; font-family: Arial, sans-serif;font-style: italic;font-size: 13px;text-align: center;' width='25%'>  sales@tenxerp.com </td> </tr> </table> </td> </tr> </table> </td> </tr> </table></body></html>";


                await EmailSender.SendAsync(Email, "طلب تغيير كلمة السر", mailBody);
                //SendMail(Email, "طلب تغيير كلمة السر", mailBody);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public void SendMail(string toEmail, string Subject, string Body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("no-reply@tenxerp.com");
            message.To.Add(toEmail);
            message.Subject = Subject;
            message.IsBodyHtml = true;
            message.Body = Body;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = true;

            smtpClient.Host = "uscentral417.accountservergroup.com";
            smtpClient.Port = 465;
            //smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("no-reply@tenxerp.com", "W1bWH5%Ii(op");

            smtpClient.Send(message);
        }


    }
}
