using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.MultiTenancy;
using ERP._System._modules;
using ERP.Authorization.Users;
using ERP.MultiTenancy;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._TenantFreeModules
{
    public class TenantRenewalHistory : AuditedEntity<long> 
    {
        
        public int Tenant_ID { get;  set; }
        [ForeignKey(nameof(Tenant_ID))]
        public Tenant Tenant { get; private set; }

        public DateTime ExpiryDate { get; set; }
        public long RenewToUserId { get; private set; }
        [ForeignKey(nameof(RenewToUserId))]

        public User RenewToUser { get; private set; }
        public decimal RenewalPrice { get; private set; } 
        public string TransactionNumber { get; private set; }
        public string SessionId { get; private set; }

        public bool Confirmed { get; private set; } = false;

        public void SetNewRenewall(int Tenant_ID, long RenewToUserId, decimal RenewalPrice, DateTime ExpiryDate,string SessionId)
        {
            this.Tenant_ID = Tenant_ID;
            this.ExpiryDate = ExpiryDate;
            this.RenewToUserId = RenewToUserId;
            this.RenewalPrice = RenewalPrice;
            this.SessionId = SessionId;
           
        }

        public void ChangeHistoryStatus(bool status)
        {
            Confirmed = status;
        }  
        public void SetTransactionNumber(string trxNo)
        {
            TransactionNumber = trxNo;
        }

    }
}
