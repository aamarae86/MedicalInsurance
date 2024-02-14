using Abp.Domain.Entities;
using ERP._System.__HR._HrPersons;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument
{
  public  class HrPersonRequestDocument : PostAuditedEntity<long>, IMustHaveTenant
    {
        public string RequestNumber { get; protected set; }
        public long RequestTypeId { get; protected set; }
        public long HrPersonId { get; protected set; }
        public long StatusLkpId { get; protected set; }
        public DateTime DocRequestDate { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }
        [ForeignKey(nameof(RequestTypeId))]
        public DocumentRequestType DocumentRequestType { get; protected set; }
        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }
        [ForeignKey(nameof(StatusLkpId))]

        public FndLookupValues FndStatusLkp { get; protected set; }
        public int TenantId { get; set; }
    }
}
