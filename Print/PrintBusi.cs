using CMSM.Print;
using System;
using System.Data;

namespace CMSM.Print
{
    public class PrintBusi : IPrintable
    {
        public PrintBusi()
        {
            //
        }
        #region 系统生成属性
       
        public string strNewAssCount { get; set; }
        
        public string strLostAssCount { get; set; }
        public string strFillFeeCount { get; set; }
        public string strDateType { get; set; }

        public string strFIllFee { get; set; }

        public string strBankFillFee { get; set; }

        public string strAssConsCount { get; set; }

        public string strAssCons { get; set; }
        public string strRetailCount { get; set; }
        public string strRetail { get; set; }
        public string strSum { get; set; }
        public string strDeptName { get; set; }
        public string strOperName { get; set; }
        public string strOperDate { get; set; }
        public string cnvcTel { get; set; }

        #endregion

        public void Print(PrintElement element)
        {
            element.AddHorizontalRule();
            element.AddData("小票类型", strDateType);
            element.AddHorizontalRule();
            element.AddData("新增会员数", strNewAssCount);
            element.AddData("挂失会员数", strLostAssCount);
            element.AddData("充值次数", strFillFeeCount);
            element.AddData("充值金额", strFIllFee);
            element.AddData("银联卡充值", strBankFillFee);
            element.AddData("会员消费次数", strAssConsCount);
            element.AddData("会员消费金额", strAssCons);
            element.AddData("零售次数", strRetailCount);
            element.AddData("零售金额", strRetail);
            element.AddHorizontalRule();
            element.AddData("现金汇总", strSum);
            element.AddHorizontalRule();

            element.AddData("操作员", strOperName);
            element.AddData("操作时间", strOperDate);
            element.AddData("操作部门", strDeptName);
            element.AddBlankLine();
            element.AddBlankLine();
            element.AddBlankLine();
            element.AddHorizontalRule();
        }
    }

}
