using ERP.ResourcePack.CRM.Meetings;
using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.CRM.meetings
{
    public class ActivityMeetingParticipantVM : BasePostAuditedVM<long>
    {

        [Display(Name = nameof(activityMeeting.ActivityMeetingId), ResourceType = typeof(activityMeeting))]
        public long ActivityMeetingId { get; set; }   
        
        
        [Display(Name = nameof(activityMeeting.RelatedToLkpId), ResourceType = typeof(activityMeeting))]
        public long RelatedToLkpId { get; set; }


        [Display(Name = nameof(activityMeeting.CrmLeadsPersonsId), ResourceType = typeof(activityMeeting))]
        public long CrmLeadsPersonsId { get; set; }

        public string rowStatus { get; set; } 


    }
}