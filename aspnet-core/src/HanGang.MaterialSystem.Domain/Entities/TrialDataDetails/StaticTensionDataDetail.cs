using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 静态拉伸试验数据明细
    /// </summary>
    public class StaticTensionDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 规定非比例延伸率(静态拉伸试验的试验参数)
        /// </summary>
        public decimal? NonProportionalExtendRatio { get; set; }

        /// <summary>
        /// 屈服强度Rp(MPa)
        /// </summary>
        public decimal? YieldStrength { get; set; }

        /// <summary>
        /// 抗拉强度Rm(MPa)
        /// </summary>
        public decimal? TensileStrength { get; set; }
        
        /// <summary>
        /// 应变硬化指数
        /// </summary>
        public decimal? StrainHardening { get; set; }
        
        /// <summary>
        /// 断后伸长率
        /// </summary>
        public decimal? Elongation { get; set; }
        
        /// <summary>
        /// 塑性应变比γ(%)
        /// </summary>
        public decimal? PlasticStrainRatio { get; set; }

        /// <summary>
        /// 弹性模量E(MPa)
        /// </summary>
        public decimal? ModulusOfElasticity { get; set; }

        /// <summary>
        /// 泊松比μ
        /// </summary>
        public decimal? PoissonRatio { get; set; }

        /// <summary>
        /// 最大力Fm(kN)
        /// </summary>
        public decimal? MaximumForce { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 烘烤硬化值(BH)
        /// </summary>
        public decimal? BHValue { get; set; }

        /// <summary>
        /// 180°弯曲试验(弯曲压头直径D)
        /// </summary>
        public decimal? IndenterDiameter { get; set; }

        /// <summary>
        /// V型冲击试验温度(℃)
        /// </summary>
        public decimal? VImpactTemperature { get; set; }

        /// <summary>
        /// V型冲击试验吸收能量(KV2/J)
        /// </summary>
        public decimal? VImpactEnergy { get; set; }

        /// <summary>
        /// 插入顺序
        /// </summary>
        public int InsertOrder { get; set; }


        /// <summary>
        /// 应力应变(真应力/真应变)数据明细
        /// </summary>
        public virtual HashSet<StaticTensionDataDetailStressStrain> StaticTensionDataDetailStressStrains { get; set; } = new HashSet<StaticTensionDataDetailStressStrain>();

    }
}
