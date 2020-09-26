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
            string conStr = ConfigurationManager.ConnectionStrings[currentDB].ConnectionString;
            if (conStr.Substring(0, 12) == "Data Source=")
                return conStr;
            else
                return SymetricEncryption.GetDecryptedValue(conStr);

         //   return ConfigurationManager.ConnectionStrings[currentDB].ConnectionString;

        }
        public static string ConnectionSTR(string name)
        {
           // return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            string conStr = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            if (conStr.Substring(0, 12) == "Data Source=")
                return conStr;
            else
                return SymetricEncryption.GetDecryptedValue(conStr);
        }
    }
  
}