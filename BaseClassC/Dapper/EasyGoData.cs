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
    /*********************************************************************************
     *   This class provide an easy way to access the database with Dapper    
     *   Dapper is one of the popular ORM frameworks.                               
     *   The class have few methods to get a list or value of a type of class       
     *   Author : Frank Mi     
     *   Version: 1.0.0.1    Date: 2020/01/01                         
     *            1.0.1.0    Date: 2021/05/01  extend method to handel db connection 
     ********************************************************************************/
    public class EasyGoData<T>
    {
        readonly string _conStr = DBConnectionHelper.ConnectionSTR();

        public List<T> ListOfT(string sp, object parameter)
        {
            // db connection string is default in Application Web config file 
            using (IDbConnection connection = new SqlConnection(_conStr))
            {
                string SP = getParamerterStrFromObject(sp, parameter);
                return connection.Query<T>(SP, parameter).ToList();
            }

        }
        // ListOfT method will return a list of any <T> type class
        // The Method accept three parameter db= database name sp = Sql script or store procedure name
        // parameter is one row list of any of class type.    
        // <T> can be any class type, such as String, Int, Student, Class
        // The method use Dapper Query method of Connection 
        public List<T> ListOfT(string db, string sp, object parameter)
        {  
            // get acture database connection string by name (db)
            string conDbStr = DBConnectionHelper.ConnectionSTR(db);
            // using Dapper connection object get get data
            using (IDbConnection connection = new SqlConnection(conDbStr))
            {
                string _sp = getParamerterStrFromObject(sp, parameter); // get parameters if the sp does not provide parameter string with @
                return connection.Query<T>(_sp, parameter).ToList();
            }

        }
        // ValueOfT method will return a value any <T> type
        // The Method accept two parameter  sp = Sql script or store procedure name
        // parameter is one row list of any of class type.    
        // <T> can be any type, such as String, Int, date, bool
        // The method use Dapper QuerySingle method of Connection 
        public T ValueOfT(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(_conStr))
            {
                string SP = getParamerterStrFromObject(sp, parameter);
                return connection.QuerySingle<T>(SP, parameter);
            }
        }

        public T ValueOfT(string db, string sp, object parameter)
        {
            string conDbStr = DBConnectionHelper.ConnectionSTR(db);
            using (IDbConnection connection = new SqlConnection(conDbStr))
            {
                string SP = getParamerterStrFromObject(sp, parameter);
                return connection.QuerySingle<T>(SP, parameter);
            }
        }
        private static string getParamerterStrFromObject(string sp, object obj)
        {
            if (sp.Contains("@"))
                return sp;
            else
                return sp + getParameterStrFromParameterObj(obj);
        }

        private static string getParameterStrFromParameterObj(object obj)
        {
            var parameterObj = PropertiesOfType<string>(obj);
            int x = 0;
            var para = "";
            foreach (var item in parameterObj)
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
        private static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<S>(object obj)
        {   
            // get parameter class type use LINQ query
            return from p in obj.GetType().GetProperties()
                   where p.PropertyType == typeof(S)
                   select new KeyValuePair<string, T>(p.Name, (T)p.GetValue(obj));
        }     
    }

}
