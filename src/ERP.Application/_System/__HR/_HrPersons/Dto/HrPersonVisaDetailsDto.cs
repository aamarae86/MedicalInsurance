using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersons._HrPersonVisaDetails;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersons.Dto
{
    [AutoMap(typeof(HrPersonVisaDetails))]
    public class HrPersonVisaDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public string VisaNumber { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public decimal? VisaCost { get; set; }

        public string DateOfIssue { get; set; }

        public string DateOfExpiry { get; set; }

        public long HrPersonId { get; set; }

        public long VisaTypeLkpId { get; set; }

        public string VisaTypeLkp { get; set; }

        public long? PlaceOfIssueLkpId { get; set; }

        public string PlaceOfIssueLkp { get; set; }

        public long? IssuedByLkpId { get; set; }

        public string IssuedByLkp { get; set; }

        public string rowStatus { get; set; }
    }
}
