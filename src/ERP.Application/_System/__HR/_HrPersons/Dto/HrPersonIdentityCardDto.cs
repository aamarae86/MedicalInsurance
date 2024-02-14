using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersons._HrPersonIdentityCard;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersons.Dto
{
    [AutoMap(typeof(HrPersonIdentityCard))]
    public class HrPersonIdentityCardDto : EntityDto<long>, IDetailRowStatus
    {
        [MaxLength(3)]
        public string Segment1 { get; set; }

        [MaxLength(4)]
        public string Segment2 { get; set; }

        [MaxLength(7)]
        public string Segment3 { get; set; }

        [MaxLength(1)]
        public string Segment4 { get; set; }

        [MaxLength(50)]
        public string IdNumber { get; set; }

        [MaxLength(50)]
        public string CardNo { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string DateOfExpiry { get; set; }

        public long HrPersonId { get; set; }

        public string rowStatus { get; set; }
    }
}
