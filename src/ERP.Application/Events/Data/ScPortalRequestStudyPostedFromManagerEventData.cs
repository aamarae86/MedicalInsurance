using Abp.Events.Bus;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;

namespace ERP.Events.Data
{
    public class ScPortalRequestStudyPostedFromManagerEventData : EventData
    {
        public ScPortalRequestMgrDecision scPortalRequestMgrDecision { get; set; }
        public string encId { get; set; }
    }
}
