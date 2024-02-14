using Abp.Domain.Entities.Auditing;
using ERP.ResourcePack.AidModule;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScCommitteeDetailVM : BasePostAuditedVM<long>
    {
        [MaxLength(4000)]
        [Display(Name = nameof(ScCommittee.RefuseDescription), ResourceType = typeof(ScCommittee))]
        public string RefuseDescription { get; set; }
    }
}