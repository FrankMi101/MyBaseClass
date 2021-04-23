using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace MyBaseClassC.Utility
{
    class JsonFileReader
    {
        public static string JsonString(string jsonFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(jsonFile))  // Server.MapPath("~/test.json")))
                {
                    string jsonString = sr.ReadToEnd();
                    return jsonString;
                }
            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return "";
            }
            finally
            { }
        }
        public static MyKeySchema GetKeyValue( string action)
        {
            try
            { var jsonFile = "myKey.json";
                var jsonString = JsonString(jsonFile);
                var result = JsonConvert.DeserializeObject<KeyTemplate>(jsonString);
                var myList = result.EncryptionKey; // pType == "Basic" ? result.Advance : result.Advance;
                return myList.FirstOrDefault(l => l.Action == action); 

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return null;
            }


        }
    }

    public class KeyTemplate
    {
        public List<MyKeySchema> EncryptionKey { get; set; } 
    }

    public class MyKeySchema
    {
        public string Action { get; set; }
        public string PIV { get; set; }
        public string PKey { get; set; }

    }
}
