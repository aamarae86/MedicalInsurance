using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using ERP.Authorization.Users;

namespace ERP.MultiTenancy.Dto
{
    [AutoMapTo(typeof(Tenant))]
    public class CreateTenantDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [Required]       
        public string MobileNo { get; set; }

        [StringLength(AbpTenantBase.MaxConnectionStringLength)]
        public string ConnectionString { get; set; }

        [Required]
        public long CountryLkpId { get; set; }

        [Required]
        public long IndustryLkpId { get; set; }

        //[Required]
        //[StringLength(128, MinimumLength = 6)]
        //public string AdminPassword { get; set; } = User.DefaultPassword;

        public bool IsActive {get; set;}
        public string Baseurl { get; set; }
    }
}
