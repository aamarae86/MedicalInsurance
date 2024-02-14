using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.PostRecords.Dto
{
    public class RefuseInputDto : EntityDto<long>
    {
        public string Lang { get; set; }

        public string Reason { get; set; }

        public override string ToString() => $"?Id={Id}&Lang={Lang}";

    }
}
