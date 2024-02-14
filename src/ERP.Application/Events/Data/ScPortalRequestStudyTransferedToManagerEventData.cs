using Abp.Events.Bus;
using ERP._System.__AidModule._ScPortalRequestStudy;

namespace ERP.Events.Data
{
    public class ScPortalRequestStudyTransferedToManagerEventData : EventData
    {
        public ScPortalRequestStudy scPortalRequestStudy { get; set; }
        public string encId { get; set; }
    }
}
