using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.SurfacePropertyDataDetails.Dtos
{
    public class SurfacePropertyCoatingWeightDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
      
        /// <summary>
        /// 材料表面性能试验
        /// </summary>
        public Guid? SurfacePropertyDataDetailId { get; set; }
        /// <summary>
        /// 面积（m2）
        /// </summary>
        public decimal? Area { get; set; }

        /// <summary>
        /// 初始重量（g）
        /// </summary>
        public decimal? OriginalWeight { get; set; }

        /// <summary>
        /// 试验后重量（g）
        /// </summary>
        public decimal? AfterWeight { get; set; }

        /// <summary>
        /// 膜重（g/mm2）
        /// </summary>
        public decimal? MembraneWeight { get; set; }
        /// <summary>
        /// 重量要求
        /// </summary>
        public string WeightRequirement { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

    }
}