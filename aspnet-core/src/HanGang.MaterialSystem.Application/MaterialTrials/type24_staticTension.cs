using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HanGang.MaterialSystem.MaterialTrials
{
    /// <summary>
    /// 静态拉伸k文件卡片
    /// </summary>
    public class type24_staticTension
    {

        /// <summary>
        /// 头部内容
        /// </summary>
        public string Title =
            "$# ---注释：邯钢汽车用钢数据信息化平台材料卡片k文件_Type24_静态拉伸---\n" +
            "\n" +
            "* KEYWORD\n" +
            "\n" +
            "$# ---注释：标题，下面“DC01”是标题，实际应为数据库中材料对应的材料牌号，格式为\n" +
            "$# 英文字母和数字，不能是中文---\n" +
            "*TITLE\n" +
            "$#                                                                         title\n";

        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName = "DC01";

        /// <summary>
        /// 中间内容
        /// </summary>
        public string Note =
            " \n" +
            " \n" +
            "$# ---#注释：下面内容为材料参数，需要填写的参数为mid（材料标号，初定为1001）、\n" +
            "$# ro（材料密度）、e（材料杨氏模量）、pr（材料泊松比）、lcss（曲线CURVE标号），\n" +
            "$# lcss为真实塑性应力应变曲线CURVE的标号（初定为2001），对应有应力应变数据，\n" +
            "$# 后面将对其进行定义。#---\n" +
            "*MAT_PIECEWISE_LINEAR_PLASTICITY_TITLE\n" +
            "MaterialTemplateType24\n" +
            "$#     mid        ro         e        pr      sigy      etan      fail      tdel\n";

        public string mid = "      1001";
        public string ro = "2.70000E-9";
        public string e = "   70000.0";
        public string pr = "      0.33";

        /// <summary>
        /// 第18、19行的内容
        /// </summary>
        public string Content1 =
            "       0.0       0.01.00000E21       0.0\n" +
            "" + "$#       c         p      lcss      lcsr        vp       lcf   \n" +
            "       0.0       0.0";

        /// <summary>
        /// 应力应变数据对编号
        /// </summary>
        public string ssCode = "      2001";

        public string Content2 =
            "         0       0.0         0\n" +
            "$#    eps1      eps2      eps3      eps4      eps5      eps6      eps7      eps8\n" +
            "       0.0       0.0       0.0       0.0       0.0       0.0       0.0       0.0\n" +
            "$#     es1       es2       es3       es4       es5       es6       es7       es8\n" +
            "       0.0       0.0       0.0       0.0       0.0       0.0       0.0       0.0\n" +
            "$# ---#注释：后面的内容为真实塑性应力应变曲线CURVE的定义。\n" +
            "$# 下面为真实塑性应力应变曲线CURVE，须填写的内容为lcid（CURVE曲线标号，初定为\n" +
            "$# 2001）、a1以及对应的o1（横坐标a1为应变，纵坐标o1为应力）#---\n" +
            "*DEFINE_CURVE_TITLE\n" +
            "stress-strain curve\n" +
            "$#    lcid      sidr       sfa       sfo      offa      offo    dattyp     lcint\n";

        public string Content3 =
            "         0       1.0       1.0       0.0       0.0         0         0\n" +
            "$#                a1                  o1  \n";

        /// <summary>
        /// 应力应变数据对
        /// </summary>
        public StringBuilder ssData = new StringBuilder();

        public string End = "*END";

        /// <summary>
        /// 将数据转化成10位右对齐数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetStandardData(string data)
        {
            if (data.Length > 10)
            {
                if (data.Contains("."))
                {
                    string[] dataArray = data.Split(".");
                    
                    if (dataArray[1].Contains("E"))

                    {
                        string[] dataArray2 = dataArray[1].Split( "E");
                        int n0 = 10 - dataArray[0].Length - dataArray2[1].Length - 2;
                        data = dataArray[0] + "." + dataArray[1].Substring(0, n0) + "E" + dataArray2[1];
                    }
                    else
                    {
                        int n0 = 10 - dataArray[0].Length - 1;
                        data = dataArray[0] + "." + dataArray[1].Substring(0, n0);
                    }

                }
            }
            else
            {
                int n = 10 - data.Length;
                for (int i = 0; i < n; i++)
                {
                    data = " " + data;
                }
            }
            return data;
        } 

        public JObject ReturnStandardValue(string KfileName)
        {
            string jsonText = "{kFileName:\"" + KfileName + "\"}";
            JObject jo = JObject.Parse(jsonText);
            return jo;
        }
    }
}
