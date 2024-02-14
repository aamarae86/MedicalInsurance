using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.PostRecords.Dto
{
    public class IdLangInputDto : EntityDto<long>
    {
        //public long UserId { get; set; }
        public string Lang { get; set; }

        public override string ToString() => $"?Id={Id}&Lang={Lang}";

    }
}
