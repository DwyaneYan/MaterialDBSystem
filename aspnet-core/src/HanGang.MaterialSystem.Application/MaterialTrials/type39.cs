using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.MaterialTrials
{
    class type39
    {
        public string txt1_8 = 
            "$# ---注释：邯钢汽车用钢数据信息化平台材料卡片k文件_Type39---\n" +
            "\n" +
            "* KEYWORD\n" +
            "\n" +
            "$# ---注释：标题，下面“DC01”是标题，实际应为数据库中材料对应的材料牌号，格式为\n" +
            "$# 英文字母和数字，不能是中文---\n" +
            "*TITLE\n" +
            "$#                                                                         title\n";

        public string name = "DC01";

        public string txt10_19 =
            "\n" +
            "\n" +
            "$# ---#注释：下面内容为材料参数，需要填写的参数为mid（材料标号，初定为1001）、\n" +
            "$# ro（材料密度）、e（材料杨氏模量）、pr（材料泊松比）、r（各向异性硬化系数）、\n" +
            "$# hlcid（应力应变曲线CURVE标号，初定为2001）、lcfld（FLD曲线CURVE标号，\n" +
            "$# 初定为2002）;hlcid为真实塑性应力应变曲线CURVE的标号（初定为2001），\n" +
            "$# 对应有真实塑性应力应变数据；lcfld为成形极限图FLD曲线CURVE的标号（初定为2002），\n" +
            "$# 对应有主应变和次应变的数据；后面将分别对这两条曲线进行定义。#---\n" +
            "*MAT_FLD_TRANSVERSELY_ANISOTROPIC_TITLE\n" +
            "MaterialTemplateType39\n" +
            "$#     mid        ro         e        pr      sigy      etan         r     hlcid\n";

        public string mid = "1001";
        public string ro = "2.70000E-9";
        public string e = "70000.0";
        public string pr = "0.33";

        public string txt20 = "       0.0       0.0";

        public string r = "1.0";

        public string txt20_30 = 
            "      2001\n" +
            "$#   lcfld     \n" +
            "      2002\n" +
            "$# ---#注释：下面为真实塑性应力应变曲线CURVE，须填写的内容为lcid\n" +
            "$# （CURVE曲线标号，初定为2001）、a1以及对应的o1（横坐标a1为应变，纵坐标o1为\n" +
            "$# 应力）#---\n" +
            "*DEFINE_CURVE_TITLE\n" +
            "stress-strain curve\n" +
            "$#    lcid      sidr       sfa       sfo      offa      offo    dattyp     lcint\n" +
            "      2001         0       1.0       1.0       0.0       0.0         0         0\n" +
            "$#                a1                  o1  \n";

        public StringBuilder ssData = new StringBuilder();

        public string txt231_238 = 
            "$# ---#注释：下面为成形极限图FLD曲线CURVE，须填写的内容为lcid\n" +
            "$# （CURVE曲线标号，初定为2002）、a1以及对应的o1（横坐标a1为次应变，纵坐标o1为\n" +
            "$# 主应变）#---\n" +
            "*DEFINE_CURVE_TITLE\n" +
            "FLD curve\n" +
            "$#    lcid      sidr       sfa       sfo      offa      offo    dattyp     lcint\n" +
            "      2002         0       1.0       1.0       0.0       0.0         0         0\n" +
            "$#                a1                  o1  \n";

        public StringBuilder FLDdata = new StringBuilder();

        public string txt_249 = "*END";

        public StringBuilder GetDataList(string name,string mid, string ro, string e,string pr, string r, StringBuilder ssData, StringBuilder FLDdata)
        {
            StringBuilder DataList = new StringBuilder();
            DataList.Append(txt1_8);
            DataList.Append(name);
            DataList.Append(txt10_19);
            DataList.Append(mid);
            DataList.Append(ro);
            DataList.Append(e);
            DataList.Append(pr);
            DataList.Append(txt20);
            DataList.Append(r);
            DataList.Append(txt20_30);
            DataList.Append(ssData);
            DataList.Append(txt231_238);
            DataList.Append(FLDdata);
            DataList.Append(txt_249);
            return DataList;
        }

    }
}
