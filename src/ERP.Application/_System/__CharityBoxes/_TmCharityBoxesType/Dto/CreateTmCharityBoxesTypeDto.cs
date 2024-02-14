using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__AccountModule._TmCharityBoxesType.Dto
{
    [AutoMap(typeof(TmCharityBoxesType))]
    public class CreateTmCharityBoxesTypeDto
    {
        [MaxLength(20)]
        [Required]
        public string TypeCode { get; set; }
        [Required]
        [MaxLength(200)]
        public string CharityBoxTypeName { get; set; }
        [MaxLength(4000)]
        public string Notes { get;  set; }
        public bool IsActive { get; set; }
    }
}
