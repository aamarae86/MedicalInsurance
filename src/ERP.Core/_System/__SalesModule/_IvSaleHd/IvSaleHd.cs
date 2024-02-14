using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System._FndLookupValues;
using ERP.Authorization.Users;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Currencies;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System._ArCustomers;
using ERP._System._ApBankAccounts;

namespace ERP._System.__SalesModule._IvSaleHd
{
    public class IvSaleHd : PostAuditedEntity<long>, IMustHaveTenant
    {
       
        [Required]
        [MaxLength(30)]
        public string IvSaleNumber { get; protected set; }
       
        [Required]
        public long StatusLkpId { get; protected set; }
        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupStatusLkp { get; protected set; }

        [Required]
        public DateTime IvSaleDate { get; protected set; }
       
        [MaxLength(30)]
        public string LpoNo { get; protected set; }
        
        [Required]
        public long IvPriceListHdId { get; protected set; }
        [ForeignKey(nameof(IvPriceListHdId))]
        public IvPriceListHd IvPriceListHd { get; set; }
       
        [MaxLength(4000)]
        public string Comments { get; protected set; }
      
        [Required]
        public long IvWarehouseId { get; protected set; }
        [ForeignKey(nameof(IvWarehouseId))]
        public IvWarehouses IvWarehouses { get; set; }

        [Required]
        public int CurrencyId { get; protected set; }
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal CurrencyRate { get; protected set; }

        [Required]
        public long FndSalesMenId { get;  set; }
        [ForeignKey(nameof(FndSalesMenId))]
        public FndSalesMen FndSalesMen { get; protected set; }
        
        [Required]
        public bool IsCash { get; protected set; }

        [Required]
        public long ArCustomerId { get; protected set; }
        [ForeignKey(nameof(ArCustomerId))]
        public ArCustomers ArCustomers { get; protected set; }
        public int TenantId { get; set; }

        
        public long? PaymentMethodLkpId { get; protected set; }
        [ForeignKey(nameof(PaymentMethodLkpId))]
        public FndLookupValues FndLookupPaymentMethodLkp { get; protected set; }

        public long? BankAccountId { get; protected set; }
        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; protected set; }

        
        public decimal? DeliveryCharges { get; protected set; }
        public decimal? Discount { get; protected set; }

        public bool? IsPOS { get; protected set; }
        public virtual ICollection<IvSaleTr> IvSaleTrs { get; protected set; }

        [MaxLength(15)]
        public string PhoneNumber { get; protected set; }
        [MaxLength(20)]
        public string CreditCardRef { get;  set; }
    }
}
