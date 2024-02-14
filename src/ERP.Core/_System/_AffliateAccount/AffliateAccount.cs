using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._AffliateAccount
{
    public class AffliateAccount : AuditedEntity<long>
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
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

        [ForeignKey(nameof(LanguageLkpId)) , Column(Order = 0)]
        public FndLookupValues FndLanguageLkp { get; set; }

        [ForeignKey(nameof(CountryLkpId)), Column(Order = 1)]
        public FndLookupValues FndCountryLkp { get; set; }

        [ForeignKey(nameof(BankLkpId)), Column(Order = 2)]
        public FndLookupValues FndBankLkp { get; set; }
    }
}
