using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations;
using System;

namespace ERP._System.__SpGuarantees._SpCaseOperations.Dto
{
    [AutoMap(typeof(SpCaseOperations))]
    public class SpCaseOperationsDto : EntityDto<long>
    {
        public DateTime OperationDate { get; set; }

        public string OperationDateStr { get; set; }

        public long ReasonLkpId { get; set; }

        public long OperationTypeLkpId { get; set; }

        public long SpContractDetailsId { get; set; }
    }
}
