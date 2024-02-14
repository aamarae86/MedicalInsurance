using Abp.Domain.Entities;
using ERP._System._TenantFreeModules;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._modules
{
    public class Module : Entity
    {
        [MaxLength(100)]
        public string NameAr { get; protected set; }
        [MaxLength(100)]
        public string NameEn { get; protected set; }
        [MaxLength(100)]
        public string Selector { get; protected set; }

        public virtual ICollection<Page> Pages { get; protected set; }
        public virtual ICollection<TenantFreeModules> TenantFreeModules { get; protected set; }

    }
}
