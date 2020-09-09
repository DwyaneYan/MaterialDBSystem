using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 回弹性能试验数据明细
    /// </summary>
    public class ReboundDataDetail : BaseTrialDataDetail
    {   
        /// <summary>
        /// 试样尺寸 
        /// </summary>
        public string SampleSize { get; set; }
        /// <summary>
        /// 试验类型
        /// </summary>
        public string TestType { get; set; }

        /// <summary>
        /// 弯曲角度范围
        /// </summary>
        public string BendingAngleRange { get; set; }

        /// <summary>
        /// 试验速度(mm/min)
        /// </summary>
        public decimal? TestSpeed { get; set; }
                
        /// <summary>
        /// 保持压力HoldStress(kN)
        /// </summary>
        public decimal? HoldStress { get; set; }
                        
        /// <summary>
        /// 保持时间HoldTime（s）
        /// </summary>
        public int? HoldTimes { get; set; }

        /// <summary>
        /// 平均凸模圆角半径范围R(mm)
        /// </summary>
        public string PunchFilletRadiusRange { get; set; }

        /// <summary>
        /// 回弹性能试验数据结果明细
        /// </summary>
        public virtual HashSet<ReboundDataDetailItem> ReboundDataDetailItems { get; set; }=new HashSet<ReboundDataDetailItem>();

        /// <summary>
        /// 回弹性能试验数据结果明细2
        /// </summary>
        public virtual HashSet<ReboundDataDetailItem2> ReboundDataDetailItems2 { get; set; } = new HashSet<ReboundDataDetailItem2>();

        /// <summary>
        /// 回弹性能试验数据结果明细3
        /// </summary>
        public virtual HashSet<ReboundDataDetailItem3> ReboundDataDetailItems3 { get; set; } = new HashSet<ReboundDataDetailItem3>();

    }
}
