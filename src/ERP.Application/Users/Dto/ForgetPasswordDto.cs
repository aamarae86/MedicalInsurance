using System.ComponentModel.DataAnnotations;

namespace ERP.Users.Dto
{
    public class ForgetPasswordDto
    {
        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ResetToken { get; set; }

        [Required]
        public string Email { get; set; }

        public int TenantId { get; set; } = 0;
    }
}
