using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HanGang.MaterialSystem.Dtos
{

    public class InputIdsDto<TPrimaryKey>
    {
        public InputIdsDto()
        {
            Ids = new List<TPrimaryKey>();
        }

        /// <summary>
        ///     主键Id必填
        /// </summary>
        [Required]
        public List<TPrimaryKey> Ids { get; set; }
    }

    public class InputIdsDto : InputIdsDto<Guid>
    {
    }


    public class InputIdsNullDto : InputIdsDto<Guid?>
    {
    }
}