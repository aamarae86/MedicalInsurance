using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersons.Dto
{
    [AutoMap(typeof(HrPersons))]
    public class HrPersonsCreateDto
    {
        #region MainProps


        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string Region { get; set; }

        [MaxLength(200)]
        public string ResidencePlace { get; set; }

        [MaxLength(30)]
        public string EmployeeNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        public string FatherName { get; set; }

        [MaxLength(200)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string PlaceOfBirth { get; set; }

        [MaxLength(256)]
        public string EmailAddress { get; set; }

        [MaxLength(200)]
        public string PersonPhoto { get; set; }

        [MaxLength(50)]
        public string AccountNumber { get; set; }

        public string HireDate { get; set; }

        public string BirthDate { get; set; }

        public string ProbationEndDate { get; set; }

        public decimal? ProbationLength { get; set; }

        public decimal? NoOfTickets { get; set; }

        public decimal? TicketAfterYears { get; set; }

        public decimal? TicketAmount { get; set; }

        public decimal? NoticeLength { get; set; }

        public long HrOrganizationsDeptId { get; set; }

        public long HrOrganizationsBranchId { get; set; }

        public long? HrPersonSupervisorId { get; set; }

        public long PyPayrollTypeId { get; set; }

        #endregion

        #region FndLkps
        public long GenderLkpId { get; set; }

        public long PersonTypeLkpId { get; set; }

        public long NationalityLkpId { get; set; }

        public long MaritalStatusLkpId { get; set; }

        public long StatusLkpId { get; set; }

        public long JobGradeLkpId { get; set; }

        public long JobLkpId { get; set; }

        public long PersonCategoryLkpId { get; set; }

        public long? FirstTitleLkpId { get; set; }

        public long? SponserLkpId { get; set; }

        public long? CountryOfBrithLkpId { get; set; }

        public long? ProbationUnitLkpId { get; set; }

        public long? DestinationCountryLkpId { get; set; }

        public long? TicketClassLkpId { get; set; }

        public long? NoticeUnitLkpId { get; set; }

        public long? PaymentTypeLkpId { get; set; }

        public long? BankLkpId { get; set; }

        #endregion

        public ICollection<HrPersonVisaDetailsDto> VisaDetails { get; set; }
        public ICollection<HrPersonPassportDetailsDto> PassportDetails { get; set; }
        public ICollection<HrPersonIdentityCardDto> IdentityCards { get; set; }
        public ICollection<HrPersonSalaryElementsDto> SalaryElements { get; set; }
        public ICollection<HrPersonAttachmentsDto> Attachments { get; set; }

    }
}
