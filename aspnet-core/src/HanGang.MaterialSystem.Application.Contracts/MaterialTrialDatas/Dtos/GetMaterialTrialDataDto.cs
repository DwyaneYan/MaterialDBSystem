﻿using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.MaterialTrialDatas.Dtos
{
    public class GetMaterialTrialDataDto
    {
        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? MaterialTrialId { get; set; }
    }

}