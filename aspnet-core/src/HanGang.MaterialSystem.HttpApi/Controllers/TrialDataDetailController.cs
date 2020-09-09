
using HanGang.MaterialSystem.CementingDataDetails.Dtos;
using HanGang.MaterialSystem.DentResistanceDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.FlangingClaspDataDetails.Dtos;
using HanGang.MaterialSystem.HighSpeedStrechDataDetails.Dtos;
using HanGang.MaterialSystem.LinqExtensions;

using HanGang.MaterialSystem.Materials.Dtos;
using HanGang.MaterialSystem.MetallographicDataDetails.Dtos;
using HanGang.MaterialSystem.PaintingDataDetails.Dtos;
using HanGang.MaterialSystem.SecondaryWorkingEmbrittlementDataDetails.Dtos;
using HanGang.MaterialSystem.TrialDataDetails;
using HanGang.MaterialSystem.TrialDataDetails.MetallographicDataDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HanGang.MaterialSystem.Controllers
{
    [Route("api/hangang/trialdatadetail/[action]")]
    public class TrialDataDetailController : MaterialSystemController
    {

        private readonly IWebHostEnvironment _webHostEnviornment;
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<ApplicationCase> _applicationCaseRepository;

        private IMetallographicDataDetailAppService _metallographicDataDetailAppService;
        private readonly IRepository<MetallographicDataDetail> _metallographicDataDetailRepository;
        private readonly IRepository<SecondaryWorkingEmbrittlementDataDetail> _secondaryWorkingEmbrittlementDataDetailRepository;
        private readonly IRepository<FlangingClaspDataDetail> _flangingClaspDataDetailRepository;
        private readonly IRepository<CementingDataDetail> _cementingDataDetailRepository;
        private readonly IRepository<PaintingDataDetail> _paintingDataDetailRepository;
        private readonly IRepository<HighSpeedStrechDataDetail> _highSpeedStrechDataDetailRepository;
        private readonly IRepository<DentResistanceDataDetail> _dentResistanceDataDetailRepository;

       
        

        public TrialDataDetailController(
            IWebHostEnvironment webHostEnviornment,
            IRepository<Material> materialRepository,
            IRepository<ApplicationCase> applicationCaseRepository,

            IMetallographicDataDetailAppService metallographicDataDetailAppService,
            IRepository<MetallographicDataDetail> metallographicDataDetailRepository,
            IRepository<SecondaryWorkingEmbrittlementDataDetail> secondaryWorkingEmbrittlementDataDetailRepository,
            IRepository<FlangingClaspDataDetail> flangingClaspDataDetailRepository,
            IRepository<CementingDataDetail> cementingDataDetailRepository,
            IRepository<PaintingDataDetail> paintingDataDetailRepository,
            IRepository<HighSpeedStrechDataDetail> highSpeedStrechDataDetailRepository,
            IRepository<DentResistanceDataDetail> dentResistanceDataDetailRepository

            )

        {
            _webHostEnviornment = webHostEnviornment;
            _materialRepository = materialRepository;
            _applicationCaseRepository = applicationCaseRepository;

            _metallographicDataDetailAppService = metallographicDataDetailAppService;
            _metallographicDataDetailRepository = metallographicDataDetailRepository;
            _secondaryWorkingEmbrittlementDataDetailRepository = secondaryWorkingEmbrittlementDataDetailRepository;
            _flangingClaspDataDetailRepository = flangingClaspDataDetailRepository;
            _cementingDataDetailRepository = cementingDataDetailRepository;
            _paintingDataDetailRepository = paintingDataDetailRepository;
            _highSpeedStrechDataDetailRepository = highSpeedStrechDataDetailRepository;
            _dentResistanceDataDetailRepository = dentResistanceDataDetailRepository;
           
        }

        #region 用多个Iformfile新增加demo
        ///// <summary>
        ///// controller金相试验添加图片等文件以及信息\
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<Guid> MetallographicDataDetailDocumentadd(MetallographicDataDetailDto model)
        //{
        //    string contentRootPath = _webHostEnviornment.ContentRootPath;
        //    string uploadsPath = Path.Combine(contentRootPath,"uploads\\images");
        //    //金相试验图片            
        //    string structureuniqueFileName = null;
        //    if (model.StructurePhoto != null)
        //    {                          
        //        structureuniqueFileName = DateTime.Now.ToString("MMddHHmmss") + "_" + model.StructurePhoto.FileName;                
        //        string filePath = Path.Combine(uploadsPath, structureuniqueFileName);
        //        model.StructurePhoto.CopyTo(new FileStream(filePath, FileMode.Create));
        //    }
        //    //非金属夹杂图片           
        //    string nonMetallicInclusionLeveluniqueFileName  = null;
        //    if (model.NonMetallicInclusionLevelPhoto != null)
        //    {                           
        //        nonMetallicInclusionLeveluniqueFileName = DateTime.Now.ToString("MMddHHmmss") + "_" + model.NonMetallicInclusionLevelPhoto.FileName;
        //        string filePath = Path.Combine(uploadsPath, nonMetallicInclusionLeveluniqueFileName);
        //        model.NonMetallicInclusionLevelPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
        //    }
        //    //晶粒度试验图片图片           
        //    string grainSizeuniqueFileName = null;
        //    if (model.GrainSizePhoto != null)
        //    { 
        //        grainSizeuniqueFileName = DateTime.Now.ToString("MMddHHmmss") + "_" + model.GrainSizePhoto.FileName;
        //        string filePath = Path.Combine(uploadsPath, grainSizeuniqueFileName);
        //        model.GrainSizePhoto.CopyTo(new FileStream(filePath, FileMode.Create));
        //    }
        //    //脱碳层深度试验图片            
        //    string depthDecarburizationuniqueFileName = null;
        //    if (model.DepthDecarburizationPhoto != null)
        //    {
        //        depthDecarburizationuniqueFileName = DateTime.Now.ToString("MMddHHmmss") + "_" + model.DepthDecarburizationPhoto.FileName;
        //        string filePath = Path.Combine(uploadsPath, depthDecarburizationuniqueFileName);
        //        model.DepthDecarburizationPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
        //    }

        //    model.StructureString = structureuniqueFileName;
        //    model.NonMetallicInclusionLevelString = nonMetallicInclusionLeveluniqueFileName ;
        //    model.GrainSizeString = grainSizeuniqueFileName;
        //    model.DepthDecarburizationString = depthDecarburizationuniqueFileName;
        //    return await _metallographicDataDetailAppService.AddMetallographicData(model);

        // }
        #endregion


        /// <summary>
        /// 导出材料卡片
        /// </summary>
        /// <param name="documentName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OutputKfile(string documentName)
        {
            try
            {
                if (documentName == null)
                {
                    return null;
                }
                string path = _webHostEnviornment.ContentRootPath + "\\uploads\\documents";

                string filePath = Path.Combine(path, documentName);
                var stream = System.IO.File.OpenRead(filePath);
                string fileExt = Path.GetExtension(filePath);
                var provider = new FileExtensionContentTypeProvider();
                //获取文件的ContentType,e如果不存在对应的map，会返回null            
                provider.Mappings.TryGetValue(fileExt, out var contenttype);
                return File(stream, contenttype ?? "application/octet-stream", documentName);

            }
            catch (Exception)
            {
                return null;
            }
        }
        #region 图片和文档

        /// <summary>
        /// 文档加载公共部分,返回的是文件流，根据文档名字加载
        /// </summary>
        /// <param name="documentName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CommonFileStringStreamDocument(string documentName)
        {
            try
            {
                if (documentName == null)
                {
                    return null;
                }


                string path = _webHostEnviornment.ContentRootPath + "\\uploads\\documents";

                string filePath = Path.Combine(path, documentName);
                var stream = System.IO.File.OpenRead(filePath);
                string fileExt = Path.GetExtension(filePath);
                var provider = new FileExtensionContentTypeProvider(); 
                //获取文件的ContentType,e如果不存在对应的map，会返回null            
                provider.Mappings.TryGetValue(fileExt,out var contenttype);             
                return File(stream,contenttype??"application/octet-stream" );

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 图片加载公共部分,返回的是文件流，根据图片名字加载
        /// </summary>
        /// <param name="pictureName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CommonFileStringStream(string pictureName)
        {
            try
            {
                if (pictureName == null)
                {
                    return null;
                }
                string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

                string filePath = Path.Combine(path, pictureName);
                var stream = System.IO.File.OpenRead(filePath);
                string fileExt = Path.GetExtension(filePath);
                var provider = new FileExtensionContentTypeProvider();  //获取文件的ContentType
               //var memi = provider.Mappings[fileExt];
               //return File(stream, memi);
                provider.Mappings.TryGetValue(fileExt, out var contenttype);
                return File(stream, contenttype ?? "application/octet-stream" );
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 文档下载公共部分根据文档名字
        /// </summary>
        /// <param name="documentName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CommonFileStringStreamDocumentDownload(string documentName)
        {
            try
            {
                if (documentName == null)
                {
                    return null;
                }
                string path = _webHostEnviornment.ContentRootPath + "\\uploads\\documents";
                string filePath = Path.Combine(path, documentName);
                var stream = System.IO.File.OpenRead(filePath);
                string fileExt = Path.GetExtension(filePath);
                var provider = new FileExtensionContentTypeProvider();
                //获取文件的ContentType,e如果不存在对应的map，会返回null，不影响下载                
                provider.Mappings.TryGetValue(fileExt, out var contenttype);
                return File(stream, contenttype ?? "application/octet-stream", documentName);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 图片下载公共部分根据图片名字 
        /// </summary>
        /// <param name="pictureName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CommonFileStringStreamDownload(string pictureName)
        {
            try
            {
                if (pictureName == null)
                {
                    return null;
                }
                string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

                string filePath = Path.Combine(path, pictureName);
                var stream = System.IO.File.OpenRead(filePath);
                string fileExt = Path.GetExtension(filePath);
                var provider = new FileExtensionContentTypeProvider();  //获取文件的ContentType
                                                                        //var memi = provider.Mappings[fileExt];
                                                                        //return File(stream, memi);
                provider.Mappings.TryGetValue(fileExt, out var contenttype);
                return File(stream, contenttype ?? "application/octet-stream", pictureName);
            }
            catch (Exception)
            {
                return null;
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

                return pictureuniqueFileName+";";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        #endregion

        #region 材料上传材料文件

        /// <summary>
        ///  材料根据Id上传试验文档
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<UploadResponseDto> MaterialDocumentPut(UploadDto model)
        {
            try
            {
                var project = await _materialRepository.GetAsync(model.Id);

                string documentName = null;
                if (model.Document != null)
                {
                    documentName = await CommonFileStringDocumentUpload(model.Document);

                    project.FileKey += documentName;

                }


                UploadResponseDto uploadResponseDto = new UploadResponseDto
                {
                    Id = "101"
                };
                return uploadResponseDto;



            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///  材料根据Id和文档名字（FileKey）删除试验文档
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<UploadResponseDto> MaterialDocumentDelete(UploadDto model)
        {
            try
            {
                var project = await _materialRepository.GetAsync(model.Id);


                if (model.FileKey != null)
                {
                    var sign = CommonFileStringDocumentDelete(model.FileKey );

                    project.FileKey = project.FileKey.Replace(model.FileKey  + ";", "");

                }
                UploadResponseDto uploadResponseDto = new UploadResponseDto
                {
                    Id = "101"
                };
                return uploadResponseDto;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
     
        #endregion

        #region 应用案例

        /// <summary>
        ///  应用案例根据Id上传试验图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<UploadResponseDto> ApplicationCasePicturePut(UploadDto model)
        {
            try
            {
                var project = await _applicationCaseRepository.GetAsync(model.Id);

                string pictureName = null;
                if (model.Photo != null)
                {
                    pictureName = await CommonFileStringUpload(model.Photo);
                   
                    project.FileString += pictureName;
                   
                }

              
                    UploadResponseDto uploadResponseDto = new UploadResponseDto
                    {
                        Id = "101"
                    };
                    return uploadResponseDto;
               


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///  应用案例根据Id和图片名字（FileString）删除试验图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<UploadResponseDto> ApplicationCasePictureDelete(UploadDto model)
        {
            try
            {
                var project = await _applicationCaseRepository.GetAsync(model.Id);


                if (model.FileString != null)
                {
                    var sign = CommonFileStringDelete(model.FileString);

                    project.FileString = project.FileString.Replace(model.FileString + ";", "");
                   
                }
                UploadResponseDto uploadResponseDto = new UploadResponseDto
                {
                    Id = "101"
                };
                return uploadResponseDto;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///  应用案例根据Id上传试验pdf
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<UploadResponseDto> ApplicationCaseDocumentPut(UploadDto model)
        {
            try
            {
                var project = await _applicationCaseRepository.GetAsync(model.Id);


                string documentName = null;
                if (model.Document != null)
                {
                    documentName = await CommonFileStringDocumentUpload(model.Document);
                    if(!project.FileKey.IsNullOrEmpty())
                    {
                        //字段中默认只放一个文档所以要删除掉之前的
                        var sign =  project.FileKey.Replace( ";", "");
                        CommonFileStringDocumentDelete(sign);
                    }
                    project.FileKey = documentName;

                }
                UploadResponseDto uploadResponseDto = new UploadResponseDto
                {
                    Id = "101"
                };
                return uploadResponseDto;

            }


            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///  应用案例根据Id和文档名字（FileKey）删除试验pdf
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<UploadResponseDto> ApplicationCaseDocumentDelete(UploadDto model)
        {
            try
            {
                var project = await _applicationCaseRepository.GetAsync(model.Id);

                if (model.FileKey != null)
                {
                    var sign = CommonFileStringDocumentDelete(model.FileKey);

                    //project.FileKey = project.FileKey.Replace(model.FileKey + ";", "");
                    project.FileKey =null;

                }
                UploadResponseDto uploadResponseDto = new UploadResponseDto
                {
                    Id = "101"
                };
                return uploadResponseDto;

            }


            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        //#region 二次加工脆化

        ///// <summary>
        /////  二次加工脆化试验根据MaterialTrialDataId上传试验图片
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<string> SecondaryWorkingEmbrittlementDocumentPut(UploadDto model)
        //{
        //    try
        //    {
        //        //根据MaterialTrialDataId得到对应的数据数组
        //        var project =  _secondaryWorkingEmbrittlementDataDetailRepository
        //                            //.AsNoTracking() 去掉这句才会同步更新数据库字段
        //                             .Where( x => x.MaterialTrialDataId == model.Id)
        //                             .OrderBy(p => p.CreationTime)
        //                             .ToList(); 

        //        string pictureName = null;
        //        if (model.Photo != null)
        //        {
        //             pictureName =await CommonFileStringUpload(model.Photo);
        //            //循环数据组，每个都加上图片名称
        //            foreach (var item in project)
        //            {                    
        //                item.FileString += pictureName;
        //            }
        //        }               
        //        return "success:"+ pictureName;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        ///// <summary>
        /////  二次加工脆化试验根据MaterialTrialDataId删除试验图片
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public  string SecondaryWorkingEmbrittlementDocumentDelete(UploadDto model)
        //{
        //    try
        //    {
        //        //根据MaterialTrialDataId得到对应的数据数组
        //        var project = _secondaryWorkingEmbrittlementDataDetailRepository
        //                             //.AsNoTracking() 去掉这句才会同步更新数据库字段
        //                             .Where(x => x.MaterialTrialDataId == model.Id)
        //                             .OrderBy(p => p.CreationTime)
        //                             .ToList(); 


        //        if (model.FileString != null)
        //        {
        //           var sign = CommonFileStringDelete(model.FileString);
        //            //循环数据组，每个都加去掉图片名称
        //            foreach (var item in project)
        //            {
        //                item.FileString=item.FileString.Replace(model.FileString+";","");
        //            }
        //        }
        //        return "success" ;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}




        //#endregion

        //#region 翻边扣合

        ///// <summary>
        /////  翻边扣合试验根据id更新上传试验图片文件
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<FlangingClaspDataDetailDto> FlangingClaspDataDetailDocumentPut(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _flangingClaspDataDetailRepository.GetAsync(model.Id);
        //        string contentRootPath = _webHostEnviornment.ContentRootPath;
        //        string uploadsPath = Path.Combine(contentRootPath, "uploads\\images");
        //        //删除文件为了更新
        //        if (project.FileString != null && model.Photo != null)
        //        {
        //            string filePath = Path.Combine(uploadsPath, project.FileString);
        //            System.IO.File.Delete(filePath);
        //        }

        //        string uniqueFileName = null;
        //        if (model.Photo != null)
        //        {
        //            uniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + model.Photo.FileName;
        //            string filePath = Path.Combine(uploadsPath, uniqueFileName);
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            { model.Photo.CopyTo(fileStream); }
        //            project.FileString = uniqueFileName;
        //        }
        //        return ObjectMapper.Map<FlangingClaspDataDetail, FlangingClaspDataDetailDto>(project);

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }


        //}
        ///// <summary>
        /////  翻边扣合试验根据id加载试验图片
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> FlangingClaspDataDetailDocumentLoading(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _flangingClaspDataDetailRepository.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

        //        string filePath = Path.Combine(path, project.FileString);
        //        var stream = System.IO.File.OpenRead(filePath);
        //        string fileExt = Path.GetExtension(filePath);
        //        var provider = new FileExtensionContentTypeProvider();
        //        var memi = provider.Mappings[fileExt];
        //        return File(stream, memi);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}
        //#endregion

        //#region 胶接

        ///// <summary>
        /////  胶接试验根据id更新上传试验图片文件
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<CementingDataDetailDto> CementingDataDetailDocumentPut(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _cementingDataDetailRepository.GetAsync(model.Id);
        //        string contentRootPath = _webHostEnviornment.ContentRootPath;
        //        string uploadsPath = Path.Combine(contentRootPath, "uploads\\images");
        //        //删除文件为了更新
        //        if (project.FileString != null && model.Photo != null)
        //        {
        //            string filePath = Path.Combine(uploadsPath, project.FileString);
        //            System.IO.File.Delete(filePath);
        //        }

        //        string uniqueFileName = null;
        //        if (model.Photo != null)
        //        {
        //            uniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + model.Photo.FileName;
        //            string filePath = Path.Combine(uploadsPath, uniqueFileName);
        //            //因为使用了非托管资源，所以需要手动进行释放
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            { model.Photo.CopyTo(fileStream); }
        //            project.FileString = uniqueFileName;
        //        }
        //        return ObjectMapper.Map<CementingDataDetail, CementingDataDetailDto>(project);

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }


        //}
        ///// <summary>
        /////  胶接试验根据id加载试验图片
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> CementingDataDetailDocumentLoading(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _cementingDataDetailRepository.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

        //        string filePath = Path.Combine(path, project.FileString);
        //        var stream = System.IO.File.OpenRead(filePath);
        //        string fileExt = Path.GetExtension(filePath);
        //        var provider = new FileExtensionContentTypeProvider();
        //        var memi = provider.Mappings[fileExt];
        //        return File(stream, memi);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}
        //#endregion

        //#region 涂装

        ///// <summary>
        /////  涂装性能试验根据id更新上传试验图片文件
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<PaintingDataDetailDto> PaintingDataDetailDocumentPut(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _paintingDataDetailRepository.GetAsync(model.Id);
        //        string contentRootPath = _webHostEnviornment.ContentRootPath;
        //        string uploadsPath = Path.Combine(contentRootPath, "uploads\\images");
        //        //删除文件为了更新
        //        if (project.FileString != null && model.Photo != null)
        //        {
        //            string filePath = Path.Combine(uploadsPath, project.FileString);
        //            System.IO.File.Delete(filePath);
        //        }

        //        string uniqueFileName = null;
        //        if (model.Photo != null)
        //        {
        //            uniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + model.Photo.FileName;
        //            string filePath = Path.Combine(uploadsPath, uniqueFileName);
        //            //因为使用了非托管资源，所以需要手动进行释放
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            { model.Photo.CopyTo(fileStream); }
        //            project.FileString = uniqueFileName;
        //        }
        //        return ObjectMapper.Map<PaintingDataDetail, PaintingDataDetailDto>(project);

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }


        //}
        ///// <summary>
        /////  涂装性能试验根据id加载试验图片
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> PaintingDataDetailDocumentLoading(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _paintingDataDetailRepository.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

        //        string filePath = Path.Combine(path, project.FileString);
        //        var stream = System.IO.File.OpenRead(filePath);
        //        string fileExt = Path.GetExtension(filePath);
        //        var provider = new FileExtensionContentTypeProvider();
        //        var memi = provider.Mappings[fileExt];
        //        return File(stream, memi);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}
        //#endregion

        //#region 高速拉伸

        ///// <summary>
        /////  高速拉伸试验根据id更新上传试验图片文件
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<HighSpeedStrechDataDetailDto> HighSpeedStrechDataDetailDocumentPut(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _highSpeedStrechDataDetailRepository.GetAsync(model.Id);
        //        string contentRootPath = _webHostEnviornment.ContentRootPath;
        //        string uploadsPath = Path.Combine(contentRootPath, "uploads\\images");
        //        //删除文件为了更新
        //        if (project.FileString != null && model.Photo != null)
        //        {
        //            string filePath = Path.Combine(uploadsPath, project.FileString);
        //            System.IO.File.Delete(filePath);
        //        }

        //        string uniqueFileName = null;
        //        if (model.Photo != null)
        //        {
        //            uniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + model.Photo.FileName;
        //            string filePath = Path.Combine(uploadsPath, uniqueFileName);
        //            //因为使用了非托管资源，所以需要手动进行释放
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            { model.Photo.CopyTo(fileStream); }
        //            project.FileString = uniqueFileName;
        //        }
        //        return ObjectMapper.Map<HighSpeedStrechDataDetail, HighSpeedStrechDataDetailDto>(project);

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }


        //}
        ///// <summary>
        /////  高速拉伸试验根据id加载试验图片
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> HighSpeedStrechDataDetailDocumentLoading(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _highSpeedStrechDataDetailRepository.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

        //        string filePath = Path.Combine(path, project.FileString);
        //        var stream = System.IO.File.OpenRead(filePath);
        //        string fileExt = Path.GetExtension(filePath);
        //        var provider = new FileExtensionContentTypeProvider();
        //        var memi = provider.Mappings[fileExt];
        //        return File(stream, memi);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}
        //#endregion

        //#region 抗凹

        ///// <summary>
        /////  抗凹试验根据id更新上传试验图片文件
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<DentResistanceDataDetailDto> DentResistanceDataDetailDocumentPut(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _dentResistanceDataDetail.GetAsync(model.Id);
        //        string contentRootPath = _webHostEnviornment.ContentRootPath;
        //        string uploadsPath = Path.Combine(contentRootPath, "uploads\\images");
        //        //删除文件为了更新
        //        if (project.PrimaryLoadingCurveString != null && model.PrimaryLoadingCurvePhoto != null)
        //        {
        //            string filePath = Path.Combine(uploadsPath, project.PrimaryLoadingCurveString);
        //            System.IO.File.Delete(filePath);
        //        }
        //        if (project.CyclicLoadingCurveString != null && model.CyclicLoadingCurvePhoto != null)
        //        {
        //            string filePath = Path.Combine(uploadsPath, project.CyclicLoadingCurveString);
        //            System.IO.File.Delete(filePath);
        //        }
        //        if (project.DentDpthLoadCurveString != null && model.DentDpthLoadCurvePhoto != null)
        //        {
        //            string filePath = Path.Combine(uploadsPath, project.DentDpthLoadCurveString);
        //            System.IO.File.Delete(filePath);
        //        }

        //        //一次加载曲线图片            
        //        string primaryLoadingCurveuniqueFileName = null;
        //        if (model.PrimaryLoadingCurvePhoto != null)
        //        {
        //            primaryLoadingCurveuniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + model.PrimaryLoadingCurvePhoto.FileName;
        //            string filePath = Path.Combine(uploadsPath, primaryLoadingCurveuniqueFileName);
        //            //因为使用了非托管资源，所以需要手动进行释放
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            { model.PrimaryLoadingCurvePhoto.CopyTo(fileStream); }                   
        //            project.PrimaryLoadingCurveString = primaryLoadingCurveuniqueFileName;
        //        }
        //        //晶粒度图片         
        //        string cyclicLoadingCurvePhotouniqueFileName = null;
        //        if (model.CyclicLoadingCurvePhoto != null)
        //        {
        //            cyclicLoadingCurvePhotouniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + model.CyclicLoadingCurvePhoto.FileName;
        //            string filePath = Path.Combine(uploadsPath, cyclicLoadingCurvePhotouniqueFileName);

        //            //因为使用了非托管资源，所以需要手动进行释放
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            { model.CyclicLoadingCurvePhoto.CopyTo(fileStream); }                   
        //            project.CyclicLoadingCurveString = cyclicLoadingCurvePhotouniqueFileName;
        //        }
        //        //凹痕深度载荷图片           
        //        string dentDpthLoadCurvePhotouniqueFileName = null;
        //        if (model.DentDpthLoadCurvePhoto != null)
        //        {
        //            dentDpthLoadCurvePhotouniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + model.DentDpthLoadCurvePhoto.FileName;
        //            string filePath = Path.Combine(uploadsPath, dentDpthLoadCurvePhotouniqueFileName);
        //            //因为使用了非托管资源，所以需要手动进行释放
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            { model.DentDpthLoadCurvePhoto.CopyTo(fileStream); }

        //            project.DentDpthLoadCurveString = dentDpthLoadCurvePhotouniqueFileName;
        //        }              

        //        return ObjectMapper.Map<DentResistanceDataDetail, DentResistanceDataDetailDto>(project);

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }


        //}
        ///// <summary>
        ///// 抗凹试验根据id加载一次加载曲线图片/base64图片PrimaryLoadingCurveString
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> DentResistanceDataDetailDocumentLoadingOne(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _dentResistanceDataDetail.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

        //        string filePath = Path.Combine(path, project.PrimaryLoadingCurveString);
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
        ///// 抗凹试验根据id加载晶粒度图片/base64图片CyclicLoadingCurve
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> DentResistanceDataDetailDocumentLoadingTwo(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _dentResistanceDataDetail.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

        //        string filePath = Path.Combine(path, project.CyclicLoadingCurveString);
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
        ///// 抗凹试验根据id加载凹痕深度载荷图片/base64图片
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> DentResistanceDataDetailDocumentLoadingThree(TrialDataDetailDto model)
        //{
        //    try
        //    {
        //        var project = await _dentResistanceDataDetail.GetAsync(model.Id);
        //        string path = _webHostEnviornment.ContentRootPath + "\\uploads\\images";

        //        string filePath = Path.Combine(path, project.DentDpthLoadCurveString);
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

        //#endregion
    }

}
