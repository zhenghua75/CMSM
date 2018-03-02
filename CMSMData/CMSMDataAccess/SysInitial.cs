using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using cc;
using System.Xml;
using System.Collections;


namespace CMSMData.CMSMDataAccess
{
	/// <summary>
	/// SysInitial 的摘要说明。
	/// </summary>
	public class SysInitial
	{
		static public SqlConnection con=new SqlConnection();
		static public string strDesFlag=System.Configuration.ConfigurationManager.AppSettings["DFLAG"].ToString();
        static public string ConString = System.Configuration.ConfigurationManager.ConnectionStrings["DBAMSCM"].ConnectionString;//System.Configuration.ConfigurationSettings.AppSettings["DBAMSCM"].ToString();
		static public string CenterConString=System.Configuration.ConfigurationManager.AppSettings["DBCenter"].ToString();
		static public int IdleTime=int.Parse(System.Configuration.ConfigurationManager.AppSettings["IdleTime"].ToString());
		static public DataSet dsSys=new DataSet();
		static public CMSMData.CMSMStruct.OperStruct NewOps=new CMSMData.CMSMStruct.OperStruct();
		static public CMSMData.CMSMStruct.OperStruct CurOps=new CMSMData.CMSMStruct.OperStruct();
		static public string LocalDept="";
        static public string LocalDeptName = "";
		static public string CP="";
		static public string TP="";
		static public string Card="";
		static public string Local="";
		static public string Tel="";
		static public bool MainDept=false;
		static public bool ReLoginFlag=false;
		static public DateTime dtQLTime=new DateTime(1900,1,1);
		static public string strTmp="";
		static public Int16 intCom=0;
		static public SqlDataAdapter daptmp;
		static public Hashtable hsOperFunc;

		public SysInitial()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		static public void desConstring(string strpath)
		{
			string strdes="";
			if(strDesFlag=="0")
			{		
				XmlDocument doc=new XmlDocument();
				doc.Load(strpath+@"\CMSM.exe.config");
				XmlNode keyNode=null;

				DESEncryptor dese=new DESEncryptor();
				dese.InputString=ConString;
				dese.EncryptKey="cmsmyykx";
				dese.DesEncrypt();
				strdes=dese.OutString;
				dese=null;
                keyNode = doc.SelectSingleNode("/configuration/connectionStrings/add[@name='DBAMSCM']");
                keyNode.Attributes["connectionString"].Value = strdes;

				dese=new DESEncryptor();
				dese.InputString=CenterConString;
				dese.EncryptKey="cmsmyykx";
				dese.DesEncrypt();
				strdes=dese.OutString;
				dese=null;
				keyNode=doc.SelectSingleNode("/configuration/appSettings/add[@key='DBCenter']");
				keyNode.Attributes["value"].Value=strdes;

				keyNode=doc.SelectSingleNode("/configuration/appSettings/add[@key='DFLAG']");
				keyNode.Attributes["value"].Value="1";
				doc.Save(strpath+@"\CMSM.exe.config");
			}
			else
			{
				DESEncryptor dese=new DESEncryptor();
				dese.InputString=ConString;
				dese.DecryptKey="cmsmyykx";
				dese.DesDecrypt();
				strdes=dese.OutString;
				dese=null;
				ConString=strdes;

				dese=new DESEncryptor();
				dese.InputString=CenterConString;
				dese.DecryptKey="cmsmyykx";
				dese.DesDecrypt();
				strdes=dese.OutString;
				dese=null;
				CenterConString=strdes;
			}
		}

		static public void CreatDS(out Exception e)
		{
			try
			{
				string FileName="comset.bet";
				string filePath=Environment.CurrentDirectory;
				if(!System.IO.File.Exists(filePath+@"\"+FileName))
				{
					intCom=0;
				}
				else
				{
					StreamReader fReader = new StreamReader(filePath+@"\"+FileName);
					string strline="";
					if((strline=fReader.ReadLine())==null)
					{
						intCom=0;
					}
					else
					{
						intCom=Int16.Parse(strline.Substring(8,strline.Length-8));
					}
				}
                CommAccess ca10 = new CommAccess(ConString);
                Exception er = null;
                LocalDeptName = ca10.GetLocalDept(out LocalDeptName, out er);
                if (er != null)
                {
                    e = er;
                    return;
                }

				con.ConnectionString=ConString;
				dsSys.Tables.Clear();
				string sql;

				sql="select * from tbCommCode where vcCommSign='AT' order by vcCommCode";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"AT");

				sql="select * from tbCommCode where vcCommSign='AT' and substring(vcComments,1,1)='Y' order by vcCommCode";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"AT1");

				sql="select * from tbCommCode where vcCommSign='AS'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"AS");

				sql="select * from tbCommCode where vcCommSign='ERR'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"ERR");

				sql="select * from tbCommCode where vcCommSign='GT'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"GoodsGT");

				sql="select * from tbCommCode where vcCommSign='OP'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"OP");

				sql="select distinct vcAssName,vcSpell from tbAssociator";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"AssSpell");

				sql="select distinct vcGoodsName,vcSpell from tbGoods";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"GoodsSpell");

				sql="select * from tbGoods";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"Goods");

                sql = "select vcOperID,vcOperName,vcLimit,vcDeptID,IsDiscount from tbOper";// "select * from tbOper";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"Oper");

				sql="select * from tbCommCode where vcCommSign='LM' ";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"LM");

				sql="select * from tbCommCode where vcCommCode='LM003' and vcCommSign='LM'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"LM2");

				sql="select * from tbCommCode where vcCommCode<>'LM003' and vcCommSign='LM'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"LM3");

				sql="select * from tbCommCode where vcCommSign='IG'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"IG");

				//sql="select * from tbCommCode where vcCommSign='FP1'";
				sql="if exists (select * from tbCommCode where vcCommSign=(select 'FP1-'+vcCommCode from tbCommCode where vcCommSign='local')) "
+" select * from tbCommCode where vcCommSign=(select 'FP1-'+vcCommCode from tbCommCode where vcCommSign='local') else select * from tbCommCode where vcCommSign='FP1'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"FP1");

				//sql="select * from tbCommCode where vcCommSign='FP2'";
				sql="if exists (select * from tbCommCode where vcCommSign=(select 'FP2-'+vcCommCode from tbCommCode where vcCommSign='local')) "
					+" select * from tbCommCode where vcCommSign=(select 'FP2-'+vcCommCode from tbCommCode where vcCommSign='local') else select * from tbCommCode where vcCommSign='FP2'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"FP2");

				//sql="select * from tbCommCode where vcCommSign='FP3'";
				sql="if exists (select * from tbCommCode where vcCommSign=(select 'FP3-'+vcCommCode from tbCommCode where vcCommSign='local')) "
					+" select * from tbCommCode where vcCommSign=(select 'FP3-'+vcCommCode from tbCommCode where vcCommSign='local') else select * from tbCommCode where vcCommSign='FP3'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"FP3");

				//sql="select * from tbCommCode where vcCommSign='FP4'";
				sql="if exists (select * from tbCommCode where vcCommSign=(select 'FP4-'+vcCommCode from tbCommCode where vcCommSign='local')) "
					+" select * from tbCommCode where vcCommSign=(select 'FP4-'+vcCommCode from tbCommCode where vcCommSign='local') else select * from tbCommCode where vcCommSign='FP4'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"FP4");

				//sql="select * from tbCommCode where vcCommSign='FP5'";
				sql="if exists (select * from tbCommCode where vcCommSign=(select 'FP5-'+vcCommCode from tbCommCode where vcCommSign='local')) "
					+" select * from tbCommCode where vcCommSign=(select 'FP5-'+vcCommCode from tbCommCode where vcCommSign='local') else select * from tbCommCode where vcCommSign='FP5'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"FP5");

				sql="select * from tbCommCode where vcCommSign='FP6'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"FP6");

				sql="select * from tbCommCode where vcCommSign='GT' order by vcCommCode ";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"GT");

				sql="select * from tbCommCode where vcCommSign='PT'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"PT");

				sql="select * from tbCommCode where vcCommSign='MD' and vcCommCode<>'CEN00'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"MD");

				sql="select * from tbCommCode where vcCommSign='BF'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"BF");

				sql="select * from tbCommCode where vcCommSign='DE'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"DE");

				sql="select * from tbCommCode where vcCommSign='ES'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"ES");

				sql="select * from tbCommCode where vcCommSign='OF'";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"OF");

				sql="select * from tbCommCode where vcCommSign='SFlag' and vcCommCode not in('1','2')";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dsSys,"SFlag");

				DataTable dtoperfunc=new DataTable();
                //sql="select * from tbOperFunc where vcFuncAddress in(select cnvcFuncAddress from tbFunc where cnvcFuncType='CS') order by vcOperID,vcFuncAddress";
                sql = "select * from tbOperFunc  order by vcOperID,vcFuncAddress";
				daptmp=new SqlDataAdapter(sql,con);
				daptmp.Fill(dtoperfunc);
				ArrayList aloperfunc=new ArrayList();
				hsOperFunc=new Hashtable();
				foreach(DataRow dr in dtoperfunc.Rows)
				{
					if(hsOperFunc.ContainsKey(dr["vcOperID"].ToString()))
					{
						aloperfunc=(ArrayList)hsOperFunc[dr["vcOperID"].ToString()];
						CMSMStruct.OperFuncStruct ops=new CMSMData.CMSMStruct.OperFuncStruct();
						ops.strOperID=dr["vcOperID"].ToString();
						ops.strFuncName=dr["vcFuncName"].ToString();
						ops.strFuncAddress=dr["vcFuncAddress"].ToString();
						aloperfunc.Add(ops);
					}
					else
					{
						aloperfunc=new ArrayList();
						CMSMStruct.OperFuncStruct ops=new CMSMData.CMSMStruct.OperFuncStruct();
						ops.strOperID=dr["vcOperID"].ToString();
						ops.strFuncName=dr["vcFuncName"].ToString();
						ops.strFuncAddress=dr["vcFuncAddress"].ToString();
						aloperfunc.Add(ops);
						hsOperFunc.Add(dr["vcOperID"].ToString(),aloperfunc);
					}
				}

				con.Open();
				sql="select vcCommName from tbCommCode where vcCommSign='SPF' and vcCommCode='Q1'";
				SqlCommand cmd=new SqlCommand(sql,con);
				SqlDataReader drr=cmd.ExecuteReader();
				drr.Read();
				string strQLTime=drr[0].ToString();
				drr.Close();
				con.Close();
				dtQLTime=new DateTime(int.Parse(strQLTime.Substring(0,4)),int.Parse(strQLTime.Substring(5,2)),int.Parse(strQLTime.Substring(8,2)));

				CommAccess ca1=new CommAccess(ConString);
				LocalDept=ca1.GetLocalDept(out er);
				if(er!=null)
				{
					e=er;
					return;
				}

				CommAccess ca11=new CommAccess(ConString);
			    er=null;
				CP=ca11.GetCP(out er);
				if(er!=null)
				{
					e=er;
					return;
				}

				
				CommAccess ca2=new CommAccess(ConString);
				er=null;
				Card=ca2.GetCard(out er);
				if(er!=null)
				{
					e=er;
					return;
				}

				CommAccess ca3=new CommAccess(ConString);
				er=null;
				Tel=ca3.GetTel2(out er);
				if(er!=null)
				{
					e=er;
					return;
				}

				CommAccess ca4=new CommAccess(ConString);
				er=null;
				TP=ca4.GetTP(out er);
				if(er!=null)
				{
					e=er;
					return;
				}

				er=null;
				MainDept=ca4.GetMainDept(out er);
				if(er!=null)
				{
					e=er;
					return;
				}


				e=null;
			}
			catch(Exception err)
			{
				e=err;
			}
		}

        static public void GetLocalDept(out Exception e)
        {
            try
            {
                CommAccess ca = new CommAccess(ConString);
                Exception er = null;
                LocalDept = ca.GetLocalDept(out er);
                if (er != null)
                {
                    e = er;
                    return;
                }
                e = null;
            }
            catch (Exception err)
            {
                e = err;
            }
        }
	}
}
