using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.PaintingDataDetails.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.TrialDataDetails.PaintingDataDetails
{
    /// <summary>
    /// 涂装性能服务 
    /// </summary>
    public class PaintingDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<PaintingDataDetail, Guid> _paintingDataDetailRepository;
        private readonly IRepository<PaintingDataDetailAdhesionItem, Guid> _paintingDataDetailAdhesionItemRepository;
        private readonly IRepository<PaintingDataDetailDampHeatItem, Guid> _paintingDataDetailDampHeatItemRepository;
        private readonly IRepository<PaintingDataDetailElectrophoreticItem, Guid> _paintingDataDetailElectrophoreticItemRepository;
        private readonly IRepository<PaintingDataDetailHardnessItem, Guid> _paintingDataDetailHardnessItemRepository;
        private readonly IRepository<PaintingDataDetailHitResistanceItem, Guid> _paintingDataDetailHitResistanceItemRepository;
        private readonly IRepository<PaintingDataDetailMembraneWeightItem, Guid> _paintingDataDetailMembraneWeightItemRepository;
        private readonly IRepository<PaintingDataDetailPhosphatingItem, Guid> _paintingDataDetailPhosphatingItemRepository;
        private readonly IRepository<PaintingDataDetailPRatioItem, Guid> _paintingDataDetailPRatioItemRepository;
        private readonly IRepository<PaintingDataDetailRoughnessItem, Guid> _paintingDataDetailRoughnessItemRepository;

        public PaintingDataDetailAppService(
            IRepository<PaintingDataDetail, Guid> paintingDataDetailRepository,
            IRepository<PaintingDataDetailAdhesionItem, Guid> paintingDataDetailAdhesionItemRepository,
            IRepository<PaintingDataDetailDampHeatItem, Guid> paintingDataDetailDampHeatItemRepository,
            IRepository<PaintingDataDetailElectrophoreticItem, Guid> paintingDataDetailElectrophoreticItemRepository,
            IRepository<PaintingDataDetailHardnessItem, Guid> paintingDataDetailHardnessItemRepository,
            IRepository<PaintingDataDetailHitResistanceItem, Guid> paintingDataDetailHitResistanceItemRepository,
            IRepository<PaintingDataDetailMembraneWeightItem, Guid> paintingDataDetailMembraneWeightItemRepository,
            IRepository<PaintingDataDetailPhosphatingItem, Guid> PaintingDataDetailPhosphatingItemRepository,
            IRepository<PaintingDataDetailPRatioItem, Guid> paintingDataDetailPRatioItemRepository,
             IRepository<PaintingDataDetailRoughnessItem, Guid> paintingDataDetailRoughnessItemRepository
            )
        {
            _paintingDataDetailRepository = paintingDataDetailRepository;
            _paintingDataDetailAdhesionItemRepository = paintingDataDetailAdhesionItemRepository;
            _paintingDataDetailDampHeatItemRepository = paintingDataDetailDampHeatItemRepository;
            _paintingDataDetailElectrophoreticItemRepository = paintingDataDetailElectrophoreticItemRepository;
            _paintingDataDetailHardnessItemRepository = paintingDataDetailHardnessItemRepository;
            _paintingDataDetailHitResistanceItemRepository = paintingDataDetailHitResistanceItemRepository;
            _paintingDataDetailMembraneWeightItemRepository = paintingDataDetailMembraneWeightItemRepository;
            _paintingDataDetailPhosphatingItemRepository = PaintingDataDetailPhosphatingItemRepository;
            _paintingDataDetailPRatioItemRepository = paintingDataDetailPRatioItemRepository;
            _paintingDataDetailRoughnessItemRepository = paintingDataDetailRoughnessItemRepository;
        }

        /// <summary>
        /// 添加涂装性能数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetail(PaintingDataDetailDto input)
        {
            var paintingDataDetail = new PaintingDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
              
                Remark = input.Remark,
                #region 新增
                Equipment = input.Equipment,
                FileString = input.FileString,
               
                #endregion

            };
            await _paintingDataDetailRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        
        /// <summary>
        /// 添加涂装性能附着力数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailAdhesionItem(PaintingDataDetailAdhesionItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailAdhesionItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
                
                PointAdhesionOne = input.PointAdhesionOne,
                PointAdhesionTwo = input.PointAdhesionTwo,
                PointAdhesionThree = input.PointAdhesionThree,
                Remark = input.Remark,
                FileString=input.FileString

            };
            await _paintingDataDetailAdhesionItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        
        /// <summary>
        /// 添加涂装性能-耐湿热性能试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailDampHeatItem(PaintingDataDetailDampHeatItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailDampHeatItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
              
                PointOne = input.PointOne,
                PointTwo = input.PointTwo,
                PointThree = input.PointThree,
                Remark = input.Remark,
                FileString = input.FileString

            };
            await _paintingDataDetailDampHeatItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        
        /// <summary>
        /// 添加涂装性能-电泳漆膜厚度试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailElectrophoreticItem(PaintingDataDetailElectrophoreticItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailElectrophoreticItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
               
                PointThickOne = input.PointThickOne,
                PointThickTwo = input.PointThickTwo,
                PointThickThree = input.PointThickThree,
                Remark = input.Remark,

            };
            await _paintingDataDetailElectrophoreticItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        
        /// <summary>
        /// 添加涂装性能-电泳漆膜硬度试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailHardnessItem(PaintingDataDetailHardnessItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailHardnessItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
                PointHardness = input.PointHardness,
                Remark = input.Remark,

            };
            await _paintingDataDetailHardnessItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        
        /// <summary>
        /// 添加涂装性能-抗石击性能试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailHitResistanceItem(PaintingDataDetailHitResistanceItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailHitResistanceItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
                PointStrength = input.PointStrength,
                Remark = input.Remark,
                FileString = input.FileString

            };
            await _paintingDataDetailHitResistanceItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        
        /// <summary>
        /// 添加涂装性能-膜重试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailMembraneWeightItem(PaintingDataDetailMembraneWeightItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailMembraneWeightItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
                Area  = input.Area ,
                OriginalWeight = input.OriginalWeight,
                AfterWeight = input.AfterWeight,
                MembraneWeight = input.MembraneWeight,
                Remark = input.Remark,

            };
            await _paintingDataDetailMembraneWeightItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        
        /// <summary>
        /// 添加涂装性能-磷化膜试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailPhosphatingItem(PaintingDataDetailPhosphatingItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailPhosphatingItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
                SizeText = input.SizeText,
                CoverRatio = input.CoverRatio,
                
                Remark = input.Remark,
                FileString = input.FileString

            };
            await _paintingDataDetailPhosphatingItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        

        /// <summary>
        /// 添加涂装性能-P比试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailPRatioItem(PaintingDataDetailPRatioItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailPRatioItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
                Ip = input.Ip,
                IH = input.IH,
                Ratio = input.Ratio,
                Remark = input.Remark

            };
            await _paintingDataDetailPRatioItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
       
        /// <summary>
        /// 添加涂装性能-电泳漆膜粗糙度试验数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddPaintingDataDetailRoughnessItem(PaintingDataDetailRoughnessItemDto input)
        {
            var paintingDataDetail = new PaintingDataDetailRoughnessItem
            {
                PaintingDataDetailId = input.PaintingDataDetailId,
               
                RaOne = input.RaOne,
                RaTwo = input.RaTwo,
                RaThree = input.RaThree,
              
                RzOne = input.RzOne,
                RzTwo = input.RzTwo,
                RzThree = input.RzThree,
                
                Remark = input.Remark

            };
            await _paintingDataDetailRoughnessItemRepository.InsertAsync(paintingDataDetail);
            return paintingDataDetail.Id;
        }
        
    }
}