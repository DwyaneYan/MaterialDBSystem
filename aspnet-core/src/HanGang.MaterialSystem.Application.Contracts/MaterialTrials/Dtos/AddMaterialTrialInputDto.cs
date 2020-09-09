﻿using System;

namespace HanGang.MaterialSystem.MaterialTrials.Dtos
{
    public class AddMaterialTrialInputDto
    {

        /// <summary>
        /// 冗余材料试验名称=试验名称(试验名称保持不变,方便查询)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 材料试验编码(暂无需求)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 材料id
        /// </summary>
        public Guid? MaterialId { get; set; }
        
        /// <summary>
        /// 试验id
        /// </summary>
        public Guid? TrialId { get; set; }
    }
}