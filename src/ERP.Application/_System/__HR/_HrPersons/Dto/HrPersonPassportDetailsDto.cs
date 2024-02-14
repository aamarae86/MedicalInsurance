using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersons._HrPersonPassportDetails;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersons.Dto
{
    [AutoMap(typeof(HrPersonPassportDetails))]
    public class HrPersonPassportDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        [MaxLength(100)]
        public string PassportNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string PlaceOfIssue { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string DateOfIssue { get; set; }

        public string DateOfExpiry { get; set; }

        public long HrPersonId { get; set; }

        public long PassportTypeLkpId { get; set; }

        public long CountryOfIssueLkpId { get; set; }

        public string PassportTypeLkp { get; set; }

        public string CountryOfIssueLkp { get; set; }

        public string rowStatus { get; set; }
    }
}
