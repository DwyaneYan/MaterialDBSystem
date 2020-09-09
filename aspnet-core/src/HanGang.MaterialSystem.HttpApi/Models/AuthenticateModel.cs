using System.ComponentModel.DataAnnotations;

namespace HanGang.MaterialSystem.Models
{
    public class AuthenticateModel
    {
        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }
    }
}