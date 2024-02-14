using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._modules;

namespace ERP._System.Home
{
    public class FavoritePage : AuditedEntity<long>, IMayHaveTenant
    {
        public int PageId { get; protected set; }

        public Page Page { get; protected set; }

        public int? TenantId { get; set; }

        public FavoritePage() { }

        public FavoritePage(int pageId, long? creatorUserId, int? tenantId)
        {
            this.PageId = pageId;
            this.TenantId = tenantId;
            this.CreatorUserId = creatorUserId;
        }

        public static FavoritePage Create(int pageId, long? creatorUserId, int? tenantId) => new FavoritePage(pageId, creatorUserId, tenantId);

    }
}
