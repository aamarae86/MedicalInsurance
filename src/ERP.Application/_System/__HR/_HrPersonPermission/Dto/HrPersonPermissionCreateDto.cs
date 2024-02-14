using Abp.AutoMapper;
using ERP._System.__HR._HrPermissionType;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__HR._HrPersonPermission.Dto
{
    [AutoMap(typeof(HrPersonPermission))]
  public class HrPersonPermissionCreateDto
    {
        [MaxLength(30)]
        public string OperationNumber { get; set; }
        public long PermissionTypeId { get; set; }
        public string PermissionDate { get; set; }
        public decimal FromTime { get; set; }
        public decimal EndTime { get; set; }
        public decimal TotalPermission { get; set; }
        public string permissionDetails { get; set; }
        public long HrPersonId { get; set; }
        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_HrPersonPermissionStatus);
        public string Notes { get; set; }

        

        
    }
}
