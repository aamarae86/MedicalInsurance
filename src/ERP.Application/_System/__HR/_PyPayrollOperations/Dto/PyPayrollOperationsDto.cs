using AutoMapper;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System.__HR._PyPayrollTypes.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._PyPayrollOperations.Dto
{
    [AutoMap(typeof(PyPayrollOperations))]
    public class PyPayrollOperationsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(20)]
        public string OperationNumber { get; set; }

        public string OperationDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long StatusLkpId { get; set; }

        public long PeriodId { get; set; }

        public long PyPayrollTypeId { get; set; }

        public long? HrPersonId { get; set; }

        public long? JobLkpId { get; set; }

        public decimal PayrollTotalValue { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndJobLkp { get; set; }

        public GlPeriodsDetailsDto Periods { get; set; }

        public HrPersonsDto HrPersons { get; set; }

        public PyPayrollTypesDto PyPayrollTypes { get; set; }

    }
}
