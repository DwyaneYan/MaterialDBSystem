using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.ApplicationCases.Dtos;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using HanGang.MaterialSystem.BendingDataDetails.Dtos;
using HanGang.MaterialSystem.CementingDataDetails.Dtos;
using HanGang.MaterialSystem.ChemicalElementDataDetails.Dtos;
using HanGang.MaterialSystem.CompressDataDetails.Dtos;
using HanGang.MaterialSystem.DentResistanceDataDetails.Dtos;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.FlangingClaspDataDetails.Dtos;
using HanGang.MaterialSystem.FLDDataDetailDetails.Dtos;
using HanGang.MaterialSystem.HighCycleFatigueDataDetails.Dtos;
using HanGang.MaterialSystem.HighSpeedStrechDataDetails.Dtos;
using HanGang.MaterialSystem.HydrogenInducedDelayedFractureDataDetails.Dtos;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.LowCycleFatigueDataDetails.Dtos;
using HanGang.MaterialSystem.MaterialTrials.Dtos;
using HanGang.MaterialSystem.MetallographicDataDetails.Dtos;
using HanGang.MaterialSystem.PaintingDataDetails.Dtos;
using HanGang.MaterialSystem.PhysicalPerformanceDataDetails.Dtos;
using HanGang.MaterialSystem.ProhibitedSubstanceDataDetails.Dtos;
using HanGang.MaterialSystem.ReboundDataDetails.Dtos;
using HanGang.MaterialSystem.SecondaryWorkingEmbrittlementDataDetails.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using HanGang.MaterialSystem.SurfacePropertyDataDetails.Dtos;
using HanGang.MaterialSystem.Trials.Dtos;
using HanGang.MaterialSystem.WeldingDataDetails.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;



namespace HanGang.MaterialSystem.MaterialTrials
{
    /// <summary>
    /// 材料试验及获取试验数据服务
    /// </summary>
    public class MaterialTrialAppService : MaterialSystemAppService, IMaterialTrialAppService
    {
        private readonly IWebHostEnvironment _webHostEnviornment;
        private readonly IRepository<Trial> _trialRepository;
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<ApplicationCase> _applicationCaseRepository;
        private readonly IRepository<MaterialTrial> _materialtrialRepository;
        private readonly IRepository<MaterialTrialData> _materialTrialDataRepository;
        private readonly IRepository<StaticTensionDataDetail> _staticTensionDataDetailRepository;
        private readonly IRepository<StaticTensionDataDetailStressStrain> _staticTensionDataDetailStressStrainRepository;
        private readonly IRepository<BendingDataDetail> _bendingDataDetailRepository;
        private readonly IRepository<CompressDataDetail> _compressDataDetailRepository;
        private readonly IRepository<HighSpeedStrechDataDetail> _highSpeedStrechDataDetailRepository;
        private readonly IRepository<LowCycleFatigueDataDetail> _lowCycleFatigueDataDetailRepository;
        private readonly IRepository<HighCycleFatigueDataDetail> _highCycleFatigueDataDetailRepository;
        private readonly IRepository<MetallographicDataDetail> _metallographicDataDetailRepository;
        private readonly IRepository<PhysicalPerformanceDataDetail> _physicalPerformanceDataDetailRepository;
        private readonly IRepository<ChemicalElementDataDetail> _chemicalElementDataDetailRepository;
        private readonly IRepository<ProhibitedSubstanceDataDetail> _prohibitedSubstanceDataDetailRepository;


        public MaterialTrialAppService( 
            IRepository<Trial> trialRepository,
            IRepository<Material> materialRepository,
            IRepository<ApplicationCase> applicationCaseRepository,
            IRepository<MaterialTrial> materialTrialRepository,
            IRepository<MaterialTrialData> materialTrialDataRepository,
            IRepository<StaticTensionDataDetail> staticTensionDataDetailRepository,
            IRepository<StaticTensionDataDetailStressStrain> staticTensionDataDetailStressStrainRepository,
            IRepository<BendingDataDetail> bendingDataDetailRepository,
            IRepository<CompressDataDetail> compressDataDetailRepository,
            IRepository<HighSpeedStrechDataDetail> highSpeedStrechDataDetailRepository,
            IRepository<LowCycleFatigueDataDetail> lowCycleFatigueDataDetailRepository,
            IRepository<HighCycleFatigueDataDetail> highCycleFatigueDataDetailRepository,
            IRepository<MetallographicDataDetail> metallographicDataDetailRepository,
            IRepository<PhysicalPerformanceDataDetail> physicalPerformanceDataDetailRepository,
            IRepository<ChemicalElementDataDetail> chemicalElementDataDetailRepository,
            IRepository<ProhibitedSubstanceDataDetail> prohibitedSubstanceDataDetailRepository
            )

        {
            _trialRepository = trialRepository;
            _materialRepository = materialRepository;
            _applicationCaseRepository = applicationCaseRepository;
            _materialtrialRepository = materialTrialRepository;
            _materialTrialDataRepository = materialTrialDataRepository;
            _staticTensionDataDetailRepository = staticTensionDataDetailRepository;
            _staticTensionDataDetailStressStrainRepository = staticTensionDataDetailStressStrainRepository;
            _bendingDataDetailRepository = bendingDataDetailRepository;
            _compressDataDetailRepository = compressDataDetailRepository;
            _compressDataDetailRepository = compressDataDetailRepository;
            _highSpeedStrechDataDetailRepository = highSpeedStrechDataDetailRepository;
            _lowCycleFatigueDataDetailRepository = lowCycleFatigueDataDetailRepository;
            _highCycleFatigueDataDetailRepository = highCycleFatigueDataDetailRepository;
            _metallographicDataDetailRepository = metallographicDataDetailRepository;
            _physicalPerformanceDataDetailRepository = physicalPerformanceDataDetailRepository;
            _chemicalElementDataDetailRepository = chemicalElementDataDetailRepository;
            _prohibitedSubstanceDataDetailRepository = prohibitedSubstanceDataDetailRepository;
        }

        /// <summary>
        /// 根据材料id获取对应所有应用案例
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ApplicationCaseDto> GetApplicationCaseByMaterialId(Guid materialId)
        {
            //1.根据材料Id找到对应应用案例
            var applicationCases = _applicationCaseRepository
                .AsNoTracking()
                .Where(m => m.MaterialId == materialId)
                .OrderBy(p => p.CreationTime)
                .ToList();
            //2.返回对应应用案例
            return ObjectMapper.Map<List<ApplicationCase>, List<ApplicationCaseDto>>(applicationCases);
        }
        /// <summary>
        /// 根据材料id和车型获取对应所有应用案例
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<ApplicationCaseDto> GetApplicationCaseByInput(ApplicationCaseDto input)
        {
            //1.找到对应应用案例
            var applicationCases = _applicationCaseRepository
                .AsNoTracking()               
                .WhereIf(input.MaterialId.HasValue,x=>x.MaterialId==input.MaterialId)
                .WhereIf(!string.IsNullOrEmpty( input.VehicleType), x => x.VehicleType == input.VehicleType)
                .OrderBy(p => p.CreationTime)
                .ToList();
            //2.返回对应应用案例
            return ObjectMapper.Map<List<ApplicationCase>, List<ApplicationCaseDto>>(applicationCases);
        }
        /// <summary>
        /// 添加应用案例
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddApplicationCase(ApplicationCaseDto input)
        {
            var applicationCase = new ApplicationCase
            {
                Remark = input.Remark,
                MaterialId = input.MaterialId,
                VehicleType = input.VehicleType,
                Breif = input.Breif,
                Requirement = input.Requirement,
                SuppliedPart = input.SuppliedPart
            };
            await _applicationCaseRepository.InsertAsync(applicationCase);
            return applicationCase.Id;
        }
        /// <summary>
        /// 更新某个应用案例
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateApplicationCase(ApplicationCaseDto input)
        {
            var applicationCase = await _applicationCaseRepository.GetAsync(input.Id);
            applicationCase.Remark = input.Remark;
            applicationCase.MaterialId = input.MaterialId;
            applicationCase.VehicleType = input.VehicleType;
            applicationCase.Breif = input.Breif;
            applicationCase.Requirement = input.Requirement;
            applicationCase.SuppliedPart = input.SuppliedPart;
            return applicationCase.Id;
        }

        /// <summary>
        /// 根据应用案例Id删除某个应用案例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteApplicationCase(Guid id)
        {
           
            await _applicationCaseRepository.DeleteAsync(m => m.Id == id);
        }

        /// <summary>
        /// 根据应用案例Id获取某个应用案例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApplicationCaseDto> GetApplicationCaseById(Guid id)
        {
            var applicationCase = await _applicationCaseRepository.GetAsync(id);
            return ObjectMapper.Map<ApplicationCase, ApplicationCaseDto>(applicationCase);
        }

        /// <summary>
        /// 根据材料id获取对应实验项目
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<TrialDto> GetTrialItemByMaterialId(Guid materialId)
        {
            //1.根据材料Id找到这个材料做了哪些试验
            var trials = _materialtrialRepository
                .AsNoTracking()
                .Include(m => m.Trial)
                .ThenInclude(y => y.Parent)
                .Where(m => m.MaterialId == materialId)
                .Select(n => n.Trial)
                 .OrderBy(p => p.CreationTime)
                .ToList();
            //2.返回此材料做的所有实验项目
            return ObjectMapper.Map<List<Trial>, List<TrialDto>>(trials);
        }
     
        /// <summary>
        /// 获取所有材料试验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<MaterialTrialDto>> GetMaterialTrials(GetMaterialTrialListInputDto input)
        {
            return _materialtrialRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name))
                .WhereIf(input.MaterialId.HasValue, x => x.MaterialId == input.MaterialId)   //按材料id查询材料试验
                .OrderBy(input.Sorting)
               
                .ProjectTo<MaterialTrialDto>(Configuration)
                .ToPageResultAsync(input);
        }


        /// <summary>
        /// 根据材料试验Id获取某个材料试验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MaterialTrialDto> GetMaterialTrialById(Guid id)
        {
            var materialtrial = await _materialtrialRepository.GetAsync(id);
            return ObjectMapper.Map<MaterialTrial, MaterialTrialDto>(materialtrial);
        }

        /// <summary>
        /// 添加材料试验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddMaterialTrial(AddMaterialTrialInputDto input)
        {
            var materialtrial = new MaterialTrial
            {
                Name = input.Name,
                Code = input.Code,
                Remark = input.Remark,
                MaterialId = input.MaterialId,
                TrialId = input.TrialId
            };
            await _materialtrialRepository.InsertAsync(materialtrial);
            return materialtrial.Id;
        }

        /// <summary>
        /// 更新某个材料试验信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateMaterialTrial(MaterialTrialDto input)
        {
            var materialtrial = await _materialtrialRepository.GetAsync(input.Id);
            materialtrial.Name = input.Name;
            materialtrial.Code = input.Code;
            materialtrial.Remark = input.Remark;
            materialtrial.MaterialId = input.MaterialId;
            materialtrial.TrialId = input.TrialId;
            return materialtrial.Id;
        }

        /// <summary>
        /// 根据材料试验Id删除某个材料试验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            //var manufactory = await _manufactoryRepository.GetAsync(id);
            await _materialtrialRepository.DeleteAsync(m => m.Id == id);
        }

        /// <summary>
        /// 数据过滤演示 同步方法演示
        /// </summary>
        /// <param name="id"></param>
        public List<TrialDto> GetAllDataExample(Guid id)
        {
            //1.根据材料Id找到这个材料做了哪些试验
            var trials = _materialtrialRepository
                .AsNoTracking()
                .Where(m => m.MaterialId == id)
                .Select(n => n.Trial)
                .ToList();
            //2、返回此材料做了哪些试验的  试验数据明细信息
            return ObjectMapper.Map<List<Trial>, List<TrialDto>>(trials);

            ////寻找静态拉伸数据明细
            //var staticData = _materialTrialDataRepository
            //    .AsNoTracking()
            //    .Include(x => x.StaticTensionDataDetails)
            //    .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
            //    .Where(m => m.MaterialTrial.Trial.TrialType == TrialType.静态拉伸
            //                && m.MaterialTrial.Material.Id == id
            //                && m.MaterialTrial.Material.Strength < 500
            //                && m.MaterialTrial.Material.Strength > 200)
            //    .SelectMany(n => n.StaticTensionDataDetails)
            //    .ToList();

            ////直接取静态拉伸试验数据
            //var staticData1 = _staticTensionDataDetailRepository.AsNoTracking()
            //    .Include(y => y.StaticTensionDataDetailStressStrains)
            //    .Where(m => m.MaterialTrialData.MaterialTrial.Material.Name == "DC01")
            //    .ToList();
        }
        #region 获取理化性能试验项目数据
        /// <summary>
        /// 获取静态拉伸数据明细
        /// </summary>
        /// <param name="materialId"></param>
        public List<StaticTensionDataDetailDto> GetStaticTensionDataDetails(Guid materialId)
        {

            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<StaticTensionDataDetail>, List<StaticTensionDataDetailDto>>(staticData);

        }
        /// <summary>
        /// 获取静态拉伸数据明细用于对比页面
        /// </summary>
        /// <param name="materialId"></param>
        public List<StaticTensionDataDetailDto> GetStaticTensionDataDetails2(Guid materialId)
        {

            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .Where(m => !m.SampleCode.Contains("小批量数据"))
                .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<StaticTensionDataDetail>, List<StaticTensionDataDetailDto>>(staticData);

        }
        /// <summary>
        /// 获取静态拉伸数据明细Requirement
        /// </summary>
        /// <param name="materialId"></param>
        public List<StaticTensionDataDetailRequirementDto> GetStaticTensionDataDetailRequirements(Guid materialId)
        {

            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetailRequirements)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.StaticTensionDataDetailRequirements)
                .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<StaticTensionDataDetailRequirement>, List<StaticTensionDataDetailRequirementDto>>(staticData);

        }
        /// <summary>
        /// 获取静态拉伸应力应变
        /// </summary>
        /// <param name="materialId"></param>

        public List<StaticTensionDataDetailStressStrainDto> GetStaticTensionDataDetailStressStrains(Guid materialId)
        {

            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .SelectMany(p => p.StaticTensionDataDetailStressStrains)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<StaticTensionDataDetailStressStrain>, List<StaticTensionDataDetailStressStrainDto>>(staticData);

        }

        /// <summary>
        /// 获取材料卡片公用信息
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<string> GetCommonCardData(Guid materialId)
        {
            List<string> CommonData = new List<string>();
            //材料表中取材料牌号
            var materialBaseData = _materialRepository
                .AsTracking()
                .Where(x => x.Id == materialId);
            string name = materialBaseData.FirstOrDefault()?.Name; //FirstOrDefault()取值操作！

            //物理性能表中取密度
            var physicalPerformanceData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PhysicalPerformanceDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PhysicalPerformanceDataDetails);
            Double ro0 = Convert.ToDouble(physicalPerformanceData.FirstOrDefault()?.Density) * 0.000000001;    //表中数据为g/cm^3,转换成k文件所需的tone/mm^3
            string ro = ro0 == 0 ? "2.70000E-9" : Convert.ToString(ro0);

            //高速拉伸中取弹性模量和泊松比
            var highSpeedStrechData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HighSpeedStrechDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(p => p.HighSpeedStrechDataDetails);

            Double e0 = Convert.ToDouble(highSpeedStrechData.FirstOrDefault()?.YoungModulu);
            Double e = e0 == 0 ? 70000.0 : e0;
            Double pr0 = Convert.ToDouble(highSpeedStrechData.FirstOrDefault()?.PoissonRatio);
            Double pr = pr0 == 0 ? 0.33 : pr0;

            string g = Convert.ToString(e / (2 * (1 + pr)));

            CommonData.Add(name);
            CommonData.Add(ro);
            CommonData.Add(Convert.ToString(e));
            CommonData.Add(Convert.ToString(pr));
            CommonData.Add(g);

            return CommonData;

        }
        /// <summary>
        /// 导出Type24材料卡片（静态拉伸）
        /// </summary>
        /// <param name="materialId"></param>
        public async Task<JObject> GetMaterialCardStaticTensionInfo(Guid materialId)
        {
            //卡片中所需信息
            string name;    //材料牌号
            string mid = "      1001"; //卡片编号
            string ro;      //密度t/mm^3
            string e;       //杨氏模量MPa
            string pr;      //泊松比
            string lcss = "      2001";       //应力应变曲线所对应的编号
            string lcid = lcss;  //应力应变曲线编号
            type24_staticTension Kmodel = new type24_staticTension();

            //材料表中取材料牌号
            var materialBaseData = _materialRepository
                .AsTracking()
                .Where(x => x.Id == materialId);
            name = materialBaseData.FirstOrDefault()?.Name; //FirstOrDefault()取值操作！

            //物理性能表中取密度
            var physicalPerformanceData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PhysicalPerformanceDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PhysicalPerformanceDataDetails);            
            Double ro0 = Convert.ToDouble(physicalPerformanceData.FirstOrDefault()?.Density) * 0.000000001;    //表中数据为g/cm^3,转换成k文件所需的tone/mm^3
            ro = ro0 == 0 ? Kmodel.ro : Convert.ToString(ro0);

            //高速拉伸中取弹性模量和泊松比
            var highSpeedStrechData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HighSpeedStrechDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(p => p.HighSpeedStrechDataDetails);

            Double e0 = Convert.ToDouble(highSpeedStrechData.FirstOrDefault()?.YoungModulu);
            e = e0 == 0 ? Kmodel.e : Convert.ToString(e0);
            Double pr0 = Convert.ToDouble(highSpeedStrechData.FirstOrDefault()?.PoissonRatio);
            pr = pr0 == 0 ? Kmodel.pr : Convert.ToString(pr0);

            //取静态拉伸真应力应变数据对
            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .SelectMany(p => p.StaticTensionDataDetailStressStrains)
                .OrderBy(p => p.CreationTime)
                .ToList();

            List<string> stress = new List<string>();
            List<string> strain = new List<string>();
            foreach (var item in staticData)
            {
                if(strain.Contains(Convert.ToString(item.RealStrain)))
                {
                    continue;
                }
                else
                {
                    stress.Add(Convert.ToString(item.RealStress));
                    strain.Add(Convert.ToString(item.RealStrain));
                }                
            }
                       

            ro = Kmodel.GetStandardData(ro);
            e = Kmodel.GetStandardData(e);
            pr = Kmodel.GetStandardData(pr);

            StringBuilder ssData = new StringBuilder();
            for( int i = 0; i != stress.Count; i++)
            {
                ssData.Append("          ");
                ssData.Append(Kmodel.GetStandardData(strain[i]));
                ssData.Append("          ");
                ssData.Append(Kmodel.GetStandardData(stress[i]));
                ssData.Append("\n");
            }

            
            StringBuilder DataList = new StringBuilder();
            DataList.Append(Kmodel.Title);
            DataList.Append(name);
            DataList.Append(Kmodel.Note);
            DataList.Append(mid);
            DataList.Append(ro);
            DataList.Append(e);
            DataList.Append(pr);
            DataList.Append(Kmodel.Content1);
            DataList.Append(lcss);
            DataList.Append(Kmodel.Content2);
            DataList.Append(lcss);
            DataList.Append(Kmodel.Content3);
            DataList.Append(ssData);
            DataList.Append(Kmodel.End);

            Console.WriteLine(DataList);

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string fileName = name + "_" + "type24_staticTension" + "_" + materialId.ToString() + ".k";
            string filePath = "../HanGang.MaterialSystem.HttpApi.Host/uploads/documents/" + name + "_" + "type24_staticTension" + "_" + materialId.ToString() + ".k";
            System.IO.File.WriteAllText(filePath, DataList.ToString(), utf8WithoutBom);

            JObject result = Kmodel.ReturnStandardValue(fileName);
            return result;
        }

        /// <summary>
        /// 获取Type12材料卡片
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public async Task<JObject> GetType12CardInfo(Guid materialId)
        {
            //卡片中所需信息
            string name;    //材料牌号
            string mid = "      1001"; //卡片编号
            string ro;      //密度t/mm^3
            string g;       //切变模量
            string sigh;      //屈服强度均值
            string etan ;       //塑性硬化模量
            string bulk ;  //体积模量
            type12 Kmodel = new type12();
            type24_staticTension Kmodel_tool = new type24_staticTension();

            //材料表中取材料牌号
            var materialBaseData = _materialRepository
                .AsTracking()
                .Where(x => x.Id == materialId);
            name = materialBaseData.FirstOrDefault().Name; //FirstOrDefault()取值操作！

            //物理性能表中取密度
            var physicalPerformanceData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PhysicalPerformanceDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PhysicalPerformanceDataDetails);
            Double ro0 = Convert.ToDouble(physicalPerformanceData.FirstOrDefault()?.Density) * 0.000000001;    //表中数据为g/cm^3,转换成k文件所需的tone/mm^3
            ro = ro0 == 0 ? Kmodel.ro : Convert.ToString(ro0);
            ro = Kmodel_tool.GetStandardData(ro);

            //高速拉伸中取弹性模量和泊松比
            var highSpeedStrechData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HighSpeedStrechDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(p => p.HighSpeedStrechDataDetails);

            Double e0 = Convert.ToDouble(highSpeedStrechData.FirstOrDefault()?.YoungModulu);
            Double e = e0 == 0 ? 70000.0 : e0;
            Double pr0 = Convert.ToDouble(highSpeedStrechData.FirstOrDefault()?.PoissonRatio);
            Double pr = pr0 == 0 ? 0.33 : pr0;
            string g0 = Convert.ToString(e/(2*(1+pr)));
            g = Kmodel_tool.GetStandardData(g0);

            var staticData = _materialTrialDataRepository
               .AsNoTracking()
               .Include(x => x.StaticTensionDataDetails)
               .Where(m => m.MaterialTrial.MaterialId == materialId)
               .SelectMany(n => n.StaticTensionDataDetails)
                .OrderBy(p => p.CreationTime)
               .ToList();

            List<double> ysValues = new List<double>();
            for(int i = 0; i!=staticData.Count; i++)
            {
                ysValues.Add(Convert.ToDouble(staticData[i].YieldStrength));
            }
            try 
            { 
                sigh = Convert.ToString(ysValues.Average());
            }
            catch
            {
                sigh = Kmodel.sigy;
            }
            sigh = Kmodel_tool.GetStandardData(sigh);

            //取静态拉伸真应力应变数据对
            var ssData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .SelectMany(p => p.StaticTensionDataDetailStressStrains)
                .OrderBy(p => p.CreationTime)
                .ToList();

            List<string> stress = new List<string>();
            List<string> strain = new List<string>();
            foreach (var item in ssData)
            {
                if (strain.Contains(Convert.ToString(item.RealStrain)))
                {
                    continue;
                }
                else
                {
                    stress.Add(Convert.ToString(item.RealStress));
                    strain.Add(Convert.ToString(item.RealStrain));
                }
            }

            try
            {
                double y1 = Convert.ToDouble(stress[0]);
                double y2 = Convert.ToDouble(stress[stress.Count]);
                double x1 = Convert.ToDouble(strain[0]);
                double x2 = Convert.ToDouble(strain[stress.Count]);
                etan = Convert.ToString((y2 - y1) / (x2 - x1));
            }
            catch
            {
                etan = "20000.0";
            }

            etan = Kmodel_tool.GetStandardData(etan);


            bulk = Convert.ToString(e / (3 * (1 - 2 * pr)));
            bulk = Kmodel_tool.GetStandardData(bulk);

            StringBuilder DataList = new StringBuilder();

            DataList = Kmodel.GetDataList(name, mid, ro, g, sigh, etan, bulk);

            //Console.WriteLine(DataList);
            
            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string fileName = name + "_" + "type12" + "_" + materialId.ToString() + ".k";
            string filePath = "../HanGang.MaterialSystem.HttpApi.Host/uploads/documents/" + name + "_" + "type12" + "_" + materialId.ToString() + ".k";
            System.IO.File.WriteAllText(filePath, DataList.ToString(), utf8WithoutBom);

            JObject result = Kmodel_tool.ReturnStandardValue(fileName);
            return result;
        }

        /// <summary>
        /// 获取Type15材料卡片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<JObject> GetType15CardInfo(GetType15CardDto input)
        {
            //卡片中所需信息
            string name;    //材料牌号
            string mid = "      1001"; //卡片编号
            string ro;      //密度t/mm^3
            string g;       //切变模量
            string e;      //弹性模量
            string pr;       //泊松比
            type15 Kmodel = new type15();
            type24_staticTension Kmodel_tool = new type24_staticTension();

            List<string> commonData = new List<string>();
            commonData = GetCommonCardData(input.materialId);
            name = commonData[0];
            ro = commonData[1];
            e = commonData[2];
            pr = commonData[3];
            g = commonData[4];

            ro = Kmodel_tool.GetStandardData(ro);
            g = Kmodel_tool.GetStandardData(g);
            e = Kmodel_tool.GetStandardData(e);
            pr = Kmodel_tool.GetStandardData(pr);

            string a = Kmodel_tool.GetStandardData(Convert.ToString(input.a));
            string b = Kmodel_tool.GetStandardData(Convert.ToString(input.b));
            string n = Kmodel_tool.GetStandardData(Convert.ToString(input.n));
            string c = Kmodel_tool.GetStandardData(Convert.ToString(input.c));
            string m = Kmodel_tool.GetStandardData(Convert.ToString(input.m));
            string tm = Kmodel_tool.GetStandardData(Convert.ToString(input.tm));
            string tr = Kmodel_tool.GetStandardData(Convert.ToString(input.tr));
            string cp = Kmodel_tool.GetStandardData(Convert.ToString(input.cp));

            StringBuilder DataList = new StringBuilder();
            DataList = Kmodel.GetDataList(name, mid, ro, g, e, pr, a, b, n, c, m, tm, tr, cp);

            Console.WriteLine(DataList);

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string fileName = name + "_" + "type15" + "_" + input.materialId.ToString() + ".k";
            string filePath = "../HanGang.MaterialSystem.HttpApi.Host/uploads/documents/" + name + "_" + "type15" + "_" + input.materialId.ToString() + ".k";
            System.IO.File.WriteAllText(filePath, DataList.ToString(), utf8WithoutBom);
            
            JObject result = Kmodel_tool.ReturnStandardValue(fileName);
            return result;
        }

        /// <summary>
        /// 获取Type39材料卡片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<JObject> GetType39CardInfo(GetType39CardDto input)
        {
            //卡片中所需信息
            string name;    //材料牌号
            string mid = "      1001"; //卡片编号
            string ro;      //密度t/mm^3
            string e;      //弹性模量
            string pr;       //泊松比
            string r;
            type39 Kmodel = new type39();
            type24_staticTension Kmodel_tool = new type24_staticTension();

            List<string> commonData = new List<string>();
            commonData = GetCommonCardData(input.materialId);
            name = commonData[0];
            ro = commonData[1];
            e = commonData[2];
            pr = commonData[3];

            //取静态拉伸真应力应变数据对
            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrial.MaterialId == input.materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .SelectMany(p => p.StaticTensionDataDetailStressStrains)
                .OrderBy(p => p.CreationTime)
                .ToList();

            List<string> stress = new List<string>();
            List<string> strain = new List<string>();
            foreach (var item in staticData)
            {
                if (strain.Contains(Convert.ToString(item.RealStrain)))
                {
                    continue;
                }
                else
                {
                    stress.Add(Convert.ToString(item.RealStress));
                    strain.Add(Convert.ToString(item.RealStrain));
                }
            }
            
            StringBuilder ssData = new StringBuilder();
            for (int i = 0; i != stress.Count; i++)
            {
                ssData.Append("          ");
                ssData.Append(Kmodel_tool.GetStandardData(strain[i]));
                ssData.Append("          ");
                ssData.Append(Kmodel_tool.GetStandardData(stress[i]));
                ssData.Append("\n");
            }

            //获取FLD中主次应变数据对
            var FLDData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.FLDDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == input.materialId)
                .SelectMany(n => n.FLDDataDetails)
                .SelectMany(p => p.FLDDataDetailItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();

            List<string> mainStrain = new List<string>();
            List<string> secendStrain = new List<string>();
            foreach (var item in FLDData)
            {
                secendStrain.Add(Convert.ToString(item.SecondaryStrain*10));
                mainStrain.Add(Convert.ToString(item.MainStrain * 10));
            }

            StringBuilder FLDdata = new StringBuilder();
            for (int i = 0; i != mainStrain.Count; i++)
            {
                FLDdata.Append("          ");
                FLDdata.Append(Kmodel_tool.GetStandardData(secendStrain[i]));
                FLDdata.Append("          ");
                FLDdata.Append(Kmodel_tool.GetStandardData(mainStrain[i]));
                FLDdata.Append("\n");
            }


            ro = Kmodel_tool.GetStandardData(ro);
            e = Kmodel_tool.GetStandardData(e);
            pr = Kmodel_tool.GetStandardData(pr);
            r = Kmodel_tool.GetStandardData(Convert.ToString(input.r));

            StringBuilder DataList = new StringBuilder();
            DataList = Kmodel.GetDataList(name, mid, ro, e, pr, r, ssData, FLDdata);

            Console.WriteLine(DataList);

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string fileName = name + "_" + "type39" + "_" + input.materialId.ToString() + ".k";
            string filePath = "../HanGang.MaterialSystem.HttpApi.Host/uploads/documents/" + name + "_" + "type39" + "_" + input.materialId.ToString() + ".k";
            System.IO.File.WriteAllText(filePath, DataList.ToString(), utf8WithoutBom);

            JObject result = Kmodel_tool.ReturnStandardValue(fileName);
            return result;
        }

        /// <summary>
        /// 获取Type81材料卡片
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public async Task<JObject> GetType81CardInfo(Guid materialId)
        {
            //卡片中所需信息
            string name;    //材料牌号
            string mid = "      1001"; //卡片编号
            string ro;      //密度t/mm^3
            string g;       //切变模量
            string e;      //弹性模量
            string pr;       //泊松比
            string eppfr = "0.4"; //断裂应变
            type81 Kmodel = new type81();
            type24_staticTension Kmodel_tool = new type24_staticTension();

            List<string> commonData = new List<string>();
            commonData = GetCommonCardData(materialId);
            name = commonData[0];
            ro = commonData[1];
            e = commonData[2];
            pr = commonData[3];

            //取静态拉伸真断后伸长率
            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .Where(n => n.MaterialTrial.MaterialId == materialId)
                .SelectMany(m => m.StaticTensionDataDetails)
                .OrderBy(p => p.CreationTime)
                .ToList();

            List<Decimal?> Elongations = new List<Decimal?>();
            foreach(var item in staticData)
            {
                Elongations.Add(item.Elongation);
            }
            eppfr = Convert.ToString(Elongations.Average());
            if(eppfr == "")
            {
                eppfr = Kmodel.eppfr;
            }

            //取静态拉伸真应力应变数据对
            var staticData2 = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .SelectMany(p => p.StaticTensionDataDetailStressStrains)
                .OrderBy(p => p.CreationTime)
                .ToList();

            List<string> stress = new List<string>();
            List<string> strain = new List<string>();
            foreach (var item in staticData2)
            {
                if (strain.Contains(Convert.ToString(item.RealStrain)))
                {
                    continue;
                }
                else
                {
                    stress.Add(Convert.ToString(item.RealStress));
                    strain.Add(Convert.ToString(item.RealStrain));
                }
            }

            StringBuilder ssData = new StringBuilder();
            for (int i = 0; i != stress.Count; i++)
            {
                ssData.Append("          ");
                ssData.Append(Kmodel_tool.GetStandardData(strain[i]));
                ssData.Append("          ");
                ssData.Append(Kmodel_tool.GetStandardData(stress[i]));
                ssData.Append("\n");
            }

            ro = Kmodel_tool.GetStandardData(ro);
            e = Kmodel_tool.GetStandardData(e);
            pr = Kmodel_tool.GetStandardData(pr);
            eppfr = Kmodel_tool.GetStandardData(eppfr);

            StringBuilder DataList = new StringBuilder();
            DataList = Kmodel.GetDataList(name, mid, ro, e, pr,eppfr,ssData);

            Console.WriteLine(DataList);

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string fileName = name + "_" + "type81" + "_" + materialId.ToString() + ".k";
            string filePath = "../HanGang.MaterialSystem.HttpApi.Host/uploads/documents/" + name + "_" + "type81" + "_" + materialId.ToString() + ".k";
            System.IO.File.WriteAllText(filePath, DataList.ToString(), utf8WithoutBom);

            JObject result = Kmodel_tool.ReturnStandardValue(fileName);
            return result;
        }

        /// <summary>
        /// 获取Type100材料卡片
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public async Task<JObject> GetType100CardInfo(Guid materialId)
        {
            //卡片中所需信息
            string name;    //材料牌号
            string mid = "      1001"; //卡片编号
            string ro;      //密度t/mm^3
            string e;      //弹性模量
            string pr;       //泊松比
            string sigy = "1000.0"; //断裂应变
            string eh = "100000.0"; //断裂应变
            string efail = "0.086"; //断裂应变
            type100 Kmodel = new type100();
            type24_staticTension Kmodel_tool = new type24_staticTension();

            List<string> commonData = new List<string>();
            commonData = GetCommonCardData(materialId);
            name = commonData[0];
            ro = commonData[1];
            e = commonData[2];
            pr = commonData[3];

            //取静态拉伸屈服强度
            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .Where(n => n.MaterialTrial.MaterialId == materialId)
                .SelectMany(m => m.StaticTensionDataDetails)
                .OrderBy(p => p.CreationTime)
                .ToList();

            List<Decimal?> YieldStrengths = new List<Decimal?>();
            foreach (var item in staticData)
            {
                YieldStrengths.Add(item.YieldStrength);
            }
            sigy = Convert.ToString(YieldStrengths.Average());
            if (sigy == "")
            {
                sigy = Kmodel.sigy;
            }

            //取静态拉伸真应力应变数据对
            var ssData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .SelectMany(p => p.StaticTensionDataDetailStressStrains)
                .OrderBy(p => p.CreationTime)
                .ToList();

            List<string> stress = new List<string>();
            List<string> strain = new List<string>();
            foreach (var item in ssData)
            {
                if (strain.Contains(Convert.ToString(item.RealStrain)))
                {
                    continue;
                }
                else
                {
                    stress.Add(Convert.ToString(item.RealStress));
                    strain.Add(Convert.ToString(item.RealStrain));
                }
            }

            try
            {
                double y1 = Convert.ToDouble(stress[0]);
                double y2 = Convert.ToDouble(stress[stress.Count]);
                double x1 = Convert.ToDouble(strain[0]);
                double x2 = Convert.ToDouble(strain[stress.Count]);
                eh = Convert.ToString((y2 - y1) / (x2 - x1));
            }
            catch
            {
                eh = "20000.0";
            }

            List<Decimal?> Elongations = new List<Decimal?>();
            foreach (var item in staticData)
            {
                Elongations.Add(item.Elongation);
            }
            efail = Convert.ToString(Elongations.Average()/100);
            if (efail == "")
            {
                efail = Kmodel.efail;
            }

            ro = Kmodel_tool.GetStandardData(ro);
            e = Kmodel_tool.GetStandardData(e);
            pr = Kmodel_tool.GetStandardData(pr);
            sigy = Kmodel_tool.GetStandardData(sigy);
            eh = Kmodel_tool.GetStandardData(eh);
            efail = Kmodel_tool.GetStandardData(efail);

            StringBuilder DataList = new StringBuilder();
            DataList = Kmodel.GetDataList(name, mid, ro, e, pr, sigy, eh,efail);

            Console.WriteLine(DataList);

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string fileName = name + "_" + "type100" + "_" + materialId.ToString() + ".k";
            string filePath = "../HanGang.MaterialSystem.HttpApi.Host/uploads/documents/" + name + "_" + "type100" + "_" + materialId.ToString() + ".k";
            System.IO.File.WriteAllText(filePath, DataList.ToString(), utf8WithoutBom);

            JObject result = Kmodel_tool.ReturnStandardValue(fileName);
            return result;
        }

        /// <summary>
        /// 获取弯曲数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<BendingDataDetailDto> GetBendingDataDetails(Guid materialId)
        {
            var bendingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.BendingDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.BendingDataDetails)
                .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<BendingDataDetail>, List<BendingDataDetailDto>>(bendingData);
        }

        /// <summary>
        /// 获取压缩数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<CompressDataDetailDto> GetCompressDataDetails(Guid materialId)
        {
            var compressData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.CompressDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.CompressDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<CompressDataDetail>, List<CompressDataDetailDto>>(compressData);
        }

        /// <summary>
        /// 获取高速拉伸数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighSpeedStrechDataDetailDto> GetHighSpeedStrechDataDetails(Guid materialId)
        {
            var highSpeedStrechData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HighSpeedStrechDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.HighSpeedStrechDataDetails)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<HighSpeedStrechDataDetail>, List<HighSpeedStrechDataDetailDto>>(highSpeedStrechData);
        }

        /// <summary>
        /// 导出高速拉伸材料卡片
        /// </summary>
        /// <param name="materialId"></param>
        public async Task<JObject> GetMaterialCardInfo(Guid materialId)
        {
            //卡片中所需信息
            string mid = "      1001"; //卡片编号
            string name;    //材料牌号
            string ro;      //密度t/mm^3
            string e;       //杨氏模量MPa
            string pr;      //泊松比
            string lcss = "      2001";       //应力应变曲线所对应的编号
            string[] values;//不同应变速率
            string[] lcid;  //某应变速率所对应的应力应变曲线编号
            type24_highSpeed_tension Kmodel = new type24_highSpeed_tension();
            type24_staticTension Kmodel_tool = new type24_staticTension();      //使用

            //材料表中取材料牌号
            var materialBaseData = _materialRepository
                .AsTracking()
                .Where(x => x.Id == materialId);
            name = materialBaseData.FirstOrDefault()?.Name; //FirstOrDefault()取值操作！

            //物理性能表中取密度
            var physicalPerformanceData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PhysicalPerformanceDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PhysicalPerformanceDataDetails);
            Double ro0 = Convert.ToDouble(physicalPerformanceData.FirstOrDefault()?.Density) * 0.000000001;    //表中数据为g/cm^3,转换成k文件所需的tone/mm^3
            ro = ro0 == 0 ? Kmodel.ro : Convert.ToString(ro0);

            //高速拉伸中取弹性模量和泊松比
            var highSpeedStrechData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HighSpeedStrechDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(p => p.HighSpeedStrechDataDetails);

            Double e0 = Convert.ToDouble(highSpeedStrechData.FirstOrDefault()?.YoungModulu);
            e = e0 == 0 ? Kmodel.e : Convert.ToString(e0);
            Double pr0 = Convert.ToDouble(highSpeedStrechData.FirstOrDefault()?.PoissonRatio);
            pr = pr0 == 0 ? Kmodel.pr : Convert.ToString(pr0);


            //高速拉伸真应力应变表中取不同速率
            var highSpeedStrechStreesStrainData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(y => y.HighSpeedStrechDataDetailStressStrainExtends)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(p => p.HighSpeedStrechDataDetailStressStrainExtends)
                .OrderBy(p => p.CreationTime)
                .ToList();
            values = new string[highSpeedStrechStreesStrainData.Count];
            for (int i = 0; i != values.Length; i++)
            {
                values[i] = highSpeedStrechStreesStrainData[i].RealPlasticTestTarget.Replace("/s","");       //获取所有速率   
            }
            HashSet<string> speedList = new HashSet<string>(values);        //去重复
            values = speedList.ToArray();


            lcid = new string[values.Length];
            for( int i =0; i!=values.Length; i++)
            {
                lcid[i] = Convert.ToString(3001 + i);
            }

            List<string> stress = new List<string>();
            List<string> strain = new List<string>();

            foreach (var item in highSpeedStrechStreesStrainData)
            {
                if (item.RealPlasticTestTarget == values[0])
                {
                    stress.Add(Convert.ToString(item.RealPlasticStressExtend));
                    strain.Add(Convert.ToString(item.RealPlasticStrainExtend));
                }
            }

            ro = Kmodel_tool.GetStandardData(ro);
            e = Kmodel_tool.GetStandardData(e);
            pr = Kmodel_tool.GetStandardData(pr);

            StringBuilder value_lcid = new StringBuilder();
            for (int i = 0; i !=  values.Length; i++)
            {
                value_lcid.Append("          ");
                value_lcid.Append(Kmodel_tool.GetStandardData(values[i]));
                value_lcid.Append("          ");
                value_lcid.Append(Kmodel_tool.GetStandardData(lcid[i]));
                value_lcid.Append("\n");
            }



            StringBuilder DataList = new StringBuilder();
            DataList.Append(Kmodel.content1_8);
            DataList.Append(name);
            DataList.Append(Kmodel.content10_17);
            DataList.Append(mid);
            DataList.Append(ro);
            DataList.Append(e);
            DataList.Append(pr);
            DataList.Append(Kmodel.content18_20);
            DataList.Append(lcss);
            DataList.Append(Kmodel.content20_31);
            DataList.Append(lcss);
            DataList.Append(Kmodel.content33);
            DataList.Append(value_lcid);
            DataList.Append(Kmodel.content42);
            DataList.Append(Convert.ToString(values.Length));
            DataList.Append(Kmodel.content42_L);


            
            for(int i = 0; i!= values.Length; i++)
            {
                DataList.Append(Kmodel.content43);
                DataList.Append(Convert.ToString(values[i]));
                DataList.Append(Kmodel.content43_44);
                DataList.Append(lcid[i]);
                DataList.Append(Kmodel.content44_46);
                DataList.Append(Convert.ToString(values[i]));
                DataList.Append(Kmodel.content47_48);
                DataList.Append(Kmodel_tool.GetStandardData(lcid[i]));
                DataList.Append(Kmodel.content49_50);

                StringBuilder ssData = new StringBuilder();
                foreach (var item in highSpeedStrechStreesStrainData)
                {
                    if (item.RealPlasticTestTarget.Replace("/s","") == values[i])
                    {
                        ssData.Append("          ");
                        ssData.Append(Kmodel_tool.GetStandardData(Convert.ToString(item.RealPlasticStrainExtend)));
                        ssData.Append("          ");
                        ssData.Append(Kmodel_tool.GetStandardData(Convert.ToString(item.RealPlasticStressExtend)));
                        ssData.Append("\n");
                    }
                }

                DataList.Append(ssData);
            }

            DataList.Append(Kmodel.end);

            //Console.WriteLine(DataList);

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string fileName = name + "_" + "type24_highSpeedTension" + "_" + materialId.ToString() + ".k";
            string filePath = "../HanGang.MaterialSystem.HttpApi.Host/uploads/documents/" + name + "_" + "type24_highSpeedTension" + "_" + materialId.ToString() + ".k";
            System.IO.File.WriteAllText(filePath, DataList.ToString(), utf8WithoutBom);

            JObject result = Kmodel_tool.ReturnStandardValue(fileName);
            return result;

        }

        /// <summary>
        /// 获取高速拉伸应力应变数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighSpeedStrechDataDetailStressStrainDto> GetHighSpeedStrechDataDetailStressStrains(Guid materialId)
        {
            var highSpeedStrechData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HighSpeedStrechDataDetails)
                .ThenInclude(y => y.HighSpeedStrechDataDetailStressStrains)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.HighSpeedStrechDataDetails)
                .SelectMany(p => p.HighSpeedStrechDataDetailStressStrains)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<HighSpeedStrechDataDetailStressStrain>, List<HighSpeedStrechDataDetailStressStrainDto>>(highSpeedStrechData);
        }
        /// <summary>
        /// 获取高速拉伸应力应变数据Extend
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighSpeedStrechDataDetailStressStrainExtendDto> GetHighSpeedStrechDataDetailStressStrainExtends(Guid materialId)
        {
            var highSpeedStrechData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(y => y.HighSpeedStrechDataDetailStressStrainExtends)
                .Where(m => m.MaterialTrial.MaterialId == materialId)

                .SelectMany(p => p.HighSpeedStrechDataDetailStressStrainExtends)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<HighSpeedStrechDataDetailStressStrainExtend>, List<HighSpeedStrechDataDetailStressStrainExtendDto>>(highSpeedStrechData);
        }

        /// <summary>
        /// 获取低周疲劳数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<LowCycleFatigueDataDetailDto> GetLowCycleFatigueDataDetails(Guid materialId)
        {
            var lowCycleFatigueData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.LowCycleFatigueDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.LowCycleFatigueDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<LowCycleFatigueDataDetail>, List<LowCycleFatigueDataDetailDto>>(lowCycleFatigueData);
        }
        /// <summary>
        /// 获取低周疲劳项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<LowCycleFatigueDataDetailItemDto> GetLowCycleFatigueDataDetailItems(Guid materialId)
        {
            var lowCycleFatigueData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.LowCycleFatigueDataDetails)
                .ThenInclude(y => y.LowCycleFatigueDataDetailItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.LowCycleFatigueDataDetails)
                .SelectMany(n => n.LowCycleFatigueDataDetailItems)
                .OrderBy(p => p.InsertOrder)
                .ProjectTo<LowCycleFatigueDataDetailItemDto>(Configuration)
                .ToList();
            return lowCycleFatigueData;
            // return ObjectMapper.Map<List<LowCycleFatigueDataDetailItem>, List<LowCycleFatigueDataDetailItemDto>>(lowCycleFatigueData);
        }
        
        /// <summary>
        /// 获取高周疲劳数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighCycleFatigueDataDetailDto> GetHighCycleFatigueDataDetails(Guid materialId)
        {
            var highCycleFatigueData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HighCycleFatigueDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.HighCycleFatigueDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ProjectTo<HighCycleFatigueDataDetailDto>(Configuration)
                .ToList();
            return highCycleFatigueData;
        }
        /// <summary>
        /// 获取高周疲劳项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighCycleFatigueDataDetailItemDto> GetHighCycleFatigueDataDetailItems(Guid materialId)
        {
            var highCycleFatigueData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HighCycleFatigueDataDetails)
                .ThenInclude(y => y.HighCycleFatigueDataDetailItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.HighCycleFatigueDataDetails)
                .SelectMany(p => p.HighCycleFatigueDataDetailItems)
                .OrderBy(p => p.InsertOrder)
                .ProjectTo<HighCycleFatigueDataDetailItemDto>(Configuration)
                .ToList();
            return highCycleFatigueData;
        }
        /// <summary>
        /// 获取金相数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<MetallographicDataDetailDto> GetMetallographicDataDetails(Guid materialId)
        {
            var metallographicData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.MetallographicDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.MetallographicDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<MetallographicDataDetail>, List<MetallographicDataDetailDto>>(metallographicData);
        }
        /// <summary>
        /// 获取物理性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PhysicalPerformanceDataDetailDto> GetPhysicalPerformanceDataDetails(Guid materialId)
        {
            var physicalPerformanceDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PhysicalPerformanceDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PhysicalPerformanceDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<PhysicalPerformanceDataDetail>, List<PhysicalPerformanceDataDetailDto>>(physicalPerformanceDataDetail);
        }
        /// <summary>
        /// 获取物理性能导热系数数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>

        public List<PhysicalPerformanceDataDetailThermalConductivityDto> GetPhysicalPerformanceDataDetailThermalConductivitys(Guid materialId)
        {
            var physicalPerformanceDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PhysicalPerformanceDataDetails)
                .ThenInclude(y => y.PhysicalPerformanceDataDetailThermalConductivities)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PhysicalPerformanceDataDetails)
                .SelectMany(p => p.PhysicalPerformanceDataDetailThermalConductivities)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<PhysicalPerformanceDataDetailThermalConductivity>, List<PhysicalPerformanceDataDetailThermalConductivityDto>>(physicalPerformanceDataDetail);
        }
        /// <summary>
        /// 获取物理性能热膨胀系数
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>

        public List<PhysicalPerformanceDataDetailThermalExpansionDto> GetPhysicalPerformanceDataDetailThermalExpansions(Guid materialId)
        {
            var physicalPerformanceDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PhysicalPerformanceDataDetails)
                .ThenInclude(y => y.PhysicalPerformanceDataDetailThermalExpansions)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PhysicalPerformanceDataDetails)
                .SelectMany(p => p.PhysicalPerformanceDataDetailThermalExpansions)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<PhysicalPerformanceDataDetailThermalExpansion>, List<PhysicalPerformanceDataDetailThermalExpansionDto>>(physicalPerformanceDataDetail);
        }
        /// <summary>
        /// 获取化学成分数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ChemicalElementDataDetailDto> GetChemicalElementDataDetails(Guid materialId)
        {
            var chemicalElementDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.ChemicalElementDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.ChemicalElementDataDetails)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<ChemicalElementDataDetail>, List<ChemicalElementDataDetailDto>>(chemicalElementDataDetail);
        }
        /// <summary>
        /// 获取禁用物质数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ProhibitedSubstanceDataDetailDto> GetProhibitedSubstanceDataDetails(Guid materialId)
        {
            var prohibitedSubstanceDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.ProhibitedSubstanceDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.ProhibitedSubstanceDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<ProhibitedSubstanceDataDetail>, List<ProhibitedSubstanceDataDetailDto>>(prohibitedSubstanceDataDetail);
        }
        /// <summary>
        /// 获取表面性能试验数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SurfacePropertyDataDetailDto> GetSurfacePropertyDataDetails(Guid materialId)
        {
            var surfacePropertyDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.SurfacePropertyDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.SurfacePropertyDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<SurfacePropertyDataDetail>, List<SurfacePropertyDataDetailDto>>(surfacePropertyDataDetail);
        }
        /// <summary>
        /// 获取表面性能镀层重量
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SurfacePropertyCoatingWeightDto> GetSurfacePropertyCoatingWeights(Guid materialId)
        {
            var surfacePropertyDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.SurfacePropertyDataDetails)
                .ThenInclude(y => y.SurfacePropertyCoatingWeights)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.SurfacePropertyDataDetails)
                .SelectMany(p => p.SurfacePropertyCoatingWeights)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<SurfacePropertyCoatingWeight>, List<SurfacePropertyCoatingWeightDto>>(surfacePropertyDataDetail);
        }
        /// <summary>
        /// 获取表面性能粗造度
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SurfacePropertyRoughnessDto> GetSurfacePropertyRoughnesss(Guid materialId)
        {
            var surfacePropertyDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.SurfacePropertyDataDetails)
                .ThenInclude(y => y.SurfacePropertyRoughnesses)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.SurfacePropertyDataDetails)
                .SelectMany(p => p.SurfacePropertyRoughnesses)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<SurfacePropertyRoughness>, List<SurfacePropertyRoughnessDto>>(surfacePropertyDataDetail);
        }
        /// <summary>
        /// 获取表面性能粗造度和峰值密度
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SurfacePropertyRoughnessAndPeakDensityDto> GetSurfacePropertyRoughnessAndPeakDensity(Guid materialId)
        {
            var surfacePropertyDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.SurfacePropertyDataDetails)
                .ThenInclude(y => y.SurfacePropertyRoughnessAndPeakDensitys)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.SurfacePropertyDataDetails)
                .SelectMany(p => p.SurfacePropertyRoughnessAndPeakDensitys)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<SurfacePropertyRoughnessAndPeakDensity>, List<SurfacePropertyRoughnessAndPeakDensityDto>>(surfacePropertyDataDetail);
        }
        /// <summary>
        /// 获取表面性能尺寸公差
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SurfacePropertySizeToleranceDto> GetSurfacePropertySizeTolerance(Guid materialId)
        {
            var surfacePropertyDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.SurfacePropertyDataDetails)
                .ThenInclude(y => y.SurfacePropertySizeTolerances)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.SurfacePropertyDataDetails)
                .SelectMany(p => p.SurfacePropertySizeTolerances)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<SurfacePropertySizeTolerance>, List<SurfacePropertySizeToleranceDto>>(surfacePropertyDataDetail);
        }
        /// <summary>
        /// 寻找抗凹性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<DentResistanceDataDetailDto> GetDentResistanceDataDetails(Guid materialId)
        {
            var dentResistanceDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.DentResistanceDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.DentResistanceDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<DentResistanceDataDetail>, List<DentResistanceDataDetailDto>>(dentResistanceDataDetail);
        }

        /// <summary>
        /// 寻找烘烤硬化数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<BakeHardeningDataDetailDto> GetBakeHardeningDataDetails(Guid materialId)
        {
            var bakeHardeningDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.BakeHardeningDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.BakeHardeningDataDetails)
                .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<BakeHardeningDataDetail>, List<BakeHardeningDataDetailDto>>(bakeHardeningDataDetail);
        }
        /// <summary>
        /// 寻找烘烤硬化项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<BakeHardeningDataDetailItemDto> GetBakeHardeningDataDetailItems(Guid materialId)
        {
            var bakeHardeningDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.BakeHardeningDataDetails)
                .ThenInclude(y => y.BakeHardeningDataDetailItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.BakeHardeningDataDetails)
                .SelectMany(p => p.BakeHardeningDataDetailItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<BakeHardeningDataDetailItem>, List<BakeHardeningDataDetailItemDto>>(bakeHardeningDataDetail);
        }
        /// <summary>
        /// 寻找回弹性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ReboundDataDetailDto> GetReboundDataDetails(Guid materialId)
        {
            var reboundData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.ReboundDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.ReboundDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<ReboundDataDetail>, List<ReboundDataDetailDto>>(reboundData);

        }
        /// <summary>
        /// 寻找回弹性能项目1数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ReboundDataDetailItemDto> GetReboundDataDetailItems(Guid materialId)
        {
            var reboundData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.ReboundDataDetails)
                .ThenInclude(y => y.ReboundDataDetailItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.ReboundDataDetails)
                .SelectMany(p => p.ReboundDataDetailItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<ReboundDataDetailItem>, List<ReboundDataDetailItemDto>>(reboundData);

        }
        /// <summary>
        /// 寻找回弹性能项目2数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ReboundDataDetailItem2Dto> GetReboundDataDetailItems2(Guid materialId)
        {
            var reboundData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.ReboundDataDetails)
                .ThenInclude(y => y.ReboundDataDetailItems2)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.ReboundDataDetails)
                .SelectMany(p => p.ReboundDataDetailItems2)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<ReboundDataDetailItem2>, List<ReboundDataDetailItem2Dto>>(reboundData);

        }
        /// <summary>
        /// 寻找回弹性能项目3数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ReboundDataDetailItem3Dto> GetReboundDataDetailItems3(Guid materialId)
        {
            var reboundData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.ReboundDataDetails)
                .ThenInclude(y => y.ReboundDataDetailItems3)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.ReboundDataDetails)
                .SelectMany(p => p.ReboundDataDetailItems3)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<ReboundDataDetailItem3>, List<ReboundDataDetailItem3Dto>>(reboundData);

        }
        /// <summary>
        /// 寻找成形极限数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<FLDDataDetailDto> GetFLDDataDetails(Guid materialId)
        {
            var fLDData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.FLDDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.FLDDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<FLDDataDetail>, List<FLDDataDetailDto>>(fLDData);

        }
        /// <summary>
        /// 寻找成形极限项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<FLDDataDetailItemDto> GetFLDDataDetailItems(Guid materialId)
        {
            var fLDData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.FLDDataDetails)
                .ThenInclude(y => y.FLDDataDetailItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.FLDDataDetails)
                .SelectMany(p => p.FLDDataDetailItems)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<FLDDataDetailItem>, List<FLDDataDetailItemDto>>(fLDData);

        }
        #region 涂装性能
        /// <summary>
        /// 寻找涂装性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailDto> GetPaintingDataDetails(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetail>, List<PaintingDataDetailDto>>(paintingData);

        }
        /// <summary>
        /// 寻找涂装性能附着力数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailAdhesionItemDto> GetPaintingDataDetailAdhesionItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailAdhesionItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailAdhesionItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailAdhesionItem>, List<PaintingDataDetailAdhesionItemDto>>(paintingData);
        }
        /// <summary>
        /// 寻找涂装性能-耐湿热性能试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailDampHeatItemDto> GetPaintingDataDetailDampHeatItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailDampHeatItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailDampHeatItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailDampHeatItem>, List<PaintingDataDetailDampHeatItemDto>>(paintingData);
        }
        /// <summary>
        /// 寻找涂装性能-电泳漆膜厚度试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailElectrophoreticItemDto> GetPaintingDataDetailElectrophoreticItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailElectrophoreticItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailElectrophoreticItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailElectrophoreticItem>, List<PaintingDataDetailElectrophoreticItemDto>>(paintingData);
        }
        /// <summary>
        /// 寻找涂装性能-电泳漆膜硬度试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailHardnessItemDto> GetPaintingDataDetailHardnessItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailHardnessItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailHardnessItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailHardnessItem>, List<PaintingDataDetailHardnessItemDto>>(paintingData);
        }
        /// <summary>
        /// 寻找涂装性能-抗石击性能试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailHitResistanceItemDto> GetPaintingDataDetailHitResistanceItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailHitResistanceItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailHitResistanceItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailHitResistanceItem>, List<PaintingDataDetailHitResistanceItemDto>>(paintingData);
        }
        /// <summary>
        /// 寻找涂装性能-膜重试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailMembraneWeightItemDto> GetPaintingDataDetailMembraneWeightItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailMembraneWeightItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailMembraneWeightItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailMembraneWeightItem>, List<PaintingDataDetailMembraneWeightItemDto>>(paintingData);
        }
        /// <summary>
        /// 寻找涂装性能-磷化膜试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailPhosphatingItemDto> GetPaintingDataDetailPhosphatingItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailPhosphatingItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailPhosphatingItems)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailPhosphatingItem>, List<PaintingDataDetailPhosphatingItemDto>>(paintingData);
        }
        /// <summary>
        /// 寻找涂装性能-P比试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailPRatioItemDto> GetPaintingDataDetailPRatioItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailPRatioItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailPRatioItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailPRatioItem>, List<PaintingDataDetailPRatioItemDto>>(paintingData);
        }
        /// <summary>
        /// 寻找涂装性能-电泳漆膜粗糙度试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailRoughnessItemDto> GetPaintingDataDetailRoughnessItems(Guid materialId)
        {
            var paintingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.PaintingDataDetails)
                .ThenInclude(y => y.PaintingDataDetailRoughnessItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.PaintingDataDetails)
                .SelectMany(p => p.PaintingDataDetailRoughnessItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<PaintingDataDetailRoughnessItem>, List<PaintingDataDetailRoughnessItemDto>>(paintingData);
        }
        #endregion
        /// <summary>
        /// 寻找胶接性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<CementingDataDetailDto> GetCementingDataDetails(Guid materialId)
        {
            var cementingData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.CementingDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.CementingDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<CementingDataDetail>, List<CementingDataDetailDto>>(cementingData);
        }
        /// <summary>
        /// 寻找焊接性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<WeldingDataDetailDto> GetWeldingDataDetails(Guid materialId)
        {
            var weldingDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.WeldingDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.WeldingDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<WeldingDataDetail>, List<WeldingDataDetailDto>>(weldingDataDetail);
        }
        /// <summary>
        /// 寻找焊接性能项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<WeldingDataDetailItemDto> GetWeldingDataDetailItems(Guid materialId)
        {
            var weldingDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.WeldingDataDetails)
                .ThenInclude(y => y.WeldingDataDetailItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.WeldingDataDetails)
                .SelectMany(p => p.WeldingDataDetailItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<WeldingDataDetailItem>, List<WeldingDataDetailItemDto>>(weldingDataDetail);
        }
        /// <summary>
        /// 寻找氢致延迟开裂数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HydrogenInducedDelayedFractureDataDetailDto> GetHydrogenInducedDelayedFractureDataDetails(Guid materialId)
        {
            var hydrogenInducedDelayedFractureDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HydrogenInducedDelayedFractureDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.HydrogenInducedDelayedFractureDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<HydrogenInducedDelayedFractureDataDetail>, List<HydrogenInducedDelayedFractureDataDetailDto>>(hydrogenInducedDelayedFractureDataDetail);
        }
        /// <summary>
        /// 寻找氢致延迟开裂数据项目
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HydrogenInducedDelayedFractureDataDetailItemDto> GetHydrogenInducedDelayedFractureDataDetailItems(Guid materialId)
        {
            var hydrogenInducedDelayedFractureDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.HydrogenInducedDelayedFractureDataDetails)
                .ThenInclude(y => y.HydrogenInducedDelayedFractureDataDetailItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.HydrogenInducedDelayedFractureDataDetails)
                .SelectMany(p => p.HydrogenInducedDelayedFractureDataDetailItems)
                .OrderBy(p => p.InsertOrder)
                .ToList();
            return ObjectMapper.Map<List<HydrogenInducedDelayedFractureDataDetailItem>, List<HydrogenInducedDelayedFractureDataDetailItemDto>>(hydrogenInducedDelayedFractureDataDetail);
        }
        /// <summary>
        /// 寻找翻边扣合数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<FlangingClaspDataDetailDto> GetFlangingClaspDataDetails(Guid materialId)
        {
            var flangingClaspDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.FlangingClaspDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.FlangingClaspDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<FlangingClaspDataDetail>, List<FlangingClaspDataDetailDto>>(flangingClaspDataDetail);
        }
        /// <summary>
        /// 寻找二次加工数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SecondaryWorkingEmbrittlementDataDetailDto> GetSecondaryWorkingEmbrittlementDataDetails(Guid materialId)
        {
            var secondaryWorkingEmbrittlementDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.SecondaryWorkingEmbrittlementDataDetails)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.SecondaryWorkingEmbrittlementDataDetails)
                  .OrderBy(p => p.CreationTime)
                .ToList();
            return ObjectMapper.Map<List<SecondaryWorkingEmbrittlementDataDetail>, List<SecondaryWorkingEmbrittlementDataDetailDto>>(secondaryWorkingEmbrittlementDataDetail);
        }
        /// <summary>
        /// 寻找二次加工项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SecondaryWorkingEmbrittlementDataDetailItemDto> GetSecondaryWorkingEmbrittlementDataDetailItems(Guid materialId)
        {
            var secondaryWorkingEmbrittlementDataDetail = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.SecondaryWorkingEmbrittlementDataDetails)
                .ThenInclude(x => x.SecondaryWorkingEmbrittlementDataDetailItems)
                .Where(m => m.MaterialTrial.MaterialId == materialId)
                .SelectMany(n => n.SecondaryWorkingEmbrittlementDataDetails)
                .SelectMany(p => p.SecondaryWorkingEmbrittlementDataDetailItems)
                .OrderBy(p => p.InsertOrder)
                .ProjectTo<SecondaryWorkingEmbrittlementDataDetailItemDto>(Configuration)
                .ToList();
            return secondaryWorkingEmbrittlementDataDetail;
        }
        #endregion
    }
}