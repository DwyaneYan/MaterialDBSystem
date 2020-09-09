using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 表面性能粗造度
    /// </summary>
    public class SurfacePropertyRoughness: FullAuditedAggregateRoot<Guid>
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
        /// Ra（μm）
        /// </summary>
        public decimal? RaOne { get; set; }
                
        /// <summary>
        /// Ra（μm）
        /// </summary>
        public decimal? RaTwo { get; set; }

        /// <summary>
        /// 粗造度 RPC（个/cm）
        /// </summary>
        public decimal? RPCOne { get; set; }
        
        /// <summary>
        /// 粗造度 RPC（个/cm）
        /// </summary>
        public decimal? RPCTwo{ get; set; }

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
