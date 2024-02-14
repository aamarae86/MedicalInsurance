using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersonsAdditionHd._HrPersonsAdditionTr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__HR._HrPersonsAdditionHd.Dto
{
    [AutoMap(typeof(HrPersonsAdditionTr))]
    public class HrPersonsAdditionTrDto : EntityDto<long>
    {
        public long? HrPersonAdditionHdId { get;  set; }
        public long? HrPersonId { get;  set; }
        public string HrPersonName { get;  set; }
        public string HrPersonNumber { get;  set; }
        public long? AdditionTypeLkpId { get;  set; }
        public string AdditionTypeLkpName { get;  set; }
        public decimal? Amount { get;  set; }
        [MaxLength(4000)]
        public string Notes { get;  set; }
        public string rowStatus { get; set; }
    }
}
