using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
 
    public class AppPrivateValue
    {
        private static readonly String IV = "SuFjcEmp/TE=";
        private static readonly String Key = "KIPSToILGp6fl+3gXJvMsN4IajizYBBT";

        public static string ValueIV()
        {
            string myKey = "AppEncryptionIV";
            string value = Environment.GetEnvironmentVariable(myKey+1);   // Doesn't work on Server side
            if (value == null)
            {
                value = WebConfigurationManager.AppSettings[myKey];
                if (value == null || value == "")
                    value = IV;
            }


            return value;
        }
        public static string ValueKey()
        {
            string myKey = "AppEncryptionKey";
            string value = Environment.GetEnvironmentVariable(myKey+1); // Doesn't work on Server side           
            if (value == null)
            {
                value = WebConfigurationManager.AppSettings[myKey];
                if (value == null || value == "")
                    value = Key;
            }

            return value;
        }
    }
 
