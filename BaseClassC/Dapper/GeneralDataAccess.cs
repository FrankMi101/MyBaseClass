
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
    public class GeneralDataAccess 
    {
        static string conSTR = DBConnectionHelper.ConnectionSTR();

        public static List<T> GetListofTypeT<T>(string sp, object parameter)
        {// T will be class type. such are School, person, Staff and so on. 
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var tlist = connection.Query<T>(sp, parameter).ToList();
                return tlist;
            }
        }
        public static List<T> GetObjectList <T> (string sp, object parameter)
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
               return (T) myValue;
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
                return myText ;
            }
        }
        public static  bool  BoolValue(string sp, object parameter)
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
        //public static List<SiteTeams> GetListsold(string operate, string userID, string userRole, string schoolYear, string schoolCode)
        //{
        //    using (IDbConnection connection = new SqlConnection(conSTR))
        //    {
        //        // connection.Query is a Dapper function
        //        //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
        //        string sp = "dbo.tcdsb_PLF_SchoolSiteTeamNew  @Operate,@UserID, @SchoolYear,@SchoolCode";
        //        Parametersp1 parameter = new Parametersp1 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode };
        //        var mylist = connection.Query<SiteTeams>(sp, parameter).ToList();
        //        //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
        //        return mylist;
        //    }
        //}
        public static bool IsStringNull(string s)
        {
            return (s == null || s == String.Empty) ? true : false;
        }

     
    }
}
