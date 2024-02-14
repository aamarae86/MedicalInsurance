using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ScCampainsAid.Dto
{
    [AutoMapFrom(typeof(ScCampainsAid))]
    public class ScCampainsAidSearchDto
    {
        public long? CampainsAidCategoryLkpId { get;  set; }
        public string AidName { get;  set; }
        public decimal? AidAmount { get;  set; }
        public override string ToString()
        {
            return $"Params.AidName={AidName}&Params.AidAmount={AidAmount}&Params.CampainsAidCategoryLkpId={CampainsAidCategoryLkpId}";
        }
    }
}
