using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._FndUsers;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._FndUserRelatives
{
    public class FndUserRelatives : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [Required]
        [MaxLength(200)]
        public string Name { get; protected set; }

        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        public string IdNumber { get; protected set; }

        public long FndUsersId { get; protected set; }

        public long GenderLkpId { get; protected set; }

        public long RelativesTypeLkpId { get; protected set; }

        public long? NationalityLkpId { get; protected set; }

        public long? QualificationLkpId { get; protected set; }

        public int TenantId { get; set; }


        [ForeignKey(nameof(GenderLkpId)), Column(Order = 0)]
        public FndLookupValues GenderFndLookupValues { get; protected set; }


        [ForeignKey(nameof(RelativesTypeLkpId)), Column(Order = 1)]
        public FndLookupValues RelativesFndLookupValues { get; protected set; }


        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 2)]
        public FndLookupValues NationalityFndLookupValues { get; protected set; }


        [ForeignKey(nameof(QualificationLkpId)), Column(Order = 3)]
        public FndLookupValues QualificationFndLookupValues { get; protected set; }


        [ForeignKey(nameof(FndUsersId))]
        public FndUsers FndUsers { get; protected set; }

        #endregion

        protected FndUserRelatives()
        {}

        protected FndUserRelatives(string name, string idNumber,
            long fndUsersId, long genderLkpId, long relativesTypeLkpId, long? nationalityLkpId, long? qualificationLkpId)
        {
            this.Name = name;
            this.IdNumber = idNumber;
            this.FndUsersId = fndUsersId;
            this.GenderLkpId = genderLkpId;
            this.NationalityLkpId = nationalityLkpId;
            this.QualificationLkpId = qualificationLkpId;
            this.RelativesTypeLkpId = relativesTypeLkpId;
        }

        public static FndUserRelatives Create(string name, string idNumber,
            long fndUsersId, long genderLkpId, long relativesTypeLkpId, long? nationalityLkpId, long? qualificationLkpId)
        {
            return new FndUserRelatives(name, idNumber,
             fndUsersId, genderLkpId, relativesTypeLkpId, nationalityLkpId, qualificationLkpId);
        }
    }
}
