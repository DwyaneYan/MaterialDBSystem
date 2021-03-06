﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 涂装性能-耐湿热性能试验数据结果明细
    /// </summary>
    public class PaintingDataDetailDampHeatItem : FullAuditedAggregateRoot<Guid>
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
        /// 湿热1
        /// </summary>
        public decimal? PointOne { get; set; }

        /// <summary>
        /// 湿热2
        /// </summary>
        public decimal? PointTwo { get; set; }

        /// <summary>
        /// 湿热3
        /// </summary>
        public decimal? PointThree { get; set; }

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
