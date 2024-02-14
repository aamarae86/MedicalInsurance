using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmContractUnitDetails.Dto
{
    [AutoMap(typeof(PmContractUnitDetails))]
    public class PmContractUnitDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long PropertiesUnitId { get; set; }

        public string PropertiesUnit { get; set; }

        public decimal Amount { get; set; }

        public decimal? AreaSize { get; set; }

        public long PmContractId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string rowStatus { get; set; }
    }
}
