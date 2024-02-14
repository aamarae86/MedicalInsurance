namespace ERP._System.__AidModule._ScFndProtalAttachmentSetting.Dto
{
    public class ScFndProtalAttachmentSettingSearchDto
    {
        public string AttachmentNameAr { get; set; }

        public string AttachmentNameEn { get; set; }

        public long? RequestTypeId { get; set; }

        public override string ToString()
          => $"Params.AttachmentNameAr={AttachmentNameAr}&Params.AttachmentNameEn={AttachmentNameEn}&Params.RequestTypeId={RequestTypeId}";
    }
}
