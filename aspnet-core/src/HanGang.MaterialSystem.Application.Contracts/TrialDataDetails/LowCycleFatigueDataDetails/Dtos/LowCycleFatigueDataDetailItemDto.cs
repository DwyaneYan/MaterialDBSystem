using System;

namespace HanGang.MaterialSystem.LowCycleFatigueDataDetails.Dtos
{
    public class LowCycleFatigueDataDetailItemDto
    {
        /// <summary>
        /// 补充用来展示
        /// </summary>
        public string SampleCode { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }


        /// <summary>
        /// 低疲劳试验数据明细
        /// </summary>
        public Guid? LowCycleFatigueDataDetailId { get; set; }

       


        /// <summary>
        /// 总应变幅
        /// </summary>
        public decimal? TotalStrainAmplitude { get; set; }

        /// <summary>
        /// 塑性应变幅
        /// </summary>
        public decimal? PlasticStrainAmplitude { get; set; }

        /// <summary>
        /// 弹性应变幅
        /// </summary>
        public decimal? ElasticStrainAmplitude { get; set; }

        /// <summary>
        /// 失效循环数
        /// </summary>
        public int? FailureCycleTimes { get; set; }

        /// <summary>
        /// 循环应力幅
        /// </summary>
        public decimal? CycleStressAmplitude { get; set; }

        /// <summary>
        /// 试验频率
        /// </summary>
        public decimal? TestFrequency { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
    }
}