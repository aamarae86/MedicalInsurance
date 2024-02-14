using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlJeHeadersVM : BasePostAuditedVM<long>
    {
        private string lang = HttpContext.Current.Request.Cookies.Get("Lang") == null ? "ar-EG" : HttpContext.Current.Request.Cookies.Get("Lang").Value;

        [Display(Name = nameof(GlJeHeaders.JeName), ResourceType = typeof(GlJeHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string JeName { get; set; }

        [Display(Name = nameof(GlJeHeaders.JeNumber), ResourceType = typeof(GlJeHeaders))]
        public string JeNumber { get; set; }

        [Display(Name = nameof(GlJeHeaders.JeNumber), ResourceType = typeof(GlJeHeaders))]
        public int JeNumberKey { get; set; }

        [Display(Name = nameof(GlJeHeaders.JeDate), ResourceType = typeof(GlJeHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string JeDate { get; set; }

        [Display(Name = nameof(GlJeHeaders.PeriodId), ResourceType = typeof(GlJeHeaders))]
        public long? PeriodId { get; set; }

        [Display(Name = nameof(GlJeHeaders.CurrencyId), ResourceType = typeof(GlJeHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int CurrencyId { get; set; }

        [Display(Name = nameof(GlJeHeaders.CurrencyRate), ResourceType = typeof(GlJeHeaders))]
        public decimal CurrencyRate { get; set; }

        [Display(Name = nameof(GlJeHeaders.JeNotes), ResourceType = typeof(GlJeHeaders))]
        public string JeNotes { get; set; }

        [Display(Name = nameof(GlJeHeaders.StatusLkpId), ResourceType = typeof(GlJeHeaders))]
        public Nullable<long> StatusLkpId { get; set; }

        [Display(Name = nameof(GlJeHeaders.JeSourceLkpId), ResourceType = typeof(GlJeHeaders))]
        public Nullable<long> JeSourceLkpId { get; set; }

        [Display(Name = nameof(GlJeHeaders.JeSourceLkpId), ResourceType = typeof(GlJeHeaders))]
        public string JeSourceLkpText
            => JeSourceFndLookupValues == null ? string.Empty :
            (lang == "ar-EG" ? JeSourceFndLookupValues.NameAr : JeSourceFndLookupValues.NameEn);

        [Display(Name = nameof(GlJeHeaders.StatusLkpId), ResourceType = typeof(GlJeHeaders))]
        public string StatusLkpText
            => StatusFndLookupValues == null ? string.Empty :
            (lang == "ar-EG" ? StatusFndLookupValues.NameAr : StatusFndLookupValues.NameEn);


        [Display(Name = nameof(GlJeHeaders.JeSourceNo), ResourceType = typeof(GlJeHeaders))]
        public string JeSourceNo { get; set; }

        public FndLookupValuesVM StatusFndLookupValues { get; set; }

        public FndLookupValuesVM JeSourceFndLookupValues { get; set; }

        public CurrenciesVM Currency { get; set; }

        public string EncId { get; set; }

        public string ListGljeLinesDetails { get; set; }

        public List<GlJeLinesDetailsVM> GlJeLinesDetailsVM => string.IsNullOrEmpty(ListGljeLinesDetails) ? new List<GlJeLinesDetailsVM>() :
            Helper<List<GlJeLinesDetailsVM>>.Convert(ListGljeLinesDetails);

        public GlPeriodsVM GlPeriodsDetails { get; set; }

        [Display(Name = nameof(GlJeHeaders.PeriodName), ResourceType = typeof(GlJeHeaders))]
        public string PeriodNameAr { get; set; }

        [Display(Name = nameof(GlJeHeaders.PeriodName), ResourceType = typeof(GlJeHeaders))]
        public string PeriodNameEn { get; set; }

    }
}