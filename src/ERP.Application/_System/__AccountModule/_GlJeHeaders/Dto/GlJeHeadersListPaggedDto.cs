using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlJeHeaders.Dto
{
    public class GlJeHeadersListPaggedDto
    {
        public List<GlJeHeadersListDto> items { get; set; }

        public int totalRecords { get; set; }
    }
}
