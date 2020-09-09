using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.ReboundDataDetails.Dtos
{
    public class ReboundDataDetailDto : BaseTrialDataDetailDto
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
        /// 试样尺寸 
        /// </summary>
        public string SampleSize { get; set; }

        /// <summary>
        /// 弯曲角度范围
        /// </summary>
        public string BendingAngleRange { get; set; }

        /// <summary>
        /// 试验速度(mm/min)
        /// </summary>
        public decimal? TestSpeed { get; set; }

        /// <summary>
        /// 保持压力HoldStress(kN)
        /// </summary>
        public decimal? HoldStress { get; set; }

        /// <summary>
        /// 保持时间HoldTime（s）
        /// </summary>
        public int? HoldTimes { get; set; }

        /// <summary>
        /// 平均凸模圆角半径范围R(mm)
        /// </summary>
        public string PunchFilletRadiusRange { get; set; }
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
      

      
        /// <summary>
        /// 试验类型
        /// </summary>
        public string TestType { get; set; }

        #endregion



    }
}