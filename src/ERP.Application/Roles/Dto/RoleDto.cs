using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using ERP.Authorization.Roles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Roles.Dto
{
    public class RoleDto : AuditedEntityDto<int>
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }

        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        //public bool IsDefault { get; set; }

        //public bool IsStatic { get; set; }

        public List<string> GrantedPermissions { get; set; }
    }
}