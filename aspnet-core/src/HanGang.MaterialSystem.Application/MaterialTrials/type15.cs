using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem.MaterialTrials
{
    class type15
    {
        public string txt1_8 = 
            "$# ---注释：邯钢汽车用钢数据信息化平台材料卡片k文件_Type15---\n" +
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
            "$# ro（材料密度）、g（切变模量）、e（材料杨氏模量）、pr（材料泊松比）、\n" +
            "$# tm（材料熔点）、tr（室温）、cp（材料比热），\n" +
            "$# 同时需要填写JOHNSON_COOK模型流动应力方程参数a、b、n、c、m。#---\n" +
            "*MAT_JOHNSON_COOK_TITLE\n" +
            "MaterialTemplateType15\n" +
            "$#     mid        ro         g         e        pr       dtf        vp    rateop\n";

        public string mid = "10001";
        public string ro = "2.70000E-9";
        public string g = "26320.0";
        public string e = "70000.0";
        public string pr = "0.33";

        public string txt18_19 = 
            "       0.0       0.0       0.0\n" +
            "$#       a         b         n         c         m        tm        tr      epso\n";

        public string a = "441.0";
        public string b = "383.39";
        public string n = "0.183";
        public string c = "0.0";
        public string m = "0.859";
        public string tm = "620.0";
        public string tr = "20.0";

        public string txt20_21 = "       1.0\n$#      cp        pc     spall        it        d1        d2        d3        d4\n";

        public string cp = "8.600000E8";

        public string txt22_25 = 
            "       0.0       2.0       0.0       0.0       0.0       0.0       0.0\n" +
            "$#      d5      c2/p      erod     efmin     \n" +
            "       0.0       0.0         01.00000E-6\n" +
            "*END";

        public StringBuilder GetDataList(string name, string mid, string ro, string g, string e, string pr, string a, string b, string n, string c, string m, string tm, string tr, string cp)
        {
            StringBuilder DataList = new StringBuilder();
            DataList.Append(txt1_8);
            DataList.Append(name);
            DataList.Append(txt10_17);
            DataList.Append(mid);
            DataList.Append(ro);
            DataList.Append(g);
            DataList.Append(e);
            DataList.Append(pr);
            DataList.Append(txt18_19);
            DataList.Append(a);
            DataList.Append(b);
            DataList.Append(n);
            DataList.Append(c);
            DataList.Append(m);
            DataList.Append(tm);
            DataList.Append(tr);
            DataList.Append(txt20_21);
            DataList.Append(cp);
            DataList.Append(txt22_25);

            return DataList;
        }
    }
}
