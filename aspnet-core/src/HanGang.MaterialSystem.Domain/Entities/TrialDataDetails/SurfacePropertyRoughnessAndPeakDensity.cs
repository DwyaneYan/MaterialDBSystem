using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 表面性能粗糙度和峰值密度
    /// </summary>
    public class SurfacePropertyRoughnessAndPeakDensity: FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料表面性能试验数据明细

        /// <summary>
        /// 材料表面性能试验
        /// </summary>
        public Guid? SurfacePropertyDataDetailId { get; set; }

        /// <summary>
        /// 材料表面性能试验
        /// </summary>
        public virtual SurfacePropertyDataDetail SurfacePropertyDataDetail { get; set; }

        #endregion

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

        /// <summary>
        /// 插入顺序
        /// </summary>
        public int InsertOrder { get; set; }
    }
}
