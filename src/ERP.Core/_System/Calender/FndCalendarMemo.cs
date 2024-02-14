using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.Calender
{
    public class FndCalendarMemo : AuditedEntity<long>, IMustHaveTenant
    {
        public string Memo { get; protected set; }

        public DateTime MemoDate { get; protected set; }

        public long UserId { get; protected set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; protected set; }
        public int TenantId { get; set; }
    }
}
