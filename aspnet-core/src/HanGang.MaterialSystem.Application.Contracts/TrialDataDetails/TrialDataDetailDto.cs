using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace HanGang.MaterialSystem.TrialDataDetails
{
    public class TrialDataDetailDto

    {
        /// <summary>
        /// MaterialTrialDataId
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 图片文件名字
        /// </summary>
        public string FileString { get; set; }
        /// <summary>
        /// 图片文件流
        /// </summary>
        public IFormFile Photo { get; set; }

        /// <summary>
        /// 抗凹性能一次加载曲线图片/base64图片PrimaryLoadingCurveString
        /// </summary>
        public IFormFile PrimaryLoadingCurvePhoto { get; set; }

        /// <summary>
        /// 抗凹性能晶粒度图片/base64图片CyclicLoadingCurve
        /// </summary>
        public IFormFile CyclicLoadingCurvePhoto { get; set; }

        /// <summary>
        /// 抗凹性能凹痕深度载荷图片/base64图片DentDpthLoadCurve
        /// </summary>
        public IFormFile DentDpthLoadCurvePhoto { get; set; }

     
    }
}