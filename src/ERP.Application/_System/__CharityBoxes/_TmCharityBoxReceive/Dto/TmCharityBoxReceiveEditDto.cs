using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive.Dto
{
    [AutoMap(typeof(TmCharityBoxReceive))]
    public class TmCharityBoxReceiveEditDto : EntityDto<long>
    {
        [Required]
        public string ReceiveDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string SupplierName { get; set; }

        [Required]
        public long CharityTypeId { get; set; }

        [Required]
        public long NoOfCharityBox { get; set; }

        [Required]
        public decimal AmountCharityBox { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }
    }
}
