using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.MultiTenancy.Dto
{
    public class TenantPaymentOptionsDto
    {

        [Required]
        public int TenantId { get; set; }

        [Required]
        public string AdminSubEndDate { get; set; }

        [Required]
        public decimal AdminValue { get; set; }

        [Required]
        public decimal UserValue { get; set; }  
        
        public int? AllowedDayes { get; set; }
    }
}
