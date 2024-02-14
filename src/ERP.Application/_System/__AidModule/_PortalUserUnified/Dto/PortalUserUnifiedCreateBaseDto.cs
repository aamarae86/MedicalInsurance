using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._PortalUserUnified.Dto
{
    public class PortalUserUnifiedCreateBaseDto
    {
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string Region { get; set; }

        [Required]
        [MaxLength(50)]
        public string MobileNumber1 { get; set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; set; }

        public string BirthDate { get; set; }

        public string IdExpirationDate { get; set; }

        public string PassportExpiryDate { get; set; }

        public string PassportIssueDate { get; set; }

        public string ResidenceEndDate { get; set; }

        [MaxLength(100)]
        public string PassportNumber { get; set; }

        [MaxLength(100)]
        public string UnifiedNumber { get; set; }

        [MaxLength(200)]
        public string Job { get; set; }

        [MaxLength(200)]
        public string JobDescription { get; set; }

        [MaxLength(4000)]
        public string Address { get; set; }

        public long MaritalStatusLkpId { get; set; }

        public long GenderLkpId { get; set; }

        public long CityLkpId { get; set; }

        public long? CaseCategoryLkpId { get; set; }

        public long? QualificationLkpId { get; set; }

    }
}
