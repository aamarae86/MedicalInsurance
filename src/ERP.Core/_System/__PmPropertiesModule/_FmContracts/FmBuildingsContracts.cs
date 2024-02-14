using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._FmContracts
{
   public class FmBuildingsContracts : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public long ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public FmContracts FmContracts { get; set; }
        public decimal Amount { get; set; }  


        public long PmPropertiesId { get; set; } 
        [ForeignKey(nameof(PmPropertiesId))]
        public PmProperties PmProperties { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string Comments { get; set; }   

        public bool IsActive  { get; set; }   
        public int TenantId { get; set; }






    }
}
