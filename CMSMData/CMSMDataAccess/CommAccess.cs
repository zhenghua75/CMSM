using System;
using System.Data;
using System.Data.SqlClient;
using CardCommon.CardRef;
using CMSMData;
using System.Text;
using System.Collections;
using System.Threading;	
using System.IO;
using CMSMData.CMSMDataAccess;

namespace CMSMData.CMSMDataAccess
{
	public enum TableOperType
	{
		Insert=0,
		Update=1,
		Delete=2,
	}

	public enum AnchorType
	{
		ProductionInStorage=0,
		SaleCheck=1,
	}
	/// <summary>
	/// CommAccess 的摘要说明。
	/// </summary>
	public class CommAccess
	{
		SqlConnection conCenter=new SqlConnection(SysInitial.CenterConString);
		public SqlConnection con=new SqlConnection();
		SqlCommand cmd;
		SqlCommand cmd1;
		SqlDataReader drr;
		SqlDataReader drr1;

		private string sql1,sql2,sql3,sql4,sql5,sql6,sql7,sql8,sql9,sql10;


		public CommAccess(string strconstring)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			con.ConnectionString=strconstring;
			//
		}

		public DataTable GetAssFillLast(string strCardID, out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtFill=new DataTable();
			try
			{
				err=null;
				DateTime dtnow=DateTime.Now;
				string strBefore1Hour=dtnow.AddHours(-4).ToShortDateString()+" "+dtnow.AddHours(-4).ToLongTimeString();
                sql1 = "select * from tbFillFee where vcCardID='" + strCardID + "'  and iSerial=(select max(iSerial) from tbFillFee where vcCardID='" + strCardID + "' and  vcComments='' and dtFillDate>='" + strBefore1Hour + "')";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtFill);

				if(dtFill.Rows.Count==0)
				{
					err=new Exception("在最近4小时内没有充值记录！");
					return null;
				}
				else if(decimal.Parse(dtFill.Rows[0]["nFillFee"].ToString())<=0)
				{
					err=new Exception("在最近4小时内充值后已有消费！");
					return null;
				}
				else
				{
					return dtFill;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
		}

        public string GetRegister(string strHddSerialNo, out Exception err)
        {
            this.MaskSqlToNull();
            string strRet = "";
            try
            {
                err = null;
                con.Open();
                sql1 = "select cnvcRegister from tbRegister where cnvcHddSerialNo='" + strHddSerialNo + "'";
                cmd = new SqlCommand(sql1, con);
                strRet = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                err = e;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return strRet;
        }

        public string GetLocalDept(out string strDeptName, out Exception err)
        {
            this.MaskSqlToNull();
            strDeptName = "";
            string strDeptID = "";
            err = null;
            try
            {
                con.Open();
                sql1 = "select count(*) from tbCommCode where vcCommSign='LOCAL'";
                cmd = new SqlCommand(sql1, con);
                drr = cmd.ExecuteReader();
                drr.Read();
                strDeptName = drr[0].ToString();
                drr.Close();
                if (strDeptName == "0")
                {
                    strDeptName = "";
                    strDeptID = "";
                }
                else
                {
                    sql1 = "select vcCommCode,vcCommName from tbCommCode where vcCommSign='LOCAL'";
                    cmd = new SqlCommand(sql1, con);
                    drr = cmd.ExecuteReader();
                    drr.Read();
                    strDeptID = drr[0].ToString();
                    strDeptName = drr[1].ToString();
                    drr.Close();
                }
            }
            catch (Exception e)
            {
                err = e;
                return null;
            }
            finally
            {
                con.Close();
            }
            return strDeptName;
        }

        public string Register(string strHddSerialNo, string strDeptName, string strOperName, out Exception err)
        {
            this.MaskSqlToNull();
            SqlConnection concenter = new SqlConnection(SysInitial.CenterConString);
            try
            {
                concenter.Open();
            }
            catch (Exception e1)
            {
                err = e1;
                return "connection";
            }
            using (SqlTransaction trans = concenter.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    err = null;
                    sql1 = "insert into tbRegister(cnvcHddSerialNo,cnvcDeptName,cnvcOperName,cndOperDate) values('" + strHddSerialNo + "','" + strDeptName + "','" + strOperName + "',getdate())";
                    cmd = new SqlCommand(sql1, concenter, trans);
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    err = e;
                }
                finally
                {
                    concenter.Close();
                }
            }
            return "";
        }

		public string SpecialCons(CMSMData.CMSMStruct.ConsItemStruct cis,string strOperType,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			string strSerial="";
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
                    //sql1="INSERT INTO tbConsSerialNo (vcFill) VALUES ('0');SELECT scope_identity()";
                    //cmd=new SqlCommand(sql1,con,trans);
                    //drr=cmd.ExecuteReader();
                    //drr.Read();
                    //strSerial=drr[0].ToString();
                    //drr.Close();

					for(int i=0;i<cis.dtItem.Rows.Count;i++)
					{
						sql1+="insert into tbConsItem values(" + cis.iSerial + ",'" + cis.dtItem.Rows[i]["GoodsID"].ToString() + "'," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dtItem.Rows[i]["Price"].ToString() + "," + cis.dtItem.Rows[i]["Count"].ToString() + ",";
						sql1+=cis.dtItem.Rows[i]["Rate"].ToString() + "," + cis.dtItem.Rows[i]["Fee"].ToString() + ",'" + cis.strComments + "','0','" + cis.strOperDate + "','" + cis.strOperName + "','" + cis.strDeptID + "');";
					}
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbBill values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dTRate.ToString() + "," + cis.dTolCharge.ToString() + "," + cis.dPay.ToString() + "," + cis.dBalance.ToString() + ",0,'";
					sql2+=cis.strConsType + "','" + cis.strOperName + "','" + cis.strOperDate + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

                    sql3 = "insert into tbBusiLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "','" + strOperType + "','" + cis.strOperName + "','" + cis.strOperDate + "','','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
					return strSerial;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					strSerial="";
					return strSerial;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public string AssFillRemove(CMSMStruct.FillFeeStruct ffs,int iCurIg,double dChargeCurBak,string strOldDate, out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					CardM1 cm=new CardM1(SysInitial.intCom);
					err=null;
					sql1="update tbFillFee set vcComments='充值撤消' where vcCardID='"+ffs.strCardID+"' and iSerial="+ffs.strSerial;
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    sql2 = "insert into tbFillFee values('" + ffs.strSerial + "9'," + ffs.strAssID + ",'" + ffs.strCardID + "'," + ffs.dFillFee.ToString() + "," + ffs.dFillProm.ToString() + "," + ffs.dFeeLast.ToString() + "," + ffs.dFeeCur.ToString() + ",'" + ffs.strFillDate + "','" + ffs.strComments + "','" + ffs.strOperName + "','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

                    sql3 = "insert into tbBusiLog values('" + ffs.strSerial + "9'," + ffs.strAssID + ",'" + ffs.strCardID + "','OP013','" + ffs.strOperName + "','" + ffs.strFillDate + "','会员充值撤消" + (-ffs.dFillFee).ToString() + "元','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql8="select iSerial from tbBusiLog where vcCardID='" + ffs.strCardID + "' and vcOperType='OP003' and dtOperDate='" +strOldDate + "'";
					cmd=new SqlCommand(sql8,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strserial=drr[0].ToString();
					drr.Close();

					sql7="insert into tbAssociatorLog SELECT " + strserial + ", [iAssID], [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag],'充值撤销', [dtCreateDate], [dtOperDate], [vcDeptID],'" + ffs.strOperName + "','" + ffs.strDeptID + "'  FROM [tbAssociator] where vcCardID='"+ffs.strCardID+"'";
					cmd=new SqlCommand(sql7,con,trans);
					cmd.ExecuteNonQuery();

					sql4="update tbAssociator set nCharge=" + ffs.dFeeCur.ToString() + ",dtOperDate='" + ffs.strFillDate + "' where vcCardID='" + ffs.strCardID + "' and vcAssState='0'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql4,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql6="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue],  [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+ffs.strCardID+"'";
					cmd1=new SqlCommand(sql6,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql5="select count(*) from tbFillFee where vcCardID='" + ffs.strCardID + "' and dtFillDate='" + ffs.strFillDate + "' and nFeeCur=" + dChargeCurBak.ToString();
					cmd=new SqlCommand(sql5,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr[0].ToString()!="1")
					{
						strresult="充值写入库的值不对！";
						drr.Close();
					}
					else
					{
						drr.Close();						
						strresult=cm.FillWriteCard(ffs.dFeeCur,dChargeCurBak,iCurIg);
						int j=0;
						while(j<9 &&(strresult=="RF039"||strresult=="RF040"))
						{
							strresult=cm.FillWriteCard(ffs.dFeeCur,dChargeCurBak,iCurIg);
							j++;
						}
						//						strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					}

					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						if(strresult.Substring(0,3)!="CMT")
						{
							trans.Rollback();
							trans1.Rollback();
						}
						else
						{
							trans.Commit();
							trans1.Commit();
						}
					}
					else
					{
						trans.Commit();
						trans1.Commit();
					}
					
					return strresult;					
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		#region Associator operation
		public CMSMStruct.AssociatorStruct GetAssociatorRelease(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			CMSMStruct.AssociatorStruct asstmp=new CMSMData.CMSMStruct.AssociatorStruct();
			try
			{
				conCenter.Open();
				err=null;
				sql1="select [iAssID], [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID] from tbAssociator where vcCardID='" + strCardID + "' and vcAssState='1'";
				cmd1=new SqlCommand(sql1,conCenter);
				SqlDataAdapter da=new SqlDataAdapter(cmd1);
				da.Fill(dtAss);
				if(dtAss!=null&&dtAss.Rows.Count>0)
				{
					asstmp.strAssID=dtAss.Rows[0]["iAssID"].ToString();
					asstmp.strCardID=dtAss.Rows[0]["vcCardID"].ToString();
					asstmp.strAssName=dtAss.Rows[0]["vcAssName"].ToString();
					asstmp.strSpell=dtAss.Rows[0]["vcSpell"].ToString();
					asstmp.strAssNbr=dtAss.Rows[0]["vcAssNbr"].ToString();
					asstmp.strLinkPhone=dtAss.Rows[0]["vcLinkPhone"].ToString();
					asstmp.strLinkAddress=dtAss.Rows[0]["vcLinkAddress"].ToString();
					asstmp.strEmail=dtAss.Rows[0]["vcEmail"].ToString();
					asstmp.strAssType=dtAss.Rows[0]["vcAssType"].ToString();
					asstmp.strAssState=dtAss.Rows[0]["vcAssState"].ToString();
					asstmp.dCharge=Double.Parse(dtAss.Rows[0]["nCharge"].ToString());
					asstmp.iIgValue=int.Parse(dtAss.Rows[0]["iIgValue"].ToString());
					asstmp.strComments=dtAss.Rows[0]["vcComments"].ToString();
					asstmp.strCreateDate=dtAss.Rows[0]["dtCreateDate"].ToString();
					asstmp.strOperDate=dtAss.Rows[0]["dtOperDate"].ToString();
					asstmp.strDeptID=dtAss.Rows[0]["vcDeptID"].ToString();
				}
				else
				{
					asstmp=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				conCenter.Close();
			}
			return asstmp;
		}
		public DataTable GetAssociator(Hashtable htPara, out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strCardID"].ToString()!=""&&htPara["strCardID"].ToString()!="*")
				{
					strCondition=" vcCardID like '%" + htPara["strCardID"].ToString() + "%'";
				}
				if(htPara["strAssName"].ToString()!=""&&htPara["strAssName"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" vcAssName like '%" + htPara["strAssName"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and vcAssName like '%" + htPara["strAssName"].ToString() + "%'";
					}
				}
                
				if (htPara["strDeptID"].ToString()!="" )	
				{
					sql1+=" and vcDeptID='"+ htPara["strDeptID"].ToString() +"'";
				}
				if (htPara["strPhone"].ToString()!="" )	
				{
					sql1+=" and vcLinkPhone like '%"+ htPara["strPhone"].ToString() +"%'";
				}

                if (htPara["strType1"].ToString() == "all")
                {
                    sql1 = "select [iAssID], [vcCardID], [vcAssName], [vcLinkPhone], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcDeptID], [dtCreateDate], [dtOperDate], [vcComments],[vcAssNbr], [vcLinkAddress], [vcEmail], [vcSpell]  from tbAssociator where vcCardID<>'V9999' and vcAssType<>'AT999' and dtCreateDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "'";
                }
                else
                {
                    sql1 = "select [iAssID], [vcCardID], [vcAssName], [vcLinkPhone], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcDeptID], [dtCreateDate], [dtOperDate], [vcComments],[vcAssNbr], [vcLinkAddress], [vcEmail], [vcSpell]  from tbAssociator where vcCardID<>'V9999' and vcAssType<>'AT999' and vcAssState='" + htPara["strType1"].ToString() + "' and dtCreateDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "'";
                }

				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" order by vcAssName,vcDeptID";
//				cmd=new SqlCommand(sql1,con);
				cmd=new SqlCommand(sql1,conCenter);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
				dtAss.Columns.Remove("vcCardFlag");
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtAss;
		}
		public DataTable GetRollAssociator(string strCardID,string strAssName,string strDeptId,string strPhone,string strBegin,string strEnd, out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(strCardID!=""&&strCardID!="*")
				{
					strCondition=" vcCardID like '%" + strCardID + "%'";
				}
				if(strAssName!=""&&strAssName!="*")
				{
					if(strCondition=="")
					{
						strCondition=" vcAssName like '%" + strAssName + "%'";
					}
					else
					{
						strCondition=strCondition + " and vcAssName like '%" + strAssName + "%'";
					}
				}
				if(strCondition=="")
				{
					strCondition=" dtOperDate between '" + strBegin + "' and '" + strEnd + "'";
				}
				else
				{
					strCondition=strCondition + " and dtOperDate between '" + strBegin + "' and '" + strEnd + "'";
				}
				sql1="select [iAssID], [vcCardID], [vcAssName], [vcLinkPhone], [vcSpell], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcDeptID], [dtCreateDate],[vcAssNbr], [vcLinkAddress], [vcEmail], [dtOperDate], [vcComments]  from tbAssociatorLog where vcCardID<>'V9999' and vcAssType<>'AT999' and vcAssState='3' ";

				if (strDeptId!="" )	
				{
					sql1+=" and vcDeptID='"+ strDeptId +"'";
				}
				if (strPhone!="" )	
				{
					sql1+=" and vcLinkPhone like '%"+ strPhone +"%'";
				}
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" order by vcAssName,vcDeptID";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
				dtAss.Columns.Remove("vcCardFlag");
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtAss;
		}
		public DataTable GetAssLost(string strCardID,string strAssName,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			try
			{
				conCenter.Open();
				err=null;
				string strCondition="";
				if(strCardID!=""&&strCardID!="*")
				{
					strCondition=" vcCardID='" + strCardID + "'";
				}
				if(strAssName!=""&&strAssName!="*")
				{
					if(strCondition=="")
					{
						strCondition=" vcAssName='" + strAssName + "'";
					}
					else
					{
						strCondition=strCondition + " and vcAssName='" + strAssName + "'";
					}
				}
				sql1="select [iAssID], [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [vcDeptID], [dtCreateDate], [dtOperDate] from tbAssociator where vcAssState='1'";
				if(strCondition!="")
				{
					sql1=sql1 + " and " + strCondition + " order by vcCardID";
				}
				cmd1=new SqlCommand(sql1,conCenter);
				SqlDataAdapter da=new SqlDataAdapter(cmd1);
				da.Fill(dtAss);
				dtAss.Columns.Remove("vcCardFlag");
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				conCenter.Close();
			}
			return dtAss;
		}

		public string InsertAssociator(CMSMStruct.AssociatorStruct ass1,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					err=null;
					string strCardSnr="";
					CardM1 cm=new CardM1(SysInitial.intCom);
					strresult=cm.ReadCardSnr(ref strCardSnr);
					if(strresult!=CardCommon.CardDef.ConstMsg.RFOK)
					{
						return strresult;
					}
					if(strCardSnr=="")
					{
						err=new Exception("读卡序列号错误！");
						return "";
					}

					sql1="insert into tbAssociator values('" + ass1.strCardID + "','" + ass1.strAssName + "','" + ass1.strSpell + "','" + ass1.strAssNbr + "','" + ass1.strLinkPhone + "','" + ass1.strLinkAddress + "','" + ass1.strEmail + "','" + ass1.strAssType + "','";
					sql1+=ass1.strAssState + "'," + ass1.dCharge.ToString() + "," + ass1.iIgValue.ToString() + ",'" + ass1.strCardFlag + "','" + ass1.strComments + "','" + ass1.strCreateDate + "','" + ass1.strOperDate + "','" + ass1.strDeptID + "','"+strCardSnr+"')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql1,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql2="select iAssID from tbAssociator where vcCardID='" + ass1.strCardID + "'";
					cmd1=new SqlCommand(sql2,conCenter,trans1);
					drr=cmd1.ExecuteReader();
					drr.Read();
					string strNewAssID=drr["iAssID"].ToString();
					drr.Close();

                    sql3 = "insert into tbBusiLog values(" + ass1.striSerial + "," + strNewAssID + ",'" + ass1.strCardID + "','OP001','" + SysInitial.CurOps.strOperName + "','" + ass1.strOperDate + "','','" + ass1.strDeptID + "')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="select iSerial from tbBusiLog where vcCardID='" + ass1.strCardID + "' and vcOperType='OP001' and dtOperDate='" + ass1.strOperDate + "'";
					cmd=new SqlCommand(sql4,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strserial=drr[0].ToString();
					drr.Close();

					sql5="insert into tbAssociatorLog values(" + strserial + "," + strNewAssID + ",'" + ass1.strCardID + "','" + ass1.strAssName + "','" + ass1.strSpell + "','" + ass1.strAssNbr + "','" + ass1.strLinkPhone + "','" + ass1.strLinkAddress + "','" + ass1.strEmail + "','" + ass1.strAssType + "','";
					sql5+=ass1.strAssState + "'," + ass1.dCharge.ToString() + "," + ass1.iIgValue.ToString() + ",'" + ass1.strCardFlag + "','" + ass1.strComments + "','" + ass1.strCreateDate + "','" + ass1.strOperDate + "','" + ass1.strDeptID + "','" + SysInitial.CurOps.strOperName + "','" + SysInitial.LocalDept + "')";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					sql6="insert into tbAssociatorSync values('" + ass1.strCardID + "','" + ass1.strAssName + "','" + ass1.strSpell + "','" + ass1.strAssNbr + "','" + ass1.strLinkPhone + "','" + ass1.strLinkAddress + "','" + ass1.strEmail + "','" + ass1.strAssType + "','";
					sql6+=ass1.strAssState + "'," + ass1.dCharge.ToString() + "," + ass1.iIgValue.ToString() + ",'" + ass1.strCardFlag + "','" + ass1.strComments + "','" + ass1.strCreateDate + "','" + ass1.strOperDate + "','" + ass1.strDeptID + "','"+strCardSnr+"',0)";
					cmd1=new SqlCommand(sql6,conCenter,trans1);
					cmd1.ExecuteNonQuery();
					
//					strresult=cm.PutOutCard(ass1.strCardID,-1,-1);
					strresult=cm.PutOutCard(ass1.strCardID,0,0,int.Parse(SysInitial.Card));
//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
						trans1.Commit();
					}
					else
					{
						trans.Rollback();
						trans1.Rollback();
					}
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		public void UpdateAssociator(CMSMStruct.AssociatorStruct assnew,CMSMStruct.AssociatorStruct assold,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string sqlset="";
				try
				{
					err=null;
					if(assnew.strAssName!=assold.strAssName)
					{
						sqlset="vcAssName='" + assnew.strAssName + "',";

						sql4="select count(*) from tbAssChange where vcCardID='" + assold.strCardID + "' and vcChangeField='vcAssName'";
						cmd=new SqlCommand(sql4,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						if(drr[0].ToString()=="0")
						{
							sql3="insert into tbAssChange values('" + assold.strCardID + "','vcAssName','" + assnew.strAssName + "','" + assnew.strOperDate + "');";
						}
						else
						{
							sql3="update tbAssChange set vcChangeValue='" + assnew.strAssName + "',dtChangeDate='" + assnew.strOperDate + "' where vcCardID='" + assold.strCardID + "' and vcChangeField='vcAssName';";
						}
						drr.Close();
					}
					if(assnew.strSpell!=assold.strSpell)
					{
						sqlset+="vcSpell='" + assnew.strSpell + "',";

						sql4="select count(*) from tbAssChange where vcCardID='" + assold.strCardID + "' and vcChangeField='vcSpell'";
						cmd=new SqlCommand(sql4,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						if(drr[0].ToString()=="0")
						{
							sql3+="insert into tbAssChange values('" + assold.strCardID + "','vcSpell','" + assnew.strSpell + "','" + assnew.strOperDate + "');";
						}
						else
						{
							sql3+="update tbAssChange set vcChangeValue='" + assnew.strSpell + "',dtChangeDate='" + assnew.strOperDate + "' where vcCardID='" + assold.strCardID + "' and vcChangeField='vcSpell';";
						}
						drr.Close();
					}
					if(assnew.strAssNbr!=assold.strAssNbr)
					{
						sqlset+="vcAssNbr='" + assnew.strAssNbr + "',";

						sql4="select count(*) from tbAssChange where vcCardID='" + assold.strCardID + "' and vcChangeField='vcAssNbr'";
						cmd=new SqlCommand(sql4,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						if(drr[0].ToString()=="0")
						{
							sql3+="insert into tbAssChange values('" + assold.strCardID + "','vcAssNbr','" + assnew.strAssNbr + "','" + assnew.strOperDate + "');";
						}
						else
						{
							sql3+="update tbAssChange set vcChangeValue='" + assnew.strAssNbr + "',dtChangeDate='" + assnew.strOperDate + "' where vcCardID='" + assold.strCardID + "' and vcChangeField='vcAssNbr';";
						}
						drr.Close();
					}
					if(assnew.strLinkPhone!=assold.strLinkPhone)
					{
						sqlset+="vcLinkPhone='" + assnew.strLinkPhone + "',";

						sql4="select count(*) from tbAssChange where vcCardID='" + assold.strCardID + "' and vcChangeField='vcLinkPhone'";
						cmd=new SqlCommand(sql4,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						if(drr[0].ToString()=="0")
						{
							sql3+="insert into tbAssChange values('" + assold.strCardID + "','vcLinkPhone','" + assnew.strLinkPhone + "','" + assnew.strOperDate + "');";
						}
						else
						{
							sql3+="update tbAssChange set vcChangeValue='" + assnew.strLinkPhone + "',dtChangeDate='" + assnew.strOperDate + "' where vcCardID='" + assold.strCardID + "' and vcChangeField='vcLinkPhone';";
						}
						drr.Close();
					}
					if(assnew.strLinkAddress!=assold.strLinkAddress)
					{
						sqlset+="vcLinkAddress='" + assnew.strLinkAddress + "',";

						sql4="select count(*) from tbAssChange where vcCardID='" + assold.strCardID + "' and vcChangeField='vcLinkAddress'";
						cmd=new SqlCommand(sql4,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						if(drr[0].ToString()=="0")
						{
							sql3+="insert into tbAssChange values('" + assold.strCardID + "','vcLinkAddress','" + assnew.strLinkAddress + "','" + assnew.strOperDate + "');";
						}
						else
						{
							sql3+="update tbAssChange set vcChangeValue='" + assnew.strLinkAddress + "',dtChangeDate='" + assnew.strOperDate + "' where vcCardID='" + assold.strCardID + "' and vcChangeField='vcLinkAddress';";
						}
						drr.Close();
					}
					if(assnew.strEmail!=assold.strEmail)
					{
						sqlset+="vcEmail='" + assnew.strEmail + "',";

						sql4="select count(*) from tbAssChange where vcCardID='" + assold.strCardID + "' and vcChangeField='vcEmail'";
						cmd=new SqlCommand(sql4,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						if(drr[0].ToString()=="0")
						{
							sql3+="insert into tbAssChange values('" + assold.strCardID + "','vcEmail','" + assnew.strEmail + "','" + assnew.strOperDate + "');";
						}
						else
						{
							sql3+="update tbAssChange set vcChangeValue='" + assnew.strEmail + "',dtChangeDate='" + assnew.strOperDate + "' where vcCardID='" + assold.strCardID + "' and vcChangeField='vcEmail';";
						}
						drr.Close();
					}
					if(assnew.strComments!=assold.strComments)
					{
						sqlset+="vcComments='" + assnew.strComments + "',";

						sql4="select count(*) from tbAssChange where vcCardID='" + assold.strCardID + "' and vcChangeField='vcComments'";
						cmd=new SqlCommand(sql4,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						if(drr[0].ToString()=="0")
						{
							sql3+="insert into tbAssChange values('" + assold.strCardID + "','vcComments','" + assnew.strComments + "','" + assnew.strOperDate + "');";
						}
						else
						{
							sql3+="update tbAssChange set vcChangeValue='" + assnew.strComments + "',dtChangeDate='" + assnew.strOperDate + "' where vcCardID='" + assold.strCardID + "' and vcChangeField='vcComments';";
						}
						drr.Close();
					}
					if(sqlset!="")
					{
						sqlset+="dtOperDate='" + assnew.strOperDate + "'";

//						sql1="update tbAssociator set " + sqlset + " where vcCardID='" + assold.strCardID + "' and iAssID=" + assold.strAssID;
						sql1="update tbAssociator set " + sqlset + " where vcCardID='" + assold.strCardID + "' ";
						cmd=new SqlCommand(sql1,con,trans);
						cmd.ExecuteNonQuery();
						cmd1=new SqlCommand(sql1,conCenter,trans1);
						cmd1.ExecuteNonQuery();

                        sql2 = "insert into tbBusiLog values(" + assnew.striSerial + "," + assold.strAssID + ",'" + assold.strCardID + "','OP002','" + SysInitial.CurOps.strOperName + "','" + assnew.strOperDate + "','','" + SysInitial.CurOps.strDeptID + "')";
						cmd=new SqlCommand(sql2,con,trans);
						cmd.ExecuteNonQuery();

//						cmd=new SqlCommand(sql3,con,trans);
//						cmd.ExecuteNonQuery();

						sql4="select iSerial from tbBusiLog where vcCardID='" + assold.strCardID + "' and vcOperType='OP002' and dtOperDate='" + assnew.strOperDate + "'";
						cmd=new SqlCommand(sql4,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						string strserial=drr[0].ToString();
						drr.Close();

						sql5="insert into tbAssociatorLog SELECT " + strserial + ",[iAssID], [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID],'" + SysInitial.CurOps.strOperName + "','" + SysInitial.LocalDept + "' from tbAssociator where vcCardID='" + assold.strCardID + "' and vcAssState='0'";
						cmd=new SqlCommand(sql5,con,trans);
						cmd.ExecuteNonQuery();

						sql6="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+assold.strCardID+"'";
						cmd=new SqlCommand(sql6,conCenter,trans1);
						cmd.ExecuteNonQuery();
					}

					trans.Commit();
					trans1.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		public CMSMStruct.AssociatorStruct GetAssociatorName(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			CMSMStruct.AssociatorStruct asstmp=new CMSMData.CMSMStruct.AssociatorStruct();
			try
			{
			    conCenter.Open();
				err=null;
				sql1="select [iAssID], [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID] from tbAssociator where vcCardID='" + strCardID + "' and vcAssState='0'";
				cmd1=new SqlCommand(sql1,conCenter);
				SqlDataAdapter da=new SqlDataAdapter(cmd1);
				da.Fill(dtAss);
				if(dtAss!=null&&dtAss.Rows.Count>0)
				{
					asstmp.strAssID=dtAss.Rows[0]["iAssID"].ToString();
					asstmp.strCardID=dtAss.Rows[0]["vcCardID"].ToString();
					asstmp.strAssName=dtAss.Rows[0]["vcAssName"].ToString();
					asstmp.strSpell=dtAss.Rows[0]["vcSpell"].ToString();
					asstmp.strAssNbr=dtAss.Rows[0]["vcAssNbr"].ToString();
					asstmp.strLinkPhone=dtAss.Rows[0]["vcLinkPhone"].ToString();
					asstmp.strLinkAddress=dtAss.Rows[0]["vcLinkAddress"].ToString();
					asstmp.strEmail=dtAss.Rows[0]["vcEmail"].ToString();
					asstmp.strAssType=dtAss.Rows[0]["vcAssType"].ToString();
					asstmp.strAssState=dtAss.Rows[0]["vcAssState"].ToString();
					asstmp.dCharge=Double.Parse(dtAss.Rows[0]["nCharge"].ToString());
					asstmp.iIgValue=int.Parse(dtAss.Rows[0]["iIgValue"].ToString());
					asstmp.strComments=dtAss.Rows[0]["vcComments"].ToString();
					asstmp.strCreateDate=dtAss.Rows[0]["dtCreateDate"].ToString();
					asstmp.dtCreateDate=(DateTime)dtAss.Rows[0]["dtCreateDate"];
					asstmp.strOperDate=dtAss.Rows[0]["dtOperDate"].ToString();
					asstmp.strDeptID=dtAss.Rows[0]["vcDeptID"].ToString();

					string strInsertDate=SysInitial.dtQLTime.ToString("yyyy-MM-dd");
					

					sql2="select count(*) from tbSetZero where vcCardID='" + strCardID + "' and dtInsertDate > '"+ strInsertDate +"'";
					cmd1=new SqlCommand(sql2,conCenter);
					drr=cmd1.ExecuteReader();
					drr.Read();
					string strcount=drr[0].ToString();
					drr.Close();
					if(strcount=="0")
						asstmp.setZeroFlag=false;
					else
						asstmp.setZeroFlag=true;

					sql3="select substring(vcComments,2,len(vcComments)-1) from tbCommCode where vcCommSign='AT' and vcCommCode='"+asstmp.strAssType+"'";
					cmd1=new SqlCommand(sql3,conCenter);
					drr=cmd1.ExecuteReader();
					drr.Read();
					string strRate=drr[0].ToString();
					drr.Close();
					asstmp.dRate=Math.Round(double.Parse(strRate),2);
				}
				else
				{
					asstmp=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				conCenter.Close();
			}
			return asstmp;
		}
        
		public CMSMStruct.AssociatorStruct GetAssociatorName_Local(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			CMSMStruct.AssociatorStruct asstmp=new CMSMData.CMSMStruct.AssociatorStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select [iAssID], [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID] from tbAssociator where vcCardID='" + strCardID + "' and vcAssState='0'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
				if(dtAss!=null&&dtAss.Rows.Count>0)
				{
					asstmp.strAssID=dtAss.Rows[0]["iAssID"].ToString();
					asstmp.strCardID=dtAss.Rows[0]["vcCardID"].ToString();
					asstmp.strAssName=dtAss.Rows[0]["vcAssName"].ToString();
					asstmp.strSpell=dtAss.Rows[0]["vcSpell"].ToString();
					asstmp.strAssNbr=dtAss.Rows[0]["vcAssNbr"].ToString();
					asstmp.strLinkPhone=dtAss.Rows[0]["vcLinkPhone"].ToString();
					asstmp.strLinkAddress=dtAss.Rows[0]["vcLinkAddress"].ToString();
					asstmp.strEmail=dtAss.Rows[0]["vcEmail"].ToString();
					asstmp.strAssType=dtAss.Rows[0]["vcAssType"].ToString();
					asstmp.strAssState=dtAss.Rows[0]["vcAssState"].ToString();
					asstmp.dCharge=Double.Parse(dtAss.Rows[0]["nCharge"].ToString());
					asstmp.iIgValue=int.Parse(dtAss.Rows[0]["iIgValue"].ToString());
					asstmp.strComments=dtAss.Rows[0]["vcComments"].ToString();
					asstmp.strCreateDate=dtAss.Rows[0]["dtCreateDate"].ToString();
					asstmp.dtCreateDate=(DateTime)dtAss.Rows[0]["dtCreateDate"];
					asstmp.strOperDate=dtAss.Rows[0]["dtOperDate"].ToString();
					asstmp.strDeptID=dtAss.Rows[0]["vcDeptID"].ToString();

					string strInsertDate=SysInitial.dtQLTime.ToString("yyyy-MM-dd");
					

					sql2="select count(*) from tbSetZero where vcCardID='" + strCardID + "' and dtInsertDate > '"+ strInsertDate +"'";
					cmd=new SqlCommand(sql2,con);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strcount=drr[0].ToString();
					drr.Close();
					if(strcount=="0")
						asstmp.setZeroFlag=false;
					else
						asstmp.setZeroFlag=true;

					sql3="select substring(vcComments,2,len(vcComments)-1) from tbCommCode where vcCommSign='AT' and vcCommCode='"+asstmp.strAssType+"'";
					cmd=new SqlCommand(sql3,con);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strRate=drr[0].ToString();
					drr.Close();
					asstmp.dRate=Math.Round(double.Parse(strRate),2);
				}
				else
				{
					asstmp=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return asstmp;
		}


		public CMSMStruct.AssociatorStruct GetAssociatorLost(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			CMSMStruct.AssociatorStruct asstmp=new CMSMData.CMSMStruct.AssociatorStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select [iAssID], [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID] from tbAssociator where vcCardID='" + strCardID + "' and vcAssState='1'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
				if(dtAss!=null&&dtAss.Rows.Count>0)
				{
					asstmp.strAssID=dtAss.Rows[0]["iAssID"].ToString();
					asstmp.strCardID=dtAss.Rows[0]["vcCardID"].ToString();
					asstmp.strAssName=dtAss.Rows[0]["vcAssName"].ToString();
					asstmp.strSpell=dtAss.Rows[0]["vcSpell"].ToString();
					asstmp.strAssNbr=dtAss.Rows[0]["vcAssNbr"].ToString();
					asstmp.strLinkPhone=dtAss.Rows[0]["vcLinkPhone"].ToString();
					asstmp.strLinkAddress=dtAss.Rows[0]["vcLinkAddress"].ToString();
					asstmp.strEmail=dtAss.Rows[0]["vcEmail"].ToString();
					asstmp.strAssType=dtAss.Rows[0]["vcAssType"].ToString();
					asstmp.strAssState=dtAss.Rows[0]["vcAssState"].ToString();
					asstmp.dCharge=Double.Parse(dtAss.Rows[0]["nCharge"].ToString());
					asstmp.iIgValue=int.Parse(dtAss.Rows[0]["iIgValue"].ToString());
					asstmp.strComments=dtAss.Rows[0]["vcComments"].ToString();
					asstmp.strCreateDate=dtAss.Rows[0]["dtCreateDate"].ToString();
					asstmp.dtCreateDate=(DateTime)dtAss.Rows[0]["dtCreateDate"];
					asstmp.strOperDate=dtAss.Rows[0]["dtOperDate"].ToString();
					asstmp.strDeptID=dtAss.Rows[0]["vcDeptID"].ToString();

					string strInsertDate=SysInitial.dtQLTime.ToString("yyyy-MM-dd");

					sql2="select count(*) from tbSetZero where vcCardID='" + strCardID + "' and dtInsertDate > '"+ strInsertDate +"'";
					cmd=new SqlCommand(sql2,con);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strcount=drr[0].ToString();
					drr.Close();
					if(strcount=="0")
						asstmp.setZeroFlag=false;
					else
						asstmp.setZeroFlag=true;
				}
				else
				{
					asstmp=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return asstmp;
		}

		public bool ChkCardIDDup(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			bool flag=true;
			try
			{
				conCenter.Open();
				err=null;
				sql1="select count(*) from tbAssociator where vcAssState='0' and vcCardID='" + strCardID + "'";
				cmd1=new SqlCommand(sql1,conCenter);
				SqlDataAdapter da=new SqlDataAdapter(cmd1);
				da.Fill(dtAss);
				if(int.Parse(dtAss.Rows[0][0].ToString())==0)
				{
					flag=false;
				}
				else
				{
					flag=true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return flag;
			}
			finally
			{
				conCenter.Close();
			}
			return flag;
		}

		public void CreatRetailAss(string strDeptID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="select count(*) from tbAssociator where vcCardID='V9999'";
					cmd=new SqlCommand(sql1,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strRetailcount=drr[0].ToString();
					drr.Close();

					if(strRetailcount=="0")
					{
						sql2="insert into tbAssociator values('V9999','零售客户','lskh','-','-','-','-','AT999','0',0,0,'0','',getdate(),getdate(),'" + strDeptID + "',null)";
						cmd=new SqlCommand(sql2,con,trans);
						cmd.ExecuteNonQuery();
					}
					
					err=null;
					sql3="select count(*) from tbAssociator where vcCardID='VMaster'";
					cmd=new SqlCommand(sql3,con,trans);
					SqlDataReader drr1=cmd.ExecuteReader();
					drr1.Read();
					string strMastercount=drr1[0].ToString();
					drr1.Close();

					if(strMastercount=="0")
					{
						sql4="insert into tbAssociator values('VMaster','门店特殊客户','mdtskh','-','-','-','-','ATMAS','0',0,0,'0','',getdate(),getdate(),'" + strDeptID + "',null)";
						cmd=new SqlCommand(sql4,con,trans);
						cmd.ExecuteNonQuery();
					}

					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public string AssUpToSilverType(string strAssID,string strCardID,int iCurIg,int iLastIg,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			string strresult="";
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
					sql1="insert into tbBusiLog values(" + strAssID + ",'" + strCardID + "','OP016','" + SysInitial.CurOps.strOperName + "',getdate(),'升级至银卡','" + SysInitial.LocalDept + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="update tbAssociator set iIgValue="+iCurIg.ToString()+",vcAssType='AT003',dtOperDate=getdate() where vcCardID='" + strCardID + "' and iAssID=" + strAssID;
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql2,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql3="insert into tbIntegralLog values("+strAssID+",'"+strCardID+"','IGT06',"+iLastIg.ToString()+",-1000,"+iCurIg.ToString()+",-1,getdate(),'"+SysInitial.CurOps.strOperName+"','升级银卡兑换：1000','"+SysInitial.LocalDept+"')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail],'AT003', [vcAssState], [nCharge],"+iCurIg.ToString()+", [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+strCardID+"'";
					cmd1=new SqlCommand(sql4,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					strresult=cm.IgChangeWriteCard(iCurIg);
					//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
						trans1.Commit();
					}
					else
					{
						trans.Rollback();
						trans1.Rollback();
					}		

					return strresult;
				}
				catch(Exception e)
				{
					trans1.Rollback();
					trans.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		public string AssUpToGoldType(string strAssType,string strAssID,string strCardID,int iCurIg,int iLastIg,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			string strresult="";
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
					sql1="insert into tbBusiLog values(" + strAssID + ",'" + strCardID + "','OP010','" + SysInitial.CurOps.strOperName + "',getdate(),'升级至金卡','" + SysInitial.LocalDept + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="update tbAssociator set iIgValue="+iCurIg.ToString()+",vcAssType='AT004',dtOperDate=getdate() where vcCardID='" + strCardID + "' and iAssID=" + strAssID;
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					if(strAssType=="AT001")
						sql3="insert into tbIntegralLog values("+strAssID+",'"+strCardID+"','IGT05',"+iLastIg.ToString()+",-2000,"+iCurIg.ToString()+",-1,getdate(),'"+SysInitial.CurOps.strOperName+"','升级金卡兑换：2000','"+SysInitial.LocalDept+"')";
					else
						sql3="insert into tbIntegralLog values("+strAssID+",'"+strCardID+"','IGT05',"+iLastIg.ToString()+",-1500,"+iCurIg.ToString()+",-1,getdate(),'"+SysInitial.CurOps.strOperName+"','升级金卡兑换：1500','"+SysInitial.LocalDept+"')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail],'AT004', [vcAssState], [nCharge],"+iCurIg.ToString()+", [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+strCardID+"'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

					strresult=cm.IgChangeWriteCard(iCurIg);
					//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}		

					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public bool AssTypeTrans(string strCardID,string strAssNewType,out double dRate,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				dRate=0;
				sql1="update tbAssociator set vcAssType='"+strAssNewType+"' where vcCardID='"+strCardID+"' and vcAssState='0'";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();

				sql2="select substring(vcComments,2,len(vcComments)-1) from tbCommCode where vcCommSign='AT' and vcCommCode='"+strAssNewType+"'";
				cmd=new SqlCommand(sql2,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				string strRate=drr[0].ToString();
				drr.Close();
				dRate=Math.Round(double.Parse(strRate),2);
			}
			catch (Exception e) 
			{
				err=e;
				dRate=0;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}
		#endregion

		#region Employee operation
		public DataTable GetEmpInfo(Hashtable htpara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtEmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="SELECT [vcCardID], [vcEmpName], [vcSex], [vcEmpNbr], [dtInDate], [vcDegree], [vcLinkPhone], [vcAddress], [vcOfficer], [vcDeptID], [vcFlag],[vcComments],[dtOperDate] FROM [tbEmployee]";
				string strCondition="";
				if(htpara["cardid"].ToString()!=""&&htpara["cardid"].ToString()!="*")
				{
					strCondition=" vcCardID='" + htpara["cardid"].ToString() + "'";
				}
				if(htpara["empname"].ToString()!=""&&htpara["empname"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" vcEmpName like '%" + htpara["empname"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and vcEmpName like '%" + htpara["empname"].ToString() + "%'";
					}
				}
				if(htpara["deptid"].ToString()!=""&&htpara["deptid"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" vcDeptID = '" + htpara["deptid"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and vcDeptID = '" + htpara["deptid"].ToString() + "'";
					}
				}
				if(htpara["phone"].ToString()!=""&&htpara["phone"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" vcLinkPhone like '%" + htpara["phone"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and vcLinkPhone like '%" + htpara["phone"].ToString() + "%'";
					}
				}
				if(strCondition!="")
				{
					sql1+=" where " + strCondition;
				}
				sql1+=" order by vcEmpName,vcDeptID";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtEmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtEmp;
		}

		public bool ChkEmpCardIDDup(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtEmp=new DataTable();
			bool flag=true;
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbEmployee where vcCardID='" + strCardID + "' and vcFlag='0'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtEmp);
				if(int.Parse(dtEmp.Rows[0][0].ToString())==0)
				{
					flag=false;
				}
				else
				{
					flag=true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return flag;
			}
			finally
			{
				con.Close();
			}
			return flag;
		}

		public string InsertEmployee(CMSMStruct.EmployeeStruct emp1,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
					sql1="insert into tbEmployee values('" + emp1.strCardID + "','" + emp1.strEmpName + "','" + emp1.strSex + "','" + emp1.strEmpNbr + "','" + emp1.strInDate + "','" + emp1.strDegree + "','" + emp1.strLinkPhone + "','" + emp1.strAddress + "','" + emp1.strPwd + "','" + emp1.strOfficer + "','" + emp1.strDeptID + "','" + emp1.strFlag + "','" + emp1.strComments + "','" + emp1.strOperDate + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					
					strresult=cm.EmpPutOutCard(emp1.strCardID,0,0);
//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public string getEmpName(string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtEmp=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select vcEmpName from tbEmployee where vcCardID='" + strCardID + "' and vcFlag='0'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				return drr[0].ToString();
			}
			catch (Exception e) 
			{
				err=e;
				return "";
			}
			finally
			{
				con.Close();
			}
		}

		public bool InsertEmpSign(CMSMStruct.EmpSignStruct es1,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="insert into tbEmpSign values('" + es1.strCardID + "','" + es1.strEmpName + "','" + es1.strSignDate + "','" + es1.strClass + "','" + es1.strSignFlag + "','" + es1.strComments + "','"+es1.strDeptID+"')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();
					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public bool ChkEmpSign(string strCardID,string strFlag,out Exception err)
		{
			this.MaskSqlToNull();
			bool flag=true;
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbEmpSign where vcCardID='" + strCardID + "' and vcSignFlag in('" + strFlag + "') and convert(char(10),dtSignDate,120)='" + DateTime.Now.ToShortDateString() + "'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				if(drr[0].ToString()=="0")
				{
					flag=false;
				}
				else
				{
					flag=true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return flag;
			}
			finally
			{
				con.Close();
			}
			return flag;
		}

		public DataTable GetSignInQuery(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtSign=new DataTable();
			try
			{
				con.Open();
				err=null;

				sql1="select vcCardID,convert(char(19),dtSignDate,120) from tbEmpSign where convert(char(8),dtSignDate,112)=convert(char(8),getdate(),112) and vcSignFlag='1' and vcDeptID='"+ SysInitial.LocalDept +"' order by dtSignDate desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtSign);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtSign;
		}

		public DataTable GetSignOutQuery(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtSign=new DataTable();
			try
			{
				con.Open();
				err=null;

				sql1="select vcCardID,convert(char(19),dtSignDate,120) from tbEmpSign where convert(char(8),dtSignDate,112)=convert(char(8),getdate(),112) and vcSignFlag='2' and vcDeptID='"+ SysInitial.LocalDept +"' order by dtSignDate desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtSign);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtSign;
		}

		public DataTable GetSignSpecQuery(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtSign=new DataTable();
			try
			{
				con.Open();
				err=null;

				sql1="select vcCardID,convert(char(19),dtSignDate,120),vcSignFlag,vcComments from tbEmpSign where convert(char(8),dtSignDate,112)=convert(char(8),getdate(),112) and vcSignFlag not in('1','2') and vcDeptID='"+ SysInitial.LocalDept +"' order by dtSignDate desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtSign);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtSign;
		}
		#endregion

		#region CardRollback 
		public string CardRollback(string strCardID,string strCharge,string strAssID,string strOperDate,double promrate,int iIG,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strRes="";
				double dLastCharge = double.Parse(strCharge);
				double dChargeTmp=dLastCharge*(100-promrate)/100;
				double dCharge = dLastCharge-dChargeTmp;
				
				if (double.Parse(strCharge)<10)
				{
					dChargeTmp=dLastCharge;
					dCharge=0;
				}
				try
				{
					CardM1 cm=new CardM1(SysInitial.intCom);
                    DateTime dtNow = DateTime.Now;
                    string striSerial = dtNow.ToString("yyyyMMddHHmmss");
					err=null;
                    sql1 = "insert into tbBusiLog values(" + striSerial  + "," + strAssID + ",'" + strCardID + "','OP017','" + SysInitial.CurOps.strOperName + "','" + strOperDate + "','回收金额为" + strCharge + "元+百分比" + promrate.ToString() + "','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="select iSerial from tbBusiLog where vcCardID='" + strCardID + "' and vcOperType='OP017' and dtOperDate='" + strOperDate + "'";
					cmd=new SqlCommand(sql2,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strserial=drr[0].ToString();
					drr.Close();

					sql4="insert into tbAssociatorLog  select '"+strserial+"',[iAssID], [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], '3', [nCharge], [iIgValue], [vcCardFlag], '卡已回收', [dtCreateDate], '" + strOperDate + "', [vcDeptID], '" + SysInitial.CurOps.strOperName + "', '" + SysInitial.CurOps.strDeptID + "'  from tbAssociator where vcCardID='"+ strCardID +"' ";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

					sql5="update tbAssociator set vcAssState='3',nCharge="+dCharge.ToString()+",vcComments='回收金额为："+ strCharge +" 元' where vcCardID='" +strCardID + "'";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql5,conCenter,trans1);
					cmd1.ExecuteNonQuery();

//					sql6="insert tbFillFee values(" + strAssID + ",'" + strCardID + "',"+ strCharge +",0,"+ strCharge +",0, '" + strOperDate + "','回收卡余额为" + strCharge + "元','" + SysInitial.CurOps.strOperName + "','" + SysInitial.CurOps.strDeptID + "')";
//					cmd=new SqlCommand(sql6,con,trans);
//					cmd.ExecuteNonQuery();

                    sql7 = "insert tbFillFee values(" + striSerial + "," + strAssID + ",'" + strCardID + "',-" + dChargeTmp + ",0,0,0, '" + strOperDate + "','回收卡退款为" + dChargeTmp + "元" + promrate.ToString() + "','" + SysInitial.CurOps.strOperName + "','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql7,con,trans);
					cmd.ExecuteNonQuery();

					sql8="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], '3', [nCharge], [iIgValue], [vcCardFlag], '回收金额为："+ strCharge +" 元', [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+strCardID+"'";
					cmd1=new SqlCommand(sql8,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql9="insert into [tbIntegralLog] values(" + strAssID + ",'" + strCardID + "','IGT06'," + iIG + ",-" + iIG + ",0,9999998, '" + strOperDate + "','" + SysInitial.CurOps.strOperName + "','回收积分为："+ iIG +" ','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql9,con,trans);
					cmd.ExecuteNonQuery();

				    strRes=cm.RecycleCard();
					if((!strRes.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
					{
						if(strRes.Substring(0,3)!="000")
						{
							drr.Close();
							trans.Rollback();
							trans1.Rollback();
						}
						else
						{
							drr.Close();
							trans.Commit();
							trans1.Rollback();
						}
					}
					else
					{
						trans.Commit();
						trans1.Commit();
					}
					
					return strRes;					
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					return strRes;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		#endregion

		#region Fill Fee
		public string FillFee(CMSMStruct.FillFeeStruct ffs,int iCurIg,double dChargeCurBak,string strZeroFlag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					CardM1 cm=new CardM1(SysInitial.intCom);
					err=null;
                    sql1 = "insert into tbFillFee values(" + ffs.iSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "'," + ffs.dFillFee.ToString() + "," + ffs.dFillProm.ToString() + "," + ffs.dFeeLast.ToString() + "," + ffs.dFeeCur.ToString() + ",'" + ffs.strFillDate + "','" + ffs.strComments + "','" + SysInitial.CurOps.strOperName + "','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    sql2 = "insert into tbBusiLog values(" + ffs.iSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "','OP003','" + SysInitial.CurOps.strOperName + "','" + ffs.strFillDate + "','充值" + ffs.dFillFee.ToString() + "元','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="update tbAssociator set nCharge=" + ffs.dFeeCur.ToString() + ",iIgValue="+iCurIg.ToString()+",dtOperDate='" + ffs.strFillDate + "' where vcCardID='" + ffs.strCardID + "' and  vcAssState='0'";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql3,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					if(strZeroFlag=="1")
					{
						sql4="insert into tbSetZero values('"+ffs.strCardID+"',getdate())";
						cmd=new SqlCommand(sql4,con,trans);
						cmd.ExecuteNonQuery();
					}

					sql5="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], "+ ffs.dFeeCur.ToString() +", "+iCurIg.ToString()+", [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where  vcCardID='"+ffs.strCardID+"'";
					cmd1=new SqlCommand(sql5,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql6="select count(*) from tbFillFee where vcCardID='" + ffs.strCardID + "' and dtFillDate='" + ffs.strFillDate + "' and nFeeCur=" + dChargeCurBak.ToString();
					cmd=new SqlCommand(sql6,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr[0].ToString()!="1")
					{
						strresult="充值写入库的值不对！";
						drr.Close();
					}
					else
					{
						drr.Close();
						strresult=cm.FillWriteCard(ffs.dFeeCur,dChargeCurBak,iCurIg);
//						strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					}

					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						if(strresult.Substring(0,3)!="CMT")
						{
							trans.Rollback();
							trans1.Rollback();
						}
						else
						{
							trans.Commit();
							trans1.Commit();
						}
					}
					else
					{
						trans.Commit();
						trans1.Commit();
					}
					
					return strresult;					
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}
		public string CardChargeUnionOut(CMSMStruct.FillFeeStruct ffs,CMSMStruct.BusiLogStruct busg,double dChargeCurBak,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					CardM1 cm=new CardM1(SysInitial.intCom);
					err=null;
                    sql1 = "insert into tbFillFee values(" + ffs.iSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "'," + ffs.dFillFee.ToString() + "," + ffs.dFillProm.ToString() + "," + ffs.dFeeLast.ToString() + "," + ffs.dFeeCur.ToString() + ",'" + ffs.strFillDate + "','" + ffs.strComments + "','" + ffs.strOperName + "','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    sql2 = "insert into tbBusiLog values(" + ffs.iSerial + "," + busg.strAssID + ",'" + busg.strCardID + "','" + busg.strOperType + "','" + busg.strOperName + "','" + busg.strOperDate + "','" + busg.strComments + "','" + busg.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="update tbAssociator set iIgValue=" + ffs.dIGCur.ToString() + ",nCharge=" + ffs.dFeeCur.ToString() + ",dtOperDate='" + ffs.strFillDate + "' where vcCardID='" + ffs.strCardID + "' and vcAssState='0'";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql3,conCenter,trans1);
					cmd1.ExecuteNonQuery();

                    sql7 = "insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], " + ffs.dFeeCur.ToString() + ", [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='" + ffs.strCardID + "' and vcAssState='0'";
					cmd1=new SqlCommand(sql7,conCenter,trans1);
					cmd1.ExecuteNonQuery();

                    sql4 = "insert into tbIntegralLog values(" + ffs.iSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "','IGT04'," + ffs.dIGLast.ToString() + ",-" + ffs.dIG.ToString() + "," + ffs.dIGCur.ToString() + ",9999999,'" + ffs.strFillDate + "','" + ffs.strOperName + "','合并转出','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

                    sql5 = "insert into tbBusiLog values(" + ffs.iSerial +9+ "," + busg.strAssID + ",'" + busg.strCardID + "','OP015','" + busg.strOperName + "','" + busg.strOperDate + "','合并转出" + ffs.dIG + "积分','" + busg.strDeptID + "')";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

                    sql8 = "insert into tbMergeOut values(" + ffs.iSerial + "," + busg.strAssID + ",'" + busg.strCardID + "'," + ffs.dFillFee.ToString() + "," + ffs.dIG.ToString() + ",'0','" + busg.strOperName + "','" + busg.strDeptID + "','" + busg.strOperDate + "','合并转出')";
                    cmd = new SqlCommand(sql8, conCenter, trans1);
                    cmd.ExecuteNonQuery();

					sql6="select count(*) from tbFillFee where vcCardID='" + ffs.strCardID + "' and dtFillDate='" + ffs.strFillDate + "' and nFeeCur=" + dChargeCurBak.ToString();
					cmd=new SqlCommand(sql6,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr[0].ToString()!="1")
					{
						strresult="合并转出写入库的值不对！";
						drr.Close();
					}
					else
					{
						drr.Close();						
						strresult=cm.UnionChargeWriteCard(ffs.dFeeCur,dChargeCurBak);
						int j=0;
						while(j<9 &&(strresult=="RF039"||strresult=="RF040"))
						{
							strresult=cm.UnionChargeWriteCard(ffs.dFeeCur,dChargeCurBak);
							j++;
						}
						strresult=cm.IgChangeWriteCard(int.Parse(ffs.dIGCur.ToString()));
						j=0;
						while(j<9 &&(strresult=="RF039"||strresult=="RF040"))
						{
							strresult=cm.UnionChargeWriteCard(ffs.dFeeCur,dChargeCurBak);
							j++;
						}
						//						strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					}

					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						if(strresult.Substring(0,3)!="CMT")
						{
							trans.Rollback();
							trans1.Rollback();
						}
						else
						{
							trans.Commit();
							trans1.Commit();
						}
					}
					else
					{
						trans.Commit();
						trans1.Commit();
					}
					
					return strresult;					
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}
		public string CardChargeUnionIn(CMSMStruct.FillFeeStruct ffs,CMSMStruct.BusiLogStruct busg,double dChargeCurBak,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					CardM1 cm=new CardM1(SysInitial.intCom);
					err=null;
                    sql1 = "insert into tbFillFee values(" + ffs.iSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "'," + ffs.dFillFee.ToString() + "," + ffs.dFillProm.ToString() + "," + ffs.dFeeLast.ToString() + "," + ffs.dFeeCur.ToString() + ",'" + ffs.strFillDate + "','" + ffs.strComments + "','" + ffs.strOperName + "','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    sql2 = "insert into tbBusiLog values(" + ffs.iSerial + "," + busg.strAssID + ",'" + busg.strCardID + "','" + busg.strOperType + "','" + busg.strOperName + "','" + busg.strOperDate + "','" + busg.strComments + "','" + busg.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="update tbAssociator set iIgValue=" + ffs.dIGCur.ToString() + ",nCharge=" + ffs.dFeeCur.ToString() + ",dtOperDate='" + ffs.strFillDate + "' where vcCardID='" + ffs.strCardID + "' and vcAssState='0'";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql3,conCenter,trans1);
					cmd1.ExecuteNonQuery();

                    sql7 = "insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], " + ffs.dFeeCur.ToString() + ", [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='" + ffs.strCardID + "' and vcAssState='0'";
					cmd1=new SqlCommand(sql7,conCenter,trans1);
					cmd1.ExecuteNonQuery();

                    sql8 = "update tbMergeOut set cFlag=1 where vcCardID='" + ffs.strCardIDOld + "' and  iSerial=" + ffs.strSerialOld + " and cFlag=0 and vcDeptID='" + busg.strDeptID + "'";
                    cmd = new SqlCommand(sql8, conCenter, trans1);
                    cmd.ExecuteNonQuery();

                    sql4 = "insert into tbIntegralLog values(" + ffs.iSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "','IGT05'," + ffs.dIGLast.ToString() + "," + ffs.dIG.ToString() + "," + ffs.dIGCur.ToString() + ",9999999,'" + ffs.strFillDate + "','" + ffs.strOperName + "','合并转入+原卡号为：" + busg.strCardID + "','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

                    sql5 = "insert into tbBusiLog values(" + ffs.iSerial +9+ "," + busg.strAssID + ",'" + busg.strCardID + "','OP015','" + busg.strOperName + "','" + busg.strOperDate + "','合并转入" + ffs.dIG.ToString() + "积分+原卡号为：" + busg.strCardID + "','" + busg.strDeptID + "')";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					sql6="select count(*) from tbFillFee where vcCardID='" + ffs.strCardID + "' and dtFillDate='" + ffs.strFillDate + "' and nFeeCur=" + dChargeCurBak.ToString();
					cmd=new SqlCommand(sql6,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr[0].ToString()!="1")
					{
						strresult="合并转入写入库的值不对！";
						drr.Close();
					}
					else
					{
						drr.Close();						
						strresult=cm.UnionChargeWriteCard(ffs.dFeeCur,dChargeCurBak);
						//IgChangeWriteCard
						int j=0;
						while(j<9 &&(strresult=="RF039"||strresult=="RF040"))
						{
							strresult=cm.UnionChargeWriteCard(ffs.dFeeCur,dChargeCurBak);
							j++;
						}
						strresult=cm.IgChangeWriteCard(int.Parse(ffs.dIGCur.ToString()));
						j=0;
						while(j<9 &&(strresult=="RF039"||strresult=="RF040"))
						{
							strresult=cm.UnionChargeWriteCard(ffs.dFeeCur,dChargeCurBak);
							j++;
						}
						//						strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					}

					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						if(strresult.Substring(0,3)!="CMT")
						{
							trans.Rollback();
							trans1.Rollback();
						}
						else
						{
							trans.Commit();
							trans1.Commit();
						}
					}
					else
					{
						trans.Commit();
						trans1.Commit();
					}
					
					return strresult;					
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

        public string CardChargeUnionOutRoll(CMSMStruct.FillFeeStruct ffs,  out Exception err)
        {
            this.MaskSqlToNull();
            con.Open();
            conCenter.Open();
            using (SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted))
            using (SqlTransaction trans1 = conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                string strresult = "";
                try
                {
                    CardM1 cm = new CardM1(SysInitial.intCom);
                    err = null;
                    sql1 = "insert into tbFillFee values(" + ffs.iSerial + 9+ "," + ffs.strAssID + ",'" + ffs.strCardID + "'," + ffs.dFillFee.ToString() + "," + ffs.dFillProm.ToString() + "," + ffs.dFeeLast.ToString() + "," + ffs.dFeeCur.ToString() + ",'" + ffs.strFillDate + "','" + ffs.strComments + "','" + ffs.strOperName + "','" + ffs.strDeptID + "')";
                    cmd = new SqlCommand(sql1, con, trans);
                    cmd.ExecuteNonQuery();

                    sql2 = "insert into tbBusiLog values(" + ffs.iSerial +99+ "," + ffs.strAssID + ",'" + ffs.strCardID + "','" + ffs.strType + "','" + ffs.strOperName + "','" + ffs.strFillDate + "','" + ffs.strComments + "','" + ffs.strDeptID + "')";
                    cmd = new SqlCommand(sql2, con, trans);
                    cmd.ExecuteNonQuery();

                    sql3 = "update tbAssociator set iIgValue=" + ffs.dIGCur.ToString() + ",nCharge=" + ffs.dFeeCur.ToString() + ",dtOperDate='" + ffs.strFillDate + "' where vcCardID='" + ffs.strCardID + "' and vcAssState='0'";
                    cmd = new SqlCommand(sql3, con, trans);
                    cmd.ExecuteNonQuery();
                    cmd1 = new SqlCommand(sql3, conCenter, trans1);
                    cmd1.ExecuteNonQuery();

                    sql7 = "insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], " + ffs.dFeeCur.ToString() + ", [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='" + ffs.strCardID + "'and vcAssState='0'";
                    cmd1 = new SqlCommand(sql7, conCenter, trans1);
                    cmd1.ExecuteNonQuery();

                    sql8 = "update tbMergeOut set cFlag=2 where vcCardID='" + ffs.strCardID + "' and  iSerial=" + ffs.iSerial + " and cFlag=0 and vcDeptID='" + ffs.strDeptID + "'";
                    cmd = new SqlCommand(sql8, conCenter, trans1);
                    cmd.ExecuteNonQuery();

                    sql4 = "insert into tbIntegralLog values(" + ffs.iSerial + 9 + "," + ffs.strAssID + ",'" + ffs.strCardID + "','IGT09'," + ffs.dIGLast.ToString() + "," + ffs.dIG.ToString() + "," + ffs.dIGCur.ToString() + ",9999999,'" + ffs.strFillDate + "','" + ffs.strOperName + "','转出撤销：" + ffs.iSerial + "','" + ffs.strDeptID + "')";
                    cmd = new SqlCommand(sql4, con, trans);
                    cmd.ExecuteNonQuery();

                    sql5 = "insert into tbBusiLog values(" + ffs.iSerial + 999 + "," + ffs.strAssID + ",'" + ffs.strCardID + "','OP019','" + ffs.strOperName + "','" + ffs.strFillDate + "','转出撤消：" + ffs.dIG.ToString() + "积分','" + ffs.strDeptID + "')";
                    cmd = new SqlCommand(sql5, con, trans);
                    cmd.ExecuteNonQuery();

                    sql6 = "select count(*) from tbFillFee where vcCardID='" + ffs.strCardID + "' and dtFillDate='" + ffs.strFillDate + "' and nFeeCur=" + ffs.dFeeCur.ToString();
                    cmd = new SqlCommand(sql6, con, trans);
                    drr = cmd.ExecuteReader();
                    drr.Read();
                    if (drr[0].ToString() != "1")
                    {
                        strresult = "合并转入写入库的值不对！";
                        drr.Close();
                    }
                    else
                    {
                        drr.Close();
                        strresult = cm.UnionChargeWriteCard(ffs.dFeeCur, ffs.dIGCur);
                        //IgChangeWriteCard
                        int j = 0;
                        while (j < 9 && (strresult == "RF039" || strresult == "RF040"))
                        {
                            strresult = cm.UnionChargeWriteCard(ffs.dFeeCur, ffs.dIGCur);
                            j++;
                        }
                        strresult = cm.IgChangeWriteCard(int.Parse(ffs.dIGCur.ToString()));
                        j = 0;
                        while (j < 9 && (strresult == "RF039" || strresult == "RF040"))
                        {
                            strresult = cm.UnionChargeWriteCard(ffs.dFeeCur, ffs.dIGCur);
                            j++;
                        }
                        //						strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
                    }

                    if (!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
                    {
                        if (strresult.Substring(0, 3) != "CMT")
                        {
                            trans.Rollback();
                            trans1.Rollback();
                        }
                        else
                        {
                            trans.Commit();
                            trans1.Commit();
                        }
                    }
                    else
                    {
                        trans.Commit();
                        trans1.Commit();
                    }

                    return strresult;
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    trans1.Rollback();
                    err = e;
                    return strresult;
                }
                finally
                {
                    con.Close();
                    conCenter.Close();
                }
            }
        }

		public string FillFeeError(CMSMStruct.FillFeeStruct ffs,int iCurIg,double dChargeCurBak,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					CardM1 cm=new CardM1(SysInitial.intCom);
					err=null;
                    sql1 = "insert into tbFillFee values(" + ffs.iSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "'," + ffs.dFillFee.ToString() + "," + ffs.dFillProm.ToString() + "," + ffs.dFeeLast.ToString() + "," + ffs.dFeeCur.ToString() + ",'" + ffs.strFillDate + "','补充值，由于操作错误','" + SysInitial.CurOps.strOperName + "','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    sql2 = "insert into tbBusiLog values(" + ffs.iSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "','OP008','" + SysInitial.CurOps.strOperName + "','" + ffs.strFillDate + "','补充值" + ffs.dFillFee.ToString() + "元','" + ffs.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="update tbAssociator set nCharge=" + ffs.dFeeCur.ToString() + ",dtOperDate='" + ffs.strFillDate + "' where vcCardID='" + ffs.strCardID + "' and vcAssState='0'";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql3,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql4="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], "+ ffs.dFeeCur.ToString() +", [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+ffs.strCardID+"'";
					cmd1=new SqlCommand(sql4,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql6="select count(*) from tbFillFee where vcCardID='" + ffs.strCardID + "' and dtFillDate='" + ffs.strFillDate + "' and nFeeCur=" + dChargeCurBak.ToString();
					cmd=new SqlCommand(sql6,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr[0].ToString()!="1")
					{
						strresult="充值写入库的值不对！";
						drr.Close();
					}
					else
					{
						drr.Close();
						strresult=cm.FillWriteCard(ffs.dFeeCur,dChargeCurBak,iCurIg);
						//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					}

					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						if(strresult.Substring(0,3)!="CMT")
						{
							trans.Rollback();
							trans1.Rollback();
						}
						else
						{
							trans.Commit();
							trans1.Commit();
						}
					}
					else
					{
						trans.Commit();
						trans1.Commit();
					}
					
					return strresult;					
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		public DataTable GetFillQuery(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strCardID"].ToString()!=""&&htPara["strCardID"].ToString()!="*")
				{
					strCondition=" a.vcCardID='" + htPara["strCardID"].ToString() + "'";
				}
				if(htPara["strAssName"].ToString()!=""&&htPara["strAssName"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" b.vcAssName = '" + htPara["strAssName"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and b.vcAssName = '" + htPara["strAssName"].ToString() + "'";
					}
				}
				if(htPara["strAssType"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" b.vcAssType='" + htPara["strAssType"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and b.vcAssType = '" + htPara["strAssType"].ToString() + "'";
					}
				}
				if(htPara["strOperName"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcOperName='" + htPara["strOperName"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcOperName = '" + htPara["strOperName"].ToString() + "'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
//				string aa=htPara["strTmp22"].ToString();
				if(htPara["strTmp22"].ToString()=="22")//全部
				{
                    sql1 = "select a.iSerial,b.vcAssName,b.vcAssType,a.vcCardID,a.nFillFee,a.nFillProm,a.nFeeLast,a.nFeeCur,a.dtFillDate,a.vcOperName,a.vcDeptID,a.vcComments from vwFillFee a,tbAssociator b where a.vcCardID=b.vcCardID   and a.dtFillDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				}
				else if(htPara["strTmp22"].ToString()=="33")//消费
				{
                    sql1 = "select a.iSerial,b.vcAssName,b.vcAssType,a.vcCardID,a.nFillFee,a.nFillProm,a.nFeeLast,a.nFeeCur,a.dtFillDate,a.vcOperName,a.vcDeptID,a.vcComments from vwFillFee a,tbAssociator b where a.vcCardID=b.vcCardID and a.nFillFee<0  and a.dtFillDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				}
				else if(htPara["strTmp22"].ToString()=="44")//银行卡充值
				{
                    sql1 = "select a.iSerial,b.vcAssName,b.vcAssType,a.vcCardID,a.nFillFee,a.nFillProm,a.nFeeLast,a.nFeeCur,a.dtFillDate,a.vcOperName,a.vcDeptID,a.vcComments from vwFillFee a,tbAssociator b where a.vcComments='银行卡' and a.vcCardID=b.vcCardID and a.nFillFee>0 and a.dtFillDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				}
				else if(htPara["strTmp22"].ToString()=="55")//现金充值
				{
                    sql1 = "select a.iSerial,b.vcAssName,b.vcAssType,a.vcCardID,a.nFillFee,a.nFillProm,a.nFeeLast,a.nFeeCur,a.dtFillDate,a.vcOperName,a.vcDeptID,a.vcComments from vwFillFee a,tbAssociator b where a.vcComments<>'银行卡' and a.vcCardID=b.vcCardID and a.nFillFee>0 and a.dtFillDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				}
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" order by a.dtFillDate ";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}
		#endregion
        public DataTable GetMaterialOut(string strCardID, out Exception err)
        {
            this.MaskSqlToNull();
            DataTable dtMaterialOut = new DataTable();
            try
            {
                conCenter.Open();
                err = null;
                sql1 += " SELECT [iSerial],[iAssID],[vcCardID],[nFillFee],[iIgGet],[vcOperName],[vcDeptID],[dtFillDate]  FROM [tbMergeOut] where cFlag=0 and vcCardID='" + strCardID + "'";
                cmd = new SqlCommand(sql1, conCenter);
                cmd.CommandTimeout = 600;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtMaterialOut);
            }
            catch (Exception e)
            {
                err = e;
                return null;
            }
            finally
            {
                conCenter.Close();
            }
            return dtMaterialOut;
        }

		#region Card Lost
		public void CardLose(string strAssID,string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
                    DateTime dtNow = DateTime.Now;
                    string strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
                    string striSerial = dtNow.ToString("yyyyMMddHHmmss");
                    //string striSerial = strOperDate.Substring(0, 4) + strOperDate.Substring(5, 2) + strOperDate.Substring(8, 2) + strOperDate.Substring(11, 2) + strOperDate.Substring(14, 2) + strOperDate.Substring(17, 2);
                    
					err=null;
                    sql1 = "insert into tbBusiLog values(" + striSerial + "," + strAssID + ",'" + strCardID + "','OP004','" + SysInitial.CurOps.strOperName + "','" + strOperDate + "','','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="update tbAssociator set vcAssState='1',dtOperDate='" + strOperDate + "' where vcCardID='" + strCardID + "' and vcAssState='0'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql2,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql3="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType],[vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+strCardID+"'";
					cmd1=new SqlCommand(sql3,conCenter,trans1);
					cmd1.ExecuteNonQuery();
					
					trans.Commit();
					trans1.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}
		#endregion
		#region Card Release
		public void CardRelease(string strAssID,string strCardID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
                    DateTime dtNow = DateTime.Now;
                    string striSerial = dtNow.ToString("yyyyMMddHHmmss");
                    string strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
                    //string striSerial = strOperDate.Substring(0, 4) + strOperDate.Substring(5, 2) + strOperDate.Substring(8, 2) + strOperDate.Substring(11, 2) + strOperDate.Substring(14, 2) + strOperDate.Substring(17, 2);
					err=null;
                    sql1 = "insert into tbBusiLog values(" + striSerial + "," + strAssID + ",'" + strCardID + "','OP018','" + SysInitial.CurOps.strOperName + "','" + strOperDate + "','','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="update tbAssociator set vcAssState='0',dtOperDate='" + strOperDate + "' where vcCardID='" + strCardID + "' and vcAssState='1'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql2,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql3="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType],'0', [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+strCardID+"'";
					cmd1=new SqlCommand(sql3,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					trans.Commit();
					trans1.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}
		#endregion
		#region Card put again
		public string CardAgain(string strNewCardID,CMSMStruct.AssociatorStruct assold,out Exception err)
		{
			this.MaskSqlToNull();
			err=null;
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					string strCardSnr="";
					CardM1 cm=new CardM1(SysInitial.intCom);
					strresult=cm.ReadCardSnr(ref strCardSnr);
					if(strresult!=CardCommon.CardDef.ConstMsg.RFOK)
					{
						return strresult;
					}
					if(strCardSnr=="")
					{
						err=new Exception("读卡序列号错误！");
						return "";
					}

                    //string strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
                    DateTime dtNow = DateTime.Now;
                    string striSerial = dtNow.ToString("yyyyMMddHHmmss");
                    string strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
					err=null;
                    sql1 = "insert into tbBusiLog values(" + striSerial + "," + assold.strAssID + ",'" + assold.strCardID + "','OP005','" + SysInitial.CurOps.strOperName + "','" + strOperDate + "','新会员：" + strNewCardID + "','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbAssociator values('" + strNewCardID + "','" + assold.strAssName + "','" + assold.strSpell + "','" + assold.strAssNbr + "','" + assold.strLinkPhone + "','" + assold.strLinkAddress + "','";
					sql2+=assold.strEmail + "','" + assold.strAssType + "','0'," + assold.dCharge.ToString() + "," + assold.iIgValue.ToString() + ",'1','原卡号为：" + assold.strCardID + "','" + strOperDate + "','" + strOperDate + "','" + SysInitial.CurOps.strDeptID + "','"+strCardSnr+"')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql2,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql3="update tbAssociator set vcAssState='2',nCharge=0,iIgValue=0,dtOperDate='" + strOperDate + "',vcComments='新卡号为：" + strNewCardID + "' where vcCardID='" + assold.strCardID + "' and vcAssState='1' ";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql3,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql4="select iAssID from tbAssociator where vcCardID='" + strNewCardID + "'";
					cmd1=new SqlCommand(sql4,conCenter,trans1);
					drr=cmd1.ExecuteReader();
					drr.Read();
					string strNewAssID=drr["iAssID"].ToString();
					drr.Close();

                    sql5 = "insert into tbFillFee values(" + striSerial + "," + strNewAssID + ",'" + strNewCardID + "'," + assold.dCharge.ToString() + ",0,0," + assold.dCharge.ToString() + ",getdate(),'补卡，原卡为：" + assold.strCardID + "','" + SysInitial.CurOps.strOperName + "','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

                    sql6 = "insert into tbFillFee values(" + striSerial +9 + "," + assold.strAssID + ",'" + assold.strCardID + "'," + (-assold.dCharge).ToString() + ",0," + assold.dCharge.ToString() + ",0,getdate(),'补卡，新卡为：" + strNewCardID + "','" + SysInitial.CurOps.strOperName + "','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

                    sql7 = "insert into tbIntegralLog values(" + striSerial + "," + strNewAssID + ",'" + strNewCardID + "','IGT03',0," + assold.iIgValue.ToString() + "," + assold.iIgValue.ToString() + "," + assold.iIgValue + ",";
					sql7+="getdate(),'" + SysInitial.CurOps.strOperName + "','补卡充入积分：" + assold.iIgValue.ToString() + "','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql7,con,trans);
					cmd.ExecuteNonQuery();

                    sql8 = "insert into tbIntegralLog values(" + striSerial +9+ "," + assold.strAssID + ",'" + assold.strCardID + "','IGT03'," + assold.iIgValue.ToString() + "," + (-assold.iIgValue).ToString() + ",0,0,";
					sql8+="getdate(),'" + SysInitial.CurOps.strOperName + "','补卡取消积分：" + assold.iIgValue.ToString() + "','" + SysInitial.CurOps.strDeptID + "')";
					cmd=new SqlCommand(sql8,con,trans);
					cmd.ExecuteNonQuery();

					if(assold.needZeroFlag)
					{
						sql7="insert into tbSetZero values('"+assold.strCardID+"',getdate())";
						cmd=new SqlCommand(sql7,con,trans);
						cmd.ExecuteNonQuery();
					}

					sql9="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType],'2', 0, 0, [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+assold.strCardID+"'";
					cmd1=new SqlCommand(sql9,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql10="insert into tbAssociatorSync values('" + strNewCardID + "','" + assold.strAssName + "','" + assold.strSpell + "','" + assold.strAssNbr + "','" + assold.strLinkPhone + "','" + assold.strLinkAddress + "','";
					sql10+=assold.strEmail + "','" + assold.strAssType + "','0'," + assold.dCharge.ToString() + "," + assold.iIgValue.ToString() + ",'1','原会员：" + assold.strCardID + "','" + strOperDate + "','" + strOperDate + "','" + SysInitial.CurOps.strDeptID + "','"+strCardSnr+"',0)";
					cmd1=new SqlCommand(sql10,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					strresult=cm.PutOutCard(strNewCardID,assold.dCharge,assold.iIgValue,int.Parse(SysInitial.Card));
//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
						trans1.Commit();
					}
					else
					{
						trans.Rollback();
						trans1.Rollback();
					}
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}
		#endregion

		#region Goods operation
		public DataTable GetGoods(string strGoodsName,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtGoods=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
//				if(strGoodsID!=""&&strGoodsID!="*")
//				{
//					strCondition=" vcGoodsID='" + strGoodsID + "'";
//				}
				if(strGoodsName!=""&&strGoodsName!="*")
				{
					if(strCondition=="")
					{
						strCondition=" vcGoodsName like '%" + strGoodsName + "%'";
					}
					else
					{
						strCondition=strCondition + " and vcGoodsName like '%" + strGoodsName + "%'";
					}
				}
				sql1="select * from tbGoods";
				if(strCondition!="")
				{
					sql1=sql1 + " where  " + strCondition + " order by vcGoodsID";
				}
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtGoods);
				dtGoods.Columns.Remove("nRate");
				dtGoods.Columns.Remove("cNewFlag");
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtGoods;
		}

		public void InsertGoods(CMSMStruct.GoodsStruct gs,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtGoods=new DataTable();
			con.Open();
			string strGoodsIDTmp="";
			if (gs.strGoodsType=="甜面类")
			{
				strGoodsIDTmp="'20','21','22','23','24','25','26'";
			}
			if (gs.strGoodsType=="欧包类")
			{
				strGoodsIDTmp="'27'";
			}
			if (gs.strGoodsType=="硬质面包类")
			{
				strGoodsIDTmp="'28'";
			}
			if (gs.strGoodsType=="丹麦类")
			{
				strGoodsIDTmp="'29'";
			}
			if (gs.strGoodsType=="吐司类")
			{
				strGoodsIDTmp="'30','31','32'";
			}
			if (gs.strGoodsType=="调理类及其它杂类")
			{
				strGoodsIDTmp="'33','34','35','36','37','38','39'";
			}
			if (gs.strGoodsType=="常温蛋糕类")
			{
				strGoodsIDTmp="'40','41','42','43','44'";
			}
			if (gs.strGoodsType=="蛋糕胚")
			{
				strGoodsIDTmp="45";
			}
			if (gs.strGoodsType=="西点类")
			{
				strGoodsIDTmp="50,51,52,53,54,55,56,57,58,59";
			}
			if (gs.strGoodsType=="生日蛋糕类")
			{
				strGoodsIDTmp="60,61,62,63,64,65,66,67,68,69";
			}
			if (gs.strGoodsType=="饼干类")
			{
				strGoodsIDTmp="70,71,72,73,74,75,76,77,78,79";
			}
			if (gs.strGoodsType=="外卖产品")
			{
				strGoodsIDTmp="80,81,82,83,84,85,86,87,88,89";
			}
			//					int recount1=0;
			//					string strGoodsID1="";

			sql1="select isnull(max(cast(vcGoodsID as numeric(10,0))),0) as maxid from tbGoods  where substring(vcGoodsID,1,2) in("+ strGoodsIDTmp + ")";
			cmd=new SqlCommand(sql1,con);
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(dtGoods);

			int strmaxid=int.Parse(dtGoods.Rows[0][0].ToString());
//			drr.Close();
			if (gs.strGoodsType=="甜面类")
			{
				if(strmaxid==0)
				{
					strmaxid=2001;
				}
				else if(strmaxid>=2699)
				{
					//							;
				}
			}
			if (gs.strGoodsType=="欧包类")
			{
				if(strmaxid==0)
				{
					strmaxid=2700;
				}
				else if(strmaxid>=2799)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="硬质面包类")
			{
				if(strmaxid==0)
				{
					strmaxid=2800;
				}
				else if(strmaxid>=2899)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="丹麦类")
			{
				if(strmaxid==0)
				{
					strmaxid=2900;
				}
				else if(strmaxid>=2999)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="吐司类")
			{
				if(strmaxid==0)
				{
					strmaxid=3001;
				}
				else if(strmaxid>=3299)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="调理类及其它杂类")
			{
				if(strmaxid==0)
				{
					strmaxid=3300;
				}
				else if(strmaxid>=3399)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="常温蛋糕类")
			{
				if(strmaxid==0)
				{
					strmaxid=4001;
				}
				else if(strmaxid>=4499)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="蛋糕胚")
			{
				if(strmaxid==0)
				{
					strmaxid=4500;
				}
				else if(strmaxid>=4599)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="西点类")
			{
				if(strmaxid==0)
				{
					strmaxid=5001;
				}
				else if(strmaxid>=5999)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="生日蛋糕类")
			{
				if(strmaxid==0)
				{
					strmaxid=6001;
				}
				else if(strmaxid>=6999)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="饼干类")
			{
				if(strmaxid==0)
				{
					strmaxid=7001;
				}
				else if(strmaxid>=7999)
				{
					//							return;
				}
			}
			if (gs.strGoodsType=="外卖产品")
			{
				if(strmaxid==0)
				{
					strmaxid=8001;
				}
				else if(strmaxid>=8999)
				{
					//							return;
				}
			}

			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					
					err=null;
					strmaxid=strmaxid+1;

					sql1="insert into tbGoods values('" + strmaxid + "','" + gs.strGoodsName + "','" + gs.strSpell + "'," + gs.dPrice.ToString() + ",0," + gs.iIgValue.ToString() + ",'0','" + gs.strComments + "')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void UpdateGoods(CMSMStruct.GoodsStruct gsnew,CMSMStruct.GoodsStruct gsold,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string sqlset="";
				try
				{
					err=null;
					if(gsnew.strGoodsName!=gsold.strGoodsName)
					{
						sqlset+="vcGoodsName='" + gsnew.strGoodsName + "',";
					}
					if(gsnew.strSpell!=gsold.strSpell)
					{
						sqlset+="vcSpell='" + gsnew.strSpell + "',";
					}
					if(gsnew.dPrice!=gsold.dPrice)
					{
						sqlset+="nPrice=" + gsnew.dPrice.ToString() + ",";
					}
					if(gsnew.iIgValue!=gsold.iIgValue)
					{
						sqlset+="iIgValue=" + gsnew.iIgValue.ToString() + ",";
					}
					if(gsnew.strComments!=gsold.strComments)
					{
						sqlset+="vcComments='" + gsnew.strComments + "',";
					}

					if(sqlset!="")
					{
						sqlset=sqlset.Substring(0,sqlset.Length-1);
						sql1="update tbGoods set " + sqlset + " where vcGoodsID='" + gsold.strGoodsID + "'";
						cmd=new SqlCommand(sql1,con,trans);
						cmd.ExecuteNonQuery();
						trans.Commit();
					}
					
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void DeleteGoods(string strGoodsID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="delete from tbGoods where vcGoodsID='" + strGoodsID + "'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();					
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void UpdateGoodsNew(ArrayList al,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string sqlset="";
				try
				{
					err=null;
					if(al.Count==0)
					{
						sql1="update tbGoods set cNewFlag='0' where cNewFlag<>'0'";
						cmd=new SqlCommand(sql1,con,trans);
						cmd.ExecuteNonQuery();
						trans.Commit();
					}
					else
					{
						for(int i=0;i<al.Count;i++)
						{
							sqlset+="'" + al[i].ToString() + "',";
						}
						sqlset=sqlset.Substring(0,sqlset.Length-1);

						sql1="update tbGoods set cNewFlag='0' where cNewFlag<>'0'";
						cmd=new SqlCommand(sql1,con,trans);
						cmd.ExecuteNonQuery();

						sql2="update tbGoods set cNewFlag='1' where vcGoodsName in(" + sqlset + ")";
						cmd=new SqlCommand(sql2,con,trans);
						cmd.ExecuteNonQuery();

						trans.Commit();
					}
					
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public bool ChkGoodsIDDup(string strGoodsID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtGoods=new DataTable();
			bool flag=true;
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbGoods where vcGoodsID='" + strGoodsID + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtGoods);
				if(int.Parse(dtGoods.Rows[0][0].ToString())==0)
				{
					flag=false;
				}
				else
				{
					flag=true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return flag;
			}
			finally
			{
				con.Close();
			}
			return flag;
		}

		public bool ChkGoodsNameDup(string strGoodsName,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtGoods=new DataTable();
			bool flag=true;
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbGoods where vcGoodsName='" + strGoodsName + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtGoods);
				if(int.Parse(dtGoods.Rows[0][0].ToString())==0)
				{
					flag=false;
				}
				else
				{
					flag=true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return flag;
			}
			finally
			{
				con.Close();
			}
			return flag;
		}

		public CMSMStruct.GoodsStruct GetGoodsByName(string strGoodsName,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtGoods=new DataTable();
			CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select top 1 * from tbGoods where vcGoodsName = '" + strGoodsName + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtGoods);
				if(dtGoods!=null&&dtGoods.Rows.Count>0)
				{
					gs.strGoodsID=dtGoods.Rows[0]["vcGoodsID"].ToString();
					gs.strGoodsName=dtGoods.Rows[0]["vcGoodsName"].ToString();
					gs.strSpell=dtGoods.Rows[0]["vcSpell"].ToString();
					gs.dPrice=Double.Parse(dtGoods.Rows[0]["nPrice"].ToString());
					gs.dRate=Double.Parse(dtGoods.Rows[0]["nRate"].ToString());
					gs.iIgValue=int.Parse(dtGoods.Rows[0]["iIgValue"].ToString());
					gs.strComments=dtGoods.Rows[0]["vcComments"].ToString();
				}
				else
				{
					gs=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return gs;
		}

		public CMSMStruct.GoodsStruct GetGoodsByID(string strGoodsID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtGoods=new DataTable();
			CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbGoods where vcGoodsID = '" + strGoodsID + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtGoods);
				if(dtGoods!=null&&dtGoods.Rows.Count>0)
				{
					gs.strGoodsID=dtGoods.Rows[0]["vcGoodsID"].ToString();
					gs.strGoodsName=dtGoods.Rows[0]["vcGoodsName"].ToString();
					gs.strSpell=dtGoods.Rows[0]["vcSpell"].ToString();
					gs.dPrice=Double.Parse(dtGoods.Rows[0]["nPrice"].ToString());
					gs.dRate=Double.Parse(dtGoods.Rows[0]["nRate"].ToString());
					gs.strComments=dtGoods.Rows[0]["vcComments"].ToString();
				}
				else
				{
					gs=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return gs;
		}
		#endregion

		#region Read Card

		public CMSMStruct.CardHardStruct ReadCardInfo(string flag,out string strResult)
		{
			strResult="";
			CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
			CardM1 cm=new CardM1(SysInitial.intCom);
			string strCardSnr="";
			bool IsEn=false;
			if(flag=="Emp")
			{
				strResult=cm.EmpReadCard(out strCardSnr,out chs.strCardID,out IsEn);
			}
			else
			{
				strResult=cm.ReadCard(ref strCardSnr,ref chs.strCardID,ref chs.dCurCharge,ref chs.iCurIg,ref IsEn);	
				chs.needZeroFlag=false;
			
				if(strResult.Equals(CardCommon.CardDef.ConstMsg.RFOK)&&strCardSnr!=""&&!IsEn)
				{
					if(!chs.strCardID.StartsWith("F"))
					{
						try
						{
							con.Open();
							conCenter.Open();
							sql1="select count(*) from tbAssociator where vcCardID='"+chs.strCardID+"' and (vcCardSerial is null or vcCardSerial='')";
							cmd1=new SqlCommand(sql1,conCenter);
							drr=cmd1.ExecuteReader();
							drr.Read();
							string asscount=drr[0].ToString();
							drr.Close();

							if(asscount!="0")
							{
								sql2="update tbAssociator set vcCardSerial='"+strCardSnr+"' where vcCardID='"+chs.strCardID+"'";
								cmd=new SqlCommand(sql2,con);
								cmd.ExecuteNonQuery();	
								cmd1=new SqlCommand(sql2,conCenter);
								cmd1.ExecuteNonQuery();	
						
								//short st = 1000;
								int i = 0;
								string ret = "";
								while(i<10 && ret!=CardCommon.CardDef.ConstMsg.RFOK)
								{
									ret = cm.EnCard(chs.strCardID,chs.dCurCharge,chs.iCurIg);
									i++;
								}
								strResult = ret;
							}
							else
							{
								throw new Exception("卡序列号不正确，请检查此卡！");
							}
						}
						catch (Exception e) 
						{
							strResult=e.Message;
						}
						finally
						{
							con.Close();
							conCenter.Close();
						}
					}
				}
			}
//			strResult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
//			chs.strCardID="GY000012";
//			chs.dCurCharge=28.76;
//			chs.iCurIg=19;
			return chs;
		}
//		public CMSMStruct.CardHardStruct ReadCardInfo(string flag,out string strResult)
//		{
//			strResult="";
//			CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
//			CardM1 cm=new CardM1(SysInitial.intCom);
//			if(flag=="Emp")
//			{
//				strResult=cm.EmpReadCard(out chs.strCardID,out chs.dCurCharge,out chs.iCurIg);
//			}
//			else
//			{
//				strResult=cm.ReadCard(ref chs.strCardID,ref chs.dCurCharge,ref chs.iCurIg);
//			}
////			strResult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
////			chs.strCardID="00001";
////			chs.dCurCharge=785.00;
////			chs.iCurIg=140;
//			return chs;
//		}
		#endregion

		#region Consumption
		public string AssCons(CMSMData.CMSMStruct.ConsItemStruct cis,CMSMStruct.CardHardStruct chs,double dCurChargeBak,out Exception err,out string strSerial)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			strSerial="";
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					err=null;
					int igadd=0;
					CardM1 cm=new CardM1(SysInitial.intCom);

					sql7="select iIgGet-iIgArrival from tbAssIgDupMakeUp where iAdded='0' and vcCardID='"+cis.strCardID+"'";
					cmd=new SqlCommand(sql7,con,trans);
					SqlDataAdapter daptmp=new SqlDataAdapter(cmd);
					DataTable dtigadd=new DataTable();
					daptmp.Fill(dtigadd);
					if(dtigadd.Rows.Count!=0&&int.Parse(dtigadd.Rows[0][0].ToString())>0)
					{
                        igadd=int.Parse(dtigadd.Rows[0][0].ToString());
					}

                    //sql1="INSERT INTO tbConsSerialNo (vcFill) VALUES ('0');SELECT scope_identity()";
                    //cmd=new SqlCommand(sql1,con,trans);
                    //drr=cmd.ExecuteReader();
                    //drr.Read();
                    //strSerial=drr[0].ToString();
                    //drr.Close();					

					for(int i=0;i<cis.dtItem.Rows.Count;i++)
					{
						sql1+="insert into tbConsItem values(" + cis.iSerial + ",'" + cis.dtItem.Rows[i]["GoodsID"].ToString() + "'," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dtItem.Rows[i]["Price"].ToString() + "," + cis.dtItem.Rows[i]["Count"].ToString() + ",";
						sql1+=cis.dtItem.Rows[i]["Rate"].ToString() + "," + cis.dtItem.Rows[i]["Fee"].ToString() + ",'" + cis.dtItem.Rows[i]["Comments"].ToString() + "','0','" + cis.strOperDate + "','" + cis.strOperName + "','" + cis.strDeptID + "');";
					}
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbBill values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dTRate.ToString() + "," + cis.dTolCharge.ToString() + "," + cis.dPay.ToString() + "," + cis.dBalance.ToString() + "," + cis.iIgValue.ToString() + ",'";
					sql2+=cis.strConsType + "','" + cis.strOperName + "','" + cis.strOperDate + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

                    sql3 = "insert into tbBusiLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "','OP006','" + cis.strOperName + "','" + cis.strOperDate + "','会员刷卡消费" + cis.dPay + "元','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

                    sql4 = "insert into tbFillFee values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "'," + (-cis.dPay).ToString() + ",0," + cis.dChargeLast.ToString() + "," + chs.dCurCharge.ToString() + ",'" + cis.strOperDate + "','','" + cis.strOperName + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

                    sql5 = "insert into tbIntegralLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "','" + cis.strIgType + "'," + cis.iIgLast.ToString() + "," + cis.iIgValue.ToString() + "," + chs.iCurIg.ToString() + "," + cis.iSerial + ",'";
					sql5+=cis.strOperDate + "','" + cis.strOperName + "','会员消费积分：" + cis.iIgValue.ToString() + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					if(igadd>0)
					{
						//罗修改 2010-06-17
//						sql5="insert into tbIntegralLog values(" + cis.strAssID + ",'" + cis.strCardID + "',''," + chs.iCurIg.ToString() + "," + igadd.ToString() + "," + (chs.iCurIg+igadd).ToString() + ",null,'";
                        sql5 = "insert into tbIntegralLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "',''," + chs.iCurIg.ToString() + "," + igadd.ToString() + "," + (chs.iCurIg + igadd).ToString() + "," + strSerial + ",'";
						sql5+=cis.strOperDate + "','admin','会员加积分：" + igadd.ToString() + "','" + cis.strDeptID + "')";
						cmd=new SqlCommand(sql5,con,trans);
						cmd.ExecuteNonQuery();

						sql5="update tbAssIgDupMakeUp set iAdded=1 where iAdded='0' and vcCardID='"+cis.strCardID+"'";
						cmd=new SqlCommand(sql5,con,trans);
						cmd.ExecuteNonQuery();
					}

					sql6="update tbAssociator set nCharge=" + chs.dCurCharge.ToString() + ",iIgValue=" + (chs.iCurIg+igadd).ToString() + ",dtOperDate='" + cis.strOperDate + "' where vcAssState='0' and  vcCardID='" + cis.strCardID + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql6,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					if(chs.needZeroFlag)
					{
						sql7="insert into tbSetZero values('"+chs.strCardID+"',getdate())";
						cmd=new SqlCommand(sql7,con,trans);
						cmd.ExecuteNonQuery();
					}

					sql8="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], "+ chs.dCurCharge.ToString() +", "+ (chs.iCurIg+igadd).ToString() +", [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+cis.strCardID+"'";
					cmd1=new SqlCommand(sql8,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql9="select count(*) from tbFillFee where vcCardID='" + cis.strCardID + "' and dtFillDate='" + cis.strOperDate + "' and nFeeCur=" + dCurChargeBak.ToString();
					cmd=new SqlCommand(sql9,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr[0].ToString()!="1")
					{
						drr.Close();
						strresult="消费写入库的值不对！";
					}
					else
					{
						drr.Close();
						strresult=cm.ConsWriteCard(chs.dCurCharge,dCurChargeBak,chs.iCurIg+igadd);
//						strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					}

					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						if(strresult.Substring(0,3)!="CMT")
						{
							trans.Rollback();
							trans1.Rollback();
						}
						else
						{
							trans.Commit();
							trans1.Commit();
						}
					}
					else
					{
						trans.Commit();
						trans1.Commit();
					}
					
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					strSerial="";
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		public string AssConsLargess(CMSMData.CMSMStruct.ConsItemStruct cis,CMSMStruct.CardHardStruct chs,double dchargelar,out Exception err,out string strSerial)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			strSerial="";
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
                    //sql1="INSERT INTO tbConsSerialNo (vcFill) VALUES ('0');SELECT scope_identity()";
                    //cmd=new SqlCommand(sql1,con,trans);
                    //drr=cmd.ExecuteReader();
                    //drr.Read();
                    //strSerial=drr[0].ToString();
                    //drr.Close();

					for(int i=0;i<cis.dtItem.Rows.Count;i++)
					{
						sql1+="insert into tbConsItem values(" + cis.iSerial + ",'" + cis.dtItem.Rows[i]["GoodsID"].ToString() + "'," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dtItem.Rows[i]["Price"].ToString() + "," + cis.dtItem.Rows[i]["Count"].ToString() + ",";
						sql1+=cis.dtItem.Rows[i]["Rate"].ToString() + "," + cis.dtItem.Rows[i]["Fee"].ToString() + ",'赠送商品','0','" + cis.strOperDate + "','" + cis.strOperName + "','" + cis.strDeptID + "');";
					}
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbBill values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dTRate.ToString() + "," + cis.dTolCharge.ToString() + "," + cis.dPay.ToString() + "," + cis.dBalance.ToString() + "," + cis.iIgValue.ToString() + ",'PT004','";
					sql2+=cis.strOperName + "','" + cis.strOperDate + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

                    sql3 = "insert into tbBusiLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "','OP006','" + cis.strOperName + "','" + cis.strOperDate + "','会员赠送消费" + cis.dTolCharge + "元','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

                    sql4 = "insert into tbFillFee values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "',0,0," + cis.dChargeLast.ToString() + "," + chs.dCurCharge.ToString() + ",'" + cis.strOperDate + "','会员赠送消费','" + cis.strOperName + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

                    sql5 = "insert into tbIntegralLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "','" + cis.strIgType + "'," + cis.iIgLast.ToString() + "," + cis.iIgValue.ToString() + "," + chs.iCurIg.ToString() + "," + cis.iSerial + ",'";
					sql5+=cis.strOperDate + "','" + cis.strOperName + "','会员赠送：" + cis.iIgValue.ToString() + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					sql6="update tbAssociator set nCharge=" + chs.dCurCharge.ToString() + ",iIgValue=" + chs.iCurIg.ToString() + ",dtOperDate='" + cis.strOperDate + "' where vcAssState='0' and  vcCardID='" + cis.strCardID + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql6,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql7="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='" + cis.strCardID + "'";
					cmd1=new SqlCommand(sql7,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql9="select count(*) from tbFillFee where vcCardID='" + cis.strCardID + "' and dtFillDate='" + cis.strOperDate + "' and nFeeCur=" + dchargelar.ToString();
					cmd=new SqlCommand(sql9,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr[0].ToString()!="1")
					{
						drr.Close();
						strresult="写入库的值不对！";
					}
					else
					{
						drr.Close();
						strresult=CardCommon.CardDef.ConstMsg.RFOK;
					}

//					strresult=cm.ConsWriteCard(chs.dCurCharge,chs.iCurIg);
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
						trans1.Commit();
					}
					else
					{
						trans.Rollback();
						trans1.Rollback();
					}
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					strSerial="";
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		public string RetailCons(CMSMData.CMSMStruct.ConsItemStruct cis,bool hungflag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			string strSerial="";
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;

					for(int i=0;i<cis.dtItem.Rows.Count;i++)
					{
						sql1+="insert into tbConsItem values(" + cis.iSerial + ",'" + cis.dtItem.Rows[i]["GoodsID"].ToString() + "'," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dtItem.Rows[i]["Price"].ToString() + "," + cis.dtItem.Rows[i]["Count"].ToString() + ",";
						sql1+=cis.dtItem.Rows[i]["Rate"].ToString() + "," + cis.dtItem.Rows[i]["Fee"].ToString() + ",'" + cis.dtItem.Rows[i]["Comments"].ToString() + "','0','" + cis.strOperDate + "','" + cis.strOperName + "','" + cis.strDeptID + "');";
					}
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbBill values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dTRate.ToString() + "," + cis.dTolCharge.ToString() + "," + cis.dPay.ToString() + "," + cis.dBalance.ToString() + ",0,'";
					sql2+=cis.strConsType + "','" + cis.strOperName + "','" + cis.strOperDate + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

                    sql3 = "insert into tbBusiLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "','OP006','" + cis.strOperName + "','" + cis.strOperDate + "','零售客户消费" + cis.dTolCharge + "元','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					if(hungflag)
					{
						sql4="truncate table tbConsItemHung";
						cmd=new SqlCommand(sql4,con,trans);
						cmd.ExecuteNonQuery();
					}
					
					trans.Commit();
					return strSerial;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					strSerial="";
					return strSerial;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public DataTable GetConsRepeat(string strCardID,string strSerial,string strBegin,string strEnd,string strDeptID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(strCardID!=""&&strCardID!="*")
				{
					strCondition=" and a.vcCardID like '%" + strCardID + "%'";
				}
				if(strSerial!=""&&strSerial!="*")
				{
					if(strCondition=="")
					{
						strCondition=" and iSerial='" + strSerial+"'";
					}
					else
					{
						strCondition=strCondition + " and iSerial='" + strSerial+ "' ";
					}
				}
				if(strDeptID!="all"&&strDeptID!="")
				{
					if(strCondition=="")
					{
						strCondition=" and a.vcDeptID='" + strDeptID + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID='" + strDeptID + "'";
					}
				}
				sql1="select a.iSerial,a.vcCardID,b.vcAssName,a.nTRate,a.nFee,a.nPay,a.nBalance,a.vcOperName,a.dtConsDate,a.vcDeptID from vwBill a,tbAssociator b,tbCommCode c where a.iSerial not in(select distinct iSerial from vwConsItem where cFlag='9' and dtConsDate between '" + strBegin + "' and '" + strEnd + "') and dtConsDate between '" + strBegin + "' and '" + strEnd + "' and a.vcCardID=b.vcCardID and a.vcConsType=c.vcCommCode";
				if(strCondition!="")
				{
					sql1+= strCondition;
				}
                sql1 += " order by a.dtConsDate desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtAss;
		}

        public DataTable GetConsRepeatEnd(string strCardID, string strSerial, string strBegin, string strEnd, string strDeptID, out Exception err)
        {
            this.MaskSqlToNull();
            DataTable dtAss = new DataTable();
            try
            {
                con.Open();
                err = null;
                string strCondition = "";
                if (strCardID != "" && strCardID != "*")
                {
                    strCondition = " and a.vcCardID like '%" + strCardID + "%'";
                }
                if (strSerial != "" && strSerial != "*")
                {
                    if (strCondition == "")
                    {
                        strCondition = " and iSerial='" + strSerial + "'";
                    }
                    else
                    {
                        strCondition = strCondition + " and iSerial='" + strSerial + "' ";
                    }
                }
                if (strDeptID != "all" && strDeptID != "")
                {
                    if (strCondition == "")
                    {
                        strCondition = " and a.vcDeptID='" + strDeptID + "'";
                    }
                    else
                    {
                        strCondition = strCondition + " and a.vcDeptID='" + strDeptID + "'";
                    }
                }
                sql1 = "select top 1 a.iSerial,a.vcCardID,b.vcAssName,a.nTRate,a.nFee,a.nPay,a.nBalance,a.vcOperName,a.dtConsDate,a.vcDeptID from vwBill a,tbAssociator b,tbCommCode c where a.iSerial not in(select distinct iSerial from vwConsItem where cFlag='9' and dtConsDate between '" + strBegin + "' and '" + strEnd + "') and dtConsDate between '" + strBegin + "' and '" + strEnd + "' and a.vcCardID=b.vcCardID and a.vcConsType=c.vcCommCode";
                if (strCondition != "")
                {
                    sql1 += strCondition;
                }
                sql1 += " order by a.dtConsDate desc";
                cmd = new SqlCommand(sql1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAss);
            }
            catch (Exception e)
            {
                err = e;
                return null;
            }
            finally
            {
                con.Close();
            }
            return dtAss;
        }

		public DataTable GetConsQuery(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strCardID"].ToString()!=""&&htPara["strCardID"].ToString()!="*")
				{
					strCondition=" a.vcCardID='" + htPara["strCardID"].ToString() + "'";
				}
				if(htPara["strAssName"].ToString()!=""&&htPara["strAssName"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" c.vcAssName = '" + htPara["strAssName"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and c.vcAssName = '" + htPara["strAssName"].ToString() + "'";
					}
				}
				if(htPara["strAssType"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" c.vcAssType='" + htPara["strAssType"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and c.vcAssType = '" + htPara["strAssType"].ToString() + "'";
					}
				}
				if(htPara["strGoodsName"].ToString()!=""&&htPara["strGoodsName"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" d.vcGoodsName='" + htPara["strGoodsName"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and d.vcGoodsName = '" + htPara["strGoodsName"].ToString() + "'";
					}
				}
				if(htPara["strConsType"].ToString()!=""&&htPara["strConsType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" a.cFlag='" + htPara["strConsType"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.cFlag = '" + htPara["strConsType"].ToString() + "'";
					}
				}
				if(htPara["strOperName"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcOperName='" + htPara["strOperName"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcOperName = '" + htPara["strOperName"].ToString() + "'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				//付费类型
				if(htPara["strPTType"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition = " b.vcConsType='"+htPara["strPTType"].ToString()+"'";
					}
					else
					{
						strCondition = strCondition +" and b.vcConsType='"+htPara["strPTType"].ToString()+"'";
					}
				}
                sql1 = "select a.iSerial,c.vcAssName,c.vcAssType,a.vcCardID,d.vcGoodsName,a.nPrice,a.iCount,round(a.nPrice*a.iCount,2) as nFee,a.nTRate,a.nFee as nPay,b.vcConsType,(case a.cFlag when '0' then '正常消费' when '9' then '已撤消' else a.cFlag end) as Flag,a.dtConsDate,a.vcOperName,a.vcDeptID,a.vcComments";
				sql1+=" from vwConsItem a,vwBill b,tbAssociator c,tbGoods d";
                sql1+=" where a.iSerial=b.iSerial and a.vcGoodsID=d.vcGoodsID and a.vcCardID=b.vcCardID and a.vcDeptID=b.vcDeptID and a.vcCardID=c.vcCardID and a.dtConsDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" order by a.dtConsDate";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}

		public DataTable GetConsItemQuery(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strAssType"].ToString()!=""&&htPara["strAssType"].ToString()!="*")
				{
					strCondition=" b.vcAssType = '" + htPara["strAssType"].ToString() + "'";
				}
				if(htPara["strGoodsType"].ToString()!=""&&htPara["strGoodsType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and d.vcCommCode  like '" + htPara["strGoodsType"].ToString() + "%'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				sql1="select a.vcDeptID,b.vcAssType,d.vcCommName,c.vcGoodsName,sum(a.iCount) as tolcount,sum(a.nFee) as tolfee,sum(a.nTRate) as tolrate";
				sql1+=" from vwConsItem a,tbAssociator b,tbGoods c,tbCommCode d";
				sql1+=" where a.cFlag='0' and d.vcCommSign='GT' and a.vcCardID=b.vcCardID and a.vcGoodsID=c.vcGoodsID and substring(a.vcGoodsID,1,2) between substring(d.vcCommCode,1,2) and substring(d.vcCommCode,4,2) and a.dtConsDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" group by a.vcDeptID,b.vcAssType,d.vcCommName,c.vcGoodsName order by a.vcDeptID,b.vcAssType,d.vcCommName,c.vcGoodsName";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}

		public DataSet GetLargQuery(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			DataTable dtCons2=new DataTable();
			DataSet dsout=new DataSet();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				if (htPara["strAssCode"].ToString()=="")
				{
					sql1="select b.vcAssName,c.vcCardID,c.VcGoodsId,c.iCount,c.dtConsDate,c.vcOperName,c.vcDeptId";
					sql1+=" from tbBill a,tbAssociator b,tbConsItem c where vcConsType='pt004' and a.vcCardID=b.vcCardID and a.iSerial=c.iSerial and a.vcCardID=c.vcCardID";
					sql1+=" and c.dtConsDate>='" + htPara["strBegin"].ToString() +"' and c.dtConsDate<='" + htPara["strEnd"].ToString() +"'";

					sql2="select count(distinct c.vcCardID) as asscount,isnull(sum(c.iCount),0) as goodscount";
					sql2+=" from tbBill a,tbAssociator b,tbConsItem c where vcConsType='pt004' and a.vcCardID=b.vcCardID and a.iSerial=c.iSerial and a.vcCardID=c.vcCardID";
					sql2+=" and c.dtConsDate>='" + htPara["strBegin"].ToString() +"' and c.dtConsDate<='" + htPara["strEnd"].ToString() +"'";
				}
				else
				{
					sql1="select b.vcAssName,c.vcCardID,c.VcGoodsId,c.iCount,c.dtConsDate,c.vcOperName,c.vcDeptId";
					sql1+=" from tbBill a,tbAssociator b,tbConsItem c where vcConsType='pt004' and a.vcCardID=b.vcCardID and a.iSerial=c.iSerial and a.vcCardID=c.vcCardID ";
					sql1+=" and c.dtConsDate>='" + htPara["strBegin"].ToString() +"' and c.dtConsDate<='" + htPara["strEnd"].ToString() +"'";
					sql1+=" and c.vcCardID='" + htPara["strAssCode"].ToString() + "'";

					sql2="select count(distinct c.vcCardID) as asscount,isnull(sum(c.iCount),0) as goodscount";
					sql2+=" from tbBill a,tbAssociator b,tbConsItem c where vcConsType='pt004' and a.vcCardID=b.vcCardID and a.iSerial=c.iSerial and a.vcCardID=c.vcCardID ";
					sql2+=" and c.dtConsDate>='" + htPara["strBegin"].ToString() +"' and c.dtConsDate<='" + htPara["strEnd"].ToString() +"'";
					sql2+=" and c.vcCardID='" + htPara["strAssCode"].ToString() + "'";
				}
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
					sql2+=" and " + strCondition;
				}
				dtCons.TableName="cons1";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
				dsout.Tables.Add(dtCons);

				dtCons2.TableName="cons2";
				cmd=new SqlCommand(sql2,con);
				cmd.CommandTimeout=600;
				da=new SqlDataAdapter(cmd);
				da.Fill(dtCons2);
				dsout.Tables.Add(dtCons2);				
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dsout;
		}

		public DataTable GetConsItemQuery1(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strAssType"].ToString()!=""&&htPara["strAssType"].ToString()!="*")
				{
					strCondition=" b.vcAssType = '" + htPara["strAssType"].ToString() + "'";
				}
				if(htPara["strGoodsType"].ToString()!=""&&htPara["strGoodsType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				sql1="select a.vcDeptID,c.vcGoodsName,sum(a.iCount) as tolcount,sum(a.nFee) as tolfee,sum(a.nTRate) as tolrate";
				sql1+=" from vwConsItem a,tbAssociator b,tbGoods c,tbCommCode d";
				sql1+=" where a.cFlag='0' and d.vcCommSign='GT' and a.vcCardID=b.vcCardID and a.vcGoodsID=c.vcGoodsID and substring(a.vcGoodsID,1,2) between substring(d.vcCommCode,1,2) and substring(d.vcCommCode,4,2) and a.dtConsDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" group by a.vcDeptID,c.vcGoodsName order by a.vcDeptID,c.vcGoodsName";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}
		public DataTable GetConsItemQuery2(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strAssType"].ToString()!=""&&htPara["strAssType"].ToString()!="*")
				{
					strCondition=" b.vcAssType = '" + htPara["strAssType"].ToString() + "'";
				}
				if(htPara["strGoodsType"].ToString()!=""&&htPara["strGoodsType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				sql1="select b.vcAssType,c.vcGoodsName,sum(a.iCount) as tolcount,sum(a.nFee) as tolfee,sum(a.nTRate) as tolrate";
				sql1+=" from vwConsItem a,tbAssociator b,tbGoods c,tbCommCode d";
				sql1+=" where a.cFlag='0' and d.vcCommSign='GT' and a.vcCardID=b.vcCardID and a.vcGoodsID=c.vcGoodsID and substring(a.vcGoodsID,1,2) between substring(d.vcCommCode,1,2) and substring(d.vcCommCode,4,2) and a.dtConsDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" group by b.vcAssType,c.vcGoodsName order by b.vcAssType,c.vcGoodsName";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}
		public DataTable GetConsItemQuery3(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strAssType"].ToString()!=""&&htPara["strAssType"].ToString()!="*")
				{
					strCondition=" b.vcAssType = '" + htPara["strAssType"].ToString() + "'";
				}
				if(htPara["strGoodsType"].ToString()!=""&&htPara["strGoodsType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				sql1="select d.vcCommName,c.vcGoodsName,sum(a.iCount) as tolcount,sum(a.nFee) as tolfee,sum(a.nTRate) as tolrate";
				sql1+=" from vwConsItem a,tbAssociator b,tbGoods c,tbCommCode d";
				sql1+=" where a.cFlag='0' and d.vcCommSign='GT' and a.vcCardID=b.vcCardID and a.vcGoodsID=c.vcGoodsID and substring(a.vcGoodsID,1,2) between substring(d.vcCommCode,1,2) and substring(d.vcCommCode,4,2) and a.dtConsDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" group by d.vcCommName,c.vcGoodsName order by d.vcCommName,c.vcGoodsName";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}
		public DataTable GetConsItemQuery4(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strAssType"].ToString()!=""&&htPara["strAssType"].ToString()!="*")
				{
					strCondition=" b.vcAssType = '" + htPara["strAssType"].ToString() + "'";
				}
				if(htPara["strGoodsType"].ToString()!=""&&htPara["strGoodsType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				sql1="select b.vcAssType,d.vcCommName,c.vcGoodsName,sum(a.iCount) as tolcount,sum(a.nFee) as tolfee,sum(a.nTRate) as tolrate";
				sql1+=" from vwConsItem a,tbAssociator b,tbGoods c,tbCommCode d";
				sql1+=" where a.cFlag='0' and d.vcCommSign='GT' and a.vcCardID=b.vcCardID and a.vcGoodsID=c.vcGoodsID and substring(a.vcGoodsID,1,2) between substring(d.vcCommCode,1,2) and substring(d.vcCommCode,4,2) and a.dtConsDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" group by b.vcAssType,d.vcCommName,c.vcGoodsName order by b.vcAssType,d.vcCommName,c.vcGoodsName";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}
		public DataTable GetConsItemQuery5(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strAssType"].ToString()!=""&&htPara["strAssType"].ToString()!="*")
				{
					strCondition=" b.vcAssType = '" + htPara["strAssType"].ToString() + "'";
				}
				if(htPara["strGoodsType"].ToString()!=""&&htPara["strGoodsType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				sql1="select a.vcDeptID,b.vcAssType,c.vcGoodsName,sum(a.iCount) as tolcount,sum(a.nFee) as tolfee,sum(a.nTRate) as tolrate";
				sql1+=" from vwConsItem a,tbAssociator b,tbGoods c,tbCommCode d";
				sql1+=" where a.cFlag='0' and d.vcCommSign='GT' and a.vcCardID=b.vcCardID and a.vcGoodsID=c.vcGoodsID and substring(a.vcGoodsID,1,2) between substring(d.vcCommCode,1,2) and substring(d.vcCommCode,4,2) and a.dtConsDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" group by a.vcDeptID,b.vcAssType,c.vcGoodsName order by a.vcDeptID,b.vcAssType,c.vcGoodsName";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}
		public DataTable GetConsItemQuery6(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strAssType"].ToString()!=""&&htPara["strAssType"].ToString()!="*")
				{
					strCondition=" b.vcAssType = '" + htPara["strAssType"].ToString() + "'";
				}
				if(htPara["strGoodsType"].ToString()!=""&&htPara["strGoodsType"].ToString()!="*")
				{
					if(strCondition=="")
					{
						strCondition=" d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
					else
					{
						strCondition=strCondition + " and d.vcCommCode like '" + htPara["strGoodsType"].ToString() + "%'";
					}
				}
				if(htPara["strDeptID"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + htPara["strDeptID"].ToString() + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + htPara["strDeptID"].ToString() + "'";
					}
				}
				sql1="select a.vcDeptID,d.vcCommName,c.vcGoodsName,sum(a.iCount) as tolcount,sum(a.nFee) as tolfee,sum(a.nTRate) as tolrate";
				sql1+=" from vwConsItem a,tbAssociator b,tbGoods c,tbCommCode d";
				sql1+=" where a.cFlag='0' and d.vcCommSign='GT' and a.vcCardID=b.vcCardID and a.vcGoodsID=c.vcGoodsID and substring(a.vcGoodsID,1,2) between substring(d.vcCommCode,1,2) and substring(d.vcCommCode,4,2) and a.dtConsDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" group by a.vcDeptID,d.vcCommName,c.vcGoodsName order by a.vcDeptID,d.vcCommName,c.vcGoodsName";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}

		public DataTable GetChangeCheckQuery(string strOper,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select vcConsType,count(*) as ConsCount,isnull(sum(nFee),0) as ConsFee from tbBill where dtConsDate<getdate() and dtConsDate>convert(char(10),getdate(),120) and vcOperName='" + strOper + "' and iSerial not in(select distinct iSerial from tbConsItem where cFlag='9' and dtConsDate<getdate() and dtConsDate>convert(char(10),getdate(),120)) group by vcConsType";
				sql1+= " union all select 'Fill' as vcConsType,count(*) as ConsCount,isnull(sum(nFillFee),0) as ConsFee from tbFillFee where dtFillDate<getdate() and dtFillDate>convert(char(10),getdate(),120) and nFillFee>0 and vcComments<>'银行卡' and vcComments not like '%补卡%' and vcComments not like '%补充值%' and vcComments not like '%撤消%' and vcComments not like '%合并%'  and vcComments not like '回收卡%'and vcOperName='" + strOper + "'";
				sql1+= " union all select 'FillBank' as vcConsType,count(*) as ConsCount,isnull(sum(nFillFee),0) as ConsFee from tbFillFee where dtFillDate<getdate() and dtFillDate>convert(char(10),getdate(),120) and nFillFee>0 and vcComments='银行卡' and vcComments not like '%补卡%' and vcComments not like '%补充值%' and vcComments not like '%撤消%' and vcComments not like '回收卡%'and vcOperName='" + strOper + "'";
				sql1+= " union all select 'CradRoll',count(1) as ConsCount,isnull(sum(nFillFee),0)as ConsFee from tbFillFee where dtFillDate<getdate() and dtFillDate>convert(char(10),getdate(),120)  and vcComments  like '回收卡退款%'  and vcOperName='" + strOper + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}
        public DataTable GetBusiQuery(string strDateZoom, out Exception err)
        {
            this.MaskSqlToNull();
            DataTable dtBusi = new DataTable();
            try
            {
                con.Open();
                err = null;
                sql1 = "SELECT (SELECT REP1 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'NewAss') AS 新增会员数, ";
                sql1 += " (SELECT REP1 FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type = 'LostAss') AS 挂失会员数,";
                sql1 += " (SELECT REP6 FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type = 'FillFee') AS 充值次数,";
                sql1 += " (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type = 'FillFee') AS 充值金额,";
                sql1 += " (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type = 'BankFillFee') AS 银联卡充值,";
                sql1 += " (SELECT SUM(REP6) FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type IN ('AssCons' , 'PromCons')) AS 会员消费次数, ";
                sql1 += " (SELECT SUM(REP4) FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type IN ('AssCons' , 'PromCons')) AS 会员消费金额, ";
                sql1 += " (SELECT REP6 FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type = 'Retail') AS 零售次数,";
                sql1 += " (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type = 'Retail') AS 零售金额,";
                sql1 += " (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom =  '" + strDateZoom + "' AND Type = 'Total') AS 现金总额";
                cmd = new SqlCommand(sql1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtBusi);
            }
            catch (Exception e)
            {
                err = e;
                return null;
            }
            finally
            {
                con.Close();
            }
            return dtBusi;
        }

		public DataTable GetConsOperList(string strDeptID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtOperList=new DataTable();
			try
			{
				con.Open();
				err=null;
				if(strDeptID=="all")
				{
					sql1="select distinct vcOperName from vwBill where vcOperName  in(select distinct vcOperName from tbOper where vcDeptID='" + SysInitial.LocalDept + "')";
				}
				else
				{
					sql1="select distinct vcOperName from vwBill where vcDeptID='" + strDeptID + "'";
				}
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtOperList);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtOperList;
		}

		public DataTable GetBespeaksQuery(Hashtable htPara,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtBes=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(htPara["strBesFlag"].ToString()!="")
				{
					if(strCondition=="")
					{
						strCondition=" vcFlag='" + htPara["strBesFlag"].ToString() + "'";
					}
				}
				sql1="select a.iSerial,(case a.vcCardID when 'V9999' then '非会员' else a.vcCardID end) as vcCardID,a.vcBesName,a.vcLinkPhone,a.vcBesComments,a.iBesCount,a.dtBesDate,a.dtFatchDate,a.vcOperName,a.vcDeptID,b.vcCommName,a.dtFinalDate from tbBespeakLog a,tbCommCode b where b.vcCommSign='BF' and a.vcflag=b.vcCommCode and a.dtFatchDate between '" + htPara["strBegin"].ToString() + "' and '" + htPara["strEnd"].ToString() + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" order by a.dtFatchDate";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtBes);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtBes;
		}

		public string BespeakOk(string strSerialNo,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					sql1="update tbBespeakLog set vcFlag='2',dtFinalDate=getdate() where iSerial='" + strSerialNo + "'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public string BespeakCancel(string strSerialNo,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					sql1="update tbBespeakLog set vcFlag='1',dtFinalDate=getdate() where iSerial='" + strSerialNo + "'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public string BespeakInsert(Hashtable hsbes,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					sql1="insert into tbBespeakLog values('" + hsbes["strCardID"].ToString() + "','" + hsbes["strName"].ToString() + "','" + hsbes["strPhone"].ToString() + "','" + hsbes["strComments"].ToString() + "'," + hsbes["strCount"].ToString() + ",getdate(),'" + hsbes["strFinal"].ToString() + "','" + SysInitial.CurOps.strOperName + "','" + SysInitial.LocalDept + "','0',null)";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return strresult;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public bool ConsItemInHung(DataTable dtConsHung,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				sql1="delete from tbConsItemHung where Comments=''";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();

				for(int i=0;i<dtConsHung.Rows.Count;i++)
				{
					sql2+="insert into tbConsItemHung values('" + dtConsHung.Rows[i]["GoodsID"].ToString() + "','" + dtConsHung.Rows[i]["GoodsName"].ToString() + "','" + dtConsHung.Rows[i]["Price"].ToString() + "','" + dtConsHung.Rows[i]["Count"].ToString() + "','" + dtConsHung.Rows[i]["Rate"].ToString()+"','" +dtConsHung.Rows[i]["Fee"].ToString()+"','" +dtConsHung.Rows[i]["Comments"].ToString()+"');";
				}
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				
				return true;
			}
			catch (Exception e) 
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
		}
		public bool ConsItemInHung_Card(DataTable dtConsHung,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				con.Open();
				err=null;
				sql1="delete from tbConsItemHung where Comments='1'";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();

				for(int i=0;i<dtConsHung.Rows.Count;i++)
				{
					sql2+="insert into tbConsItemHung values('" + dtConsHung.Rows[i]["GoodsID"].ToString() + "','" + dtConsHung.Rows[i]["GoodsName"].ToString() + "','" + dtConsHung.Rows[i]["Price"].ToString() + "','" + dtConsHung.Rows[i]["Count"].ToString() + "','" + dtConsHung.Rows[i]["Rate"].ToString()+"','" +dtConsHung.Rows[i]["Fee"].ToString()+"','1');";
				}
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				
				return true;
			}
			catch (Exception e) 
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
		}

		public DataTable GetConsItemHung(out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				DataTable dthung=new DataTable();
				con.Open();
				err=null;
				sql1="select * from tbConsItemHung where Comments=''";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dthung);

				return dthung;
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
		}
		public DataTable GetConsItemHung_Card(out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				DataTable dthung=new DataTable();
				con.Open();
				err=null;
				sql1="select * from tbConsItemHung where Comments='1'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dthung);

				return dthung;
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
		}

		public DataSet GetAssConsLast(string strCardID, out Exception err)
		{
			this.MaskSqlToNull();
			DataSet dsout=new DataSet();
			DataTable dtBill=new DataTable();
			DataTable dtCurCharge=new DataTable();
			DataTable dtConsItem=new DataTable();
			try
			{
				con.Open();
				err=null;
				DateTime dtnow=DateTime.Now;
				string strBefore1Hour=dtnow.AddHours(-4).ToShortDateString()+" "+dtnow.AddHours(-4).ToLongTimeString();
				sql1="select max(iSerial) from tbBill where vcCardID='"+strCardID+"' and dtConsDate>='"+strBefore1Hour+"' and vcConsType='PT001' and iSerial in(select distinct iSerial from tbConsItem where vcCardID='"+strCardID+"' and dtConsDate>='"+strBefore1Hour+"' and vcConsType='PT001' and cFlag='0')";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				string strSerial=drr[0].ToString();
				drr.Close();

				if(strSerial=="")
				{
					err=new Exception("在最近4小时内没有消费记录！");
					return null;
				}
				else
				{
					sql2="select iSerial,nPay,convert(char(19),dtConsDate,120) as dtTime from tbBill where iSerial="+strSerial;
					cmd=new SqlCommand(sql2,con);
					SqlDataAdapter da=new SqlDataAdapter(cmd);
					da.Fill(dtBill);
					dtBill.TableName="Bill";
					dsout.Tables.Add(dtBill);

					if(dtBill.Rows.Count!=1)
					{
						err=new Exception("在最近4小时内没有消费记录！");
						return null;
					}
					else
					{
						string strConsDate=dtBill.Rows[0]["dtTime"].ToString();
						sql3="select top 1 vcCardID,nFeeCur from tbFillFee where vcCardID='"+strCardID+"' and dtFillDate='"+strConsDate+"'";
						cmd=new SqlCommand(sql3,con);
						da=new SqlDataAdapter(cmd);
						da.Fill(dtCurCharge);
						dtCurCharge.TableName="CurCharge";
						dsout.Tables.Add(dtCurCharge);

						sql4="select a.vcGoodsID,b.vcGoodsName,a.nPrice,a.iCount,a.nTRate,a.nFee from tbConsItem a,tbGoods b where a.iSerial="+strSerial+" and a.vcGoodsID=b.vcGoodsID";
						cmd=new SqlCommand(sql4,con);
						da=new SqlDataAdapter(cmd);
						da.Fill(dtConsItem);
						dtConsItem.TableName="ConsItem";
						dsout.Tables.Add(dtConsItem);

						return dsout;
					}
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
		}
       

		public string AssConsRemove(string strSerial,CMSMStruct.FillFeeStruct refill,int curIg,double dCurChargeBak,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				string strresult="";
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);

					sql1="update tbConsItem set cFlag='9' where iSerial="+strSerial;
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    sql2 = "insert into tbBusiLog values('" + refill.iSerial + "9'," + refill.strAssID + ",'" + refill.strCardID + "','OP009','" + refill.strOperName + "','" + refill.strFillDate + "','会员消费撤消" + refill.dFillFee + "元','" + refill.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

                    sql3 = "insert into tbFillFee values('" + refill.iSerial + "9'," + refill.strAssID + ",'" + refill.strCardID + "'," + refill.dFillFee.ToString() + ",0," + refill.dFeeLast.ToString() + "," + refill.dFeeCur.ToString() + ",'" + refill.strFillDate + "','" + refill.strComments + "','" + refill.strOperName + "','" + refill.strDeptID + "')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					//取得积分 zhh 20120508
					sql7="select isnull(SUM(iIgGet),0) as ig from tbIntegralLog where iLinkCons="+strSerial;
					cmd=new SqlCommand(sql7,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					int iIg = Convert.ToInt32(drr[0].ToString());
					drr.Close();
					int iIgLast = curIg;
					curIg = curIg-iIg;//撤销积分

                    sql8 = "insert into tbIntegralLog values('" + refill.iSerial + "9'," + refill.strAssID + ",'" + refill.strCardID + "','IGT04'," + iIgLast.ToString() + ",-" + iIg.ToString() + "," + curIg.ToString() + "," + strSerial + ",'";
					sql8+=refill.strFillDate + "','" + refill.strOperName + "','会员消费撤销积分：-" + iIg.ToString() + "','" + refill.strDeptID + "')";
					cmd=new SqlCommand(sql8,con,trans);
					cmd.ExecuteNonQuery();
					//zhh 20120508

					sql4="update tbAssociator set nCharge=" + refill.dFeeCur.ToString() + ",dtOperDate='" + refill.strFillDate + "',iIgValue='"+curIg.ToString()+"' where vcAssState='0' and vcCardID='" + refill.strCardID + "' and vcAssState='0'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql4,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql6="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], "+ refill.dFeeCur.ToString() +", [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+refill.strCardID+"'";
					cmd1=new SqlCommand(sql6,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql5="select count(*) from tbFillFee where vcCardID='" + refill.strCardID + "' and dtFillDate='" + refill.strFillDate + "' and nFeeCur=" + dCurChargeBak.ToString();
					cmd=new SqlCommand(sql5,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					if(drr[0].ToString()!="1")
					{
						drr.Close();
						strresult="消费写入库的值不对！";
					}
					else
					{
						drr.Close();
						strresult=cm.ConsWriteCard(refill.dFeeCur,dCurChargeBak,curIg);
//						strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					}

					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						if(strresult.Substring(0,3)!="CMT")
						{
							trans.Rollback();
							trans1.Rollback();
						}
						else
						{
							trans.Commit();
							trans1.Commit();
						}
					}
					else
					{
						trans.Commit();
						trans1.Commit();
					}
					
					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					strSerial="";
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}

		public DataSet GetNonAssConsLast(string strBillNo, out Exception err)
		{
			this.MaskSqlToNull();
			DataSet dsout=new DataSet();
			DataTable dtBill=new DataTable();
			DataTable dtConsItem=new DataTable();
			try
			{
				con.Open();
				err=null;
				DateTime dtnow=DateTime.Now;
				string strBefore1Hour=dtnow.AddHours(-4).ToShortDateString()+" "+dtnow.AddHours(-4).ToLongTimeString();
				sql2="select distinct a.iSerial,a.nPay,convert(char(19),a.dtConsDate,120) as dtTime,b.cFlag from tbBill a,tbConsItem b where a.vcConsType in ('PT002','PT008') and a.iSerial="+strBillNo+" and a.dtConsDate>'"+strBefore1Hour+"' and a.iSerial=b.iSerial";
				cmd=new SqlCommand(sql2,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtBill);
				dtBill.TableName="Bill";
				dsout.Tables.Add(dtBill);

				if(dtBill.Rows.Count!=1)
				{
					err=new Exception("此小票消费时间已经超出4小时！");
					return null;
				}
				else
				{
					if(dtBill.Rows[0]["cFlag"].ToString()=="9")
					{
						err=new Exception("此小票已经撤消！");
						return null;
					}
					else
					{
						sql4="select a.vcGoodsID,b.vcGoodsName,a.nPrice,a.iCount,a.nTRate,a.nFee from tbConsItem a,tbGoods b where a.iSerial="+strBillNo+" and a.vcGoodsID=b.vcGoodsID";
						cmd=new SqlCommand(sql4,con);
						da=new SqlDataAdapter(cmd);
						da.Fill(dtConsItem);
						dtConsItem.TableName="ConsItem";
						dsout.Tables.Add(dtConsItem);
					}

					return dsout;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
		}

		public bool NonAssConsRemove(string strSerial,string strConsFee,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
					sql1="update tbConsItem set cFlag='9' where iSerial="+strSerial;
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    sql2 = "insert into tbBusiLog values('" + strSerial + "9',1,'V9999','OP009','" + SysInitial.CurOps.strOperName + "','" + strDate + "','非会员消费撤消" + strConsFee + "元','" + SysInitial.LocalDept + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();					
					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Recycle card
		public string RecycleCard()
		{
			string strResult="";
			CardM1 cm=new CardM1(SysInitial.intCom);
			strResult=cm.RecycleCard();
			return strResult;
		}
		#endregion

		#region Oper manage
		public DataTable GetOper(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtOper=new DataTable();
			try
			{
				con.Open();
				err=null;

				sql1="select a.vcOperID,a.vcOperName,'收银员' from tbOper a,tbCommCode b where a.vcLimit=b.vcCommCode and b.vcCommSign='LM' and b.vcCommCode<>'LM003'  and a.vcDeptID='" + SysInitial.LocalDept + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtOper);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtOper;
		}
		public DataTable GetOper1(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtOper=new DataTable();
			try
			{
				con.Open();
				err=null;

				sql1="select a.vcOperID,a.vcOperName,b.vcCommName from tbOper a,tbCommCode b where a.vcLimit=b.vcCommCode and b.vcCommSign='LM' and a.vcDeptID='" + SysInitial.LocalDept + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtOper);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtOper;
		}
		public CMSMStruct.OperStruct GetOperName(string strOperID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtOper=new DataTable();
			CMSMStruct.OperStruct opertmp=new CMSMData.CMSMStruct.OperStruct();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbOper where vcOperID='" + strOperID + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtOper);
				if(dtOper!=null&&dtOper.Rows.Count>0)
				{
					opertmp.strOperID=dtOper.Rows[0]["vcOperID"].ToString();
					opertmp.strOperName=dtOper.Rows[0]["vcOperName"].ToString();
					opertmp.strLimit=dtOper.Rows[0]["vcLimit"].ToString();
					opertmp.strPwd=dtOper.Rows[0]["vcPwd"].ToString();
				}
				else
				{
					opertmp=null;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return opertmp;
		}

		public void InsertOper(CMSMStruct.OperStruct os1,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="insert into tbOper values('" + os1.strOperID + "','" + os1.strOperName + "','" + os1.strLimit + "','" + os1.strPwd + "','" + os1.strDeptID + "','0')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void DeleteOper(string strOperID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="delete from tbOper where vcOperID='" + strOperID + "'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void UpdateOper(CMSMStruct.OperStruct osold,CMSMStruct.OperStruct osnew,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					string sqlset="";
					err=null;
					if(osold.strLimit!=osnew.strLimit)
					{
						sqlset="vcLimit='" + osnew.strLimit + "',";
					}
					if(osold.strPwd!=osnew.strPwd)
					{
						sqlset+="vcPwd='" + osnew.strPwd + "',";
					}

					if(sqlset!="")
					{
						sqlset=sqlset.Substring(0,sqlset.Length-1);
						sql1="update tbOper set " + sqlset + " where vcOperID='" + osold.strOperID + "'";
						cmd=new SqlCommand(sql1,con,trans);
						cmd.ExecuteNonQuery();
						trans.Commit();
					}

				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public bool ChkOperIDDup(string strOperID,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtOper=new DataTable();
			bool flag=true;
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbOper where vcOperID='" + strOperID + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtOper);
				if(int.Parse(dtOper.Rows[0][0].ToString())==0)
				{
					flag=false;
				}
				else
				{
					flag=true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return flag;
			}
			finally
			{
				con.Close();
			}
			return flag;
		}

		public bool ChkOperNameDup(string strOperName,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtOper=new DataTable();
			bool flag=true;
			try
			{
				con.Open();
				err=null;
				sql1="select count(*) from tbOper where vcOperName='" + strOperName + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtOper);
				if(int.Parse(dtOper.Rows[0][0].ToString())==0)
				{
					flag=false;
				}
				else
				{
					flag=true;
				}
			}
			catch (Exception e) 
			{
				err=e;
				return flag;
			}
			finally
			{
				con.Close();
			}
			return flag;
		}

		public DataTable GetOperToday(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtOper=new DataTable();
			try
			{
				con.Open();
				err=null;

				sql1="select distinct vcOperName from tbBill where convert(char(8),dtConsDate,112)=convert(char(8),getdate(),112) union select distinct vcOperName from tbFillFee where convert(char(8),dtFillDate,112)=convert(char(8),getdate(),112)";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtOper);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtOper;
		}
		#endregion

		#region Integral Common Code
		public void UpdateIgComm(CMSMData.CMSMStruct.CommStruct cos,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="select count(*) from tbCommCode where vcCommSign='IG'";
					cmd=new SqlCommand(sql1,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strCount=drr[0].ToString();
					drr.Close();

					if(strCount=="0")
					{
						sql2="insert into tbCommCode values('" + cos.strCommName + "','" + cos.strCommCode + "','" + cos.strCommSign + "','" + cos.strComments + "')";
					}
					else
					{
						sql2="update tbCommCode set vcCommName='" + cos.strCommName + "',vcCommCode='" + cos.strCommCode + "' where vcCommSign='IG'";
					}
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();

				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Integral change
		public string IntegralChange(CMSMData.CMSMStruct.ConsItemStruct cis,CMSMStruct.CardHardStruct chs,out Exception err,out string strSerial)
		{
			this.MaskSqlToNull();
			con.Open();
			conCenter.Open();
			strSerial="";
			string strresult="";
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			using(SqlTransaction trans1=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CardM1 cm=new CardM1(SysInitial.intCom);
                    //sql1="INSERT INTO tbConsSerialNo (vcFill) VALUES ('0');SELECT scope_identity()";
                    //cmd=new SqlCommand(sql1,con,trans);
                    //drr=cmd.ExecuteReader();
                    //drr.Read();
                    //strSerial=drr[0].ToString();
                    //drr.Close();

					for(int i=0;i<cis.dtItem.Rows.Count;i++)
					{
						sql1+="insert into tbConsItem values(" + cis.iSerial + ",'" + cis.dtItem.Rows[i]["GoodsID"].ToString() + "'," + cis.strAssID + ",'" + cis.strCardID + "',0," + cis.dtItem.Rows[i]["Count"].ToString() + ",0,0,'用积分兑换','0','" + cis.strOperDate + "','" + cis.strOperName + "','" + cis.strDeptID + "');";
					}
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbBill values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "'," + cis.dTRate.ToString() + "," + cis.dTolCharge.ToString() + "," + cis.dPay.ToString() + "," + cis.dBalance.ToString() + "," + cis.iIgValue.ToString() + ",'";
					sql2+=cis.strConsType + "','" + cis.strOperName + "','" + cis.strOperDate + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

                    sql3 = "insert into tbBusiLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "','OP007','" + cis.strOperName + "','" + cis.strOperDate + "','会员积分兑换" + cis.dTolCharge + "分值','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

                    sql5 = "insert into tbIntegralLog values(" + cis.iSerial + "," + cis.strAssID + ",'" + cis.strCardID + "','" + cis.strIgType + "'," + cis.iIgLast.ToString() + "," + cis.iIgValue.ToString() + "," + (cis.iIgLast + cis.iIgValue).ToString() + "," + cis.iSerial + ",'";
					sql5+=cis.strOperDate + "','" + cis.strOperName + "','会员兑换积分：" + cis.iIgValue.ToString() + "','" + cis.strDeptID + "')";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					sql6="update tbAssociator set iIgValue=" + (cis.iIgLast+cis.iIgValue).ToString() + ",dtOperDate='" + cis.strOperDate + "' where vcAssState='0' and vcCardID='" + cis.strCardID + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();
					cmd1=new SqlCommand(sql6,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					sql7="insert into tbAssociatorSync SELECT [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], "+ (cis.iIgLast+cis.iIgValue).ToString() +", [vcCardFlag], [vcComments], [dtCreateDate], getdate(), [vcDeptID], [vcCardSerial],0 FROM [tbAssociator] where vcCardID='"+cis.strCardID+"'";
					cmd1=new SqlCommand(sql7,conCenter,trans1);
					cmd1.ExecuteNonQuery();

					if (chs.needZeroFlag)
					{
						sql8="insert into tbSetZero values('"+chs.strCardID+"',getdate())";
						cmd=new SqlCommand(sql8,con,trans);
						cmd.ExecuteNonQuery();
					}

					strresult=cm.IgChangeWriteCard(chs.iCurIg);
//					strresult=CardCommon.CardDef.ConstMsg.RFOK;//测试用
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						trans.Commit();
						trans1.Commit();
					}
					else
					{
						trans.Rollback();
						trans1.Rollback();
					}

					return strresult;
				}
				catch(Exception e)
				{
					trans.Rollback();
					trans1.Rollback();
					err=e;
					strSerial="";
					return strresult;
				}
				finally
				{
					con.Close();
					conCenter.Close();
				}
			}
		}
		#endregion

		#region Fill Prom Fee Common Code
		public void UpdateRollPromComm(Hashtable htp,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					CMSMData.CMSMStruct.CommStruct cos=(CMSMData.CMSMStruct.CommStruct)htp["FP4"];
					string aa=cos.strCommCode;
					sql1="select count(*) from tbCommCode where vcCommSign='" + cos.strCommSign + "'";
					cmd=new SqlCommand(sql1,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strCount=drr[0].ToString();
					drr.Close();

					if(strCount=="0")
					{
						sql2="insert into tbCommCode values('" + cos.strCommName + "','" + cos.strCommCode + "','" + cos.strCommSign + "','" + cos.strComments + "')";
					}
					else
					{
						sql2="update tbCommCode set vcCommCode='" + cos.strCommCode + "' where vcCommSign='" + cos.strCommSign + "'";
					}
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		public void UpdateFillPromComm(Hashtable htp,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					for(int i=1;i<=htp.Count;i++)
					{
						CMSMData.CMSMStruct.CommStruct cos=(CMSMData.CMSMStruct.CommStruct)htp["FP"+i];
						string aa=cos.strCommCode;
						sql1="select count(*) from tbCommCode where vcCommSign='" + cos.strCommSign + "'";
						cmd=new SqlCommand(sql1,con,trans);
						drr=cmd.ExecuteReader();
						drr.Read();
						string strCount=drr[0].ToString();
						drr.Close();

						if(strCount=="0")
						{
							sql2="insert into tbCommCode values('" + cos.strCommName + "','" + cos.strCommCode + "','" + cos.strCommSign + "','" + cos.strComments + "')";
						}
						else
						{
							sql2="update tbCommCode set vcCommCode='" + cos.strCommCode + "' where vcCommSign='" + cos.strCommSign + "'";
						}
						cmd=new SqlCommand(sql2,con,trans);
						cmd.ExecuteNonQuery();
					}

					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Get Business's Log'
		public DataTable GetBusiLogQuery(string strDeptID,string strOperName,string strBegin,string strEnd,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			try
			{
				con.Open();
				err=null;
				string strCondition="";
				if(strOperName!="")
				{
					strCondition=" a.vcOperName='" + strOperName + "'";
				}
				if(strDeptID!="")
				{
					if(strCondition=="")
					{
						strCondition=" a.vcDeptID='" + strDeptID + "'";
					}
					else
					{
						strCondition=strCondition + " and a.vcDeptID = '" + strDeptID + "'";
					}
				}
				sql1="select a.iSerial,b.vcAssName,b.vcAssType,a.vcCardID,c.vcCommName,a.vcOperName,a.dtOperDate,a.vcDeptID,a.vcComments from vwBusiLog a,tbAssociator b,tbCommCode c where a.vcCardID=b.vcCardID and a.vcOperType=c.vcCommCode and c.vcCommSign='OP' and a.dtOperDate between '" + strBegin + "' and '" + strEnd + "' ";
				if(strCondition!="")
				{
					sql1+=" and " + strCondition;
				}
				sql1+=" order by a.dtOperDate";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}
		#endregion

		#region DownLoadData
		public void DownAllData(string strBeginDate,string downFileName,out Exception err)
		{
			this.MaskSqlToNull();
			SqlConnection contmp=new SqlConnection();
			try
			{
				con.Open();
				err=null;
//				sql1="exec('IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N''AMSCMTemp'') DROP DATABASE [AMSCMTemp]')";
//				cmd=new SqlCommand(sql1,con);
//				cmd.ExecuteNonQuery();

//				sql2="CREATE DATABASE [AMSCMTemp]  ON (NAME = N'AMSCMTemp_Data', FILENAME = N'E:\\BreadWorksDataBak\\AMSCMTemp_Data.MDF' , SIZE = 10, FILEGROWTH = 10%) LOG ON (NAME = N'AMSCMTemp_Log', FILENAME = N'E:\\BreadWorksDataBak\\AMSCMTemp_Log.LDF' , SIZE = 10, FILEGROWTH = 10%)";
//				cmd=new SqlCommand(sql2,con);
//				cmd.ExecuteNonQuery();

//				sql5="CREATE TABLE AMSCMTemp.dbo.[tbConsSerialNo] ([vcFill] [varchar] (5) COLLATE Chinese_PRC_CI_AS NULL) ON [PRIMARY]";
//				cmd=new SqlCommand(sql5,con);
//				cmd.ExecuteNonQuery();

				sql3="exec sp_DownData '" + strBeginDate + "'";
				cmd=new SqlCommand(sql3,con);
				cmd.CommandTimeout=600;
				cmd.ExecuteNonQuery();
				con.Close();

//				contmp.ConnectionString=SysInitial.ConTempString;
//				string fileName=downFileName;
//				string filePath=@"E:\\BreadWorksDataBak\\DownLoad\\";
//　　			contmp.Open();
//				sql4=" declare @AMSCMTmp varchar(100)  ";
//				sql4+=" set @AMSCMTmp='AMSCMTEMP'";
//				sql4+="exec('BACKUP DATABASE '+@AMSCMTmp+' TO DISK =N''" + filePath + fileName + "'' WITH NOINIT,NOUNLOAD,NAME=N''" + fileName + "备份'',NOSKIP,STATS=10,NOFORMAT')";
//　　			cmd = new SqlCommand(sql4,contmp);
//				cmd.CommandTimeout=600;
//　　			cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
				if(contmp.State==ConnectionState.Open)
				{
					contmp.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
				if(contmp.State==ConnectionState.Open)
				{
					contmp.Close();
				}
			}
		}

		public void DownMainDeptData(string strBeginDate,string downFileName,out Exception err)
		{
			this.MaskSqlToNull();
			SqlConnection contmp=new SqlConnection();
			try
			{
				con.Open();
				err=null;
//				sql1="exec('IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N''AMSCMTemp'') DROP DATABASE [AMSCMTemp]')";
//				cmd=new SqlCommand(sql1,con);
//				cmd.ExecuteNonQuery();
//
//				sql2="CREATE DATABASE [AMSCMTemp]  ON (NAME = N'AMSCMTemp_Data', FILENAME = N'E:\\BreadWorksDataBak\\AMSCMTemp_Data.MDF' , SIZE = 10, FILEGROWTH = 10%) LOG ON (NAME = N'AMSCMTemp_Log', FILENAME = N'E:\\BreadWorksDataBak\\AMSCMTemp_Log.LDF' , SIZE = 10, FILEGROWTH = 10%)";
//				cmd=new SqlCommand(sql2,con);
//				cmd.ExecuteNonQuery();

				sql3="exec sp_MainDeptDownData '" + strBeginDate + "'";
				cmd=new SqlCommand(sql3,con);
				cmd.CommandTimeout=600;
				cmd.ExecuteNonQuery();
				con.Close();

//				contmp.ConnectionString=SysInitial.ConTempString;
//				string fileName=downFileName;
//				string filePath=@"E:\\BreadWorksDataBak\\DownLoad\\";
//　　			contmp.Open();
//				sql4=" declare @AMSCMTmp varchar(100)  ";
//				sql4+=" set @AMSCMTmp='AMSCMTEMP'";
//				sql4+="exec('BACKUP DATABASE '+@AMSCMTmp+' TO DISK =N''" + filePath + fileName + "'' WITH NOINIT,NOUNLOAD,NAME=N''" + fileName + "备份'',NOSKIP,STATS=10,NOFORMAT')";
//　　			cmd = new SqlCommand(sql4,contmp);
//				cmd.CommandTimeout=600;
//　　			cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
				if(contmp.State==ConnectionState.Open)
				{
					contmp.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
				if(contmp.State==ConnectionState.Open)
				{
					contmp.Close();
				};
			}
		}

		public ArrayList DownAssData(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			ArrayList alAss=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbAssociator where vcCardID<>'V9999' and vcAssType<>'AT999' and dtOperDate>='" + strBeginDate + "' order by iAssID,vcCardID";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);

				for(int i=0;i<dtAss.Rows.Count;i++)
				{
					CMSMStruct.AssociatorStruct asstmp=new CMSMData.CMSMStruct.AssociatorStruct();
					asstmp.strAssID=dtAss.Rows[i]["iAssID"].ToString();
					asstmp.strCardID=dtAss.Rows[i]["vcCardID"].ToString();
					asstmp.strAssName=dtAss.Rows[i]["vcAssName"].ToString();
					asstmp.strSpell=dtAss.Rows[i]["vcSpell"].ToString();
					asstmp.strAssNbr=dtAss.Rows[i]["vcAssNbr"].ToString();
					asstmp.strLinkPhone=dtAss.Rows[i]["vcLinkPhone"].ToString();
					asstmp.strLinkAddress=dtAss.Rows[i]["vcLinkAddress"].ToString();
					asstmp.strEmail=dtAss.Rows[i]["vcEmail"].ToString();
					asstmp.strAssType=dtAss.Rows[i]["vcAssType"].ToString();
					asstmp.strAssState=dtAss.Rows[i]["vcAssState"].ToString();
					asstmp.dCharge=Double.Parse(dtAss.Rows[i]["nCharge"].ToString());
					asstmp.iIgValue=int.Parse(dtAss.Rows[i]["iIgValue"].ToString());
					asstmp.strCardFlag=dtAss.Rows[i]["vcCardFlag"].ToString();
					asstmp.strComments=dtAss.Rows[i]["vcComments"].ToString();
					asstmp.strCreateDate=dtAss.Rows[i]["dtCreateDate"].ToString();
					asstmp.strOperDate=dtAss.Rows[i]["dtOperDate"].ToString();
					asstmp.strDeptID=dtAss.Rows[i]["vcDeptID"].ToString();
					alAss.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alAss;
		}

		public ArrayList DownAssChange(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			ArrayList alAssChange=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbAssChange where dtChangeDate>'" + strBeginDate + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);

				for(int i=0;i<dtAss.Rows.Count;i++)
				{
					CMSMStruct.AssChangeStruct asstmp=new CMSMData.CMSMStruct.AssChangeStruct();
					asstmp.strCardID=dtAss.Rows[i]["vcCardID"].ToString();
					asstmp.strChangeField=dtAss.Rows[i]["vcChangeField"].ToString();
					asstmp.strChangeValue=dtAss.Rows[i]["vcChangeValue"].ToString();
					asstmp.strOperDate=dtAss.Rows[i]["dtChangeDate"].ToString();
					alAssChange.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alAssChange;
		}

		public ArrayList DownGoodsData(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtAss=new DataTable();
			ArrayList alAss=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbGoods order by vcGoodsID";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtAss);

				for(int i=0;i<dtAss.Rows.Count;i++)
				{
					CMSMStruct.GoodsStruct asstmp=new CMSMData.CMSMStruct.GoodsStruct();
					asstmp.strGoodsID=dtAss.Rows[i]["vcGoodsID"].ToString();
					asstmp.strGoodsName=dtAss.Rows[i]["vcGoodsName"].ToString();
					asstmp.strSpell=dtAss.Rows[i]["vcSpell"].ToString();
					asstmp.dPrice=double.Parse(dtAss.Rows[i]["nPrice"].ToString());
					asstmp.dRate=double.Parse(dtAss.Rows[i]["nRate"].ToString());
					asstmp.iIgValue=int.Parse(dtAss.Rows[i]["iIgValue"].ToString());
					asstmp.strNewFlag=dtAss.Rows[i]["cNewFlag"].ToString();
					asstmp.strComments=dtAss.Rows[i]["vcComments"].ToString();
					alAss.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alAss;
		}

		public ArrayList DownCons(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			ArrayList alCons=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbConsItem where dtConsDate>'" + strBeginDate + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);

				for(int i=0;i<dtCons.Rows.Count;i++)
				{
					CMSMStruct.ConsDownStruct asstmp=new CMSMData.CMSMStruct.ConsDownStruct();
					asstmp.strSerial=dtCons.Rows[i]["iSerial"].ToString();
					asstmp.strGoodsID=dtCons.Rows[i]["vcGoodsID"].ToString();
					asstmp.strAssID=dtCons.Rows[i]["iAssID"].ToString();
					asstmp.strCardID=dtCons.Rows[i]["vcCardID"].ToString();
					asstmp.dPrice=double.Parse(dtCons.Rows[i]["nPrice"].ToString());
					asstmp.iCount=int.Parse(dtCons.Rows[i]["iCount"].ToString());
					asstmp.dTRate=double.Parse(dtCons.Rows[i]["nTRate"].ToString());
					asstmp.dFee=double.Parse(dtCons.Rows[i]["nFee"].ToString());
					asstmp.strFlag=dtCons.Rows[i]["cFlag"].ToString();
					asstmp.strConsDate=dtCons.Rows[i]["dtConsDate"].ToString();
					asstmp.strOperName=dtCons.Rows[i]["vcOperName"].ToString();
					asstmp.strDeptID=dtCons.Rows[i]["vcDeptID"].ToString();
					alCons.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alCons;
		}

		public ArrayList DownBill(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtBill=new DataTable();
			ArrayList alBill=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbBill where dtConsDate>'" + strBeginDate + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtBill);

				for(int i=0;i<dtBill.Rows.Count;i++)
				{
					CMSMStruct.BillStruct asstmp=new CMSMData.CMSMStruct.BillStruct();
					asstmp.strSerial=dtBill.Rows[i]["iSerial"].ToString();
					asstmp.strAssID=dtBill.Rows[i]["iAssID"].ToString();
					asstmp.strCardID=dtBill.Rows[i]["vcCardID"].ToString();
					asstmp.dTRate=double.Parse(dtBill.Rows[i]["nTRate"].ToString());
					asstmp.dFee=double.Parse(dtBill.Rows[i]["nFee"].ToString());
					asstmp.dPay=double.Parse(dtBill.Rows[i]["nPay"].ToString());
					asstmp.dBalance=double.Parse(dtBill.Rows[i]["nBalance"].ToString());
					asstmp.iIgValue=int.Parse(dtBill.Rows[i]["iIgValue"].ToString());
					asstmp.strConsType=dtBill.Rows[i]["vcConsType"].ToString();
					asstmp.strOperName=dtBill.Rows[i]["vcOperName"].ToString();
					asstmp.strConsDate=dtBill.Rows[i]["dtConsDate"].ToString();
					asstmp.strDeptID=dtBill.Rows[i]["vcDeptID"].ToString();
					alBill.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alBill;
		}

		public ArrayList DownIntegral(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtIg=new DataTable();
			ArrayList alIg=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbIntegralLog where dtIgDate>'" + strBeginDate + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtIg);

				for(int i=0;i<dtIg.Rows.Count;i++)
				{
					CMSMStruct.IntegralStruct asstmp=new CMSMData.CMSMStruct.IntegralStruct();
					asstmp.strSerial=dtIg.Rows[i]["iSerial"].ToString();
					asstmp.strAssID=dtIg.Rows[i]["iAssID"].ToString();
					asstmp.strCardID=dtIg.Rows[i]["vcCardID"].ToString();
					asstmp.strIgType=dtIg.Rows[i]["vcIgType"].ToString();
					asstmp.iIgLast=int.Parse(dtIg.Rows[i]["iIgLast"].ToString());
					asstmp.iIgGet=int.Parse(dtIg.Rows[i]["iIgGet"].ToString());
					asstmp.iIgArrival=int.Parse(dtIg.Rows[i]["iIgArrival"].ToString());
					asstmp.iLinkCons=int.Parse(dtIg.Rows[i]["iLinkCons"].ToString());
					asstmp.strIgDate=dtIg.Rows[i]["dtIgDate"].ToString();
					asstmp.strOperName=dtIg.Rows[i]["vcOperName"].ToString();
					asstmp.strComments=dtIg.Rows[i]["vcComments"].ToString();
					asstmp.strDeptID=dtIg.Rows[i]["vcDeptID"].ToString();
					alIg.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alIg;
		}

		public ArrayList DownFillFee(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtFill=new DataTable();
			ArrayList alFill=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbFillFee where dtFillDate>'" + strBeginDate + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtFill);

				for(int i=0;i<dtFill.Rows.Count;i++)
				{
					CMSMStruct.FillFeeStruct asstmp=new CMSMData.CMSMStruct.FillFeeStruct();
					asstmp.strSerial=dtFill.Rows[i]["iSerial"].ToString();
					asstmp.strAssID=dtFill.Rows[i]["iAssID"].ToString();
					asstmp.strCardID=dtFill.Rows[i]["vcCardID"].ToString();
					asstmp.dFillFee=double.Parse(dtFill.Rows[i]["nFillFee"].ToString());
					asstmp.dFillProm=double.Parse(dtFill.Rows[i]["nFillProm"].ToString());
					asstmp.dFeeLast=double.Parse(dtFill.Rows[i]["nFeeLast"].ToString());
					asstmp.dFeeCur=double.Parse(dtFill.Rows[i]["nFeeCur"].ToString());
					asstmp.strFillDate=dtFill.Rows[i]["dtFillDate"].ToString();
					asstmp.strComments=dtFill.Rows[i]["vcComments"].ToString();
					asstmp.strOperName=dtFill.Rows[i]["vcOperName"].ToString();
					asstmp.strDeptID=dtFill.Rows[i]["vcDeptID"].ToString();
					alFill.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alFill;
		}

		public ArrayList DownBusiLog(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtBusi=new DataTable();
			ArrayList alBusi=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbBusiLog where dtOperDate>'" + strBeginDate + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtBusi);

				for(int i=0;i<dtBusi.Rows.Count;i++)
				{
					CMSMStruct.BusiLogStruct asstmp=new CMSMData.CMSMStruct.BusiLogStruct();
					asstmp.strSerial=dtBusi.Rows[i]["iSerial"].ToString();
					asstmp.strAssID=dtBusi.Rows[i]["iAssID"].ToString();
					asstmp.strCardID=dtBusi.Rows[i]["vcCardID"].ToString();
					asstmp.strOperType=dtBusi.Rows[i]["vcOperType"].ToString();
					asstmp.strOperName=dtBusi.Rows[i]["vcOperName"].ToString();
					asstmp.strOperDate=dtBusi.Rows[i]["dtOperDate"].ToString();
					asstmp.strComments=dtBusi.Rows[i]["vcComments"].ToString();
					asstmp.strDeptID=dtBusi.Rows[i]["vcDeptID"].ToString();
					alBusi.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alBusi;
		}

		public ArrayList DownEmpSign(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtes=new DataTable();
			ArrayList ales=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbEmpSign where dtSignDate>'" + strBeginDate + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtes);

				for(int i=0;i<dtes.Rows.Count;i++)
				{
					CMSMStruct.EmpSignStruct asstmp=new CMSMData.CMSMStruct.EmpSignStruct();
					asstmp.strSerial=dtes.Rows[i]["iSerial"].ToString();
					asstmp.strCardID=dtes.Rows[i]["vcCardID"].ToString();
					asstmp.strCardID=dtes.Rows[i]["vcCardID"].ToString();
					asstmp.strEmpName=dtes.Rows[i]["vcEmpName"].ToString();
					asstmp.strSignDate=dtes.Rows[i]["dtSignDate"].ToString();
					asstmp.strClass=dtes.Rows[i]["vcClass"].ToString();
					asstmp.strSignFlag=dtes.Rows[i]["vcSignFlag"].ToString();
					asstmp.strComments=dtes.Rows[i]["vcComments"].ToString();
					asstmp.strDeptID=dtes.Rows[i]["vcDeptID"].ToString();
					ales.Add(asstmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return ales;
		}

		public ArrayList DownEmpInfo(string strBeginDate,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtemp=new DataTable();
			ArrayList alemp=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbEmployee where dtOperDate>'" + strBeginDate + "'";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtemp);

				for(int i=0;i<dtemp.Rows.Count;i++)
				{
					CMSMStruct.EmployeeStruct Emptmp=new CMSMData.CMSMStruct.EmployeeStruct();
					Emptmp.strCardID=dtemp.Rows[i]["vcCardID"].ToString();
					Emptmp.strEmpName=dtemp.Rows[i]["vcEmpName"].ToString();
					Emptmp.strSex=dtemp.Rows[i]["vcSex"].ToString();
					Emptmp.strEmpNbr=dtemp.Rows[i]["vcEmpNbr"].ToString();
					Emptmp.strInDate=dtemp.Rows[i]["dtInDate"].ToString();
					Emptmp.strDegree=dtemp.Rows[i]["vcDegree"].ToString();
					Emptmp.strLinkPhone=dtemp.Rows[i]["vcLinkPhone"].ToString();
					Emptmp.strAddress=dtemp.Rows[i]["vcAddress"].ToString();
					Emptmp.strPwd=dtemp.Rows[i]["vcPwd"].ToString();
					Emptmp.strOfficer=dtemp.Rows[i]["vcOfficer"].ToString();
					Emptmp.strDeptID=dtemp.Rows[i]["vcDeptID"].ToString();
					Emptmp.strFlag=dtemp.Rows[i]["vcFlag"].ToString();
					Emptmp.strComments=dtemp.Rows[i]["vcComments"].ToString();
					Emptmp.strOperDate=dtemp.Rows[i]["dtOperDate"].ToString();
					alemp.Add(Emptmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alemp;
		}

		public ArrayList DownSysPara(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtPara=new DataTable();
			ArrayList alPara=new ArrayList();
			try
			{
				con.Open();
				err=null;
				sql1="select * from tbCommCode where vcCommSign<>'LOCAL' and vcCommCode<>'CEN00' order by vcCommSign,vcCommCode";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtPara);

				for(int i=0;i<dtPara.Rows.Count;i++)
				{
					CMSMStruct.CommStruct paratmp=new CMSMData.CMSMStruct.CommStruct();
					paratmp.strCommName=dtPara.Rows[i]["vcCommName"].ToString();
					paratmp.strCommCode=dtPara.Rows[i]["vcCommCode"].ToString();
					paratmp.strCommSign=dtPara.Rows[i]["vcCommSign"].ToString();
					paratmp.strComments=dtPara.Rows[i]["vcComments"].ToString();
					alPara.Add(paratmp);
				}
			}
			catch(Exception e)
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return alPara;
		}
		#endregion

		#region UpLoadData
		public void TruncateDataTmp(out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				err=null;
				con.Open();
				sql1="truncate table tbAssociatorDownUpTmp;truncate table tbBillDownUpTmp;truncate table tbBusiLogDownUpTmp;truncate table tbConsItemDownUpTmp;truncate table tbFillFeeDownUpTmp;truncate table tbIntegralLogDownUpTmp;truncate table tbEmpSignTmp;truncate table tbEmployeeTmp;";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
		}

		public void TruncateParaTmp(out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				err=null;
				con.Open();
				sql1="truncate table tbCommCodeTmp;truncate table tbGoodsTmp;";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
		}

		public void UpAllData(string filePath,string strUpName,out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				err=null;

				con.Open();
//				//创建数据库，还原形式
//				string strtomdf=@"E:\\BreadWorksDataBak\\AMSCMTemp.mdf";
//				string strtoldf=@"E:\\BreadWorksDataBak\\AMSCMTemp.ldf";
//				string sql2="exec('RESTORE DATABASE AMSCMTemp FROM DISK = ''" + filePath + strUpName + "'' WITH MOVE ''AMSCMTemp_Data'' TO ''" + strtomdf + "'',MOVE ''AMSCMTemp_Log'' TO ''" + strtoldf + "''')";
//				cmd=new SqlCommand(sql2,con);
//				cmd.CommandTimeout=600;
//				cmd.ExecuteNonQuery();

				sql3="exec sp_UpData";
				cmd=new SqlCommand(sql3,con);
				cmd.CommandTimeout=600;
				cmd.ExecuteNonQuery();

				sql1="truncate table tbAssociatorDownUpTmp;truncate table tbBillDownUpTmp;truncate table tbBusiLogDownUpTmp;truncate table tbConsItemDownUpTmp;truncate table tbFillFeeDownUpTmp;truncate table tbIntegralLogDownUpTmp;truncate table tbEmpSignTmp;truncate table tbEmployeeTmp;";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
		}

		public void UpAllPara(out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="delete from tbCommCode where vcCommSign<>'LOCAL'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbCommCode select * from tbCommCodeTmp where vcCommSign<>'LOCAL'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();
				}
				catch(Exception e)
				{
					err=e;
					trans.Rollback();
					if(con.State==ConnectionState.Open)
					{
						con.Close();
					}
				}
				finally
				{
					if(con.State==ConnectionState.Open)
					{
						con.Close();
					}
				}
			}
		}

		public void UpAllGoods(out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="truncate table tbGoods";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbGoods select * from tbGoodsTmp";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();
				}
				catch(Exception e)
				{
					err=e;
					trans.Rollback();
					if(con.State==ConnectionState.Open)
					{
						con.Close();
					}
				}
				finally
				{
					if(con.State==ConnectionState.Open)
					{
						con.Close();
					}
				}
			}
		}

		public void UpOtherDeptData(string filePath,string strUpName,out Exception err)
		{
			try
			{
				err=null;
				con.Open();

				//创建数据库，还原形式
//				string strtomdf=@"E:\\BreadWorksDataBak\\AMSCMTemp.mdf";
//				string strtoldf=@"E:\\BreadWorksDataBak\\AMSCMTemp.ldf";
//				string sql2="exec('RESTORE DATABASE AMSCMTemp FROM DISK = ''" + filePath + strUpName + "'' WITH MOVE ''AMSCMTemp_Data'' TO ''" + strtomdf + "'',MOVE ''AMSCMTemp_Log'' TO ''" + strtoldf + "''')";
//				cmd=new SqlCommand(sql2,con);
//				cmd.CommandTimeout=600;
//				cmd.ExecuteNonQuery();

				string sql3="exec sp_MainDeptUpData";
				cmd.CommandTimeout=600;
				cmd=new SqlCommand(sql3,con);
				cmd.ExecuteNonQuery();
		
				sql1="truncate table tbAssociatorDownUpTmp;truncate table tbBillDownUpTmp;truncate table tbBusiLogDownUpTmp;truncate table tbConsItemDownUpTmp;truncate table tbFillFeeDownUpTmp;truncate table tbIntegralLogDownUpTmp;";
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
		}

		public bool UpAssData(CMSMStruct.AssociatorStruct assnew,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
			try
			{
				sql2="insert into tbAssociatorDownUpTmp values(" + assnew.strAssID + ",'" + assnew.strCardID + "','" + assnew.strAssName + "','" + assnew.strSpell + "','" + assnew.strAssNbr + "','" + assnew.strLinkPhone + "','" + assnew.strLinkAddress + "','" + assnew.strEmail + "','" + assnew.strAssType + "','";
				sql2+=assnew.strAssState + "'," + assnew.dCharge.ToString() + "," + assnew.iIgValue.ToString() + ",'" + assnew.strCardFlag + "','" + assnew.strComments + "','" + assnew.strCreateDate + "','" + assnew.strOperDate + "','" + assnew.strDeptID + "')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpNoticeDate(CMSMStruct.NoticeStruct notis,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			try
			{
				sql1="select count(*) from tbNotice where id='" + notis.strID + "'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				string strRecordCount=drr[0].ToString();
				drr.Close();
				if(strRecordCount=="0")
				{
					sql2="insert into tbNotice values('"+notis.strID+"','"+notis.strComments+"','"+notis.strCreateDate+"','"+notis.strActiveFlag+"','"+notis.strDeptFlag+"')";
					cmd=new SqlCommand(sql2,con);
					cmd.ExecuteNonQuery();
				}
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpAssAlterData(CMSMStruct.AssChangeStruct asschange,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					sql1="select count(*) from tbAssChange where vcCardID='" + asschange.strCardID + "' and vcChangeField='" + asschange.strChangeField + "' and dtChangeDate>'" + asschange.strOperDate + "'";
					cmd=new SqlCommand(sql1,con,trans);
					drr=cmd.ExecuteReader();
					drr.Read();
					string strRecordCount=drr[0].ToString();
					drr.Close();
					if(strRecordCount=="0")
					{
						if(asschange.strChangeField=="nCharge"||asschange.strChangeField=="iIgValue")
						{
							sql2="update tbAssociator set " + asschange.strChangeField + "=" + asschange.strChangeValue + " where vcCardID='" + asschange.strCardID + "'";
						}
						else
						{
							sql2="update tbAssociator set " + asschange.strChangeField + "='" + asschange.strChangeValue + "' where vcCardID='" + asschange.strCardID + "'";
						}
						cmd=new SqlCommand(sql2,con,trans);
						cmd.ExecuteNonQuery();

						sql3="update tbAssChange set dtChangeDate='" + asschange.strOperDate + "' where vcCardID='" + asschange.strCardID + "' and vcChangeField='" + asschange.strChangeField + "'";
						cmd=new SqlCommand(sql3,con,trans);
						cmd.ExecuteNonQuery();
						flag="YES";
					}
					trans.Commit();
				}
				catch(Exception e)
				{
					err=e;
					trans.Rollback();
					return false;
				}
				finally
				{
					con.Close();
				}
				return true;
			}
		}

		public bool UpGoodsData(CMSMStruct.GoodsStruct goods,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
			try
			{
				sql2="insert into tbGoodsTmp values('" + goods.strGoodsID + "','" + goods.strGoodsName + "','" + goods.strSpell + "'," + goods.dPrice.ToString() + "," + goods.dRate.ToString() + "," + goods.iIgValue.ToString() + ",'" + goods.strNewFlag + "','" + goods.strComments + "')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpConsData(CMSMStruct.ConsDownStruct consd,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
			try
			{
				sql2="insert into tbConsItemDownUpTmp values(" + consd.strSerial + ",'" + consd.strGoodsID + "'," + consd.strAssID + ",'" + consd.strCardID + "'," + consd.dPrice.ToString() + "," + consd.iCount.ToString() + ",";
				sql2+=consd.dTRate.ToString() + "," + consd.dFee.ToString() + ",'" + consd.strComments + "','" + consd.strFlag + "','" + consd.strConsDate + "','" + consd.strOperName + "','" + consd.strDeptID + "')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpBillData(CMSMStruct.BillStruct bis,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
//			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
//			{
//				try
//				{
//					sql1="select count(*) from tbBillOther where iSerial=" + bis.strSerial + " and vcDeptID='" + bis.strDeptID + "'";
//					cmd=new SqlCommand(sql1,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					string strRecordCount=drr[0].ToString();
//					drr.Close();
//					if(strRecordCount=="0")
//					{
//						sql2="insert into tbBillOther values(" + bis.strSerial + "," + bis.strAssID + ",'" + bis.strCardID + "'," + bis.dTRate.ToString() + "," + bis.dFee.ToString() + "," + bis.dPay.ToString() + "," + bis.dBalance.ToString() + "," +bis.iIgValue.ToString() + ",'" + bis.strConsType + "','" + bis.strOperName + "','" + bis.strConsDate + "','" + bis.strDeptID + "')";
//						cmd=new SqlCommand(sql2,con,trans);
//						cmd.ExecuteNonQuery();
//						flag="YES";
//					}
//					trans.Commit();
//				}
//				catch(Exception e)
//				{
//					err=e;
//					trans.Rollback();
//					return false;
//				}
//				finally
//				{
//					con.Close();
//				}
//				return true;
//			}

			try
			{
				sql2="insert into tbBillDownUpTmp values(" + bis.strSerial + "," + bis.strAssID + ",'" + bis.strCardID + "'," + bis.dTRate.ToString() + "," + bis.dFee.ToString() + "," + bis.dPay.ToString() + "," + bis.dBalance.ToString() + "," +bis.iIgValue.ToString() + ",'" + bis.strConsType + "','" + bis.strOperName + "','" + bis.strConsDate + "','" + bis.strDeptID + "')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpIntegralData(CMSMStruct.IntegralStruct its,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
//			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
//			{
//				try
//				{
//					sql1="select count(*) from tbIntegralLogOther where iSerial=" + its.strSerial + " and vcDeptID='" + its.strDeptID + "'";
//					cmd=new SqlCommand(sql1,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					string strRecordCount=drr[0].ToString();
//					drr.Close();
//					if(strRecordCount=="0")
//					{
//						sql2="insert into tbIntegralLogOther values(" + its.strSerial + "," + its.strAssID + ",'" + its.strCardID + "','" + its.strIgType + "'," + its.iIgLast.ToString() + "," + its.iIgGet.ToString() + "," + its.iIgArrival.ToString() + "," + its.iLinkCons.ToString() + ",'" + its.strIgDate + "','" + its.strOperName + "','" + its.strComments +"','" + its.strDeptID + "')";
//						cmd=new SqlCommand(sql2,con,trans);
//						cmd.ExecuteNonQuery();
//						flag="YES";
//					}
//					trans.Commit();
//				}
//				catch(Exception e)
//				{
//					err=e;
//					trans.Rollback();
//					return false;
//				}
//				finally
//				{
//					con.Close();
//				}
//				return true;
//			}

			try
			{
				sql2="insert into tbIntegralLogDownUpTmp values(" + its.strSerial + "," + its.strAssID + ",'" + its.strCardID + "','" + its.strIgType + "'," + its.iIgLast.ToString() + "," + its.iIgGet.ToString() + "," + its.iIgArrival.ToString() + "," + its.iLinkCons.ToString() + ",'" + its.strIgDate + "','" + its.strOperName + "','" + its.strComments +"','" + its.strDeptID + "')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpFillData(CMSMStruct.FillFeeStruct ffs,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
//			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
//			{
//				try
//				{
//					sql1="select count(*) from tbFillFeeOther where iSerial=" + ffs.strSerial + " and vcDeptID='" + ffs.strDeptID + "'";
//					cmd=new SqlCommand(sql1,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					string strRecordCount=drr[0].ToString();
//					drr.Close();
//					if(strRecordCount=="0")
//					{
//						sql2="insert into tbFillFeeOther values(" + ffs.strSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "'," + ffs.dFillFee + "," + ffs.dFillProm + "," + ffs.dFeeLast + "," + ffs.dFeeCur + ",'" + ffs.strFillDate + "','" + ffs.strComments + "','" + ffs.strOperName + "','" + ffs.strDeptID + "')";
//						cmd=new SqlCommand(sql2,con,trans);
//						cmd.ExecuteNonQuery();
//						flag="YES";
//					}
//					trans.Commit();
//				}
//				catch(Exception e)
//				{
//					err=e;
//					trans.Rollback();
//					return false;
//				}
//				finally
//				{
//					con.Close();
//				}
//				return true;
//			}

			try
			{
				sql2="insert into tbFillFeeDownUpTmp values(" + ffs.strSerial + "," + ffs.strAssID + ",'" + ffs.strCardID + "'," + ffs.dFillFee + "," + ffs.dFillProm + "," + ffs.dFeeLast + "," + ffs.dFeeCur + ",'" + ffs.strFillDate + "','" + ffs.strComments + "','" + ffs.strOperName + "','" + ffs.strDeptID + "')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpBusiLogData(CMSMStruct.BusiLogStruct blogs,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
//			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
//			{
//				try
//				{
//					sql1="select count(*) from tbBusiLogOther where iSerial=" + blogs.strSerial + " and vcDeptID='" + blogs.strDeptID + "'";
//					cmd=new SqlCommand(sql1,con,trans);
//					drr=cmd.ExecuteReader();
//					drr.Read();
//					string strRecordCount=drr[0].ToString();
//					drr.Close();
//					if(strRecordCount=="0")
//					{
//						sql2="insert into tbBusiLogOther values(" + blogs.strSerial + "," + blogs.strAssID + ",'" + blogs.strCardID + "','" + blogs.strOperType + "','" + blogs.strOperName + "','" + blogs.strOperDate + "','" + blogs.strComments + "','" + blogs.strDeptID + "')";
//						cmd=new SqlCommand(sql2,con,trans);
//						cmd.ExecuteNonQuery();
//						flag="YES";
//					}
//					trans.Commit();
//				}
//				catch(Exception e)
//				{
//					err=e;
//					trans.Rollback();
//					return false;
//				}
//				finally
//				{
//					con.Close();
//				}
//				return true;
//			}

			try
			{
				sql2="insert into tbBusiLogDownUpTmp values(" + blogs.strSerial + "," + blogs.strAssID + ",'" + blogs.strCardID + "','" + blogs.strOperType + "','" + blogs.strOperName + "','" + blogs.strOperDate + "','" + blogs.strComments + "','" + blogs.strDeptID + "')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpEmpSignData(CMSMStruct.EmpSignStruct emps,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
			try
			{
				sql2="insert into tbEmpSignTmp values("+emps.strSerial+",'" +emps.strCardID+"','"+emps.strEmpName+"','"+emps.strSignDate+"','"+emps.strClass+"','"+emps.strSignFlag+"','"+emps.strComments+"','"+emps.strDeptID+"')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpEmployeeData(CMSMStruct.EmployeeStruct empinfo,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
			try
			{
				sql2="insert into tbEmployeeTmp values('" +empinfo.strCardID+"','"+empinfo.strEmpName+"','"+empinfo.strSex+"','"+empinfo.strEmpNbr+"','"+empinfo.strInDate+"','"+empinfo.strDegree+"','"+empinfo.strLinkPhone+"','"+empinfo.strAddress+"','"+empinfo.strPwd+"','"+empinfo.strOfficer+"','"+empinfo.strDeptID+"','"+empinfo.strFlag+"','"+empinfo.strComments+"','"+empinfo.strOperDate+"')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}

		public bool UpCommData(CMSMStruct.CommStruct comm,out string flag,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			err=null;
			flag="NO";
			try
			{
				sql2="insert into tbCommCodeTmp values('" + comm.strCommName + "','" + comm.strCommCode + "','" + comm.strCommSign + "','" + comm.strComments + "')";
				cmd=new SqlCommand(sql2,con);
				cmd.ExecuteNonQuery();
				flag="YES";
			}
			catch(Exception e)
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
			return true;
		}
		#endregion

		#region DeptManage
		public bool GetMainDept(out Exception err)
		{
			this.MaskSqlToNull();
			err=null;
			try
			{
				con.Open();
				sql1="select count(*) from tbCommCode where vcCommSign='MainD'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				if(drr[0].ToString()=="0")
				{
					drr.Close();
					return false;
				}
				else
				{
					drr.Close();
					return true;
				}	
			}
			catch (Exception e) 
			{
				err=e;
				return false;
			}
			finally
			{
				con.Close();
			}
		}

		public string GetLocalDept(out Exception err)
		{
			this.MaskSqlToNull();
			string strDeptID="";
			err=null;
			try
			{
				con.Open();
				sql1="select count(*) from tbCommCode where vcCommSign='LOCAL'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				strDeptID=drr[0].ToString();
				drr.Close();
				if(strDeptID=="0")
				{
					strDeptID="";
				}
				else
				{
					sql1="select vcCommCode from tbCommCode where vcCommSign='LOCAL'";
					cmd=new SqlCommand(sql1,con);
					drr=cmd.ExecuteReader();
					drr.Read();
					strDeptID=drr[0].ToString();
					drr.Close();
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return strDeptID;
		}

		public string GetCP(out Exception err)
		{
			this.MaskSqlToNull();
			string CP="";
			err=null;
			try
			{
				con.Open();
					sql1="select vcCommName from tbCommCode where vcCommSign='CP'";
					cmd=new SqlCommand(sql1,con);
					drr=cmd.ExecuteReader();
					drr.Read();
					CP=drr[0].ToString();
					drr.Close();
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return CP;
		}

		public string GetTP(out Exception err)
		{
			this.MaskSqlToNull();
			string TP_Price="";
			err=null;
			try
			{
				con.Close();
				con.Open();
				sql1="select vcCommCode from tbCommCode where vcCommSign='TP'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				TP_Price=drr[0].ToString();
				drr.Close();
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return TP_Price;
		}


		public string GetCard(out Exception err)
		{
			this.MaskSqlToNull();
			string Card="";
			err=null;
			try
			{
				con.Open();
				sql1="select vcCommCode from tbCommCode where vcCommSign='Card'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				Card=drr[0].ToString();
				drr.Close();
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return Card;
		}

		public string GetTel(out Exception err)
		{
			this.MaskSqlToNull();
			string Local="";
			string Tel="";
			err=null;
			try
			{
				con.Open();
				sql1="select vcCommCode from tbCommCode where vcCommSign = 'LOCAL'";
				cmd=new SqlCommand(sql1,con);
				drr=cmd.ExecuteReader();
				drr.Read();
				Local=drr[0].ToString();
				drr.Close();
				con.Close();

				con.Open();
				sql2="select vcComments from tbCommCode where vcCommCode = '" + Local + "' and vcCommSign='MD'";
				cmd=new SqlCommand(sql2,con);
				drr1=cmd.ExecuteReader();
				drr1.Read();
				Tel=drr1[0].ToString();
				drr1.Close();
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return Tel;
		}

		public void SetLocalDept(string strDeptName,string strDeptID,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="insert into tbCommCode values('" + strDeptName + "','" + strDeptID + "','LOCAL','本地门店')";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region Report
		public DataTable BusiIncomeReport(string strDeptID,string strBegin,string strEnd,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dttmp=new DataTable();
			try
			{
				con.Open();
				err=null;

				sql1="exec sp_BusiIncomeReport '" + strDeptID + "','" + strBegin + "','" + strEnd + "'";
				cmd=new SqlCommand(sql1,con);
				cmd.CommandTimeout=1000;
				cmd.ExecuteNonQuery();

				sql2="select Type,REP1,REP2,REP3,REP4,REP5,REP6,REP7 from tbBusiIncomeReport where vcDateZoom='" + strBegin+strEnd + "' order by ReNo";
				cmd=new SqlCommand(sql2,con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dttmp);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dttmp;
		}

		public DataTable TopGoodsQuery(string strDeptID,string strBegin,string strEnd,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtTop=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select  b.vcGoodsName,sum(iCount) from vwConsItem a,tbGoods b where a.cFlag='0' and a.vcGoodsID=b.vcGoodsID and a.dtConsDate>='" + strBegin +"' and a.dtConsDate<='" + strEnd +"' and a.vcDeptID like '" + strDeptID + "' ";
				sql1+=" group by vcGoodsName order by sum(iCount) desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtTop);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtTop;
		}

		public DataTable TopAssQuery(string strDeptID,string strBegin,string strEnd,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtTop=new DataTable();
			try
			{
				con.Open();
				err=null;
				sql1="select a.vcCardID,b.vcAssName,b.vcLinkPhone,sum(nFee) from vwConsItem a,tbAssociator b where a.cFlag='0' and b.vcAssType<>'AT002' and a.vcCardID<>'VMaster' and a.vcCardID=b.vcCardID and a.dtConsDate>='" + strBegin +"' and a.dtConsDate<='" + strEnd +"' and a.vcDeptID like '" + strDeptID + "' and a.vcCardID<>'V9999'";
				sql1+=" group by a.vcCardID,b.vcAssName,b.vcLinkPhone order by sum(nFee) desc";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtTop);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtTop;
		}
		#endregion

		#region DataToHis
		public DataTable GetCurrentMonth(out Exception err)
		{
			this.MaskSqlToNull();
			err=null;
			DataTable dtmonth=new DataTable();
			try
			{
				sql1="select distinct convert(char(6),dtOperDate,112) as curmonth from tbBusiLog where convert(char(6),dtOperDate,112)<convert(char(6),dateadd(Month,-1,getdate()),112) order by convert(char(6),dtOperDate,112)";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtmonth);
				return dtmonth;
			}
			catch (Exception e) 
			{
				err=e;
				return dtmonth;
			}
			finally
			{
				con.Close();
			}
		}

		public bool AllDataToHis(string strmonth,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					sql1="insert into tbBillHis select * from tbBill where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

					sql2="insert into tbBusiLogHis select * from tbBusiLog where convert(char(6),dtOperDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();

					sql3="insert into tbConsItemHis select * from tbConsItem where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql3,con,trans);
					cmd.ExecuteNonQuery();

					sql4="insert into tbFillFeeHis select * from tbFillFee where convert(char(6),dtFillDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql4,con,trans);
					cmd.ExecuteNonQuery();

					sql5="insert into tbIntegralLogHis select * from tbIntegralLog where convert(char(6),dtIgDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql5,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbBill where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbBusiLog where convert(char(6),dtOperDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbConsItem where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbFillFee where convert(char(6),dtFillDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbBill where convert(char(6),dtConsDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					sql6="delete from tbIntegralLog where convert(char(6),dtIgDate,112)='" + strmonth + "'";
					cmd=new SqlCommand(sql6,con,trans);
					cmd.ExecuteNonQuery();

					trans.Commit();
					return true;
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
					return false;
				}
				finally
				{
					con.Close();
				}
			}
		}
		#endregion

		#region System Error
		public void WriteError(string strErr)
		{
			this.MaskSqlToNull();
			if(SysInitial.LocalDept!="")
			{
				strErr=strErr.Replace("'","");
				con.Open();
				if(strErr.Length>3000)
				{
					sql1="insert into tbSysErrorLog values('"+SysInitial.LocalDept+"',getdate(),'"+strErr.Substring(0,3000)+"')";
				}
				else
				{
					sql1="insert into tbSysErrorLog values('"+SysInitial.LocalDept+"',getdate(),'"+strErr+"')";
				}
				cmd=new SqlCommand(sql1,con);
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
		#endregion

		#region Make strsql to null
		private void MaskSqlToNull()
		{
			sql1="";
			sql2="";
			sql3="";
			sql4="";
			sql5="";
			sql6="";
			sql7="";
			sql7="";
			sql8="";
			sql9="";
			sql10="";
		}
		#endregion

		public void Tmpupdate(out Exception err)
		{
			this.MaskSqlToNull();
			try
			{
				err=null;
//				con.Open();
//				sql1="update tbFillFee set vcComments='' where vcComments ='补充值，由于操作错误' and dtFillDate between '2008-05-01'and '2008-05-06 23:00:00'";
//				cmd=new SqlCommand(sql1,con);
//				cmd.ExecuteNonQuery();
//
//				sql1="update tbBusiLog set vcOperType='OP003',vcComments='充值' where vcOpertype='OP008' and dtOperDate between '2008-05-01'and '2008-05-06 23:00:00'";
//				cmd=new SqlCommand(sql1,con);
//				cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				err=e;
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
			finally
			{
				if(con.State==ConnectionState.Open)
				{
					con.Close();
				}
			}
		}

		#region 生产入库
//		private string GetAnchor(AnchorType at,SqlTransaction trans)
//		{
//			cmd=new SqlCommand(string.Format("select Anchor from SyncAnchor where id={0}",(int)at),con,trans);
//			object obj = cmd.ExecuteScalar();
//			string anchor = "0";
//			if(obj!=null)
//			{
//				string str=obj.ToString();
//				if(str.Length>0)
//				{
//					anchor=str;
//				}
//			}
//			return anchor;
//		}
		private int GetOperType(int id,AnchorType at,SqlTransaction trans)
		{
			int operType = (int)TableOperType.Insert;	
			switch(at)
			{
				case AnchorType.ProductionInStorage:
					cmd=new SqlCommand(string.Format("select count(1) from ProductionInStorage where id={0} and vercol>=(select cast(Anchor as int) from SyncAnchor where id={1})",id,(int)at),con,trans);
					break;
				case AnchorType.SaleCheck:
					cmd=new SqlCommand(string.Format("select count(1) from SaleCheck where id={0} and vercol>=(select cast(Anchor as int) from SyncAnchor where id={1})",id,(int)at),con,trans);
					break;
			}
			
			object obj = cmd.ExecuteScalar();
			if(obj!=null)
			{
				string str = obj.ToString();
				if(str.Length>0)
				{
					int count = Convert.ToInt32(str);
					if(count>0)
					{
						operType = (int)TableOperType.Update;
					}
				}
			}
			return operType;
		}
		public bool ProductionInStorageExist(string strDeptId,string strInDate,string strGoodsId)
		{
			try
			{
				con.Open();			
				cmd=new SqlCommand(string.Format("select count(1) from ProductionInStorage where vcDeptId='{0}' and InDate='{1}' and vcGoodsId='{2}'",strDeptId,strInDate,strGoodsId),con);
				object obj = cmd.ExecuteScalar();
				if(obj!=null)
				{
					string str = obj.ToString();
					if(str.Length>0)
					{
						return Convert.ToInt32(str)>0;
					}
				}
			}
			catch (Exception ex) 
			{
				throw ex;
			}
			finally
			{
				con.Close();
			}
			return false;
		}
		public void ProductionInStorage(CMSMData.CMSMStruct.ConsItemStruct cis,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strsql = "insert into ProductionInStorage (vcDeptId,InDate,vcGoodsId,Quantity,vcOperId,CreateDate,OperType)values('{0}','{1}','{2}',{3},'{4}',getdate(),{5});";
										
					//string anchor = GetAnchor(AnchorType.ProductionInStorage,trans);
					for(int i=0;i<cis.dtItem.Rows.Count;i++)
					{
						int id = Convert.ToInt32(cis.dtItem.Rows[i]["Id"]);
						string strQuantity = cis.dtItem.Rows[i]["Count"].ToString();
						if(id>0)
						{
							int operType = GetOperType(id,AnchorType.ProductionInStorage,trans);
							sql1+=string.Format("update ProductionInStorage set Quantity={0},OperType={2} where Id={1};",strQuantity,id,operType);
						}
						else
						{
							sql1+=string.Format(strsql,cis.strDeptID,cis.strOperDate,cis.dtItem.Rows[i]["GoodsID"].ToString(),strQuantity,cis.strOperName,(int)TableOperType.Insert);
						}
					}
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    DateTime dtNow = DateTime.Now;
                    string striSerial = dtNow.ToString("yyyyMMddHHmmss");

                    string strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
                    //string striSerial = strOperDate.Substring(0, 4) + strOperDate.Substring(5, 2) + strOperDate.Substring(8, 2) + strOperDate.Substring(11, 2) + strOperDate.Substring(14, 2) + strOperDate.Substring(17, 2);
                    sql2 = string.Format("insert into tbBusiLog(iSerial,iAssId,vcOperType,vcOperName,dtOperDate,vcComments,vcDeptId)values(" + striSerial + ",1,'{0}','{1}','" + strOperDate  + "','{2}','{3}')", "OP019", cis.strOperName, "生产入库数量" + cis.strTolCount, cis.strDeptID);
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}
		public DataTable GetProductionInStorage(string strDeptId,string strInDate)
		{
			try
			{
				string strsql = "select a.Id,a.vcGoodsId,b.vcGoodsName,b.nPrice,Quantity from ProductionInStorage a left join tbGoods b on a.vcGoodsId=b.vcGoodsId where vcDeptId='{0}' and InDate='{1}'";
				con.Open();
				cmd=new SqlCommand(string.Format(strsql,strDeptId,strInDate),con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				con.Close();
			}
		}
//		public bool IsSync(AnchorType at,string strId)
//		{
//			try
//			{
//				con.Open();			
//				cmd=new SqlCommand(string.Format("select count(1) from SyncAnchor where Id={0} and Anchor>{1}",(int)at,strId),con);
//				object obj = cmd.ExecuteScalar();
//				if(obj!=null)
//				{
//					string str = obj.ToString();
//					if(str.Length>0)
//					{
//						return Convert.ToInt32(str)>0;
//					}
//				}
//			}
//			catch (Exception ex) 
//			{
//				throw ex;
//			}
//			finally
//			{
//				con.Close();
//			}
//			return false;
//		}
		#endregion

		#region 销售盘点
		public bool SaleCheckExist(string strDeptId,string strCheckDate,string strGoodsId)
		{
			try
			{
				con.Open();			
				cmd=new SqlCommand(string.Format("select count(1) from SaleCheck where vcDeptId='{0}' and CheckDate='{1}' and vcGoodsId='{2}'",strDeptId,strCheckDate,strGoodsId),con);
				object obj = cmd.ExecuteScalar();
				if(obj!=null)
				{
					string str = obj.ToString();
					if(str.Length>0)
					{
						return Convert.ToInt32(str)>0;
					}
				}
			}
			catch (Exception ex) 
			{
				throw ex;
			}
			finally
			{
				con.Close();
			}
			return false;
		}
		public void SaleCheck(CMSMData.CMSMStruct.ConsItemStruct cis,out Exception err)
		{
			this.MaskSqlToNull();
			con.Open();
			using(SqlTransaction trans=con.BeginTransaction(IsolationLevel.ReadCommitted))
			{
				try
				{
					err=null;
					string strsql = "insert into SaleCheck (vcDeptId,CheckDate,vcGoodsId,Quantity,vcOperId,CreateDate,OperType)values('{0}','{1}','{2}',{3},'{4}',getdate(),{5});";
					//string anchor = GetAnchor(AnchorType.SaleCheck,trans);
					for(int i=0;i<cis.dtItem.Rows.Count;i++)
					{
						int id = Convert.ToInt32(cis.dtItem.Rows[i]["Id"]);
						string strQuantity = cis.dtItem.Rows[i]["Count"].ToString();
						if(id>0)
						{
							int operType = GetOperType(id,AnchorType.SaleCheck,trans);
							sql1+=string.Format("update SaleCheck set Quantity={0},OperType={2} where Id={1};",strQuantity,id,(int)TableOperType.Update);
						}
						else
						{
							sql1+=string.Format(strsql,cis.strDeptID,cis.strOperDate,cis.dtItem.Rows[i]["GoodsID"].ToString(),cis.dtItem.Rows[i]["Count"].ToString(),cis.strOperName,(int)TableOperType.Insert);
						}
					}
					cmd=new SqlCommand(sql1,con,trans);
					cmd.ExecuteNonQuery();

                    DateTime dtNow = DateTime.Now;
                    string striSerial = dtNow.ToString("yyyyMMddHHmmss");

                    string strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
                    //string striSerial = strOperDate.Substring(0, 4) + strOperDate.Substring(5, 2) + strOperDate.Substring(8, 2) + strOperDate.Substring(11, 2) + strOperDate.Substring(14, 2) + strOperDate.Substring(17, 2);
                    sql2 = string.Format("insert into tbBusiLog(iSerial,iAssId,vcOperType,vcOperName,dtOperDate,vcComments,vcDeptId)values(" + striSerial + ",1,'{0}','{1}','" + strOperDate + "','{2}','{3}')", "OP020", cis.strOperName, "销售盘点数量" + cis.strTolCount, cis.strDeptID);
					cmd=new SqlCommand(sql2,con,trans);
					cmd.ExecuteNonQuery();
					
					trans.Commit();
				}
				catch(Exception e)
				{
					trans.Rollback();
					err=e;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public DataTable GetSaleCheck(string strDeptId,string strInDate)
		{
			try
			{
				string strsql = "select a.Id,a.vcGoodsId,b.vcGoodsName,b.nPrice,Quantity from SaleCheck a left join tbGoods b on a.vcGoodsId=b.vcGoodsId where vcDeptId='{0}' and CheckDate='{1}'";
				con.Open();
				cmd=new SqlCommand(string.Format(strsql,strDeptId,strInDate),con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				con.Close();
			}
		}
		#endregion

		#region 销售平衡表
		public DataTable GetSaleBalance(string strDate,string strBalance,out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dtCons=new DataTable();
			string strLastDate = DateTime.Parse(strDate).AddDays(-1).ToString("yyyy-MM-dd");
			try
			{
				con.Open();
				err=null;				
//				sql1=@"select vcDeptName,vcGoodsName,InDate,InQuantity,SaleQuantity,CheckQuantity,Balance from 
//(select e.vcDeptName,d.vcGoodsName,a.InDate,a.Quantity as InQuantity,isnull(b.Quantity,0) as SaleQuantity,isnull(c.Quantity,0) as CheckQuantity,
//case when a.Quantity-isnull(b.Quantity,0)-isnull(c.Quantity,0)=0 then '平衡' else '不平衡' end as Balance,a.vcDeptId,a.vcGoodsId
// from 
//(select vcGoodsId,vcDeptId,InDate,Quantity from ProductionInStorage where InDate='{0}') a
//left join
//(select vcGoodsId,vcDeptId,convert(char(10),dtConsDate,121) ConsDate,sum(icount) Quantity from vwConsItem where
//convert(char(10),dtConsDate,121)='{0}'
//group by vcGoodsId,vcDeptId,convert(char(10),dtConsDate,121)) b on a.vcGoodsId=b.vcGoodsId and a.vcDeptId=b.vcDeptId and b.ConsDate=a.InDate
//left join
//(select vcGoodsId,vcDeptId,CheckDate,Quantity from SaleCheck where CheckDate='{0}')c on a.vcGoodsId=c.vcGoodsId and a.vcDeptId=c.vcDeptId and c.CheckDate=a.InDate
//left join tbGoods d on a.vcGoodsId=d.vcGoodsId
//left join (select vcCommCode as vcDeptId,vcCommName as vcDeptName from tbCommCode where vcCommSign='MD') e on a.vcDeptId=e.vcDeptId
//) f 
//";
				sql1=@"
select vcDeptName,vcGoodsName,nPrice,InDate,LastCheckQuantity,InQuantity,SaleQuantity,CheckQuantity,(LastCheckQuantity + InQuantity - SaleQuantity - CheckQuantity) * nPrice * -1,Balance from 
(select e.vcDeptName,d.vcGoodsName,d.nPrice,a.InDate,a.LastCheckQuantity,a.InQuantity as InQuantity,isnull(b.Quantity,0) as SaleQuantity,isnull(c.Quantity,0) as CheckQuantity,
case when a.LastCheckQuantity+a.InQuantity-isnull(b.Quantity,0)-isnull(c.Quantity,0)=0 then '平衡' else '不平衡' end as Balance,a.vcDeptId,a.vcGoodsId
 from 
(
 select 
 case when g.vcGoodsId is null then h.vcGoodsId else g.vcGoodsId end as vcGoodsId,
 case when g.vcDeptId is null then h.vcDeptId else g.vcDeptId end as vcDeptId,
 '{0}' as InDate,
 isnull(g.Quantity,0) LastCheckQuantity,
 isnull(h.Quantity,0) InQuantity
  from
 (select vcGoodsId,vcDeptId,CheckDate,Quantity from SaleCheck where CheckDate='{1}') g full join
 (select vcGoodsId,vcDeptId,InDate,Quantity from ProductionInStorage where InDate='{0}') h 
 on h.vcGoodsId=g.vcGoodsId and h.vcDeptId=g.vcDeptId 
) a 
left join
(select vcGoodsId,vcDeptId,convert(char(10),dtConsDate,121) ConsDate,sum(icount) Quantity from vwConsItem where
convert(char(10),dtConsDate,121)='{0}' and cFlag=0
group by vcGoodsId,vcDeptId,convert(char(10),dtConsDate,121)) b on a.vcGoodsId=b.vcGoodsId and a.vcDeptId=b.vcDeptId and b.ConsDate=a.InDate
left join
(select vcGoodsId,vcDeptId,CheckDate,Quantity from SaleCheck where CheckDate='{0}')c on a.vcGoodsId=c.vcGoodsId and a.vcDeptId=c.vcDeptId and c.CheckDate=a.InDate

left join tbGoods d on a.vcGoodsId=d.vcGoodsId
left join (select vcCommCode as vcDeptId,vcCommName as vcDeptName from tbCommCode where vcCommSign='MD') e on a.vcDeptId=e.vcDeptId
) f 
";
				if(strBalance.Length>0)
				{
					sql1+=@" where Balance='"+strBalance+"'";
				}
				sql1+=" order by f.vcDeptId,f.vcGoodsId ";
				cmd=new SqlCommand(string.Format(sql1,strDate,strLastDate),con);
				cmd.CommandTimeout=600;
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dtCons);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dtCons;
		}

		#endregion

		public DataTable GetNewGoods(out Exception err)
		{
			this.MaskSqlToNull();
			DataTable dt=new DataTable();
			try
			{
				con.Open();
				err=null;				
				sql1="SELECT vcGoodsName, nPrice FROM tbGoods WHERE (cNewFlag = '1')";
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dt;
		}

		public string GetEnterpriseName(out Exception err)
		{
			this.MaskSqlToNull();
			string strEn="面包";
			try
			{
				con.Open();
				err=null;				
				sql1="select vcCommName from tbCommCode where vcCommSign='EN'";
				cmd=new SqlCommand(sql1,con);
				object obj = cmd.ExecuteScalar();				
				if(obj!=null)
				{
					strEn=obj.ToString();
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return strEn;
		}
		public string GetTel2(out Exception err)
		{
			this.MaskSqlToNull();
			string strTel="";
			try
			{
				con.Open();
				err=null;				
				sql1="select vcComments from tbCommCode where vcCommSign='MD' and vcCommCode=(select vcCommCode from tbCommCode where vcCommSign='LOCAL')";
				cmd=new SqlCommand(sql1,con);
				object obj = cmd.ExecuteScalar();				
				if(obj!=null)
				{
					strTel=obj.ToString();
				}
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return strTel;
		}

		public DataTable GetBillBySerial(out Exception err,string strSerial)
		{
			this.MaskSqlToNull();
			DataTable dt=new DataTable();
			try
			{
				con.Open();
				err=null;				
//				sql1="select a.iSerial,a.vcCardId,c.vcAssName,a.nTRate,a.nFee,a.nPay,a.nBalance,a.iIgValue,a.vcConsType,a.vcOperName,a.dtConsDate,a.vcDeptId,b.vcDeptName from vwBill a "
//+" left join (select vcCommName as vcDeptName,vcCommCode as vcDeptId from tbCommCode where vcCommSign='MD') b on a.vcDeptId=b.vcDeptId "
//+" left join (select vcCardId,vcAssName from tbAssociator) c on a.vcCardId=c.vcCardId "
//+" where a.iSerial="+strSerial;
				sql1="select a.iSerial,a.vcCardId,a.nTRate,a.nFee,a.nPay,a.nBalance,a.iIgValue,a.vcConsType,a.vcOperName,a.dtConsDate,a.vcDeptId from vwBill a where a.iSerial="+strSerial;
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dt;
		}
		public DataTable GetConsItemBySerial(out Exception err,string strSerial)
		{
			this.MaskSqlToNull();
			DataTable dt=new DataTable();
			try
			{
				con.Open();
				err=null;				
				sql1="select b.vcGoodsName as GoodsName,a.nPrice as Price,a.iCount as Count,a.nFee as Fee from vwConsItem a "
+" left join (select vcGoodsId,vcGoodsName from tbGoods) b on a.vcGoodsId=b.vcGoodsId "
+" where a.cFlag='0' and a.iSerial="+strSerial;
				cmd=new SqlCommand(sql1,con);
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception e) 
			{
				err=e;
				return null;
			}
			finally
			{
				con.Close();
			}
			return dt;
		}
	}
}
