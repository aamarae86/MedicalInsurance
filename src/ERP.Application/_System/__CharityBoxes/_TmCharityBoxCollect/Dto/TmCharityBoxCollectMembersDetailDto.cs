using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectMembersDetail;
using ERP.Helpers.Core;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto
{
    [AutoMap(typeof(TmCharityBoxCollectMembersDetail))]
    public class TmCharityBoxCollectMembersDetailDto : EntityDto<long>, IDetailRowStatus
    {

        public long TmCharityBoxCollectId { get; set; }

        public long TmCharityBoxCollectMemberId { get;  set; }

        public string memberName { get;  set; }

        public string memberNumber { get;  set; }

        public string memberCategory { get;  set; }

        public string rowStatus { get; set; }
    }
}
