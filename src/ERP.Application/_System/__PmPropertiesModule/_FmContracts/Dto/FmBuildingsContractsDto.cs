using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._PmProperties.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._FmContracts.Dto
{
    [AutoMap(typeof(FmBuildingsContracts))]
   public class FmBuildingsContractsDto : EntityDto<long>, IDetailRowStatus
    {
        public long ContractId { get; set; }
        public string contractText { get; set; }

        public decimal Amount { get; set; }
        public long PmPropertiesId { get; set; }
        public string pmPropertiesName { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string PmPropertiesValue { get; set; }

        public string Comments { get; set; }
        public string rowStatus { get; set ; }



    }
}
