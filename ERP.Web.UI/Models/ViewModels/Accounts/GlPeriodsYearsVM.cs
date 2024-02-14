using ERP._System._GlPeriods.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.Web.UI.Controllers.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlPeriodsYearsVM : BaseAuditedEntityVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId { get; set; }

        [Required]
        [Display(Name = nameof(GlPeriodsYears.PeriodYear), ResourceType = typeof(GlPeriodsYears))]
        [Remote("IsExistingPeriod", "GlPeriodsYears", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "periodExist", ErrorMessageResourceType = typeof(GlPeriodsYears))]
        public int PeriodYear { get; set; }

        [Required]
        [Display(Name = nameof(GlPeriodsYears.StartDate), ResourceType = typeof(GlPeriodsYears))]
        public string StartDate { get; set; }

        [Required]
        [Display(Name = nameof(GlPeriodsYears.EndDate), ResourceType = typeof(GlPeriodsYears))]
        public string EndDate { get; set; }

        public string ListPeriodDetails { get; set; }

        public ICollection<GlPeriodsDetailsDto> PeriodDetails => string.IsNullOrEmpty(ListPeriodDetails) ? new List<GlPeriodsDetailsDto>() :
            Helper<List<GlPeriodsDetailsDto>>.Convert(ListPeriodDetails);

        public string DeletedDetailIdsStr { get; set; }

        public ICollection<long> DeletedDetailIds => string.IsNullOrEmpty(DeletedDetailIdsStr) ? new List<long>() :
            Helper<List<long>>.Convert(DeletedDetailIdsStr);

        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }

    }
}