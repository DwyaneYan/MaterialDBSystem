using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 涂装性能-附着力试验数据结果明细
    /// </summary>
    public class PaintingDataDetailAdhesionItem : FullAuditedAggregateRoot<Guid>
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
        /// 附着力1
        /// </summary>
        public decimal? PointAdhesionOne { get; set; }

        /// <summary>
        /// 附着力2
        /// </summary>
        public decimal? PointAdhesionTwo { get; set; }

        /// <summary>
        /// 附着力3
        /// </summary>
        public decimal? PointAdhesionThree { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string FileString { get; set; }

        /// <summary>
        /// 插入顺序
        /// </summary>
        public int InsertOrder { get; set; }

    }
}
