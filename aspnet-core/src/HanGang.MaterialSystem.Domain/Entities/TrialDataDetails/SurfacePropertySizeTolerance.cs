using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 表面性能尺寸公差
    /// </summary>
    public class SurfacePropertySizeTolerance: FullAuditedAggregateRoot<Guid>
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
        /// Size要求值
        /// </summary>
        public string SizeRequirement { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string TestCode { get; set; }
        /// <summary>
        /// 距边部40mm厚度
        /// </summary>
        public decimal? EdgeThickness1 { get; set; }
        /// <summary>
        /// 距左边部1/4厚度
        /// </summary>
        public decimal? EdgeThickness2 { get; set; }

        /// <summary>
        /// 板宽1/2厚度
        /// </summary>
        public decimal? EdgeThickness3 { get; set; }
      

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
