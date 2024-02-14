using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ERP.ResourcePack.CRM.Leads;
using ERP._System.__CRM._ActivityCall;
using ERP._System.__CRM._ActivityMeeting;
using ERP._System.__CRM._ActivityTasks;
using ERP.ResourcePack.CRM.activityCall;
using ERP.ResourcePack.Common;

namespace ERP.Web.UI.Models.ViewModels.CRM.Leads
{
    public class CrmLeadsPersonsVM : BasePostAuditedVM<long>
    {

        [Display(Name = nameof(crmLeadsPersons.CreatedBy), ResourceType = typeof(crmLeadsPersons))]
        public string CreatedBy { get; set; }

        [Display(Name = nameof(crmLeadsPersons.CreatedDate), ResourceType = typeof(crmLeadsPersons))]
        public string CreatedDate { get; set; }

        [Display(Name = nameof(crmLeadsPersons.UserName), ResourceType = typeof(crmLeadsPersons))]        
        public long UserId { get; set; }

        public string EncId { get; set; }
        [Display(Name = nameof(crmLeadsPersons.RegisterDate), ResourceType = typeof(crmLeadsPersons))]
        public string RegisterDate { get; set; }

        [Display(Name = nameof(crmLeadsPersons.LeadStatusIdLkp), ResourceType = typeof(crmLeadsPersons))]
        public long? LeadStatusIdLkp { get; set; }
        public string LeadStatusVal { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.FirstName), ResourceType = typeof(crmLeadsPersons))]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.LastName), ResourceType = typeof(crmLeadsPersons))]
        public string LastName { get; set; }

        [MaxLength(150)]
        [Display(Name = nameof(crmLeadsPersons.Title), ResourceType = typeof(crmLeadsPersons))]
        public string Title { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.Phone), ResourceType = typeof(crmLeadsPersons))]
        public string Phone { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.Fax), ResourceType = typeof(crmLeadsPersons))]
        public string Fax { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.Mobile), ResourceType = typeof(crmLeadsPersons))]
        public string Mobile { get; set; }

        [MaxLength(150)]
        [Display(Name = nameof(crmLeadsPersons.Email), ResourceType = typeof(crmLeadsPersons))]
        public string Email { get; set; }

        [MaxLength(150)]
        [Display(Name = nameof(crmLeadsPersons.SecondaryEmail), ResourceType = typeof(crmLeadsPersons))]
        public string SecondaryEmail { get; set; }

        [MaxLength(500)]
        [Display(Name = nameof(crmLeadsPersons.Company), ResourceType = typeof(crmLeadsPersons))]
        public string Company { get; set; }

        [MaxLength(500)]
        [Display(Name = nameof(crmLeadsPersons.Website), ResourceType = typeof(crmLeadsPersons))]
        public string Website { get; set; }

        [Display(Name = nameof(crmLeadsPersons.LeadSourceLkpId), ResourceType = typeof(crmLeadsPersons))]
        public long? LeadSourceLkpId { get; set; }
        public string LeadSourceVal { get; set; }

        [Display(Name = nameof(crmLeadsPersons.IndustryLkpId), ResourceType = typeof(crmLeadsPersons))]
        public long? IndustryLkpId { get; set; }
        public string IndustryVal { get; set; }

        [Display(Name = nameof(crmLeadsPersons.AnnualRevenue), ResourceType = typeof(crmLeadsPersons))]
        public decimal? AnnualRevenue { get; set; }

        [Display(Name = nameof(crmLeadsPersons.NoOfEmployees), ResourceType = typeof(crmLeadsPersons))]
        public int? NoOfEmployees { get; set; }

        [Display(Name = nameof(crmLeadsPersons.RatingLkpId), ResourceType = typeof(crmLeadsPersons))]
        public long? RatingLkpId { get; set; }
        public string RatingVal { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.Skype), ResourceType = typeof(crmLeadsPersons))]
        public string Skype { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(crmLeadsPersons.Twitter), ResourceType = typeof(crmLeadsPersons))]
        public string Twitter { get; set; }

        [Display(Name = nameof(crmLeadsPersons.EmailOptOutId), ResourceType = typeof(crmLeadsPersons))]
        public bool? EmailOptOutId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(crmLeadsPersons.Description), ResourceType = typeof(crmLeadsPersons))]
        public string Description { get; set; }

        [MaxLength(2000)]
        [Display(Name = nameof(crmLeadsPersons.Street), ResourceType = typeof(crmLeadsPersons))]
        public string Street { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.City), ResourceType = typeof(crmLeadsPersons))]
        public string City { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.State), ResourceType = typeof(crmLeadsPersons))]
        public string State { get; set; }

        [Display(Name = nameof(crmLeadsPersons.CountryLkpId), ResourceType = typeof(crmLeadsPersons))]
        public long? CountryLkpId { get; set; }

        [Display(Name = nameof(crmLeadsPersons.CountryVal), ResourceType = typeof(crmLeadsPersons))]
        public string CountryVal { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.ZipCode), ResourceType = typeof(crmLeadsPersons))]
        public string ZipCode { get; set; }


        [MaxLength(2000)]
        [Display(Name = nameof(crmLeadsPersons.LeadImage), ResourceType = typeof(crmLeadsPersons))]
        public string LeadImage { get; set; }   
        
        [MaxLength(2000)]
        public string ShowLink { get; set; }

        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        public string ToDate { get; set; }
        //type(Tasks-Calls-Meetings)
        //date

        [Display(Name = nameof(crmLeadsPersons.ActivityType), ResourceType = typeof(crmLeadsPersons))]
        public string ActivityType { get; set; }

        [Display(Name = nameof(crmLeadsPersons.ActivityDate), ResourceType = typeof(crmLeadsPersons))]
        public string ActivityDate { get; set; }

        public ICollection<ERP._System.__CRM._ActivityCall.ActivityCall> ActivityCall { get; set; }
        public ICollection<ActivityMeeting> ActivityMeeting { get; set; }
        public ICollection<ERP._System.__CRM._ActivityTasks.ActivityTasks> ActivityTasks { get; set; }

        [Display(Name = nameof(crmLeadsPersons.FullName), ResourceType = typeof(crmLeadsPersons))]
        public string FullName =>   FirstName +" "+LastName;

        public long? TypeLkpId { get; set; }

        public string lang { get; set; }

        [Display(Name = nameof(crmLeadsPersons.CrmProductId), ResourceType = typeof(crmLeadsPersons))]
        public long? CrmProductId { get; set; }

        [Display(Name = nameof(crmLeadsPersons.CrmServiceId), ResourceType = typeof(crmLeadsPersons))]
        public long? CrmServiceId { get; set; }

        [Display(Name = nameof(activityCall.CallResultLkpId), ResourceType = typeof(activityCall))]
        public long? CallResultLkpId { get; set; }
        public string CallResultLkpVal { get; set; }
        public string CrmProductAr { get; set; }
        public string CrmProductEn { get; set; }
        public string CrmServiceAr { get; set; }
        public string CrmServiceEn { get; set; }
        #region Contacts
        [Display(Name = nameof(crmLeadsPersons.AccountLkpId), ResourceType = typeof(crmLeadsPersons))]
        public string AccountName { get; set; }

        [Display(Name = nameof(crmLeadsPersons.VendorLkpId), ResourceType = typeof(crmLeadsPersons))]
        public string VendorName { get; set; }


        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.Department), ResourceType = typeof(crmLeadsPersons))]

        public string Department { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.OtherPhone), ResourceType = typeof(crmLeadsPersons))]

        public string OtherPhone { get; set; }
        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.HomePhone), ResourceType = typeof(crmLeadsPersons))]

        public string HomePhone { get; set; }
        [Display(Name = nameof(crmLeadsPersons.OtherCountryLkpId), ResourceType = typeof(crmLeadsPersons))]

        public long? OtherCountryLkpId { get; set; }

        public string OtherCountryLkpVal { get; set; } //"Country"
        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.OtherState), ResourceType = typeof(crmLeadsPersons))]

        public string OtherState { get; set; }
        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.OtherCity), ResourceType = typeof(crmLeadsPersons))]

        public string OtherCity { get; set; }
        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.OtherStreet), ResourceType = typeof(crmLeadsPersons))]

        public string OtherStreet { get; set; }
        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.OtherZipCode), ResourceType = typeof(crmLeadsPersons))]

        public string OtherZipCode { get; set; }
        [MaxLength(150)]
        [Display(Name = nameof(crmLeadsPersons.Assistant), ResourceType = typeof(crmLeadsPersons))]

        public string Assistant { get; set; }
        [Display(Name = nameof(crmLeadsPersons.DateOfBirth), ResourceType = typeof(crmLeadsPersons))]

        public string DateOfBirth { get; set; }
        [MaxLength(30)]
        [Display(Name = nameof(crmLeadsPersons.AssistantPhone), ResourceType = typeof(crmLeadsPersons))]

        public string AssistantPhone { get; set; }
        #endregion

        public int? IsLead { get; set; }

    }
}