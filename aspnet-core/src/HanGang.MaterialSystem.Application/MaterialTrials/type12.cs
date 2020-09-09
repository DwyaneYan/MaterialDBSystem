using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.MaterialTrials
{
    class type12
    {
        public string txt1 = "$# ---注释：邯钢汽车用钢数据信息化平台材料卡片k文件_Type12---\n" +
            "\n" +
            "* KEYWORD\n" +
            "\n" +
            "$# ---注释：标题，下面“DC01”是标题，实际应为数据库中材料对应的材料牌号，格式为\n" +
            "$# 英文字母和数字，不能是中文---\n" +
            "*TITLE\n" +
            "$#                                                                         title\n";

        public string name = "DC01";

        public string txt2 = 
            "\n" +
            "\n" +
            "$# ---#注释：下面内容为材料参数，需要填写的参数为mid（材料标号，初定为1001）、\n" +
            "$# ro（材料密度）、g（切变模量）、sigy（屈服强度）、etan（塑性硬化模量）、\n" +
            "$# bulk（体积模量）。#---\n" +
            "*MAT_ISOTROPIC_ELASTIC_PLASTIC_TITLE\n" +
            "MaterialTemplateType12\n" +
            "$#     mid        ro         g      sigy      etan      bulk \n";

        public string mid = "      1001";
        public string ro = "2.70000E-9";
        public string g = "   26316.0";
        public string sigy = "  213.9591";
        public string etan = "   20000.0";
        public string bulk = "   68627.0";

        public string end = "\n*END";

        public StringBuilder GetDataList(string name, string mid, string ro, string g, string sigy, string etan, string bulk)
        {
            StringBuilder Datalist = new StringBuilder();
            Datalist.Append(txt1);
            Datalist.Append(name);
            Datalist.Append(txt2);
            Datalist.Append(mid);
            Datalist.Append(ro);
            Datalist.Append(g);
            Datalist.Append(sigy);
            Datalist.Append(etan);
            Datalist.Append(bulk);
            Datalist.Append(end);

            return Datalist;
        }

    }
}
