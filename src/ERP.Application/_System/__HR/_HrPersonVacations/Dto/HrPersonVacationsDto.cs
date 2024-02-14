using Abp.AutoMapper;
using ERP._System.__HR._HrAbsencesTypes.Dto;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrPersonVacations.Dto
{
    [AutoMap(typeof(HrPersonVacations))]
    public class HrPersonVacationsDto : PostAuditedEntityDto<long>
    {
        [MaxLength(30)]
        public string OperationNumber { get; set; }

        public decimal VacationBalance { get; set; }

        public string OperationDate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public long StatusLkpId { get; set; }

        public long HrVacationsTypeId { get; set; }

        public long HrPersonId { get; set; }

        public int NoOfDays { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public HrVacationsTypesDto HrVacationsTypes { get; set; }

        public HrPersonsDto HrPersons { get; set; }
    }
}
