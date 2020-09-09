namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 禁用物质试验数据明细
    /// </summary>
    public class ProhibitedSubstanceDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 要求值
        /// </summary>
        public string Requirement { get; set; }
        /// <summary>
        /// 禁用物质元素名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 禁用物质元素符号
        /// </summary>
        public string Element { get; set; }

        /// <summary>
        /// 禁用物质元素含量
        /// </summary>
        public decimal? ContentRatio { get; set; }
    }
}
