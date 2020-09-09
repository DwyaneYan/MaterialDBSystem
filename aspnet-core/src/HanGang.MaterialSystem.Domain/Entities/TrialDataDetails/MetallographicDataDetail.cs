namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 金相试验数据明细
    /// </summary>
    public class MetallographicDataDetail: BaseTrialDataDetail
    {
        /// <summary>
        /// 金相组织
        /// </summary>
        public string Structure { get; set; }

        /// <summary>
        /// 非金属夹杂（级）
        /// </summary>
        public string NonMetallicInclusionLevel { get; set; }

        /// <summary>
        /// 晶粒度
        /// </summary>
        public decimal? GrainSize { get; set; }

        /// <summary>
        /// 脱碳层深度
        /// </summary>
        public decimal? DepthDecarburization { get; set; }

        //#region 金相试验图片

        ///// <summary>
        ///// 金相图片/base64图片
        ///// </summary>
        //public string StructureString { get; set; }

        ///// <summary>
        ///// 金相文件服务key
        ///// </summary>
        //public string StructureKey { get; set; }

        ///// <summary>
        ///// 金相文件二进制内容
        ///// </summary>
        //public byte[] StructurBytes { get; set; }

        //#endregion

        //#region 非金属夹杂图片

        ///// <summary>
        ///// 非金属夹杂图片/base64图片
        ///// </summary>
        //public string NonMetallicInclusionLevelString { get; set; }

        ///// <summary>
        ///// 非金属夹杂文件服务key
        ///// </summary>
        //public string NonMetallicInclusionLevelKey { get; set; }

        ///// <summary>
        ///// 非金属夹杂文件二进制内容
        ///// </summary>
        //public byte[] NonMetallicInclusionLevelBytes { get; set; }
        //#endregion

        //#region 晶粒度试验图片

        ///// <summary>
        ///// 晶粒度图片/base64图片
        ///// </summary>
        //public string GrainSizeString { get; set; }

        ///// <summary>
        ///// 晶粒度文件服务key
        ///// </summary>
        //public string GrainSizeKey { get; set; }
        
        ///// <summary>
        ///// 晶粒度文件二进制内容
        ///// </summary>
        //public byte[] GrainSizeBytes { get; set; }
        //#endregion

        //#region 脱碳层深度试验图片

        ///// <summary>
        ///// 脱碳层深度图片/base64图片
        ///// </summary>
        //public string DepthDecarburizationString { get; set; }

        ///// <summary>
        ///// 脱碳层深度文件服务key
        ///// </summary>
        //public string DepthDecarburizationKey { get; set; }

        ///// <summary>
        ///// 脱碳层深度文件二进制内容
        ///// </summary>
        //public byte[] DepthDecarburizationBytes { get; set; }
        //#endregion
    }
}
