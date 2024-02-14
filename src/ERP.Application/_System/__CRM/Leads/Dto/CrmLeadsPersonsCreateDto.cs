using Abp.AutoMapper;
using ERP._System.__CRM.Leads;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmLeadsPersons.Dto
{
    [AutoMap(typeof(CrmLeadsPersons))]
    public class CrmLeadsPersonsCreateDto
    {
        public string RegisterDate { get; set; }
        public long? LeadStatusIdLkp { get; set; }
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
        public long? IndustryLkpId { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int? NoOfEmployees { get; set; }
        public long? RatingLkpId { get; set; }
        [MaxLength(30)]
        public string Skype { get; set; }
        [MaxLength(200)]
        public string Twitter { get; set; }
        public bool? EmailOptOutId { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        [MaxLength(2000)]
        public string Street { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(30)]
        public string State { get; set; }
        public long? CountryLkpId { get; set; }
        [MaxLength(30)]
        public string ZipCode { get; set; }
        [MaxLength(2000)]
        public string LeadImage { get; set; }
        public long? TypeLkpId { get; set; }

        public long? CrmProductId { get; set; }
        public long? CrmServiceId { get; set; }

        #region Contacts
        public string AccountName { get; set; }
        public string VendorName { get; set; }

        public string ShowLink { get; set; }
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
        public int? IsLead { get; set; }


    }
}
