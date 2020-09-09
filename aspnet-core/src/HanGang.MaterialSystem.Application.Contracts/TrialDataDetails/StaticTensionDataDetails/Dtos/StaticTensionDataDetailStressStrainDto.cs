using System;

namespace HanGang.MaterialSystem.StaticTensionDataDetails.Dtos
{
    public class StaticTensionDataDetailStressStrainDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
        #region 关联静态拉伸试验数据

        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? StaticTensionDataDetailId { get; set; }

       

        #endregion

        /// <summary>
        /// 应力
        /// </summary>
        public decimal? Stress { get; set; }

        /// <summary>
        /// 应变
        /// </summary>
        public decimal? Strain { get; set; }

        /// <summary>
        /// 真应力
        /// </summary>
        public decimal? RealStress { get; set; }

        /// <summary>
        /// 真应变
        /// </summary>
        public decimal? RealStrain { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
    }
}