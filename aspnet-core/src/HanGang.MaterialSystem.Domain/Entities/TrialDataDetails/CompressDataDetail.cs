namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 压缩试验数据明细
    /// </summary>
    public class CompressDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 抗压强度Rm(MPa)
        /// </summary>
        public decimal? CompressiveStrength { get; set; }

        /// <summary>
        /// 规定非比例压缩强度
        /// </summary>
        public decimal? NonProportionalCompressStrenth { get; set; }
        
        /// <summary>
        /// 压缩弹性模量E(MPa)
        /// </summary>
        public decimal? CompressOfElasticity { get; set; }
    }
}
