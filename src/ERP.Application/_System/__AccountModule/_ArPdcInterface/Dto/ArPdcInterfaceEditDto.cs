using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ArPdcInterface.Dto
{
    public class ArPdcInterfaceEditDto : EntityDto<long>
    {
        [MaxLength(4000)]
        public string Notes { get; set; }

        public string MaturityDate { get; set; }

        public long? DepositBankAccountId { get; set; }
    }
}
