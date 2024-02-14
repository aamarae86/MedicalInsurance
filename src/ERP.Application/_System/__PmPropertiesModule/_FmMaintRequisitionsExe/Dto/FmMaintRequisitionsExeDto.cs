using ERP._System.__PmPropertiesModule._FmContracts.Dto;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe.Dto
{
    public class FmMaintRequisitionsExeDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public long StatusLkpId { get; set; }

        public long ExecuteTypeLkpId { get; set; }

        public long? EngineerId { get; set; }

        public long? FmContractsId { get; set; }

        public long? FmContractVisitsId { get; set; }

        public long? FmMaintRequisitionsHdrId { get; set; }

        public string ExecuteDate { get; set; }

        public string EngineerName { get; set; }
        
        public string ExecuteTime { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public string FmContractVisitNumber { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndExecuteTypeLkp { get; set; }

        public FmEngineersDto FmEngineers { get; set; }

        public FmContractsDto FmContracts { get; set; }

        public FmContractVisitsDto FmContractVisits { get; set; }

        public FmMaintRequisitionsHdrDto FmMaintRequisitionsHdr { get; set; }
    }
}
