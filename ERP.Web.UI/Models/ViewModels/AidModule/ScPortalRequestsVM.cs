using ERP._System.__AidModule._ScPortalRequest.Dto;
using ERP._System.__AidModule._ScPortalRequestVisited.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Authentications;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScPortalRequestsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        public string FinalDecision { get; set; }

        public string Source { get; set; }

        public string Name { get; set; }

        [Display(Name = nameof(ScPortalRequests.IncomeSourceName), ResourceType = typeof(ScPortalRequests))]
        public string IncomeSourceName { get; set; }

        [Display(Name = nameof(ScPortalRequests.MonthlyIncomeAmount), ResourceType = typeof(ScPortalRequests))]
        public decimal MonthlyIncomeAmount { get; set; }

        [Display(Name = nameof(ScPortalRequests.TotalIncomes), ResourceType = typeof(ScPortalRequests))]
        public decimal MonthlyIncomeAmountTotal { get; set; }

        [Display(Name = nameof(ScPortalRequests.Total), ResourceType = typeof(ScPortalRequests))]
        public decimal Total { get; set; }

        [Display(Name = nameof(ScPortalRequests.DutyType), ResourceType = typeof(ScPortalRequests))]
        public string DutyType { get; set; }

        [Display(Name = nameof(ScPortalRequests.DutyDescription), ResourceType = typeof(ScPortalRequests))]
        public string DutyDescription { get; set; }

        [Display(Name = nameof(ScPortalRequests.MonthlyAmount), ResourceType = typeof(ScPortalRequests))]
        public decimal MonthlyAmount { get; set; }

        [Display(Name = nameof(ScPortalRequests.FromDate), ResourceType = typeof(ScPortalRequests))]
        public string FromDate { get; set; }

        [Display(Name = nameof(ScPortalRequests.ToDate), ResourceType = typeof(ScPortalRequests))]
        public string ToDate { get; set; }

        [Display(Name = nameof(ScPortalRequests.SourceLkpId), ResourceType = typeof(ScPortalRequests))]
        public long SourceLkpId { get; set; }

        [Display(Name = nameof(ScPortalRequests.PortalUsersId), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PortalUsersId { get; set; }

        [Display(Name = nameof(ScPortalRequests.PortalRequestNumber), ResourceType = typeof(ScPortalRequests))]
        public string PortalRequestNumber { get; set; }

        [Display(Name = nameof(ScPortalRequests.PortalRequestDate), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PortalRequestDate { get; set; }

        [Display(Name = nameof(ScPortalRequests.StatusLkpId), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ScPortalRequests.Description), ResourceType = typeof(ScPortalRequests))]
        public string Description { get; set; }

        [Display(Name = nameof(ScPortalRequests.Region), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string Region { get; set; }

        [Display(Name = nameof(ScPortalRequests.JobDescription), ResourceType = typeof(ScPortalRequests))]
        public string JobDescription { get; set; }

        [Display(Name = nameof(ScPortalRequests.Address), ResourceType = typeof(ScPortalRequests))]
        public string Address { get; set; }

        [Display(Name = nameof(ScPortalRequests.WifeHusbandName1), ResourceType = typeof(ScPortalRequests))]
        public string WifeHusbandName1 { get; set; }

        [Display(Name = nameof(ScPortalRequests.WifeName2), ResourceType = typeof(ScPortalRequests))]
        public string WifeName2 { get; set; }

        [Display(Name = nameof(ScPortalRequests.WifeName3), ResourceType = typeof(ScPortalRequests))]
        public string WifeName3 { get; set; }

        [Display(Name = nameof(ScPortalRequests.WifeName4), ResourceType = typeof(ScPortalRequests))]
        public string WifeName4 { get; set; }

        [Display(Name = nameof(ScPortalRequests.IdNumber), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMaxLength), ErrorMessageResourceType = typeof(FndUsers))]
        [MinLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMinLength), ErrorMessageResourceType = typeof(FndUsers))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string IdNumber { get; set; }

        [Display(Name = nameof(ScPortalRequests.IdNumberWifeHusband1), ResourceType = typeof(ScPortalRequests))]
        [MaxLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMaxLength), ErrorMessageResourceType = typeof(FndUsers))]
        [MinLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMinLength), ErrorMessageResourceType = typeof(FndUsers))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string IdNumberWifeHusband1 { get; set; }

        [Display(Name = nameof(ScPortalRequests.IdNumberWife2), ResourceType = typeof(ScPortalRequests))]
        [MaxLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMaxLength), ErrorMessageResourceType = typeof(FndUsers))]
        [MinLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMinLength), ErrorMessageResourceType = typeof(FndUsers))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string IdNumberWife2 { get; set; }

        [Display(Name = nameof(ScPortalRequests.IdNumberWife3), ResourceType = typeof(ScPortalRequests))]
        [MaxLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMaxLength), ErrorMessageResourceType = typeof(FndUsers))]
        [MinLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMinLength), ErrorMessageResourceType = typeof(FndUsers))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string IdNumberWife3 { get; set; }

        [Display(Name = nameof(ScPortalRequests.IdNumberWife4), ResourceType = typeof(ScPortalRequests))]
        [MaxLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMaxLength), ErrorMessageResourceType = typeof(FndUsers))]
        [MinLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMinLength), ErrorMessageResourceType = typeof(FndUsers))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string IdNumberWife4 { get; set; }

        [Display(Name = nameof(ScPortalRequests.IdExpirationDate), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string IdExpirationDate { get; set; }

        [Display(Name = nameof(ScPortalRequests.PhoneNumber), ResourceType = typeof(ScPortalRequests))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string PhoneNumber { get; set; }

        [Display(Name = nameof(ScPortalRequests.MobileNumber1), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string MobileNumber1 { get; set; }

        [Display(Name = nameof(ScPortalRequests.MobileNumber2), ResourceType = typeof(ScPortalRequests))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string MobileNumber2 { get; set; }

        [Display(Name = nameof(ScPortalRequests.AidRequestTypeId), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long AidRequestTypeId { get; set; }

        [Display(Name = nameof(ScPortalRequests.IncomeSource), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string IncomeSource { get; set; }

        [Display(Name = nameof(ScPortalRequests.MonthlyOutcomeAmount), ResourceType = typeof(ScPortalRequests))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal MonthlyOutcomeAmount { get; set; }

        [Display(Name = nameof(ScPortalRequests.TotalDuties), ResourceType = typeof(ScPortalRequests))]
        public decimal MonthlyOutcomeAmountTotal { get; set; }

        [Display(Name = nameof(ScPortalRequests.NetValue), ResourceType = typeof(ScPortalRequests))]
        public decimal NetValue { get; set; }

        [Display(Name = nameof(ScPortalRequests.City), ResourceType = typeof(ScPortalRequests))]
        public string City { get; set; }

        [Display(Name = nameof(ScPortalRequests.MaritalStatus), ResourceType = typeof(ScPortalRequests))]
        public string MaritalStatus { get; set; }

        [Display(Name = nameof(ScPortalRequests.Qualification), ResourceType = typeof(ScPortalRequests))]
        public string Qualification { get; set; }

        [Display(Name = nameof(ScPortalRequests.Nationality), ResourceType = typeof(ScPortalRequests))]
        public string Nationality { get; set; }

        [Display(Name = nameof(ScPortalRequests.ResearcherId), ResourceType = typeof(ScPortalRequests))]
        public long? ResearcherId { get; set; }

        public string Status => string.Empty;

        public FndLookupValuesVM FndLookupValuesStatusLkp { get; set; }
        public ScFndAidRequestTypeVM AidRequestType { get; set; }


        public PortalUsersVM PortalUser { get; set; }

        public UsersVM Researcher { get; set; }


        [Display(Name = nameof(ScPortalRequests.VisitDate), ResourceType = typeof(ScPortalRequests))]
        public string VisitDate { get; set; }

        [Display(Name = nameof(ScPortalRequests.VisitTime), ResourceType = typeof(ScPortalRequests))]
        public string VisitTime { get; set; }

        [Display(Name = nameof(ScPortalRequests.VisitStatusLkpId), ResourceType = typeof(ScPortalRequests))]
        public long VisitStatusLkpId { get; set; }

        [Display(Name = nameof(ScPortalRequests.MobileNumber), ResourceType = typeof(ScPortalRequests))]
        public string MobileNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(FndUsers.JobWifeHusband1), ResourceType = typeof(FndUsers))]
        public string JobWifeHusband1 { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(FndUsers.JobWife2), ResourceType = typeof(FndUsers))]
        public string JobWife2 { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(FndUsers.JobWife3), ResourceType = typeof(FndUsers))]
        public string JobWife3 { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(FndUsers.JobWife4), ResourceType = typeof(FndUsers))]
        public string JobWife4 { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(FndUsers.PassportNumber), ResourceType = typeof(FndUsers))]
        public string PassportNumber { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(FndUsers.UnifiedNumber), ResourceType = typeof(FndUsers))]
        public string UnifiedNumber { get; set; }


        [Display(Name = nameof(FndUsers.TotalAmount), ResourceType = typeof(FndUsers))]
        public decimal? TotalAmount { get; set; }

        [Display(Name = nameof(FndUsers.PassportIssueDate), ResourceType = typeof(FndUsers))]
        public string PassportIssueDate { get; set; }

        [Display(Name = nameof(FndUsers.PassportExpiryDate), ResourceType = typeof(FndUsers))]
        public string PassportExpiryDate { get; set; }

        [Display(Name = nameof(FndUsers.ResidenceEndDate), ResourceType = typeof(FndUsers))]
        public string ResidenceEndDate { get; set; }

        public string ListScPortalRequestVisitedDetail { get; set; }

        public string ListAttachments { get; set; }

        public string DutiesListStr { get; set; }

        public string IncomesListStr { get; set; }

        public FndLookupValuesVM FndLookupValuesSourceLkp { get; set; }

        public ICollection<ScPortalRequestIncomeDto> RequestIncomes
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(IncomesListStr) ?
                    new List<ScPortalRequestIncomeDto>() : Helper<List<ScPortalRequestIncomeDto>>.Convert(IncomesListStr);
                }
                catch (Exception X)
                {
                    throw;
                }
            }
        }

        public ICollection<ScPortalRequestDutiesDto> RequestDuties
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(DutiesListStr) ?
                    new List<ScPortalRequestDutiesDto>() : Helper<List<ScPortalRequestDutiesDto>>.Convert(DutiesListStr);
                }
                catch (Exception X)
                {
                    throw;
                }
            }
        }

        public ICollection<ScPortalRequestAttachmentCreateDto> RequestAttachments
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(ListAttachments) ?
                   new List<ScPortalRequestAttachmentCreateDto>() : Helper<List<ScPortalRequestAttachmentCreateDto>>.Convert(ListAttachments);
                }
                catch (Exception X)
                {
                    throw;
                }
            }
        }

        public ICollection<ScPortalRequestVisitedDto> RequestVisits
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(ListScPortalRequestVisitedDetail) ?
                     new List<ScPortalRequestVisitedDto>() : Helper<List<ScPortalRequestVisitedDto>>.Convert(ListScPortalRequestVisitedDetail);
                }
                catch (Exception x) { throw; }
            }
        }

    }
}