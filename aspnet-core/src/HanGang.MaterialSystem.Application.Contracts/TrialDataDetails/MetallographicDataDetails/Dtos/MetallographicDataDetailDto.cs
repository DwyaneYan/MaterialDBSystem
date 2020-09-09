using HanGang.MaterialSystem.TrialDataDetails;
using Microsoft.AspNetCore.Http;
using System;

namespace HanGang.MaterialSystem.MetallographicDataDetails.Dtos
{
    public class MetallographicDataDetailDto : BaseTrialDataDetailDto
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
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        #endregion
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

       
     
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
      


        #endregion
    }
}