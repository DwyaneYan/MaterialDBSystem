using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HanGang.MaterialSystem.Dtos
{
    public class InputNameDto
    {
        /// <summary>
        ///     名称必填
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}