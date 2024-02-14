using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    [AutoMapTo(typeof(PoPurchaseOrderTr))]
    public class PoPurchaseOrderDetailsEditDto: PoPurchaseOrderDetailsDto, IDetailRowStatus
    {
        public string rowStatus { get; set; }
    }
}
