using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._ApDrCrHd.Dto;
using ERP._System._ArDrCrHd.Dto;
using ERP._System._FndTaxType;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__AccountModule._ApDrCrTr.Dto
{

    [AutoMap(typeof(ApDrCrTr))]
    public class ApDrCrTrDto : CodeComUtility, IDetailRowStatus
    {
        public int index { get; set; }
        public long? AccountId { get; set; }
        public long? Id { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Tax { get; set; }
        public long? ApDrCrHdId { get; set; }
        public long? FndTaxtypeId { get; set; }
        public FndTaxTypeDto FndTaxType { get; set; }
        public string rowStatus { get; set; }
        public GlCodeComDetailsDto GlCodeComDetails { get; set; }

        public ApDrCrHdDto ApDrCrHd { get; set; }
    }

}
