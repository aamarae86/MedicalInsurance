using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._FndUserRelatives;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AidModule._FndUsers
{
    public class FndUsers : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [Required]
        [MaxLength(200)]
        public string Name { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string Region { get; protected set; }

        [MaxLength(200)]
        public string JobDescription { get; protected set; }

        [MaxLength(4000)]
        public string Address { get; protected set; }

        [MaxLength(200)]
        public string WifeHusbandName1 { get; protected set; }

        [MaxLength(200)]
        public string WifeName2 { get; protected set; }

        [MaxLength(200)]
        public string WifeName3 { get; protected set; }

        [MaxLength(200)]
        public string WifeName4 { get; protected set; }

        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        public string IdNumber { get; protected set; }

        [MaxLength(15)]
        [MinLength(15)]
        public string IdNumberWifeHusband1 { get; protected set; }

        [MaxLength(15)]
        [MinLength(15)]
        public string IdNumberWife2 { get; protected set; }

        [MaxLength(15)]
        [MinLength(15)]
        public string IdNumberWife3 { get; protected set; }

        [MaxLength(15)]
        [MinLength(15)]
        public string IdNumberWife4 { get; protected set; }

        public DateTime IdExpirationDate { get; protected set; }

        public DateTime BrithDate { get; protected set; }

        [MaxLength(50)]
        public string PhoneNumber { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string MobileNumber1 { get; protected set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; protected set; }

        public long GenderLkpId { get; protected set; }

        public long CityLkpId { get; protected set; }

        public long NationalityLkpId { get; protected set; }

        public long MaritalStatusLkpId { get; protected set; }

        public long? QualificationLkpId { get; protected set; }

        public long? PortalUsersId { get; protected set; }

        public int TenantId { get; set; }


        [ForeignKey(nameof(GenderLkpId)), Column(Order = 0)]
        public FndLookupValues GenderFndLookupValues { get; protected set; }

        [ForeignKey(nameof(CityLkpId)), Column(Order = 1)]
        public FndLookupValues CityFndLookupValues { get; protected set; }

        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 2)]
        public FndLookupValues NationalityFndLookupValues { get; protected set; }

        [ForeignKey(nameof(MaritalStatusLkpId)), Column(Order = 3)]
        public FndLookupValues MaritalStatusFndLookupValues { get; protected set; }

        [ForeignKey(nameof(QualificationLkpId)), Column(Order = 4)]
        public FndLookupValues QualificationFndLookupValues { get; protected set; }

        public virtual ICollection<FndUserRelatives> FndUserRelatives { get; protected set; }
        public virtual ICollection<ScCampainsDetail> ScCampainsDetail { get; protected set; }
        

        #endregion

        protected FndUsers()
        {

        }
        protected FndUsers(string name, string region, string jobDescription, string address,
           string WifeHusbandName1, string wifeName2, string wifeName3, string wifeName4,
           string idNumber, string IdNumberWifeHusband1, string idNumberWife2, string idNumberWife4,
           DateTime idExpirationDate, DateTime brithDate, string phoneNumber, string mobileNumber1,
                string mobileNumber2, long genderLkpId, long cityLkpId, long nationalityLkpId, long maritalStatusLkpId,
             long? qualificationLkpId, long? portalUsersId = null)
        {
            this.Name = name;
            this.Region = region;
            this.JobDescription = jobDescription;
            this.Address = address;
            this.WifeHusbandName1 = WifeHusbandName1;
            this.WifeName2 = wifeName2;
            this.WifeName3 = wifeName3; this.WifeName4 = wifeName4;
            this.IdNumber = idNumber; this.IdNumberWifeHusband1 = IdNumberWifeHusband1; this.IdNumberWife2 = idNumberWife2;
            this.IdNumberWife2 = idNumberWife2; this.IdNumberWife4 = idNumberWife4;
            this.IdExpirationDate = idExpirationDate; this.BrithDate = brithDate;
            this.PhoneNumber = phoneNumber; this.MobileNumber1 = mobileNumber1; this.MobileNumber2 = mobileNumber2;
            this.GenderLkpId = genderLkpId; this.CityLkpId = cityLkpId; this.NationalityLkpId = nationalityLkpId;
            this.MaritalStatusLkpId = maritalStatusLkpId; this.QualificationLkpId = qualificationLkpId; this.PortalUsersId = portalUsersId;
        }

        public static FndUsers Create(string name, string region, string jobDescription, string address,
           string WifeHusbandName1, string wifeName2, string wifeName3, string wifeName4,
           string idNumber, string IdNumberWifeHusband1, string idNumberWife2, string idNumberWife4,
           DateTime idExpirationDate, DateTime brithDate, string phoneNumber, string mobileNumber1,
                string mobileNumber2, long genderLkpId, long cityLkpId, long nationalityLkpId, long maritalStatusLkpId,
             long? qualificationLkpId, long? portalUsersId = null)
        {
            return new FndUsers(name, region, jobDescription, address,
            WifeHusbandName1, wifeName2, wifeName3, wifeName4,
            idNumber, IdNumberWifeHusband1, idNumberWife2, idNumberWife4,
            idExpirationDate, brithDate, phoneNumber, mobileNumber1,
                 mobileNumber2, genderLkpId, cityLkpId, nationalityLkpId, maritalStatusLkpId,
              qualificationLkpId, portalUsersId);
        }
    }
}
