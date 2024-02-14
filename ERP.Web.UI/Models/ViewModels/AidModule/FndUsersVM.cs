using ERP._System.__AidModule._Portal.UserAttachments;
using ERP._System.__AidModule._Portal.UserDuites;
using ERP._System.__AidModule._Portal.UserIncomes;
using ERP._System._Portal.UserRelatives.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Users.Dto;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class PortalUsersVM : BaseAuditedEntityVM<long>, IAttachmentListJSONString
    {
        public string EncId { get; set; }

        public string EncPortalUserDataId { get; set; }

        [Display(Name = nameof(FndUsers.LastModificationUser), ResourceType = typeof(FndUsers))]
        public string LastModificationUser { get; set; }

        public string LastModificationTimeStr2 => this.LastModificationTime.HasValue ? this.LastModificationTime.Value.ToString(Formatters.DateFormat) : string.Empty;

        [Display(Name = nameof(FndUsers.AddToLoggedTenant), ResourceType = typeof(FndUsers))]
        public bool AddToLoggedTenant { get; set; }

        [Display(Name = nameof(FndUsers.AddToLoggedTenant), ResourceType = typeof(FndUsers))]
        public bool AddToLoggedTenantAlt { get; set; }

        public string UserTenants { get; set; }

        [Display(Name = nameof(FndUsers.IsZakat), ResourceType = typeof(FndUsers))]
        public bool IsZakat { get; set; }

        [Display(Name = nameof(FndUsers.IsZakat), ResourceType = typeof(FndUsers))]
        public bool IsZakatAlt { get; set; }

        [Display(Name = nameof(FndUsers.CaseNumber), ResourceType = typeof(FndUsers))]
        public string CaseNumber { get; set; }

        [Display(Name = nameof(FndUsers.CaseCategoryLkpId), ResourceType = typeof(FndUsers))]
        public long? CaseCategoryLkpId { get; set; }

        [Display(Name = nameof(FndUsers.Job), ResourceType = typeof(FndUsers))]
        public string Job { get; set; }

        [Display(Name = nameof(FndUsers.FromDate), ResourceType = typeof(FndUsers))]
        public string FromDate { get; set; }

        [Display(Name = nameof(FndUsers.ToDate), ResourceType = typeof(FndUsers))]
        public string ToDate { get; set; }

        [Display(Name = nameof(FndUsers.Employer), ResourceType = typeof(FndUsers))]
        public string Employer { get; set; }

        [Display(Name = nameof(Name), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string Name { get; set; }

        [Display(Name = nameof(Region), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string Region { get; set; }

        [Display(Name = nameof(JobDescription), ResourceType = typeof(FndUsers))]
        public string JobDescription { get; set; }

        [Display(Name = nameof(Address), ResourceType = typeof(FndUsers))]
        public string Address { get; set; }

        [Display(Name = nameof(WifeHusbandName1), ResourceType = typeof(FndUsers))]
        public string WifeHusbandName1 { get; set; }

        [Display(Name = nameof(WifeName2), ResourceType = typeof(FndUsers))]
        public string WifeName2 { get; set; }

        [Display(Name = nameof(WifeName3), ResourceType = typeof(FndUsers))]
        public string WifeName3 { get; set; }

        [Display(Name = nameof(WifeName4), ResourceType = typeof(FndUsers))]
        public string WifeName4 { get; set; }

        [Display(Name = nameof(IdNumber), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string IdNumber { get; set; }

        [Display(Name = nameof(IdNumberWifeHusband1), ResourceType = typeof(FndUsers))]
        public string IdNumberWifeHusband1 { get; set; }

        [Display(Name = nameof(IdNumberWife2), ResourceType = typeof(FndUsers))]
        public string IdNumberWife2 { get; set; }

        [Display(Name = nameof(IdNumberWife3), ResourceType = typeof(FndUsers))]
        public string IdNumberWife3 { get; set; }

        [Display(Name = nameof(IdNumberWife4), ResourceType = typeof(FndUsers))]
        public string IdNumberWife4 { get; set; }

        [Display(Name = nameof(IdExpirationDate), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string IdExpirationDate { get; set; }

        [Display(Name = "BirthDate", ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string BirthDate { get; set; }

        [Display(Name = nameof(PhoneNumber), ResourceType = typeof(FndUsers))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string PhoneNumber { get; set; }

        [Display(Name = nameof(MobileNumber1), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string MobileNumber1 { get; set; }

        [Display(Name = nameof(MobileNumber2), ResourceType = typeof(FndUsers))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = nameof(Settings.NumbersOnly), ErrorMessageResourceType = typeof(Settings))]
        public string MobileNumber2 { get; set; }

        [Display(Name = nameof(GenderLkpId), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long GenderLkpId { get; set; }

        [Display(Name = nameof(CityLkpId), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long CityLkpId { get; set; }

        [Display(Name = nameof(NationalityLkpId), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long NationalityLkpId { get; set; }

        [Display(Name = nameof(MaritalStatusLkpId), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long MaritalStatusLkpId { get; set; }

        [Display(Name = nameof(MaritalStatusLkpId), ResourceType = typeof(FndUsers))]
        public long MaritalStatusRelativesLkpId { get; set; }

        [Display(Name = nameof(QualificationLkpId), ResourceType = typeof(FndUsers))]
        public long? QualificationLkpId { get; set; }

        [Display(Name = nameof(RelativesTypeLkpId), ResourceType = typeof(FndUsers))]
        public long RelativesTypeLkpId { get; set; }

        [Display(Name = nameof(FndUsers.Title), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PortalUserId { get; set; }

        public FndLookupValuesVM GenderFndLookupValues { get; set; }

        public FndLookupValuesVM CityFndLookupValues { get; set; }

        public FndLookupValuesVM NationalityFndLookupValues { get; set; }

        public FndLookupValuesVM MaritalStatusFndLookupValues { get; set; }

        public FndLookupValuesVM QualificationFndLookupValues { get; set; }

        public FndLookupValuesVM FndCaseCategoryLkp { get; set; }

        [Display(Name = nameof(RelName), ResourceType = typeof(FndUsers))]
        public string RelName { get; set; }

        [Display(Name = nameof(RelQualification), ResourceType = typeof(FndUsers))]
        public string RelQualification { get; set; }

        [Display(Name = nameof(RelGender), ResourceType = typeof(FndUsers))]
        public string RelGender { get; set; }

        [Display(Name = nameof(RelIdNumber), ResourceType = typeof(FndUsers))]
        public string RelIdNumber { get; set; }

        [Display(Name = nameof(RelNationality), ResourceType = typeof(FndUsers))]
        public string RelNationality { get; set; }

        public string ListFndUserRelatives { get; set; }

        public string UserStr { get; set; }

        [Display(Name = nameof(FndUsers.UserName), ResourceType = typeof(FndUsers))]
        public string UsName { get; set; }

        [Display(Name = nameof(EmailAddress), ResourceType = typeof(FndUsers))]
        public string EmailAddress { get; set; }

        [Display(Name = nameof(FndUsers.Password), ResourceType = typeof(FndUsers))]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }

        [Display(Name = nameof(FndUsers.ConfirmPassword), ResourceType = typeof(FndUsers))]
        [Compare(nameof(Password2), ErrorMessageResourceName = nameof(Settings.ConfirmPasswordCompare), ErrorMessageResourceType = typeof(Settings))]
        [DataType(DataType.Password)]
        public string ConPass { get; set; }


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

        [Display(Name = nameof(FndUsers.PassportIssueDate), ResourceType = typeof(FndUsers))]
        public string PassportIssueDate { get; set; }

        [Display(Name = nameof(FndUsers.PassportExpiryDate), ResourceType = typeof(FndUsers))]
        public string PassportExpiryDate { get; set; }

        [Display(Name = nameof(FndUsers.ResidenceEndDate), ResourceType = typeof(FndUsers))]
        public string ResidenceEndDate { get; set; }

        [Display(Name = nameof(FndUsers.Notes), ResourceType = typeof(FndUsers))]
        public string Notes { get; set; }

        public CreateUserDto User => string.IsNullOrEmpty(UserStr) ? new CreateUserDto { } : Helper<CreateUserDto>.Convert(UserStr);

        public List<PortalUserRelativesDto> UserRelatives
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(ListFndUserRelatives))
                    {
                        return new List<PortalUserRelativesDto>();
                    }
                    else
                    {
                        return Helper<List<PortalUserRelativesDto>>.Convert(ListFndUserRelatives);
                    }
                }
                catch (Exception x)
                {
                    throw;
                }
            }
        }

        [Display(Name = nameof(FndUsers.CreationTimeStr), ResourceType = typeof(FndUsers))]
        public string CreationTimeStr2 => this.CreationTime.ToString(Formatters.DateFormat);

        public bool IdNumbersRepeated { get; set; }

        [Display(Name = nameof(FndUsers.Source), ResourceType = typeof(FndUsers))]
        public string Source { get; set; }


        [Display(Name = nameof(ScPortalRequests.MonthlyOutcomeAmount), ResourceType = typeof(ScPortalRequests))]
        public decimal MonthlyOutcomeAmount { get; set; }

        [Display(Name = nameof(ScPortalRequests.TotalDuties), ResourceType = typeof(ScPortalRequests))]
        public decimal MonthlyOutcomeAmountTotal { get; set; }

        [Display(Name = nameof(ScPortalRequests.NetValue), ResourceType = typeof(ScPortalRequests))]
        public decimal NetValue { get; set; }

        [Display(Name = nameof(FndUsers.SourceCreatorName), ResourceType = typeof(FndUsers))]
        public string SourceCreatorName { get; set; }

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

        [Display(Name = nameof(FndUsers.TotalAmount), ResourceType = typeof(FndUsers))]
        public decimal TotalAmount { get; set; }

        [Display(Name = nameof(FndUsers.Source), ResourceType = typeof(FndUsers))]
        public long SourceId { get; set; }

        [Display(Name = nameof(FndUsers.SourceCreatorName), ResourceType = typeof(FndUsers))]
        public long CreatorId { get; set; }

        public string DutiesListStr { get; set; }

        public string IncomesListStr { get; set; }

        public PortalUsersVM PortalUser { get; set; }

        public ICollection<PortalUserIncomesDto> UserIncomes
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(IncomesListStr) ?
                    new List<PortalUserIncomesDto>() : Helper<List<PortalUserIncomesDto>>.Convert(IncomesListStr);
                }
                catch (Exception X)
                {
                    throw;
                }
            }
        }

        public ICollection<PortalUserDutiesDto> UserDuties
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(DutiesListStr) ?
                    new List<PortalUserDutiesDto>() : Helper<List<PortalUserDutiesDto>>.Convert(DutiesListStr);
                }
                catch (Exception X)
                {
                    throw;
                }
            }
        }

        public ICollection<PortalUserAttachmentsDto> UserAttachments
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(AttachmentsListStr) ?
                    new List<PortalUserAttachmentsDto>() : Helper<List<PortalUserAttachmentsDto>>.Convert(AttachmentsListStr);
                }
                catch (Exception X)
                {
                    throw;
                }
            }
        }

        public string AttachmentsListStr { get; set; }

        public bool FromUnifiedUser { get; set; } = false;
    }
}