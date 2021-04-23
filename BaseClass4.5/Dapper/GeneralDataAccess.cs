
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyDapper
{
    public class GeneralDataAccess
    {
        static readonly string conSTR = DBConnectionHelper.ConnectionSTR();

        public static List<T> ListofT<T>(string sp, object parameter)
        {
            {// T will be class type. such are School, person, Staff and so on. 
                using (IDbConnection connection = new SqlConnection(conSTR))
                {
                    var tlist = connection.Query<T>(sp, parameter).ToList();
                    return tlist;
                }
            }

        }
        public static T ValueOfT<T>(string sp, object parameter)
        {
            {// T will be class type. such are School, person, Staff and so on. 
                using (IDbConnection connection = new SqlConnection(conSTR))
                {
                    var value = connection.QuerySingle<T>(sp, parameter);
                    return value;
                }
            }

        }

        public static List<T> GetListofTypeT<T>(string sp, object parameter)
        {// T will be class type. such are School, person, Staff and so on. 
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var tlist = connection.Query<T>(sp, parameter).ToList();
                return tlist;
            }
        }
        public static List<T> GetObjectList<T>(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var mylist = connection.Query<T>(sp, parameter).ToList();
                return mylist;
            }
        }

        public static object GetValueofTypeT<T>(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var myValue = connection.QuerySingle<T>(sp, parameter);
                return (T)myValue;
            }
        }
        public static T GetValueof<T>(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var myValue = connection.QuerySingle<T>(sp, parameter);
                return (T)myValue;
            }
        }

        public static object GetObjValue<T>(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var myReuslt = connection.QuerySingle<T>(sp, parameter);
                return (T)myReuslt;
            }
        }
        public static string TextValue(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var myText = connection.QuerySingle<string>(sp, parameter);
                return myText;
            }
        }
        public static bool BoolValue(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var result = connection.QuerySingle<bool>(sp, parameter);
                return result;
            }
        }
        public static DateTime DateValue(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var result = connection.QuerySingle<DateTime>(sp, parameter);
                return result;
            }
        }

        public static bool IsStringNull(string s)
        {
            return string.IsNullOrEmpty(s) ? true : false;
        }


    }



}
