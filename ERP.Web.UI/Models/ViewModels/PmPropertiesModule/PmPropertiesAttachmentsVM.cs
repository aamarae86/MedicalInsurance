using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP.ResourcePack.PmPropertiesModule;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmPropertiesAttachmentsVM : Entity<long>
    {

        [Display(Name = nameof(PmProperties.AttachmentName), ResourceType = typeof(PmProperties))]
        public string AttachmentName { get;  set; }

    }
}