using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.ModificationsValidation
{
    public interface IHasModificationTimeValidation
    {
        DateTime? LastModificationTime { get; }
        string LastModificationTimeStr { get; set; }
    }
    public interface IHasPostTimeValidation
    {
        DateTime? PostTime { get; }
    }
}
