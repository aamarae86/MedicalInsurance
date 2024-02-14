using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using ERP._System._GlAccDetails;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._GlAccHeaders
{
    public class GlAccHeaders : AuditedEntity<long>,IMustHaveTenant
    {
        #region Props

        [Required]
        [MaxLength(200)]
        public string NameEn { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string NameAr { get; protected set; }

        public int ShowOrder { get; protected set; }

        public bool IsHide { get; protected set; }
        public long AttributeLkpId { get; protected set; }
        public Nullable<long> ParentId { get; protected set; }


        [ForeignKey(nameof(AttributeLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        [ForeignKey(nameof(ParentId))]
        public GlAccHeaders Parent { get; protected set; }

        public virtual ICollection<GlAccDetails> GlAccDetails { get; protected set; }

        public int TenantId { get; set; }

        #endregion

        protected GlAccHeaders()
        {

        }
        protected GlAccHeaders(string nameAr,string nameEn,
            long attributeLkpId,bool isHide ,
            int showOrder, long? parentId = null)
        {
            this.NameAr = nameAr;
            this.NameEn = nameEn;
            this.AttributeLkpId = attributeLkpId;
            this.IsHide = isHide;
            this.ShowOrder = showOrder;
            this.ParentId = parentId;
        }

        public static GlAccHeaders Create(string nameAr, string nameEn,
            long attributeLkpId, bool isHide,
            int order, long? parentId = null)
        {
            return new GlAccHeaders(nameAr,nameEn,attributeLkpId,isHide,order,parentId);
        }
    }
}
