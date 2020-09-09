using HanGang.MaterialSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.Manufactories.Dtos
{
    public class GetManufactoryListInputDto : PagedInputDto
    {
        /// <summary>
        /// 生产厂家名称
        /// </summary>
        public string Name { get; set; }
    }
}
