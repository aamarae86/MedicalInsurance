using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__HR._HrOrganizations;
using ERP._System.__HR._HrPersons._HrPersonIdentityCard;
using ERP._System.__HR._HrPersons._HrPersonPassportDetails;
using ERP._System.__HR._HrPersons._HrPersonSalaryElements;
using ERP._System.__HR._HrPersons._HrPersonVisaDetails;
using ERP._System.__HR._HrPersonsAdditionHd._HrPersonsAdditionTr;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._HrPersonVacations;
using ERP._System.__HR._PyPayrollOperations;
using ERP._System.__HR._PyPayrollTypes;
using ERP._System.__PmPropertiesModule._FmEngineers;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersons
{
    public class HrPersons : AuditedEntity<long>, IMustHaveTenant
    {
        #region MainProps

        [Required]
        [MaxLength(30)]
        public string EmployeeNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string FirstName { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string FatherName { get; protected set; }

        [MaxLength(200)]
        public string LastName { get; protected set; }

        [MaxLength(200)]
        public string PlaceOfBirth { get; protected set; }

        [MaxLength(256)]
        public string EmailAddress { get; protected set; }

        [MaxLength(200)]
        public string PersonPhoto { get; protected set; }

        [MaxLength(50)]
        public string AccountNumber { get; protected set; }

        [MaxLength(50)]
        public string PhoneNumber { get; protected set; }

        [MaxLength(200)]
        public string Region { get; protected set; }

        [MaxLength(200)]
        public string ResidencePlace { get; protected set; }

        public DateTime HireDate { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public DateTime? ProbationEndDate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? ProbationLength { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? NoOfTickets { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? TicketAfterYears { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? TicketAmount { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? NoticeLength { get; protected set; }

        public long HrOrganizationsDeptId { get; protected set; }

        [ForeignKey(nameof(HrOrganizationsDeptId)), Column(Order = 0)]
        public HrOrganizations HrOrganizationsDept { get; protected set; }

        public long HrOrganizationsBranchId { get; protected set; }

        [ForeignKey(nameof(HrOrganizationsBranchId)), Column(Order = 1)]
        public HrOrganizations HrOrganizationsBranch { get; protected set; }

        public long? HrPersonSupervisorId { get; protected set; }

        [ForeignKey(nameof(HrPersonSupervisorId))]
        public HrPersons HrPersonSupervisor { get; protected set; }

        public long PyPayrollTypeId { get; protected set; }

        [ForeignKey(nameof(PyPayrollTypeId))]
        public PyPayrollTypes PyPayrollTypes { get; protected set; }
        #endregion

        #region FndLkps
        public long GenderLkpId { get; protected set; }

        [ForeignKey(nameof(GenderLkpId)), Column(Order = 0)]
        public FndLookupValues FndGenderLkp { get; protected set; }

        public long PersonTypeLkpId { get; protected set; }

        [ForeignKey(nameof(PersonTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndPersonTypeLkp { get; protected set; }

        public long NationalityLkpId { get; protected set; }

        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 2)]
        public FndLookupValues FndNationalityLkp { get; protected set; }

        public long MaritalStatusLkpId { get; protected set; }

        [ForeignKey(nameof(MaritalStatusLkpId)), Column(Order = 3)]
        public FndLookupValues FndMaritalStatusLkp { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 4)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        public long JobGradeLkpId { get; protected set; }

        [ForeignKey(nameof(JobGradeLkpId)), Column(Order = 5)]
        public FndLookupValues FndJobGradeLkp { get; protected set; }

        public long JobLkpId { get; protected set; }

        [ForeignKey(nameof(JobLkpId)), Column(Order = 6)]
        public FndLookupValues FndJobLkp { get; protected set; }

        public long PersonCategoryLkpId { get; protected set; }

        [ForeignKey(nameof(PersonCategoryLkpId)), Column(Order = 7)]
        public FndLookupValues FndPersonCategoryLkp { get; protected set; }

        public long? FirstTitleLkpId { get; protected set; }

        [ForeignKey(nameof(FirstTitleLkpId)), Column(Order = 8)]
        public FndLookupValues FndFirstTitleLkp { get; protected set; }

        public long? SponserLkpId { get; protected set; }

        [ForeignKey(nameof(SponserLkpId)), Column(Order = 9)]
        public FndLookupValues FndSponserLkp { get; protected set; }

        public long? CountryOfBrithLkpId { get; protected set; }

        [ForeignKey(nameof(CountryOfBrithLkpId)), Column(Order = 10)]
        public FndLookupValues FndCountryOfBrithLkp { get; protected set; }

        public long? ProbationUnitLkpId { get; protected set; }

        [ForeignKey(nameof(ProbationUnitLkpId)), Column(Order = 11)]
        public FndLookupValues FndProbationUnitLkp { get; protected set; }

        public long? DestinationCountryLkpId { get; protected set; }

        [ForeignKey(nameof(DestinationCountryLkpId)), Column(Order = 12)]
        public FndLookupValues FndDestinationCountryLkp { get; protected set; }

        public long? TicketClassLkpId { get; protected set; }

        [ForeignKey(nameof(TicketClassLkpId)), Column(Order = 13)]
        public FndLookupValues FndTicketClassLkp { get; protected set; }

        public long? NoticeUnitLkpId { get; protected set; }

        [ForeignKey(nameof(NoticeUnitLkpId)), Column(Order = 13)]
        public FndLookupValues FndNoticeUnitLkp { get; protected set; }

        public long? PaymentTypeLkpId { get; protected set; }

        [ForeignKey(nameof(PaymentTypeLkpId)), Column(Order = 14)]
        public FndLookupValues FndPaymentTypeLkp { get; protected set; }

        public long? BankLkpId { get; protected set; }

        [ForeignKey(nameof(BankLkpId)), Column(Order = 15)]
        public FndLookupValues FndBankLkp { get; protected set; }
        #endregion

        public virtual ICollection<FmEngineers> FmEngineers { get; protected set; }
        public virtual ICollection<HrPersonsAdditionTr> HrPersonsAdditionTr { get; protected set; }
        public virtual ICollection<HrPersonVisaDetails> HrPersonVisaDetails { get; protected set; }
        public virtual ICollection<HrPersonPassportDetails> HrPersonPassportDetails { get; protected set; }
        public virtual ICollection<HrPersonIdentityCard> HrPersonIdentityCard { get; protected set; }
        public virtual ICollection<HrPersonsDeductionTr> HrPersonsDeductionTr { get; protected set; }
        public virtual ICollection<HrPersonSalaryElements> HrPersonSalaryElements { get; protected set; }
        public virtual ICollection<HrPersonVacations> HrPersonVacations { get; protected set; }
        public virtual ICollection<PyPayrollOperations> PyPayrollOperations { get; protected set; }
        public virtual ICollection<PyPayrollOperationPersons> PyPayrollOperationPersons { get; protected set; }
        public virtual ICollection<HrPersonAttachments> HrPersonAttachments { get; protected set; }

        public int TenantId { get; set; }

        public string GetFullName() => $"{this.FirstName} {this.FatherName} {this.LastName}";

    }
}
