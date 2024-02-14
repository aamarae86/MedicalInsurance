using Abp.Domain.Entities;
using ERP._System.__AidModule._PortalUserData;
using ERP._System.__AidModule._ScFndAidRequestType;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__AidModule._ScPortalRequestVisited;
using ERP._System._FndLookupValues;
using ERP.Authorization.Users;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScPortalRequest
{
    public class ScPortalRequest : PostAuditedEntity<long>, IMustHaveTenant
    {

        #region MainProperties

        public long PortalUsersId { get; protected set; }

        public DateTime PortalRequestDate { get; protected set; }

        [MaxLength(30)]
        public string PortalRequestNumber { get; protected set; }

        [MaxLength(1000)]
        public string FinalDecision { get; protected set; }

        public long AidRequestTypeId { get; protected set; }

        public long SourceLkpId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [MaxLength(4000)]
        public string Description { get; protected set; }
        #endregion

        #region Duplicated Properties From Portal User

        public string Name { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string City { get; protected set; }

        public string Region { get; protected set; }

        [MaxLength(50)]
        public string IdNumber { get; protected set; }

        public DateTime IdExpirationDate { get; protected set; }

        [MaxLength(200)]
        public string WifeHusbandName1 { get; protected set; }

        [MaxLength(50)]
        public string IdNumberWifeHusband1 { get; protected set; }

        [MaxLength(200)]
        public string WifeName2 { get; protected set; }

        [MaxLength(50)]
        public string IdNumberWife2 { get; protected set; }

        [MaxLength(200)]
        public string WifeName3 { get; protected set; }

        [MaxLength(50)]
        public string IdNumberWife3 { get; protected set; }

        [MaxLength(200)]
        public string WifeName4 { get; protected set; }

        [MaxLength(50)]
        public string IdNumberWife4 { get; protected set; }

        public string Nationality { get; protected set; }

        [MaxLength(50)]
        public string MobileNumber1 { get; protected set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; protected set; }

        [MaxLength(200)]
        public string JobDescription { get; protected set; }

        [MaxLength(4000)]
        public string Address { get; protected set; }

        public string MaritalStatus { get; protected set; }

        public string Qualification { get; protected set; }
        #endregion

        public long? ResearcherId { get; protected set; }

        public int TenantId { get; set; }


        [ForeignKey(nameof(ResearcherId))]
        public User Researcher { get; protected set; }

        [ForeignKey(nameof(PortalUsersId))]
        public PortalUser PortalUser { get; protected set; }

        [ForeignKey(nameof(AidRequestTypeId))]
        public ScFndAidRequestType AidRequestType { get; protected set; }

        [ForeignKey(nameof(SourceLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesSourceLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        public virtual ICollection<ScPortalRequestAttachment> Attachments { get; protected set; }
        public virtual ICollection<ScPortalRequestStudy> ScPortalRequestStudy { get; protected set; }
        public virtual ICollection<ScPortalRequestVisited> ScPortalRequestVisited { get; protected set; }
        public virtual ICollection<ScPortalRequestIncome> ScPortalRequestIncome { get; protected set; }
        public virtual ICollection<ScPortalRequestDuties> ScPortalRequestDuties { get; protected set; }
        public virtual ICollection<ScMaintenanceTechnicalReport> ScMaintenanceTechnicalReport { get; protected set; }

        protected ScPortalRequest() { }

        public void SetSharedProps(PortalUserData currentPortalUser)
        {
            this.IdNumber = currentPortalUser.PortalUser.IdNumber;
            this.IdNumberWifeHusband1 = currentPortalUser.PortalUser.IdNumberWifeHusband1;
            this.IdNumberWife2 = currentPortalUser.PortalUser.IdNumberWife2;
            this.IdNumberWife3 = currentPortalUser.PortalUser.IdNumberWife3;
            this.IdNumberWife4 = currentPortalUser.PortalUser.IdNumberWife4;
            this.WifeHusbandName1 = currentPortalUser.PortalUser.WifeHusbandName1;
            this.WifeName2 = currentPortalUser.PortalUser.WifeName2;
            this.WifeName3 = currentPortalUser.PortalUser.WifeName3;
            this.WifeName4 = currentPortalUser.PortalUser.WifeName4;
            this.IdExpirationDate = currentPortalUser.IdExpirationDate;
            this.Address = currentPortalUser.Address;
            this.PhoneNumber = currentPortalUser.PhoneNumber;
            this.MobileNumber1 = currentPortalUser.MobileNumber1;
            this.MobileNumber2 = currentPortalUser.MobileNumber2;
            this.Name = currentPortalUser.PortalUser.Name;
            this.Region = currentPortalUser.Region;
            this.JobDescription = currentPortalUser.JobDescription;
            this.City = currentPortalUser.CityFndLookupValues.NameAr;
            this.Nationality = currentPortalUser.PortalUser.NationalityFndLookupValues.NameAr;
            this.Qualification = currentPortalUser.QualificationFndLookupValues == null ? null : currentPortalUser.QualificationFndLookupValues.NameAr;
            this.MaritalStatus = currentPortalUser.MaritalStatusFndLookupValues.NameAr;
        }

        public void SetIncomesCollection(ICollection<ScPortalRequestIncome> scPortalRequestIncomes)
        {
            this.ScPortalRequestIncome = scPortalRequestIncomes;
        }

        public void SetDutiesCollection(ICollection<ScPortalRequestDuties> scPortalRequestDuties)
            => this.ScPortalRequestDuties = scPortalRequestDuties;

    }
}
