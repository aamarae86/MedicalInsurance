using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._ScCampainsAid.Dto
{
    [AutoMapFrom(typeof(ScCampainsAid))]
    [AutoMapTo(typeof(ScCampainsAid))]
    [AutoMap(typeof(ScCampainsAid))]
    public class CreateScCampainsAidDto
    {
        public long CampainsAidCategoryLkpId { get; set; }
        [MaxLength(200)]
        public string AidName { get; set; }
        public decimal AidAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
