using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._FndCollectors.Dto
{
    [AutoMapFrom(typeof(FndCollectors))]
    [AutoMapTo(typeof(FndCollectors))]
    [AutoMap(typeof(FndCollectors))]
    public class CreateFndCollectorsDto
    {
        public string Lang { get; set; }
        public int? CollectorNumber { get;  set; } = 1;
        [MaxLength(200)]
        public string CollectorNameAr { get;  set; }
        [MaxLength(200)]
        public string CollectorNameEn { get;  set; }
    }
}
