using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._PortalUserData;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._Portal
{
    public class PortalUserRelatives : AuditedEntity<long>
    {
        [MaxLength(200)]
        public string Name { get; protected set; }

        [MaxLength(200)]
        public string Employer { get; protected set; }

        public long GenderLkpId { get; protected set; }

        public long? RelativesTypeLkpId { get; protected set; }

        [MaxLength(50)]
        public string IdNumber { get; protected set; }

        public long? NationalityLkpId { get; protected set; }

        public long? QualificationLkpId { get; protected set; }

        public long? MaritalStatusLkpId { get; protected set; }

        public long PortalUserDataId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(PortalUserDataId))]
        public PortalUserData PortalUserData { get; protected set; }

        [ForeignKey(nameof(GenderLkpId)), Column(Order = 0)]
        public FndLookupValues GenderFndLookupValues { get; protected set; }

        [ForeignKey(nameof(RelativesTypeLkpId)), Column(Order = 1)]
        public FndLookupValues RelativesFndLookupValues { get; protected set; }

        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 2)]
        public FndLookupValues NationalityFndLookupValues { get; protected set; }

        [ForeignKey(nameof(QualificationLkpId)), Column(Order = 3)]
        public FndLookupValues QualificationFndLookupValues { get; protected set; }

        [ForeignKey(nameof(MaritalStatusLkpId)), Column(Order = 4)]
        public FndLookupValues MaritalStatusFndLookupValues { get; protected set; }
    }
}
