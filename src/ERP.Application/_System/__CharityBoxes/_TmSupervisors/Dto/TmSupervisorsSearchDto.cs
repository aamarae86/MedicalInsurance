using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmSupervisors.Dto
{
    public class TmSupervisorsSearchDto
    {
        public string SupervisorNumber { get;  set; }
        public string SupervisorName { get;  set; }
        public long? StatusLkpId { get;  set; }
        public override string ToString()
        {
            return $"Params.SupervisorNumber={SupervisorNumber}&Params.SupervisorName={SupervisorName}&Params.StatusLkpId={StatusLkpId}";
        }
    }
}
