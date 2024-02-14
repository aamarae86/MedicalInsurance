using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using ERP.Authorization.Users;

namespace ERP.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : AuditedEntityDto<long>
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public string UserValue { get; set; }
        public DateTime? LastLoginTime { get; set; }

        public string[] RoleNames { get; set; }
        public string SubEndDate { get;  set; }
    }
}
