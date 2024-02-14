using ERP.Front.Helpers.Core;
using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ERP.ResourcePack.CRM.Meetings;
using ERP.ResourcePack.CRM.Deals;


namespace ERP.Web.UI.Models.ViewModels.CRM.meetings
{
    public class ActivityMeetingVM : BasePostAuditedVM<long>
    {

        public string EncId { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(activityMeeting.Title), ResourceType = typeof(activityMeeting))]
        public string Title { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(activityMeeting.Location), ResourceType = typeof(activityMeeting))]
        public string Location { get; set; }

        [Display(Name = nameof(activityMeeting.AllDay), ResourceType = typeof(activityMeeting))]
        public bool AllDay { get; set; }

        [Display(Name = nameof(activityMeeting.FromDay), ResourceType = typeof(activityMeeting))]
        public string FromDay { get; set; }

        [Display(Name = nameof(activityMeeting.FromTime), ResourceType = typeof(activityMeeting))]
        public string FromTime { get; set; }

        [Display(Name = nameof(activityMeeting.ToDay), ResourceType = typeof(activityMeeting))]
        public string ToDay { get; set; }

        [Display(Name = nameof(activityMeeting.ToTime), ResourceType = typeof(activityMeeting))]
        public string ToTime { get; set; }

        [Display(Name = nameof(activityMeeting.RelatedToLkpId), ResourceType = typeof(activityMeeting))]
        public long RelatedToLkpId { get; set; }

        [Display(Name = nameof(activityMeeting.CrmLeadsPersonsId), ResourceType = typeof(activityMeeting))]
        public long CrmLeadsPersonsId { get; set; }

        [Display(Name = nameof(activityMeeting.PartiReminderLkpId), ResourceType = typeof(activityMeeting))]
        public long PartiReminderLkpId { get; set; }

        public string RelatedToLkpVal { get; set; }
        public string CrmLeadsPersonsVal { get; set; }
        public string PartiReminderLkpVal { get; set; }


        [Display(Name = nameof(deals.Title), ResourceType = typeof(deals))]
        public long? CrmDealsId { get; set; }
        public string CrmDealsVal { get; set; }


        [MaxLength(4000)]
        [Display(Name = nameof(activityMeeting.Description), ResourceType = typeof(activityMeeting))]
        public string Description { get; set; }


        public string ActivityMeetingParticipantStr { get; set; }

        public ICollection<ActivityMeetingParticipantVM> ActivityMeetingParticipantList => string.IsNullOrEmpty(ActivityMeetingParticipantStr) ?
                new List<ActivityMeetingParticipantVM>() : Helper<List<ActivityMeetingParticipantVM>>.Convert(ActivityMeetingParticipantStr);
         
    }
}