using ERP._System.__AidModule._ScDeliveryOtherAids.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScDeliveryOtherAidsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.OperationNumber), ResourceType = typeof(ScCommitteesCheck))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string OperationNumber { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.OperationDate), ResourceType = typeof(ScCommitteesCheck))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string OperationDate { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.StatusLkpId), ResourceType = typeof(ScCommitteesCheck))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.CommitteeId), ResourceType = typeof(ScCommitteesCheck))]
        public long? CommitteeId { get; set; }

        [Display(Name = nameof(ScCommitteesCheck.MaturityDate), ResourceType = typeof(ScCommitteesCheck))]
        public string MaturityDate { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScCommitteesCheck.Notes), ResourceType = typeof(ScCommitteesCheck))]
        public string Notes { get; set; }

        public string Status { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public ScCommitteeVM ScCommittee { get; set; }

        public string ListOtherAidDetailsStr { get; set; }

        public ICollection<ScDeliveryOtherAidDetailsDto> OtherAidDetails => string.IsNullOrEmpty(ListOtherAidDetailsStr) ?
                new List<ScDeliveryOtherAidDetailsDto>() : Helper<List<ScDeliveryOtherAidDetailsDto>>.Convert(ListOtherAidDetailsStr);
    }
}