using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.PhysicalPerformanceDataDetails.Dtos
{
    public class PhysicalPerformanceDataDetailDto : BaseTrialDataDetailDto
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
        /// 维氏硬度（HV）
        /// </summary>
        public decimal? HV { get; set; }

        /// <summary>
        /// 布氏硬度（HBW）
        /// </summary>
        public decimal? HBW { get; set; }

        /// <summary>
        /// 洛氏硬度（HRC）
        /// </summary>
        public decimal? HRC { get; set; }

        /// <summary>
        /// 密度ρ（g/cm3）
        /// </summary>
        public decimal? Density { get; set; }

        /// <summary>
        /// 电阻率ρ（Ω·m）
        /// </summary>
        public decimal? Resistivity { get; set; }
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
       

      

        #endregion
    }
}