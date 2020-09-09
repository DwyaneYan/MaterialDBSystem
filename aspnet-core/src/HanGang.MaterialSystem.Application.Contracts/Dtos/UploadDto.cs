using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace HanGang.MaterialSystem.TrialDataDetails
{
    public class UploadDto

    {
        /// <summary>
        /// Id
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
        /// 文档名字
        /// </summary>
        public string FileKey { get; set; }
        /// <summary>
        /// 文档文件流 
        /// </summary>
        public IFormFile Document { get; set; }



    }
}