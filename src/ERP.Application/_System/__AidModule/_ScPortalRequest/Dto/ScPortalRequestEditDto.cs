using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequestVisited.Dto;
using ERP.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    [AutoMap(typeof(ScPortalRequest))]
    public class ScPortalRequestEditDto : EntityDto<long> // Edit is only allowed when the status is new
    {
        public long? ResearcherId { get; set; }

        public int TenantId { get; set; }

        #region MainProperties
        #region ERP Edits Only
        public long PortalUsersId { get; set; }

        public string PortalRequestDate { get; set; }
        #endregion

        [MaxLength(4000)]
        public string IncomeSource { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MonthlyIncomeAmount { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MonthlyOutcomeAmount { get; set; }

        public long SourceLkpId { get; set; } // static value from the frontend (ERP - PORTAL) // enum value

        public long StatusLkpId { get; set; } // to use a static value which is new status

        [MaxLength(4000)]
        public string Description { get; set; }
        #endregion

        public ICollection<ScPortalRequestAttachmentCreateDto> RequestAttachments { get; set; }

        public ICollection<ScPortalRequestVisitedDto> RequestVisits { get; set; }

        public ICollection<ScPortalRequestDutiesDto> RequestDuties { get; set; }

        public ICollection<ScPortalRequestIncomeDto> RequestIncomes { get; set; }
    }
}
