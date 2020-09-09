using System.ComponentModel.DataAnnotations;

namespace HanGang.MaterialSystem.Dtos
{
    public class RefreshTokenInputDto
    {
        [Required]
        public string RefreshToken { get; set; }

        public string GrantType { get; set; }
    }
}