using HanGang.MaterialSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.MaterialTrials.Dtos
{
    public class GetMaterialTrialListInputDto : PagedInputDto
    {
        /// <summary>
        /// 材料试验Id
        /// </summary>
        public System.Guid Id { get; set; }
        /// <summary>
        /// 材料试验名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 材料id
        /// </summary>
        public Guid? MaterialId { get; set; }

        /// <summary>
        /// 试验
        /// </summary>
        public Guid? TrialId { get; set; }

    }
}
