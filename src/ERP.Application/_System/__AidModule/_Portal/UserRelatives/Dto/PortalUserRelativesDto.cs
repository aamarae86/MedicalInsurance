using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System._Portal.UserRelatives.Dto
{
    [AutoMap(typeof(PortalUserRelatives))]
    public class PortalUserRelativesDto : EntityDto<long>, IDetailRowStatus
    {
        [Required]
        public long PortalUserDataId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public long GenderLkpId { get; set; }

        public long? RelativesTypeLkpId { get; set; }

        public long? NationalityLkpId { get; set; }

        public long? QualificationLkpId { get; set; }

        public long? MaritalStatusLkpId { get; set; }

        public string Employer { get; set; }

        public string Notes { get; set; }

        [MaxLength(50)]
        public string IdNumber { get; set; }

        public string genderLkp { get; set; }

        public string relativesTypeLkp { get; set; }

        public string nationalityLkp { get; set; }

        public string qualificationLkp { get; set; }

        public string maritalStatusLkp { get; set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }
}
