
using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Materials.Dtos
{
    public class MaterialRecommendationDto : EntityDto<Guid>
    {
        /// <summary>
        /// 材料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 卷号
        /// </summary>
        public decimal? ReelNumber { get; set; }

        /// <summary>
        /// 型号规格 
        /// </summary>
        public decimal? Model { get; set; }


        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Manufactory { get; set; }


        /// <summary>
        /// 材料样本图片
        /// </summary>
        public string FileString { get; set; }
        /// <summary>
        /// 材料id
        /// </summary>
        public Guid MaterialId { get; set; }

    }
}