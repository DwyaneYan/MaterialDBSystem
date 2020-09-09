using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace HanGang.MaterialSystem.TrialDataDetails
{
    public class BaseTrialDataDetailDto

    {
        /// <summary>
        /// 测试机构
        /// </summary>
        public string TestOrganization { get; set; }
        /// <summary>
        /// 试验方法
        /// </summary>
        public string TestMethod { get; set; }
        /// <summary>
        /// 检测开始日期
        /// </summary>
        public DateTime? Dates { get; set; }
        /// <summary>
        /// 检测结束日期
        /// </summary>
        public DateTime? DateEnds { get; set; }
        /// <summary>
        /// 材料样本图片/base64图片
        /// </summary>
        public string FileString { get; set; }


        /// <summary>
        /// 图文文件服务key
        /// </summary>
        public string FileKey { get; set; }


    }
}