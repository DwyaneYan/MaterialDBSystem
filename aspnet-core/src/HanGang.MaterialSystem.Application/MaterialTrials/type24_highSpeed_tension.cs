using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.MaterialTrials
{
    public class type24_highSpeed_tension
    {
        public string content1_8 = "$# ---注释：邯钢汽车用钢数据信息化平台材料卡片k文件_Type24_高速拉伸---\n" +
            " \n" +
            "*KEYWORD\n" +
            " \n" +
            "$# ---注释：标题，下面“DC01”是标题，实际应为数据库中材料对应的材料牌号，格式为\n" +
            "$# 英文字母和数字，不能是中文---\n" +
            "*TITLE\n" +
            "$#                                                                         title\n";

        public string name;

        public string content10_17 =
            "\n" +
            "\n" +
            "$# ---#注释：下面内容为材料参数，需要填写的参数为mid（材料标号，初定为1001）、\n" +
            "$# ro（材料密度）、e（材料杨氏模量）、pr（材料泊松比）、lcss（表格TABLE标号），\n" +
            "$# lcss为表格TABLE的标号（初定为2001），该TABLE中有不同应变速率下的真实塑性应\n" +
            "$# 力应变曲线数据，对应多条真实塑性应力应变曲线CURVE，后面将对其进行定义。#---\n" +
            "*MAT_PIECEWISE_LINEAR_PLASTICITY_TITLE\n" +
            "MaterialTemplateType24\n" +
            "$#     mid        ro         e        pr      sigy      etan      fail      tdel\n";

        public string mid;
        public string ro = "2.70000E-9";
        public string e = "   70000.0";
        public string pr = "      0.33";

        public string content18_20 = 
            "       0.0       0.01.00000E21       0.0\n" +
            "$#       c         p      lcss      lcsr        vp       lcf   \n" +
            "       0.0       0.0";
       
        public string lcss;

        public string content20_31 = 
            "         0       0.0         0\n" +
            "$#    eps1      eps2      eps3      eps4      eps5      eps6      eps7      eps8\n" +
            "       0.0       0.0       0.0       0.0       0.0       0.0       0.0       0.0\n" +
            "$#     es1       es2       es3       es4       es5       es6       es7       es8\n" +
            "       0.0       0.0       0.0       0.0       0.0       0.0       0.0       0.0\n" +
            "\n\n" +
            "$# ---#注释：下面内容为表格TABLE的定义，此表格TABLE对应多条真实塑性应力应变曲线\n" +
            "$# CURVE，需填写的参数为tbid（表格标号，初定为2001）、value（应变速率）与对应的\n" +
            "$# lcid（真实塑性应力应变曲线CURVE标号，初定为3001-3008）#---\n" +
            "*DEFINE_TABLE_TITLE\n" +
            "stress-strain curves with different strain rate\n" +
            "$#    tbid       sfa      offa    \n";

        public string content33 = 
            "\n" +
            "$#             value      lcid    ";

        public StringBuilder value_lcid = new StringBuilder();

        public string speed = "";
        public string content42 =
            "$# ---#注释：后面的内容为";
        public string content42_L= 
            "条真实塑性应力应变曲线CURVE的定义。\n" ;

        public string content43 = "$# 下面这条为应变速率为";
        public string content43_44 =
            "/s的真实塑性应力应变曲线CURVE，须填写的内容为\n" +
            "$# lcid（CURVE曲线标号，初定为";
            
        public string content44_46 = 
            "）、a1以及对应的o1（横坐标a1为应变，纵坐\n" +
            "$# 标o1为应力）#---\n" +
            "*DEFINE_CURVE_TITLE\n";

        public string content47_48 =
            "/s strain rate\n" +
            "$#    lcid      sidr       sfa       sfo      offa      offo    dattyp     lcint\n";

        public string content49_50 = 
            "         0       1.0       1.0       0.0       0.0         0         0\n" +
            "$#                a1                  o1  \n";

        public StringBuilder ssdata = new StringBuilder();

        public string content151 = "$# 下面这条为应变速率为";
        public string content151_152 = "/s的真实塑性应力应变曲线CURVE，须填写的内容为\n$# lcid（CURVE曲线标号，初定为";
        public string content152_154 = "）、a1以及对应的o1（横坐标a1为应变，纵坐\n$# 标o1为应力）#---\n*DEFINE_CURVE_TITLE\n";
        public string content155_156 = "s-1 strain rate\n$#    lcid      sidr       sfa       sfo      offa      offo    dattyp     lcint\n";
        public string content157_158 = "         0       1.0       1.0       0.0       0.0         0         0\n$#                a1                  o1  \n";




        public string end = 
            "*END";
    }
}
