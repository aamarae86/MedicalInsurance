using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto
{
    public class ManagerRefuseReasonInput : EntityDto<long>
    {
        [Required]
        public string ManagerRefuseResaon { get; set; }
    }
}
