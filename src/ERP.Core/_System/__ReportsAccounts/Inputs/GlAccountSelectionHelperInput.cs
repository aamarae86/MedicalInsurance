using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__ReportsAccounts.Inputs
{
    public class GlAccountSelectionHelperInput : PrepareRPTInput
    {
        public CodeComAttrs FromCodeCom { get; set; }

        public CodeComAttrs ToCodeCom { get; set; }

        public string[] YesNoAttrs { get; set; }
    }

    public class CodeComAttrs
    {
        public long? Attribute1 { get; set; }

        public long? Attribute2 { get; set; }

        public long? Attribute3 { get; set; }

        public long? Attribute4 { get; set; }

        public long? Attribute5 { get; set; }

        public long? Attribute6 { get; set; }

        public long? Attribute7 { get; set; }

        public long? Attribute8 { get; set; }

        public long? Attribute9 { get; set; }

        public long? AccId { get; set; }
    }

}
