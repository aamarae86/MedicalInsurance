using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__PmPropertiesModule._PmPropertiesAttachments.Dto
{
    [AutoMap(typeof(PmPropertiesAttachments))]
    public class PmPropertiesAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        public string attachmentName { get;  set; }

        //public string base64Str { get;  set; }

        //public string fileExt { get; set; }

        public string FilePath { get; set; }

        public long PropertyId { get;  set; }

        public string rowStatus { get ; set ; } = RowStatus.NoAction.ToString();
    }
}
