using ERP._System.__HR._HrPersons.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrPersonsVM : BaseAuditedEntityVM<long>, IAttachmentListJSONString
    {
        public string EncId { get; set; }


        [Display(Name = nameof(HrPersons.FullName), ResourceType = typeof(HrPersons))]
        public string FullName { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(HrPersons.PhoneNumber), ResourceType = typeof(HrPersons))]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersons.Region), ResourceType = typeof(HrPersons))]
        public string Region { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersons.ResidencePlace), ResourceType = typeof(HrPersons))]
        public string ResidencePlace { get; set; }

        #region MainProps

        [MaxLength(30)]
        [Display(Name = nameof(HrPersons.EmployeeNumber), ResourceType = typeof(HrPersons))]
        public string EmployeeNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersons.FirstName), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string FirstName { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersons.FatherName), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string FatherName { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersons.LastName), ResourceType = typeof(HrPersons))]
        public string LastName { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersons.PlaceOfBirth), ResourceType = typeof(HrPersons))]
        public string PlaceOfBirth { get; set; }

        [MaxLength(256)]
        [Display(Name = nameof(HrPersons.EmailAddress), ResourceType = typeof(HrPersons))]
        public string EmailAddress { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersons.PersonPhoto), ResourceType = typeof(HrPersons))]
        public string PersonPhoto { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(HrPersons.AccountNumber), ResourceType = typeof(HrPersons))]
        public string AccountNumber { get; set; }

        [Display(Name = nameof(HrPersons.HireDate), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string HireDate { get; set; }

        [Display(Name = nameof(HrPersons.BirthDate), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string BirthDate { get; set; }

        [Display(Name = nameof(HrPersons.ProbationEndDate), ResourceType = typeof(HrPersons))]
        public string ProbationEndDate { get; set; }

        [Display(Name = nameof(HrPersons.ProbationLength), ResourceType = typeof(HrPersons))]
        public decimal? ProbationLength { get; set; }

        [Display(Name = nameof(HrPersons.NoOfTickets), ResourceType = typeof(HrPersons))]
        public decimal? NoOfTickets { get; set; }

        [Display(Name = nameof(HrPersons.TicketAfterYears), ResourceType = typeof(HrPersons))]
        public decimal? TicketAfterYears { get; set; }

        [Display(Name = nameof(HrPersons.TicketAmount), ResourceType = typeof(HrPersons))]
        public decimal? TicketAmount { get; set; }

        [Display(Name = nameof(HrPersons.NoticeLength), ResourceType = typeof(HrPersons))]
        public decimal? NoticeLength { get; set; }

        [Display(Name = nameof(HrPersons.HrOrganizationsDeptId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long HrOrganizationsDeptId { get; set; }

        public HrOrganizationsVM HrOrganizationsDept { get; set; }

        [Display(Name = nameof(HrPersons.HrOrganizationsBranchId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long HrOrganizationsBranchId { get; set; }

        public HrOrganizationsVM HrOrganizationsBranch { get; set; }

        [Display(Name = nameof(HrPersons.HrPersonSupervisorId), ResourceType = typeof(HrPersons))]
        public long? HrPersonSupervisorId { get; set; }

        public HrPersonsVM HrPersonSupervisor { get; set; }

        [Display(Name = nameof(HrPersons.PyPayrollTypeId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PyPayrollTypeId { get; set; }

        public PyPayrollTypesVM PyPayrollTypes { get; set; }
        #endregion

        #region FndLkps

        [Display(Name = nameof(HrPersons.GenderLkpId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long GenderLkpId { get; set; }

        public FndLookupValuesVM FndGenderLkp { get; set; }

        [Display(Name = nameof(HrPersons.PersonTypeLkpId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PersonTypeLkpId { get; set; }

        public FndLookupValuesVM FndPersonTypeLkp { get; set; }

        [Display(Name = nameof(HrPersons.NationalityLkpId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long NationalityLkpId { get; set; }

        public FndLookupValuesVM FndNationalityLkp { get; set; }

        [Display(Name = nameof(HrPersons.MaritalStatusLkpId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long MaritalStatusLkpId { get; set; }

        public FndLookupValuesVM FndMaritalStatusLkp { get; set; }

        [Display(Name = nameof(HrPersons.StatusLkpId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        [Display(Name = nameof(HrPersons.JobGradeLkpId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long JobGradeLkpId { get; set; }

        public FndLookupValuesVM FndJobGradeLkp { get; set; }

        [Display(Name = nameof(HrPersons.JobLkpId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long JobLkpId { get; set; }

        public FndLookupValuesVM FndJobLkp { get; set; }

        [Display(Name = nameof(HrPersons.PersonCategoryLkpId), ResourceType = typeof(HrPersons))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PersonCategoryLkpId { get; set; }

        public FndLookupValuesVM FndPersonCategoryLkp { get; set; }

        [Display(Name = nameof(HrPersons.FirstTitleLkpId), ResourceType = typeof(HrPersons))]
        public long? FirstTitleLkpId { get; set; }

        public FndLookupValuesVM FndFirstTitleLkp { get; set; }

        [Display(Name = nameof(HrPersons.SponserLkpId), ResourceType = typeof(HrPersons))]
        public long? SponserLkpId { get; set; }

        public FndLookupValuesVM FndSponserLkp { get; set; }

        [Display(Name = nameof(HrPersons.CountryOfBrithLkpId), ResourceType = typeof(HrPersons))]
        public long? CountryOfBrithLkpId { get; set; }

        public FndLookupValuesVM FndCountryOfBrithLkp { get; set; }

        [Display(Name = nameof(HrPersons.ProbationUnitLkpId), ResourceType = typeof(HrPersons))]
        public long? ProbationUnitLkpId { get; set; }

        public FndLookupValuesVM FndProbationUnitLkp { get; set; }

        [Display(Name = nameof(HrPersons.DestinationCountryLkpId), ResourceType = typeof(HrPersons))]
        public long? DestinationCountryLkpId { get; set; }

        public FndLookupValuesVM FndDestinationCountryLkp { get; set; }

        [Display(Name = nameof(HrPersons.TicketClassLkpId), ResourceType = typeof(HrPersons))]
        public long? TicketClassLkpId { get; set; }

        public FndLookupValuesVM FndTicketClassLkp { get; set; }

        [Display(Name = nameof(HrPersons.NoticeUnitLkpId), ResourceType = typeof(HrPersons))]
        public long? NoticeUnitLkpId { get; set; }

        public FndLookupValuesVM FndNoticeUnitLkp { get; set; }

        [Display(Name = nameof(HrPersons.PaymentTypeLkpId), ResourceType = typeof(HrPersons))]
        public long? PaymentTypeLkpId { get; set; }

        public FndLookupValuesVM FndPaymentTypeLkp { get; set; }

        [Display(Name = nameof(HrPersons.BankLkpId), ResourceType = typeof(HrPersons))]
        public long? BankLkpId { get; set; }

        public FndLookupValuesVM FndBankLkp { get; set; }
        #endregion

        #region VisaDetails

        [Display(Name = nameof(HrPersons.VisaNumber), ResourceType = typeof(HrPersons))]
        public string VisaNumber { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(HrPersons.Notes), ResourceType = typeof(HrPersons))]
        public string Notes { get; set; }

        [Display(Name = nameof(HrPersons.VisaCost), ResourceType = typeof(HrPersons))]
        public decimal? VisaCost { get; set; }

        [Display(Name = nameof(HrPersons.DateOfIssue), ResourceType = typeof(HrPersons))]
        public string DateOfIssue { get; set; }

        [Display(Name = nameof(HrPersons.DateOfExpiry), ResourceType = typeof(HrPersons))]
        public string DateOfExpiry { get; set; }

        [Display(Name = nameof(HrPersons.HrPersonId), ResourceType = typeof(HrPersons))]
        public long HrPersonId { get; set; }

        [Display(Name = nameof(HrPersons.VisaTypeLkpId), ResourceType = typeof(HrPersons))]
        public long VisaTypeLkpId { get; set; }

        public string VisaTypeLkp { get; set; }

        [Display(Name = nameof(HrPersons.PlaceOfIssueLkpId), ResourceType = typeof(HrPersons))]
        public long? PlaceOfIssueLkpId { get; set; }

        public string PlaceOfIssueLkp { get; set; }

        [Display(Name = nameof(HrPersons.IssuedByLkpId), ResourceType = typeof(HrPersons))]
        public long? IssuedByLkpId { get; set; }

        public string IssuedByLkp { get; set; }

        public string VisaDetailsListStr { get; set; }

        public ICollection<HrPersonVisaDetailsDto> VisaDetails => string.IsNullOrEmpty(VisaDetailsListStr) ?
                new List<HrPersonVisaDetailsDto>() : Helper<List<HrPersonVisaDetailsDto>>.Convert(VisaDetailsListStr);
        #endregion

        #region Passport Details

        [MaxLength(100)]
        [Display(Name = nameof(HrPersons.PassportNumber), ResourceType = typeof(HrPersons))]
        public string PassportNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersons.PlaceOfIssue), ResourceType = typeof(HrPersons))]
        public string PlaceOfIssue { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(HrPersons.Notes), ResourceType = typeof(HrPersons))]
        public string PassportNotes { get; set; }

        [Display(Name = nameof(HrPersons.DateOfIssue), ResourceType = typeof(HrPersons))]
        public string PassportDateOfIssue { get; set; }

        [Display(Name = nameof(HrPersons.DateOfExpiry), ResourceType = typeof(HrPersons))]
        public string PassportDateOfExpiry { get; set; }

        [Display(Name = nameof(HrPersons.PassportTypeLkpId), ResourceType = typeof(HrPersons))]
        public long PassportTypeLkpId { get; set; }

        [Display(Name = nameof(HrPersons.CountryOfIssueLkpId), ResourceType = typeof(HrPersons))]
        public long CountryOfIssueLkpId { get; set; }

        public string PassportTypeLkp { get; set; }

        public string CountryOfIssueLkp { get; set; }

        public string PassportDetailsListStr { get; set; }

        public ICollection<HrPersonPassportDetailsDto> PassportDetails => string.IsNullOrEmpty(PassportDetailsListStr) ?
        new List<HrPersonPassportDetailsDto>() : Helper<List<HrPersonPassportDetailsDto>>.Convert(PassportDetailsListStr);
        #endregion

        #region IdentityCard Details

        [MaxLength(3)]
        [Display(Name = nameof(HrPersons.Segment1), ResourceType = typeof(HrPersons))]
        public string Segment1 { get; set; }

        [MaxLength(4)]
        [Display(Name = nameof(HrPersons.Segment2), ResourceType = typeof(HrPersons))]
        public string Segment2 { get; set; }

        [MaxLength(7)]
        [Display(Name = nameof(HrPersons.Segment3), ResourceType = typeof(HrPersons))]
        public string Segment3 { get; set; }

        [MaxLength(1)]
        [Display(Name = nameof(HrPersons.Segment4), ResourceType = typeof(HrPersons))]
        public string Segment4 { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(HrPersons.IdNumber), ResourceType = typeof(HrPersons))]
        public string IdNumber { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(HrPersons.CardNo), ResourceType = typeof(HrPersons))]
        public string CardNo { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(HrPersons.IdentityCardNotes), ResourceType = typeof(HrPersons))]
        public string IdentityCardNotes { get; set; }

        public string IdentityCardsListStr { get; set; }

        public ICollection<HrPersonIdentityCardDto> IdentityCards => string.IsNullOrEmpty(IdentityCardsListStr) ?
        new List<HrPersonIdentityCardDto>() : Helper<List<HrPersonIdentityCardDto>>.Convert(IdentityCardsListStr);
        #endregion

        #region SalaryElements Details

        [Display(Name = nameof(HrPersons.PyElementId), ResourceType = typeof(HrPersons))]
        public long PyElementId { get; set; }

        [Display(Name = nameof(HrPersons.StartPeriodId), ResourceType = typeof(HrPersons))]
        public long StartPeriodId { get; set; }

        [Display(Name = nameof(HrPersons.EndPeriodId), ResourceType = typeof(HrPersons))]
        public long? EndPeriodId { get; set; }

        [Display(Name = nameof(HrPersons.Amount), ResourceType = typeof(HrPersons))]
        public decimal Amount { get; set; }

        public string SalaryElementsListStr { get; set; }

        public ICollection<HrPersonSalaryElementsDto> SalaryElements => string.IsNullOrEmpty(SalaryElementsListStr) ?
        new List<HrPersonSalaryElementsDto>() : Helper<List<HrPersonSalaryElementsDto>>.Convert(SalaryElementsListStr);
        #endregion

        public string AttachmentsListStr { get; set; }

        public ICollection<HrPersonAttachmentsDto> Attachments => string.IsNullOrEmpty(AttachmentsListStr) ?
           new List<HrPersonAttachmentsDto>() : Helper<List<HrPersonAttachmentsDto>>.Convert(AttachmentsListStr);
    }
}