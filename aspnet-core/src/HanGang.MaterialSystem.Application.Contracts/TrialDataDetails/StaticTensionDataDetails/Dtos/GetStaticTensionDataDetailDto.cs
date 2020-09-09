using HanGang.MaterialSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.GetStaticTensionDataDetails.Dtos
{
    public class GetStaticTensionDataDetailDto : PagedInputDto
    {
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
        /// <summary>
        /// 材料样本图片/base64图片2
        /// </summary>
        public string FileString2 { get; set; }

        /// <summary>
        /// 材料样本图片/base64图片3
        /// </summary>
        public string FileString3 { get; set; }
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

        #endregion
        #region        
        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }

        #endregion

        #region 公共试验参数/条件 同参数的材料 试验数据可能多条...

        /// <summary>
        /// 执行标准
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        /// 序号 按送检日期 从1开始自增
        /// </summary>
        public int? SerialNumber { get; set; }

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
        public decimal? Width { get; set; }

        /// <summary>
        /// 试样真实厚度
        /// </summary>
        public decimal? Thickness { get; set; }

        /// <summary>
        /// 试样真实直径(mm)
        /// </summary>
        public decimal? Diameter { get; set; }

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
        /// 规定非比例延伸率(静态拉伸试验的试验参数)
        /// </summary>
        public decimal? NonProportionalExtendRatio { get; set; }

        /// <summary>
        /// 屈服强度Rp(MPa)
        /// </summary>
        public decimal? YieldStrength { get; set; }

        /// <summary>
        /// 抗拉强度Rm(MPa)
        /// </summary>
        public decimal? TensileStrength { get; set; }

        /// <summary>
        /// 应变硬化指数
        /// </summary>
        public decimal? StrainHardening { get; set; }

        /// <summary>
        /// 断后伸长率
        /// </summary>
        public decimal? Elongation { get; set; }

        /// <summary>
        /// 塑性应变比γ(%)
        /// </summary>
        public decimal? PlasticStrainRatio { get; set; }

        /// <summary>
        /// 弹性模量E(MPa)
        /// </summary>
        public decimal? ModulusOfElasticity { get; set; }

        /// <summary>
        /// 泊松比μ
        /// </summary>
        public decimal? PoissonRatio { get; set; }

        /// <summary>
        /// 最大力Fm(kN)
        /// </summary>
        public decimal? MaximumForce { get; set; }
    }
}
