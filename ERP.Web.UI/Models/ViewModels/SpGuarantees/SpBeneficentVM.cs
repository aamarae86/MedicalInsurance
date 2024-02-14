using ERP._System.__SpGuarantees._SpBeneficent.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.SpGuarantees;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpBeneficentVM : BaseAuditedEntityVM<long>, IAttachmentListJSONString
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(SpBeneficent.BeneficentNumber), ResourceType = typeof(SpBeneficent))]
        public string Search_BeneficentNumber { get; set; }

        [Display(Name = nameof(SpBeneficent.CityLkpId), ResourceType = typeof(SpBeneficent))]
        public long? Search_CityLkpId { get; set; }

        [Display(Name = nameof(SpBeneficent.Search_Name), ResourceType = typeof(SpBeneficent))]
        public string Search_BeneficentName { get; set; }

        [Display(Name = nameof(SpBeneficent.Search_MobileNumber), ResourceType = typeof(SpBeneficent))]
        public string Search_MobileNumber { get; set; }

        [Display(Name = nameof(SpBeneficent.BeneficentNumber), ResourceType = typeof(SpBeneficent))]
        public string BeneficentNumber { get; set; }

        [Display(Name = nameof(SpBeneficent.CityLkpId), ResourceType = typeof(SpBeneficent))]
        public long? CityLkpId { get; set; }

        public FndLookupValuesVM FndLookupCityValues { get; set; }

        [Display(Name = nameof(SpBeneficent.BeneficentName), ResourceType = typeof(SpBeneficent))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string BeneficentName { get; set; }


        [Display(Name = nameof(SpBeneficent.FirstTitle), ResourceType = typeof(SpBeneficent))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long FirstTitleLkpId { get; set; }

        [Display(Name = nameof(SpBeneficent.Gender), ResourceType = typeof(SpBeneficent))]
        public long? GenderLkpId { get; set; }

        [Display(Name = nameof(SpBeneficent.Nationality), ResourceType = typeof(SpBeneficent))]
        public long? NationalityLkpId { get; set; }

        [Display(Name = nameof(SpBeneficent.MobileNumber1), ResourceType = typeof(SpBeneficent))]
        [MaxLength(50)]
        public string MobileNumber1 { get; set; }

        [Display(Name = nameof(SpBeneficent.MobileNumber2), ResourceType = typeof(SpBeneficent))]
        [MaxLength(50)]
        public string MobileNumber2 { get; set; }

        [Display(Name = nameof(SpBeneficent.LastTitle), ResourceType = typeof(SpBeneficent))]
        public long? LastTitleLkpId { get; set; }

        [Display(Name = nameof(SpBeneficent.Fax), ResourceType = typeof(SpBeneficent))]
        [MaxLength(32)]
        public string Fax { get; set; }

        [Display(Name = nameof(SpBeneficent.EmailAddress), ResourceType = typeof(SpBeneficent))]
        [MaxLength(256)]
        public string EmailAddress { get; set; }

        [Display(Name = nameof(SpBeneficent.PoBox), ResourceType = typeof(SpBeneficent))]
        [MaxLength(100)]
        public string PoBox { get; set; }

        [Display(Name = nameof(SpBeneficent.JobDescription), ResourceType = typeof(SpBeneficent))]
        [MaxLength(200)]
        public string JobDescription { get; set; }

        [Display(Name = nameof(SpBeneficent.Job), ResourceType = typeof(SpBeneficent))]
        [MaxLength(200)]
        public string Job { get; set; }

        [Display(Name = nameof(SpBeneficent.Address), ResourceType = typeof(SpBeneficent))]
        [MaxLength(4000)]
        public string Address { get; set; }

        public FndLookupValuesVM FndLookupFirstTitleValues { get; set; }

        public FndLookupValuesVM FndLookupGenderValues { get; set; }

        public FndLookupValuesVM FndLookupNationalityValues { get; set; }

        public FndLookupValuesVM FndLookupLastTitleValues { get; set; }

        public string ListSpBeneficentBank { get; set; }

        public ICollection<SpBeneficentAttachmentsDto> ListOfAttachments => string.IsNullOrEmpty(AttachmentsListStr) ?
                 new List<SpBeneficentAttachmentsDto>() : Helper<List<SpBeneficentAttachmentsDto>>.Convert(AttachmentsListStr);

        public virtual ICollection<SpBeneficentBanksCreateDto> ListOfBanks { get; set; }

        public virtual ICollection<SpBeneficentBankEditDto> ListOfEditBanks { get; set; }

        public string AttachmentsListStr { get; set; }

        #region Banks
        [Display(Name = nameof(SpBeneficent.BankLkpId), ResourceType = typeof(SpBeneficent))]
        public long Bank_LkpId { get; set; }

        [Display(Name = nameof(SpBeneficent.AccountNumber), ResourceType = typeof(SpBeneficent))]
        [MaxLength(50)]
        public string Bank_AccountNumber { get; set; }

        [Display(Name = nameof(SpBeneficent.AccountOwnerName), ResourceType = typeof(SpBeneficent))]
        [MaxLength(200)]
        public string Bank_AccountOwnerName { get; set; }

        [Display(Name = nameof(SpBeneficent.IsDefault), ResourceType = typeof(SpBeneficent))]
        public bool Bank_IsDefault { get; set; }
        public bool IsDefaultAlt { get; set; }

        public FndLookupValuesVM Bank_LookupBankValues { get; set; }
        #endregion

        #region Attachments
        [Display(Name = nameof(SpBeneficent.AttachmentName), ResourceType = typeof(SpBeneficent))]
        [MaxLength(200)]
        public string Attachment_Name { get; set; }

        [Display(Name = nameof(SpBeneficent.FilePath), ResourceType = typeof(SpBeneficent))]
        [MaxLength(1000)]
        public string Attachment_FilePath { get; set; }
        #endregion
    }
}