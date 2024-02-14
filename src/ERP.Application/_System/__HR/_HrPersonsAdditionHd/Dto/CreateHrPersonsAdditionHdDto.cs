using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__HR._HrPersonsAdditionHd.Dto
{
    [AutoMap(typeof(HrPersonsAdditionHd))]
    public class CreateHrPersonsAdditionHdDto
    {
        public string AdditionNumber { get; set; }
        [MaxLength(200)]
        public string AdditionName { get; set; }
        public long? PeriodId { get; set; }
        public long? StatusLkpId { get; set; }

        public virtual ICollection<HrPersonsAdditionTrDto> PersonsAdditionTr { get; set; }
    }
}
