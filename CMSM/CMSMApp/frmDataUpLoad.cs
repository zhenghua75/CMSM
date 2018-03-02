using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using CMSMData;
using CMSMData.CMSMDataAccess;
using cc;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmDataUpLoad.
	/// </summary>
	public class frmDataUpLoad : frmBase
	{
		private DevExpress.XtraEditors.SimpleButton sbtnOk;
		private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
		private System.Windows.Forms.ListBox listBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		StructToString sts=new StructToString();
		CommAccess ca=new CommAccess(SysInitial.ConString);
		Exception err=null;

		public frmDataUpLoad()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
			this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
			this.listBox1 = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// sbtnOk
			// 
			this.sbtnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.sbtnOk.Location = new System.Drawing.Point(328, 16);
			this.sbtnOk.Name = "sbtnOk";
			this.sbtnOk.Size = new System.Drawing.Size(80, 23);
			this.sbtnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.CornflowerBlue, System.Drawing.SystemColors.ControlText);
			this.sbtnOk.TabIndex = 27;
			this.sbtnOk.Text = "��ʼ�ϴ�";
			this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
			// 
			// progressBarControl1
			// 
			this.progressBarControl1.EditValue = 100;
			this.progressBarControl1.Location = new System.Drawing.Point(8, 48);
			this.progressBarControl1.Name = "progressBarControl1";
			this.progressBarControl1.Size = new System.Drawing.Size(406, 16);
			this.progressBarControl1.TabIndex = 26;
			this.progressBarControl1.TabStop = false;
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(8, 80);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(416, 256);
			this.listBox1.TabIndex = 25;
			// 
			// frmDataUpLoad
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(432, 342);
			this.Controls.Add(this.sbtnOk);
			this.Controls.Add(this.progressBarControl1);
			this.Controls.Add(this.listBox1);
			this.Name = "frmDataUpLoad";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�����ϴ�";
			this.Load += new System.EventHandler(this.frmDataUpLoad_Load);
			((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDataUpLoad_Load(object sender, System.EventArgs e)
		{
			this.progressBarControl1.Position=0;
			this.progressBarControl1.Properties.Maximum=40;
			this.progressBarControl1.Visible=false;
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			this.progressBarControl1.Position=0;
			this.listBox1.Items.Clear();
			string filePath=@"E:\\BreadWorksDataBak\\UpLoad\\";
			string UpFileName;

			if(!System.IO.Directory.Exists(filePath))
			{
				System.IO.Directory.CreateDirectory(filePath);
				MessageBox.Show("û����Ҫ�ϴ������ϣ�","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			string[] fileall=Directory.GetFiles(filePath);
			if(fileall.Length==0)
			{
				MessageBox.Show("û����Ҫ�ϴ������ϣ�","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			DataTable dtmd=SysInitial.dsSys.Tables["MD"];
			string strZZ;
			bool fileflag=false;

			for(int i=0;i<dtmd.Rows.Count;i++)
			{
				if(dtmd.Rows[i]["vcCommCode"].ToString()!=SysInitial.LocalDept)
				{
					fileflag=false;
					strZZ=dtmd.Rows[i]["vcCommCode"].ToString() + ".L00$";
					Regex regExpr = new Regex(strZZ.ToLower());
					foreach(string _strFileName in fileall)	
					{
						FileInfo fileInfo = new FileInfo(_strFileName);
					
						if ( regExpr.IsMatch(fileInfo.Name.ToLower(),0))
						{
							fileflag=true;
							break;
						}
					}
				}
				if(fileflag)
				{
					break;
				}
			}
			if(!fileflag)
			{
				MessageBox.Show("û����Ҫ�ϴ������ϣ�","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			for(int i=0;i<dtmd.Rows.Count;i++)
			{
				if(dtmd.Rows[i]["vcCommCode"].ToString()!=SysInitial.LocalDept)
				{
					fileflag=false;
					strZZ=dtmd.Rows[i]["vcCommCode"].ToString() + ".L00$";
					Regex regExpr = new Regex(strZZ.ToLower());
					foreach(string _strFileName in fileall)	
					{
						FileInfo fileInfo = new FileInfo(_strFileName);
					
						if(regExpr.IsMatch(fileInfo.Name.ToLower(),0))
						{
							fileflag=true;
							break;
						}
					}
					if(!fileflag)
					{
						continue;
					}

					this.listBox1.Items.Add("��ʼ�ϴ�" + dtmd.Rows[i]["vcCommName"].ToString() + "�����ݣ�");
					this.listBox1.Items.Add("---------------------------");
					this.Refresh();
					UpFileName="down" + dtmd.Rows[i]["vcCommCode"].ToString() + ".L00";
					if(System.IO.File.Exists(filePath+UpFileName+".tmp"))
						System.IO.File.Delete(filePath+UpFileName+".tmp");
					ArrayList alUp=new ArrayList();	
			
					StreamReader fReader;
					string strLine;
					string strTitle="";
					string strUpFlag;
					string strFlag="NO";
//					int upcount=0;
//					int reTolCount=0;
//					int unitcount=0;
//					int curcount=0;

					if(System.IO.File.Exists(filePath+UpFileName))
					{
						//����
						DESEncryptor dese=new DESEncryptor();
						dese.InputFilePath=filePath+UpFileName;
						dese.OutFilePath=filePath+UpFileName+".tmp";
						dese.DecryptKey="cmsmyykx";
						dese.FileDesDecrypt();
						if(dese.NoteMessage!=null)
						{
							MessageBox.Show("�ϴ��ļ�������������ԣ�","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
							this.clog.WriteLine(dese.NoteMessage);
							return;
						}
						dese=null;

						err=null;
						ca.TruncateDataTmp(out err);

						fReader = new StreamReader(filePath+UpFileName+".tmp");
						while((strLine = fReader.ReadLine()) != null)
						{
							strUpFlag="";
							strFlag="NO";
							if(strLine.Trim().Length <= 0)
								continue;

							//�Ƿ񵥱����
							strUpFlag=strLine.Substring(0,3);
							if(strUpFlag=="END")
							{
//								switch(strTitle)
//								{
//									case "USERTOL":
//										this.listBox1.Items.Add("��Ա�����ϴ���ɣ������ϴ���Ա����" + upcount.ToString());
//										break;
//									case "ALTETOL":
//										this.listBox1.Items.Add("��Ա���ϱ����¼�ϴ���ɣ������ϴ���¼����" + upcount.ToString());
//										break;
//									case "CONSTOL":
//										this.listBox1.Items.Add("������ϸ�ϴ���ɣ������ϴ���¼����" + upcount.ToString());
//										break;
//									case "INVOTOL":
//										this.listBox1.Items.Add("СƱ�����ϴ���ɣ������ϴ���¼����" + upcount.ToString());
//										break;
//									case "INTGTOL":
//										this.listBox1.Items.Add("������־�ϴ���ɣ������ϴ���¼����" + upcount.ToString());
//										break;
//									case "FILLTOL":
//										this.listBox1.Items.Add("��ֵ��־�ϴ���ɣ������ϴ���¼����" + upcount.ToString());
//										break;
//									case "BUSSTOL":
//										this.listBox1.Items.Add("Ӫҵ��־�ϴ���ɣ������ϴ���¼����" + upcount.ToString());
//										break;
//									default:
//										break;
//								}
								if( strTitle=="USERTOL"&&!SysInitial.MainDept)
								{
									break;
								}
								strTitle="";
//								upcount=0;
//								curcount=0;
								continue;
							}

							//�Ƿ񵥱�ʼ
							strUpFlag=strLine.Substring(4,3);
							if(strUpFlag=="TOL")
							{
								strTitle=strLine.Substring(0,7);
//								reTolCount=int.Parse(strLine.Substring(8,strLine.Length-8));
//								this.progressBarControl1.Position=0;
//								unitcount=reTolCount/40;
								continue;
							}

							//�����ϴ����������ϴ�
							switch(strTitle)
							{
								case "USERTOL":
									#region �ϴ���Ա����
									CMSMStruct.AssociatorStruct ass=new CMSMData.CMSMStruct.AssociatorStruct();
									err=null;
									if(!sts.UserParseLine(strLine,",",out ass,out err))
									{
										MessageBox.Show("ת���ϴ�����ʱ����ϵͳ���Զ������������ϣ������ϴ���","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
										if(err!=null)
										{
											clog.WriteLine(err);
										}
										continue;
									}
									err=null;
									if(!ca.UpAssData(ass,out strFlag,out err))
									{
										MessageBox.Show("�ϴ����ݳ������ţ�" + ass.strCardID + " ��","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
										if(err!=null)
										{
											clog.WriteLine(err);
										}
										continue;
									}
//									if(strFlag=="YES")
//										upcount++;
//									curcount++;
//									if(curcount<reTolCount)
//									{
//										if(curcount==(this.progressBarControl1.Position+1)*unitcount)
//										{
//											this.progressBarControl1.Position++;
//											this.Refresh();
//										}
//									}
//									else
//									{
//										this.progressBarControl1.Position=40;
//										this.Refresh();
//									}
									#endregion
									break;
								case "ALTETOL":
//									#region �ϴ���Ա���ϱ����¼
//									CMSMStruct.AssChangeStruct asschange=new CMSMData.CMSMStruct.AssChangeStruct();
//									err=null;
//									if(!sts.UserAlterParseLine(strLine,",",out asschange,out err))
//									{
//										MessageBox.Show("ת���ϴ�����ʱ����ϵͳ���Զ������������ϣ������ϴ���","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
//										if(err!=null)
//										{
//											clog.WriteLine(err);
//										}
//										continue;
//									}
//									err=null;
//									if(!ca.UpAssAlterData(asschange,out strFlag,out err))
//									{
//										MessageBox.Show("�ϴ����ݳ������ţ�" + asschange.strCardID + " ��","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
//										if(err!=null)
//										{
//											clog.WriteLine(err);
//										}
//										continue;
//									}
//									if(strFlag=="YES")
//										upcount++;
//									curcount++;
//									if(curcount<reTolCount)
//									{
//										if(curcount==(this.progressBarControl1.Position+1)*unitcount)
//										{
//											this.progressBarControl1.Position++;
//											this.Refresh();
//										}
//									}
//									else
//									{
//										this.progressBarControl1.Position=40;
//										this.Refresh();
//									}
//									#endregion
									break;
								case "CONSTOL":
									#region �ϴ�������ϸ
									if(SysInitial.MainDept)
									{
										CMSMStruct.ConsDownStruct consd=new CMSMData.CMSMStruct.ConsDownStruct();
										err=null;
										if(!sts.ConsParseLine(strLine,",",out consd,out err))
										{
											MessageBox.Show("ת���ϴ�����ʱ����ϵͳ���Զ������������ϣ������ϴ���","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
										err=null;
										if(!ca.UpConsData(consd,out strFlag,out err))
										{
											MessageBox.Show("�ϴ����ݳ������ţ�" + consd.strCardID + " ��","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
//										if(strFlag=="YES")
//											upcount++;
//										curcount++;
//										if(curcount<reTolCount)
//										{
//											if(curcount==(this.progressBarControl1.Position+1)*unitcount)
//											{
//												this.progressBarControl1.Position++;
//												this.Refresh();
//											}
//										}
//										else
//										{
//											this.progressBarControl1.Position=40;
//											this.Refresh();
//										}
									}
									#endregion
									break;
								case "INVOTOL":
									#region �ϴ�СƱ����
									if(SysInitial.MainDept)
									{
										CMSMStruct.BillStruct bis=new CMSMData.CMSMStruct.BillStruct();
										err=null;
										if(!sts.BillParseLine(strLine,",",out bis,out err))
										{
											MessageBox.Show("ת���ϴ�����ʱ����ϵͳ���Զ������������ϣ������ϴ���","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
										err=null;
										if(!ca.UpBillData(bis,out strFlag,out err))
										{
											MessageBox.Show("�ϴ����ݳ������ţ�" + bis.strCardID + " ��","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
//										if(strFlag=="YES")
//											upcount++;
//										curcount++;
//										if(curcount<reTolCount)
//										{
//											if(curcount==(this.progressBarControl1.Position+1)*unitcount)
//											{
//												this.progressBarControl1.Position++;
//												this.Refresh();
//											}
//										}
//										else
//										{
//											this.progressBarControl1.Position=40;
//											this.Refresh();
//										}
									}
									#endregion
									break;
								case "INTGTOL":
									#region �ϴ�������־����
									if(SysInitial.MainDept)
									{
										CMSMStruct.IntegralStruct its=new CMSMData.CMSMStruct.IntegralStruct();
										err=null;
										if(!sts.IntegralParseLine(strLine,",",out its,out err))
										{
											MessageBox.Show("ת���ϴ�����ʱ����ϵͳ���Զ������������ϣ������ϴ���","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
										err=null;
										if(!ca.UpIntegralData(its,out strFlag,out err))
										{
											MessageBox.Show("�ϴ����ݳ������ţ�" + its.strCardID + " ��","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
//										if(strFlag=="YES")
//											upcount++;
//										curcount++;
//										if(curcount<reTolCount)
//										{
//											if(curcount==(this.progressBarControl1.Position+1)*unitcount)
//											{
//												this.progressBarControl1.Position++;
//												this.Refresh();
//											}
//										}
//										else
//										{
//											this.progressBarControl1.Position=40;
//											this.Refresh();
//										}
									}
									#endregion
									break;
								case "FILLTOL":
									#region �ϴ���ֵ��־����
									if(SysInitial.MainDept)
									{
										CMSMStruct.FillFeeStruct ffs=new CMSMData.CMSMStruct.FillFeeStruct();
										err=null;
										if(!sts.FillParseLine(strLine,",",out ffs,out err))
										{
											MessageBox.Show("ת���ϴ�����ʱ����ϵͳ���Զ������������ϣ������ϴ���","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
										err=null;
										if(!ca.UpFillData(ffs,out strFlag,out err))
										{
											MessageBox.Show("�ϴ����ݳ������ţ�" + ffs.strCardID + " ��","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
//										if(strFlag=="YES")
//											upcount++;
//										curcount++;
//										if(curcount<reTolCount)
//										{
//											if(curcount==(this.progressBarControl1.Position+1)*unitcount)
//											{
//												this.progressBarControl1.Position++;
//												this.Refresh();
//											}
//										}
//										else
//										{
//											this.progressBarControl1.Position=40;
//											this.Refresh();
//										}
									}
									#endregion
									break;
								case "BUSSTOL":
									#region �ϴ�Ӫҵ��־
									if(SysInitial.MainDept)
									{
										CMSMStruct.BusiLogStruct blogs=new CMSMData.CMSMStruct.BusiLogStruct();
										err=null;
										if(!sts.BusiLogParseLine(strLine,",",out blogs,out err))
										{
											MessageBox.Show("ת���ϴ�����ʱ����ϵͳ���Զ������������ϣ������ϴ���","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
										err=null;
										if(!ca.UpBusiLogData(blogs,out strFlag,out err))
										{
											MessageBox.Show("�ϴ����ݳ������ţ�" + blogs.strCardID + " ��","ϵͳ��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
											if(err!=null)
											{
												clog.WriteLine(err);
											}
											continue;
										}
//										if(strFlag=="YES")
//											upcount++;
//										curcount++;
//										if(curcount<reTolCount)
//										{
//											if(curcount==(this.progressBarControl1.Position+1)*unitcount)
//											{
//												this.progressBarControl1.Position++;
//												this.Refresh();
//											}
//										}
//										else
//										{
//											this.progressBarControl1.Position=40;
//											this.Refresh();
//										}
									}
									#endregion
									break;
							}
						}
						fReader.Close();

						err=null;
						if(SysInitial.MainDept)
						{
							//���ܵ��ϴ��ֵ����ݣ�������Ա���ϣ����ѣ�Ӫҵ��־�ȵ�
							ca.UpAllData(filePath,UpFileName,out err);
						}
						else
						{
							//�ڷֵ��ϴ����������ݣ�ֻ�ϴ���Ա����
							ca.UpOtherDeptData(filePath,UpFileName,out err);
						}

						System.IO.File.Delete(filePath+UpFileName+".tmp");
					}
					if(err!=null)
					{
						this.listBox1.Items.Add("�ϴ�����ʧ�ܣ������ԣ�");
						this.listBox1.Items.Add(err.ToString());
						return;
					}

					if(System.IO.File.Exists(filePath+UpFileName))
						System.IO.File.Delete(filePath+UpFileName);
					this.listBox1.Items.Add("\n");
					this.listBox1.Items.Add("�ϴ�������ɣ�");
					this.listBox1.Items.Add("\n");
					this.listBox1.Items.Add("\n");
					this.Refresh();
				}
			}
		}
	}
}
