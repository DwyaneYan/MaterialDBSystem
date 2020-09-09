using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.StaticTensionDataDetails.Dtos
{
    public class StaticTensionDataDetailRequirementDto 
    {
        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }

        

        /// <summary>
        /// 样件编号(0℃ -1)/测试编号
        /// </summary>
        public string SampleCode { get; set; }
        /// <summary>
        /// 方向
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// 试样厚度
        /// </summary>
        public string Thickness { get; set; }

        /// <summary>
        /// 规定非比例延伸率(静态拉伸试验的试验参数)
        /// </summary>
        public string NonProportionalExtendRatio { get; set; }

        /// <summary>
        /// 屈服强度Rp(MPa)
        /// </summary>
        public string YieldStrength { get; set; }

        /// <summary>
        /// 抗拉强度Rm(MPa)
        /// </summary>
        public string TensileStrength { get; set; }

        /// <summary>
        /// 应变硬化指数
        /// </summary>
        public string StrainHardening { get; set; }

        /// <summary>
        /// 断后伸长率
        /// </summary>
        public string Elongation { get; set; }

        /// <summary>
        /// 塑性应变比γ(%)
        /// </summary>
        public string PlasticStrainRatio { get; set; }

        /// <summary>
        /// 弹性模量E(MPa)
        /// </summary>
        public string ModulusOfElasticity { get; set; }

        /// <summary>
        /// 泊松比μ
        /// </summary>
        public string PoissonRatio { get; set; }

        /// <summary>
        /// 最大力Fm(kN)
        /// </summary>
        public string MaximumForce { get; set; }



        /// <summary>
        /// 烘烤硬化值(BH)
        /// </summary>
        public string BHValue { get; set; }

        /// <summary>
        /// 180°弯曲试验(弯曲压头直径D)
        /// </summary>
        public string IndenterDiameter { get; set; }

        /// <summary>
        /// V型冲击试验温度(℃)
        /// </summary>
        public string VImpactTemperature { get; set; }

        /// <summary>
        /// V型冲击试验吸收能量(KV2/J)
        /// </summary>
        public string VImpactEnergy { get; set; }
    }
}