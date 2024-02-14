using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using ERP.Authorization.Roles;
using System.Threading.Tasks;
using System.Linq;

namespace ERP.Authorization.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            RoleManager roleManager,
            UserStore store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher, 
            IEnumerable<IUserValidator<User>> userValidators, 
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<User>> logger, 
            IPermissionManager permissionManager, 
            IUnitOfWorkManager unitOfWorkManager, 
            ICacheManager cacheManager, 
            IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
            IOrganizationUnitSettings organizationUnitSettings, 
            ISettingManager settingManager)
            : base(
                roleManager, 
                store, 
                optionsAccessor, 
                passwordHasher, 
                userValidators, 
                passwordValidators, 
                keyNormalizer, 
                errors, 
                services, 
                logger, 
                permissionManager, 
                unitOfWorkManager, 
                cacheManager,
                organizationUnitRepository, 
                userOrganizationUnitRepository, 
                organizationUnitSettings, 
                settingManager)
        {
        }

        public List<MailReceiver> GetUsersForPermissionByPermissionName(string permissionName)
        {
            var deniedUsersEmailList = Users
                .Where(u => u.Permissions.Any(p => !p.IsGranted && p.Name.Equals(permissionName)))
                .Select(p => new MailReceiver { Id = p.Id, Name = p.Name, EmailAddress = p.EmailAddress }).ToList();

            var allowedRolesIdList = RoleManager.Roles
                .Where(r => r.Permissions.Any(p => p.IsGranted && p.Name.Equals(permissionName)))
                .Select(r => r.Id).ToList();

            IEnumerable<MailReceiver> allowedUsersEmailList = Users
                .Where(u => u.Roles.Any(r => allowedRolesIdList.Contains(r.RoleId)) || u.Permissions.Any(p => p.IsGranted && p.Name.Equals(permissionName)))
                .Select(p => new MailReceiver { Id = p.Id, Name = p.Name, EmailAddress = p.EmailAddress }).ToList();

            return allowedUsersEmailList.Except(deniedUsersEmailList).ToList();
        }
    }
}
