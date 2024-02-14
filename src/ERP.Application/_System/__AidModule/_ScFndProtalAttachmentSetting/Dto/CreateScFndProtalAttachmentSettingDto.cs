using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScFndProtalAttachmentSetting.Dto
{
    [AutoMap(typeof(ScFndProtalAttachmentSetting))]
    public class CreateScFndProtalAttachmentSettingDto
    {
        public string AttachmentNameAr { get; set; }

        public string AttachmentNameEn { get; set; }

        public long RequestTypeId { get; set; }

        public int OrderBy { get; set; }

        public bool IsRequired { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }

    }
}
