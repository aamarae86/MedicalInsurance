using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonsDeduction.Dto
{
    [AutoMap(typeof(HrPersonsDeductionTr))]
    public class HrPersonsDeductionTrDto : EntityDto<long>, IDetailRowStatus
    {
        public long HrPersonDeductionHdId { get; set; }

        public long HrPersonId { get; set; }

        public long DeductionTypeLkpId { get; set; }

        public decimal Amount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string PersonName { get; set; }

        public string DeductionTypeLkpNameAr { get; set; }

        public string DeductionTypeLkpNameEn { get; set; }

        public string rowStatus { get; set; }
    }
}
