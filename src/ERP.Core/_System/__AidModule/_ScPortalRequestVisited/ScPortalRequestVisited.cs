using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequestVisited
{
    public class ScPortalRequestVisited : AuditedEntity<long>, IMustHaveTenant
    {
        public long PortalRequestId { get; protected set; }

        public DateTime VisitDate { get; protected set; }

        public long VisitStatusLkpId { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string MobileNumber { get; protected set; }


        [ForeignKey(nameof(VisitStatusLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        [ForeignKey(nameof(PortalRequestId))]
        public ScPortalRequest ScPortalRequests { get; protected set; }

        public int TenantId { get ; set ; }
    }
}
