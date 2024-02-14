using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using ERP._System.__PmPropertiesModule._FmContracts.Dto;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.TenantFreeModulesInput.Dto
{ 
    public class TenantFreeModulesInputDto : EntityDto<long>
    {
        public int ModuleId { get; set; }
        public int TenentId { get; set; }
        public string lastStatus { get; set; }
        public string Status { get; set; }
    }

  


}
