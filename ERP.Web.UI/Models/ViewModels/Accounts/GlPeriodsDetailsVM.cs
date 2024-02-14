using ERP.ResourcePack.Accounts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlPeriodsDetailsVM
    {
        public long? glPeriodsDetailsId { get; set; }

        public int index { get; set; }

        [Display(Name = nameof(GlPeriodsYearsDetails.PeriodNameEn), ResourceType = typeof(GlPeriodsYearsDetails))]
        public string periodNameEn { get; set; }

        [Display(Name = nameof(GlPeriodsYearsDetails.PeriodNameAr), ResourceType = typeof(GlPeriodsYearsDetails))]
        public string periodNameAr { get; set; }

        [Display(Name = nameof(GlPeriodsYearsDetails.StartDate), ResourceType = typeof(GlPeriodsYearsDetails))]
        public string StartDateStrDetail { get; set; }

        [Display(Name = nameof(GlPeriodsYearsDetails.EndDate), ResourceType = typeof(GlPeriodsYearsDetails))]
        public string EndDateStrDetail { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string StatusLkp { get; set; }
    }
}