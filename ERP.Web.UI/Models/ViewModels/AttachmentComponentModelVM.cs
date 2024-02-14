namespace ERP.Web.UI.Models.ViewModels
{
    public class AttachmentComponentModelVM
    {
        public string ImgId { get; set; }

        public string HidenFilePathId { get; set; }
        public string fNameSelector { get; set; }

        public string FileUploaderId { get; set; } = "defaultUploader";
    }
}