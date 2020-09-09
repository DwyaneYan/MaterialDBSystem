using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.MaterialTrials
{
    class type100
    {
        public string txt1_8 = 
            "$# ---注释：邯钢汽车用钢数据信息化平台材料卡片k文件_Type100---\n" +
            "\n" +
            "* KEYWORD\n" +
            "\n" +
            "$# ---注释：标题，下面“DC01”是标题，实际应为数据库中材料对应的材料牌号，格式为\n" +
            "$# 英文字母和数字，不能是中文---\n" +
            "*TITLE\n" +
            "$#                                                                         title\n";

        public string name = "DC01";

        public string txt10_15 =
            "\n" +
            "\n" +
            "$# ---#注释：下面内容为材料参数，需要填写的参数为mid（材料标号，初定为1001）、\n" +
            "$# ro（材料密度）、e（材料杨氏模量）、pr（材料泊松比）、sigy（屈服强度）、\n" +
            "$# eh（塑性硬化模量）、efail（焊点失效时的等效塑性应变）#---\n" +
            "*MAT_SPOTWELD_TITLE\n" +
            "MaterialTemplateType100\n" +
            "$#     mid        ro         e        pr      sigy        eh        dt     tfail\n";

        public string mid = "1001";
        public string ro = "2.70000E-9";
        public string e = "70000.0";
        public string pr = "0.33";
        public string sigy = "1000.0";
        public string eh = "100000.0";

        public string txt17_18 = "1.00000E-6       0.0\n$#   efail       nrr       nrs       nrt       mrr       mss       mtt        nf\n";

        public string efail = "0.086";

        public string txt19_20 = "       0.0       0.0       0.0       0.0       0.0       0.0       0.0\n* END";

        public StringBuilder GetDataList(string name,string mid, string ro, string e, string pr,string sigy,string eh, string efail)
        {
            StringBuilder DataList = new StringBuilder();
            DataList.Append(txt1_8);
            DataList.Append(name);
            DataList.Append(txt10_15);
            DataList.Append(mid);
            DataList.Append(ro);
            DataList.Append(e);
            DataList.Append(pr);
            DataList.Append(sigy);
            DataList.Append(eh);
            DataList.Append(txt17_18);
            DataList.Append(efail);
            DataList.Append(txt19_20);
            return DataList;
        }
    }
}
