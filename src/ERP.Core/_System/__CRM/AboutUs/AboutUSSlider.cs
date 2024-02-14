using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__CRM.AboutUs
{
   
    public class AboutUSSlider : PostAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(4000)]
        public string SliderFilepath { get; protected set; }

        public long CrmAboutUsId { get; set; }
        [ForeignKey(nameof(CrmAboutUsId))]
        public CrmAboutUs CrmAboutUs { get; set; }  

        public int TenantId { get; set; }

    }




}
