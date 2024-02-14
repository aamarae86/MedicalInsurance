using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Core
{
    public interface IAuditedEntityStrDates
    {
        string CreationTimeStr { get; }
        string LastModificationTimeStr { get; }
    }
}
