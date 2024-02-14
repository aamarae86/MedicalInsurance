using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__CRM.AboutUs;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__CRM._CrmAboutUs.Dto
{
    [AutoMapFrom(typeof(CrmAboutUs))]
    public class PagedCrmAboutUsResultRequestDto : PagedAndSortedResultRequestDto, ISortModel
    {
        public CrmAboutUsSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }
    }
}
