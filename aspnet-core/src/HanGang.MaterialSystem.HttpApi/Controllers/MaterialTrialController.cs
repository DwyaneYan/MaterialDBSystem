
using HanGang.MaterialSystem.MaterialTrials;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using HanGang.MaterialSystem.BendingDataDetails.Dtos;
using HanGang.MaterialSystem.LowCycleFatigueDataDetails.Dtos;
using HanGang.MaterialSystem.ChemicalElementDataDetails.Dtos;

namespace HanGang.MaterialSystem.Controllers
{
    [Route("api/hangang/contrast/[action]")]
    public class MaterialTrialController : MaterialSystemController
    {
        private IMaterialTrialAppService _materialTrialAppService;
        

        public MaterialTrialController(
            IMaterialTrialAppService materialTrialAppService            )
       
        {
            _materialTrialAppService = materialTrialAppService;
           
         }
        #region demo
        //public List<StaticTensionDataDetailDto> GetStaticTensionDataDetailsNum(List<Guid> ids)
        //{
        //   // List<StaticTensionDataDetailDto> project = new List<StaticTensionDataDetailDto>();
        //    try
        //    {
        //        var project = _materialTrialAppService.GetStaticTensionDataDetails(ids[0]);
        //        var projecr = _materialTrialAppService.GetStaticTensionDataDetails(ids[0]);
        //        var projecr1=project.Concat(projecr).ToList<StaticTensionDataDetailDto>();

        //        List<StaticTensionDataDetailDto> projecr2 = new List<StaticTensionDataDetailDto>();
        //        projecr2.Add(project[0]);
        //        decimal len = projecr1.Count();
        //        decimal sum=0 ;
        //        projecr1[0].YieldStrength = 10;
        //        foreach (var item in projecr1)
        //        {
        //            sum += (decimal)item.YieldStrength;
        //        }
        //        projecr1.Average(t => t.YieldStrength);
        //        foreach (var item in projecr2)
        //        {
        //            // item.YieldStrength = sum / len+1;
        //            //根据List对象集合中的某个属性进行求平均值
        //            item.YieldStrength=projecr1.Average(t => t.YieldStrength);
        //        }
        //        return projecr2;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion


        /// <summary>
        /// 对比页面根据(list(guid) 材料id)查询静态拉伸数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public List<StaticTensionDataDetailDto> GetStaticTensionDataDetailsNum(List<Guid> ids)
        {
           
            try
            {
                //存放查询一个id返回得到的数据数组
                List<StaticTensionDataDetailDto> project1 = new List<StaticTensionDataDetailDto>();
                //对查询返回得到的数据数组处理
                StaticTensionDataDetailDto project2 =new StaticTensionDataDetailDto();
                //处理后存放的位置，最后一起返回所有id对应的数据数组
                List<StaticTensionDataDetailDto> project3 = new List<StaticTensionDataDetailDto>();
                foreach (var item in ids)
                {
                    //查询一个materiaid返回的是一个数组,如果数组为空则在project3add一个空对象数组
                    
                    project1 = _materialTrialAppService.GetStaticTensionDataDetails2(item);
                    if (project1.Count != 0)
                    {
                        project2 =project1[0];
                        //返回两位数的小数
                        project2.YieldStrength =Math.Round(project1.Average(t => t.YieldStrength).GetValueOrDefault(),2);
                        project2.TensileStrength = Math.Round(project1.Average(t => t.TensileStrength).GetValueOrDefault(),2);
                        project2.StrainHardening = Math.Round(project1.Average(t => t.StrainHardening).GetValueOrDefault(),2);
                        project2.Elongation = Math.Round(project1.Average(t => t.Elongation).GetValueOrDefault(),2);
                        project2.PlasticStrainRatio = Math.Round(project1.Average(t => t.PlasticStrainRatio).GetValueOrDefault(),2);
                        project2.ModulusOfElasticity = Math.Round(project1.Average(t => t.ModulusOfElasticity).GetValueOrDefault(),2);
                        project2.PoissonRatio = Math.Round(project1.Average(t => t.PoissonRatio).GetValueOrDefault(),2);
                        project2.MaximumForce = Math.Round(project1.Average(t => t.MaximumForce).GetValueOrDefault(),2);
                        project2.BHValue = Math.Round(project1.Average(t => t.BHValue).GetValueOrDefault(), 2);
                        project2.IndenterDiameter = Math.Round(project1.Average(t => t.IndenterDiameter).GetValueOrDefault(), 2);
                        project2.VImpactTemperature = Math.Round(project1.Average(t => t.VImpactTemperature).GetValueOrDefault(), 2);
                        project2.VImpactEnergy = Math.Round(project1.Average(t => t.VImpactEnergy).GetValueOrDefault(), 2);

                    }
                    else
                    {
                        //需要对project2重新操作一次让它为空
                        project2 = new StaticTensionDataDetailDto(); 
                    }


                    project3.Add(project2);

                }           
                return project3;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 对比页面根据(list(guid) 材料id)查询低周疲劳数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public List<LowCycleFatigueDataDetailItemDto> LowCycleFatigueDataDetailItemsNum(List<Guid> ids)
        {

            try
            {
                //存放查询一个id返回得到的数据数组
                List<LowCycleFatigueDataDetailItemDto> project1 = new List<LowCycleFatigueDataDetailItemDto>();
                //对查询返回得到的数据数组处理
                LowCycleFatigueDataDetailItemDto project2 = new LowCycleFatigueDataDetailItemDto();
                //处理后存放的位置，最后一起返回所有id对应的数据数组
                List<LowCycleFatigueDataDetailItemDto> project3 = new List<LowCycleFatigueDataDetailItemDto>();
                foreach (var item in ids)
                {
                    //查询一个materiaid返回的是一个数组,如果数组为空则在project3add一个空对象数组

                    project1 = _materialTrialAppService.GetLowCycleFatigueDataDetailItems(item);
                    if (project1.Count != 0)
                    {
                        project2 = project1[0];
                        //返回两位数的小数
                        project2.TotalStrainAmplitude = Math.Round(project1.Average(t => t.TotalStrainAmplitude).GetValueOrDefault(), 6);
                        project2.PlasticStrainAmplitude = Math.Round(project1.Average(t => t.PlasticStrainAmplitude).GetValueOrDefault(), 6);
                        project2.ElasticStrainAmplitude = Math.Round(project1.Average(t => t.ElasticStrainAmplitude).GetValueOrDefault(), 6);
                        project2.FailureCycleTimes =(int) Math.Round(project1.Average(t => t.FailureCycleTimes).GetValueOrDefault(),0);
                        project2.CycleStressAmplitude = Math.Round(project1.Average(t => t.CycleStressAmplitude).GetValueOrDefault(), 3);
                        project2.TestFrequency = Math.Round(project1.Average(t => t.TestFrequency).GetValueOrDefault(), 0);
                        
                    }
                    else
                    {
                        //需要对project2重新操作一次让它为空
                        project2 = new LowCycleFatigueDataDetailItemDto();
                        
                    }


                    project3.Add(project2);

                }
                return project3;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 对比页面根据(list(guid) 材料id)查询化学成分数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ChemicalElementDataDetailContrastDto> ChemicalElementDataDetailsNum(List<Guid> ids)
        {

            try
            {
                //存放查询一个id返回得到的数据数组
                List< ChemicalElementDataDetailDto > project1 = new List<ChemicalElementDataDetailDto>();
               
                //处理后存放的位置，最后一起返回所有id对应的数据数组
                List<ChemicalElementDataDetailContrastDto> project3 = new List<ChemicalElementDataDetailContrastDto>();
                foreach (var item in ids)
                {
                    //查询一个materiaid返回的是一个数组,如果数组为空则在project3add一个空对象数组

                    project1 = _materialTrialAppService.GetChemicalElementDataDetails(item);
                    if (project1.Count != 0)
                    {
                        ////处理后暂时存放的位置
                        ChemicalElementDataDetailContrastDto project2 = new ChemicalElementDataDetailContrastDto { 
                        MaterialTrialDataId=project1[0].MaterialTrialDataId
                        };
                        //化学成分不同元素放到不同的数组，分别进行处理
                        List<ChemicalElementDataDetailDto> projectC = new List<ChemicalElementDataDetailDto>();
                        List<ChemicalElementDataDetailDto> projectSi = new List<ChemicalElementDataDetailDto>();
                        List<ChemicalElementDataDetailDto> projectMn = new List<ChemicalElementDataDetailDto>();
                        List<ChemicalElementDataDetailDto> projectP = new List<ChemicalElementDataDetailDto>();
                        List<ChemicalElementDataDetailDto> projectS = new List<ChemicalElementDataDetailDto>();
                        List<ChemicalElementDataDetailDto> projectAlS = new List<ChemicalElementDataDetailDto>();
                        List<ChemicalElementDataDetailDto> projectTi = new List<ChemicalElementDataDetailDto>();
                        List<ChemicalElementDataDetailDto> projectN = new List<ChemicalElementDataDetailDto>();
                        List<ChemicalElementDataDetailDto> projectB = new List<ChemicalElementDataDetailDto>();
                        for (int i = 0; i < project1.Count(); i++)
                        {
                           
                            if (project1[i].Element.ToLower().Equals("c"))
                            {
                                projectC.Add(project1[i]);
                            }
                            if (project1[i].Element.ToLower().Equals("si"))
                            {
                                projectSi.Add(project1[i]);
                            }
                            if (project1[i].Element.ToLower().Equals("mn"))
                            {
                                projectMn.Add(project1[i]);
                            }
                            if (project1[i].Element.ToLower().Equals("p"))
                            {
                                projectP.Add(project1[i]);
                            }
                            if (project1[i].Element.ToLower().Equals("s"))
                            {
                                projectS.Add(project1[i]);
                            }
                            if (project1[i].Element.ToLower().Equals("als"))
                            {
                                projectAlS.Add(project1[i]);
                            }
                            if (project1[i].Element.ToLower().Equals("ti"))
                            {
                                projectTi.Add(project1[i]);
                            }
                            if (project1[i].Element.ToLower().Equals("n"))
                            {
                                projectN.Add(project1[i]);
                            }
                            if (project1[i].Element.ToLower().Equals("b"))
                            {
                                projectB.Add(project1[i]);
                            }

                        }
                       if (projectC.Count() != 0)
                        {
                            project2.ContentRatioC = Math.Round(projectC.Average(t =>t.ContentRatio).GetValueOrDefault(), 5);
                        }
                        if (projectSi.Count() != 0)
                        {
                            project2.ContentRatioSi = Math.Round(projectSi.Average(t => t.ContentRatio).GetValueOrDefault(), 5);
                        }
                        if (projectMn.Count() != 0)
                        {
                            project2.ContentRatioMn = Math.Round(projectMn.Average(t => t.ContentRatio).GetValueOrDefault(), 5);
                        }
                        if (projectP.Count() != 0)
                        {
                            project2.ContentRatioP = Math.Round(projectP.Average(t => t.ContentRatio).GetValueOrDefault(), 5);
                        }
                        if (projectS.Count() != 0)
                        {
                            project2.ContentRatioS = Math.Round(projectS.Average(t => t.ContentRatio).GetValueOrDefault(), 5);
                        }
                        if (projectAlS.Count() != 0)
                        {
                            project2.ContentRatioAlS = Math.Round(projectAlS.Average(t => t.ContentRatio).GetValueOrDefault(), 5);
                        }
                        if (projectTi.Count() != 0)
                        {
                            project2.ContentRatioTi = Math.Round(projectTi.Average(t => t.ContentRatio).GetValueOrDefault(),5);
                        }
                        if (projectN.Count() != 0)
                        {
                            project2.ContentRatioN = Math.Round(projectN.Average(t => t.ContentRatio).GetValueOrDefault(), 5);
                        }
                        if (projectB.Count() != 0)
                        {
                            project2.ContentRatioB = Math.Round(projectB.Average(t => t.ContentRatio).GetValueOrDefault(), 5);
                        }

                        project3.Add(project2);
                    }
                    else
                    {
                        ChemicalElementDataDetailContrastDto project2 = new ChemicalElementDataDetailContrastDto();
                        project3.Add(project2);
                    }
                                                                     
                }
                return project3;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
