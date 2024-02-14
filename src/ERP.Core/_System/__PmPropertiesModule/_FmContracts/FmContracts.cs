using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using ERP._System.__PmPropertiesModule._FmContracts;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe;
using ERP._System._ApVendors;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._FmContracts
{
    public class FmContracts : PostAuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        [MaxLength(30)]
        public string ContractNumber { get; set; }


        public long StatusLkpId { get; set; }
        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues StatusValues { get;set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    
        public long PaymentTypeLkpId { get;set; }
        [ForeignKey(nameof(PaymentTypeLkpId))]
        public FndLookupValues PaymentTypesValues { get; set; }


        public DateTime ContractDate { get; set; }

        public long VendorId { get; set; }
        [ForeignKey(nameof(VendorId))]
        public ApVendors ApVendorsValues { get; set; }



        [Column(TypeName = "nvarchar(4000)")]
        public string Comments { get; set; }

        public long AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails AccounGlCodeComDetails { get; set; }



        public decimal AnnualAmount { get; set; }
        public decimal RentAmount { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string VendorContractNumber { get; set; }
        public long AdvAccountId { get; set; }
        [ForeignKey(nameof(AdvAccountId))]
        public GlCodeComDetails AdvGlCodeComDetails { get; set; }




        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        public ICollection<FmContractVisits> FmContractVisits { get; set; }
        public ICollection<FmBuildingsContracts> FmBuildingsContracts { get; set; }
        public virtual ICollection<FmMaintRequisitionsExe> FmMaintRequisitionsExe { get; protected set; }
    }









}
