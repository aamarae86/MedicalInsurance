using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmSupervisors.Dto
{
    [AutoMap(typeof(TmSupervisors))]
    public class CreateTmSupervisorsDto
    {
        [MaxLength(30)]
        public string SupervisorNumber { get; set; }

        [MaxLength(200)]
        public string SupervisorName { get; set; }

        public long? SourceLkpId => 592;

        public long? StatusLkpId { get; set; }
    }
}
