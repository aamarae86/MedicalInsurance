using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive.Dto
{
    [AutoMap(typeof(TmCharityBoxReceive))]
    public class CreateTmCharityBoxReceiveDto
    {
        [Required]
        public string ReceiveDate { get; set; }

        public string ReceiveNumber { get; set; }

        [Required]
        public long StatusLkpId => 606;

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
