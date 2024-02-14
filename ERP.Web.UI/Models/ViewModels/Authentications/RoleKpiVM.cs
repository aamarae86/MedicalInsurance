using ERP.Front.Helpers.Core;
using ERP.Roles.Dto;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Authentications
{
    public class RoleKpiVM : BaseAuditedEntityVM<long>
    {
        public string EncId { get; set; }
        public FndLookupValuesVM FndKpisLkp { get; set; }
        public string AbpKpiRoleStr { get; set; }
        public ICollection<AbpKpiRoleDto> RoleKpi => string.IsNullOrEmpty(AbpKpiRoleStr) ?
           new List<AbpKpiRoleDto>() : Helper<List<AbpKpiRoleDto>>.Convert(AbpKpiRoleStr);
    }
}