using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 涂装性能-电泳漆膜粗糙度试验数据结果明细
    /// </summary>
    public class PaintingDataDetailRoughnessItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料涂装性能试验数据

        /// <summary>
        /// 涂装性能试验数据明细
        /// </summary>
        public Guid? PaintingDataDetailId { get; set; }

        /// <summary>
        /// 涂装性能试验数据明细
        /// </summary>
        public virtual PaintingDataDetail PaintingDataDetail { get; set; }

        #endregion

       

        /// <summary>
        /// Ra（μm）1
        /// </summary>
        public decimal? RaOne { get; set; }

        /// <summary>
        /// Ra（μm）2
        /// </summary>
        public decimal? RaTwo { get; set; }

        /// <summary>
        /// Ra（μm）3
        /// </summary>
        public decimal? RaThree { get; set; }

       

        /// <summary>
        /// Rz（μm）1
        /// </summary>
        public decimal? RzOne { get; set; }

        /// <summary>
        /// Rz（μm）2
        /// </summary>
        public decimal? RzTwo { get; set; }

        /// <summary>
        /// Rz（μm）3
        /// </summary>
        public decimal? RzThree { get; set; }

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
