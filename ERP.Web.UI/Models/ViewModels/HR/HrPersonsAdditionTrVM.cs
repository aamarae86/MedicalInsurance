using ERP.ResourcePack.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrPersonsAdditionTrVM
    {
        public long Id { get; set; }
        public long? HrPersonAdditionHdId { get; set; }
        public long? HrPersonId { get; set; }
        [Display(Name = nameof(HrPersonsAdditionHd.HrPersonName), ResourceType = typeof(HrPersonsAdditionHd))]
        public string HrPersonName { get; set; }
        [Display(Name = nameof(HrPersonsAdditionHd.HrPersonNumber), ResourceType = typeof(HrPersonsAdditionHd))]
        public string HrPersonNumber { get; set; }
        [Display(Name = nameof(HrPersonsAdditionHd.AdditionTypeLkpId), ResourceType = typeof(HrPersonsAdditionHd))]
        public long? AdditionTypeLkpId { get; set; }
        public string AdditionTypeLkpName { get; set; }
        [Display(Name = nameof(HrPersonsAdditionHd.Amount), ResourceType = typeof(HrPersonsAdditionHd))]
        public decimal? Amount { get; set; }
        [MaxLength(4000)]
        [Display(Name = nameof(HrPersonsAdditionHd.Notes), ResourceType = typeof(HrPersonsAdditionHd))]
        public string Notes { get; set; }
        public string rowStatus { get; set; }
    }
}