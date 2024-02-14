using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Currencies.Dto
{
    public class CurrencyRateDto
    {
        [Required]
        public int Id { get; set; }

        public DateTime? date { get; set; }
    }
}
