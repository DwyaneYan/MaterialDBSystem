using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.WeldingDataDetails.Dtos
{
    public class WeldingDataDetailDto : BaseTrialDataDetailDto
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
        /// 试验类型
        /// </summary>
        public string TestType { get; set; }

        /// <summary>
        /// 焊机类别
        /// </summary>
        public string WelderType { get; set; }

        /// <summary>
        /// 焊机型号
        /// </summary>
        public string WelderMode { get; set; }

        /// <summary>
        /// 电极头前端直径
        /// </summary>
        public decimal? HeadDiameter { get; set; }

        /// <summary>
        /// 电极压力
        /// </summary>
        public decimal? ElectrodePressure { get; set; }

        /// <summary>
        /// 脉冲次数
        /// </summary>
        public int? PulseTimes { get; set; }

        /// <summary>
        /// 预压时间
        /// </summary>
        public int? PreloadingTimes { get; set; }

        /// <summary>
        /// 升压时间
        /// </summary>
        public int? BoostTimes { get; set; }

        /// <summary>
        /// 最小焊接时间
        /// </summary>
        public int? MinimumWeldingTimes { get; set; }

        /// <summary>
        /// 中值焊接时间
        /// </summary>
        public int? MiddleWeldingTimes { get; set; }

        /// <summary>
        /// 最大焊接时间
        /// </summary>
        public int? MaxmumWeldingTimes { get; set; }

        /// <summary>
        /// 保压时间
        /// </summary>
        public int? HoldingWeldingTimes { get; set; }

        /// <summary>
        /// 临界焊点直径
        /// </summary>
        public decimal? CriticalJointDiameter { get; set; }

        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }


   

        #endregion


    }
}