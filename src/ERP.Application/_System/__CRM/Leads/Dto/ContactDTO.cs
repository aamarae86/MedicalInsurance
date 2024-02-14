using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__CRM.Leads.Dto
{
  public  class ContactDTO
    {

        #region Contacts
        public long? AccountLkpId { get; set; }
        public string AccountLkpVal { get; set; } //"CrmLeadsPersonsAccount"
        public long? VendorLkpId { get; set; }
        public string VendorLkpVal { get; set; } //"CrmLeadsPersonsVendor"

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
