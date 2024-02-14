using Abp.Application.Services.Dto;
using ERP.ResourcePack.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlJeLinesVM
    {

        public long Id { get; set; }

        [Display(Name = nameof(GlJeHeaders.DebitAmount), ResourceType = typeof(GlJeHeaders))]
        public decimal DebitAmount { get; set; }

        [Display(Name = nameof(GlJeHeaders.CreditAmount), ResourceType = typeof(GlJeHeaders))]
        public decimal CreditAmount { get; set; }

        public long AccountId { get; set; }

        public long GlJeHeaderId { get; set; }

        public long JeDtlSourceLkpId { get; set; }

        public long JeSourceId { get; set; }

        [Display(Name = nameof(GlJeHeaders.JeNotes), ResourceType = typeof(GlJeHeaders))]
        public string Notes { get; set; }
    }
}