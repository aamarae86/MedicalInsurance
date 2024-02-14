using System.Collections.Generic;
using System.Text;

namespace ERP.FileUploader
{
    public class ErrorsDictionary : Dictionary<string, string>
    {
        public bool IsValid { get; private set; } = true;

        public void AddError(string v1, string v2)
        {
            IsValid = false;
            this.Add(v1, v2);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var Key in this.Keys)
            {
                sb.Append($"Error: {Key}");
                sb.Append($"Details:\r\n");
                string value;
                if (TryGetValue(Key, out value))
                    sb.Append($"{value}\r\n");
            }
            return sb.ToString();
        }
    }
}
