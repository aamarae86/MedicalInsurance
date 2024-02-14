using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._FndCollectors.Dto
{
    [AutoMapFrom(typeof(FndCollectors))]
    public class FndCollectorsSearchDto
    {
        public int? CollectorNumber { get;  set; }
        public string CollectorNameAr { get;  set; }
        public string CollectorNameEn { get;  set; }
        public override string ToString()
        {
            return $"Params.CollectorNameAr={CollectorNameAr}&Params.CollectorNameEn={CollectorNameEn}&Params.CollectorNumber={CollectorNumber}";
        }
    }
}
