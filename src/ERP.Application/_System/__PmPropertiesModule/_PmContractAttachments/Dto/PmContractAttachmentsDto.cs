using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__PmPropertiesModule._PmContractAttachments.Dto
{
    [AutoMap(typeof(PmContractAttachments))]
    public class PmContractAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        [Required]
        [MaxLength(200)]
        public string attachmentName { get;  set; }

        //[Required]
        //public string base64Str { get; set; }

        //[Required]
        //public string fileExt { get;  set; }

      
        [MaxLength(1000)]
        public string FilePath { get;  set; }

        public long PmContractId { get;  set; }

        public string rowStatus { get ; set ; } = RowStatus.NoAction.ToString();
    }
}
