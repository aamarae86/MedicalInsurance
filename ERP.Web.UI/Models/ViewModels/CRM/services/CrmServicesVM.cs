using System.ComponentModel.DataAnnotations;
using ERP.ResourcePack.CRM.services;
using ERP.Web.UI.Controllers.Base;

namespace ERP.Web.UI.Models.ViewModels.CRM.Services
{
    public class CrmServicesVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(services.IsActive), ResourceType = typeof(services))]
        public bool IsActive { get; set; }

        [StringLength(200)]
        [Display(Name = nameof(services.ServiceNameAr), ResourceType = typeof(services))]
        public string ServiceNameAr { get;  set; }
        [StringLength(200)]
        [Display(Name = nameof(services.ServiceNameEn), ResourceType = typeof(services))]
        public string ServiceNameEn { get;  set; }

        [StringLength(4000)]
        [Display(Name = nameof(services.ContentAr), ResourceType = typeof(services))]
        public string ContentAr { get; set; }
        [StringLength(4000)]
        [Display(Name = nameof(services.ContentEn), ResourceType = typeof(services))]
        public string ContentEn { get; set; }
        [StringLength(500)]
        [Display(Name = nameof(services.Filepath), ResourceType = typeof(services))]
        public string Filepath { get; set; }

    }
}