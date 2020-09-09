using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Materials;
using HanGang.MaterialSystem.Materials.Dtos;
using HanGang.MaterialSystem.TrialDataDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;


namespace HanGang.MaterialSystem.Controllers
{
    [Route("api/hangang/[action]")]
    public class MaterialController : MaterialSystemController
    {
        private IMaterialAppService _materialAppService;
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<MaterialRecommendation> _materialRecommendationRepository;
        private readonly IWebHostEnvironment _webHostEnviornment;


        public MaterialController(
            IMaterialAppService materialAppService,
            IRepository<Material> materialRepository,
            IRepository<MaterialRecommendation> materialRecommendationRepository,
        IWebHostEnvironment webHostEnviornment)
       
        {
            _materialAppService = materialAppService;
            _materialRepository = materialRepository;
            _materialRecommendationRepository = materialRecommendationRepository;
            _webHostEnviornment = webHostEnviornment;
         }
        #region demon
        ///// <summary>
        ///// controller中添加材料例子
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<Guid> MaterialCreate(MaterialDto input)
        //{

        //    return await _materialAppService.AddMaterial(input);
        //}

        ///// <summary>
        ///// 材料文件id查询下载
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> MaterialDocumentGet(AddPictureDto model)
        //{
        //    try
        //    {
        //        var project = await _materialRepository.GetAsync(model.Id);

        //        var stream = System.IO.File.OpenRead(project.FileString);
        //        string fileExt = Path.GetExtension(project.FileString);
        //        //获取文件的ContentType
        //        var provider = new FileExtensionContentTypeProvider();
        //        var memi = provider.Mappings[fileExt];
        //        return File(stream, memi, Path.GetFileName(project.FileString));
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }



        //}

        ///// <summary>
        ///// 根据材料id加载图片
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<FileContentResult> MaterialDocumentLoading(AddPictureDto model)
        //{
        //    try
        //    {
        //        var project = await _materialRepository.GetAsync(model.Id);          
        //        FileInfo fi = new FileInfo(project.FileString);
        //        string fileExt = Path.GetExtension(project.FileString);                
        //        FileStream fs = fi.OpenRead();
        //        byte[] buffer = new byte[fi.Length];
        //        //读取图片字节流
        //        //从流中读取一个字节块，并在给定的缓冲区中写入数据。
        //        fs.Read(buffer, 0, Convert.ToInt32(fi.Length));
        //        var resource = File(buffer, "image/"+fileExt);
        //        fs.Close();
        //        return resource;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
        ///// <summary>
        ///// controller中添加材料图片等文件以及信息\
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        ////[FromForm]

        //[HttpPost]
        //public async Task<Guid> MaterialDocumentadd(MaterialDto model)
        //{
        //    model.FileString = "";
        //    string uniqueFileName = null;
        //    string filepath = null;
        //    if (model.Photo != null && model.Photo.Count > 0)
        //    {
        //        foreach (var photo in model.Photo)
        //        {
        //            string webroot = _webHostEnviornment.ContentRootPath;
        //            string webrootpath = webroot.Remove(webroot.LastIndexOf("\\"));
        //            //string ccc = model.Photo.ContentType;
        //            string uploadsfolder = Path.Combine(webrootpath, "HanGang.MaterialSystem.IdentityServer\\wwwroot\\images");
        //            uniqueFileName = DateTime.Now.ToString("MMddHHmmss") + "_" + photo.FileName;
        //            filepath = Path.Combine(uploadsfolder, uniqueFileName);
        //            photo.CopyTo(new FileStream(filepath, FileMode.Create));
        //            model.FileString = model.FileString + ';' + model.FileString;
        //        }
        //    }

        //    return await _materialAppService.AddMaterial(model);

        //}
        #endregion
        /// <summary>
        /// 材料的应用案例自动导出
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ApplicationCaseExportOne(Guid id)
        {
            try
            {
              string filename= _materialAppService.ApplicationCaseExport(id);
                string path = _webHostEnviornment.ContentRootPath + "\\uploads\\documents";

                string filePath = Path.Combine(path, filename);
                var stream = System.IO.File.OpenRead(filePath);
                string fileExt = Path.GetExtension(filePath);
                var provider = new FileExtensionContentTypeProvider();
                //获取文件的ContentType,e如果不存在对应的map，会返回null，不影响下载                
                provider.Mappings.TryGetValue(fileExt, out var contenttype);
                return File(stream, contenttype ?? "application/vnd.ms-excel" );
                //return File(stream, contenttype ?? "application/vnd.ms-excel", DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename);



            }

            catch (Exception ex)
            {
                return null;
            }
        }
        ///// <summary>
        ///// 文档加载部分,返回的文档路径
        ///// </summary>
        ///// <param name="id"></param>     
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<List<string>> CommonFileStringStreamDocumentPath(Guid id)
        //{
        //    try
        //    {
        //        var project = await _materialRepository.GetAsync(id);
        //        string[] documentName = project.FileKey.Split(";");
        //        string path = _webHostEnviornment.ContentRootPath + "uploads\\documents";
        //        List<string> documentNameFilePath = new List<string>();
        //        for (int i = 0; i< documentName.Length - 1; i++) 
        //        {

        //            var filePath = Path.Combine(path, documentName[i]);
        //            documentNameFilePath.Add(filePath);

        //        }
        //        return documentNameFilePath;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }



        //}
        ///// <summary>
        ///// 材料根据id和上传文档更新上传文档
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        ////[FromForm]

        //[HttpPut]
        //public async Task<string> MaterialDocumentPut(UploadDto model)
        //{
        //    try
        //    {
        //        var project = await _materialRepository.GetAsync(model.Id);


        //        string documentName = null;
        //        if (model.Document != null)
        //        {
        //            documentName = await CommonFileStringDocumentUpload(model.Document);
        //            project.FileKey += documentName;

        //        }
        //        return "success:" + documentName;

        //    }


        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
        ///// <summary>
        ///// 材料根据id和文档名删除文档
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        ////[FromForm]

        //[HttpPut]
        //public async Task<string> MaterialDocumentDelete(UploadDto model)
        //{
        //    try
        //    {
        //        var project = await _materialRepository.GetAsync(model.Id);

        //        if (model.FileKey != null)
        //        {
        //            var sign = CommonFileStringDocumentDelete(model.FileKey);

        //            project.FileKey = project.FileKey.Replace(model.FileKey + ";", "");

        //        }
        //        return "success";

        //    }


        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}


        /// <summary>
        /// 材料根据id和上传图片更新上传图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[FromForm]

        [HttpPut]
        public async Task<UploadResponseDto> MaterialPicturePut(UploadDto model)
        {
            try
            {
                var project = await _materialRepository.GetAsync(model.Id);
                //两表之间没有键之间的关联，通过这种方式改变图片字段存储
                var project1 = _materialRecommendationRepository
                    .Where(t => t.MaterialId == model.Id)
                    .FirstOrDefault();

                string documentName = null;
                if (model.Photo != null)
                {
                    //材料表图片字段只保留一张图片，所以要删掉之前的
                    if (!project.FileString.IsNullOrEmpty())
                    {
                        var sign = CommonFileStringDelete(project.FileString.Replace(";", "").Trim());
                    }
                    documentName = await CommonFileStringUpload(model.Photo);
                    project.FileString = documentName;

                }
                project1.FileString = project.FileString;
                UploadResponseDto uploadResponseDto = new UploadResponseDto
                {
                    Id = "101"
                };
                return uploadResponseDto;

            }


            catch (Exception )
            {
                return null;
            }

        }
        /// <summary>
        /// 材料根据id和图片名删除图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[FromForm]

        [HttpPut]
        public async Task<UploadResponseDto> MaterialPictureDelete(UploadDto model)
        {
            try
            {
                var project = await _materialRepository.GetAsync(model.Id);
                //两表之间没有键之间的关联，通过这种方式改变图片字段存储
                var project1 = _materialRecommendationRepository
                    .Where(t => t.MaterialId == model.Id)
                    .FirstOrDefault();

                if (model.FileString != null)
                {
                    var sign = CommonFileStringDelete(model.FileString);

                    project.FileString = project.FileString.Replace(model.FileString + ";", "");

                }
                project1.FileString = project.FileString;
                UploadResponseDto uploadResponseDto = new UploadResponseDto
                {
                    Id = "101"
                };
                return uploadResponseDto;

            }


            catch (Exception)
            {
                return null;
            }

        }
        /// <summary>
        /// 图片删除公共部分，根据图片名字删除,每次删除一个
        /// </summary>
        /// <param name="pictureName"></param>

        /// <returns></returns>

        protected string CommonFileStringDelete(string pictureName)
        {
            try
            {
                if (pictureName == null)
                {
                    return null;
                }


                string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

                string filePath = Path.Combine(path, pictureName);
                System.IO.File.Delete(filePath);

                return "success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// 图片上传公共部分，每次上传一个
        /// </summary>
        /// <param name="picture"></param>        
        /// <returns></returns>

        protected async Task<string> CommonFileStringUpload(IFormFile picture)
        {
            try
            {
                string contentRootPath = _webHostEnviornment.ContentRootPath;
                string uploadsPicture = Path.Combine(contentRootPath, "uploads\\images");
                string filename;

                //取文件名不要带地址"\\"和"/",所以+1不然会报错
                if (picture.FileName.Contains("\\"))
                {
                    filename = picture.FileName.Substring(picture.FileName.LastIndexOf("\\") + 1);
                }
                else
                {
                    filename = picture.FileName.Substring(picture.FileName.LastIndexOf("/") + 1);
                }
                string pictureuniqueFileName;
                pictureuniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename;
                string filePath = Path.Combine(uploadsPicture, pictureuniqueFileName);
                //因为使用了非托管资源，所以需要手动进行释放
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    await picture.CopyToAsync(fileStream);
                }

                return pictureuniqueFileName + ";";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// 文档删除公共部分，根据文档名字删除,每次删除一个
        /// </summary>
        /// <param name="documentName"></param>

        /// <returns></returns>

        protected string CommonFileStringDocumentDelete(string documentName)
        {
            try
            {
                if (documentName == null)
                {
                    return null;
                }


                string path = _webHostEnviornment.ContentRootPath + "\\uploads\\documents";

                string filePath = Path.Combine(path, documentName);
                System.IO.File.Delete(filePath);

                return "success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// 文档上传公共部分，每次上传一个
        /// </summary>
        /// <param name="document"></param>        
        /// <returns></returns>

        protected async Task<string> CommonFileStringDocumentUpload(IFormFile document)
        {
            try
            {
                string contentRootPath = _webHostEnviornment.ContentRootPath;
                string uploadsDocument = Path.Combine(contentRootPath, "uploads\\documents");
                string filename;

                //取文件名不要带地址"\\"和"/",所以+1不然会报错
                if (document.FileName.Contains("\\"))
                {
                    filename = document.FileName.Substring(document.FileName.LastIndexOf("\\") + 1);
                }
                else
                {
                    filename = document.FileName.Substring(document.FileName.LastIndexOf("/") + 1);
                }
                string documentuniqueFileName;
                documentuniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename;
                string filePath = Path.Combine(uploadsDocument, documentuniqueFileName);
                //因为使用了非托管资源，所以需要手动进行释放
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    await document.CopyToAsync(fileStream);
                }

                return documentuniqueFileName + ";";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #region 无用
        ////以前写的无用

        ///// <summary>
        ///// 材料根据id加载图片接口
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> MaterialDocumentLoadingOne(AddPictureDto model)
        //{
        //    try
        //    {
        //        var project = await _materialRepository.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

        //        string filePath = Path.Combine(path, project.FileString);
        //        var stream = System.IO.File.OpenRead(filePath);
        //        string fileExt = Path.GetExtension(filePath);
        //        var provider = new FileExtensionContentTypeProvider();  //获取文件的ContentType
        //        var memi = provider.Mappings[fileExt];
        //        return File(stream, memi);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}
        ///// <summary>
        ///// 材料根据id加载文档接口
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> MaterialDocumentLoadingTwo(AddPictureDto model)
        //{
        //    try
        //    {
        //        var project = await _materialRepository.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\documents";

        //        string filePath = Path.Combine(path, project.FileKey);
        //        var stream = System.IO.File.OpenRead(filePath);
        //        string fileExt = Path.GetExtension(filePath);
        //        var provider = new FileExtensionContentTypeProvider();  //获取文件的ContentType
        //        var memi = provider.Mappings[fileExt];
        //        return File(stream, memi);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}
        ///// <summary>
        ///// 材料根据id查询下载文档
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> MaterialDocumentGet(AddPictureDto model)
        //{
        //    try
        //    {
        //        var project = await _materialRepository.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\documents";

        //        string filePath = Path.Combine(path, project.FileKey);
        //        var stream = System.IO.File.OpenRead(filePath);
        //        string fileExt = Path.GetExtension(filePath);
        //        var provider = new FileExtensionContentTypeProvider();  //获取文件的ContentType
        //        var memi = provider.Mappings[fileExt];
        //        return File(stream, memi, Path.GetFileName(project.FileKey));
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }



        //}
        #endregion





    }
}
