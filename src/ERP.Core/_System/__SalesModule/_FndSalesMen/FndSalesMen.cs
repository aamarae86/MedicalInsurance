using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System._ArMiscReceiptHeaders;
using ERP.Authorization.Users;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__SalesModule._FndSalesMen
{
    public class FndSalesMen : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        [Required]
        public string SalesManNo { get; protected set; }

        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        [Required]
        public string SalesManNameAr { get; protected set; }

        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        [Required]
        public string SalesManNameEn { get; protected set; }      

        public bool IsActive { get; set; }
        public int TenantId { get; set; }

        /// <summary>
        public long? UserId { get; protected set; }
        public int? DiscountPercentageAllowed { get; protected set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; protected set; }
        /// </summary>

        [InverseProperty(nameof(ArJobCardHd.FndSalesMen))]
        public virtual ICollection<ArJobCardHd> FndSalesMenCollection { get; protected set; }

    }
}
