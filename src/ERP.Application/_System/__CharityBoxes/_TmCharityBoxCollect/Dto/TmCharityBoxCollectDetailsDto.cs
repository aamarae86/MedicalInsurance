using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectDetails;
using ERP.Helpers.Core;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto
{

    [AutoMap(typeof(TmCharityBoxCollectDetails))]
    public class TmCharityBoxCollectDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long TmCharityBoxCollectId { get; set; }

        public long CharityBoxActionDetailId { get; set; }

        public string charityBoxName { get; set; }

        public string subLocation { get; set; }

        public string barCode { get; set; }

        public string rowStatus { get; set; }
    }
}
