using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__CharityBoxes._TmCharityBoxes.Dto
{
    [AutoMap(typeof(TmCharityBoxes))]
    public class TmCharityBoxesEditDto : EntityDto<long>
    {
        //[Required]
        //public long StatusLkpId { get; set; }

        //[Required]
        //public long CharityTypeId { get; set; }
    }
}
