using Abp.AutoMapper;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System.__HR._TimeSheetType.Dto;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonTimeSheet.Dto
{
    [AutoMap(typeof(HrPersonTimeSheet))]
    public  class HrPersonTimeSheetDto : PostAuditedEntityDto<long>
    {
        public string TimeSheetNumber { get;  set; }
        public string ProjectName { get;  set; }
        public long HrPersonId { get;  set; }
        public long TimeSheetTypeId { get;  set; }
        public string TimeSheetDate { get;  set; }
        public decimal FromTime { get;  set; }
        public decimal EndTime { get;  set; }
        public string Notes { get;  set; }
        public HrPersonsDto HrPersons { get;  set; }
        public TimeSheetTypeDto TimeSheetType { get; set; }
    }
}
