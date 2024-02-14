using Abp.Application.Services.Dto;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto
{
    public class FmMaintRequisitionsHdrPagedDto  : PagedAndSortedResultRequestDto
    {
        public FmMaintRequisitionsHdrSearchDto Params { get; set; }
    }
}
