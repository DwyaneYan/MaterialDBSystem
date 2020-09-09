using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 回弹试验数据结果明细
    /// </summary>
    public class ReboundDataDetailItem2 : FullAuditedAggregateRoot<Guid>
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
        /// 弯曲角度
        /// </summary>
        public decimal? BendingAngle { get; set; }

        /// <summary>
        /// R=t
        /// </summary>
        public string Rt1 { get; set; }

        /// <summary>
        /// R=1.5t
        /// </summary>
        public string Rt2 { get; set; }

        /// <summary>
        /// R=1.67t
        /// </summary>
        public string Rt3 { get; set; }

        /// <summary>
        /// R=2t
        /// </summary>
        public string Rt4 { get; set; }

        /// <summary>
        /// R=2.3t
        /// </summary>
        public string Rt5 { get; set; }

        /// <summary>
        /// R=2.67t
        /// </summary>
        public string Rt6 { get; set; }

        /// <summary>
        /// 最小弯曲角度
        /// </summary>
        public string RtMin { get; set; }






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
