using ERP._System.__AidModule._PortalUserData;
using ERP._System.__AidModule._PortalUserUnified;
using ERP._System._FndLookupValues;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Authorization.Users
{
    public class PortalUser : PortalUserUnifiedBase
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string IdNumber { get; protected set; }

        [MaxLength(30)]
        public string CaseNumber { get; protected set; }

        [MaxLength(200)]
        public string WifeHusbandName1 { get; protected set; }

        [MaxLength(50)]
        public string IdNumberWifeHusband1 { get; protected set; }

        [MaxLength(200)]
        public string JobWifeHusband1 { get; protected set; }

        [MaxLength(200)]
        public string WifeName2 { get; protected set; }

        [MaxLength(50)]
        public string IdNumberWife2 { get; protected set; }

        [MaxLength(200)]
        public string WifeName3 { get; protected set; }

        [MaxLength(50)]
        public string IdNumberWife3 { get; protected set; }

        [MaxLength(200)]
        public string WifeName4 { get; protected set; }

        [MaxLength(50)]
        public string IdNumberWife4 { get; protected set; }

        [MaxLength(200)]
        public string JobWife2 { get; protected set; }

        [MaxLength(200)]
        public string JobWife3 { get; protected set; }

        [MaxLength(200)]
        public string JobWife4 { get; protected set; }

        public long NationalityLkpId { get; protected set; }

        public int? TenantCreatorId { get; protected set; }

        public long? UserId { get; protected set; }

        public User User { get; protected set; }

        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 2)]
        public FndLookupValues NationalityFndLookupValues { get; protected set; }

        public virtual ICollection<PortalUserData> PortalUserData { get; protected set; }

        public bool RepeatedIdNumberForUser()
        {
            var valid = (
                    (!string.IsNullOrEmpty(IdNumber) &&
                        (IdNumber == IdNumberWifeHusband1 || IdNumber == IdNumberWife2 || IdNumber == IdNumberWife3 || IdNumber == IdNumberWife4)
                    )
                    ||
                    (!string.IsNullOrEmpty(IdNumberWifeHusband1) &&
                        (IdNumberWifeHusband1 == IdNumber || IdNumberWifeHusband1 == IdNumberWife2 || IdNumberWifeHusband1 == IdNumberWife3 || IdNumberWifeHusband1 == IdNumberWife4)
                    )
                    ||
                    (!string.IsNullOrEmpty(IdNumberWife2) &&
                        (IdNumberWife2 == IdNumberWifeHusband1 || IdNumberWife2 == IdNumber || IdNumberWife2 == IdNumberWife3 || IdNumberWife2 == IdNumberWife4)
                    )
                    ||
                    (!string.IsNullOrEmpty(IdNumberWife3) &&
                        (IdNumberWife3 == IdNumber || IdNumberWife3 == IdNumberWife2 || IdNumberWife3 == IdNumberWifeHusband1 || IdNumberWife3 == IdNumberWife4)
                    )
                    ||
                    (!string.IsNullOrEmpty(IdNumberWife4) &&
                        (IdNumberWife4 == IdNumber || IdNumberWife4 == IdNumberWife2 || IdNumberWife4 == IdNumberWife3 || IdNumberWife4 == IdNumberWifeHusband1)
                    )
                );

            return valid;
        }

        public bool HasNoRequests() => true;
    }

    public class CheckIdNumbers
    {
        public long id { get; set; }
        public string IdNumber { get; set; }
        public string idNumberWifeHusband1 { get; set; }
        public string idNumberWife2 { get; set; }
        public string idNumberWife3 { get; set; }
        public string idNumberWife4 { get; set; }
    }
}
