using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AutoMapper;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectDetails;
using ERP._System.__CharityBoxes._TmCharityBoxes;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs._TmDamagedCharityBoxDetails;
using ERP._System.__CharityBoxes._TmLocations;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails
{
    public class TmCharityBoxActionDetails : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public long ActionLkpId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long TmLocationSubId { get; protected set; }

        public long? OldCharityBoxid { get; protected set; }

        public long? NewCharityBoxId { get; protected set; }

        public long CharityBoxActionId { get; protected set; }

        [ForeignKey(nameof(OldCharityBoxid)), Column(Order = 0)]
        public TmCharityBoxes OldTmCharityBoxes { get; protected set; }

        [ForeignKey(nameof(NewCharityBoxId)), Column(Order = 1)]
        public TmCharityBoxes NewTmCharityBoxes { get; protected set; }

        [ForeignKey(nameof(ActionLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesActionLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        [ForeignKey(nameof(CharityBoxActionId))]
        public TmCharityBoxActions TmCharityBoxActions { get; protected set; }

        [ForeignKey(nameof(TmLocationSubId))]
        public TmLocationSub TmLocationSub { get; protected set; }

        public virtual ICollection<TmCharityBoxCollectDetails> TmCharityBoxCollectDetails { get; protected set; }
        public virtual ICollection<TmDamagedCharityBoxDetails> TmDamagedCharityBoxDetails { get; protected set; }
        
        public int TenantId { get; set; }
    }
}
