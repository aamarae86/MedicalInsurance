using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._GlAccHeaders;
using ERP._System._GlCodeComDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._GlAccDetails
{
    public class GlAccDetails : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [Required]
        [MaxLength(20)]
        public string Code { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string NameAr { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string NameEn { get; protected set; }

        public long GlAccHeaderId { get; protected set; }

        public bool IsDefault { get; protected set; }

        public long? ParentId { get; protected set; }

        public long? DashboardMappingId { get; protected set; }

        [ForeignKey(nameof(ParentId))]
        public GlAccDetails GlAccDetail { get; protected set; }

        [ForeignKey(nameof(GlAccHeaderId))]
        public GlAccHeaders GlAccHeader { get; protected set; }

        public int TenantId { get; set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr1))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr1Collection { get; protected set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr2))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr2Collection { get; protected set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr3))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr3Collection { get; protected set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr4))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr4Collection { get; protected set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr5))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr5Collection { get; protected set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr6))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr6Collection { get; protected set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr7))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr7Collection { get; protected set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr8))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr8Collection { get; protected set; }

        [InverseProperty(nameof(GlCodeComDetails.GlAccDetailsAttr9))]
        public virtual ICollection<GlCodeComDetails> GlAccDetailsAttr9Collection { get; protected set; }

        #endregion

        protected GlAccDetails()  { }

        protected GlAccDetails(string code, string nameAr, string nameEn, long glAccHeaderId, bool isDefault, long? parentId)
        {
            this.Code = code;
            this.NameAr = nameAr;
            this.NameEn = nameEn;
            this.GlAccHeaderId = glAccHeaderId;
            this.IsDefault = isDefault;
            this.ParentId = parentId;
        }

        public static GlAccDetails
            Create(string code, string nameAr, string nameEn, long glAccHeaderId, bool isDefault, long? parentId = null)
        {
            return new GlAccDetails(code, nameAr, nameEn, glAccHeaderId, isDefault, parentId);
        }

    }
}
