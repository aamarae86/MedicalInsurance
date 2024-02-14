using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__CRM._Projects;
using ERP._System.__CRM.Services;
using ERP._System._Projects;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmServices.Dto
{
    [AutoMap(typeof(CrmServices))]
    public class CrmServicesEditDto : CrmServicesDto
    {
    }
}
