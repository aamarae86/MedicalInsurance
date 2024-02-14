using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Parameters.Users
{
    public class UsersParms
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public bool? IsActive { get; set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            return $"Params.UserName={UserName}&Params.EmailAddress={EmailAddress}&Params.IsActive={IsActive}&Params.FullName={FullName}&Params.Name={Name}&Params.Surname={Surname}";
        }
    }
}
