
using Microsoft.AspNetCore.Http;
using System;
using Volo.Abp.Application.Dtos;

namespace HanGang.MaterialSystem.Materials.Dtos
{
    public class AddPictureDto
    {
        

        public Guid Id { get; set; }

        /// <summary>
        /// 材料样本图片/base64图片
        /// </summary>
        public string FileString { get; set; }

        /// <summary>
        /// 图文文件服务key
        /// </summary>
        public string FileKey { get; set; }
         /// <summary>
        /// 文件二进制内容
        /// </summary>
        public byte[] FileBytes { get; set; }

        
        public IFormFile Photo { get; set; }
        public IFormFile Document { get; set; }
    }
}