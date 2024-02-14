using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersonTimeSheet;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._TimeSheetType.Dto
{
    [AutoMap(typeof(TimeSheetType))]
    public  class TimeSheetTypeEditDto : EntityDto<long>
    {
        public string TimeSheetTypeName { get; set; }
    }
}
