using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 静态拉伸试验数据明细
    /// </summary>
    public class StaticTensionDataDetailStressStrain : FullAuditedAggregateRoot<Guid>
    {
        #region 关联静态拉伸试验数据

        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? StaticTensionDataDetailId { get; set; }

        /// <summary>
        /// 材料试验
        /// </summary>
        public virtual StaticTensionDataDetail StaticTensionDataDetail { get; set; }
           
        #endregion

        /// <summary>
        /// 应力
        /// </summary>
        public decimal? Stress { get; set; }

        /// <summary>
        /// 应变
        /// </summary>
        public decimal? Strain { get; set; }

        /// <summary>
        /// 真应力
        /// </summary>
        public decimal? RealStress { get; set; }

        /// <summary>
        /// 真应变
        /// </summary>
        public decimal? RealStrain { get; set; }

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
