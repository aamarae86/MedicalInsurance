using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._FndUserRelatives.Dto
{
    [AutoMap(typeof(FndUserRelatives))]
    public class FndUserRelativesDto: IDetailRowStatus
    {
        public long? id { get; set; }

        public string name { get; set; }

        public string idNumber { get; set; }


        public long genderLkpId { get; set; }

        public long relativesTypeLkpId { get; set; }

        public long? nationalityLkpId { get; set; }

        public long? qualificationLkpId { get; set; }


        public string genderLkp { get; set; }

        public string relativesTypeLkp { get; set; }

        public string nationalityLkp { get; set; }

        public string qualificationLkp { get; set; }
        public string rowStatus { get ; set ; }
    }
}
