using ERP._System.__AidModule._ScCampainsDetail.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScCampainsVM : PostAuditedEntity<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ScCampains.CampainName), ResourceType = typeof(ScCampains))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string CampainName { get; set; }

        [Display(Name = nameof(ScCampains.CampainNumber), ResourceType = typeof(ScCampains))]
        public string CampainNumber { get; set; }

        [Display(Name = nameof(ScCampains.ScCampainDate), ResourceType = typeof(ScCampains))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ScCampainDate { get; set; }

        [Display(Name = nameof(ScCampains.StatusLkpId), ResourceType = typeof(ScCampains))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ScCampains.Notes), ResourceType = typeof(ScCampains))]
        public string Notes { get; set; }

        public string Status => string.Empty;

        public FndLookupValuesVM FndLookupValues { get; set; }

        public string ListScCampainsDetail { get; set; }

        public ICollection<ScCampainsDetailDto> ScCampainDetailsList => string.IsNullOrEmpty(ListScCampainsDetail) ?
                new List<ScCampainsDetailDto>() :
                Helper<List<ScCampainsDetailDto>>.Convert(ListScCampainsDetail);


        [Display(Name = nameof(ScCampains.FndUsersId), ResourceType = typeof(ScCampains))]
        public long FndUsersId { get; set; }

        [Display(Name = nameof(ScCampains.CampainAidId), ResourceType = typeof(ScCampains))]
        public long CampainAidId { get; set; }

        [Display(Name = nameof(ScCampains.StatusLkpIdDetail), ResourceType = typeof(ScCampains))]
        public long StatusLkpDetailId { get; set; }

    }
}