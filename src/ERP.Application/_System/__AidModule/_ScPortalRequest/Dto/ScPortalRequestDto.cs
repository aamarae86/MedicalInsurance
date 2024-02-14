using Abp.AutoMapper;
using ERP._System.__AidModule._ScFndAidRequestType.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.Users.Dto;
using System;
using System.Collections.Generic;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    [AutoMapFrom(typeof(ScPortalRequest))]
    public class ScPortalRequestDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public int TenantId { get; set; }

        public string FinalDecision { get; set; }

        #region MainProperties
        public long PortalUsersId { get; set; }

        public string PortalRequestDate { get; set; }

        public string PortalRequestNumber { get; set; }

        public long AidRequestTypeId { get; set; }

        public string IncomeSource { get; set; }

        public decimal MonthlyIncomeAmount { get; set; }

        public decimal MonthlyOutcomeAmount { get; set; }

        public long SourceLkpId { get; set; }

        public long StatusLkpId { get; set; }

        public string Description { get; set; }
        #endregion

        #region Duplicated Properties From Portal User

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string IdNumber { get; set; }

        public string IdExpirationDate { get; set; }

        public string WifeHusbandName1 { get; set; }

        public string IdNumberWifeHusband1 { get; set; }

        public string WifeName2 { get; set; }

        public string IdNumberWife2 { get; set; }

        public string WifeName3 { get; set; }

        public string IdNumberWife3 { get; set; }

        public string WifeName4 { get; set; }

        public string IdNumberWife4 { get; set; }

        public string Nationality { get; set; }

        public string MobileNumber1 { get; set; }

        public string MobileNumber2 { get; set; }

        public string JobDescription { get; set; }

        public string Address { get; set; }

        public string MaritalStatus { get; set; }

        public string Qualification { get; set; }
        #endregion

        public long? ResearcherId { get; set; }

        public PortalUserDto PortalUser { get; set; }

        public ScFndAidRequestTypeDto AidRequestType { get; set; }

        public UserDto Researcher { get; set; }

        public FndLookupValuesDto FndLookupValuesSourceLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesStatusLkp { get; set; }

        public ICollection<ScPortalRequestAttachmentDto> Attachments { get; set; }

        public ICollection<ScPortalRequestDutiesDto> RequestDuties { get; set; }

        public ICollection<ScPortalRequestIncomeDto> RequestIncomes { get; set; }
    }
}
