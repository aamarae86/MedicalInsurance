using Abp.Domain.Entities;
using ERP.ResourcePack.PmPropertiesModule;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels
{
    public class BaseAttachmentsVM : Entity<long>
    {

        [Display(Name = nameof(PmProperties.AttachmentName), ResourceType = typeof(PmProperties))]
        public string AttachmentName { get; set; }

        public string HidenAttachmentFilePathId { get; set; } = "FilePathAttachment";
    }
}