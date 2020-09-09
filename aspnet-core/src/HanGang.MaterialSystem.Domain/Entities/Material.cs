using System;
using System.Collections.Generic;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities
{
    public class Material : FullAuditedAggregateRoot<Guid>
    {
        #region 基础字段 实验数据导入时,材料名称 编码 规格 送检日期确定唯一材料
        /// <summary>
        /// 材料标准
        /// </summary>
        public string MaterialStandard { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 卷号
        /// </summary>
        public decimal? ReelNumber { get; set; }
        

        /// <summary>
        /// 材料编码
        /// </summary>
        public string Code { get; set; }

      
        /// <summary>
        /// 型号规格 
        /// </summary>
        public decimal? Model { get; set; }

        /// <summary>
        /// 强度
        /// </summary>
        public decimal? Strength { get; set; }

        /// <summary>
        /// 材料类型
        /// </summary>
        public MaterialType MaterialType { get; set; }

        ///// <summary>
        ///// 检测开始日期
        ///// </summary>
        //public DateTime? Date { get; set; }
        ///// <summary>
        ///// 检测结束日期
        ///// </summary>
        //public DateTime? DateEnd { get; set; }

        /// <summary>
        /// 应用车型
        /// </summary>
        public string AppliedVehicleType { get; set; }

        /// <summary>
        /// 材料备注
        /// </summary>
        public string Remark { get; set; }

        #endregion

        #region 图片/文件信息

        /// <summary>
        /// 材料样本图片/base6E:\vs2019\project\HanGangMaterialSystem\aspnet-core\src\HanGang.MaterialSystem.Application\TrialDataDetails\4图片
        /// </summary>
        public string FileString { get; set; }

        /// <summary>
        /// 文件服务key
        /// </summary>
        public string FileKey { get; set; }

       

        #endregion 

        #region 典型零部件 生产厂家

        /// <summary>
        /// 典型零部件
        /// </summary>
        public Guid? TypicalPartId { get; set; }

        /// <summary>
        /// 典型零部件
        /// </summary>
        public virtual TypicalPart TypicalPart { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public Guid? ManufactoryId { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public virtual Manufactory Manufactory { get; set; }


        #endregion

        #region 材料试验项目
        
        /// <summary>
        /// 材料试验项目
        /// </summary>
        public virtual HashSet<MaterialTrial> MaterialTrials { get; set; } = new HashSet<MaterialTrial>();
        /// <summary>
        /// 应用案例
        /// </summary>
        public virtual HashSet<ApplicationCase> ApplicationCases { get; set; } = new HashSet<ApplicationCase>();



        #endregion
    }
}
