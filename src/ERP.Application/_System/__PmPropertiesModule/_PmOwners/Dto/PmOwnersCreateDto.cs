using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP.Helpers.Parameters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmOwners.Dto
{
    [AutoMap(typeof(PmOwners))]
    public class PmOwnersCreateDto
    {
        //[Required]
        public string OwnerNumber { get; set; }

        [Required]
        public string OwnerNameAr { get; set; }

        [Required]
        public string OwnerNameEn { get; set; }

        public long StatusLkpId { get; set; }

        public string IdNumber { get; set; }

        //[Required]
        public string TaxNumber { get; set; }

        public long NationalityLkpId { get; set; }

        public long CountryLkpId { get; set; }

        public long CityLkpId { get; set; }

        public string Address { get; set; }

        public string HomePhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string WorkPhoneNumber { get; set; }

        public string Fax { get; set; }

        public string Website { get; set; }

        public string EmailAddress { get; set; }

        public string JobName { get; set; }

        public string CompanyName { get; set; }

        public string PoBox { get; set; }

        public string OtherAddress { get; set; }

        public string Notes { get; set; }

        [Required]
        public long AccountId { get; set; }

        public CodeComUtility Account { get; set; }

        [Required]
        public long? CurrentAccountId { get; set; }

        public CodeComUtility CurrentAccount { get; set; }

        [Required]
        public long? BankAccountId { get; set; }

        public ApBankAccountsDto BankAccount { get; set; }

        [Required]
        public long? CashAccountId { get; set; }

        public ApBankAccountsDto CashAccount { get; set; }

        public bool IsMainOwner { get; set; }


        public ICollection<PmOwnersTaxDetailsDto> PmOwnersTaxDetails { get; set; }

        public ICollection<PmOwnersTaxDetailsDto> POTaxDetailsList { get; set; }
    }
}
