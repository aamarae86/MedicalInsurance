using Abp.AutoMapper;
using ERP._System.__CRM._ActivityCall;
using ERP._System.__CRM._ActivityMeeting;
using ERP._System.__CRM._ActivityTasks;
using ERP._System.__CRM._Projects;
using ERP._System.__CRM.Leads;
using ERP._System.__CRM.Services;
using ERP._System.__PmPropertiesModule._FmContracts.Dto;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmLeadsPersons.Dto
{
    public class CrmLeadsPersonsDto : PostAuditedEntityDto<long>
    { 

        public string CreatedBy { get; set; }
        public string CreatedByUser { get; set; }
        public string EncId => CipherStringController.Encrypt(Id.ToString());

        public string RegisterDate { get; set; }
        public long LeadStatusIdLkp { get; set; }

        public string LeadStatusVal { get; set; }

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
        public long LeadSourceLkpId { get; set; }
        public string LeadSourceVal { get; set; }


        public long IndustryLkpId { get; set; }
        public string IndustryVal { get; set; }
        public string ShowLink { get; set; }
        public string CallResultLkpVal { get; set; }
        public  ICollection<ActivityCall> ActivityCall { get; set; }
        public  ICollection<ActivityMeeting> ActivityMeeting { get; set; }
        public  ICollection<ActivityTasks> ActivityTasks { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int NoOfEmployees { get; set; }
        public long RatingLkpId { get; set; }
        public string RatingVal { get; set; }
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
        public long CountryLkpId { get; set; }
        public string CountryVal { get; set; }
       
        [MaxLength(30)]
        public string ZipCode { get; set; }
        [MaxLength(2000)]
        public string LeadImage { get; set; }
        public long TypeLkpId { get; set; }

        public string lang { get; set; }


        public long CrmProductId { get; set; }
        public long CrmServiceId { get; set; }

        public string CrmProductAr { get; set; }
        public string CrmProductEn { get; set; }
        public string CrmServiceAr { get; set; }
        public string CrmServiceEn { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDate { get; set; }
        public CrmServices CrmServices { get; set; }
        public CrmProducts CrmProducts { get; set; }

        #region Contacts
        public string AccountName { get; set; }
        public string VendorName { get; set; }

        [MaxLength(30)]
        public string Department { get; set; }

        [MaxLength(30)]
        public string OtherPhone { get; set; }
        [MaxLength(30)]
        public string HomePhone { get; set; }
        public long? OtherCountryLkpId { get; set; }

        public string OtherCountryLkpVal { get; set; } //"Country"
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
        public string DateOfBirth { get; set; }
        [MaxLength(30)]
        public string AssistantPhone { get; set; }


        #endregion


    }
}
