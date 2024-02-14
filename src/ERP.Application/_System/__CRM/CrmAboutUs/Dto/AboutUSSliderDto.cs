using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__CRM.AboutUs.Dto
{
    [AutoMap(typeof(AboutUSSlider))]
    public class AboutUSSliderDto : EntityDto<long>, IDetailRowStatus
    {
        [StringLength(4000)]
        public string FilePath { get; set; }
        public long CrmAboutUsId { get; set; }
        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }
}
