using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._FmContracts.Dto
{
    [AutoMap(typeof(FmContractVisits))]

    public class FmContractVisitsDto : EntityDto<long>, IDetailRowStatus
    {
        public long ContractId { get; set; }
        public string contractText { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string VisitNumber { get; set; }
        
        public string VisitDate { get; set; }

        public long EngineerId { get; set; }
        public string engineerName { get; set; }



        [Column(TypeName = "nvarchar(4000)")]
        public string Comments { get; set; }
        public string rowStatus { get; set; }



    }
}
