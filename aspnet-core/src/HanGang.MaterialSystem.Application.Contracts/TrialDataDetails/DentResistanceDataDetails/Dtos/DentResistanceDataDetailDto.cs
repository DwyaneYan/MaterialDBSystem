using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.DentResistanceDataDetails.Dtos
{
    public class DentResistanceDataDetailDto : BaseTrialDataDetailDto
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
        /// 初始刚度(N/mm)
        /// </summary>
        public decimal? OriginalRigidity { get; set; }

        /// <summary>
        /// 0.1mm可见凹痕载荷(N)
        /// </summary>
        public decimal? VisibleDentLoad { get; set; }


    
        #region 新增字段
        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
       

       

        #endregion

    }
}