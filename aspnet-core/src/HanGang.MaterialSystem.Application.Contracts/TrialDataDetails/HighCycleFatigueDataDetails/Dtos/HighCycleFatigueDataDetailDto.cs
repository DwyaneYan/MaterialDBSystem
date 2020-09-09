using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.HighCycleFatigueDataDetails.Dtos
{
    public class HighCycleFatigueDataDetailDto : BaseTrialDataDetailDto
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
        /// 是否使用引伸计
        /// </summary>
        public bool? UseExtensometer { get; set; }

        /// <summary>
        /// 引伸计标距(mm)
        /// </summary>
        public decimal? ExtensometerGaugeDistance { get; set; }

        /// <summary>
        /// 表面质量
        /// </summary>
        public string SurfaceQuality { get; set; }

        /// <summary>
        /// 循环应力比
        /// </summary>
        public string CyclicStressRatio { get; set; }

        #region 高周疲劳计算结果参数 S-N曲线

        /// <summary>
        /// 高周疲劳 S-N曲线参数a
        /// </summary>
        public decimal? SNAParameter { get; set; }

        /// <summary>
        /// 高周疲劳 S-N曲线参数b
        /// </summary>
        public decimal? SNBParameter { get; set; }

        /// <summary>
        /// 高周疲劳 S-N曲线相关系数
        /// </summary>
        public decimal? SNRelatedParameter { get; set; }

        /// <summary>
        /// 高周疲劳 疲劳极限强度/MPa
        /// </summary>
        public decimal? FatigueLimitStrength { get; set; }

        /// <summary>
        /// 高周疲劳 标准偏差/MPa
        /// </summary>
        public decimal? StandardDeviation { get; set; }

        #endregion 高周疲劳计算结果参数 S-N曲线
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
        /// <summary>
        /// 公式
        /// </summary>
        public string Formula { get; set; }
        #endregion
    }
}