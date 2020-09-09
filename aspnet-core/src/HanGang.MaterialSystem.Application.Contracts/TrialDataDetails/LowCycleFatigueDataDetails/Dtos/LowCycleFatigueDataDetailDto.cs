using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.LowCycleFatigueDataDetails.Dtos
{
    public class LowCycleFatigueDataDetailDto : BaseTrialDataDetailDto
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
        /// 引伸计标距(mm)
        /// </summary>
        public decimal? ExtensometerGaugeDistance { get; set; }

        /// <summary>
        /// 表面质量
        /// </summary>
        public string SurfaceQuality { get; set; }

        /// <summary>
        /// 循环应变比
        /// </summary>
        public string CyclicStrainRatio { get; set; }

        #region 低周疲劳计算结果参数

        /// <summary>
        /// 低周疲劳 循环强度系数Κ＇/MPa
        /// </summary>
        public decimal? CyclicStrengthParameter { get; set; }

        /// <summary>
        /// 低周疲劳 循环应变硬化指数
        /// </summary>
        public decimal? CyclicStrainHardening { get; set; }

        /// <summary>
        /// 低周疲劳 应力应变相关系数
        /// </summary>
        public decimal? RelatedSressParameter { get; set; }

        /// <summary>
        /// 低周疲劳 疲劳强度系数
        /// </summary>
        public decimal? FatigueStrengthParameter { get; set; }

        /// <summary>
        /// 低周疲劳 疲劳强度指数
        /// </summary>
        public decimal? FatigueStrength { get; set; }

        /// <summary>
        /// 低周疲劳 应变寿命疲劳强度相关系数
        /// </summary>
        public decimal? RelatedLifeFatigueParameter { get; set; }

        /// <summary>
        /// 低周疲劳 疲劳延性系数
        /// </summary>
        public decimal? FatigueStrechParameter { get; set; }

        /// <summary>
        /// 低周疲劳 疲劳延性指数
        /// </summary>
        public decimal? FatigueStrech { get; set; }

        /// <summary>
        /// 低周疲劳 应变寿命疲劳延性相关系数
        /// </summary>
        public decimal? RelatedLifeStrechParameter { get; set; }

        #endregion
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }


       
        /// <summary>
        /// 屈服强度标准
        /// </summary>
        public decimal? FormYieldStrength { get; set; }

        /// <summary>
        /// 拉伸强度标准
        /// </summary>
        public decimal? FormTensileStrength { get; set; }

     
        /// <summary>
        /// 断后伸长率标准
        /// </summary>
        public decimal? FormModulusOfElasticity { get; set; }

        #endregion
    }
}