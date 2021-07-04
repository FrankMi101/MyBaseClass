using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapper
{
    public static class DBConnectionHelper
    {
        public static string ConnectionSTR()
        {
            string currentDB = ConfigurationManager.ConnectionStrings["currentDB"].ConnectionString;
            return ConnectionSTR(currentDB);
        }
        public static string ConnectionSTR(string name)
        {
            if (name.Substring(0, 12) == "Data Source=")
                return name;
            else
            {
                string conStr = ConfigurationManager.ConnectionStrings[name].ConnectionString;
                return GetConnStr(conStr);
            }
        }
        private static string GetConnStr(string conStr)
        {
            if (conStr.Substring(0, 12) == "Data Source=")
                return conStr;
            else
                return SymetricEncryption.GetDecryptedValue(conStr);
        }
    }
  
}