namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 弯曲试验数据明细
    /// </summary>
    public class BendingDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 抗弯强度Rm(MPa)
        /// </summary>
        public decimal? BendingStrength { get; set; }

        /// <summary>
        /// 规定非比例弯曲强度
        /// </summary>
        public decimal? NonProportionalBendingStrenth { get; set; }

        /// <summary>
        /// 弯曲弹性模量E(MPa)
        /// </summary>
        public decimal? BendingOfElasticity { get; set; }

        /// <summary>
        /// 跨距
        /// </summary>
        public decimal? Span { get; set; }
    }
}
