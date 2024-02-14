using Abp.AutoMapper;
using ERP._System.__HR._DocumentRequestType.Dto;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument.Dto
{

    [AutoMap(typeof(HrPersonRequestDocument))]
    public class HrPersonRequestDocumentDto : PostAuditedEntityDto<long>
    {
        public string RequestNumber { get;  set; }
        public long RequestTypeId { get;  set; }
        public long HrPersonId { get;  set; }
        public long StatusLkpId { get;  set; }
        public string DocRequestDate { get; set; }
        public string Notes { get;  set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }
        public DocumentRequestTypeDto DocumentRequestType { get; set; }

        public HrPersonsDto HrPersons { get; set; }






    }
}
