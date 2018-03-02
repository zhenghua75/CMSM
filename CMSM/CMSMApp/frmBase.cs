using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;
using System.Data.OleDb;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;
using System.Text;
using System.Text.RegularExpressions;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmBase 的摘要说明。
	/// </summary>
	public class frmBase : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CMSM.log.CMSMLog clog;

		public frmBase()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			dgStyle();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");
			
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// frmBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "frmBase";
			this.Text = "frmBase";
			this.Load += new System.EventHandler(this.frmBase_Load);
			this.Closing+=new CancelEventHandler(frmBase_Closing);
		}
		#endregion

		#region Set dataGrid's style
		protected void dgStyle()
		{
			foreach(System.Windows.Forms.Control ctl in this.Controls)
			{
				if(ctl is System.Windows.Forms.DataGrid)
				{

					DataGrid dg=ctl as DataGrid;

					dg.ReadOnly=true;//设置只读属性
					dg.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;

					dg.AlternatingBackColor=System.Drawing.Color.WhiteSmoke;
					dg.BackgroundColor = System.Drawing.Color.Gainsboro;
					dg.CaptionBackColor = Color.FromArgb(((System.Byte)(195)), ((System.Byte)(231)), ((System.Byte)(253)));//Color.LightSkyBlue;
					dg.CaptionForeColor=Color.DodgerBlue;
					dg.CaptionForeColor = System.Drawing.Color.Black;
					dg.GridLineColor = System.Drawing.Color.LightSkyBlue;
					dg.HeaderBackColor = Color.Gainsboro;
					dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
					dg.ParentRowsBackColor = System.Drawing.Color.WhiteSmoke;
					dg.SelectionBackColor = System.Drawing.SystemColors.Info;
					dg.SelectionForeColor=Color.Blue;
					dg.PreferredColumnWidth=100;
				}
			}
		}
		#endregion

        #region frmBase_Load
        private void frmBase_Load(object sender, System.EventArgs e)
		{
			foreach(System.Windows.Forms.Control con in this.Controls)
			{
				Font ftnew=new Font("宋体",10);
				con.Font=ftnew;
				if(con is System.Windows.Forms.GroupBox)
				{
					con.ForeColor=Color.RoyalBlue;
					Font ftnew1=new Font("宋体",11);
					con.Font=ftnew1;
					foreach(System.Windows.Forms.Control con1 in con.Controls)
					{
						if(con1 is Label || con1 is TextBox || con1 is ComboBox || con1 is DateTimePicker || con1 is ListBox || con1 is RadioButton)
						{
							con1.Font=ftnew;
							con1.ForeColor=Color.Black;
							con1.Font=ftnew;
						}
						if(con1 is Button)
						{
							Button bt=con1 as Button;
							bt.ForeColor=Color.Black;
							bt.BackColor=Color.SeaShell;
							bt.Font=ftnew;
							bt.FlatStyle=System.Windows.Forms.FlatStyle.Popup;
						}
                        //if(con1 is DevExpress.XtraEditors.SimpleButton)
                        //{
                        //    DevExpress.XtraEditors.SimpleButton bts=con1 as DevExpress.XtraEditors.SimpleButton;
                        //    bts.ForeColor=Color.Black;
                        //    bts.ButtonStyle=DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        //}
					}
				}
				if(con is Label || con is TextBox || con is ComboBox || con is DateTimePicker)
				{
					con.Font=ftnew;
				}
				if(con is Button)
				{
					Button bt=con as Button;
					bt.ForeColor=Color.Black;
					bt.BackColor=Color.SeaShell;
					bt.Font=ftnew;
					bt.FlatStyle=System.Windows.Forms.FlatStyle.Popup;
				}
                //if(con is DevExpress.XtraEditors.SimpleButton)
                //{
                //    DevExpress.XtraEditors.SimpleButton bts=con as DevExpress.XtraEditors.SimpleButton;
                //    bts.ForeColor=Color.Black;
                //    bts.ButtonStyle=DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                //}
			}
		}
        #endregion

		#region English to Chinese
		protected void EnToCh(string strChinese,string strWidth,DataTable dt,System.Windows.Forms.DataGrid dg)
		{
			if(dt!=null)
			{
				int col_count=0;
				string[] str=strChinese.Split(',');
				string[] wid=strWidth.Split(',');
				System.Windows.Forms.DataGridTableStyle t_style=new System.Windows.Forms.DataGridTableStyle();
				t_style.MappingName=dt.TableName;
				System.Windows.Forms.DataGridColumnStyle[] c_style=new System.Windows.Forms.DataGridColumnStyle[str.Length];
				dg.TableStyles.Clear();
				col_count=(str.Length<dt.Columns.Count)?str.Length:dt.Columns.Count;
				for(int i=0;i<col_count;i++)
				{
					c_style[i]=new System.Windows.Forms.DataGridTextBoxColumn();
					c_style[i].MappingName=dt.Columns[i].ColumnName;
					c_style[i].HeaderText=(str[i]!="")?str[i]:dt.Columns[i].ColumnName;
					if(i<wid.Length && wid[i] != "")
						c_style[i].Width=Convert.ToInt32(wid[i]);
					t_style.GridColumnStyles.Add(c_style[i]);
				}
				t_style.AlternatingBackColor=System.Drawing.Color.WhiteSmoke;
				t_style.BackColor=System.Drawing.Color.White;
				t_style.GridLineColor=System.Drawing.Color.LightSkyBlue;
				t_style.HeaderBackColor=Color.Gainsboro;
				t_style.HeaderForeColor=System.Drawing.SystemColors.ControlText;
				t_style.SelectionBackColor=System.Drawing.SystemColors.Info;
				t_style.SelectionForeColor=Color.Blue;

				dg.Capture=true;

				dg.TableStyles.Add(t_style);
				dg.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;
				dg.ReadOnly=true;
			}
		}
		#endregion

		#region Fill ComboBox
		protected void FillComboBox(ComboBox cb,string tabName,string colName)
		{
			for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
				cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
			if(cb.Items.Count>0) 
				cb.SelectedIndex=0;
			cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
		}

		protected void FillComboBox(ComboBox cb,string tabName,string colName,string flag)
		{
			if(flag=="all")
			{
				cb.Items.Add("全部");
				for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
					cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
				if(cb.Items.Count>0) 
					cb.SelectedIndex=0;
				cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
			if(flag=="allExcRetail")
			{
				cb.Items.Add("全部");
				for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
				{
					if(SysInitial.dsSys.Tables[tabName].Rows[i]["vcCommCode"].ToString()!="AT999")
					{
						cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
					}
				}
				if(cb.Items.Count>0) 
					cb.SelectedIndex=0;
				cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}

		protected void FillComboBox(ComboBox cb,DataTable dttab,string colName,string flag)
		{
			if(flag=="all")
			{
				cb.Items.Add("全部");
				for(int i=0;i<dttab.Rows.Count;i++)
					cb.Items.Add(dttab.Rows[i][colName].ToString());
				if(cb.Items.Count>0) 
					cb.SelectedIndex=0;
				cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
			else
			{
				for(int i=0;i<dttab.Rows.Count;i++)
					cb.Items.Add(dttab.Rows[i][colName].ToString());
				if(cb.Items.Count>0) 
					cb.SelectedIndex=0;
				cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}

		protected void FillOperComboBox(ComboBox cb,string tabName,string colName)
		{
			for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
			{
				if(SysInitial.dsSys.Tables[tabName].Rows[i]["vcDeptID"].ToString()==SysInitial.LocalDept)
				{
					cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
				}
			}
			if(cb.Items.Count>0) 
				cb.SelectedIndex=0;
			cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
		}


		#endregion

		#region Fill ComboBox by en spell
		protected void FillComboBoxBySpell(ComboBox cb,string tabName,string colName,string colCode,string strSpell)
		{
			int len=strSpell.Length;
			cb.Items.Clear();
			cb.Refresh();
			for(int i=0;i<SysInitial.dsSys.Tables[tabName].Rows.Count;i++)
			{
				if(SysInitial.dsSys.Tables[tabName].Rows[i][colCode].ToString().Length>=len&&SysInitial.dsSys.Tables[tabName].Rows[i][colCode].ToString().Substring(0,len)==strSpell)
				{
					cb.Items.Add(SysInitial.dsSys.Tables[tabName].Rows[i][colName].ToString());
				}
			}
			cb.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDown;
			if(cb.Items.Count>0)
			{
				cb.SelectedIndex=0;
			}
			else
			{
				cb.DroppedDown=true;
			}
		}
		#endregion

		#region encode Column convert to Chinise
		protected string GetColCh(string strCode,string tabName)
		{
			string colch="";
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
			dv.Sort = "vcCommCode";
			if(dv.Find(strCode)==-1)
			{
				colch="未定义的编码："+strCode;
			}
			else
			{
				colch = dv[dv.Find(strCode)]["vcCommName"].ToString().Trim();
			}
			return colch;
		}
		#endregion

		#region Chinise convert to encode
		protected string GetColEn(string strName,string tabName)
		{
			string colen="";
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
			dv.Sort = "vcCommName";
			colen = dv[dv.Find(strName)]["vcCommCode"].ToString().Trim();
			return colen;
		}
		#endregion

		#region Code of DataTable convert to chinese
		//have condition
		public void DataTableConvert(DataTable dt,string columnName,string showTable,string tabColumnCode,string tabColumnName,string strFilter)
		{
			/// <summary>
			/// dt：被转换的表名，columnName:被转换的表的字段名,showTable:要转换的表名，tabColumnCode:要转换的表字段代码列名,
			/// tabColumnName:要转换的表字段内容列名,strFilter:要转换的表的过滤条件
			/// </summary>
			string strTemp ;			
			string strCommentColumnName = columnName;
	
			foreach (DataRow dr in dt.Rows)
			{				
				strTemp = this.CodeConvert(showTable,dr[columnName].ToString(),tabColumnCode,tabColumnName,strFilter);	
				dr[strCommentColumnName] = strTemp;
			}			
		}

		//have condition
		public string CodeConvert(string tabName,string columnValue,string tabColumnCode,string tabColumnName,string strFilter)
		{
			/// <summary>
			/// tabName：要转换的表名，columnValue:被转换的表的字段值,tabColumnCode:要转换的表字段代码列名,tabColumnName:要转换的表字段内容列名
			/// </summary>
			
			//			DataTable dt=(DataTable)dat_dsSys.dsSys.Tables[tabName];
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
			dv.RowFilter = strFilter;//过滤条件		
			string strRemark = columnValue;

			for(int i = 0;i<dv.Count;i++)
			{
				if(dv[i][""+tabColumnCode+""].ToString().ToUpper().Equals(columnValue.ToUpper()))
				{
					strRemark = dv[i][""+tabColumnName+""].ToString();
					break;
				}
			}
			return strRemark;	
		}

		//no condition
		public void DataTableConvert(DataTable dt,string columnName,string showTable,string tabColumnCode,string tabColumnName)
		{
			/// <summary>
			/// dt：被转换的表名，columnName:被转换的表的字段名,showTable:要转换的表名，tabColumnCode:要转换的表字段代码列名,
			/// tabColumnName:要转换的表字段内容列名,strFilter:要转换的表的过滤条件
			/// </summary>
			string strTemp ;			
			string strCommentColumnName = columnName;
	
			foreach (DataRow dr in dt.Rows)
			{				
				strTemp = this.CodeConvert(showTable,dr[columnName].ToString(),tabColumnCode,tabColumnName);	
				dr[strCommentColumnName] = strTemp;
			}			
		}

		//no condition
		public string CodeConvert(string tabName,string columnValue,string tabColumnCode,string tabColumnName)
		{
			/// <summary>
			/// tabName：要转换的表名，columnValue:被转换的表的字段值,tabColumnCode:要转换的表字段代码列名,tabColumnName:要转换的表字段内容列名
			/// </summary>
			
			//			DataTable dt=(DataTable)dat_dsSys.dsSys.Tables[tabName];
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
					
			string strRemark = columnValue;
		
			for(int i = 0;i<dv.Count;i++)
			{
				if(dv[i][""+tabColumnCode+""].ToString().Equals(columnValue))
				{
					strRemark = dv[i][""+tabColumnName+""].ToString();
					break;
				}
			}
			return strRemark;	
		}
		#endregion

		#region Clear textbox
		protected void ClearText()
		{
			foreach(System.Windows.Forms.Control ctl in this.Controls)
			{
				if(ctl is System.Windows.Forms.TextBox || ctl is System.Windows.Forms.ComboBox)
				{
					ctl.Text="";
				}
				if(ctl is System.Windows.Forms.GroupBox)
				{
					foreach(System.Windows.Forms.Control con1 in ctl.Controls)
					{
						if(con1 is TextBox || con1 is ComboBox)
						{
							con1.Text="";
						}
					}
				}
			}
		}
		#endregion

		#region 导出到Excel
		//去掉DagaGrid的HeadText不符合做为列名称规范的字符
		protected string replace(string str)
		{
			str=str.Replace("(","");
			str=str.Replace(")","");
			str=str.Replace("-","");
			return str;
		}

		private string repText(string str)
		{
			str=str.Replace("'","");
			return str;
		}

		protected void ExportToExcel(string table)
		{
			this.Cursor=Cursors.WaitCursor;
			OleDbConnection con=new OleDbConnection();
			bool sucess=false;
			string file="";
			try
			{
				string strApp = Assembly.GetExecutingAssembly().Location.ToString();
				string strDir = strApp.Substring(0,strApp.LastIndexOf(@"\"));
				file=strDir + "\\XX报表.xls";
				if(System.IO.File.Exists(file))
					System.IO.File.Delete(file);
                con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=0;';";
				con.Open();
				OleDbCommand com=new OleDbCommand();
				com.Connection=con;
				int count=0;
				string name="";
				foreach(System.Windows.Forms.Control ctl in this.Controls)
				{
					if(ctl is System.Windows.Forms.DataGrid)
					{
						count++;
						DataGrid dg=ctl as DataGrid;
						if(name==dg.CaptionText)//给表取名称，没有错误对应captionText
							name="Table" + count.ToString();
						else
							name=dg.CaptionText==""?"Table" + count.ToString():dg.CaptionText;
						DataTable dt=new DataTable();
						dt=(DataTable)dg.DataSource;
						if(dt!=null && dt.Rows.Count>0)
						{							
							if(table.Length>0)
								table=table.Substring(0,table.Length-1);
							table="create table " + name + " (" + table + ")";
							com.CommandText=table;
							com.ExecuteNonQuery();//创建表结构
							for(int i=0;i<dt.Rows.Count;i++)
							{
								string row="";
								for(int j=0;j<dt.Columns.Count;j++)
								{
									if(dg.TableStyles[0].GridColumnStyles[j].Width>0)
										row+="'" + this.repText(dt.Rows[i][j].ToString()) + "',";
								}
								row=row.Substring(0,row.Length-1);
								row="insert into " + name + " values(" + row + ")";
								com.CommandText=row;
								com.ExecuteNonQuery();//插入数据
							}
							sucess=true;
						}
						else
						{
							MessageBox.Show("表格【" + name + "】没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
						}
					}
				}                
			}
			catch(Exception err)
			{
				MessageBox.Show("导出出错，请重试！","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Error );
				clog.WriteLine(err);
			}
			finally
			{
				con.Close();
				if(sucess)
				{
					ProcessStartInfo helpFile=new ProcessStartInfo(file);
					Process.Start(helpFile);
				}
			}
			this.Cursor=Cursors.Default;
		}

		protected void BusiIncomeExportToExcel(string tabname,string tabdate,DataTable dtIncome)
		{
			try
			{
				Excel.Application xapp=new Excel.ApplicationClass();
				Excel.Workbook xbook=xapp.Workbooks.Open(Application.StartupPath+@"\BusiIncomeModel.xls",Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				Excel.Worksheet xSheet = (Excel.Worksheet)xbook.Sheets["业务量"];//得到Sheet

				xSheet.get_Range("A1", Missing.Value).Value2 = tabname;
				xSheet.get_Range("A2", Missing.Value).Value2 = tabdate;
				for(int i=1;i<dtIncome.Rows.Count-2;i++)
				{
					for(int j=1;j<8;j++)
					{
						xSheet.Cells[i+3,j+1] = dtIncome.Rows[i][j].ToString();
					}
				}

				for(int i=1;i<8;i++)
				{
					xSheet.Cells[21,i+1] = dtIncome.Rows[18][i].ToString();
				}

				SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
				SaveFileDialog1.Filter = "Excel文件（*.xls）|*.xls";
				SaveFileDialog1.FileName= SysInitial.CP + "业务量报表" + DateTime.Now.ToShortDateString() + ".xls";
				if(SaveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					xbook.SaveCopyAs(SaveFileDialog1.FileName);//另存
					xbook.Close(false, Application.StartupPath+@"\BusiIncomeModel.xls", Missing.Value);//关闭
					xSheet = null;
					xbook = null;
					xapp.Quit();
					xapp = null;
				}
				else
				{
					xbook.Close(false, Missing.Value, Missing.Value);//关闭
					xSheet = null;
					xbook = null;
					xapp.Quit();
					xapp = null;
				}
			}
			catch(Exception err)
			{
				MessageBox.Show("导出时出错，请重试！","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Error );
				clog.WriteLine(err);
			}
			finally
			{

			}
		}
		#endregion

		private void frmBase_Closing(object sender, CancelEventArgs e)
		{
			if(this.ParentForm!=null)
			{
				foreach(System.Windows.Forms.Control con in this.ParentForm.Controls)
				{
					if(con is System.Windows.Forms.StatusBar)
					{
						StatusBar st=con as StatusBar;
						st.Panels[3].Text="当前位置：主界面";
						return;
					}
				}
			}
		}

		public void OpenDrawer()
		{
//			PrintDocument pdc = new PrintDocument();
//			string printerName = pdc.PrinterSettings.PrinterName; 
//			string send = "" + (char)(27) + (char)(112) + (char)(1) + (char)(50) + (char)(120);
//			RawPrinterHelper.SendStringToPrinter(printerName, send);
		}

		private void Print(string strEn,CMSM.Print.IPrintable pBill)
		{
			try
			{
				CMSM.Print.PrintEngine printEngine = new CMSM.Print.PrintEngine(strEn);
				printEngine.AddPrintObject(pBill);
				printEngine.Print();
			}
			catch(Exception ex)
			{
				clog.WriteLine(ex);
				MessageBox.Show("打印错误","打印",MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
		}
		protected void AssConsPrint(CMSMData.CMSMStruct.CardHardStruct chs,CMSMData.CMSMStruct.ConsItemStruct cis,CommAccess cs,string strSerialok,DataTable dtConsItem,double dTolCharge)
		{
			Exception err;
			string strEn = cs.GetEnterpriseName(out err);
			if(err!=null)
			{
				MessageBox.Show("查询企业名称出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strEn="道讯收银";
			}

			DataTable dtNewItem = cs.GetNewGoods(out err);
			if(err!=null)
			{
				MessageBox.Show("查询推荐新品出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				dtNewItem = new DataTable();
			}
			string strTel = cs.GetTel2(out err);
			if(err!=null)
			{
				MessageBox.Show("查询服务电话出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strTel = "";
			}
			DataTable dtIgItem = new DataTable();
            CMSM.Print.ConsTicket pBill = new CMSM.Print.ConsTicket(strSerialok, this.GetColCh(cis.strDeptID, "MD"), cis.strCardID, "当前余额",
				cis.dChargeLast,chs.dCurCharge,
				dtConsItem,dTolCharge,cis.dTRate,"会员刷卡",dTolCharge,0,dtNewItem,strTel,dtIgItem,chs.iCurIg,cis.strOperDate);
			Print(strEn,pBill);
		}
		protected void RetailConsPrint(CMSMData.CMSMStruct.ConsItemStruct cis,CommAccess cs,string strSerialok,DataTable dtConsItem,double dTolCharge,double dPay,double dBalance,double dDiscount)
		{
			Exception err;
            string strConsTypeTmp = cis.strConsType;
            switch (cis.strConsType)
            {
                case "PT002":
                    strConsTypeTmp = "支付现金";
                    break;
                case "PT005":
                    strConsTypeTmp = "门店报损";
                    break;
                case "PT006":
                    strConsTypeTmp = "门店品尝";
                    break;
                case "PT007":
                    strConsTypeTmp = "门店退货";
                    break;
                case "PT008":
                    strConsTypeTmp = "银行卡";
                    break;

            }
			string strEn = cs.GetEnterpriseName(out err);
			if(err!=null)
			{
				MessageBox.Show("查询企业名称出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strEn="道讯收银";
			}
			DataTable dtNewItem = cs.GetNewGoods(out err);
			if(err!=null)
			{
				MessageBox.Show("查询推荐新品出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				dtNewItem = new DataTable();
			}
			string strTel = cs.GetTel2(out err);
			if(err!=null)
			{
				MessageBox.Show("查询服务电话出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strTel = "";
			}
			DataTable dtIgItem= new DataTable();
            CMSM.Print.ConsTicket pBill = new CMSM.Print.ConsTicket(strSerialok, this.GetColCh(cis.strDeptID, "MD"), "", "", 0, 0, dtConsItem, dTolCharge, dDiscount, strConsTypeTmp, dPay, dBalance, dtNewItem, strTel, dtIgItem, 0, cis.strOperDate);
			Print(strEn,pBill);
		}
		
		protected void FillFeePrint(CMSMData.CMSMStruct.FillFeeStruct ffs,CommAccess cs,string strAssName,string strOperName,string strDeptName)
		{
			Exception err;
			CMSM.Print.PrintedBill pBill = new CMSM.Print.PrintedBill();
			pBill.cnvcBillType = "充值";
			pBill.cnvcMemberCardNo = ffs.strCardID;
			pBill.cnvcMemberName = strAssName;
			pBill.cnnLastBalance = Convert.ToDecimal(ffs.dFeeLast);
			pBill.cnnBalance = Convert.ToDecimal(ffs.dFeeCur);
			pBill.cnnPrepay = Convert.ToDecimal(ffs.dFillFee);
			pBill.cnnDonate = Convert.ToDecimal(ffs.dFillProm);
						
			pBill.cnvcOperName = strOperName;
			pBill.cndOperDate = Convert.ToDateTime(ffs.strFillDate);
			pBill.cnvcDeptName = strDeptName;
			string strEn = cs.GetEnterpriseName(out err);
			if(err!=null)
			{
				MessageBox.Show("查询企业名称出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
                strEn = "道讯收银";
			}

			string strTel = cs.GetTel2(out err);
			if(err!=null)
			{
				MessageBox.Show("查询服务电话出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strTel = "";
			}
			pBill.cnvcTel = strTel;
			Print(strEn,pBill);
		}
        // 当日结账
        protected void ChangeCheckPrint(CMSMData.CMSMStruct.DailyAccountStruct ffs, CommAccess cs, string strOperName, string strDeptName)
        {
            Exception err;
            CMSM.Print.PrintChangeCheck pBill = new CMSM.Print.PrintChangeCheck();
            pBill.cnvcDateType = "当日结账";
            pBill.cnvcOperName = ffs.strOper;
            DateTime dtnow = DateTime.Now;
            pBill.cnvcOperDate =dtnow.ToShortDateString() + dtnow.ToShortTimeString();
            pBill.cnvcDeptName = strDeptName;
            pBill.cnvcFillCount = ffs.strFillCount;
            pBill.cnvcFillFee = ffs.strFillFee;
            pBill.cnvcFillCountBank = ffs.strFillCountBank;
            pBill.cnvcFillFeeBank = ffs.strFillFeeBank;
            pBill.cnvcConsCount = ffs.strConsCount;
            pBill.cnvcRetail = ffs.strRetail;
            pBill.cnvcRetailBank = ffs.strRetailBank;
            pBill.cnvcAssCons = ffs.strAssCons;
            pBill.cnvcRoll = ffs.strRoll;
            pBill.cnvcRollSum = ffs.strRollSum;
            pBill.cnvcLargCount = ffs.strLargCount;
            pBill.cnvcCash = ffs.strCash;

            string strEn = cs.GetEnterpriseName(out err);
            if (err != null)
            {
                MessageBox.Show("查询企业名称出错，请与管理员联系！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                clog.WriteLine(err);
                strEn = "道讯收银";
            }

            string strTel = cs.GetTel2(out err);
            if (err != null)
            {
                MessageBox.Show("查询服务电话出错，请与管理员联系！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                clog.WriteLine(err);
                strTel = "";
            }
            pBill.cnvcTel = strTel;
            Print(strEn, pBill);
        }
        protected void BusiPrint(CMSMData.CMSMStruct.BusiStruct ffs, CommAccess cs, string strOperName, string strDeptName)
        {
            Exception err;
            CMSM.Print.PrintBusi pBill = new CMSM.Print.PrintBusi();
            pBill.strDateType = "业务量报表";
            pBill.strNewAssCount = ffs.strNewAssCount;
            pBill.strLostAssCount = ffs.strLostAssCount;
            pBill.strFillFeeCount = ffs.strFillFeeCount;
            pBill.strFIllFee = ffs.strFIllFee;
            pBill.strBankFillFee = ffs.strBankFillFee;
            pBill.strAssConsCount = ffs.strAssConsCount;
            pBill.strAssCons = ffs.strAssCons;
            pBill.strRetailCount = ffs.strRetailCount;
            pBill.strRetail = ffs.strRetail;
            pBill.strSum = ffs.strSum;
            pBill.strOperName = ffs.strOperName;
            DateTime dtnow = DateTime.Now;
            pBill.strOperDate = dtnow.ToShortDateString() + dtnow.ToShortTimeString();
            pBill.strDeptName = ffs.strDeptname;

            string strEn = cs.GetEnterpriseName(out err);
            if (err != null)
            {
                MessageBox.Show("查询企业名称出错，请与管理员联系！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                clog.WriteLine(err);
                strEn = "道讯收银";
            }

            string strTel = cs.GetTel2(out err);
            if (err != null)
            {
                MessageBox.Show("查询服务电话出错，请与管理员联系！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                clog.WriteLine(err);
                strTel = "";
            }
            pBill.cnvcTel = strTel;
            Print(strEn, pBill);
        }
		protected void FillFeePrint(CMSMData.CMSMStruct.FillFeeStruct ffs,CommAccess cs,string strAssName)
		{
			FillFeePrint(ffs,cs,strAssName,SysInitial.CurOps.strOperName,this.GetColCh(ffs.strDeptID,"MD"));
		}
        protected void ChangeCheckPrint(CMSMData.CMSMStruct.DailyAccountStruct ffs, CommAccess cs)
        {
            ChangeCheckPrint(ffs, cs,SysInitial.CurOps.strOperName, this.GetColCh(ffs.strDeptID, "MD"));
        }
        protected void BusiPrint(CMSMData.CMSMStruct.BusiStruct ffs, CommAccess cs)
        {
            BusiPrint(ffs, cs, ffs.strOperName, ffs.strOperName);
        }

		protected void AssGiftPrint(CMSMData.CMSMStruct.CardHardStruct chs,CMSMData.CMSMStruct.ConsItemStruct cis,CommAccess cs,string strSerialok,DataTable dtConsItem,double dTolCharge)
		{
			Exception err;
			string strEn = cs.GetEnterpriseName(out err);
			if(err!=null)
			{
				MessageBox.Show("查询企业名称出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strEn="道讯收银";
			}

			DataTable dtNewItem = cs.GetNewGoods(out err);
			if(err!=null)
			{
				MessageBox.Show("查询推荐新品出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				dtNewItem = new DataTable();
			}
			string strTel = cs.GetTel2(out err);
			if(err!=null)
			{
				MessageBox.Show("查询服务电话出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strTel = "";
			}
			DataTable dtIgItem = new DataTable();
			CMSM.Print.ConsTicket pBill = new CMSM.Print.ConsTicket(strSerialok,this.GetColCh(cis.strDeptID,"MD"),cis.strCardID,"当前余额",
				cis.dChargeLast,chs.dCurCharge,
				dtConsItem,dTolCharge,0,"赠送商品",dTolCharge,0,dtNewItem,strTel,dtIgItem,0,cis.strOperDate);
			Print(strEn,pBill);
		}
		protected void AssIgPrint(CMSMData.CMSMStruct.CardHardStruct chs,CMSMData.CMSMStruct.ConsItemStruct cis,CommAccess cs,string strSerialok,DataTable dtIgItem,double dTolCharge)
		{
			Exception err;
			string strEn = cs.GetEnterpriseName(out err);
			if(err!=null)
			{
				MessageBox.Show("查询企业名称出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strEn="道讯收银";
			}

			DataTable dtNewItem = cs.GetNewGoods(out err);
			if(err!=null)
			{
				MessageBox.Show("查询推荐新品出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				dtNewItem = new DataTable();
			}
			string strTel = cs.GetTel2(out err);
			if(err!=null)
			{
				MessageBox.Show("查询服务电话出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				strTel = "";
			}
			DataTable dtConsItem = new DataTable();
			CMSM.Print.ConsTicket pBill = new CMSM.Print.ConsTicket(strSerialok,this.GetColCh(cis.strDeptID,"MD"),cis.strCardID,"当前余额",
				cis.dChargeLast,chs.dCurCharge,
				dtConsItem,dTolCharge,0,"积分兑换",dTolCharge,0,dtNewItem,strTel,dtIgItem,0,cis.strOperDate);
			Print(strEn,pBill);
		}
		protected int GetPromrate(double dFee)
		{
			string pattern = @"\d+-\d+|\d+";
			int promrate=0;

			for(int i=1;i<6;i++)
			{
				if(SysInitial.dsSys.Tables.Contains("FP"+i.ToString()))
				{
					DataTable dt = SysInitial.dsSys.Tables["FP"+i.ToString()];
					if(dt.Rows.Count>0)
					{
						string strCommName = dt.Rows[0]["vcCommName"].ToString();
						Match match = Regex.Match(strCommName, pattern);
						if (match.Success) 
						{
							string strMatch = match.Captures[0].Value;
							string[] strCommNames = strMatch.Split('-');
							double dBegin = double.Parse(strCommNames[0]);
							double dEnd = double.MaxValue;
							if(strCommNames.Length>1)
							{
								dEnd = double.Parse(strCommNames[1]);
							}

							if(dFee>=dBegin && dFee<dEnd)
							{
								string strCommCode = dt.Rows[0]["vcCommCode"].ToString();
								promrate = int.Parse(strCommCode);
							}
						}
					}
				}
			}
			return promrate;
			
		}
	}
}
