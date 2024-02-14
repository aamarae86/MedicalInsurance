using Abp.AutoMapper;
using ERP._System.__AccountModule._TmCharityBoxesType.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive.Dto
{
    [AutoMap(typeof(TmCharityBoxReceive))]
    public class TmCharityBoxReceiveDto : PostAuditedEntityDto<long>
    {
        [Required]
        public string ReceiveDate { get; set; }

        public string ReceiveNumber { get; set; }

        [Required]
        public long StatusLkpId { get; set; }
        public FndLookupValuesDto FndLookupValues { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string SupplierName { get; set; }

        [Required]
        public long CharityTypeId { get; set; }
        public TmCharityBoxesTypeDto CharityBoxesType { get; protected set; }

        [Required]
        public long NoOfCharityBox { get; set; }

        [Required]
        public decimal AmountCharityBox { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }
    }
}
