using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ERP._System.__CRM.AboutUs
{
   public class CrmAboutUs : PostAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(200)]
        [Required]
        public string HeaderNameAr { get; protected set; } 
        
        [StringLength(200)]
        [Required]
        public string HeaderNameEN { get; protected set; }

        [StringLength(4000)]
        public string ContentAr { get; protected set; }
        [StringLength(4000)]
        public string ContentEn { get; protected set; }
        [StringLength(4000)]
        public string AboutUsFilepath { get; protected set; }

        public ICollection<AboutUSSlider> AboutUSSliderPhotos { get; set; }
        public int TenantId { get; set; }

    }
}
