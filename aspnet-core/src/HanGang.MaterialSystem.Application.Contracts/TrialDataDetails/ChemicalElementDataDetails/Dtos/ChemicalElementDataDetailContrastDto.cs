using HanGang.MaterialSystem.TrialDataDetails;
using System;

namespace HanGang.MaterialSystem.ChemicalElementDataDetails.Dtos
{
    public class ChemicalElementDataDetailContrastDto
    {


       
        /// <summary>
        /// 关联材料试验
        /// </summary>
        public Guid? MaterialTrialDataId { get; set; }
        


        /// <summary>
        /// C元素含量
        /// </summary>
        public decimal? ContentRatioC { get; set; }
        /// <summary>
        /// Si元素含量
        /// </summary>
        public decimal? ContentRatioSi { get; set; }
        /// <summary>
        /// Mn元素含量
        /// </summary>
        public decimal? ContentRatioMn { get; set; }
        /// <summary>
        /// P元素含量
        /// </summary>
        public decimal? ContentRatioP { get; set; }
        /// <summary>
        /// S元素含量
        /// </summary>
        public decimal? ContentRatioS { get; set; }
        /// <summary>
        /// AlS元素含量
        /// </summary>
        public decimal? ContentRatioAlS { get; set; }
        /// <summary>
        /// Ti元素含量
        /// </summary>
        public decimal? ContentRatioTi { get; set; }
        /// <summary>
        /// N元素含量
        /// </summary>
        public decimal? ContentRatioN { get; set; }
        /// <summary>
        ///B元素含量
        /// </summary>
        public decimal? ContentRatioB { get; set; }



    }
}