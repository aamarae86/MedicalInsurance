using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonPermission.Dto
{
   public class HrPersonPermissionSearchDto
    {
        public long PermissionTypeId { get; set; }
        public string OperationNumber { get; set; }
        public string PermissionDate { get; set; }
        public long HrPersonId { get; set; }
        public override string ToString()
         => $"Params.HrPersonId={HrPersonId}&Params.PermissionTypeId={PermissionTypeId}&Params.PermissionDate={PermissionDate}&Params.OperationNumber={OperationNumber}";
    
}
}
