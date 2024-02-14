using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SpGuarantees._SpFamilies.Dto
{
    [AutoMap(typeof(SpFamilies))]
    public class SpFamiliesCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string FamilyName { get; set; }

        [MaxLength(30)]
        public string FamilyNumber { get; set; }

        public string RegistrationDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string GuardianName { get; set; }

        public string BirthDate { get; set; }

        [MaxLength(200)]
        public string PlaceOfBirth { get; set; }

        [MaxLength(50)]
        public string IdNumber { get; set; }

        public string IdExpirationDate { get; set; }

        [MaxLength(200)]
        public string JobDescription { get; set; }

        [MaxLength(200)]
        public string Job { get; set; }

        public bool IsFatherDied { get; set; }

        public bool IsMotherDied { get; set; }

        public bool IsHasHouse { get; set; }

        public string FatherDiedDate { get; set; }

        public string MotherDiedDate { get; set; }

        [MaxLength(200)]
        public string FatherDiedReason { get; set; }

        [MaxLength(200)]
        public string MotherDiedReason { get; set; }

        [MaxLength(200)]
        public string Region { get; set; }

        [MaxLength(4000)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string MobileNumber1 { get; set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; set; }

        [MaxLength(50)]
        public string AccountNumber { get; set; }

        [MaxLength(50)]
        public string AccountOwner { get; set; }

        public long? BankLkpId { get; set; }

        public long? MaritalStatusLkpId { get; set; }

        public long? RelativesTypeLkpId { get; set; }

        public long? NationalityLkpId { get; set; }

        public long? HousingTypeLkpId { get; set; }

        public long? HousingStatusLkpId { get; set; }

        public long? CityLkpId { get; set; }

        public FndLookupValuesDto FndBankLkp { get; set; }

        public FndLookupValuesDto FndMaritalStatusLkp { get; set; }

        public FndLookupValuesDto FndRelativesTypeLkp { get; set; }

        public FndLookupValuesDto FndNationalityLkp { get; set; }

        public FndLookupValuesDto FndHousingTypeLkp { get; set; }

        public FndLookupValuesDto FndHousingStatusLkp { get; set; }

        public FndLookupValuesDto FndCityLkp { get; set; }

        public ICollection<SpFamilyCasesDto> FamilyCases { get; set; }

        public ICollection<SpFamilyDutiesDto> FamilyDuties { get; set; }

        public ICollection<SpFamilyIncomesDto> FamilyIncomes { get; set; }
    }
}
