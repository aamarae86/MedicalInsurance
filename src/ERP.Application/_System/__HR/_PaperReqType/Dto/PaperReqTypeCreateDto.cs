using Abp.AutoMapper;
using ERP._System.__HR._HRPaperRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._PaperReqType.Dto
{
    [AutoMap(typeof(PaperReqType))]
   public class PaperReqTypeCreateDto
    {
        public string PaperReqTypeName { get; set; }

    }
}
