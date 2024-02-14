using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._AffliateAccount.Dto
{
    [AutoMap(typeof(AffliateAccount))]
    public class AffliateAccountDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Tel { get; set; }

        [MaxLength(200)]
        public string Mobile { get; set; }

        [MaxLength(200)]
        public string BankAccountNo { get; set; }

        [MaxLength(200)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Region { get; set; }

        public long? BankLkpId { get; set; }

        public long? CountryLkpId { get; set; }

        public long? LanguageLkpId { get; set; }
    }
}
