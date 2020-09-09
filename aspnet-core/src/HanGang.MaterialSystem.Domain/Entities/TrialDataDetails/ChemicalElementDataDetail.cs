namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 化学成分试验数据明细
    /// </summary>
    public class ChemicalElementDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 要求值
        /// </summary>
        public string Requirement { get; set; }
        /// <summary>
        /// 元素名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 元素符号
        /// </summary>
        public string Element { get; set; }

        /// <summary>
        /// 元素含量
        /// </summary>
        public decimal? ContentRatio { get; set; }

        /// <summary>
        /// 插入顺序
        /// </summary>
        public int InsertOrder { get; set; }
    }
}
