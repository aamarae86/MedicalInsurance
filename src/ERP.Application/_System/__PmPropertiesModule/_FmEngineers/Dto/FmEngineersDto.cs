using Abp.Application.Services.Dto;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._FmEngineers.Dto
{
    public class FmEngineersDto : AuditedEntityDto<long>
    {
        [MaxLength(30)]
        public string EngineerNumber { get; set; }

        [MaxLength(100)]
        public string EngineerName { get; set; }

        public long StatusLkpId { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        [MaxLength(50)]
        public string Mobile1 { get; set; }

        [MaxLength(50)]
        public string Mobile2 { get; set; }

        public string HireDate { get; set; }

        public long? HrPersonsId { get; set; }

        public string FndStatusLkpNameAr { get; set; }

        public string FndStatusLkpNameEn { get; set; }

        public string EmployeeName { get; set; }

        public string BirthDate { get; set; }

        public string GenderAr { get; set; }

        public string GenderEn { get; set; }

        public string NationalityAr { get; set; }

        public string NationalityEn { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public HrPersonsDto HrPersons { get; set; }
    }
}
