using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._FndUserRelatives;
using ERP._System.__AidModule._FndUserRelatives.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._FndUsers.Dto
{
    [AutoMap(typeof(FndUsers))]
    [AutoMapTo(typeof(FndUsers))]
    [AutoMapFrom(typeof(FndUsers))]
    public class FndUsersDto : EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string Name { get; set; }

        public string Region { get; set; }

        public string JobDescription { get; set; }

        public string Address { get; set; }

        public string WifeHusbandName1 { get; set; }

        public string WifeName2 { get; set; }

        public string WifeName3 { get; set; }

        public string WifeName4 { get; set; }

        public string IdNumber { get; set; }

        public string IdNumberWifeHusband1 { get; set; }

        public string IdNumberWife2 { get; set; }

        public string IdNumberWife3 { get; set; }
        public string IdNumberWife4 { get; set; }

        public DateTime IdExpirationDate { get; set; }
        public string IdExpirationDateStr { get; set; }

        public DateTime BrithDate { get; set; }
        public string BrithDateStr { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber1 { get; set; }

        public string MobileNumber2 { get; set; }

        public long GenderLkpId { get; set; }

        public long CityLkpId { get; set; }

        public long NationalityLkpId { get; set; }

        public long MaritalStatusLkpId { get; set; }

        public long? QualificationLkpId { get; set; }

        public long? PortalUsersId { get; set; }

        public FndLookupValuesDto GenderFndLookupValues { get; set; }

        public FndLookupValuesDto CityFndLookupValues { get; set; }

        public FndLookupValuesDto NationalityFndLookupValues { get; set; }

        public FndLookupValuesDto MaritalStatusFndLookupValues { get; set; }

        public FndLookupValuesDto QualificationFndLookupValues { get; set; }


        public List<FndUserRelativesDto> FndUserRelativesList { get; set; }


        public bool IdNumbersRepeated { get; set; }

    }
}
