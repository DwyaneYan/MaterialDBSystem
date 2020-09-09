using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.ProhibitedSubstanceDataDetails.Dtos
{
    public class ProhibitedSubstanceDataDetailDto : BaseTrialDataDetailDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
        /// <summary>
        /// 关联材料试验
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }
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
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        #endregion

        /// <summary>
        /// 要求值
        /// </summary>
        public string Requirement { get; set; }

        /// <summary>
        /// 禁用物质元素符号
        /// </summary>
        public string Element { get; set; }

        /// <summary>
        /// 禁用物质元素含量
        /// </summary>
        public decimal? ContentRatio { get; set; }
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
        

       

        #endregion
    }
}