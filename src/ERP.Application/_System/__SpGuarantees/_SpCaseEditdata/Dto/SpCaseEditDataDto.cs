using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace ERP._System.__SpGuarantees._SpCaseEditData.Dto
{
    [AutoMap(typeof(SpCaseEditData))]
    public class SpCaseEditDataDto : EntityDto<long>
    {
        //public DateTime OperationDate { get; set; }

        //public string OperationDateStr { get; set; }

        //public long ReasonLkpId { get; set; }

        //public long OperationTypeLkpId { get; set; }

        //public long SpContractDetailsId { get; set; }
    }
}
