using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.StaticTensionDataDetails.Dtos
{
    public class StaticTensionDataDetailDto : BaseTrialDataDetailDto
    {
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }


        
        

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

        #endregion

        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
        #region        
        /// <summary>
        /// 材料试验数据id
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }

        #endregion

        #region 公共试验参数/条件 同参数的材料 试验数据可能多条...

        /// <summary>
        /// 执行标准
        /// </summary>
        public string Standard { get; set; }

      

        /// <summary>
        /// 样件编号(0℃ -1)/测试编号
        /// </summary>
        public string SampleCode { get; set; }


        /// <summary>
        /// 试样真实厚度
        /// </summary>
        public decimal? Thickness { get; set; }



        /// <summary>
        /// 标距(mm)
        /// </summary>
        public decimal? GaugeDistance { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        #endregion


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
    }
}