using Abp.Domain.Entities;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScCampains
{
    public class ScCampains : PostAuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [Required]
        [MaxLength(200)]
        public string CampainName { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string CampainNumber { get; protected set; }

        public DateTime ScCampainDate { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        public virtual ICollection<ScCampainsDetail> ScCampainsDetails { get; set; }

        public int TenantId { get; set; }
        #endregion

        public void SetStatusLkpId(long statusLkpId) => this.StatusLkpId = statusLkpId;

        public void SetCampainNumber(string campainNumber) => this.CampainNumber = campainNumber;

    }
}
