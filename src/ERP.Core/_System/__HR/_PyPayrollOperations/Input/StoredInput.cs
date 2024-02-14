using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._PyPayrollOperations.Input
{
    public class StoredInput
    {
        public long Id { get; set; }
        public string Lang { get; set; }
        public long UserId { get; set; }
        public override string ToString()
        {
            return $"?Id={Id}&Lang={Lang}&UserId={UserId}";
        }
    }
}
