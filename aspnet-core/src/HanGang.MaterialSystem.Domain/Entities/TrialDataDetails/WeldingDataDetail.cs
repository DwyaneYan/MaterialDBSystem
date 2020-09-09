using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 焊接试验数据明细
    /// </summary>
    public class WeldingDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 试验类型
        /// </summary>
        public string TestType { get; set; }

        /// <summary>
        /// 焊机类别
        /// </summary>
        public string WelderType { get; set; }
        
        /// <summary>
        /// 焊机型号
        /// </summary>
        public string WelderMode { get; set; }
                
        /// <summary>
        /// 电极头前端直径
        /// </summary>
        public decimal? HeadDiameter { get; set; }

        /// <summary>
        /// 电极压力
        /// </summary>
        public decimal? ElectrodePressure { get; set; }

        /// <summary>
        /// 脉冲次数
        /// </summary>
        public int? PulseTimes { get; set; }

        /// <summary>
        /// 预压时间
        /// </summary>
        public int? PreloadingTimes{ get; set; }

        /// <summary>
        /// 升压时间
        /// </summary>
        public int? BoostTimes{ get; set; }

        /// <summary>
        /// 最小焊接时间
        /// </summary>
        public int? MinimumWeldingTimes{ get; set; }
        
        /// <summary>
        /// 中值焊接时间
        /// </summary>
        public int? MiddleWeldingTimes{ get; set; }
               
        /// <summary>
        /// 最大焊接时间
        /// </summary>
        public int? MaxmumWeldingTimes{ get; set; }
                       
        /// <summary>
        /// 保压时间
        /// </summary>
        public int? HoldingWeldingTimes{ get; set; }
                 
        /// <summary>
        /// 临界焊点直径
        /// </summary>
        public decimal? CriticalJointDiameter{ get; set; }

        /// <summary>
        /// 焊接试验数据结果明细
        /// </summary>
        public virtual HashSet<WeldingDataDetailItem> WeldingDataDetailItems { get; set; } = new HashSet<WeldingDataDetailItem>();

    }
}
