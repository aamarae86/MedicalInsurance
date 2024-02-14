using System.ComponentModel.DataAnnotations;
using ERP.ResourcePack.CRM.projects;
using ERP.Web.UI.Controllers.Base;

namespace ERP.Web.UI.Models.ViewModels.CRM._projects
{
    public class CrmProjectsVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(projects.ProjectDate), ResourceType = typeof(projects))]
        [Required]
        public string ProjectDate { get; set; }
        [StringLength(200)]
        [Display(Name = nameof(projects.ProjectNameAr), ResourceType = typeof(projects))]
        [Required]
        public string ProjectNameAr { get; set; }
        [StringLength(200)]
        [Display(Name = nameof(projects.ProjectNameEn), ResourceType = typeof(projects))]
        [Required]
        public string ProjectNameEn { get; set; }
        [StringLength(4000)]
        [Display(Name = nameof(projects.ProjectAdressAr), ResourceType = typeof(projects))]
        public string ProjectAdressAr { get; set; }
        [StringLength(4000)]
        [Display(Name = nameof(projects.ProjectAdressEn), ResourceType = typeof(projects))]
        public string ProjectAdressEn { get; set; }
        [StringLength(4000)]
        [Display(Name = nameof(projects.ContentAr), ResourceType = typeof(projects))]
        public string ContentAr { get; set; }
        [StringLength(4000)]
        [Display(Name = nameof(projects.ContentEn), ResourceType = typeof(projects))]
        public string ContentEn { get; set; }
        [StringLength(500)]
        [Display(Name = nameof(projects.Filepath), ResourceType = typeof(projects))]
        public string Filepath { get; set; }

    }
}