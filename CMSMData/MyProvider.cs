using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSMData
{
    public class MyProvider : System.Web.Security.SqlMembershipProvider
    {
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            string connectionString = CMSMData.CMSMDataAccess.SysInitial.ConString;
            System.Reflection.FieldInfo connectionStringField =
                GetType().BaseType.GetField("_sqlConnectionString",
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic);

            connectionStringField.SetValue(this, connectionString);
        }
    }
}
