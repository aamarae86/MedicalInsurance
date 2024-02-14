using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonVacations.Dto
{
    public class HrPersonVacationsSearchDto
    {
        public string OperationNumber { get; set; }

        public string OperationDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long? HrVacationsTypeId { get; set; }

        public long? HrPersonId { get; set; }

        public override string ToString()
            => $"Params.OperationNumber={OperationNumber}&Params.OperationDate={OperationDate}&Params.HrPersonId={HrPersonId}&Params.StatusLkpId={StatusLkpId}&Params.HrVacationsTypeId={HrVacationsTypeId}";
    }
}
