using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._modules
{
    public class Page : Entity
    {
        [MaxLength(100)]
        public string NameAr { get; protected set; }

        [MaxLength(100)]
        public string NameEn { get; protected set; }

        [MaxLength(100)]
        public string Selector { get; protected set; }

        [MaxLength(100)]
        public string Link { get; protected set; }

        [MaxLength(100)]
        public string Icon { get; protected set; }

        public int ModuleId { get; protected set; }

        [ForeignKey(nameof(ModuleId))]
        public Module Module { get; protected set; }

        [MaxLength(200)]
        public string VideoUrlAr { get; protected set; }

        [MaxLength(200)]
        public string VideoUrlEn { get; protected set; }

        [MaxLength(200)]
        public string DocPathAr { get; protected set; }

        [MaxLength(200)]
        public string DocPathEn { get; protected set; }
    }
}
