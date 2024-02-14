using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Core
{
    //
    // Summary:
    //     This interface is defined to standardize to return a list of items to clients.
    //
    // Type parameters:
    //   T:
    //     Type of the items in the Abp.Application.Services.Dto.IListResult`1.Items list
    public interface IListResult<T>
    {
        //
        // Summary:
        //     List of items.
        IReadOnlyList<T> Items { get; set; }
    }
}
