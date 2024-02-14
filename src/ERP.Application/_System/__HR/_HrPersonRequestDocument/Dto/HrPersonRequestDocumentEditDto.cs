﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument.Dto
{
    [AutoMap(typeof(HrPersonRequestDocument))]
    public class HrPersonRequestDocumentEditDto : EntityDto<long>
    {
        public string RequestNumber { get; set; }
        public long RequestTypeId { get; set; }
        public long HrPersonId { get; set; }
        public string DocRequestDate { get; set; }
        public string Notes { get;  set; }

    }
}