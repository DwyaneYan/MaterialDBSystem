using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.HydrogenInducedDelayedFractureDataDetails.Dtos
{
    public class HydrogenInducedDelayedFractureDataDetailDto: BaseTrialDataDetailDto
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
        /// 试验名称
        /// </summary>
        public string TestName { get; set; }

       

        /// <summary>
        /// 溶液类别
        /// </summary>
        public string LiquorType { get; set; }

        /// <summary>
        /// 试验时间
        /// </summary>
        public decimal? TestTime { get; set; }


        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
 

       
      


        #endregion
    }
}