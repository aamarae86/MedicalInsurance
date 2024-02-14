using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    [AutoMapTo(typeof(IvStoreIssueTr))]
    public class IvStoreIssueDetailsEditDto: IvStoreIssueDetailsDto, IDetailRowStatus
    {
        public string rowStatus { get; set; }
    }
}
