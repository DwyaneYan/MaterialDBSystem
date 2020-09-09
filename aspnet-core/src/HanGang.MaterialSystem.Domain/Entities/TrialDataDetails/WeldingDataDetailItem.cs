using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 焊接试验数据结果明细
    /// </summary>
    public class WeldingDataDetailItem: FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料焊接试验数据明细

        /// <summary>
        /// 材料焊接试验数据明细
        /// </summary>
        public Guid? WeldingDataDetailId { get; set; }

        /// <summary>
        /// 材料焊接试验数据明细
        /// </summary>
        public virtual WeldingDataDetail WeldingDataDetail { get; set; }

        #endregion
        /// <summary>
        /// 焊接电流区间
        /// </summary>
        public decimal? WeldingCurrentInterval { get; set; }
        /// <summary>
        /// 左边界电流（kA）
        /// </summary>
        public decimal? LeftBoundaryElectric{ get; set; }

        /// <summary>
        /// 右边界电流（kA）
        /// </summary>
        public decimal? RightBoundaryElectric{ get; set; }

        /// <summary>
        /// 焊接时间
        /// </summary>
        public int? WeldingTimes { get; set; }

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
