using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CRM._ActivityMeeting.Dto
{
    public class ActivityMeetingSearchDto
    {
        public long? RelatedToLkpId { get;  set; }
        public long? CrmLeadsPersonsId { get;  set; }
        public string Title { get;  set; }
        public string Location { get;  set; }
        public string Lang { get;  set; }
 
        public override string ToString()
               => $"Params.RelatedToLkpId={RelatedToLkpId}&Params.Title={Title}&Params.Lang={Lang}&Params.CrmLeadsPersonsId={CrmLeadsPersonsId}&Params.Location={Location}";
    }
}
