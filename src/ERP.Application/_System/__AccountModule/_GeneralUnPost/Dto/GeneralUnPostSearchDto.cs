using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._GeneralUnPost.Dto
{
    [AutoMapFrom(typeof(GeneralUnPost))]
    public class GeneralUnPostSearchDto
    {
        public string UnPostNo { get;  set; }
        public string UnPostDate { get;  set; }
        public long? SourceLkpId { get;  set; }
        public override string ToString()
        {
            return $"Params.UnPostNo={UnPostNo}&Params.UnPostDate={UnPostDate}&Params.SourceLkpId={SourceLkpId}";
        }
    }
}
