using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;

namespace CMSMData
{
	/// <summary>
	/// SyncTableStruct 的摘要说明。
	/// </summary>
	public class SyncTableStruct
	{
		public SyncTableStruct()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static void Update(string strConnString)
		{            
			string[] scriptStructFileNames = {"tbOper.sql","ProductionInStorage.sql","SaleCheck.sql","SyncAnchor.sql","tbCommCode.sql"
			};
			SqlConnection conn = new SqlConnection(strConnString);
			try
			{
				conn.Open();
				UpdateDatabase(conn, scriptStructFileNames);
			}
			catch(SqlException sex)
			{
				
				throw sex;
			}
			finally
			{
				conn.Close();
			}
		}

		private static void UpdateDatabase(SqlConnection conn, string[] scriptStructFileNames)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			ArrayList lScript = new ArrayList();
			foreach (string scriptFileName in scriptStructFileNames)
			{
				string script = GetSql(assembly, scriptFileName);

				if (script.Length>0)
				{
					lScript.Add(script);
				}
			}
			if (lScript.Count > 0)
			{
				foreach (string script in lScript)
				{
					using (SqlCommand cmd = new SqlCommand(script, conn))
					{
						cmd.ExecuteNonQuery();
					}
				}
			}
		}
		private static string GetSql(Assembly assembly,string scriptFileName)
		{
			string script = string.Empty;
			Stream stream = assembly.GetManifestResourceStream("CMSMData.SqlServerScript." + scriptFileName);
			StreamReader sr = new StreamReader(stream);
			if (sr != null)
			{
				script = sr.ReadToEnd();
				sr.Close();
				stream.Close();
			}
			return script;
		}
	}
}
