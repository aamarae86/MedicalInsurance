using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Helpers.Parameters.GlMainAccounts
{
    public class GlMainAccountsParms
    {
        public long? DescriptionSearchId { get; set; }

        public string ReferenceCode { get; set; }

            public 
            override 
            string 
            ToString() 
            =>
            $"Params.DescriptionSearchId={DescriptionSearchId}&Params.ReferenceCode={ReferenceCode}";
    }
}
