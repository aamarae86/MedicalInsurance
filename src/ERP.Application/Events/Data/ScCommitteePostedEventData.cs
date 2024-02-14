using Abp.Events.Bus;
using ERP._System.__AidModule._ScCommittee;
using System.Collections.Generic;

namespace ERP.Events.Data
{
    public class ScCommitteePostedEventData : EventData
    {
        public ScCommittee scCommittee { get; set; }
        public List<ScCommitteeDetail> scCommitteeDetails { get; set; }
    }
    public class ScCommitteeDetailPostedEventData : EventData
    {
        public ScCommitteeDetail scCommitteeDetail { get; set; }
        public string encId { get; set; }
    }
}
