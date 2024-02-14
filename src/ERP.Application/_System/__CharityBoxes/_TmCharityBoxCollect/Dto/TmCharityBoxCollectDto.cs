using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto
{
    [AutoMap(typeof(TmCharityBoxCollect))]
    public class TmCharityBoxCollectDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string CollectDate { get; set; }

        [MaxLength(30)]
        public string CollectNumber { get; set; }

        public string Notes { get; set; }

        #region Coins Category
        public long? Value25F { get; set; }

        public long? Value50F { get; set; }

        public long? Value1Dh { get; set; }

        public long? Value5Dh { get; set; }

        public long? Value10Dh { get; set; }

        public long? Value20Dh { get; set; }

        public long? Value50Dh { get; set; }

        public long? Value100Dh { get; set; }

        public long? Value200Dh { get; set; }

        public long? Value500Dh { get; set; }

        public long? Value1000Dh { get; set; }
        #endregion

        public long StatusLkpId { get; set; }

        public long BankAccountId { get; set; }

        public FndLookupValuesDto FndStatusLookup { get; set; }

        public ApBankAccountsDto ApBankAccounts { get; set; }

        public ICollection<TmCharityBoxCollectMembersDetailDto> CharityBoxCollectMembers { get; set; }

        public ICollection<TmCharityBoxCollectDetailsDto> CharityBoxCollectDetails { get; set; }
    }
}
