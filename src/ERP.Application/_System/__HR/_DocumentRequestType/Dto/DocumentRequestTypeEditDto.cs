﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersonRequestDocument;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._DocumentRequestType.Dto
{
    [AutoMap(typeof(DocumentRequestType))]
    public class DocumentRequestTypeEditDto : EntityDto<long>
    {
        public string DocumentRequestName { get; set; }
    }
}