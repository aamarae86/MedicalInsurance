using System.Collections.Generic;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    public class CommitteeDetailPermissionInputDto
    {
        public long UserId { get; set; }
        public ICollection<string> AllowedPermissions { get; set; }
        public ICollection<string> DeniedPermissions { get; set; }
    }
}
