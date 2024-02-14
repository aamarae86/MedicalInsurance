using System.Collections.Generic;

namespace ERP.Front.Helpers.Core
{
    //
    // Summary:
    //     Implements Abp.Application.Services.Dto.IListResult`1.
    //
    // Type parameters:
    //   T:
    //     Type of the items in the Abp.Application.Services.Dto.ListResultDto`1.Items list
    public class ListResultDto<T> : IListResult<T>
    {
        //
        // Summary:
        //     Creates a new Abp.Application.Services.Dto.ListResultDto`1 object.
        public ListResultDto() { }
        //
        // Summary:
        //     Creates a new Abp.Application.Services.Dto.ListResultDto`1 object.
        //
        // Parameters:
        //   items:
        //     List of items
        public ListResultDto(IReadOnlyList<T> items) { }

        //
        // Summary:
        //     List of items.
        public IReadOnlyList<T> Items { get; set; }
    }
}
