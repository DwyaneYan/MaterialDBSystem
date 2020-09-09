using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 公共数据明细类
    /// </summary>
    public class BaseTrialDataDetail : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料试验数据

        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }

        /// <summary>
        /// 材料试验
        /// </summary>
        public virtual MaterialTrialData MaterialTrialData { get; set; }

        #endregion

        #region 公共试验参数/条件 同参数的材料 试验数据可能多条...

        /// <summary>
        /// 检测开始日期
        /// </summary>
        public DateTime? Dates { get; set; }
        /// <summary>
        /// 检测结束日期
        /// </summary>
        public DateTime? DateEnds { get; set; }
        /// <summary>
        /// 执行标准
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        /// 试验设备
        /// </summary>
        public string Equipment { get; set; }
        /// <summary>
        /// 测试机构
        /// </summary>
        public string TestOrganization { get; set; }
        /// <summary>
        /// 试验方法
        /// </summary>
        public string TestMethod { get; set; }

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

        #region 试验文件/图片/报告(pdf/excel)

        /// <summary>
        /// 材料样本图片/base64图片
        /// </summary>
        public string FileString { get; set; }

       

        /// <summary>
        /// 图文文件服务key
        /// </summary>
        public string FileKey { get; set; }

      

        #endregion

        #region 标准表字段
        /// <summary>
        /// 屈服强度标准
        /// </summary>
        public decimal? FormYieldStrength { get; set; }

        /// <summary>
        /// 抗拉强度标准
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
    }
}
