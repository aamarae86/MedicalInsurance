using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonTimeSheet.Dto
{
    [AutoMap(typeof(HrPersonTimeSheet))]
    public  class HrPersonTimeSheetEditDto : EntityDto<long>
    {
        
        public string ProjectName { get; set; }
        public long HrPersonId { get; set; }
        public long TimeSheetTypeId { get; set; }
        public string TimeSheetDate { get; set; }
        public decimal FromTime { get; set; }
        public decimal EndTime { get; set; }
        public string Notes { get; set; }
    }
}
