using HanGang.MaterialSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.TypicalParts.Dtos
{
    public class GetTypicalPartListInputDto : PagedInputDto
    {
        /// <summary>
        /// 零部件名称
        /// </summary>
        public string Name { get; set; }
    }
}
