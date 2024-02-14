using Abp.Domain.Entities;
using ERP._System.__CRM._ActivityCall;
using ERP._System.__CRM._ActivityMeeting;
using ERP._System.__CRM._ActivityTasks;
using ERP._System.__CRM._Projects;
using ERP._System.__CRM.Services;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__CRM.Leads
{
   public class CrmLeadsPersons : PostAuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public DateTime? RegisterDate { get; set; }
        public long? LeadStatusIdLkp { get; set; }  
        [ForeignKey(nameof(LeadStatusIdLkp))]
        public FndLookupValues LeadStatus { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Fax { get; set; }
        [MaxLength(30)]
        public string Mobile { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(150)]
        public string SecondaryEmail { get; set; }
        [MaxLength(500)]
        public string Company { get; set; }
        [MaxLength(500)]
        public string Website { get; set; }

        public long? LeadSourceLkpId { get; set; }  

        [ForeignKey(nameof(LeadSourceLkpId))]
        public FndLookupValues LeadSources { get; set; }

        public long? IndustryLkpId { get; set; }  
        [ForeignKey(nameof(IndustryLkpId))]
        public FndLookupValues Industrys { get; set; }

        public decimal AnnualRevenue { get; set; }
        public int? NoOfEmployees { get; set; }

        public long? RatingLkpId { get; set; }  
        [ForeignKey(nameof(RatingLkpId))]
        public FndLookupValues Ratings { get; set; }

        [MaxLength(30)]
        public string Skype { get; set; }
        [MaxLength(200)]
        public string Twitter { get; set; }
        public bool EmailOptOutId { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
        [MaxLength(2000)]
        public string Street { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(30)]
        public string State { get; set; }

        public long? CountryLkpId { get; set; }  
        [ForeignKey(nameof(CountryLkpId))]
        public FndLookupValues Countrys { get; set; }

        public long? TypeLkpId { get; set; }  
        [ForeignKey(nameof(TypeLkpId))]
        public FndLookupValues TypeLkps { get; set; }

        [MaxLength(30)]
        public string ZipCode { get; set; }
        [MaxLength(2000)]
        public string LeadImage { get; set; }
        public bool IsActive { get; set; }
        public int TenantId { get; set; }
         
        public bool? WasLead { get; set; }
        public DateTime? ConvertDate { get; set; }
        public long? UserConvertId { get; set; }

        public string ShowLink { get; set; }

        public long? CrmProductId { get; set; }

        public long? CrmServiceId { get; set; }

        [ForeignKey(nameof(CrmServiceId))]
        public CrmServices CrmServices { get;  set; }

        [ForeignKey(nameof(CrmProductId))]
        public CrmProducts CrmProducts { get; set; }

        public virtual ICollection<ActivityCall> ActivityCall { get; set; }
        public virtual ICollection<ActivityMeeting> ActivityMeeting { get; set; }
        public virtual ICollection<ActivityTasks> ActivityTasks { get; set; }

        #region Contact

        public string AccountName { get; set; }
        public string VendorName { get; set; }
         
        [MaxLength(30)]
        public string Department { get; set; }

        [MaxLength(30)]
        public string OtherPhone { get; set; }
        [MaxLength(30)]
        public string HomePhone { get; set; }
        public long? OtherCountryLkpId { get; set; }
        [ForeignKey(nameof(OtherCountryLkpId))]
        public FndLookupValues OtherCountryLkp { get; set; } //"Country"
        [MaxLength(30)]
        public string OtherState { get; set; }
        [MaxLength(30)]
        public string OtherCity { get; set; }
        [MaxLength(30)]
        public string OtherStreet { get; set; }
        [MaxLength(30)]
        public string OtherZipCode { get; set; }
        [MaxLength(150)]
        public string Assistant { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(30)]
        public string AssistantPhone { get; set; }

       
       
        #endregion


        [NotMapped]
        public string Lang { get; set; }

    }

}
