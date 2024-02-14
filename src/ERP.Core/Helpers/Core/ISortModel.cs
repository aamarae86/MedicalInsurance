using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Helpers.Core
{
    public interface ISortModel
    {
        SortModel OrderByValue { get; set; }
    }
}
