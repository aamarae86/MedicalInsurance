using Abp.Domain.Entities;
using ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.CharityBoxes;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmCharityBoxCollectVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        public string Status { get; set; }

        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        public string ToDate { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.CollectDate), ResourceType = typeof(TmCharityBoxCollect))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string CollectDate { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.CollectNumber), ResourceType = typeof(TmCharityBoxCollect))]
        public string CollectNumber { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Notes), ResourceType = typeof(TmCharityBoxCollect))]
        public string Notes { get; set; }

        #region Coins Category
        [Display(Name = nameof(TmCharityBoxCollect.Value25F), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value25F { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value50F), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value50F { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value1Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value1Dh { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value5Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value5Dh { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value10Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value10Dh { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value20Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value20Dh { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value50Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value50Dh { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value100Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value100Dh { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value200Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value200Dh { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value500Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value500Dh { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Value1000Dh), ResourceType = typeof(TmCharityBoxCollect))]
        public long? Value1000Dh { get; set; }
        #endregion

        [Display(Name = nameof(TmCharityBoxCollect.MemberNumber), ResourceType = typeof(TmCharityBoxCollect))]
        public string MemberNumber { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.MemberCategory), ResourceType = typeof(TmCharityBoxCollect))]
        public string MemberCategory { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.TmCharityBoxCollectMemberId), ResourceType = typeof(TmCharityBoxCollect))]
        public long TmCharityBoxCollectMemberId { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.BarCode), ResourceType = typeof(TmCharityBoxCollect))]
        public long CharityBoxActionDetailId { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.CharityBox), ResourceType = typeof(TmCharityBoxCollect))]
        public string CharityBoxName { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.SubLocation), ResourceType = typeof(TmCharityBoxCollect))]
        public string SubLocation { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.StatusLkpId), ResourceType = typeof(TmCharityBoxCollect))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.BankAccountId), ResourceType = typeof(TmCharityBoxCollect))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long BankAccountId { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.Total), ResourceType = typeof(TmCharityBoxCollect))]
        public decimal Total { get; set; }

        public FndLookupValuesVM FndStatusLookup { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }

        public string CharityBoxCollectMembersListStr { get; set; }

        public ICollection<TmCharityBoxCollectMembersDetailDto> CharityBoxCollectMembers =>
            string.IsNullOrEmpty(CharityBoxCollectMembersListStr) ?
             new List<TmCharityBoxCollectMembersDetailDto>() :
            Helper<List<TmCharityBoxCollectMembersDetailDto>>.Convert(CharityBoxCollectMembersListStr);

        public string CharityBoxCollectDetailsListStr { get; set; }

        public ICollection<TmCharityBoxCollectDetailsDto> CharityBoxCollectDetails =>
            string.IsNullOrEmpty(CharityBoxCollectDetailsListStr) ?
             new List<TmCharityBoxCollectDetailsDto>() :
            Helper<List<TmCharityBoxCollectDetailsDto>>.Convert(CharityBoxCollectDetailsListStr);

    }
}