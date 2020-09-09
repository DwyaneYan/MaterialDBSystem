using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.FlangingClaspDataDetails.Dtos
{
    public class FlangingClaspDataDetailDto : BaseTrialDataDetailDto
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
        /// 翻边等级
        /// </summary>
        public string FlangingLevel { get; set; }
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
 

       
        #endregion
    }
}