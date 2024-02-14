using Abp.AutoMapper;
using ERP._System.__CRM._Projects;
using ERP._System.__CRM.Services;
using ERP._System._Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__CRM._CrmServices.Dto
{
    [AutoMap(typeof(CrmServices))]
    public class CrmServicesCreateDto: CrmServicesDto
    {
       
    }
}
