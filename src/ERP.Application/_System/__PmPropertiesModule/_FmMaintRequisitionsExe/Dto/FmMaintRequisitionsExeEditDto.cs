using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe.Dto
{
    [AutoMap(typeof(FmMaintRequisitionsExe))]
    public class FmMaintRequisitionsExeEditDto : EntityDto<long>
    {
        public long ExecuteTypeLkpId { get; set; }

        public long? EngineerId { get; set; }

        public long? FmContractsId { get; set; }

        public long? FmContractVisitsId { get; set; }

        public long? FmMaintRequisitionsHdrId { get; set; }

        [Required]
        public string ExecuteDate { get; set; }

        [Required]
        public string ExecuteTime { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }
    }
}
