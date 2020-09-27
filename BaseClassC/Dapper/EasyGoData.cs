using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapper
{

    public class EasyGoData<T>
    {
        readonly string _conStr = DBConnectionHelper.ConnectionSTR();

        public List<T> ListOfT(string sp, object parameter)
        {

            using (IDbConnection connection = new SqlConnection(_conStr))
            {
                string SP = GetParamerters(sp, parameter);
                return connection.Query<T>(SP, parameter).ToList();
            }

        }
        public T ValueOfT(string sp, object parameter)
        {

            using (IDbConnection connection = new SqlConnection(_conStr))
            {
                string SP = GetParamerters(sp, parameter);
                return connection.QuerySingle<T>(SP, parameter);

            }

        }
        private static string GetParamerters(string sp, object obj)
        {
            if (sp.Contains("@"))
                return sp;
            else
                return sp + GetParameterStrFromParameterObj(obj);
        }

        private static string GetParameterStrFromParameterObj(object obj)
        {
            var myP = PropertiesOfType<string>(obj);
            int x = 0;
            var para = "";
            foreach (var item in myP)
            {
                if (item.Value != null)
                {
                    if (x == 0)
                        para = " @" + item.Key;
                    else
                        para = para + ",@" + item.Key;
                    x++;
                }

            };
            return para;
        }
        private static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object obj)
        {
            return from p in obj.GetType().GetProperties()
                   where p.PropertyType == typeof(T)
                   select new KeyValuePair<string, T>(p.Name, (T)p.GetValue(obj));
        }     
    }

}
