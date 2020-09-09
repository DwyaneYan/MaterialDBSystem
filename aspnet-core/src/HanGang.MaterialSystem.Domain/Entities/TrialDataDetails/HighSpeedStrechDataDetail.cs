using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 高速拉伸试验数据明细
    /// </summary>
    public class HighSpeedStrechDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 杨氏模量
        /// </summary>
        public decimal? YoungModulu { get; set; }
        /// <summary>
        /// 泊松比
        /// </summary>
        public decimal? PoissonRatio { get; set; }

        /// <summary>
        /// 取样方向
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 拉伸速率测试指标
        /// </summary>
        public decimal? TestTarget { get; set; }

        public string? NameCode { get; set; }

        /// <summary>
        /// 屈服强度Rp(MPa)
        /// </summary>
        public decimal? YieldStrength { get; set; }

        /// <summary>
        /// 抗拉强度Rm(MPa)
        /// </summary>
        public decimal? TensileStrength { get; set; }

        /// <summary>
        /// 断后伸长率
        /// </summary>
        public decimal? Elongation { get; set; }
        
        /// <summary>
        /// 拉伸速度(m/s)
        /// </summary>
        public decimal? StretchingSpeed { get; set; }


        /// <summary>
        /// 插入顺序
        /// </summary>
        public int InsertOrder { get; set; }


        /// <summary>
        /// 高速拉伸试验数据明细
        /// </summary>
        public virtual HashSet<HighSpeedStrechDataDetailStressStrain> HighSpeedStrechDataDetailStressStrains { get; set; } = new HashSet<HighSpeedStrechDataDetailStressStrain>();
        ///// <summary>
        ///// 高速拉伸试验数据明细Extend
        ///// </summary>
        //public virtual HashSet<HighSpeedStrechDataDetailStressStrainExtend> HighSpeedStrechDataDetailStressStrainExtends { get; set; } = new HashSet<HighSpeedStrechDataDetailStressStrainExtend>();
    }
}
