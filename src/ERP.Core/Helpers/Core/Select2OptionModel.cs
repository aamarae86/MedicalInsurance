using ERP.Core.Helpers.Core;

namespace ERP.Helpers.Core
{
    public class Select2OptionModel
    {
        public long id { get; set; }

        public string text { get; set; }

        public string altText { get; set; }
        public string additional { get; set; }

        public string encId => CipherStringController.Encrypt(this.id.ToString());
    }
}
