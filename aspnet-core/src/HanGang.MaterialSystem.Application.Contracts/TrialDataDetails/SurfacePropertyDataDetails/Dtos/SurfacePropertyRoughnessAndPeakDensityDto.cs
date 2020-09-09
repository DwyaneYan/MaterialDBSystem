using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.SurfacePropertyDataDetails.Dtos
{
    public class SurfacePropertyRoughnessAndPeakDensityDto { 

        /// <summary>
        /// Id
        /// </summary>
    public System.Guid Id { get; set; }
        /// <summary>
        /// 材料表面性能试验
        /// </summary>
        public Guid? SurfacePropertyDataDetailId { get; set; }

        /// <summary>
        /// Ra要求值
        /// </summary>
        public string RaRequirement { get; set; }
        /// <summary>
        /// 操作位置
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 上表粗糙度(Ra/μm)
        /// </summary>
        public decimal? AboveRoughness { get; set; }
        /// <summary>
        /// 上表峰值密度RPc个 /cm
        /// </summary>
        public decimal? AbovePeakDensity { get; set; }

        /// <summary>
        /// 下表粗糙度(Ra/μm)
        /// </summary>
        public decimal? BelowRoughness { get; set; }
        /// <summary>
        /// 下表峰值密度RPc个 /cm
        /// </summary>
        public decimal? BelowPeakDensity { get; set; }
        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

    }
}