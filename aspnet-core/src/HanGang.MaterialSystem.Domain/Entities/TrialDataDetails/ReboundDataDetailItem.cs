using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 回弹试验数据结果明细
    /// </summary>
    public class ReboundDataDetailItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料回弹试验数据

        /// <summary>
        /// 回弹试验数据明细
        /// </summary>
        public Guid? ReboundDataDetailId { get; set; }

        /// <summary>
        /// 回弹试验数据明细
        /// </summary>
        public virtual ReboundDataDetail ReboundDataDetail { get; set; }

        #endregion

        /// <summary>
        /// 方向（沿轧向或者垂直轧向）
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 厚度 t/mm
        /// </summary>
        public decimal? Thickness { get; set; }

        /// <summary>
        /// 凸模圆角半径R(mm)
        /// </summary>
        public string PunchFilletRadius { get; set; }
        
        /// <summary>
        /// 弯曲角度
        /// </summary>
        public decimal? BendingAngle { get; set; }

        /// <summary>
        /// 测量角度
        /// </summary>
        public decimal? MeasuringAngle { get; set; }

        /// <summary>
        /// 回弹角度
        /// </summary>
        public decimal? ReboundAngle { get; set; }

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
