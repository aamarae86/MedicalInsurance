using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._PyElements;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._PyElements.Dto
{
    [AutoMap(typeof(PyElements))]
    public class PyElementsDto : AuditedEntityDto<long>, IEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public int ElementSerial { get; set; }

        [MaxLength(200)]
        public string ElementName { get; set; }

        public long ElementTypeLkpId { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        public long? DebitAccountId { get; set; }

        public GlCodeComDetailsDto CrGlCodeComDetailsDebitAccount { get; set; }

        public FndLookupValuesDto FndLookupValuesElementTypeLkp { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

    }
}
