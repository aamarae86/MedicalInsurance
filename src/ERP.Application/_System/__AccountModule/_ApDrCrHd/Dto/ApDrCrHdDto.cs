using Abp.AutoMapper;
using ERP._System.__AccountModule._ApDrCrTr.Dto;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System._ArCustomers;
using ERP._System._ArCustomers.Dto;
using ERP._System._ArDrCrTr.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ApDrCrHd.Dto
{
    [AutoMap(typeof(ApDrCrHd))]
    public class ApDrCrHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string HdDrCrNumber { get; set; }

        public string HdDate { get; set; }

        public long? HdTypeLkpId { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public long? StatusLkpId { get; set; }

        public int CurrencyId { get; set; }

        public decimal? CurrencyRate { get; set; }

        public long? VendorId { get; set; }

        public long? SourceLkpId { get; set; }

        public long? SourceId { get; set; }

        [MaxLength(30)]
        public string SourceNo { get; set; }

        public FndLookupValuesDto FndLookupValuesHdTypeLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesStatusLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesSourceLkp { get; set; }

        public CurrencyDto Currency { get; set; }

        public ApVendorsDto Vendors { get; set; }

        public virtual ICollection<ApDrCrTrDto> ApDrCrTr { get; set; }

        public List<ApDrCrTrDto> ApDrCrTrList { get; set; }
    }
}
