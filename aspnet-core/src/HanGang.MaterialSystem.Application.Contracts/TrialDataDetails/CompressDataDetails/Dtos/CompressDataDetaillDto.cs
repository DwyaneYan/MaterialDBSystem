using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.CompressDataDetails.Dtos
{
    public class CompressDataDetailDto : BaseTrialDataDetailDto
    {
        #region        
        /// <summary>
        /// 材料试验数据id
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }

        #endregion

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
        /// 抗压强度Rm(MPa)
        /// </summary>
        public decimal? CompressiveStrength { get; set; }

        /// <summary>
        /// 规定非比例压缩强度
        /// </summary>
        public decimal? NonProportionalCompressStrenth { get; set; }

        /// <summary>
        /// 压缩弹性模量E(MPa)
        /// </summary>
        public decimal? CompressOfElasticity { get; set; }
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
        

        

        #endregion
    }
}