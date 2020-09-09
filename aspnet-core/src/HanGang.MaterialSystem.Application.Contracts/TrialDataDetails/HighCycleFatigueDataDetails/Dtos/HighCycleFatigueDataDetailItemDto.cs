using System;

namespace HanGang.MaterialSystem.HighCycleFatigueDataDetails.Dtos
{
    public class HighCycleFatigueDataDetailItemDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string ItemSampleCode { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 高周疲劳试验数据明细
        /// </summary>
        public Guid? HighCycleFatigueDataDetailId { get; set; }

       
        /// <summary>
        /// 最大应力/MPa
        /// </summary>
        public decimal? MaximumStress { get; set; }

        /// <summary>
        /// 应力幅/MPa
        /// </summary>
        public decimal? StressAmplitude { get; set; }

        /// <summary>
        /// 试验循环周次
        /// </summary>
        public decimal? TestFrequency { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
    }
}