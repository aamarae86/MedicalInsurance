using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmOwners.Dto
{
    [AutoMap(typeof(PmOwnersTaxDetails))]
    public class PmOwnersTaxDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long PmOwnerId { get; set; }
     //   public PmOwnersDto PmOwner { get; set; }

        public long PmActivityTypeLkpId { get; set; }
        public FndLookupValuesDto FndPmActivityTypeLkp { get; set; }

        [Range(0, 100)]
        public decimal TaxPercentage { get; set; }

        public string rowStatus { get; set; }
    }
}
