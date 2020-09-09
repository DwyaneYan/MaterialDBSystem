using System;

namespace HanGang.MaterialSystem.MaterialTrialDatas.Dtos
{
    public class AddMaterialTrialDataDto 
    {
        //#region 关联材料试验

        /// <summary>
        /// 材料试验
        /// </summary>
        public Guid? MaterialTrialId { get; set; }

        ///// <summary>
        ///// 材料试验
        ///// </summary>
        //public virtual MaterialTrial MaterialTrial { get; set; }

        //#endregion

        //#region 理化性能试验数据明细

        ///// <summary>
        ///// 静态拉伸试验数据明细
        ///// </summary>
        //public virtual HashSet<StaticTensionDataDetail> StaticTensionDataDetails { get; set; } = new HashSet<StaticTensionDataDetail>();

        ///// <summary>
        ///// 弯曲试验数据明细
        ///// </summary>
        //public virtual HashSet<BendingDataDetail> BendingDataDetails { get; set; } = new HashSet<BendingDataDetail>();

        ///// <summary>
        ///// 压缩试验数据明细
        ///// </summary>
        //public virtual HashSet<CompressDataDetail> CompressDataDetails { get; set; } = new HashSet<CompressDataDetail>();

        ///// <summary>
        ///// 高速拉伸试验数据明细
        ///// </summary>
        //public virtual HashSet<HighSpeedStrechDataDetail> HighSpeedStrechDataDetails { get; set; } = new HashSet<HighSpeedStrechDataDetail>();

        ///// <summary>
        ///// 低周疲劳试验数据明细
        ///// </summary>
        //public virtual HashSet<LowCycleFatigueDataDetail> LowCycleFatigueDataDetails { get; set; } = new HashSet<LowCycleFatigueDataDetail>();

        ///// <summary>
        ///// 高周疲劳试验数据明细
        ///// </summary>
        //public virtual HashSet<HighCycleFatigueDataDetail> HighCycleFatigueDataDetails { get; set; } = new HashSet<HighCycleFatigueDataDetail>();

        ///// <summary>
        ///// 金相试验数据明细
        ///// </summary>
        //public virtual HashSet<MetallographicDataDetail> MetallographicDataDetails { get; set; } = new HashSet<MetallographicDataDetail>();

        ///// <summary>
        ///// 物理性能试验数据明细
        ///// </summary>
        //public virtual HashSet<PhysicalPerformanceDataDetail> PhysicalPerformanceDataDetails { get; set; } = new HashSet<PhysicalPerformanceDataDetail>();

        ///// <summary>
        ///// 化学成分试验数据明细
        ///// </summary>
        //public virtual HashSet<ChemicalElementDataDetail> ChemicalElementDataDetails { get; set; } = new HashSet<ChemicalElementDataDetail>();

        ///// <summary>
        ///// 禁用物质试验数据明细
        ///// </summary>
        //public virtual HashSet<ProhibitedSubstanceDataDetail> ProhibitedSubstanceDataDetails { get; set; } = new HashSet<ProhibitedSubstanceDataDetail>();

        ///// <summary>
        ///// 表面性能试验数据明细
        ///// </summary>
        //public virtual HashSet<SurfacePropertyDataDetail> SurfacePropertyDataDetails { get; set; } = new HashSet<SurfacePropertyDataDetail>();

        //#endregion

        //#region 工艺性能试验数据明细

        ///// <summary>
        ///// 抗凹性能试验数据明细
        ///// </summary>
        //public virtual HashSet<DentResistanceDataDetail> DentResistanceDataDetails { get; set; } = new HashSet<DentResistanceDataDetail>();

        ///// <summary>
        ///// 二次加工脆性试验数据明细
        ///// </summary>
        //public virtual HashSet<SecondaryWorkingEmbrittlementDataDetail> SecondaryWorkingEmbrittlementDataDetails { get; set; } = new HashSet<SecondaryWorkingEmbrittlementDataDetail>();

        ///// <summary>
        ///// 翻边扣合性能试验数据明细
        ///// </summary>
        //public virtual HashSet<FlangingClaspDataDetail> FlangingClaspDataDetails { get; set; } = new HashSet<FlangingClaspDataDetail>();

        ///// <summary>
        ///// 氢致延迟开裂性能试验数据明细
        ///// </summary>
        //public virtual HashSet<HydrogenInducedDelayedFractureDataDetail> HydrogenInducedDelayedFractureDataDetails { get; set; } = new HashSet<HydrogenInducedDelayedFractureDataDetail>();

        ///// <summary>
        ///// 焊接性能试验数据明细
        ///// </summary>
        //public virtual HashSet<WeldingDataDetail> WeldingDataDetails { get; set; } = new HashSet<WeldingDataDetail>();

        ///// <summary>
        ///// 胶接性能试验数据明细
        ///// </summary>
        //public virtual HashSet<CementingDataDetail> CementingDataDetails { get; set; } = new HashSet<CementingDataDetail>();

        ///// <summary>
        ///// 涂装性能试验数据明细
        ///// </summary>
        //public virtual HashSet<PaintingDataDetail> PaintingDataDetails { get; set; } = new HashSet<PaintingDataDetail>();

        ///// <summary>
        ///// 成型极限FLD试验数据明细
        ///// </summary>
        //public virtual HashSet<FLDDataDetail> FLDDataDetails { get; set; } = new HashSet<FLDDataDetail>();

        ///// <summary>
        ///// 成型极限FLD试验数据明细
        ///// </summary>
        //public virtual HashSet<ReboundDataDetail> ReboundDataDetails { get; set; } = new HashSet<ReboundDataDetail>();

        ///// <summary>
        ///// 烘烤硬化试验数据明细
        ///// </summary>
        //public virtual HashSet<BakeHardeningDataDetail> BakeHardeningDataDetails { get; set; } = new HashSet<BakeHardeningDataDetail>();

        //#endregion
    }
}