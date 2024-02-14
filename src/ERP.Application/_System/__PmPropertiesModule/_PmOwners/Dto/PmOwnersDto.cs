using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System.Collections.Generic;

namespace ERP._System.__PmPropertiesModule._PmOwners.Dto
{
    [AutoMap(typeof(PmOwners))]
    public class PmOwnersDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string OwnerNumber { get; set; }

        public string OwnerNameAr { get; set; }

        public string OwnerNameEn { get; set; }

        public long StatusLkpId { get; set; }
        public FndLookupValuesDto FndStatusLkp { get; set; }

        public string IdNumber { get; set; }

        public string TaxNumber { get; set; }

        public long NationalityLkpId { get; set; }

        public FndLookupValuesDto FndNationalityLkp { get; set; }

        public long CountryLkpId { get; set; }

        public FndLookupValuesDto FndCountryLkp { get; set; }

        public long CityLkpId { get; set; }
        public FndLookupValuesDto FndCityLkp { get; set; }

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

        public long AccountId { get; set; }
        public GlCodeComDetailsDto GlCodeComAccount { get; set; }

        public long CurrentAccountId { get; set; }
        public GlCodeComDetailsDto GlCodeComCurrentAccount { get; set; }

        public long BankAccountId { get; set; }
        public ApBankAccountsDto GlCodeComBankAccount { get; set; }

        public long CashAccountId { get; set; }
        public ApBankAccountsDto GlCodeComCashAccount { get; set; }

        public bool IsMainOwner { get; set; }


        public ICollection<PmOwnersTaxDetailsDto> PmOwnersTaxDetails { get; set; }
        public ICollection<PmOwnersTaxDetailsDto> PmOwnersTaxesDetails { get; set; }

        #region CodeComs
        public CodeComUtility Account { get; set; }

        public CodeComUtility CurrentAccount { get; set; }

        public ApBankAccountsDto BankAccount { get; set; }

        public ApBankAccountsDto CashAccount { get; set; }
        #endregion

    }
}
