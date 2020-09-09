using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Dtos
{
    public class InputIdDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        /// <summary>
        ///     主/外键Id必填
        /// </summary>
        [Required]
        public TPrimaryKey Id { get; set; }
    }

    public class InputIdDto : InputIdDto<Guid>
    {
    }

    public class InputGuidNullDto : IEntityDto<Guid?>
    {
        public Guid? Id { get; set; }
    }
}