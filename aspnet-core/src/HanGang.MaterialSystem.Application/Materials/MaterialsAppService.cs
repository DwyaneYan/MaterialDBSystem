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
using Spire.Xls;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Collections.Generic;
using HanGang.MaterialSystem.MaterialTrials.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Spire.Xls.Collections;
using HanGang.MaterialSystem.TypicalParts.Dtos;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.ComponentModel;

namespace HanGang.MaterialSystem.Trials
{
    /// <summary>
    /// 材料服务
    /// </summary>
    public class MaterialAppService : MaterialSystemAppService, IMaterialAppService
    {
        #region  
        private readonly IWebHostEnvironment _webHostEnviornment;
        private readonly IRepository<Manufactory> _manufactoryRepository;
        private readonly IRepository<TypicalPart> _typicalPartRepository;
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<ApplicationCase> _applicationCaseRepository;
        private readonly IRepository<MaterialRecommendation> _materialRecommendationRepository;
        private readonly IRepository<MaterialTrial> _materialTrialRepository;
        private readonly IRepository<MaterialTrialData> _materialTrialDataRepository;
        private readonly IRepository<StaticTensionDataDetail> _staticTensionDataDetailRepository;
        private readonly IRepository<StaticTensionDataDetailRequirement> _staticTensionDataDetailRequirementRepository;
        private readonly IRepository<StaticTensionDataDetailStressStrain> _staticTensionDataDetailStressStrainRepository;
        private readonly IRepository<Trial> _trialRepository;
        private readonly IRepository<LowCycleFatigueDataDetail> _lowCycleFatigueDataDetailRepository;
        private readonly IRepository<LowCycleFatigueDataDetailItem> _lowCycleFatigueDataDetailItemRepository;
        private readonly IRepository<PhysicalPerformanceDataDetail> _physicalPerformanceDataDetailRepository;
        private readonly IRepository<PhysicalPerformanceDataDetailThermalConductivity> _physicalPerformanceDataDetailThermalConductivityRepository;
        private readonly IRepository<PhysicalPerformanceDataDetailThermalExpansion> _physicalPerformanceDataDetailThermalExpansionRepository;
        private readonly IRepository<ReboundDataDetail> _reboundDataDetailRepository;
        private readonly IRepository<ReboundDataDetailItem> _reboundDataDetailItemRepository;
        private readonly IRepository<ReboundDataDetailItem2> _reboundDataDetailItem2Repository;
        private readonly IRepository<ReboundDataDetailItem3> _reboundDataDetailItem3Repository;
        private readonly IRepository<HighCycleFatigueDataDetail> _highCycleFatigueDataDetailRepository;
        private readonly IRepository<HighCycleFatigueDataDetailItem> _highCycleFatigueDataDetailItemRepository;
        private readonly IRepository<WeldingDataDetail> _weldingDataDetailRepository;
        private readonly IRepository<WeldingDataDetailItem> _weldingDataDetailItemRepository;
        private readonly IRepository<HydrogenInducedDelayedFractureDataDetail> _hydrogenInducedDelayedFractureDataDetailRepository;
        private readonly IRepository<HydrogenInducedDelayedFractureDataDetailItem> _hydrogenInducedDelayedFractureDataDetailItemRepository;
        private readonly IRepository<HighSpeedStrechDataDetail> _highSpeedStrechDataDetailRepository;
        private readonly IRepository<HighSpeedStrechDataDetailStressStrain> _highSpeedStrechDataDetailStressStrainRepository;
        private readonly IRepository<HighSpeedStrechDataDetailStressStrainExtend> _highSpeedStrechDataDetailStressStrainExtendRepository;
        private readonly IRepository<ProhibitedSubstanceDataDetail> _prohibitedSubstanceDataDetailRepository;
        private readonly IRepository<ChemicalElementDataDetail> _chemicalElementDataDetailRepository;
        private readonly IRepository<SurfacePropertyDataDetail> _surfacePropertyDataDetailRepository;
        private readonly IRepository<SurfacePropertyRoughness> _surfacePropertyRoughnessRepository;
        private readonly IRepository<SurfacePropertyCoatingWeight> _surfacePropertyCoatingWeightRepository;
        private readonly IRepository<SurfacePropertyRoughnessAndPeakDensity> _surfacePropertyRoughnessAndPeakDensityRepository;
        private readonly IRepository<SurfacePropertySizeTolerance> _surfacePropertySizeToleranceRepository;
        private readonly IRepository<BakeHardeningDataDetail> _bakeHardeningDataDetailRepository;
        private readonly IRepository<BakeHardeningDataDetailItem> _bakeHardeningDataDetailItemRepository;
        private readonly IRepository<BendingDataDetail> _bendingDataDetailRepository;
        private readonly IRepository<CompressDataDetail> _compressDataDetailRepository;
        private readonly IRepository<FlangingClaspDataDetail> _flangingClaspDataDetailRepository;
        private readonly IRepository<FLDDataDetail> _fLDDataDetailRepository;
        private readonly IRepository<FLDDataDetailItem> _fLDDataDetailItemRepository;
        private readonly IRepository<SecondaryWorkingEmbrittlementDataDetail> _secondaryWorkingEmbrittlementDataDetailRepository;
        private readonly IRepository<SecondaryWorkingEmbrittlementDataDetailItem> _secondaryWorkingEmbrittlementDataDetailItemRepository;
        private readonly IRepository<CementingDataDetail> _cementingDataDetailRepository;
        private readonly IRepository<MetallographicDataDetail> _metallographicDataDetailRepository;
        private readonly IRepository<DentResistanceDataDetail> _dentResistanceDataDetailRepository;
        private readonly IRepository<PaintingDataDetail> _paintingDataDetailRepository;
        private readonly IRepository<PaintingDataDetailPhosphatingItem> _paintingDataDetailPhosphatingItemRepository;
        private readonly IRepository<PaintingDataDetailMembraneWeightItem> _paintingDataDetailMembraneWeightItemRepository;
        private readonly IRepository<PaintingDataDetailPRatioItem> _paintingDataDetailPRatioItemRepository;
        private readonly IRepository<PaintingDataDetailElectrophoreticItem> _paintingDataDetailElectrophoreticItemRepository;
        private readonly IRepository<PaintingDataDetailHardnessItem> _paintingDataDetailHardnessItemRepository;
        private readonly IRepository<PaintingDataDetailRoughnessItem> _paintingDataDetailRoughnessItemRepository;
        private readonly IRepository<PaintingDataDetailHitResistanceItem> _paintingDataDetailHitResistanceItemRepository;
        private readonly IRepository<PaintingDataDetailAdhesionItem> _paintingDataDetailAdhesionItemRepository;
        private readonly IRepository<PaintingDataDetailDampHeatItem> _paintingDataDetailDampHeatItemRepository;
        public MaterialAppService(
            IWebHostEnvironment webHostEnviornment,
            IRepository<TypicalPart> typicalPartRepository,
            IRepository<Manufactory> manufactoryRepository,
            IRepository<Material> materialRepository,
            IRepository<ApplicationCase> applicationCaseRepository,
            IRepository<MaterialRecommendation> materialRecommendationRepository,
            IRepository<MaterialTrial> materialTrialRepository,
            IRepository<MaterialTrialData> materialTrialDataRepository,
            IRepository<StaticTensionDataDetail> staticTensionDataDetailRepository,
            IRepository<StaticTensionDataDetailRequirement> staticTensionDataDetailRequirementRepository,
            IRepository<StaticTensionDataDetailStressStrain> staticTensionDataDetailStressStrainRepository,
            IRepository<Trial> trialRepository,
            IRepository<LowCycleFatigueDataDetail> lowCycleFatigueDataDetailRepository,
            IRepository<LowCycleFatigueDataDetailItem> lowCycleFatigueDataDetailItemRepository,
            IRepository<PhysicalPerformanceDataDetail> physicalPerformanceDataDetailRepository,
            IRepository<PhysicalPerformanceDataDetailThermalConductivity> physicalPerformanceDataDetailThermalConductivityRepository,
            IRepository<PhysicalPerformanceDataDetailThermalExpansion> physicalPerformanceDataDetailThermalExpansionRepository,
            IRepository<ReboundDataDetail> reboundDataDetailRepository,
            IRepository<ReboundDataDetailItem> reboundDataDetailItemRepository,
            IRepository<ReboundDataDetailItem2> reboundDataDetailItem2Repository,
            IRepository<ReboundDataDetailItem3> reboundDataDetailItem3Repository,
            IRepository<HighCycleFatigueDataDetail> highCycleFatigueDataDetailRepository,
            IRepository<HighCycleFatigueDataDetailItem> highCycleFatigueDataDetailItemRepository,
            IRepository<WeldingDataDetail> weldingDataDetailRepository,
            IRepository<WeldingDataDetailItem> weldingDataDetailItemRepository,
            IRepository<HydrogenInducedDelayedFractureDataDetail> hydrogenInducedDelayedFractureDataDetailRepository,
            IRepository<HydrogenInducedDelayedFractureDataDetailItem> hydrogenInducedDelayedFractureDataDetailItemRepository,              
            IRepository<HighSpeedStrechDataDetail> highSpeedStrechDataDetailRepository,
            IRepository<HighSpeedStrechDataDetailStressStrain> highSpeedStrechDataDetailStressStrainRepository,
            IRepository<HighSpeedStrechDataDetailStressStrainExtend> highSpeedStrechDataDetailStressStrainExtendRepository,
            IRepository<ProhibitedSubstanceDataDetail> prohibitedSubstanceDataDetailRepository,
            IRepository<ChemicalElementDataDetail> chemicalElementDataDetailRepository,
            IRepository<SurfacePropertyDataDetail> surfacePropertyDataDetailRepository,
            IRepository<SurfacePropertyRoughness> surfacePropertyRoughnessRepository,
            IRepository<SurfacePropertyCoatingWeight> surfacePropertyCoatingWeightRepository,
            IRepository<SurfacePropertyRoughnessAndPeakDensity> surfacePropertyRoughnessAndPeakDensityRepository,
            IRepository<SurfacePropertySizeTolerance> surfacePropertySizeToleranceRepository,
            IRepository<BakeHardeningDataDetail> bakeHardeningDataDetailRepository,
            IRepository<BakeHardeningDataDetailItem> bakeHardeningDataDetailItemRepository,
            IRepository<BendingDataDetail> bendingDataDetailRepository,
            IRepository<CompressDataDetail> compressDataDetailRepository,
            IRepository<FlangingClaspDataDetail> flangingClaspDataDetailRepository,
            IRepository<FLDDataDetail> fLDDataDetailRepository,
            IRepository<FLDDataDetailItem> fLDDataDetailItemRepository,
            IRepository<SecondaryWorkingEmbrittlementDataDetail> secondaryWorkingEmbrittlementDataDetailRepository,
            IRepository<SecondaryWorkingEmbrittlementDataDetailItem> secondaryWorkingEmbrittlementDataDetailItemRepository,
            IRepository<CementingDataDetail> cementingDataDetailRepository,
            IRepository<MetallographicDataDetail> metallographicDataDetailRepository,
            IRepository<DentResistanceDataDetail> dentResistanceDataDetailRepository,
            IRepository<PaintingDataDetail> paintingDataDetailRepository,
            IRepository<PaintingDataDetailPhosphatingItem> paintingDataDetailPhosphatingItemRepository,
            IRepository<PaintingDataDetailMembraneWeightItem> paintingDataDetailMembraneWeightItemRepository,
            IRepository<PaintingDataDetailPRatioItem> paintingDataDetailPRatioItemRepository,
            IRepository<PaintingDataDetailElectrophoreticItem> paintingDataDetailElectrophoreticItemRepository,
            IRepository<PaintingDataDetailHardnessItem> paintingDataDetailHardnessItemRepository,
            IRepository<PaintingDataDetailRoughnessItem> paintingDataDetailRoughnessItemRepository,
            IRepository<PaintingDataDetailHitResistanceItem> paintingDataDetailHitResistanceItemRepository,
            IRepository<PaintingDataDetailAdhesionItem> paintingDataDetailAdhesionItemRepository,
            IRepository<PaintingDataDetailDampHeatItem> paintingDataDetailDampHeatItemRepository
        #endregion
            )
        {
            _webHostEnviornment = webHostEnviornment;
            _manufactoryRepository = manufactoryRepository;
            _typicalPartRepository = typicalPartRepository;
            _materialRepository = materialRepository;
            _applicationCaseRepository = applicationCaseRepository;
            _materialRecommendationRepository = materialRecommendationRepository;
            _materialTrialRepository = materialTrialRepository;
            _materialTrialDataRepository = materialTrialDataRepository;
            _staticTensionDataDetailRepository = staticTensionDataDetailRepository;
            _staticTensionDataDetailRequirementRepository = staticTensionDataDetailRequirementRepository;
            _staticTensionDataDetailStressStrainRepository = staticTensionDataDetailStressStrainRepository;
            _trialRepository = trialRepository;
            _lowCycleFatigueDataDetailRepository = lowCycleFatigueDataDetailRepository;
            _lowCycleFatigueDataDetailItemRepository = lowCycleFatigueDataDetailItemRepository;
            _physicalPerformanceDataDetailRepository = physicalPerformanceDataDetailRepository;
            _physicalPerformanceDataDetailThermalConductivityRepository = physicalPerformanceDataDetailThermalConductivityRepository;
            _physicalPerformanceDataDetailThermalExpansionRepository = physicalPerformanceDataDetailThermalExpansionRepository;
            _reboundDataDetailRepository = reboundDataDetailRepository;
            _reboundDataDetailItemRepository = reboundDataDetailItemRepository;
            _reboundDataDetailItem2Repository = reboundDataDetailItem2Repository;
            _reboundDataDetailItem3Repository = reboundDataDetailItem3Repository;
            _highCycleFatigueDataDetailRepository = highCycleFatigueDataDetailRepository;
            _highCycleFatigueDataDetailItemRepository = highCycleFatigueDataDetailItemRepository;
            _weldingDataDetailRepository = weldingDataDetailRepository;
            _weldingDataDetailItemRepository = weldingDataDetailItemRepository;
            _hydrogenInducedDelayedFractureDataDetailRepository = hydrogenInducedDelayedFractureDataDetailRepository;
            _hydrogenInducedDelayedFractureDataDetailItemRepository = hydrogenInducedDelayedFractureDataDetailItemRepository;
            _highSpeedStrechDataDetailRepository = highSpeedStrechDataDetailRepository;
            _highSpeedStrechDataDetailStressStrainRepository = highSpeedStrechDataDetailStressStrainRepository;
            _highSpeedStrechDataDetailStressStrainExtendRepository = highSpeedStrechDataDetailStressStrainExtendRepository;
            _prohibitedSubstanceDataDetailRepository = prohibitedSubstanceDataDetailRepository;
            _chemicalElementDataDetailRepository = chemicalElementDataDetailRepository;
            _surfacePropertyDataDetailRepository = surfacePropertyDataDetailRepository;
            _surfacePropertyRoughnessRepository = surfacePropertyRoughnessRepository;
            _surfacePropertyCoatingWeightRepository = surfacePropertyCoatingWeightRepository;
            _surfacePropertyRoughnessAndPeakDensityRepository = surfacePropertyRoughnessAndPeakDensityRepository;
            _surfacePropertySizeToleranceRepository = surfacePropertySizeToleranceRepository;
            _bakeHardeningDataDetailRepository = bakeHardeningDataDetailRepository;
            _bakeHardeningDataDetailItemRepository = bakeHardeningDataDetailItemRepository;
            _bendingDataDetailRepository = bendingDataDetailRepository;
            _compressDataDetailRepository = compressDataDetailRepository;
            _flangingClaspDataDetailRepository = flangingClaspDataDetailRepository;
            _fLDDataDetailRepository = fLDDataDetailRepository;
            _fLDDataDetailItemRepository = fLDDataDetailItemRepository;
            _secondaryWorkingEmbrittlementDataDetailRepository = secondaryWorkingEmbrittlementDataDetailRepository;
            _secondaryWorkingEmbrittlementDataDetailItemRepository = secondaryWorkingEmbrittlementDataDetailItemRepository;
            _cementingDataDetailRepository = cementingDataDetailRepository;
            _metallographicDataDetailRepository = metallographicDataDetailRepository;
            _dentResistanceDataDetailRepository = dentResistanceDataDetailRepository;
            _paintingDataDetailRepository = paintingDataDetailRepository;
            _paintingDataDetailPhosphatingItemRepository = paintingDataDetailPhosphatingItemRepository;
            _paintingDataDetailMembraneWeightItemRepository = paintingDataDetailMembraneWeightItemRepository;
            _paintingDataDetailPRatioItemRepository = paintingDataDetailPRatioItemRepository;
            _paintingDataDetailElectrophoreticItemRepository = paintingDataDetailElectrophoreticItemRepository;
            _paintingDataDetailHardnessItemRepository = paintingDataDetailHardnessItemRepository;
            _paintingDataDetailRoughnessItemRepository = paintingDataDetailRoughnessItemRepository;
            _paintingDataDetailHitResistanceItemRepository = paintingDataDetailHitResistanceItemRepository;
            _paintingDataDetailAdhesionItemRepository = paintingDataDetailAdhesionItemRepository;
            _paintingDataDetailDampHeatItemRepository = paintingDataDetailDampHeatItemRepository;

        }

        /// <summary>
        /// vim平台跳到邯钢典型零件页面所需判断
        /// </summary>
        /// <param name="carTypeAndPart"></param>
        public async Task<JObject> VIMtoHangangOperation(VIMtoHangangDto carTypeAndPart)
        {
            var typicalPartsData = _typicalPartRepository
                .AsNoTracking()
                .Where(m => m.ProjectId == carTypeAndPart.projectId
                            && m.directoryId == carTypeAndPart.directoryId)
                .Select(n => n.MaterialId)
                .FirstOrDefault()
                .ToString();

            if (typicalPartsData != null)
            {
                string jsonText = "{materialId:\"" + typicalPartsData + "\"}";
                JObject jo = JObject.Parse(jsonText);
                return jo;
            }
            else
            {
                string jsonText = "{materialId: null}";
                JObject jo = JObject.Parse(jsonText);
                return jo;
            }

        }

        /// <summary>
        /// 邯钢典型零件页面跳到vim平台所需判断
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public async Task<JObject> HanGangToVIMOperation(Guid materialId)
        {
            var typicalPartsData = _typicalPartRepository
                .AsNoTracking()
                .Where(m => m.MaterialId == materialId)
                .FirstOrDefault();

            if (typicalPartsData != null)
            {
                string projectId = typicalPartsData.ProjectId;
                string partName = typicalPartsData.Name;
                string directoryId = typicalPartsData.directoryId;

                string jsonText = "{ProjectId:\"" + projectId + "\",directoryId:\"" + directoryId + "\", Name:\"" + partName + "\" }";
                JObject jo = JObject.Parse(jsonText);
                return jo;
            }
            else
            {
                string jsonText = "{ProjectId: null,directoryId: null}";
                JObject jo = JObject.Parse(jsonText);
                return jo;
            }
        }

        /// <summary>
        /// 获取所有典型零件
        /// </summary>
        /// <returns></returns>
        public List<TypicalPartDto> GetAllTypicalPart()
        {
            return _typicalPartRepository
                .AsNoTracking()
                .ProjectTo<TypicalPartDto>(Configuration)
                .ToList();
        }


        /// <summary>
        /// 绑定材料和零件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<JObject> UpdatePartsMaterialId(BindPartAndMaterialDto input)
        {
            var theDataId = _typicalPartRepository
                .AsNoTracking()
                .Where(m => m.directoryId == input.directoryId)
                .Select(n=>n.Id)
                .FirstOrDefault();

            var typicalPart = await _typicalPartRepository.GetAsync(theDataId);
            Guid matId = new Guid(input.materialId);
            typicalPart.MaterialId = matId;


            return JObject.Parse("{Code: 200}");
        }


        /// <summary>
        /// 数据过滤演示
        /// </summary>
        /// <param name="id"></param>
        public void GetAllDataExample(Guid id)
        {
            //寻找静态拉伸数据明细
            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrial.Trial.TrialType == TrialType.静态拉伸
                            && m.MaterialTrial.Material.Id == id
                            && m.MaterialTrial.Material.Strength < 500
                            && m.MaterialTrial.Material.Strength > 200)
                .SelectMany(n => n.StaticTensionDataDetails)
                .ToList();

            //直接取静态拉伸试验数据
            var staticData1 = _staticTensionDataDetailRepository
                .AsNoTracking()
                .Include(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrialData.MaterialTrial.Material.Name == "DC01")
                .ToList();
        }

        /// <summary>
        /// 获取所有材料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<MaterialDto>> GetMaterials(GetMaterialListInputDto input)
        {
            return _materialRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name))  //按材料名称筛选
                .WhereIf(input.MaterialType.HasValue, x => x.MaterialType == input.MaterialType)   //增加按材料类型筛选
                .WhereIf(input.ReelNumber.HasValue, x => x.ReelNumber == input.ReelNumber) //卷号筛选
                .WhereIf(input.Model.HasValue, x => x.Model == input.Model)   //增加按型号规格型筛选
                .WhereIf(input.MinModel.HasValue, m => m.Model >= input.MinModel)//按最小型号规格筛选
                .WhereIf(input.MaxModel.HasValue, m => m.Model <= input.MaxModel)//按最大型号规格筛选
                .WhereIf(input.Strength.HasValue, x => x.Strength == input.Strength)  //按屈服强度筛选
                .WhereIf(input.MinStrenth.HasValue, m => m.Strength >= input.MinStrenth)//按最小材料强度筛选
                .WhereIf(input.MaxStrenth.HasValue, m => m.Strength <= input.MaxStrenth)//按最大材料强度筛选
                .WhereIf(input.ManufactoryId.HasValue, x => x.ManufactoryId == input.ManufactoryId)  //按厂家Id度筛选
                .WhereIf(input.Id.HasValue, x => x.Id == input.Id)  //按厂家Id度筛选                                                                    
                .OrderByDescending(p => p.CreationTime)//.OrderBy(input.Sorting)
                .ProjectTo<MaterialDto>(Configuration)
                .ToPageResultAsync(input);
        }

        /// <summary>
        /// 添加材料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>between types 'System.String' and 'System.Nullable`1[System.Guid]'.”

        public async Task<Guid> AddMaterial(MaterialDto input)
        {
            var material = new Material
            {
                MaterialStandard =input.MaterialStandard,
                Name = input.Name,
                ReelNumber = input.ReelNumber,
                Model = input.Model,
                
                Strength = input.Strength,
                MaterialType = input.MaterialType,
              
                TypicalPartId = input.TypicalPartId,
                ManufactoryId = input.ManufactoryId,
                
                AppliedVehicleType = input.AppliedVehicleType,
                Remark=input.Remark
            };
            await _materialRepository.InsertAsync(material);
            //Thread.Sleep(100);
            return material.Id;
        }

        /// <summary>
        /// 更新某个材料信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateTrial(MaterialDto input, Guid id)
        {
            var material = await _materialRepository.GetAsync(id);
            material.MaterialStandard = input.MaterialStandard;
            material.Name = input.Name;
            material.Model = input.Model;
            
            material.Strength = input.Strength;
            material.MaterialType = input.MaterialType;
          
            material.ReelNumber = input.ReelNumber;
          
            material.AppliedVehicleType = input.AppliedVehicleType;
            material.TypicalPartId = input.TypicalPartId;
            material.ManufactoryId = input.ManufactoryId;
            
            return material.Id;
        }

     

        /// <summary>
        /// 根据材料Id删除某个材料信息和关联的材料试验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var material = await _materialRepository.GetAsync(id);
                await _materialTrialRepository.DeleteAsync(t => t.MaterialId == material.Id);
                await _materialRecommendationRepository.DeleteAsync(t => t.MaterialId == id);
                await _materialRepository.DeleteAsync(t => t.Id == id);
            }
        }
        /// <summary>
        /// 获取所有材料推荐
        /// </summary>

        /// <returns></returns>
        public List<MaterialRecommendationDto> GetMaterialRecommendations()
        {
            return _materialRecommendationRepository
                .AsNoTracking()
                .Select(g => g)
                .OrderBy(p => p.CreationTime)//.OrderBy(input.Sorting)
                .ProjectTo<MaterialRecommendationDto>(Configuration)
                .ToList();
        }
        /// <summary>
        /// 根据材料id添加材料推荐表
        /// </summary>
        /// <param name="id"></param>        
        /// <returns></returns>between types 'System.String' and 'System.Nullable`1[System.Guid]'.”

        public async Task<Guid?> AddMaterialRecommendations(Guid? id)

        {
            //var materialRecommendation0 = _materialRecommendationRepository
            //    .AsNoTracking()
            //    .WhereIf(id.HasValue, x => x.MaterialId == id)
            //    .ToList();
            ////如果之前已经添加过,则删除
            //if (materialRecommendation0.Count != 0)
            //{
            ////如果之前已经添加过,则删除
            await _materialRecommendationRepository.DeleteAsync(t => t.MaterialId== id);
            //}
                var material = _materialRepository
                    .AsNoTracking()
                    .WhereIf(id.HasValue, x => x.Id == id)
                     .ProjectTo<MaterialDto>(Configuration)
                     .FirstOrDefault();

                var materialRecommendation = new MaterialRecommendation
                {
                    Name = material.Name,
                    ReelNumber = material.ReelNumber,
                    Model = material.Model,
                    Manufactory = material.ManufactoryName,
                    FileString = material.FileString,
                    MaterialId = material.Id
                };
                await _materialRecommendationRepository.InsertAsync(materialRecommendation);
            //Thread.Sleep(100);
            return materialRecommendation.Id;
         
        }
        /// <summary>
        /// 删除材料推荐表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteMaterialRecommendations(Guid id)
        {


            await _materialRecommendationRepository.DeleteAsync(t => t.Id == id);

        }

        #region 入口
        /// <summary>
        /// 试验项目上传入口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<JObject>  AutoAddTestItem(IFormFileCollection input)
        {
            try
            {
                string itemname = input[0].FileName;
                int counts = input.Count();
                //图片字段存储
                 string pictureFileName = null;
                if (counts > 1)
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        var formFileName0 = formFileName.Substring(formFileName.LastIndexOf("/") + 1);
                            if (formFileName.Contains(".png") || formFileName.Contains(".jpg") || formFileName.Contains(".bmp") 
                                || formFileName.Contains(".tif") || formFileName.Contains(".jpeg") || formFileName.Contains(".JPG") 
                                || formFileName.Contains(".PNG") || formFileName.Contains(".TIF"))
                        {
                            pictureFileName += await UploadPicture(formFile)+";";
                            continue;
                        }
                    }
                }
                //文档字段存储
                string documentFileName = null;
                if (counts > 1)
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        var formFileName0 = formFileName.Substring(formFileName.LastIndexOf("/") + 1);
                        if ( formFileName.Contains(".pdf"))//formFileName.Contains(".doc") || formFileName.Contains(".docx") ||
                        {
                            documentFileName += await UploadDocument(formFile) + ";";
                            continue;
                        }
                    }
                }
                //标记字段
                string sign = "failed";
                string[] arraya ={ "静态拉伸", "低周疲劳", "物理性能", "回弹", "高周疲劳", "焊接", "氢致延迟" ,"高速拉伸","禁用物质","化学成分"
                        ,"表面性能","烘烤硬化","弯曲","压缩","翻边","FLD","二次加工脆","胶结","金相","抗凹","涂装"};

                //静态拉伸excel解析
                if (itemname.Contains(arraya[0]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddStaticTension2(formFile, pictureFileName, documentFileName);
                        }
                    }
                }

                //低周疲劳excel解析
                if (itemname.Contains(arraya[1]))
                { 
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if(formFileName.Contains(".xls")|| formFileName.Contains(".xlsx"))
                        {
                           sign = await AutoAddLowCycleFatigue(formFile, pictureFileName, documentFileName);
                                break;
                        }
              
                    }
                }
                //物理性能excel解析

                if (itemname.Contains(arraya[2]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddPhysicalPerformance(formFile, pictureFileName, documentFileName);
                            break;
                        }

                    }
                }
                //回弹excel解析

                if (itemname.Contains(arraya[3]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddRebound(formFile, pictureFileName, documentFileName);
                            break;
                        }

                    }
                }
                //高周疲劳excel解析

                if (itemname.Contains(arraya[4]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddHighCycleFatigue(formFile, pictureFileName, documentFileName);
                            break;
                        }

                    }
                }
                //焊接excel解析

                if (itemname.Contains(arraya[5]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddWelding(formFile, pictureFileName, documentFileName);
                            break;
                        }

                    }
                }
                //氢致延迟excel解析

                if (itemname.Contains(arraya[6]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddHydrogenInducedDelayedFracture(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //高速拉伸excel解析

                if (itemname.Contains(arraya[7]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddHighSpeedStrech(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //禁用物质excel解析

                if (itemname.Contains(arraya[8]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddProhibitedSubstance(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //化学成分excel解析

                if (itemname.Contains(arraya[9]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddChemicalElement(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                
               
                //表面性能excel解析

                if (itemname.Contains(arraya[10]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddSurfaceProperty2(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //烘烤硬化excel解析

                if (itemname.Contains(arraya[11]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddBakeHardening(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //弯曲excel解析

                if (itemname.Contains(arraya[12]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddBending(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //压缩excel解析

                if (itemname.Contains(arraya[13]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddCompress(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //翻边excel解析

                if (itemname.Contains(arraya[14]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddFlangingClasp(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //FLDexcel解析

                if (itemname.Contains(arraya[15]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddFLD(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //二次加工脆excel解析

                if (itemname.Contains(arraya[16]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddSecondaryWorkingEmbrittlement(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //胶结excel解析

                if (itemname.Contains(arraya[17]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddCementing(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //金相excel解析

                if (itemname.Contains(arraya[18]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddMetallographic(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //抗凹excel解析

                if (itemname.Contains(arraya[19]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddDentResistance(formFile, pictureFileName, documentFileName);
                        }

                    }
                }
                //涂装性能excel解析

                if (itemname.Contains(arraya[20]))
                {
                    foreach (var formFile in input)
                    {
                        var formFileName = formFile.FileName;
                        if (formFileName.Contains(".xls") || formFileName.Contains(".xlsx"))
                        {
                            sign = await AutoAddPainting(formFile, pictureFileName, documentFileName);
                        }

                    }
                }


              
                if(sign== "success")
                {
                    UploadResponseDto uploadResponseDto = new UploadResponseDto
                    {
                        Id = "101"
                    };
                    string jsonText = "{result:\"" + sign + "\"}";
                    return JObject.Parse(jsonText);
                }
                string jsonText2 = "{code:\"500\",message:\"" + "模版错误，请修改后重试！" + "\"}";
                JObject jo = JObject.Parse(jsonText2);
                return jo;
            }

            catch (Exception e)
            {
                Console.WriteLine(Convert.ToString(e));
                string rst = Convert.ToString(e);
                string jsonText = "{code:\"500\",message:\"" + "模版错误，请修改后重试！" + "\"}";
                JObject jo = JObject.Parse(jsonText);
                return jo;
            }
        }
        #endregion

        #region 公用部分
        /// <summary>
            /// 去除DataTable中空行
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
        protected DataTable RemoveEmpty(DataTable dt)
        {

            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool rowdataisnull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {

                        rowdataisnull = false;
                        break;
                    }
                }
                if (rowdataisnull)
                {
                    removelist.Add(dt.Rows[i]);
                }

            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
            return dt;
        }

        /// <summary>
        /// 图片导入公共部分
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        protected async Task<string> UploadPicture(IFormFile picture)

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
                pictureuniqueFileName =DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename;
                 string filePath = Path.Combine(uploadsPicture, pictureuniqueFileName);
               //因为使用了非托管资源，所以需要手动进行释放
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    await picture.CopyToAsync(fileStream);
                }

                return pictureuniqueFileName;
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }

        }
        /// <summary>
        /// 文档导入公共部分
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        protected async Task<string> UploadDocument(IFormFile document)

        {
            try
            {
               
                string contentRootPath = _webHostEnviornment.ContentRootPath;
                string uploadsdocument = Path.Combine(contentRootPath, "uploads\\documents");
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
                ////利用了if判断的先后顺序，顺序不可以变
                //if(filename.Contains(".docx"))
                //{
                //    filename = filename.Replace(".docx", ".pdf");
                //}
                //else if(filename.Contains(".doc"))
                //{
                //    filename = filename.Replace(".doc", ".pdf");
                //}
                documentuniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename;
                string filePath = Path.Combine(uploadsdocument, documentuniqueFileName);
                //如果是word文档含doc或docx,需要用spire.doc包将其转换为pdf再保存
                //if (document.FileName.Contains(".doc"))
                //{
                //    //WordDocument.Application application = new WordDocument.Application();
                //    //WordDocument.Document documentLoad = null;
                //    //application.Visible = false;
                //    //documentLoad = application.Documents.Open(@"C:\\Users\\Dell\\Desktop\\新建文件夹 (3)\\DC04模板\\低周疲劳\\新建 Microsoft Word 文档.doc");
                //    //documentLoad.ExportAsFixedFormat(filePath, WordDocument.WdExportFormat.wdExportFormatPDF);
                //}
                //else
                //{
                    //因为使用了非托管资源，所以需要手动进行释放
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {

                        await document.CopyToAsync(fileStream);
                   
                    }
                //}

                return documentuniqueFileName;
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }

        }
        
        /// <summary>
        /// 模板公用导入部分,是否存在该试验项目
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="material"></param>
        /// <param name="materialTrial"></param>       
        /// <returns></returns>
        protected async Task<Guid> AutoAddCommon( DataTable dt, Material material,MaterialTrial materialTrial)
        {
        

                //表基本信息字段数组
                string[] arraya = { "材料牌号","卷号" ,"型号规格", "生产厂家", "材料类别",
                                        "试验项目","材料标准"};

              
            ////文档
            //material.FileKey = documentFileName;
                for (int i = 0; i <9; i++)
                {
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        material.Name = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        material.ReelNumber =TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {

                        material.Model = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //根据生产厂家名称查询Manufactory得到唯一生产厂家Id
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                     
                        material.ManufactoryId = (_manufactoryRepository
                                .AsNoTracking()
                                .WhereIf(!string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()), m => m.Name == dt.Rows[1][i].ToString().Trim())
                                .Select(n => n.Id)
                                .ToList()).FirstOrDefault();
                        
                    //如果没有该厂家，则添加
                        if (material.ManufactoryId.ToString() == "00000000-0000-0000-0000-000000000000")
                        {
                        var manufactory = new Manufactory
                        {
                            Name = dt.Rows[1][i].ToString().Trim()
                        };
                        await _manufactoryRepository.InsertAsync(manufactory);
                        //Thread.Sleep(100);
                        material.ManufactoryId = manufactory.Id;
                        }

                    continue;
                    }
                  
                   //enum类型转换string
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                        {
                            material.MaterialType = (MaterialType)System.Enum.Parse(typeof(MaterialType), dt.Rows[1][i].ToString().Trim());
                            continue;
                        }
                    //根据试验项目得到唯一trialId
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[5]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        materialTrial.TrialId = (_trialRepository
                                .AsNoTracking()
                                .WhereIf(!string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()), m => m.Name == dt.Rows[1][i].ToString().Trim())
                                .Select(n => n.Id)
                                .ToList()).FirstOrDefault();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[6]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        material.MaterialStandard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                                      

                }
                //验证基本信息生产厂家、试验项目填写错误
                if (material.ManufactoryId.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentOutOfRangeException("生产厂家填写错误");
                }
                if (materialTrial.TrialId.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentOutOfRangeException("试验项目填写错误");
                }
                //生成材料数据,先判断是否已经导入该材料
                var idmaterial = _materialRepository
                                   .AsNoTracking()
                                   .Where(x => x.ManufactoryId == material.ManufactoryId && x.Name == material.Name && x.Model == material.Model  &&
                                    x.ReelNumber == material.ReelNumber && x.MaterialType == material.MaterialType)
                                   .Select(n => n.Id)
                                   .FirstOrDefault();

                //如果数据库没有该材料,则重新导入
                if (idmaterial.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    await _materialRepository.InsertAsync(material, true);
                //Thread.Sleep(100);

                //材料Id
                idmaterial = material.Id;

                }
                //生成材料试验 ,先判断是否已经导入该材料试验，如果已经导入，则删除后重新导入
                var idmaterialtrial = _materialTrialRepository
                             .AsNoTracking()
                             .Where(x => x.MaterialId == idmaterial && x.TrialId == materialTrial.TrialId)
                             .Select(n => n.Id)
                             .FirstOrDefault();
                if (idmaterialtrial.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    await _materialTrialRepository.DeleteAsync(t => t.Id == idmaterialtrial);
                    await _materialTrialDataRepository.DeleteAsync(t => t.MaterialTrialId == idmaterialtrial);
                }
                materialTrial.MaterialId = idmaterial;
                await _materialTrialRepository.InsertAsync(materialTrial, true);

            //材料试验Id
            idmaterialtrial = materialTrial.Id;

                //生成材料试验数据 
                var materialTrialData = new MaterialTrialData
                {
                    MaterialTrialId = idmaterialtrial
                };
            //选择true,才可以生成事务用sql语句在材料数据表中查到此id
                await _materialTrialDataRepository.InsertAsync(materialTrialData, true);
            //Thread.Sleep(100);
            //材料试验数据ID
            Guid idmaterialtrialdata = materialTrialData.Id;
                return idmaterialtrialdata;
            }

        /// <summary>
        /// 将科学计数或者小数型字符串转换为decimal
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        protected decimal TransToDecimal(string dec)
        {
            System.Globalization.NumberStyles sty = System.Globalization.NumberStyles.AllowExponent | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.Number ;
            if (!string.IsNullOrEmpty(dec))
            {
                return decimal.Parse(dec, sty);
            }
            else
            {
                return -1;
            }
            
        }
        /// <summary>
        /// 日期格式转换
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        protected DateTime TransToDate(string dec)
        {
            //自定义时间格式
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy.MM.dd";
            DateTime date = Convert.ToDateTime(dec, dtFormat);
            return date;
        }
        #endregion

        #region 材料文件自动导入静态拉伸
        /// <summary>
        /// 材料文件自动导入静态拉伸邯钢
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddStaticTension2(IFormFile input, string pictureName, string documentName)
        {
            try
            {
                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];
                //获取第2个工作表
                Worksheet sheetone = wb.Worksheets[1];
                //获取第3个工作表
                Worksheet sheettwo = wb.Worksheets[2];
                //获取工作表行数列数

                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, true);
                DataTable dtone = sheetone.ExportDataTable(sheetone.FirstRow, sheetone.FirstColumn, sheetone.LastRow, sheetone.LastColumn, false);
                DataTable dttwo = sheettwo.ExportDataTable(sheettwo.FirstRow, sheettwo.FirstColumn, sheettwo.LastRow, sheettwo.LastColumn, false);



                dt = RemoveEmpty(dt);
                //dtone = RemoveEmpty(dtone);
                //dttwo = RemoveEmpty(dttwo);
                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;
                //表1数据行数
                int rowsone = dtone.Rows.Count;

                //表2数据行数
                int rowstwo = dttwo.Rows.Count;
                int rowsmax = 0;
                if (rowsone < rowstwo)
                {
                    rowsmax = rowstwo;

                }
                else
                {
                    rowsmax = rowsone;
                }
                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
              
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
               
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法", "标距" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                decimal? gaugeDistance = null;

                for (int i =8; i < columns; i++)
                {
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        gaugeDistance = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }


                //静态拉伸试验Detail导入

                string[] arrayb = { "位置","方向","试样厚度","屈服强度","抗拉强度",
                                 "断后伸长率","应变硬化指数","塑性应变比","弹性模量","泊松比","最大力",
                                 "烘烤硬化值","弯曲试验","V型冲击试验温度",
                                    "V型冲击试验吸收能量" };

                for (int i = 0; i < columns; i++)
                {
                    string aa = dt.Rows[2][i].ToString().Trim();
                    if (!dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板0使用错误");
                    }
                }
                if (!(dtone.Rows[1][0].ToString().Trim().Contains("应变") &&
                    dtone.Rows[1][1].ToString().Trim().Contains("应力") &&
                    dttwo.Rows[1][0].ToString().Trim().Contains("真应变") &&
                    dttwo.Rows[1][1].ToString().Trim().Contains("真应力")))
                {
                    throw new ArgumentOutOfRangeException("模板1,2使用错误");
                }
                //第一类
                //计数性能要求的行数
                int reqNums = 0;
                for (int i = 3; i < rows; i++)
                {
                    if (dt.Rows[i][0].ToString().Trim().Contains("性能要求"))
                    {
                        StaticTensionDataDetailRequirement staticTensionDataDetailRequirements = new StaticTensionDataDetailRequirement
                        {
                            MaterialTrialDataId = idmaterialtrialdata
                        };
                        bool sign = false;
                        if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.SampleCode = dt.Rows[i][0].ToString().Trim();
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.Direction = dt.Rows[i][1].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.Thickness = dt.Rows[i][2].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.YieldStrength = dt.Rows[i][3].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.TensileStrength = dt.Rows[i][4].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.Elongation = dt.Rows[i][5].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][6].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.StrainHardening = dt.Rows[i][6].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.PlasticStrainRatio = dt.Rows[i][7].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][8].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.ModulusOfElasticity = dt.Rows[i][8].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][9].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.PoissonRatio = dt.Rows[i][9].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][10].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.MaximumForce = dt.Rows[i][10].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][11].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.BHValue = dt.Rows[i][11].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][12].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.IndenterDiameter = dt.Rows[i][12].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][13].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.VImpactTemperature = dt.Rows[i][13].ToString().Trim();
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i][14].ToString().Trim()))
                        {
                            staticTensionDataDetailRequirements.VImpactEnergy = dt.Rows[i][14].ToString().Trim();
                            sign = true;
                        }
                        if (sign)
                        {
                            await _staticTensionDataDetailRequirementRepository.InsertAsync(staticTensionDataDetailRequirements);
                        }

                        reqNums += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                //小批量数据
                int insertOrder = 1;
                for (int i = 3 + reqNums; i < 3 + reqNums + 25; i++)
                {
                    StaticTensionDataDetail StaticTensionDataDetails0 = new StaticTensionDataDetail
                    {
                        MaterialTrialDataId = idmaterialtrialdata,
                        TestOrganization = testOrganization,
                        Standard = standard,
                        Equipment = equipment,
                        TestMethod = testMethod,
                        GaugeDistance = gaugeDistance,
                        Dates=date,
                        DateEnds=dateEnd,
                        FileString = pictureName,
                        FileKey=documentName
                    };
                    bool sign = false;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.SampleCode = dt.Rows[i][0].ToString().Trim();
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.Direction = dt.Rows[i][1].ToString().Trim();
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.Thickness = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.YieldStrength = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.TensileStrength = TransToDecimal(dt.Rows[i][4].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.Elongation = TransToDecimal(dt.Rows[i][5].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][6].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.StrainHardening = TransToDecimal(dt.Rows[i][6].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.PlasticStrainRatio = TransToDecimal(dt.Rows[i][7].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][8].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.ModulusOfElasticity = TransToDecimal(dt.Rows[i][8].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][9].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.PoissonRatio = TransToDecimal(dt.Rows[i][9].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][10].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.MaximumForce = TransToDecimal(dt.Rows[i][10].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][11].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.BHValue = TransToDecimal(dt.Rows[i][11].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][12].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.IndenterDiameter = TransToDecimal(dt.Rows[i][12].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][13].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.VImpactTemperature = TransToDecimal(dt.Rows[i][13].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][14].ToString().Trim()))
                    {
                        StaticTensionDataDetails0.VImpactEnergy = TransToDecimal(dt.Rows[i][14].ToString().Trim());
                        sign = true;
                    }
                    if (sign)
                    {
                        StaticTensionDataDetails0.InsertOrder = insertOrder;
                        await _staticTensionDataDetailRepository.InsertAsync(StaticTensionDataDetails0);
                        insertOrder++;
                    }

                }

                //先生成实体数组，数量对应数据数rows - 3 - reqNums - 25
                List<StaticTensionDataDetailStressStrain> staticTensionDataDetailStressStrains = new List<StaticTensionDataDetailStressStrain>();
                //静态拉伸表信息字段数组,有顺序,验证模板
                string sampleCode1 = null;
                //屈服强度保存在这里，最后求均值放入添加到材料表中
                List<decimal?> yieldStrength = new List<decimal?>();
                int daiOrder = 3 + reqNums + 25; //带头带中带尾的插入顺序，排在小批量数据后
                for (int i = 3 + reqNums + 25; i < rows; i++)
                {
                    StaticTensionDataDetail staticTensionDataDetails1 = new StaticTensionDataDetail
                    {
                        MaterialTrialDataId = idmaterialtrialdata,
                        TestOrganization = testOrganization,
                        Standard = standard,
                        Equipment = equipment,
                        TestMethod = testMethod,
                        GaugeDistance = gaugeDistance,
                        FileString = pictureName,
                        FileKey = documentName
                    };
                    bool sign0 = false;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        staticTensionDataDetails1.SampleCode = dt.Rows[i][0].ToString().Trim();
                        sampleCode1= dt.Rows[i][0].ToString().Trim();
                        sign0 = true;
                    }
                    else
                    {
                        //SampleCode所在单元格为合并单元格，用这种方法处理保证都有值
                        staticTensionDataDetails1.SampleCode = sampleCode1;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        staticTensionDataDetails1.Direction = dt.Rows[i][1].ToString().Trim();
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        staticTensionDataDetails1.Thickness = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        staticTensionDataDetails1.YieldStrength = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        staticTensionDataDetails1.TensileStrength = TransToDecimal(dt.Rows[i][4].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                    {
                        staticTensionDataDetails1.Elongation = TransToDecimal(dt.Rows[i][5].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][6].ToString().Trim()))
                    {
                        staticTensionDataDetails1.StrainHardening = TransToDecimal(dt.Rows[i][6].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()))
                    {
                        staticTensionDataDetails1.PlasticStrainRatio = TransToDecimal(dt.Rows[i][7].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][8].ToString().Trim()))
                    {
                        staticTensionDataDetails1.ModulusOfElasticity = TransToDecimal(dt.Rows[i][8].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][9].ToString().Trim()))
                    {
                        staticTensionDataDetails1.PoissonRatio = TransToDecimal(dt.Rows[i][9].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][10].ToString().Trim()))
                    {
                        staticTensionDataDetails1.MaximumForce = TransToDecimal(dt.Rows[i][10].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][11].ToString().Trim()))
                    {
                        staticTensionDataDetails1.BHValue = TransToDecimal(dt.Rows[i][11].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][12].ToString().Trim()))
                    {
                        staticTensionDataDetails1.IndenterDiameter = TransToDecimal(dt.Rows[i][12].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][13].ToString().Trim()))
                    {
                        staticTensionDataDetails1.VImpactTemperature = TransToDecimal(dt.Rows[i][13].ToString().Trim());
                        sign0 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][14].ToString().Trim()))
                    {
                        staticTensionDataDetails1.VImpactEnergy = TransToDecimal(dt.Rows[i][14].ToString().Trim());
                        sign0 = true;
                    }
                    if (sign0)
                    {
                        //屈服强度保存在这里，最后求均值放入添加到材料表中
                        yieldStrength.Add(staticTensionDataDetails1.YieldStrength);
                        staticTensionDataDetails1.InsertOrder = daiOrder;
                        await _staticTensionDataDetailRepository.InsertAsync(staticTensionDataDetails1);
                        daiOrder++;

                        var n = (i - 3- reqNums - 25) * 2;
                        //应力应变和真应力应变数据对导入，取最大行数，j不能大于表行数
                        int order = 1;
                        for (int j = 2; j < rowsmax; j++)
                        {
                            bool bj = false;//用作是否导入数据的标识符
                            staticTensionDataDetailStressStrains.AddFirst(new StaticTensionDataDetailStressStrain());
                            staticTensionDataDetailStressStrains[0].StaticTensionDataDetailId = staticTensionDataDetails1.Id;
                            if (j < rowsone && !string.IsNullOrEmpty(dtone.Rows[j][n].ToString().Trim()) &&
                                  !string.IsNullOrEmpty(dtone.Rows[j][n + 1].ToString().Trim()))
                            {

                                staticTensionDataDetailStressStrains[0].Strain = TransToDecimal(dtone.Rows[j][n].ToString().Trim());
                                staticTensionDataDetailStressStrains[0].Stress = TransToDecimal(dtone.Rows[j][n + 1].ToString().Trim());
                                bj = true;
                            }
                            if (j < rowstwo && !string.IsNullOrEmpty(dttwo.Rows[j][n].ToString().Trim()) &&
                                    !string.IsNullOrEmpty(dttwo.Rows[j][n + 1].ToString().Trim()))
                            {
                                staticTensionDataDetailStressStrains[0].RealStrain = TransToDecimal(dttwo.Rows[j][n].ToString().Trim());
                                staticTensionDataDetailStressStrains[0].RealStress = TransToDecimal(dttwo.Rows[j][n + 1].ToString().Trim());
                                bj = true;
                            }
                            if (bj)
                            {
                                staticTensionDataDetailStressStrains[0].InsertOrder = order;
                                await _staticTensionDataDetailStressStrainRepository.InsertAsync(staticTensionDataDetailStressStrains[0]);
                                order++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }
             


                //屈服强度平均值录入material表中

                var project1 = _materialTrialDataRepository
                           
                            .Where(x => x.Id == idmaterialtrialdata)
                            .Include(m => m.MaterialTrial)
                            .ThenInclude(y => y.Material)
                            .Select(y => y.MaterialTrial.Material)
                            .ToList();

                           
                project1[0].Strength = Math.Round(yieldStrength.Average().GetValueOrDefault(), 2);

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入低周疲劳
        /// <summary>
        /// 材料文件自动导入低周疲劳
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddLowCycleFatigue(IFormFile input, string pictureName, string documentName)
        {
            try
            {
                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());

                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);

                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;
            
                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构","执行标准", "设备", "试验方法","循环应变比", "表面质量", "引伸计", "循环强度系数", "循环应变硬化" , "循环强度相关系数", 
                    "疲劳强度系数", "疲劳强度指数","疲劳强度相关系数",  "疲劳延性系数", "疲劳延性指数", "疲劳延性相关系数" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                string cyclicStrainRatio = null;
                string surfaceQuality = null;
                decimal? extensometerGaugeDistance = null;
                decimal? cyclicStrengthParameter = null;
                decimal? cyclicStrainHardening = null;
                decimal? relatedSressParameter = null;
                decimal? fatigueStrengthParameter = null;
                decimal? fatigueStrength = null;
                decimal? relatedLifeFatigueParameter = null;
                decimal? fatigueStrechParameter = null;
                decimal? fatigueStrech = null;
                decimal? relatedLifeStrechParameter = null;
              
                for (int i = 8; i < columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                         equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                   
                    //试验方法
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                         testMethod= Convert.ToString(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //循环应变比
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                       cyclicStrainRatio = Convert.ToString(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //表面质量
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[5]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfaceQuality = Convert.ToString(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //引伸计
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[6]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                         extensometerGaugeDistance = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //循环强度系数
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[7]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        cyclicStrengthParameter = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //循环应变硬化
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[8]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                         cyclicStrainHardening = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                 
                    //循环强度相关系数
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[9]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        relatedSressParameter = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //疲劳强度系数
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[10]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                          fatigueStrengthParameter = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //疲劳强度指数
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[11]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                         fatigueStrength = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //疲劳强度相关系数
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[12]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        relatedLifeFatigueParameter = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //疲劳延性系数
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[13]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                         fatigueStrechParameter = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //疲劳延性指数
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[14]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                          fatigueStrech = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    //疲劳延性相关系数
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[15]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                         relatedLifeStrechParameter = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }

                //低周疲劳试验Detail导入,分为两类导入，对应同一个 MaterialTrialDataId;
                    //第一类导入
                LowCycleFatigueDataDetail lowCycleFatigueDataDetail0 = new LowCycleFatigueDataDetail
                {
                    TestOrganization=testOrganization,
                    Standard = standard,
                    Equipment = equipment,
                    TestMethod=testMethod,                   
                    CyclicStrainRatio = cyclicStrainRatio,
                    SurfaceQuality = surfaceQuality,
                    ExtensometerGaugeDistance = extensometerGaugeDistance,
                    CyclicStrengthParameter = cyclicStrengthParameter,
                    CyclicStrainHardening = cyclicStrainHardening,                     
                    RelatedSressParameter = relatedSressParameter,
                    FatigueStrengthParameter = fatigueStrengthParameter,
                    FatigueStrength = fatigueStrength,
                    RelatedLifeFatigueParameter = relatedLifeFatigueParameter,
                    FatigueStrechParameter = fatigueStrechParameter,
                    FatigueStrech = fatigueStrech,
                    RelatedLifeStrechParameter = relatedLifeStrechParameter,
                    Dates=date,
                    DateEnds=dateEnd,
                    //图片
                    FileString = pictureName,
                    FileKey=documentName,
                    MaterialTrialDataId = idmaterialtrialdata
                };
                await _lowCycleFatigueDataDetailRepository.InsertAsync(lowCycleFatigueDataDetail0);
                // 低周疲劳试验Detail.id
                var idlowCycleFatigueDataDetail0 = lowCycleFatigueDataDetail0.Id;


                //第二类导入
                List<LowCycleFatigueDataDetail> lowCycleFatigueDataDetail = new List<LowCycleFatigueDataDetail>();
                string[] arrayb = { "抗拉强度","屈服强度","断后伸长率A" };

                for (int i = 0; i < columns; i++)
                {
                    string aa = dt.Rows[2][i].ToString().Trim();
                    if (dt.Rows[2][i].ToString().Trim().Contains(arrayb[0]))
                    {
                        for (int j = 3; j < rows; j++)
                        {
                            bool bj = false;//用作是否导入数据的标识符
                            lowCycleFatigueDataDetail.AddFirst(new LowCycleFatigueDataDetail());
                            lowCycleFatigueDataDetail[0].MaterialTrialDataId = idmaterialtrialdata;
                            if (!string.IsNullOrEmpty(dt.Rows[j][i].ToString().Trim()))
                            {
                                //抗拉强度
                                lowCycleFatigueDataDetail[0].FormTensileStrength = TransToDecimal(dt.Rows[j][i].ToString().Trim());
                                bj = true;
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[j][i + 1].ToString().Trim()))
                            {
                                //屈服强度
                                lowCycleFatigueDataDetail[0].FormYieldStrength = TransToDecimal(dt.Rows[j][i + 1].ToString().Trim());
                                bj = true;
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[j][i + 2].ToString().Trim()))
                            {
                                //断后伸长率
                                lowCycleFatigueDataDetail[0].FormModulusOfElasticity = TransToDecimal(dt.Rows[j][i + 2].ToString().Trim());
                                bj = true;
                            }
                            if (bj)
                            {
                                await _lowCycleFatigueDataDetailRepository.InsertAsync(lowCycleFatigueDataDetail[0]);
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                }
                //低周疲劳项目表信息字段数组,有顺序,验证模板
                string[] arrayc = { "编号","总应变幅","塑性应变幅","弹性应变幅","失效循环数","循环应力幅",
                                 "试验频率","抗拉强度","屈服强度","断后伸长率A" };

                for (int i = 0; i < columns; i++)
                {
                    bool yz = true;
                    foreach (var item in arrayc)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || dt.Rows[2][i].ToString().Trim().Contains(item))
                        {
                            yz = false;
                            break;
                        }
                    }
                    if (yz)
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }
                //低周疲劳项目表信息字段插入
                List<LowCycleFatigueDataDetailItem> lowCycleFatigueDataDetailItem = new List<LowCycleFatigueDataDetailItem>();
                int order = 1;
                for (int i = 3; i < rows; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        break;
                    }
                    lowCycleFatigueDataDetailItem.AddFirst(new LowCycleFatigueDataDetailItem());
                    lowCycleFatigueDataDetailItem[0].LowCycleFatigueDataDetailId = idlowCycleFatigueDataDetail0;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        lowCycleFatigueDataDetailItem[0].SampleCode = dt.Rows[i][0].ToString().Trim();
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        lowCycleFatigueDataDetailItem[0].TotalStrainAmplitude = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        lowCycleFatigueDataDetailItem[0].PlasticStrainAmplitude = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        lowCycleFatigueDataDetailItem[0].ElasticStrainAmplitude = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        lowCycleFatigueDataDetailItem[0].FailureCycleTimes = Convert.ToInt32(dt.Rows[i][4].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                    {
                        lowCycleFatigueDataDetailItem[0].CycleStressAmplitude = TransToDecimal(dt.Rows[i][5].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][6].ToString().Trim()))
                    {
                        lowCycleFatigueDataDetailItem[0].TestFrequency = TransToDecimal(dt.Rows[i][6].ToString().Trim());
                    }
                    lowCycleFatigueDataDetailItem[0].InsertOrder = order;
                    await _lowCycleFatigueDataDetailItemRepository.InsertAsync(lowCycleFatigueDataDetailItem[0]);
                    order++;
                }
                return "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入物理性能
        /// <summary>
        /// 材料文件自动导入物理性能
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddPhysicalPerformance(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);

             

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;

                for (int i = 8; i < columns; i++)
                {
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                }


                //物理性能Detail导入 对应 MaterialTrialDataId;

                PhysicalPerformanceDataDetail physicalPerformanceDataDetail = new PhysicalPerformanceDataDetail
                {
                    TestOrganization = testOrganization,
                    TestMethod=testMethod,
                    Standard = standard,
                    Equipment = equipment,
                    Dates=date,
                    DateEnds=dateEnd,
                    MaterialTrialDataId = idmaterialtrialdata,

                    FileString = pictureName,
                    FileKey=documentName
                };
                string[] arrayb = { "维氏硬度", "布氏硬度", "洛氏硬度", "密度", "电阻率" };
                for (int i = 0; i < 5; i++)
                {
                    //维氏硬度
                    if (dt.Rows[2][i].ToString().Trim().Contains(arrayb[0]) && !string.IsNullOrEmpty(dt.Rows[3][i].ToString().Trim()))
                    {
                        physicalPerformanceDataDetail.HV = TransToDecimal( dt.Rows[3][i].ToString().Trim());
                        continue;
                    }
                    //布氏硬度
                    if (dt.Rows[2][i].ToString().Trim().Contains(arrayb[1]) && !string.IsNullOrEmpty(dt.Rows[3][i].ToString().Trim()))
                    {
                        physicalPerformanceDataDetail.HBW = TransToDecimal(dt.Rows[3][i].ToString().Trim());
                        continue;
                    }
                    //洛氏硬度
                    if (dt.Rows[2][i].ToString().Trim().Contains(arrayb[2]) && !string.IsNullOrEmpty(dt.Rows[3][i].ToString().Trim()))
                    {
                        physicalPerformanceDataDetail.HRC = TransToDecimal(dt.Rows[3][i].ToString().Trim());
                        continue;
                    }
                    //密度
                    if (dt.Rows[2][i].ToString().Trim().Contains(arrayb[3]) && !string.IsNullOrEmpty(dt.Rows[3][i].ToString().Trim()))
                    {
                        physicalPerformanceDataDetail.Density = TransToDecimal(dt.Rows[3][i].ToString().Trim());
                        continue;
                    }
                    //电阻率
                    if (dt.Rows[2][i].ToString().Trim().Contains(arrayb[4]) && !string.IsNullOrEmpty(dt.Rows[3][i].ToString().Trim()))
                    {
                        physicalPerformanceDataDetail.Resistivity = TransToDecimal(dt.Rows[3][i].ToString().Trim());
                        continue;
                    }

                }
                await _physicalPerformanceDataDetailRepository.InsertAsync(physicalPerformanceDataDetail);
                // 物理性能Detail.id
                var idphysicalPerformanceDataDetail = physicalPerformanceDataDetail.Id;
               

                //模板验证
                string[] arrayc = { "温度", "热膨胀系数", "温度" , "导热系数"  };
                for(int i=0;i<4;i++)
                {
                    if(string.IsNullOrEmpty(dt.Rows[4][i].ToString().Trim()) || !dt.Rows[4][i].ToString().Trim().Contains(arrayc[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }
               
                //物理性能-导热系数数据导入

                List<PhysicalPerformanceDataDetailThermalConductivity> physicalPerformanceDataDetailThermalConductivity = new List<PhysicalPerformanceDataDetailThermalConductivity>();


                for (int i = 5; i <rows; i++)

                {
                    if (string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()) || string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        break;
                    }
                    physicalPerformanceDataDetailThermalConductivity.AddFirst(new PhysicalPerformanceDataDetailThermalConductivity());
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                        {
                        physicalPerformanceDataDetailThermalConductivity[0].Temperature = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim())) { 
                        physicalPerformanceDataDetailThermalConductivity[0].ThermalConductivity = TransToDecimal( dt.Rows[i][3].ToString().Trim());
                    }
                    physicalPerformanceDataDetailThermalConductivity[0].PhysicalPerformanceDataDetailId = idphysicalPerformanceDataDetail;
                    await _physicalPerformanceDataDetailThermalConductivityRepository.InsertAsync(physicalPerformanceDataDetailThermalConductivity[0]);
                }
                //物理性能-热膨胀系数数据导入

                List<PhysicalPerformanceDataDetailThermalExpansion> physicalPerformanceDataDetailThermalExpansion = new List<PhysicalPerformanceDataDetailThermalExpansion>();


                for (int i =5; i < rows; i++)

                {
                    if (string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()) || string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        break;
                    }
                    physicalPerformanceDataDetailThermalExpansion.AddFirst(new PhysicalPerformanceDataDetailThermalExpansion());
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        physicalPerformanceDataDetailThermalExpansion[0].TemperatureRange = dt.Rows[i][0].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        physicalPerformanceDataDetailThermalExpansion[0].ThermalExpansion = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                    }
                    physicalPerformanceDataDetailThermalExpansion[0].PhysicalPerformanceDataDetailId = idphysicalPerformanceDataDetail;
                    await _physicalPerformanceDataDetailThermalExpansionRepository.InsertAsync(physicalPerformanceDataDetailThermalExpansion[0]);
                    //Thread.Sleep(100);

                }
                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入回弹
        /// <summary>
        /// 材料文件自动导入回弹
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddRebound(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);

                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "回弹试验类型", "试验方法", "弯曲角度", "凸模圆角", "试样尺寸", "试验速度", "保持压力", "保持时间" };


                //回弹性能Detail导入 

                ReboundDataDetail reboundDataDetail = new ReboundDataDetail {
                    MaterialTrialDataId = idmaterialtrialdata,
                    FileString=pictureName,
                    FileKey=documentName,
                    Dates=date,
                    DateEnds=dateEnd
                };


                for (int i = 8; i < columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.TestType = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[5]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.BendingAngleRange = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[6]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.PunchFilletRadiusRange = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[7]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.SampleSize = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[8]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.TestSpeed = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[9]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.HoldStress = TransToDecimal( dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[10]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        reboundDataDetail.HoldTimes =Convert.ToInt32( dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                   

                }
                await _reboundDataDetailRepository.InsertAsync(reboundDataDetail);
                var idreboundDataDetail = reboundDataDetail.Id;
                
                //子表1导入,与模板验证
                string[] arrayb = { "方向", "厚度", "凸模圆角半径", "弯曲角度", "测量角度", "回弹角" };
                for (int i = 0; i <6; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {       
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

                List<ReboundDataDetailItem> reboundDataDetailItem = new List<ReboundDataDetailItem>();
                int order = 1;
                for (int i = 3; i < rows; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()) || string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()) || string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        break;
                    }
                    reboundDataDetailItem.AddFirst(new ReboundDataDetailItem());
                    reboundDataDetailItem[0].ReboundDataDetailId = idreboundDataDetail;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        reboundDataDetailItem[0].Direction = dt.Rows[i][0].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        reboundDataDetailItem[0].Thickness = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        reboundDataDetailItem[0].PunchFilletRadius = dt.Rows[i][2].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        reboundDataDetailItem[0].BendingAngle = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        reboundDataDetailItem[0].MeasuringAngle = TransToDecimal(dt.Rows[i][4].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                    {
                        reboundDataDetailItem[0].ReboundAngle = TransToDecimal(dt.Rows[i][5].ToString().Trim());
                    }
                    reboundDataDetailItem[0].InsertOrder = order;
                    await _reboundDataDetailItemRepository.InsertAsync(reboundDataDetailItem[0]);
                    order++;

                }
                //子表2导入,与模板验证
                string[] arrayc = { "方向", "弯曲角度", "厚度", "R=t", "1.5t", "1.67t", "2t", "2.3t", "2.67t", "最小弯曲角度" };
                for (int i = 0; i < 10; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i+7].ToString().Trim()) || !dt.Rows[2][i+7].ToString().Trim().Contains(arrayc[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

                List<ReboundDataDetailItem2> reboundDataDetailItem2= new List<ReboundDataDetailItem2>();
                order = 1;
                for (int i = 3; i < rows; i++)

                {
                    if (string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()) || string.IsNullOrEmpty(dt.Rows[i][8].ToString().Trim()))
                    {
                        break;
                    }
                    reboundDataDetailItem2.AddFirst(new ReboundDataDetailItem2());
                    reboundDataDetailItem2[0].ReboundDataDetailId = idreboundDataDetail;
                    if (!string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].Direction = dt.Rows[i][7].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][8].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].BendingAngle = TransToDecimal(dt.Rows[i][8].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][9].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].Thickness = TransToDecimal(dt.Rows[i][9].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][10].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].Rt1 = dt.Rows[i][10].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][11].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].Rt2 = dt.Rows[i][11].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][12].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].Rt3 = dt.Rows[i][12].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][13].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].Rt4 = dt.Rows[i][13].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][14].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].Rt5 = dt.Rows[i][14].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][15].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].Rt6 = dt.Rows[i][15].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][16].ToString().Trim()))
                    {
                        reboundDataDetailItem2[0].RtMin = dt.Rows[i][16].ToString().Trim();
                    }
                    reboundDataDetailItem2[0].InsertOrder = order;
                    await _reboundDataDetailItem2Repository.InsertAsync(reboundDataDetailItem2[0]);
                    order++;

                }
                //子表3导入,与模板验证
                string[] arrayd = { "方向", "厚度","R/t=0.5","R/t=1", "R/t=1.5", "R/t=2" };
                for (int i = 0; i < 6; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i + 18].ToString().Trim()) || !dt.Rows[2][i + 18].ToString().Trim().Contains(arrayd[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

                List<ReboundDataDetailItem3> reboundDataDetailItem3 = new List<ReboundDataDetailItem3>();
                order = 1;
                for (int i = 3; i < rows; i++)

                {
                    if (string.IsNullOrEmpty(dt.Rows[i][18].ToString().Trim()) || string.IsNullOrEmpty(dt.Rows[i][19].ToString().Trim()))
                    {
                        break;
                    }
                    reboundDataDetailItem3.AddFirst(new ReboundDataDetailItem3());
                    reboundDataDetailItem3[0].ReboundDataDetailId = idreboundDataDetail;
                    if (!string.IsNullOrEmpty(dt.Rows[i][18].ToString().Trim()))
                    {
                        reboundDataDetailItem3[0].Direction = dt.Rows[i][18].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][19].ToString().Trim()))
                    {
                        reboundDataDetailItem3[0].Thickness = TransToDecimal(dt.Rows[i][19].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][20].ToString().Trim()))
                    {
                        reboundDataDetailItem3[0].Rt1 = dt.Rows[i][20].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][21].ToString().Trim()))
                    {
                        reboundDataDetailItem3[0].Rt2 = dt.Rows[i][21].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][22].ToString().Trim()))
                    {
                        reboundDataDetailItem3[0].Rt3 = dt.Rows[i][22].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][23].ToString().Trim()))
                    {
                        reboundDataDetailItem3[0].Rt4 = dt.Rows[i][23].ToString().Trim();
                    }
                    reboundDataDetailItem3[0].InsertOrder = order;
                    await _reboundDataDetailItem3Repository.InsertAsync(reboundDataDetailItem3[0]);
                    order++;
                }
                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入高周疲劳
        /// <summary>
        /// 材料文件自动导入高周疲劳
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddHighCycleFatigue(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);

                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;

                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法", "表面质量", "循环应力比", "引伸计规格", "公式", "a", "b", "相关系数", "疲劳极限", "标准偏差" };


                //高周疲劳Detail导入  分两类
                //第一类
                HighCycleFatigueDataDetail highCycleFatigueDataDetail = new HighCycleFatigueDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                    //图片
                    FileString = pictureName,
                    FileKey=documentName,
                    Dates=date,
                    DateEnds=dateEnd
                };

                for (int i = 8; i < columns; i++)
                {
                    
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.SurfaceQuality= dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[5]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.CyclicStressRatio = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[6]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.ExtensometerGaugeDistance =TransToDecimal( dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[7]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.Formula = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Equals(arraya[8]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.SNAParameter =TransToDecimal( dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[9]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.SNBParameter =TransToDecimal( dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[10]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.SNRelatedParameter =TransToDecimal( dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[11]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.FatigueLimitStrength = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[12]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        highCycleFatigueDataDetail.StandardDeviation =TransToDecimal( dt.Rows[1][i].ToString().Trim());
                        continue;
                    }

                }
                await _highCycleFatigueDataDetailRepository.InsertAsync(highCycleFatigueDataDetail);
                //Thread.Sleep(100);
                var idhighCycleFatigueDataDetail = highCycleFatigueDataDetail.Id;
                //第二类
                List<HighCycleFatigueDataDetail> highCycleFatigueDataDetail1 = new List<HighCycleFatigueDataDetail>();
                string[] arrayb = { "抗拉强度", "屈服强度", "断后伸长率A" };

                for (int i = 5; i < columns; i++)
                {
                    string ss = dt.Rows[2][i].ToString().Trim();
                    if (dt.Rows[2][i].ToString().Trim().Contains(arrayb[0]))
                    {
                        for (int j = 3; j < rows; j++)
                        {
                            bool bj = false;//用作是否导入数据的标识符
                            highCycleFatigueDataDetail1.AddFirst(new HighCycleFatigueDataDetail());
                            highCycleFatigueDataDetail1[0].MaterialTrialDataId = idmaterialtrialdata;
                            if (!string.IsNullOrEmpty(dt.Rows[j][i].ToString().Trim()))
                            {
                                //抗拉强度
                                highCycleFatigueDataDetail1[0].FormTensileStrength = TransToDecimal(dt.Rows[j][i].ToString().Trim());
                                bj = true;
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[j][i + 1].ToString().Trim()))
                            {


                                //屈服强度
                                highCycleFatigueDataDetail1[0].FormYieldStrength = TransToDecimal(dt.Rows[j][i + 1].ToString().Trim());
                                bj = true;
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[j][i + 2].ToString().Trim()))
                            {

                                //断后伸长率
                                highCycleFatigueDataDetail1[0].FormModulusOfElasticity = TransToDecimal(dt.Rows[j][i + 2].ToString().Trim());
                                bj = true;
                            }
                            if (bj)
                            {
                                await _highCycleFatigueDataDetailRepository.InsertAsync(highCycleFatigueDataDetail1[0]);
                                // Thread.Sleep(100);
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                }
                //子表导入,与模板验证
                string[] arrayc = { "编号", "最大应力", "应力幅", "循环次数" };
                int order = 1;
                for (int i = 0; i < 4; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayc[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

                List<HighCycleFatigueDataDetailItem> highCycleFatigueDataDetailItem = new List<HighCycleFatigueDataDetailItem>();
                for (int i = 3; i < rows; i++)

                {
                    if (string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        break;
                    }
                    highCycleFatigueDataDetailItem.AddFirst(new HighCycleFatigueDataDetailItem());
                    highCycleFatigueDataDetailItem[0].HighCycleFatigueDataDetailId = idhighCycleFatigueDataDetail;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        highCycleFatigueDataDetailItem[0].ItemSampleCode = dt.Rows[i][0].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        highCycleFatigueDataDetailItem[0].MaximumStress = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        highCycleFatigueDataDetailItem[0].StressAmplitude = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        highCycleFatigueDataDetailItem[0].TestFrequency = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                    }

                    highCycleFatigueDataDetailItem[0].InsertOrder = order;
                    await _highCycleFatigueDataDetailItemRepository.InsertAsync(highCycleFatigueDataDetailItem[0]);
                    order++;

                }

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入焊接
        /// <summary>
        /// 材料文件自动导入焊接
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddWelding(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);

                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;

                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构","执行标准", "焊接试验类型", "焊机类别", "焊机型号","试验方法", "电极头前端直径", "电极压力", "脉冲次数", "预压时间",
                    "升压时间", "最小焊接时间", "中值焊接时间","最大焊接时间"   ,"保压时间" ,"临界焊点直径"     };


                //焊接Detail导入  

                WeldingDataDetail weldingDataDetail = new WeldingDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                    Dates=date,
                    DateEnds=dateEnd,
                    //图片
                    FileString = pictureName,
                    FileKey=documentName
                  
                };


                for (int i = 8; i < columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                  
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.TestType = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.WelderType= dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.WelderMode= dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[5]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[6]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.HeadDiameter= TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[7]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail .ElectrodePressure= TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Equals(arraya[8]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.PulseTimes = Convert.ToInt32(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[9]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.PreloadingTimes = Convert.ToInt32(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[10]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.BoostTimes = Convert.ToInt32(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[11]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.MinimumWeldingTimes= Convert.ToInt32(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[12]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.MiddleWeldingTimes = Convert.ToInt32(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[13]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.MaxmumWeldingTimes = Convert.ToInt32(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[14]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.HoldingWeldingTimes = Convert.ToInt32(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[15]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        weldingDataDetail.CriticalJointDiameter = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                await _weldingDataDetailRepository.InsertAsync(weldingDataDetail);
                //Thread.Sleep(100);
                var idweldingDataDetail = weldingDataDetail.Id;
               
                //子表导入,与模板验证
                string[] arrayc = { "焊接时间", "左边界电流", "右边界电流", "焊接电流区间" };
                for (int i = 0; i <4; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayc[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

                List<WeldingDataDetailItem> weldingDataDetailItem = new List<WeldingDataDetailItem>();
                int order = 1;
                for (int i = 3; i < rows; i++)

                {
                    if (string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        break;
                    }
                    weldingDataDetailItem.AddFirst(new WeldingDataDetailItem());
                    weldingDataDetailItem[0].WeldingDataDetailId = idweldingDataDetail;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        weldingDataDetailItem[0].WeldingTimes = Convert.ToInt32(dt.Rows[i][0].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        weldingDataDetailItem[0].LeftBoundaryElectric = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        weldingDataDetailItem[0].RightBoundaryElectric = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        weldingDataDetailItem[0].WeldingCurrentInterval = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                    }
                    weldingDataDetailItem[0].InsertOrder = order;
                    await _weldingDataDetailItemRepository.InsertAsync(weldingDataDetailItem[0]);
                    order++;
                }
                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入氢致延迟断裂
        /// <summary>
        /// 材料文件自动导入氢致延迟断裂
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddHydrogenInducedDelayedFracture(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = {"测试机构", "执行标准", "设备", "氢脆试验项目", "试验方法", "溶液类别", "试验时间"};


                //氢脆Detail导入  

                HydrogenInducedDelayedFractureDataDetail hydrogenInducedDelayedFractureDataDetail = new HydrogenInducedDelayedFractureDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                    Dates=date,
                    DateEnds=dateEnd,
                    //图片
                    FileString = pictureName,
                    FileKey=documentName
                };

                for (int i = 8; i < columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetail.TestName = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[5]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetail.LiquorType = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[6]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetail.TestTime = TransToDecimal(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                   
                   

                }
                await _hydrogenInducedDelayedFractureDataDetailRepository.InsertAsync(hydrogenInducedDelayedFractureDataDetail);
                //Thread.Sleep(100);
                var idhydrogenInducedDelayedFractureDataDetail = hydrogenInducedDelayedFractureDataDetail.Id;

                //子表导入,与模板验证
                string[] arrayc = { "弯曲跨度", "弯曲应变", "弯曲应力", "试验时间", "试验结果" };

                for (int i = 0; i < 5; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayc[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

                List<HydrogenInducedDelayedFractureDataDetailItem> hydrogenInducedDelayedFractureDataDetailItem = new List<HydrogenInducedDelayedFractureDataDetailItem>();
                int order = 1;
                for (int i = 3; i < rows; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        break;
                    }
                    hydrogenInducedDelayedFractureDataDetailItem.AddFirst(new HydrogenInducedDelayedFractureDataDetailItem());
                    hydrogenInducedDelayedFractureDataDetailItem[0].HydrogenInducedDelayedFractureDataDetailId = idhydrogenInducedDelayedFractureDataDetail;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetailItem[0].Span = TransToDecimal(dt.Rows[i][0].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetailItem[0].Strain = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetailItem[0].Stress = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetailItem[0].Hour = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        hydrogenInducedDelayedFractureDataDetailItem[0].Remark = dt.Rows[i][4].ToString().Trim();
                    }

                    hydrogenInducedDelayedFractureDataDetailItem[0].InsertOrder = order;
                    await _hydrogenInducedDelayedFractureDataDetailItemRepository.InsertAsync(hydrogenInducedDelayedFractureDataDetailItem[0]);
                    order++;
                }

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入高速拉伸邯钢
        /// <summary>
        /// 材料文件自动导入高速拉伸邯钢
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddHighSpeedStrech(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());
                WorksheetsCollection sheets = wb.Worksheets;
                //表数量
                int sheetNumber = sheets.Count;


                DataTable[] dt = new DataTable[sheetNumber];
                CellRange range;
                //获取工作表
                for (int i = 0; i < sheetNumber; i++)
                {

                    range = sheets[i].Range[sheets[i].FirstRow, sheets[i].FirstColumn, sheets[i].LastRow, sheets[i].LastColumn];
                    //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题
                    dt[i] = sheets[i].ExportDataTable(range, false, false);
                }
                //释放资源
                wb.Dispose();

                dt[0] = RemoveEmpty(dt[0]);

                //表0数据行数,列数
                int rows = dt[0].Rows.Count;
                int columns = dt[0].Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt[0], material, materialTrial );

                //高速拉伸Detail导入  分两类
                //第二类
                List<HighSpeedStrechDataDetail> highSpeedStrechDataDetail1 = new List<HighSpeedStrechDataDetail>();
                string[] arrayb = { "材料牌号", "屈服强度", "抗拉强度", "断后伸长率", "弹性模量", "杨氏模量", "泊松比" };

                for (int i = 9; i < columns; i++)
                {
                    if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayb[0]))
                    {
                        for (int j = 3; j < rows; j++)
                        {
                            bool bj = false;//用作是否导入数据的标识符
                            highSpeedStrechDataDetail1.AddFirst(new HighSpeedStrechDataDetail());
                            highSpeedStrechDataDetail1[0].MaterialTrialDataId = idmaterialtrialdata;
                            if (!string.IsNullOrEmpty(dt[0].Rows[j][i].ToString().Trim()))
                            {
                                //材料牌号编码
                                highSpeedStrechDataDetail1[0].NameCode = dt[0].Rows[j][i].ToString().Trim();
                                bj = true;
                            }
                            //else
                            //{
                            //    highSpeedStrechDataDetail1[0].NameCode = dt[0].Rows[1][0].ToString().Trim();
                            //    bj = true;
                            //}
                            
                            if (!string.IsNullOrEmpty(dt[0].Rows[j][i+1].ToString().Trim()))
                            {
                                //屈服强度
                                highSpeedStrechDataDetail1[0].FormYieldStrength = TransToDecimal(dt[0].Rows[j][i+1].ToString().Trim());
                                bj = true;
                            }
                            //else
                            //{
                            //    highSpeedStrechDataDetail1[0].FormYieldStrength = null;
                            //    bj = true;
                            //}

                            if (!string.IsNullOrEmpty(dt[0].Rows[j][i + 2].ToString().Trim()))
                            {
                                //抗拉强度
                                highSpeedStrechDataDetail1[0].FormTensileStrength = TransToDecimal(dt[0].Rows[j][i + 2].ToString().Trim());
                                bj = true;
                            }
                            //else
                            //{
                            //    highSpeedStrechDataDetail1[0].FormTensileStrength = null;
                            //    bj = true;
                            //}

                            if (!string.IsNullOrEmpty(dt[0].Rows[j][i + 3].ToString().Trim()))
                            {
                                //断后伸长率
                                highSpeedStrechDataDetail1[0].FormModulusOfElasticity = TransToDecimal(dt[0].Rows[j][i + 3].ToString().Trim());
                                bj = true;
                            }
                            //else
                            //{
                            //    highSpeedStrechDataDetail1[0].FormModulusOfElasticity = null;
                            //    bj = true;
                            //}

                            if (!string.IsNullOrEmpty(dt[0].Rows[j][i + 4].ToString().Trim()))
                            {
                                //弹性模量
                                highSpeedStrechDataDetail1[0].FormElongation = TransToDecimal(dt[0].Rows[j][i + 4].ToString().Trim());
                                bj = true;
                            }
                            //else
                            //{
                            //    highSpeedStrechDataDetail1[0].FormElongation = null;
                            //    bj = true;
                            //}

                            if (!string.IsNullOrEmpty(dt[0].Rows[j][i + 5].ToString().Trim()))
                            {
                                //杨氏模量
                                highSpeedStrechDataDetail1[0].YoungModulu = TransToDecimal(dt[0].Rows[j][i + 5].ToString().Trim());
                                bj = true;
                            }
                            //else
                            //{
                            //    highSpeedStrechDataDetail1[0].YoungModulu = null;
                            //    bj = true;
                            //}

                            if (!string.IsNullOrEmpty(dt[0].Rows[j][i + 6].ToString().Trim()))
                            {
                                //泊松比
                                highSpeedStrechDataDetail1[0].PoissonRatio = TransToDecimal(dt[0].Rows[j][i + 6].ToString().Trim());
                                bj = true;
                            }
                            //else
                            //{
                            //    highSpeedStrechDataDetail1[0].PoissonRatio = null;
                            //    bj = true;
                            //}

                            if (bj)
                            {
                                //
                                await _highSpeedStrechDataDetailRepository.InsertAsync(highSpeedStrechDataDetail1[0]);
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                }
                //第一类
                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {
                    if (dt[0].Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt[0].Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt[0].Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt[0].Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt[0].Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt[0].Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法", "取样方向" };
                string[] arrayc = { "拉伸速率", "样件编号", "样品厚度", "标距段宽度", "屈服强度", "抗拉强度", "断后伸长率", "拉伸速度" };
                HighSpeedStrechDataDetail[] highSpeedStrechDataDetail = new HighSpeedStrechDataDetail[rows - 3];

                int detailInsertOrder = 1;
                for (int j = 0; j < rows - 3; j++)
                {
                    highSpeedStrechDataDetail[j] = new HighSpeedStrechDataDetail();
                    highSpeedStrechDataDetail[j].MaterialTrialDataId = idmaterialtrialdata;
                    highSpeedStrechDataDetail[j].Dates = date;
                    highSpeedStrechDataDetail[j].DateEnds = dateEnd;
                    //图片
                    highSpeedStrechDataDetail[j].FileString = pictureName;
                    highSpeedStrechDataDetail[j].FileKey =documentName;

                    //第一部分导入
                    for (int i = 9; i < columns; i++)
                    {
                        //测试机构
                        if (dt[0].Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt[0].Rows[1][i].ToString().Trim()))
                        {
                            highSpeedStrechDataDetail[j].TestOrganization = dt[0].Rows[1][i].ToString().Trim();
                            continue;
                        }
                        //执行标准
                        if (dt[0].Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt[0].Rows[1][i].ToString().Trim()))
                        {
                            highSpeedStrechDataDetail[j].Standard = dt[0].Rows[1][i].ToString().Trim();
                            continue;
                        }
                        //设备
                        if (dt[0].Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt[0].Rows[1][i].ToString().Trim()))
                        {
                            highSpeedStrechDataDetail[j].Equipment = dt[0].Rows[1][i].ToString().Trim();
                            continue;
                        }
                        //试验方法
                        if (dt[0].Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt[0].Rows[1][i].ToString().Trim()))
                        {
                            highSpeedStrechDataDetail[j].TestMethod = dt[0].Rows[1][i].ToString().Trim();
                            continue;
                        }
                        if (dt[0].Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt[0].Rows[1][i].ToString().Trim()))
                        {
                            highSpeedStrechDataDetail[j].Direction = dt[0].Rows[1][i].ToString().Trim();
                            continue;
                        }
                    }
                    //第二部分导入
                    for (int i = 0; i < 8; i++)
                    {
                        highSpeedStrechDataDetail[j].InsertOrder = detailInsertOrder;
                        if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayc[0]))
                        {
                            highSpeedStrechDataDetail[j].TestTarget = TransToDecimal(dt[0].Rows[j + 3][i].ToString().Trim());
                            continue;
                        }
                        if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayc[1]))
                        {
                            highSpeedStrechDataDetail[j].SampleCode = dt[0].Rows[j + 3][i].ToString().Trim();
                            continue;
                        }

                        if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayc[2]))
                        {
                            if(!string.IsNullOrEmpty(dt[0].Rows[j + 3][i].ToString().Trim()))
                            {
                                highSpeedStrechDataDetail[j].Thickness = TransToDecimal(dt[0].Rows[j + 3][i].ToString().Trim());
                            }
                            else
                            {
                                highSpeedStrechDataDetail[j].Thickness = null;
                            }
                            continue;
                        }

                        if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayc[3]))
                        {
                            if (!string.IsNullOrEmpty(dt[0].Rows[j + 3][i].ToString().Trim()))
                            {
                                highSpeedStrechDataDetail[j].GaugeDistance = TransToDecimal(dt[0].Rows[j + 3][i].ToString().Trim());
                            }
                            else
                            {
                                highSpeedStrechDataDetail[j].GaugeDistance = null;
                            }
                            continue;
                        }

                        if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayc[4]))
                        {
                            if (!string.IsNullOrEmpty(dt[0].Rows[j + 3][i].ToString().Trim()))
                            {
                                highSpeedStrechDataDetail[j].YieldStrength = TransToDecimal(dt[0].Rows[j + 3][i].ToString().Trim());
                            }
                            else
                            {
                                highSpeedStrechDataDetail[j].YieldStrength = null;
                            }
                            continue;
                        }

                        if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayc[5]))
                        {
                            if (!string.IsNullOrEmpty(dt[0].Rows[j + 3][i].ToString().Trim()))
                            {
                                highSpeedStrechDataDetail[j].TensileStrength = TransToDecimal(dt[0].Rows[j + 3][i].ToString().Trim());
                            }
                            else
                            {
                                highSpeedStrechDataDetail[j].TensileStrength = null;
                            }
                            continue;
                        }

                        if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayc[6]))
                        {
                            if (!string.IsNullOrEmpty(dt[0].Rows[j + 3][i].ToString().Trim()))
                            {
                                highSpeedStrechDataDetail[j].Elongation = TransToDecimal(dt[0].Rows[j + 3][i].ToString().Trim());
                            }
                            else
                            {
                                highSpeedStrechDataDetail[j].Elongation = null;
                            }
                            continue;
                        }

                        if (!string.IsNullOrEmpty(dt[0].Rows[2][i].ToString().Trim()) && dt[0].Rows[2][i].ToString().Trim().Contains(arrayc[7]))
                        {
                            if (!string.IsNullOrEmpty(dt[0].Rows[j + 3][i].ToString().Trim()))
                            {
                                highSpeedStrechDataDetail[j].StretchingSpeed = TransToDecimal(dt[0].Rows[j + 3][i].ToString().Trim());
                            }
                            else
                            {
                                highSpeedStrechDataDetail[j].StretchingSpeed = null;
                            }
                            continue;
                        }
                    }
                    detailInsertOrder++;
                }

                //高速拉伸DetailStressStrainExtend导入，该表与detail同级别,另一类
                DataTable dt1 = new DataTable();
                for (int i = 0; i < sheetNumber; i++)
                {
                    if (dt[i].TableName.Equals("真塑性应变真应力"))
                    {
                        dt1 = dt[i];
                        if (!dt1.Rows[0][0].ToString().Trim().Contains("train"))
                        {
                            throw new ArgumentOutOfRangeException("模板使用错误");
                        }
                        break;
                    }
                }
                if (!dt1.TableName.Contains("真塑性应变真应力"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                int rows1 = dt1.Rows.Count;
                int columns1 = dt1.Columns.Count;

                //真塑性应变真应力子表Extend
                DataTable dt3 = new DataTable();
                for (int i = 0; i < sheetNumber; i++)
                {
                    if (dt[i].TableName.Equals("真塑性应变真应力1"))
                    {
                        dt3 = dt[i];
                        if (!dt3.Rows[0][0].ToString().Trim().Contains("train"))
                        {
                            throw new ArgumentOutOfRangeException("模板使用错误");
                        }
                        break;
                    }

                }
                int rows3 = dt3.Rows.Count;
                int columns3 = dt3.Columns.Count;
                if (!dt3.TableName.Contains("真塑性应变真应力1"))
                {
                    throw new ArgumentOutOfRangeException("真塑性应变真应力模板使用错误");
                }
                int mincolumns = columns1;
                if (columns3 < columns1)
                {
                    mincolumns= columns3;
                }
                int maxrows = rows3;
                if (rows3 < rows1)
                {
                    maxrows = rows1;
                }
                string realPlasticTestTarget = null;
                int order = 1; //标记插入顺序
                for (int i = 1; i < mincolumns; i++) 
                {
                    if(!string.IsNullOrEmpty(dt1.Rows[1][i].ToString().Trim())&& !string.IsNullOrEmpty(dt3.Rows[1][i].ToString().Trim())
                        &&dt1.Rows[1][i].ToString().Trim()!= dt1.Rows[1][i].ToString().Trim())
                    {
                        throw new ArgumentOutOfRangeException("真塑性应变真应力模板使用错误");
                    }
                    else
                    {
                        realPlasticTestTarget = dt1.Rows[1][i].ToString().Trim();
                    }
                    for (int j = 2; j < maxrows; j++)
                    {
                        
                        //这个sheet表数据对行数也从j-1开始，真塑性应变真应力子表extend表
                        HighSpeedStrechDataDetailStressStrainExtend highSpeedStrechDataDetailStressStrainExtend = new HighSpeedStrechDataDetailStressStrainExtend
                        {
                           MaterialTrialDataId = idmaterialtrialdata,
                           RealPlasticTestTarget = realPlasticTestTarget
                        };
                        bool signs = false;

                        if (j<rows1&&!string.IsNullOrEmpty(dt1.Rows[j][0].ToString().Trim()) && !string.IsNullOrEmpty(dt1.Rows[j][i].ToString().Trim()))
                        {
                            highSpeedStrechDataDetailStressStrainExtend.RealPlasticStrainHalf = TransToDecimal(dt1.Rows[j][0].ToString().Trim());
                            highSpeedStrechDataDetailStressStrainExtend.RealPlasticStressHalf = TransToDecimal(dt1.Rows[j][i].ToString().Trim());
                            signs = true;                           

                        }
                        if (j < rows3&&!string.IsNullOrEmpty(dt3.Rows[j][0].ToString().Trim()) && !string.IsNullOrEmpty(dt3.Rows[j][i].ToString().Trim()))
                        {
                            highSpeedStrechDataDetailStressStrainExtend.RealPlasticStrainExtend = TransToDecimal(dt3.Rows[j][0].ToString().Trim());
                            highSpeedStrechDataDetailStressStrainExtend.RealPlasticStressExtend = TransToDecimal(dt3.Rows[j][i].ToString().Trim());
                            signs = true;
                        }
                        if (signs)
                        {
                            highSpeedStrechDataDetailStressStrainExtend.InsertOrder = order;
                            await _highSpeedStrechDataDetailStressStrainExtendRepository.InsertAsync(highSpeedStrechDataDetailStressStrainExtend);
                            order++;
                        }
                    } 
                }


                //一个detail对应多个详情数据，从数组中遍历添加,高速拉伸DetailStressStrain导入 
                for (int i = 0; i < rows - 3; i++)
                {
                    await _highSpeedStrechDataDetailRepository.InsertAsync(highSpeedStrechDataDetail[i]);
                    var idhighSpeedStrechDataDetail = highSpeedStrechDataDetail[i].Id;
                    var testTarget = highSpeedStrechDataDetail[i].TestTarget;

                    //其他子表，寻找对应子sheet表
                    DataTable dt2 = new DataTable();
                    bool pd = true;

                    for (int j = 0; j < sheetNumber; j++)
                    {
                        if (dt[j].TableName.Contains(testTarget.ToString()))
                        {
                            dt2 = dt[j];
                            pd = false;
                            break;
                        }
                    }

                    //如果没有获得目标表报错
                    if (pd)
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                    int rows2 = dt2.Rows.Count;

                    //模板验证
                    if (!string.IsNullOrEmpty(dt2.Rows[1][0].ToString().Trim()) && !dt2.Rows[1][0].ToString().Trim().Contains("Engineering")
                        && !dt2.Rows[1][0].ToString().Trim().Contains("strain") && !string.IsNullOrEmpty(dt2.Rows[2][0].ToString().Trim()))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                    //从第3行开始为数据对，循环创建数据需求对象，添加一对多的数据
                    int insertOrder = 1;
                    for (int j = 3; j < rows2; j++)
                    {
                        HighSpeedStrechDataDetailStressStrain highSpeedStrechDataDetailStressStrain = new HighSpeedStrechDataDetailStressStrain
                        {
                            HighSpeedStrechDataDetailId = idhighSpeedStrechDataDetail
                        };
                        bool sign = false;
                        //(i % 3) * 4 取余×4计算列数，同一拉伸速率会重复测量3次对3取余
                        if (j < rows2 && !string.IsNullOrEmpty(dt2.Rows[j][0 + (i % 3) * 4].ToString().Trim()) && !string.IsNullOrEmpty(dt2.Rows[j][1 + (i % 3) * 4].ToString().Trim())
                            && !string.IsNullOrEmpty(dt2.Rows[j][2 + (i % 3) * 4].ToString().Trim()) && !string.IsNullOrEmpty(dt2.Rows[j][3 + (i % 3) * 4].ToString().Trim()))
                        {
                            highSpeedStrechDataDetailStressStrain.EngineeringStrain = TransToDecimal(dt2.Rows[j][0 + (i % 3) * 4].ToString().Trim());
                            highSpeedStrechDataDetailStressStrain.EngineeringStress = TransToDecimal(dt2.Rows[j][1 + (i % 3) * 4].ToString().Trim());
                            highSpeedStrechDataDetailStressStrain.RealStrain = TransToDecimal(dt2.Rows[j][2 + (i % 3) * 4].ToString().Trim());
                            highSpeedStrechDataDetailStressStrain.RealStress = TransToDecimal(dt2.Rows[j][3 + (i % 3) * 4].ToString().Trim());
                            sign = true;
                        }
                        if (sign)
                        {
                            highSpeedStrechDataDetailStressStrain.InsertOrder = insertOrder;
                            await _highSpeedStrechDataDetailStressStrainRepository.InsertAsync(highSpeedStrechDataDetailStressStrain);
                            insertOrder++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入禁用物质
        /// <summary>
        /// 材料文件自动导入禁用物质
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>        
        /// <returns></returns>
        public async Task<string> AutoAddProhibitedSubstance(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial );

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                for (int i = 8; i < columns; i++)
                {
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }


                //禁用物质Detail其他数据 
               List<string> arrayb = new List<string>();
                //模板验证
                if (!dt.Rows[2][0].ToString().Trim().Contains("编号"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                //把未知数目元素信息放入字符串列表中
                for(int i = 1; i <columns;i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()))
                    {
                        arrayb.Add(dt.Rows[2][i].ToString().Trim());
                    }
                    else
                    {
                        break;
                    }
                }
                int arraybCounts = arrayb.Count;
                for(int i = 0; i < arraybCounts; i++)
                {
                    for(int j = 4; j < rows; j++)
                    {
                        
                        ProhibitedSubstanceDataDetail prohibitedSubstanceDataDetail = new ProhibitedSubstanceDataDetail
                        {
                            MaterialTrialDataId = idmaterialtrialdata,
                            TestMethod=testMethod,
                            TestOrganization=testOrganization,
                            Standard=standard,
                            Dates=date,
                            DateEnds=dateEnd,
                            Equipment=equipment,
                            FileString=pictureName,
                            FileKey=documentName,
                            //做了去空行处理,模板保证此列无空字段。所以不做验证
                            SampleCode = dt.Rows[j][0].ToString().Trim()

                        };
                        if (!string.IsNullOrEmpty(dt.Rows[3][i + 1].ToString().Trim()))
                        {
                            prohibitedSubstanceDataDetail.Requirement = dt.Rows[3][i + 1].ToString().Trim();
                        }
                        //空字段后下一行对应可能不为空，所以不用break
                        if (!string.IsNullOrEmpty(dt.Rows[j][i + 1].ToString().Trim()))
                        {
                            prohibitedSubstanceDataDetail.Element = arrayb[i];
                            prohibitedSubstanceDataDetail.ContentRatio =TransToDecimal( dt.Rows[j][i + 1].ToString().Trim());
                            await _prohibitedSubstanceDataDetailRepository.InsertAsync(prohibitedSubstanceDataDetail);
                            //Thread.Sleep(100);
                        }

                    }
                }            
            
             

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入化学成分
        /// <summary>
        /// 材料文件自动导入化学成分
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>        
        /// <returns></returns>
        public async Task<string> AutoAddChemicalElement(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);

                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;

                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构","执行标准", "设备" ,"试验方法"};
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                for (int i = 8; i <columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //试验方法
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }

                //化学成分Detail其他数据 
                List<string> arrayb = new List<string>();
                //模板验证
                if (!dt.Rows[2][0].ToString().Trim().Contains("编号")&& !dt.Rows[3][0].ToString().Trim().Contains("要求值") && dt.Rows[4][0].ToString().Trim().Contains("要求值"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                //把未知数目元素信息放入字符串列表中
                for (int i = 1; i < columns; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()))
                    {
                        arrayb.Add(dt.Rows[2][i].ToString().Trim());
                    }
                    else
                    {
                        break;
                    }
                }
                int arraybCounts = arrayb.Count;
                int order = 1;
                for (int i = 0; i < arraybCounts; i++)
                {
                    for (int j = 4; j < rows; j++)
                    {
                        ChemicalElementDataDetail chemicalElementDataDetail = new ChemicalElementDataDetail
                        {
                            MaterialTrialDataId = idmaterialtrialdata,
                            TestOrganization=testOrganization,
                            TestMethod=testMethod,
                            Standard = standard,
                            Dates=date,
                            DateEnds=dateEnd,
                            Equipment = equipment,
                            //做了去空行处理,模板保证此列无空字段。所以不做验证
                            SampleCode = dt.Rows[j][0].ToString().Trim(),
                            FileString=pictureName,
                            FileKey=documentName
                        };
                        if(!string.IsNullOrEmpty(dt.Rows[3][i + 1].ToString().Trim()))
                        {
                            chemicalElementDataDetail.Requirement= dt.Rows[3][i + 1].ToString().Trim();
                        }
                       
                        //空字段后下一行对应可能不为空，所以不用break
                        if (!string.IsNullOrEmpty(dt.Rows[j][i + 1].ToString().Trim()))
                        {
                            chemicalElementDataDetail.Element = arrayb[i];
                            chemicalElementDataDetail.ContentRatio = TransToDecimal(dt.Rows[j][i + 1].ToString().Trim());
                            chemicalElementDataDetail.InsertOrder = order;
                            await _chemicalElementDataDetailRepository.InsertAsync(chemicalElementDataDetail);
                            order++;
                        }
                    }
                }
                return "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入表面性能
        /// <summary>
        /// 材料文件自动导入表面性能
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>

        /// <returns></returns>
        public async Task<string> AutoAddSurfaceProperty(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };


                //表面性能Detail导入  

                SurfacePropertyDataDetail surfacePropertyDataDetail = new SurfacePropertyDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                     Dates=date,
                     DateEnds=dateEnd,
                   FileString=pictureName,
                   FileKey=documentName

                };


                for (int i = 8; i < columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                   
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                await _surfacePropertyDataDetailRepository.InsertAsync(surfacePropertyDataDetail);
                //Thread.Sleep(100);
                var idsurfacePropertyDataDetail = surfacePropertyDataDetail.Id;

                //子表1导入,与模板验证
                string[] arrayb = { "面积", "初始重量", "试验后重量" , "膜重" };
                for (int i = 0; i < 4; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[3][i].ToString().Trim()) || !dt.Rows[3][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

              
                for (int i = 4; i < 7; i++)
                {
                    bool sign = false;
                    SurfacePropertyCoatingWeight surfacePropertyCoatingWeight = new SurfacePropertyCoatingWeight
                    {
                        SurfacePropertyDataDetailId = idsurfacePropertyDataDetail
                    };                  
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight .Area= TransToDecimal(dt.Rows[i][0].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight.OriginalWeight= TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight.AfterWeight = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight.MembraneWeight = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }

                    if (sign)
                    {
                        await _surfacePropertyCoatingWeightRepository.InsertAsync(surfacePropertyCoatingWeight);
                        //Thread.Sleep(100);
                    }
                }
                //子表2导入,与模板验证
                string[] arrayc = { "镀层粗糙度", "RP" };
              
                if (string.IsNullOrEmpty(dt.Rows[7][0].ToString().Trim()) || !dt.Rows[7][0].ToString().Trim().Contains(arrayc[0])
                || string.IsNullOrEmpty(dt.Rows[8][2].ToString().Trim()) || !dt.Rows[8][2].ToString().Trim().Contains(arrayc[1]))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }

                int order = 1;
                for (int i = 9; i < rows; i++)
                {
                    bool sign = false;
                    SurfacePropertyRoughness surfacePropertyRoughness = new SurfacePropertyRoughness
                    {
                        SurfacePropertyDataDetailId = idsurfacePropertyDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        surfacePropertyRoughness.RaOne = TransToDecimal(dt.Rows[i][0].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        surfacePropertyRoughness.RaTwo= TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        surfacePropertyRoughness.RPCOne = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        surfacePropertyRoughness.RPCTwo = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }

                    if (sign)
                    {
                        surfacePropertyRoughness.InsertOrder = order;
                        await _surfacePropertyRoughnessRepository.InsertAsync(surfacePropertyRoughness);
                        order++;
                    }
                }
                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入表面性能邯钢
        /// <summary>
        /// 材料文件自动导入表面性能邯钢
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddSurfaceProperty2(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法", "表面性能试验项目" , "表面质量等级" };


                //表面性能Detail导入  

                SurfacePropertyDataDetail surfacePropertyDataDetail = new SurfacePropertyDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                    Dates=date,
                    DateEnds=dateEnd,
                    FileString=pictureName,
                    FileKey=documentName
                };

                for (int i =8; i < columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //试验方法
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.TestItem = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[5]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        surfacePropertyDataDetail.SurfaceQualityGrade = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                await _surfacePropertyDataDetailRepository.InsertAsync(surfacePropertyDataDetail);
                //Thread.Sleep(100);
                var idsurfacePropertyDataDetail = surfacePropertyDataDetail.Id;

                //子表1导入,与模板验证
                string[] arrayb = { "面积", "初始重量", "试验后重量", "膜重", "重量要求" };
                for (int i = 0; i < 5; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[3][i].ToString().Trim()) || !dt.Rows[3][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }


                for (int i = 4; i < 7; i++)

                {
                    bool sign = false;
                    SurfacePropertyCoatingWeight surfacePropertyCoatingWeight = new SurfacePropertyCoatingWeight
                    {
                        SurfacePropertyDataDetailId = idsurfacePropertyDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight.Area = TransToDecimal(dt.Rows[i][0].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight.OriginalWeight = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight.AfterWeight = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight.MembraneWeight = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        surfacePropertyCoatingWeight.WeightRequirement = dt.Rows[i][4].ToString().Trim();
                        sign = true;
                    }

                    if (sign)
                    {
                        await _surfacePropertyCoatingWeightRepository.InsertAsync(surfacePropertyCoatingWeight);
                        //Thread.Sleep(100);
                    }
                }
                //子表2导入,与模板验证
                string[] arrayc = { "要求", "粗糙度","峰值密度" };

                if (string.IsNullOrEmpty(dt.Rows[7][0].ToString().Trim()) || !dt.Rows[7][0].ToString().Trim().Contains(arrayc[0])
                     || string.IsNullOrEmpty(dt.Rows[11][1].ToString().Trim()) || !dt.Rows[11][1].ToString().Trim().Contains(arrayc[1])
                || string.IsNullOrEmpty(dt.Rows[12][1].ToString().Trim()) || !dt.Rows[12][1].ToString().Trim().Contains(arrayc[2])
                 || string.IsNullOrEmpty(dt.Rows[7][2].ToString().Trim()) || string.IsNullOrEmpty(dt.Rows[7][5].ToString().Trim())
                 || string.IsNullOrEmpty(dt.Rows[7][8].ToString().Trim()))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                //特殊字段单独处理
                string position = null;
                string raRequirement = null;
                if (!string.IsNullOrEmpty(dt.Rows[8][2].ToString().Trim()))
                {
                    raRequirement = dt.Rows[8][2].ToString().Trim();
                }
                for (int j = 2; j < 11; j++)
                {                    
                   
                        bool sign = false;
                        SurfacePropertyRoughnessAndPeakDensity surfacePropertyRoughnessAndPeakDensity = new SurfacePropertyRoughnessAndPeakDensity
                        {
                            SurfacePropertyDataDetailId = idsurfacePropertyDataDetail,
                            RaRequirement= raRequirement
                        };
                        if (!string.IsNullOrEmpty(dt.Rows[7][j].ToString().Trim()))
                        {
                            position = dt.Rows[7][j].ToString().Trim();
                            surfacePropertyRoughnessAndPeakDensity.Position  = position;                            
                        }
                        else
                        {
                            surfacePropertyRoughnessAndPeakDensity.Position = position;
                        }
                       
                        if (!string.IsNullOrEmpty(dt.Rows[9][j].ToString().Trim()))
                        {
                            surfacePropertyRoughnessAndPeakDensity.AboveRoughness = TransToDecimal(dt.Rows[9][j].ToString().Trim());
                            sign = true;
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[10][j].ToString().Trim()))
                        {
                            surfacePropertyRoughnessAndPeakDensity.AbovePeakDensity = TransToDecimal(dt.Rows[10][j].ToString().Trim());
                            sign = true;
                        }
                    if (!string.IsNullOrEmpty(dt.Rows[11][j].ToString().Trim()))
                    {
                        surfacePropertyRoughnessAndPeakDensity.BelowRoughness= TransToDecimal(dt.Rows[11][j].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[12][j].ToString().Trim()))
                    {
                        surfacePropertyRoughnessAndPeakDensity.BelowPeakDensity = TransToDecimal(dt.Rows[12][j].ToString().Trim());
                        sign = true;
                    }

                    if (sign)
                    {
                        await _surfacePropertyRoughnessAndPeakDensityRepository.InsertAsync(surfacePropertyRoughnessAndPeakDensity);
                    }

                }

                //子表3导入,与模板验证
                string[] arrayd = {  "距边部40", "距左边部1/4", "板宽1/2" };
                for (int i = 0; i < 3; i++)
                {
                    if ( !dt.Rows[15+i][0].ToString().Trim().Contains(arrayd[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }
                string sizeRequirement = null;
                if (!string.IsNullOrEmpty(dt.Rows[13][1].ToString().Trim()))
                {
                    sizeRequirement = dt.Rows[13][1].ToString().Trim();
                }

                for (int j = 1; j < 5; j++)

                {
                    bool sign = false;
                    SurfacePropertySizeTolerance surfacePropertySizeTolerance = new SurfacePropertySizeTolerance
                    {
                        SurfacePropertyDataDetailId = idsurfacePropertyDataDetail,
                        SizeRequirement=sizeRequirement
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[14][j].ToString().Trim()))
                    {
                        surfacePropertySizeTolerance.TestCode = dt.Rows[14][j].ToString().Trim();
                        
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[15][j].ToString().Trim()))
                    {
                        surfacePropertySizeTolerance.EdgeThickness1 = TransToDecimal(dt.Rows[15][j].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[16][j].ToString().Trim()))
                    {
                        surfacePropertySizeTolerance.EdgeThickness2 = TransToDecimal(dt.Rows[16][j].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[17][j].ToString().Trim()))
                    {
                        surfacePropertySizeTolerance.EdgeThickness3 = TransToDecimal(dt.Rows[17][j].ToString().Trim());
                        sign = true;
                    }
                    if (sign)
                    {
                        await _surfacePropertySizeToleranceRepository.InsertAsync(surfacePropertySizeTolerance);
                    }
                }
                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入烘烤硬化
        /// <summary>
        /// 材料文件自动导入烘烤硬化
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddBakeHardening(IFormFile input, string pictureName, string documentName)
        {
            try
            {
                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());

                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);

                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;

                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial );
                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };


                //烘烤硬化Detail导入  

                BakeHardeningDataDetail bakeHardeningDataDetail = new BakeHardeningDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                    Dates=date,
                    DateEnds=dateEnd,
                    FileString=pictureName,
                    FileKey=documentName

                };


                for (int i = 8; i < columns; i++)
                {
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        bakeHardeningDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        bakeHardeningDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        bakeHardeningDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        bakeHardeningDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                await _bakeHardeningDataDetailRepository.InsertAsync(bakeHardeningDataDetail);
                var idbakeHardeningDataDetail = bakeHardeningDataDetail.Id;

                //子表导入,与模板验证
                string[] arrayb = { "烘烤温度", "Rt", "Rp", "Rm" , "BH" };
                for (int i = 0; i < 5; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

                int order = 1;
                for (int i = 3; i < rows; i++)

                {
                    bool sign = false;
                    BakeHardeningDataDetailItem bakeHardeningDataDetailItem = new BakeHardeningDataDetailItem
                    {
                       BakeHardeningDataDetailId=idbakeHardeningDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        bakeHardeningDataDetailItem.TemperatureTimes = dt.Rows[i][0].ToString().Trim();
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        bakeHardeningDataDetailItem.Rt = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        bakeHardeningDataDetailItem .Rp= TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        bakeHardeningDataDetailItem.Rm = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        bakeHardeningDataDetailItem.BH2 = TransToDecimal(dt.Rows[i][4].ToString().Trim());
                        sign = true;
                    }

                    if (sign)
                    {
                        bakeHardeningDataDetailItem.InsertOrder = order;
                        await _bakeHardeningDataDetailItemRepository.InsertAsync(bakeHardeningDataDetailItem);
                        order++;
                    }
                }
            
                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入弯曲
        /// <summary>
        /// 材料文件自动导入弯曲
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>

        /// <returns></returns>
        public async Task<string> AutoAddBending(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                for (int i =8; i < columns; i++)
                {
              
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                //弯曲Detail导入  

               
               
                //表导入,与模板验证
                string[] arrayb = { "样件编号", "试样宽", "试样厚", "试样直径", "试样长度" , "跨距" , "抗弯强度" , "规定非比例弯曲强度", "弯曲弹性模量" };
                for (int i = 0; i < 9; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }


                for (int i = 3; i < rows; i++)

                {
                    bool sign = false;
                    BendingDataDetail bendingDataDetail = new BendingDataDetail
                    {
                        MaterialTrialDataId = idmaterialtrialdata,
                        TestMethod=testMethod,
                        TestOrganization=testOrganization,
                        Standard = standard,
                        Equipment=equipment,
                        Dates=date,
                        DateEnds=dateEnd,
                        FileString=pictureName,
                        FileKey=documentName
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        bendingDataDetail.SampleCode = dt.Rows[i][0].ToString().Trim();
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        bendingDataDetail.Width = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        bendingDataDetail.Thickness = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        bendingDataDetail.Diameter = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        bendingDataDetail.Length = TransToDecimal(dt.Rows[i][4].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                    {
                        bendingDataDetail.Span = TransToDecimal(dt.Rows[i][5].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][6].ToString().Trim()))
                    {
                        bendingDataDetail.BendingStrength = TransToDecimal(dt.Rows[i][6].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()))
                    {
                        bendingDataDetail.NonProportionalBendingStrenth = TransToDecimal(dt.Rows[i][7].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][8].ToString().Trim()))
                    {
                        bendingDataDetail.BendingOfElasticity = TransToDecimal(dt.Rows[i][8].ToString().Trim());
                        sign = true;
                    }

                    if (sign)
                    {
                        await _bendingDataDetailRepository.InsertAsync(bendingDataDetail);
                        //Thread.Sleep(100);
                    }
                }

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入压缩
        /// <summary>
        /// 材料文件自动导入压缩
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>

        /// <returns></returns>
        public async Task<string> AutoAddCompress(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                for (int i = 8; i < columns; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                //压缩Detail导入  



                //表导入,与模板验证
                string[] arrayb = { "样件编号", "试样宽", "试样厚", "试样直径", "试样长度", "抗压强度", "规定非比例压缩强度", "压缩弹性模量" };
                for (int i = 0; i < 8; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }


                for (int i = 3; i < rows; i++)

                {
                    bool sign = false;
                    CompressDataDetail compressDataDetail = new CompressDataDetail
                    {
                        MaterialTrialDataId = idmaterialtrialdata,
                        TestOrganization=testOrganization,
                        TestMethod=testMethod,
                        Standard = standard,
                        Dates=date,
                        DateEnds=dateEnd,
                        Equipment = equipment,
                        FileString=pictureName,
                        FileKey=documentName
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        compressDataDetail.SampleCode = dt.Rows[i][0].ToString().Trim();
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        compressDataDetail.Width = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        compressDataDetail.Thickness = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        compressDataDetail.Diameter = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        compressDataDetail.Length = TransToDecimal(dt.Rows[i][4].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                    {
                        compressDataDetail.CompressiveStrength = TransToDecimal(dt.Rows[i][5].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][6].ToString().Trim()))
                    {
                        compressDataDetail .NonProportionalCompressStrenth= TransToDecimal(dt.Rows[i][6].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()))
                    {
                        compressDataDetail.CompressOfElasticity = TransToDecimal(dt.Rows[i][7].ToString().Trim());
                        sign = true;
                    }
                  

                    if (sign)
                    {
                        await _compressDataDetailRepository.InsertAsync(compressDataDetail);
                        //Thread.Sleep(100);
                    }
                }

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入翻边
        /// <summary>
        /// 材料文件自动导入翻边
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddFlangingClasp(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial );

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法", "翻边等级" };
                FlangingClaspDataDetail flangingClaspDataDetail = new FlangingClaspDataDetail
                {
                MaterialTrialDataId=idmaterialtrialdata,
                Dates=date,
                DateEnds=dateEnd,
                FileString=pictureName,
                FileKey=documentName
                };

                for (int i = 8; i < columns; i++)
                {
                  
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        flangingClaspDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        flangingClaspDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        flangingClaspDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        flangingClaspDataDetail.TestMethod= dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //翻边等级
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[4]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        flangingClaspDataDetail.FlangingLevel = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                }
                await _flangingClaspDataDetailRepository.InsertAsync(flangingClaspDataDetail);
                //Thread.Sleep(100);



                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入FLD试验
        /// <summary>
        /// 材料文件自动导入FLD试验
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddFLD(IFormFile input, string pictureName, string documentName)
        {
            try
            {
                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);

                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;

                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };

                FLDDataDetail fLDDataDetail = new FLDDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                    Dates=date,
                    DateEnds=dateEnd,
                    FileString = pictureName,
                    FileKey=documentName
                };
                for (int i = 8; i < columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        fLDDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        fLDDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        fLDDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //试验方法
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        fLDDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }

                await _fLDDataDetailRepository.InsertAsync(fLDDataDetail);
                //Thread.Sleep(100);
                Guid idfLDDataDetail = fLDDataDetail.Id;

                //子表导入,与模板验证
                string[] arrayb = { "宽度", "次应变", "主应变" };
                for (int i = 0; i <3; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }

                int order = 1;
                for (int i = 3; i < rows; i++)

                {
                    bool sign = false;
                    FLDDataDetailItem fLDDataDetailItem = new FLDDataDetailItem
                    {
                        FLDDataDetailId=idfLDDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        fLDDataDetailItem.SpecimenWidth = TransToDecimal(dt.Rows[i][0].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        fLDDataDetailItem.SecondaryStrain = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        fLDDataDetailItem.MainStrain = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }                 
                    if (sign)
                    {
                        fLDDataDetailItem.InsertOrder = order;
                        await _fLDDataDetailItemRepository.InsertAsync(fLDDataDetailItem);
                        order++;
                    }
                }

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入二次加工脆化
        /// <summary>
        /// 材料文件自动导入二次加工脆化
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>        
        /// <returns></returns>
        public async Task<string> AutoAddSecondaryWorkingEmbrittlement(IFormFile input, string pictureName, string documentName)
        {
            try
            {
                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());

                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);
                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;

                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial );

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                SecondaryWorkingEmbrittlementDataDetail secondaryWorkingEmbrittlementDataDetail = new SecondaryWorkingEmbrittlementDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                    Dates = date,
                    DateEnds = dateEnd,
                    FileString = pictureName,
                    FileKey = documentName
                };
                for (int i = 8; i <columns; i++)
                {
                    //测试机构
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        secondaryWorkingEmbrittlementDataDetail.TestOrganization= dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        secondaryWorkingEmbrittlementDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        secondaryWorkingEmbrittlementDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //试验方法
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        secondaryWorkingEmbrittlementDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                await _secondaryWorkingEmbrittlementDataDetailRepository.InsertAsync(secondaryWorkingEmbrittlementDataDetail);
                //Thread.Sleep(100);
                Guid idsecondaryWorkingEmbrittlementDataDetail = secondaryWorkingEmbrittlementDataDetail.Id;

                //子表
                List<string> arrayb = new List<string>();
                //模板验证
                if (!dt.Rows[3][0].ToString().Trim().Contains("SWET")|| !dt.Rows[3][1].ToString().Trim().Contains("温度"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");

                }
                //SWET不会变
                string swet = null;
                if(!string.IsNullOrEmpty(dt.Rows[4][0].ToString().Trim()))
                 {
                    swet = dt.Rows[4][0].ToString().Trim();
                  }
                //把未知数目号杯信息放入字符串列表中
                for (int i = 2; i < columns; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[3][i].ToString().Trim()))
                    {
                        arrayb.Add(dt.Rows[3][i].ToString().Trim());
                    }
                    else
                    {
                        break;
                    }
                }

                int arraybCounts = arrayb.Count;
                int order = 1;
                for (int i = 0; i < arraybCounts; i++)
                {
                    for (int j = 4; j < rows; j++)
                    {
                        SecondaryWorkingEmbrittlementDataDetailItem secondaryWorkingEmbrittlementDataDetailItem = new SecondaryWorkingEmbrittlementDataDetailItem
                        {
                           SecondaryWorkingEmbrittlementDataDetailId=idsecondaryWorkingEmbrittlementDataDetail,
                            //swet不会变
                           Swet =swet
                        };
                        //空字段后下一行对应可能不为空，所以不用break
                        if (!string.IsNullOrEmpty(dt.Rows[j][i + 2].ToString().Trim()))
                        {
                            //温度不可能为空，不作验证
                            secondaryWorkingEmbrittlementDataDetailItem.Temperature = TransToDecimal(dt.Rows[j][1].ToString().Trim());
                            secondaryWorkingEmbrittlementDataDetailItem.SerialNumber = arrayb[i];
                            secondaryWorkingEmbrittlementDataDetailItem.ExpansionType=dt.Rows[j][i + 2].ToString().Trim();
                            secondaryWorkingEmbrittlementDataDetailItem.InsertOrder = order;
                            await _secondaryWorkingEmbrittlementDataDetailItemRepository.InsertAsync(secondaryWorkingEmbrittlementDataDetailItem);
                            order++;
                        }
                    }
                }
                return "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入胶结试验
        /// <summary>
        /// 材料文件自动导入胶结试验
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddCementing(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                for (int i = 8; i < columns; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                //胶结Detail导入  



                //表导入,与模板验证
                string[] arrayb = { "样件编号", "样品长度", "试样宽度", "胶结宽度", "剪切强度", "失效模式" };
                for (int i = 0; i < 6; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }


                for (int i = 3; i < rows; i++)

                {
                    bool sign = false;
                    CementingDataDetail cementingDataDetail = new CementingDataDetail
                    {
                        MaterialTrialDataId = idmaterialtrialdata,
                        TestOrganization=testOrganization,
                        TestMethod=testMethod,
                        Standard = standard,
                        Equipment = equipment,
                        Dates=date,
                        DateEnds=dateEnd,

                        FileString=pictureName,
                        FileKey=documentName
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        cementingDataDetail.SampleCode = dt.Rows[i][0].ToString().Trim();
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        cementingDataDetail.Length = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        cementingDataDetail.Width = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        cementingDataDetail.CementingWidth = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString().Trim()))
                    {
                        cementingDataDetail.MPA = TransToDecimal(dt.Rows[i][4].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                    {
                        cementingDataDetail.FailureMode = dt.Rows[i][5].ToString().Trim();
                        sign = true;
                    }
                   
                  

                    if (sign)
                    {
                        await _cementingDataDetailRepository.InsertAsync(cementingDataDetail);
                        //Thread.Sleep(100);
                    }
                }

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入金相
        /// <summary>
        /// 材料文件自动导入金相
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddMetallographic(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();

                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                for (int i = 8; i < columns; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                //金相Detail导入  



                //表导入,与模板验证
                string[] arrayb = { "金相组织", "非金属夹杂", "晶粒度", "脱碳层深度" };
                for (int i = 0; i < 4; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }


                for (int i = 3; i < rows; i++)

                {
                    bool sign = false;
                    MetallographicDataDetail metallographicDataDetail = new MetallographicDataDetail
                    {
                        MaterialTrialDataId = idmaterialtrialdata,
                        TestOrganization=testOrganization,
                        TestMethod=testMethod,
                        Standard = standard,
                        Equipment = equipment,
                        Dates=date,
                        DateEnds=dateEnd,
                        FileString = pictureName,
                        FileKey=documentName
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        metallographicDataDetail.Structure = dt.Rows[i][0].ToString().Trim();
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        metallographicDataDetail.NonMetallicInclusionLevel = dt.Rows[i][1].ToString().Trim();
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        metallographicDataDetail.GrainSize = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        metallographicDataDetail.DepthDecarburization = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                        sign = true;
                    }
                   

                    if (sign)
                    {
                        await _metallographicDataDetailRepository.InsertAsync(metallographicDataDetail);
                        //Thread.Sleep(100);
                    }
                }

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入抗凹
        /// <summary>
        /// 材料文件自动导入抗凹
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddDentResistance(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);



                dt = RemoveEmpty(dt);



                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                string testOrganization = null;
                string standard = null;
                string equipment = null;
                string testMethod = null;
                for (int i = 8; i < columns; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        testMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                //抗凹Detail导入  



                //表导入,与模板验证
                string[] arrayb = { "初始刚度", "可见凹痕载荷" };
                for (int i = 0; i < 2; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }


                for (int i = 3; i < rows; i++)

                {
                    bool sign = false;
                    DentResistanceDataDetail dentResistanceDataDetail = new DentResistanceDataDetail
                    {
                        MaterialTrialDataId = idmaterialtrialdata,
                        Standard = standard,
                        Equipment = equipment,
                        TestOrganization=testOrganization,
                        TestMethod=testMethod,
                        Dates=date,
                        DateEnds=date,
                        FileString = pictureName,
                        FileKey=documentName
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        dentResistanceDataDetail.OriginalRigidity =TransToDecimal( dt.Rows[i][0].ToString().Trim());
                        sign = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        dentResistanceDataDetail.VisibleDentLoad= TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign = true;
                    }                 

                    if (sign)
                    {
                        await _dentResistanceDataDetailRepository.InsertAsync(dentResistanceDataDetail);
                        //Thread.Sleep(100);
                    }
                }

                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料文件自动导入涂装性能
        /// <summary>
        /// 材料文件自动导入涂装性能
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pictureName"></param>
        /// <param name="documentName"></param>
        /// <returns></returns>
        public async Task<string> AutoAddPainting(IFormFile input, string pictureName, string documentName)
        {
            try
            {

                //创建Workbook对象
                Workbook wb = new Workbook();

                //加载Excel文档//@"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx"
                wb.LoadFromStream(input.OpenReadStream());


                //获取第一个工作表
                Worksheet sheet = wb.Worksheets[0];

                //var A=sheet.Range["c20"].Value2.ToString();
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                //放到DATATABLE中操作数据，设置为false，不把excel第一行定为列标题

                DataTable dt = sheet.ExportDataTable(range, false, false);

                dt = RemoveEmpty(dt);

                //释放资源
                wb.Dispose();
                //表0数据行数,列数
                int rows = dt.Rows.Count;
                int columns = dt.Columns.Count;


                //预先定义好实体结构
                var material = new Material();
                var materialTrial = new MaterialTrial();
                //返回试验材料id
                Guid idmaterialtrialdata = await AutoAddCommon(dt, material, materialTrial);

                //材料试验detail表基本信息字段数组
                string[] arraya0 = { "检测开始日期", "检测结束日期" };
                DateTime? date = null;
                DateTime? dateEnd = null;
                for (int i = 4; i < 6; i++)
                {

                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        date = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya0[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        dateEnd = TransToDate(dt.Rows[1][i].ToString().Trim());
                        continue;
                    }
                }
                string[] arraya = { "测试机构", "执行标准", "设备", "试验方法" };
                PaintingDataDetail paintingDataDetail = new PaintingDataDetail
                {
                    MaterialTrialDataId = idmaterialtrialdata,
                    Dates=date,
                    DateEnds=dateEnd,
                    FileString = pictureName,
                    FileKey=documentName
                };

                for (int i = 8; i < columns; i++)
                {
                   
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[0]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        paintingDataDetail.TestOrganization = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //执行标准
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[1]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        paintingDataDetail.Standard = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                    //设备
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[2]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        paintingDataDetail.Equipment = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
              
                    if (dt.Rows[0][i].ToString().Trim().Contains(arraya[3]) && !string.IsNullOrEmpty(dt.Rows[1][i].ToString().Trim()))
                    {
                        paintingDataDetail.TestMethod = dt.Rows[1][i].ToString().Trim();
                        continue;
                    }
                }
                await _paintingDataDetailRepository.InsertAsync(paintingDataDetail);
                Guid idpaintingDataDetail = paintingDataDetail.Id;
                //磷化膜子表
                string[] arrayb = { "磷化膜结晶尺寸", "磷化膜覆盖率" };
                for (int i = 0; i < 2; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[2][i].ToString().Trim()) || !dt.Rows[2][i].ToString().Trim().Contains(arrayb[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }
                bool sign0 = false;
                PaintingDataDetailPhosphatingItem paintingDataDetailPhosphatingItem = new PaintingDataDetailPhosphatingItem
                {
                    PaintingDataDetailId=idpaintingDataDetail
                };
               if(!string.IsNullOrEmpty(dt.Rows[3][0].ToString().Trim()) )
                {
                    paintingDataDetailPhosphatingItem.SizeText = dt.Rows[3][0].ToString().Trim();
                    sign0 = true;
                }
                if ( !string.IsNullOrEmpty(dt.Rows[3][1].ToString().Trim()))
                {
                    paintingDataDetailPhosphatingItem.CoverRatio =TransToDecimal(dt.Rows[3][1].ToString().Trim());
                    sign0 = true;
                }
                if (sign0)
                {
                    await _paintingDataDetailPhosphatingItemRepository.InsertAsync(paintingDataDetailPhosphatingItem);
                }


                //电泳漆膜硬度子表               
                if (string.IsNullOrEmpty(dt.Rows[4][0].ToString().Trim()) || !dt.Rows[4][0].ToString().Trim().Contains("电泳漆膜"))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                //固定3个
                int order = 1;
                for (int i = 0; i < 3; i++)
                {
                    PaintingDataDetailHardnessItem paintingDataDetailHardnessItem = new PaintingDataDetailHardnessItem
                    {
                        PaintingDataDetailId = idpaintingDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[5][i].ToString().Trim()))
                    {
                        paintingDataDetailHardnessItem.PointHardness = dt.Rows[5][i].ToString().Trim();
                        paintingDataDetailHardnessItem.InsertOrder = order;
                        await _paintingDataDetailHardnessItemRepository.InsertAsync(paintingDataDetailHardnessItem);
                        order++;
                    }
                }
               
                //抗石击性能子表               
                if (string.IsNullOrEmpty(dt.Rows[6][0].ToString().Trim()) || !dt.Rows[6][0].ToString().Trim().Contains("抗石击"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                //固定3个
                order = 1;
                for (int i = 0; i < 3; i++)
                {
                    PaintingDataDetailHitResistanceItem paintingDataDetailHitResistanceItem = new PaintingDataDetailHitResistanceItem
                    {
                        PaintingDataDetailId = idpaintingDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[7][i].ToString().Trim()))
                    {
                        paintingDataDetailHitResistanceItem.PointStrength = TransToDecimal(dt.Rows[7][i].ToString().Trim());
                        paintingDataDetailHitResistanceItem.InsertOrder = order;
                        await _paintingDataDetailHitResistanceItemRepository.InsertAsync(paintingDataDetailHitResistanceItem);
                        order++;
                    }
                }


                //附着力子表               
                if (string.IsNullOrEmpty(dt.Rows[8][0].ToString().Trim()) || !dt.Rows[8][0].ToString().Trim().Contains("附着力"))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                //固定3行3列
                //0
                order = 1;
                for(int i = 9; i < 12; i++) 
                {
                    PaintingDataDetailAdhesionItem paintingDataDetailAdhesionItem = new PaintingDataDetailAdhesionItem

                    {
                        PaintingDataDetailId = idpaintingDataDetail
                    };
                    bool sign1 = false;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        paintingDataDetailAdhesionItem.PointAdhesionOne = TransToDecimal(dt.Rows[i][0].ToString().Trim());
                        sign1 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        paintingDataDetailAdhesionItem.PointAdhesionTwo = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign1 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        paintingDataDetailAdhesionItem.PointAdhesionThree = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign1 = true;
                    }
                    if (sign1)
                    {
                        paintingDataDetailAdhesionItem.InsertOrder = order;
                        await _paintingDataDetailAdhesionItemRepository.InsertAsync(paintingDataDetailAdhesionItem);
                        order++;
                    }
                }

                //耐湿热子表               
                if (string.IsNullOrEmpty(dt.Rows[12][0].ToString().Trim()) || !dt.Rows[12][0].ToString().Trim().Contains("耐湿热"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                //固定3行3列
                order = 1;
                for (int i = 13; i < 16; i++)
                {
                    PaintingDataDetailDampHeatItem paintingDataDetailDampHeatItem = new PaintingDataDetailDampHeatItem

                    {
                        PaintingDataDetailId = idpaintingDataDetail
                    };
                    bool sign1 = false;
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        paintingDataDetailDampHeatItem.PointOne = TransToDecimal(dt.Rows[i][0].ToString().Trim());
                        sign1 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        paintingDataDetailDampHeatItem.PointTwo = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                        sign1 = true;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        paintingDataDetailDampHeatItem.PointThree = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                        sign1 = true;
                    }
                    if (sign1)
                    {
                        paintingDataDetailDampHeatItem.InsertOrder = order;
                        await _paintingDataDetailDampHeatItemRepository.InsertAsync(paintingDataDetailDampHeatItem);
                        order++;
                    }
                }


                //膜重子表
                if (string.IsNullOrEmpty(dt.Rows[16][0].ToString().Trim()) || !dt.Rows[16][0].ToString().Trim().Contains("膜重"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                string[] arrayc = { "面积", "初始重量", "试验后重量", "膜重" };
                for (int i = 0; i <4; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[17][i].ToString().Trim()) || !dt.Rows[17][i].ToString().Trim().Contains(arrayc[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }
                order = 1;
                for(int i = 18; i < rows; i++)
                {
                    if(string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim())&& string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim())
                        && string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()) && string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        break;
                    }
                    PaintingDataDetailMembraneWeightItem paintingDataDetailMembraneWeightItem = new PaintingDataDetailMembraneWeightItem
                    {
                        PaintingDataDetailId = idpaintingDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        paintingDataDetailMembraneWeightItem.Area = TransToDecimal(dt.Rows[i][0].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][1].ToString().Trim()))
                    {
                        paintingDataDetailMembraneWeightItem.OriginalWeight = TransToDecimal(dt.Rows[i][1].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString().Trim()))
                    {
                        paintingDataDetailMembraneWeightItem.AfterWeight = TransToDecimal(dt.Rows[i][2].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString().Trim()))
                    {
                        paintingDataDetailMembraneWeightItem.MembraneWeight = TransToDecimal(dt.Rows[i][3].ToString().Trim());
                    }
                    paintingDataDetailMembraneWeightItem.InsertOrder = order;
                    await _paintingDataDetailMembraneWeightItemRepository.InsertAsync(paintingDataDetailMembraneWeightItem);
                    order++;
                }

                //P比子表
                if (string.IsNullOrEmpty(dt.Rows[16][5].ToString().Trim()) || !dt.Rows[16][5].ToString().Trim().Contains("P比"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                string[] arrayd= { "Ip", "IH", "P比" };
                for (int i = 0; i < 3; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[17][i+5].ToString().Trim()) || !dt.Rows[17][i+5].ToString().Trim().Contains(arrayd[i]))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                }
                order = 1;
                for (int i = 18; i < rows; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()) && string.IsNullOrEmpty(dt.Rows[i][6].ToString().Trim())
                        && string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()))
                    {
                        break;
                    }
                    PaintingDataDetailPRatioItem paintingDataDetailPRatioItem = new PaintingDataDetailPRatioItem
                    {
                        PaintingDataDetailId = idpaintingDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][5].ToString().Trim()))
                    {
                        paintingDataDetailPRatioItem.Ip = TransToDecimal(dt.Rows[i][5].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][6].ToString().Trim()))
                    {
                        paintingDataDetailPRatioItem.IH = TransToDecimal(dt.Rows[i][6].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][7].ToString().Trim()))
                    {
                        paintingDataDetailPRatioItem.Ratio = TransToDecimal(dt.Rows[i][7].ToString().Trim());
                    }
                    paintingDataDetailPRatioItem.InsertOrder = order;
                    await _paintingDataDetailPRatioItemRepository.InsertAsync(paintingDataDetailPRatioItem);
                    order++;
                }

                //电泳漆膜厚度子表
                if (string.IsNullOrEmpty(dt.Rows[16][9].ToString().Trim()) || !dt.Rows[16][9].ToString().Trim().Contains("电泳漆膜厚度"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
                order = 1;
                for (int i = 17; i < rows; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][9].ToString().Trim()) && string.IsNullOrEmpty(dt.Rows[i][10].ToString().Trim())
                        && string.IsNullOrEmpty(dt.Rows[i][11].ToString().Trim()))
                    {
                        break;
                    }
                    PaintingDataDetailElectrophoreticItem paintingDataDetailElectrophoreticItem = new PaintingDataDetailElectrophoreticItem
                    {
                        PaintingDataDetailId = idpaintingDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][9].ToString().Trim()))
                    {
                        paintingDataDetailElectrophoreticItem.PointThickOne = TransToDecimal(dt.Rows[i][9].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][10].ToString().Trim()))
                    {
                        paintingDataDetailElectrophoreticItem.PointThickTwo= TransToDecimal(dt.Rows[i][10].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][11].ToString().Trim()))
                    {
                        paintingDataDetailElectrophoreticItem.PointThickThree = TransToDecimal(dt.Rows[i][11].ToString().Trim());
                    }
                    paintingDataDetailElectrophoreticItem.InsertOrder = order;
                    await _paintingDataDetailElectrophoreticItemRepository.InsertAsync(paintingDataDetailElectrophoreticItem);
                    order++;
                }

                //电泳漆膜粗糙度子表
                if (string.IsNullOrEmpty(dt.Rows[16][13].ToString().Trim()) || !dt.Rows[16][13].ToString().Trim().Contains("电泳漆膜粗糙度"))
                {
                    throw new ArgumentOutOfRangeException("模板使用错误");
                }
             
                if (string.IsNullOrEmpty(dt.Rows[17][13].ToString().Trim()) || !dt.Rows[17][13].ToString().Trim().Contains("Ra"))
                    {
                        throw new ArgumentOutOfRangeException("模板使用错误");
                    }
                order = 1;
                for (int i = 18; i < rows; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][13].ToString().Trim()) && string.IsNullOrEmpty(dt.Rows[i][14].ToString().Trim())
                        && string.IsNullOrEmpty(dt.Rows[i][15].ToString().Trim()) && string.IsNullOrEmpty(dt.Rows[i][16].ToString().Trim())
                        && string.IsNullOrEmpty(dt.Rows[i][17].ToString().Trim()) && string.IsNullOrEmpty(dt.Rows[i][18].ToString().Trim()))
                    {
                        break;
                    }
                    PaintingDataDetailRoughnessItem paintingDataDetailRoughnessItem = new PaintingDataDetailRoughnessItem
                    {
                        PaintingDataDetailId = idpaintingDataDetail
                    };
                    if (!string.IsNullOrEmpty(dt.Rows[i][13].ToString().Trim()))
                    {
                        paintingDataDetailRoughnessItem.RaOne = TransToDecimal(dt.Rows[i][13].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][14].ToString().Trim()))
                    {
                        paintingDataDetailRoughnessItem.RaTwo = TransToDecimal(dt.Rows[i][14].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][15].ToString().Trim()))
                    {
                        paintingDataDetailRoughnessItem.RaThree= TransToDecimal(dt.Rows[i][15].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][16].ToString().Trim()))
                    {
                        paintingDataDetailRoughnessItem.RzOne = TransToDecimal(dt.Rows[i][16].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][17].ToString().Trim()))
                    {
                        paintingDataDetailRoughnessItem.RzTwo = TransToDecimal(dt.Rows[i][17].ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][18].ToString().Trim()))
                    {
                        paintingDataDetailRoughnessItem.RzThree = TransToDecimal(dt.Rows[i][18].ToString().Trim());
                    }
                    paintingDataDetailRoughnessItem.InsertOrder = order;
                    await _paintingDataDetailRoughnessItemRepository.InsertAsync(paintingDataDetailRoughnessItem);
                    order++;
                }



                return "success";
            }

            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return Convert.ToString(ex);
            }
        }
        #endregion

        #region 材料的应用案例自动导出
        /// <summary>
        /// 材料的应用案例自动导出
        /// </summary>
        /// <param name="id"></param>

        /// <returns></returns>
        public string ApplicationCaseExport(Guid id)
        {
            try
            {

                //创建1个工作簿，相当于1个Excel文件
                Workbook workbook = new Workbook();

                //获取第一个sheet，进行操作，下标是从0开始
                Worksheet sheet = workbook.Worksheets[0];
                //查询对应材料
                 
                var material = _materialRepository
                            .AsNoTracking()
                            .Where(m => m.Id == id)
                            .OrderBy(p => p.CreationTime)
                            .ProjectTo<MaterialDto>(Configuration)
                            .FirstOrDefault();
                var applicationCases = _applicationCaseRepository
                                        .AsNoTracking()
                                        .Where(m => m.MaterialId == id)
                                        .OrderBy(p => p.CreationTime)
                                            .ToList();

                //单元格写入信息
                sheet.Range[1,1].Text = "材料牌号";
                sheet.Range[1, 2].Text = "卷号";
                sheet.Range[1, 3].Text = "型号规格(厚度mm)";
                sheet.Range[1, 4].Text = "生产厂家";
                sheet.Range[1, 5].Text = "材料类别";
                sheet.Range[1, 6].Text = "材料标准";       
              
                 

                sheet.Range[2, 1].Text =   material.Name ;
                
                sheet.Range[2, 2].Text =   material.ReelNumber.ToString();
                sheet.Range[2, 3].Text =  material.Model.ToString();
                sheet.Range[2, 4].Text = string.IsNullOrEmpty(material.ManufactoryName) ? "" : material.ManufactoryName;
                sheet.Range[2, 5].Text =  material.MaterialType.ToString();              
                sheet.Range[2, 6].Text = string.IsNullOrEmpty(material.MaterialStandard ) ? "" : material.MaterialStandard ;

                sheet.Range[4, 1].Text ="车型名称";
                sheet.Range[4, 2].Text ="简况";
                sheet.Range[4, 3].Text ="供货零件名称";
                sheet.Range[4, 4].Text ="要求";
                for (int i=0;i< applicationCases.Count();i++)
                {
                    sheet.Range[5+i, 1].Text =  string.IsNullOrEmpty(applicationCases[i].VehicleType ) ? "" : applicationCases[i].VehicleType ;
                    sheet.Range[5+i, 2].Text = string.IsNullOrEmpty(applicationCases[i].Breif ) ? "" : applicationCases[i].Breif ;
                    sheet.Range[5+i, 3].Text = string.IsNullOrEmpty(applicationCases[i].SuppliedPart ) ? "" : applicationCases[i].SuppliedPart ;
                    sheet.Range[5 + i, 4].Text = string.IsNullOrEmpty(applicationCases[i].Requirement ) ? "" : applicationCases[i].Requirement ;
                }



                //将Excel文件保存到指定文件,还可以指定Excel版本            

                workbook.SaveToFile("uploads\\documents\\应用案例.xls" );
                
                //释放资源
                workbook.Dispose();
                return "应用案例.xls";
                 
            }

            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}