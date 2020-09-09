using HanGang.MaterialSystem.MaterialTrials.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos;
using HanGang.MaterialSystem.BendingDataDetails.Dtos;
using HanGang.MaterialSystem.CementingDataDetails.Dtos;
using HanGang.MaterialSystem.ChemicalElementDataDetails.Dtos;
using HanGang.MaterialSystem.CompressDataDetails.Dtos;
using HanGang.MaterialSystem.DentResistanceDataDetails.Dtos;
using HanGang.MaterialSystem.FlangingClaspDataDetails.Dtos;
using HanGang.MaterialSystem.FLDDataDetailDetails.Dtos;
using HanGang.MaterialSystem.HighCycleFatigueDataDetails.Dtos;
using HanGang.MaterialSystem.HighSpeedStrechDataDetails.Dtos;
using HanGang.MaterialSystem.HydrogenInducedDelayedFractureDataDetails.Dtos;
using HanGang.MaterialSystem.LowCycleFatigueDataDetails.Dtos;
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
using System.Collections.Generic;

namespace HanGang.MaterialSystem.MaterialTrials
{
    /// <summary>
    /// 材料服务接口
    /// </summary>
    public interface IMaterialTrialAppService
    {
        /// <summary>
        /// 根据材料id获取对应实验项目
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<TrialDto> GetTrialItemByMaterialId(Guid materialId);
        #region 获取理化性能试验项目数据
        /// <summary>
        /// 获取静态拉伸数据明细
        /// </summary>
        /// <param name="materialId"></param>

        public List<StaticTensionDataDetailDto> GetStaticTensionDataDetails(Guid materialId);
        /// <summary>
        /// 获取静态拉伸数据明细用于对比页面
        /// </summary>
        /// <param name="materialId"></param>

        public List<StaticTensionDataDetailDto> GetStaticTensionDataDetails2(Guid materialId);
        /// <summary>
        /// 获取静态拉伸应力应变
        /// </summary>
        /// <param name="materialId"></param>

        public List<StaticTensionDataDetailStressStrainDto> GetStaticTensionDataDetailStressStrains(Guid materialId);
        /// <summary>
        /// 获取弯曲数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<BendingDataDetailDto> GetBendingDataDetails(Guid materialId);
        /// <summary>
        /// 获取压缩数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<CompressDataDetailDto> GetCompressDataDetails(Guid materialId);
        /// <summary>
        /// 获取高速拉伸数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighSpeedStrechDataDetailDto> GetHighSpeedStrechDataDetails(Guid materialId);
        /// <summary>
        /// 获取高速拉伸应力应变数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighSpeedStrechDataDetailStressStrainDto> GetHighSpeedStrechDataDetailStressStrains(Guid materialId);
        /// <summary>
        /// 获取低周疲劳数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<LowCycleFatigueDataDetailDto> GetLowCycleFatigueDataDetails(Guid materialId);
        /// <summary>
        /// 获取低周疲劳项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<LowCycleFatigueDataDetailItemDto> GetLowCycleFatigueDataDetailItems(Guid materialId);
        /// <summary>
        /// 获取高周疲劳数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighCycleFatigueDataDetailDto> GetHighCycleFatigueDataDetails(Guid materialId);
        /// <summary>
        /// 获取高周疲劳项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HighCycleFatigueDataDetailItemDto> GetHighCycleFatigueDataDetailItems(Guid materialId);
        /// <summary>
        /// 获取金相数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<MetallographicDataDetailDto> GetMetallographicDataDetails(Guid materialId);
        /// <summary>
        /// 获取物理性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PhysicalPerformanceDataDetailDto> GetPhysicalPerformanceDataDetails(Guid materialId);
        /// <summary>
        /// 获取物理性能导热系数数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>

        public List<PhysicalPerformanceDataDetailThermalConductivityDto> GetPhysicalPerformanceDataDetailThermalConductivitys(Guid materialId);
        /// <summary>
        /// 获取物理性能热膨胀系数
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>

        public List<PhysicalPerformanceDataDetailThermalExpansionDto> GetPhysicalPerformanceDataDetailThermalExpansions(Guid materialId);
        /// <summary>
        /// 获取化学成分数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ChemicalElementDataDetailDto> GetChemicalElementDataDetails(Guid materialId);
        /// <summary>
        /// 获取禁用物质数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ProhibitedSubstanceDataDetailDto> GetProhibitedSubstanceDataDetails(Guid materialId);
        /// <summary>
        /// 获取表面性能试验数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SurfacePropertyDataDetailDto> GetSurfacePropertyDataDetails(Guid materialId);
        /// <summary>
        /// 获取表面性能镀层重量
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SurfacePropertyCoatingWeightDto> GetSurfacePropertyCoatingWeights(Guid materialId);
        /// <summary>
        /// 获取表面性能粗造度
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SurfacePropertyRoughnessDto> GetSurfacePropertyRoughnesss(Guid materialId);
        /// <summary>
        /// 寻找抗凹性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<DentResistanceDataDetailDto> GetDentResistanceDataDetails(Guid materialId);
        
        /// <summary>
        /// 寻找烘烤硬化数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<BakeHardeningDataDetailDto> GetBakeHardeningDataDetails(Guid materialId);
        /// <summary>
        /// 寻找烘烤硬化项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<BakeHardeningDataDetailItemDto> GetBakeHardeningDataDetailItems(Guid materialId);
        /// <summary>
        /// 寻找回弹性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ReboundDataDetailDto> GetReboundDataDetails(Guid materialId);
        /// <summary>
        /// 寻找回弹性能项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<ReboundDataDetailItemDto> GetReboundDataDetailItems(Guid materialId);
        /// <summary>
        /// 寻找成形极限数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<FLDDataDetailDto> GetFLDDataDetails(Guid materialId);
        /// <summary>
        /// 寻找成形极限项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<FLDDataDetailItemDto> GetFLDDataDetailItems(Guid materialId);
        #region 涂装性能
        /// <summary>
        /// 寻找涂装性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailDto> GetPaintingDataDetails(Guid materialId);
        /// <summary>
        /// 寻找涂装性能附着力数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailAdhesionItemDto> GetPaintingDataDetailAdhesionItems(Guid materialId);
        /// <summary>
        /// 寻找涂装性能-耐湿热性能试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailDampHeatItemDto> GetPaintingDataDetailDampHeatItems(Guid materialId);
        /// <summary>
        /// 寻找涂装性能-电泳漆膜厚度试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailElectrophoreticItemDto> GetPaintingDataDetailElectrophoreticItems(Guid materialId);
        /// <summary>
        /// 寻找涂装性能-电泳漆膜硬度试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailHardnessItemDto> GetPaintingDataDetailHardnessItems(Guid materialId);
        /// <summary>
        /// 寻找涂装性能-抗石击性能试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailHitResistanceItemDto> GetPaintingDataDetailHitResistanceItems(Guid materialId);
        /// <summary>
        /// 寻找涂装性能-膜重试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailMembraneWeightItemDto> GetPaintingDataDetailMembraneWeightItems(Guid materialId);
        /// <summary>
        /// 寻找涂装性能-磷化膜试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailPhosphatingItemDto> GetPaintingDataDetailPhosphatingItems(Guid materialId);
        /// <summary>
        /// 寻找涂装性能-P比试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailPRatioItemDto> GetPaintingDataDetailPRatioItems(Guid materialId);
        /// <summary>
        /// 寻找涂装性能-电泳漆膜粗糙度试验数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<PaintingDataDetailRoughnessItemDto> GetPaintingDataDetailRoughnessItems(Guid materialId);
        #endregion
        /// <summary>
        /// 寻找胶接性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<CementingDataDetailDto> GetCementingDataDetails(Guid materialId);
        /// <summary>
        /// 寻找焊接性能数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<WeldingDataDetailDto> GetWeldingDataDetails(Guid materialId);
        /// <summary>
        /// 寻找焊接性能项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<WeldingDataDetailItemDto> GetWeldingDataDetailItems(Guid materialId);
        /// <summary>
        /// 寻找氢致延迟开裂数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HydrogenInducedDelayedFractureDataDetailDto> GetHydrogenInducedDelayedFractureDataDetails(Guid materialId);
        /// <summary>
        /// 寻找氢致延迟开裂数据项目
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<HydrogenInducedDelayedFractureDataDetailItemDto> GetHydrogenInducedDelayedFractureDataDetailItems(Guid materialId);
        /// <summary>
        /// 寻找翻边扣合数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<FlangingClaspDataDetailDto> GetFlangingClaspDataDetails(Guid materialId);
        /// <summary>
        /// 寻找二次加工数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SecondaryWorkingEmbrittlementDataDetailDto> GetSecondaryWorkingEmbrittlementDataDetails(Guid materialId);
        /// <summary>
        /// 寻找二次加工项目数据
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<SecondaryWorkingEmbrittlementDataDetailItemDto> GetSecondaryWorkingEmbrittlementDataDetailItems(Guid materialId);
        #endregion


        /// <summary>
        /// 获取所有材料试验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<MaterialTrialDto>> GetMaterialTrials(GetMaterialTrialListInputDto input);


        /// <summary>
        /// 根据材料试验Id获取某个材料试验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<MaterialTrialDto> GetMaterialTrialById(Guid id);
        /// <summary>
        /// 添加材料试验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<Guid> AddMaterialTrial(AddMaterialTrialInputDto input);

        /// <summary>
        /// 更新某个材料试验信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<Guid> UpdateMaterialTrial(MaterialTrialDto input);

        /// <summary>
        /// 根据材料试验Id删除某个材料试验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task Delete(Guid id);
    }
}
