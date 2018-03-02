using CMSM.Print;
using System;
using System.Data;

namespace CMSM.Print
{
    public class PrintChangeCheck : IPrintable
    {
        public PrintChangeCheck()
		{
            //
		}
        #region 系统生成属性
        /// <summary>
        /// 操作员
        /// </summary>
        public string cnvcOperName{get;set;}
        /// <summary>
        /// 操作时间
        /// </summary>
        public string cnvcOperDate { get; set; }
        public string cnvcDateType { get; set; }

        public string cnvcTel { get; set; }

        public string cnvcDeptName { get; set; }

        public string cnvcFillCount { get; set; }

        public string cnvcFillFee { get; set; }
        public string cnvcFillCountBank { get; set; }
        public string cnvcFillFeeBank { get; set; }
        public string cnvcConsCount { get; set; }
        public string cnvcRetail { get; set; }
        public string cnvcRetailBank { get; set; }
        public string cnvcAssCons { get; set; }
        public string cnvcRoll { get; set; }
        public string cnvcRollSum { get; set; }
        public string cnvcLargCount { get; set; }
        public string cnvcCash { get; set; }

        #endregion

        public void Print(PrintElement element)
        {
            //element.AddSeat(cnvcBillType);
            element.AddHorizontalRule();
            element.AddData("小票类型", cnvcDateType);
            element.AddHorizontalRule();

            element.AddData("现金充值次数", cnvcFillCount);
            element.AddData("现金充值金额", cnvcFillFee);
            element.AddData("银行卡充值次数", cnvcFillCountBank);
            element.AddData("银行卡充值金额", cnvcFillFeeBank);
            element.AddData("消费次数", cnvcConsCount);
            element.AddData("现金零售金额", cnvcRetail);
            element.AddData("银行卡零售金额", cnvcRetailBank);
            element.AddData("会员消费金额", cnvcAssCons);
            element.AddData("回收卡数", cnvcRoll);
            element.AddData("回收退款金额", cnvcRollSum);
            element.AddData("赠送次数", cnvcLargCount);
            element.AddHorizontalRule();
            element.AddData("现金总额", cnvcCash);
            element.AddHorizontalRule();

            element.AddData("操作员", cnvcOperName);
            element.AddData("操作时间", cnvcOperDate);
            element.AddData("操作部门", cnvcDeptName);
            element.AddBlankLine();
            element.AddBlankLine();
            element.AddBlankLine();
            element.AddHorizontalRule();
        }
    }

}
