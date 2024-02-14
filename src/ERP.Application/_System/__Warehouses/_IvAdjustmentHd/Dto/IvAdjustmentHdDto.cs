using Abp.AutoMapper;
using ERP._System.__Warehouses.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvAdjustmentHd.Dto
{
    [AutoMap(typeof(IvAdjustmentHd))]
    public class IvAdjustmentHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string AdjustmentNumber { get; set; }

        public string AdjustmentDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long? AdjustmentTypeLkpId { get; set; }

        public long? IvWarehouseId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public FndLookupValuesDto FndLookupValuesAdjustmentTypeLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesStatusLkpIvAdjustmentHd { get; set; }

        public IvWarehousesDto IvWarehouses { get; set; }

        public virtual ICollection<IvAdjustmentTrDto> AdjustmentTr { get; set; }
    }
}
