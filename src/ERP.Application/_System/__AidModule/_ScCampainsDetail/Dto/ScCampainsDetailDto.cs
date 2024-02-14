using Abp.AutoMapper;
using ERP.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;

namespace ERP._System.__AidModule._ScCampainsDetail.Dto
{
    [AutoMap(typeof(ScCampainsDetail))]
    public class ScCampainsDetailDto : PostAuditedEntityDto<long>, IDetailRowStatus
    {
        public long? id { get; set; }

        public long portalFndUsersId { get; set; }
        public long campainAidId { get; set; }
        public long statusLkpId { get; set; }

        public string fndUsers { get; set; }
        public string fndUserEncId { get; set; }
        public string fndUsersIdNumber { get; set; }

        public string campainAid { get; set; }
        public string statusLkp { get; set; }

        public string userRelativeCount { get; set; }

        public int recievedCount { get; set; }
        public int postedCount { get; set; }

        public string rowStatus { get; set; }
    }
}
