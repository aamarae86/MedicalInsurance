using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;
using ERP._System._ApUserBankAccess;
using ERP._System._TenantFreeModules;

namespace ERP.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public virtual ICollection<ApUserBankAccess> ApUserBankAccesses { get; protected set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()

            };

            user.SetNormalizedNames();

            return user;
        }

        public bool IsPortalUser { get; set; } = false;

        public DateTime? SubEndDate { get; protected set; }
       

        public PortalUser portalUser { get; set; }

        public virtual ICollection<IvUserWarehousesPrivileges> IvUserWarehousesPrivileges { get; protected set; }

        public virtual ICollection<ScPortalRequest> ScPortalRequest { get; protected set; }
        public virtual ICollection<TenantRenewalHistory> TenantRenewalHistories { get; protected set; }

        public void SetSubEndDateValue(DateTime SubEndDate)
        {
            this.SubEndDate = SubEndDate;
        }
    }
}
