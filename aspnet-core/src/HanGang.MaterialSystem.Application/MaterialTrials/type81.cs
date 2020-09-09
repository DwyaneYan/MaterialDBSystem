using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.MaterialTrials
{
    class type81
    {
        public string txt1_8 = 
            "$# ---注释：邯钢汽车用钢数据信息化平台材料卡片k文件_Type81---\n" +
            "\n" +
            "* KEYWORD\n" +
            "\n" +
            "$# ---注释：标题，下面“DC01”是标题，实际应为数据库中材料对应的材料牌号，格式为\n" +
            "$# 英文字母和数字，不能是中文---\n" +
            "*TITLE\n" +
            "$#                                                                         title\n";

        public string name = "DC01";

        public string txt10_17 = 
            "\n" +
            "\n" +
            "$# ---#注释：下面内容为材料参数，需要填写的参数为mid（材料标号，初定为1001）、\n" +
            "$# ro（材料密度）、e（材料杨氏模量）、pr（材料泊松比）、lcss（曲线CURVE标号）、\n" +
            "$# eppfr（断裂应变），lcss为真实塑性应力应变曲线CURVE的标号（初定为2001），\n" +
            "$# 对应有应力应变数据，后面将对其进行定义。#---\n" +
            "*MAT_PLASTICITY_WITH_DAMAGE_TITLE\n" +
            "MaterialTemplateType81\n" +
            "$#     mid        ro         e        pr      sigy      etan      eppf      tdel\n";

        public string mid = "1001";
        public string ro = "2.70000E-9";
        public string e = "70000.0";
        public string pr = "0.33";

        public string txt18_20 = 
            "       0.0       0.01.00000E12       0.0\n" +
            "$#       c         p      lcss      lcsr     eppfr        vp      lcdm    numint\n" +
            "       0.0       0.0      2001         0";

        public string eppfr = "0.4";

        public string txt20_32 = 
            "       0.0         0         0\n" +
            "$#    eps1      eps2      eps3      eps4      eps5      eps6      eps7      eps8\n" +
            "       0.0       0.0       0.0       0.0       0.0       0.0       0.0       0.0\n" +
            "$#     es1       es2       es3       es4       es5       es6       es7       es8\n" +
            "       0.0       0.0       0.0       0.0       0.0       0.0       0.0       0.0\n" +
            "$# ---#注释：后面的内容为真实塑性应力应变曲线CURVE的定义。\n" +
            "$# 下面为真实塑性应力应变曲线CURVE，须填写的内容为lcid（CURVE曲线标号，初定为\n" +
            "$# 2001）、a1以及对应的o1（横坐标a1为应变，纵坐标o1为应力）#---	   \n" +
            "*DEFINE_CURVE_TITLE\n" +
            "stress-strain curve\n" +
            "$#    lcid      sidr       sfa       sfo      offa      offo    dattyp     lcint\n" +
            "      2001         0       1.0       1.0       0.0       0.0         0         0\n" +
            "$#                a1                  o1  \n";

        public StringBuilder ssData = new StringBuilder();

        public string txt233 = "*END";

        public StringBuilder GetDataList(string name, string mid, string ro, string e, string pr, string eppfr, StringBuilder ssData)
        {
            StringBuilder DataList = new StringBuilder();
            DataList.Append(txt1_8);
            DataList.Append(name);
            DataList.Append(txt10_17);
            DataList.Append(mid);
            DataList.Append(ro);
            DataList.Append(e);
            DataList.Append(pr);
            DataList.Append(txt18_20);
            DataList.Append(eppfr);
            DataList.Append(txt20_32);
            DataList.Append(ssData);
            DataList.Append(txt233);
            return DataList;
        }
    }
}
