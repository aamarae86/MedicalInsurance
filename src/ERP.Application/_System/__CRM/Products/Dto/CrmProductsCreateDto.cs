using Abp.AutoMapper;
using ERP._System.__CRM._Projects;
using ERP._System._Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__CRM._CrmProducts.Dto
{
    [AutoMap(typeof(CrmProducts))]
    public class CrmProductsCreateDto
    {
        public bool IsActive { get; set; }
        [StringLength(200)]
        [Required]

        public string ProductNameAr { get; set; }
        [StringLength(200)]
        [Required]
        public string ProductNameEn { get; set; }

        [StringLength(4000)]
        public string ContentAr { get; set; }
        [StringLength(4000)]
        public string ContentEn { get; set; }
        [StringLength(500)]
        public string Filepath { get; set; }
    }
}
