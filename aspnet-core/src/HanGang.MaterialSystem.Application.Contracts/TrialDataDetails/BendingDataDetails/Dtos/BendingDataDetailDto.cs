using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.BendingDataDetails.Dtos
{
    public class BendingDataDetailDto : BaseTrialDataDetailDto
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
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        #endregion
       
        /// <summary>
        /// 抗弯强度Rm(MPa)
        /// </summary>
        public decimal? BendingStrength { get; set; }

        /// <summary>
        /// 规定非比例弯曲强度
        /// </summary>
        public decimal? NonProportionalBendingStrenth { get; set; }

        /// <summary>
        /// 弯曲弹性模量E(MPa)
        /// </summary>
        public decimal? BendingOfElasticity { get; set; }
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
    

  
        /// <summary>
        /// 跨距
        /// </summary>
        public decimal? Span { get; set; }

        #endregion
    }
}