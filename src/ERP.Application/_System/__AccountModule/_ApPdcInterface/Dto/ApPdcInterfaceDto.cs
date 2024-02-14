using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ApPdcInterface.Dto
{
    [AutoMapFrom(typeof(ApPdcInterface))]
    public class ApPdcInterfaceDto : PostAuditedEntityDto<long>
    {
        public string encApMiscPaymenId
        {
            get
            {
                if (this.SourceCodeLkpId != null && this.SourceCodeLkpId == 43 && this.SourceId != null)
                {
                    return CipherStringController.Encrypt(this.SourceId.ToString());
                }

                return string.Empty;
            }
        }

        public long? SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        public long? StatusLkpId { get; set; }

        [MaxLength(30)]
        public string SourceNumber { get; set; }

        public decimal? Amount { get; set; }

        [MaxLength(30)]
        public string CheckNumber { get; set; }

        public string MaturityDate { get; set; }

        public long? BankAccountId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string ConfirmedDate { get; set; }

        public string ReversedDate { get; set; }

        public long? VendorId { get; set; }

        public long? ChqReturnResonLKPId { get; set; }

        public FndLookupValuesDto FndLookupValuesSourceCodeLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesStatusLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesChqReturnResonLKP { get; set; }

        public ApBankAccountsDto ApBankAccounts { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}
