using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ApPdcInterface.Dto
{
    [AutoMap(typeof(ApPdcInterface))]
    public class ApPdcInterfaceEditDto : EntityDto<long>
    {
        [MaxLength(4000)]
        public string Notes { get; set; }

        public string MaturityDate { get;  set; }

        public long? ChqReturnResonLKPId { get; set; }
    }
}
