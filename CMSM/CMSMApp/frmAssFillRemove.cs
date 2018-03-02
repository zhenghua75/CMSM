using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmAssConsRemove 的摘要说明。
	/// </summary>
	public class frmAssFillRemove : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnRemove;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCurCharge;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.TextBox txtAssID;
		private System.Windows.Forms.TextBox txtFillSerial;
		private System.Windows.Forms.TextBox txtFillFee;
		private System.Windows.Forms.TextBox txtFillDate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPromFee;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private string strOldDate="";

		public frmAssFillRemove()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.txtFillSerial = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRead = new System.Windows.Forms.Button();
			this.txtFillFee = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtFillDate = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.txtCurCharge = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAssName = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtAssID = new System.Windows.Forms.TextBox();
			this.txtPromFee = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.AliceBlue;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(40, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(440, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "会员充值撤单只能撤消会员1小时内在本店的最后一次充值且之后还未有消费";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "会员卡号";
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(80, 80);
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(168, 22);
			this.txtCardID.TabIndex = 2;
			this.txtCardID.Text = "";
			// 
			// txtFillSerial
			// 
			this.txtFillSerial.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtFillSerial.Location = new System.Drawing.Point(336, 80);
			this.txtFillSerial.Name = "txtFillSerial";
			this.txtFillSerial.Size = new System.Drawing.Size(168, 22);
			this.txtFillSerial.TabIndex = 4;
			this.txtFillSerial.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(272, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "充值流水";
			// 
			// btnRead
			// 
			this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRead.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnRead.Location = new System.Drawing.Point(144, 240);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(56, 24);
			this.btnRead.TabIndex = 5;
			this.btnRead.Text = "刷卡";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// txtFillFee
			// 
			this.txtFillFee.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtFillFee.Location = new System.Drawing.Point(80, 160);
			this.txtFillFee.Name = "txtFillFee";
			this.txtFillFee.Size = new System.Drawing.Size(168, 22);
			this.txtFillFee.TabIndex = 8;
			this.txtFillFee.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "充值金额";
			// 
			// txtFillDate
			// 
			this.txtFillDate.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtFillDate.Location = new System.Drawing.Point(80, 200);
			this.txtFillDate.Name = "txtFillDate";
			this.txtFillDate.Size = new System.Drawing.Size(168, 22);
			this.txtFillDate.TabIndex = 10;
			this.txtFillDate.Text = "";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(16, 208);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "充值时间";
			// 
			// btnRemove
			// 
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.ForeColor = System.Drawing.Color.Crimson;
			this.btnRemove.Location = new System.Drawing.Point(304, 240);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 24);
			this.btnRemove.TabIndex = 12;
			this.btnRemove.Text = "确认撤消";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// txtCurCharge
			// 
			this.txtCurCharge.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCurCharge.Location = new System.Drawing.Point(336, 120);
			this.txtCurCharge.Name = "txtCurCharge";
			this.txtCurCharge.Size = new System.Drawing.Size(168, 22);
			this.txtCurCharge.TabIndex = 14;
			this.txtCurCharge.Text = "";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(272, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "会员余额";
			// 
			// txtAssName
			// 
			this.txtAssName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtAssName.Location = new System.Drawing.Point(80, 120);
			this.txtAssName.Name = "txtAssName";
			this.txtAssName.Size = new System.Drawing.Size(168, 22);
			this.txtAssName.TabIndex = 16;
			this.txtAssName.Text = "";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(16, 128);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 15;
			this.label8.Text = "会员姓名";
			// 
			// txtAssID
			// 
			this.txtAssID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtAssID.Location = new System.Drawing.Point(8, 232);
			this.txtAssID.Name = "txtAssID";
			this.txtAssID.Size = new System.Drawing.Size(96, 22);
			this.txtAssID.TabIndex = 17;
			this.txtAssID.Text = "";
			this.txtAssID.Visible = false;
			// 
			// txtPromFee
			// 
			this.txtPromFee.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtPromFee.Location = new System.Drawing.Point(336, 160);
			this.txtPromFee.Name = "txtPromFee";
			this.txtPromFee.Size = new System.Drawing.Size(168, 22);
			this.txtPromFee.TabIndex = 19;
			this.txtPromFee.Text = "";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(272, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 18;
			this.label6.Text = "赠款金额";
			// 
			// frmAssFillRemove
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(520, 274);
			this.Controls.Add(this.txtPromFee);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtAssID);
			this.Controls.Add(this.txtAssName);
			this.Controls.Add(this.txtCurCharge);
			this.Controls.Add(this.txtFillDate);
			this.Controls.Add(this.txtFillFee);
			this.Controls.Add(this.txtFillSerial);
			this.Controls.Add(this.txtCardID);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmAssFillRemove";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会员充值撤单";
			this.Load += new System.EventHandler(this.frmAssConsRemove_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAssConsRemove_Load(object sender, System.EventArgs e)
		{
			this.txtCardID.ReadOnly=true;
			this.txtFillSerial.ReadOnly=true;
			this.txtAssName.ReadOnly=true;
			this.txtCurCharge.ReadOnly=true;
			this.txtFillFee.ReadOnly=true;
			this.txtFillDate.ReadOnly=true;
			this.txtPromFee.ReadOnly=true;
			this.btnRemove.Enabled=false;
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，挂失失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }

			string strresult="";
			CMSMStruct.CardHardStruct chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("该卡不属于本系统使用的卡，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult!="")
				{
					strresult=this.GetColCh(strresult,"ERR");
				}
				MessageBox.Show("刷卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(strresult!=null)
				{
					clog.WriteLine(strresult);
				}
				return;
			}
			if(chs.strCardID=="")
			{
				MessageBox.Show("会员卡号不正确，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(chs.strCardID.Substring(0,1)=="F")
			{
				MessageBox.Show("此卡为员工卡，不可进行消费！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			if(chs.strCardID!=txtCardID.Text.Trim())
			{
				MessageBox.Show("充值撤消卡与首次刷卡不是同一张卡，充值撤消失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.ClearText();
				btnRead.Enabled=true;				
				return;
			}
			else
			{
				#region 开始充值撤消
				if(this.txtFillSerial.Text.Trim()=="")
				{
					MessageBox.Show("没有任何可以进行撤消的充值记录！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					return;
				}

				CMSMData.CMSMStruct.FillFeeStruct refill=new CMSMData.CMSMStruct.FillFeeStruct();
				refill.strAssID=this.txtAssID.Text.Trim();
				refill.strCardID=this.txtCardID.Text.Trim();
				refill.dFillFee=Math.Round(-double.Parse(this.txtFillFee.Text.Trim()),2);
				refill.dFillProm=Math.Round(-double.Parse(this.txtPromFee.Text.Trim()),2);
				refill.dFeeLast=Math.Round(double.Parse(this.txtCurCharge.Text.Trim()),2);
				refill.dFeeCur=refill.dFillFee+refill.dFeeLast+refill.dFillProm;
				refill.strFillDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
				refill.strComments="充值撤消，原流水号："+this.txtFillSerial.Text.Trim();
				refill.strOperName=SysInitial.CurOps.strOperName;
				refill.strDeptID=SysInitial.LocalDept;
				refill.strSerial=this.txtFillSerial.Text.Trim();
				if(refill.dFeeCur<0)
				{
					MessageBox.Show("撤消后余额已经小于0，充值撤消失败，请检查是否已经有消费，再重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}

				chs.dCurCharge=refill.dFeeCur;
				double dCurChargeBak=System.Math.Round(double.Parse(txtCurCharge.Text.Trim())-double.Parse(this.txtFillFee.Text.Trim())-double.Parse(this.txtPromFee.Text.Trim()),2);

				if(chs.dCurCharge!=dCurChargeBak)
				{
					MessageBox.Show("充值撤消失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine("充值撤消备份值与计算值不等：备份值-- " + dCurChargeBak.ToString() + " 计算值-- " + chs.dCurCharge.ToString());
					return;
				}

				err=null;
				strresult="";
				strresult=cs.AssFillRemove(refill,chs.iCurIg,dCurChargeBak,strOldDate,out err);
				if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.Substring(0,3)=="CMT")
				{
					MessageBox.Show("充值撤消成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					clog.WriteLine(strresult);
				}
				else
				{
					MessageBox.Show("充值撤消失败，本次充值撤消无效，请检查余额是否正确！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err+ "\n" + strresult);
				}
				this.ClearText();
				btnRead.Enabled=true;
				this.btnRemove.Enabled=false;
				#endregion
			}		
		}

		private void btnRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，挂失失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }
			string strresult="";
			CMSMStruct.CardHardStruct chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("该卡不属于本系统使用的卡，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult.Substring(0,2)=="RF")
				{
					MessageBox.Show("刷卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("刷卡失败，请重试！\n"+strresult,"系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				if(strresult!=null)
				{
					clog.WriteLine(strresult);
				}
				return;
			}
			if(chs.strCardID=="")
			{
				MessageBox.Show("会员卡号不正确，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(chs.strCardID.Substring(0,1)=="F")
			{
				MessageBox.Show("此卡为员工卡，不可进行充值撤消！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				err=null;
				CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
				assres=cs.GetAssociatorName(chs.strCardID,out err);
				if(assres!=null)
				{
					DataRow[] drn=SysInitial.dsSys.Tables["AS"].Select("vcCommCode='"+assres.strAssState+"'");
					if(drn==null||drn.Length==0)
					{
						MessageBox.Show("会员状态参数错误，请检查参数或重新启动系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					else
					{
						string strAssState=drn[0]["vcCommName"].ToString();
						if(assres.strAssState!="0")
						{
							MessageBox.Show("该会员已经失效，卡号：" + chs.strCardID + "，现处于“"+strAssState+"”状态，请核查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							return;
						}
					}
					
					err=null;
					DataTable dtFillFee=cs.GetAssFillLast(assres.strCardID,out err);
					if(dtFillFee==null||err!=null)
					{
						MessageBox.Show(err.Message,"系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					else
					{
						txtAssID.Text=assres.strAssID;
						txtCurCharge.Text=dtFillFee.Rows[0]["nFeeCur"].ToString();
						txtCardID.Text=assres.strCardID;
						txtAssName.Text=assres.strAssName;

						this.txtFillSerial.Text=dtFillFee.Rows[0]["iSerial"].ToString();
						this.txtFillFee.Text=dtFillFee.Rows[0]["nFillFee"].ToString();
						this.txtFillDate.Text=dtFillFee.Rows[0]["dtFillDate"].ToString();
						this.txtPromFee.Text=dtFillFee.Rows[0]["nFillProm"].ToString();
						strOldDate=dtFillFee.Rows[0]["dtFillDate"].ToString();

						btnRead.Enabled=false;
						this.btnRemove.Enabled=true;
					}
				}
				else
				{
					MessageBox.Show("无会员资料，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}
	}
}
