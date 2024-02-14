using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScPortalRequestStudyAttachmentVM
    {
        public long? Id { get; set; }
        public long? PortalRequestStudyId { get; set; }
        [MaxLength(200)]
        public string AttachmentName { get; set; }
        [MaxLength(1000)]
        public string FilePath { get; set; }
        public string FileExt { get; set; }
        public int TenantId { get; set; }
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string rowStatus { get; set; }
    }
}