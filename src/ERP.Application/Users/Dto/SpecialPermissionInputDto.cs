using System.Collections.Generic;

namespace ERP.Users.Dto
{
    public class SpecialPermissionInputDto
    {
        public string ActionName { get; set; }
        public long UserId { get; set; }
        public ICollection<string> AllowedPermissions { get; set; }
        public ICollection<string> DeniedPermissions { get; set; }
    }
}
