using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs._TmDamagedCharityBoxDetails;
using ERP.Helpers.Core;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto
{
    [AutoMap(typeof(TmDamagedCharityBoxDetails))]
    public class TmDamagedCharityBoxDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long TmDamagedCharityBoxId { get; set; }

        public long CharityBoxActionDetailId { get; set; }

        public string DamageReason { get;  set; }

        public string barCode { get; set; }

        public string charityBoxName { get; set; }

        public string rowStatus { get; set; }
    }
}
