using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonsAdditionHd.Dto
{
    [AutoMap(typeof(HrPersonsAdditionHd))]
    public class HrPersonsAdditionHdEditDto : EntityDto<long>
    {
        [MaxLength(200)]
        public string AdditionName { get; set; }

        public long? PeriodId { get; set; }

        public virtual ICollection<HrPersonsAdditionTrDto> PersonsAdditionTr { get; set; }
    }
}
