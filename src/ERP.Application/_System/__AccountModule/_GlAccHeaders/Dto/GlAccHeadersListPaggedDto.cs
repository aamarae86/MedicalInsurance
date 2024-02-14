using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccHeaders.Dto
{
    public class GlAccHeadersListPaggedDto
    {
        public List<GlAccHeadersListDto> items { get; set; }

        public int totalRecords { get; set; }
    }
}
