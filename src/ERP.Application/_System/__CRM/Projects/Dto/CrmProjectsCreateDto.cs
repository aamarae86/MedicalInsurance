using Abp.AutoMapper;
using ERP._System._Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__CRM._CrmProjects.Dto
{
    [AutoMap(typeof(CrmProjects))]
    public class CrmProjectsCreateDto
    {
        public string ProjectDate { get; set; }
        [StringLength(200)]
        public string ProjectNameAr { get; set; }
        [StringLength(200)]
        public string ProjectNameEn { get; set; }
        [StringLength(4000)]
        public string ProjectAdressAr { get; set; }
        [StringLength(4000)]
        public string ProjectAdressEn { get; set; }
        [StringLength(4000)]
        public string ContentAr { get; set; }
        [StringLength(4000)]
        public string ContentEn { get; set; }
        [StringLength(500)]
        public string Filepath { get; set; }
    }
}
