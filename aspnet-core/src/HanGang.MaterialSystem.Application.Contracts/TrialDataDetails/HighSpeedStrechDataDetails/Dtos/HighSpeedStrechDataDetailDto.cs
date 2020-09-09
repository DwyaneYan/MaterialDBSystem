using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.HighSpeedStrechDataDetails.Dtos
{
    public class HighSpeedStrechDataDetailDto : BaseTrialDataDetailDto
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
        /// 试样真实厚度
        /// </summary>
        public decimal? Thickness { get; set; }

 

        /// <summary>
        /// 标距(mm)
        /// </summary>
        public decimal? GaugeDistance { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        #endregion
        /// <summary>
        /// 取样方向
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 拉伸速率测试指标
        /// </summary>
        public decimal? TestTarget { get; set; }

        /// <summary>
        /// 屈服强度Rp(MPa)
        /// </summary>
        public decimal? YieldStrength { get; set; }

        /// <summary>
        /// 抗拉强度Rm(MPa)
        /// </summary>
        public decimal? TensileStrength { get; set; }

        /// <summary>
        /// 断后伸长率
        /// </summary>
        public decimal? Elongation { get; set; }

        /// <summary>
        /// 拉伸速度(m/s)
        /// </summary>
        public decimal? StretchingSpeed { get; set; }
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
        /// 弹性模量标准
        /// </summary>
        public decimal? FormElongation { get; set; }

        /// <summary>
        /// 断后伸长率标准
        /// </summary>
        public decimal? FormModulusOfElasticity { get; set; }
        /// <summary>
        /// 杨氏模量
        /// </summary>
        public decimal? YoungModulu { get; set; }
        /// <summary>
        /// 泊松比
        /// </summary>
        public decimal? PoissonRatio { get; set; }

        #endregion
    }
}