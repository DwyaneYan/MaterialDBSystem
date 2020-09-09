using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 涂装性能试验数据明细
    /// </summary>
    public class PaintingDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 涂装-磷化膜试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailPhosphatingItem> PaintingDataDetailPhosphatingItems { get; set; } = new HashSet<PaintingDataDetailPhosphatingItem>();

        /// <summary>
        /// 涂装-膜重试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailMembraneWeightItem> PaintingDataDetailMembraneWeightItems { get; set; } = new HashSet<PaintingDataDetailMembraneWeightItem>();

        /// <summary>
        /// 涂装-P比试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailPRatioItem> PaintingDataDetailPRatioItems { get; set; } = new HashSet<PaintingDataDetailPRatioItem>();

        /// <summary>
        /// 涂装-电泳漆膜厚度试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailElectrophoreticItem> PaintingDataDetailElectrophoreticItems { get; set; } = new HashSet<PaintingDataDetailElectrophoreticItem>();
        
        /// <summary>
        /// 涂装-电泳漆膜硬度试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailHardnessItem> PaintingDataDetailHardnessItems { get; set; } = new HashSet<PaintingDataDetailHardnessItem>();
        
        /// <summary>
        /// 涂装-电泳漆膜粗糙度试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailRoughnessItem> PaintingDataDetailRoughnessItems { get; set; } = new HashSet<PaintingDataDetailRoughnessItem>();
                
        /// <summary>
        /// 涂装-抗石击性能试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailHitResistanceItem> PaintingDataDetailHitResistanceItems { get; set; } = new HashSet<PaintingDataDetailHitResistanceItem>();
                
        /// <summary>
        /// 涂装-附着力试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailAdhesionItem> PaintingDataDetailAdhesionItems { get; set; } = new HashSet<PaintingDataDetailAdhesionItem>();                
        
        /// <summary>
        /// 涂装-耐湿热性能试验数据结果明细
        /// </summary>
        public virtual HashSet<PaintingDataDetailDampHeatItem> PaintingDataDetailDampHeatItems { get; set; } = new HashSet<PaintingDataDetailDampHeatItem>();

    }
}
