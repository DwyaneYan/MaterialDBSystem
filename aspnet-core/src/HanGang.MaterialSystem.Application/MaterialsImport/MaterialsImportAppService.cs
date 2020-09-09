using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Materials.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using HanGang.MaterialSystem.Materials;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using Workbook = Spire.Xls.Workbook;
using Worksheet = Spire.Xls.Worksheet;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace HanGang.MaterialSystem.Trials
{
    /// <summary>
    /// 材料服务
    /// </summary>
    public class MaterialsImportAppService : MaterialSystemAppService
    {
        private readonly IRepository<Material> _materialRepository;

        public MaterialsImportAppService(
            IRepository<Material> materialRepository)
        {
            _materialRepository = materialRepository;
        }

        /// <summary>
        /// 添加材料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>between types 'System.String' and 'System.Nullable`1[System.Guid]'.”

        public IListResult <MaterialDto> AddMaterial(string input)
        {
            try
            {
                //    var material = new Material
                //    {
                //        Name = input.Name,
                //        Model = input.Model,
                //        Strength = input.Strength,
                //        MaterialType = input.MaterialType,
                //        Date = input.Date,               
                //        TypicalPartId = input.TypicalPartId,
                //        ManufactoryId = input.ManufactoryId,
                //        FileString = input.FileString
                //};

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromFile(input);

                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //获取指定单元格的值
                string value = sheet.Range["A2"].Value2.ToString();
                //自定义时间格式
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy/MM/dd";

                var material = new MaterialDto
                {
                    Name = sheet.Range["A2"].Value2.ToString(),
                    //Model = sheet.Range["C2"].Value2.ToString(),
                    TypicalPartId = new Guid(sheet.Range["a2"].Value2.ToString()),
                    
                    //Date= Convert.ToDateTime(sheet.Range["b2"].Value2.ToString(), dtFormat)//注意:string格式有要求,yyyy/MM/dd

                };

               //释放资源
                wb.Dispose();
                //await _materialRepository.InsertAsync(material);

                return null;
                   
            }

            catch (Exception )
            {
                return null;
            }

        }

    }
}