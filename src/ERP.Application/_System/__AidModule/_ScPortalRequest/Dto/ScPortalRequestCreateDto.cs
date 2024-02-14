using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequestVisited.Dto;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    [AutoMapTo(typeof(ScPortalRequest))]
    public class ScPortalRequestCreateDto : EntityDto<long>
    {
        public long? ResearcherId { get; set; }

        public int TenantId { get; set; }

        #region MainProperties
        public long? PortalUsersId { get; set; }

        public string PortalRequestNumber { get; set; }

        public string PortalRequestDate { get; set; }

        public string IdExpirationDate { get; set; }

        public long AidRequestTypeId { get; set; }

        [MaxLength(4000)]
        public string IncomeSource { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MonthlyIncomeAmount { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MonthlyOutcomeAmount { get; set; }

        public long SourceLkpId => Convert.ToInt64(FndEnum.FndLkps.Manual_ScPortalRequestSource);

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequest);

        [MaxLength(4000)]
        public string Description { get; set; }
        #endregion

        public ICollection<ScPortalRequestAttachmentCreateDto> RequestAttachments { get; set; }

        public ICollection<ScPortalRequestVisitedDto> RequestVisits { get; set; }

        public ICollection<ScPortalRequestDutiesDto> RequestDuties { get; set; }

        public ICollection<ScPortalRequestIncomeDto> RequestIncomes { get; set; }
    }
}
