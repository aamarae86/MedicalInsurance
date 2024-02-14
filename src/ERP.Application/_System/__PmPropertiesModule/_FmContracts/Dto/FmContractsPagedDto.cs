using Abp.Application.Services.Dto;

namespace ERP._System.__PmPropertiesModule._FmContracts.Dto
{
    public class FmContractsPagedDto: PagedAndSortedResultRequestDto
    {
        public FmContractsSearchDto Params { get; set; }
    }
}
