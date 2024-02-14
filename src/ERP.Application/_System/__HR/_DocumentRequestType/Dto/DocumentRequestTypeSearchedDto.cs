using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._DocumentRequestType.Dto
{
    public class DocumentRequestTypeSearchedDto
    {
        public string DocumentRequestName { get; set; }
        public override string ToString()
         => $"Params.DocumentRequestName={DocumentRequestName}";
    }
}
