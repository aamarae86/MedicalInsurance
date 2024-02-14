using ERP.ResourcePack.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Parameters.Users
{
    public class ChangePasswordParms
    {

        [Required]
        [Display(Name = nameof(Settings.OldPasswrod), ResourceType = typeof(Settings))]
        public string CurrentPassword { get; set; }

        [Required]
        [Display(Name = nameof(Settings.NewPassword), ResourceType = typeof(Settings))]
        public string NewPassword { get; set; }
    }
}
