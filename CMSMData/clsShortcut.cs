using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CMSMData
{
    public class clsShortcut
    {
        public Hashtable hsshortcut = new Hashtable();

        public clsShortcut()
        {
            hsshortcut.Add("会员基本资料", "Alt0");
            hsshortcut.Add("会员卡充值", "Alt1");
            hsshortcut.Add("会员消费", "Alt2");
            hsshortcut.Add("非会员零售", "Alt3");
            hsshortcut.Add("赠送会员商品", "Alt4");
            hsshortcut.Add("商品特殊消耗", "Alt5");
            hsshortcut.Add("生产入库", "Alt6");
            hsshortcut.Add("销售盘点", "Alt7");
            hsshortcut.Add("同步历史数据", "Alt8");
            hsshortcut.Add("数据同步", "Alt9");
        }
        
    }
}
