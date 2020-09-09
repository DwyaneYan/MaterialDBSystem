using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.CementingDataDetails.Dtos
{
    public class CementingDataDetailDto : BaseTrialDataDetailDto
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
        /// 试样长度
        /// </summary>
        public decimal? Length { get; set; }

        /// <summary>
        /// 试样真实宽度
        /// </summary>
        public decimal? Width{ get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        #endregion
        /// <summary>
        /// 胶接宽度
        /// </summary>
        public decimal? CementingWidth { get; set; }

        /// <summary>
        /// 剪切强度Rp(MPa)
        /// </summary>
        public decimal? MPA { get; set; }

        /// <summary>
        /// 失效模式
        /// </summary>
        public string FailureMode { get; set; }
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
 

       

        #endregion


    }
}