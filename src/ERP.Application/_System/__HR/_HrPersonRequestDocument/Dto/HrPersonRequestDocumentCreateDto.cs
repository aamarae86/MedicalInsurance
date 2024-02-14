using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument.Dto
{
    [AutoMap(typeof(HrPersonRequestDocument))]
    public class HrPersonRequestDocumentCreateDto
    {
        public string RequestNumber { get; set; }
        public long RequestTypeId { get; set; }
        public long HrPersonId { get; set; }
        public string DocRequestDate { get; set; }
        public string Notes { get;  set; }
        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_HrPersonPermissionStatus);
    }
}
