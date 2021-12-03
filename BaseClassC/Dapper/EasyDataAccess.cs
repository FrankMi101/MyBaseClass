using Dapper;
using MyDapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MyDapper
{
    //****************************************************************************************
    // this work for Dapper ORM 
    // the parameter pass to SP must be an Anonymous object,
    // if pass a domain class object as a parameter,you must include specific parameters in SP
    // or the domain class defination must as same as your SP parameters in Name and Order.
    //
    // if include parameters in SP, always using Dapper CommandType=Text
    // using CommandType=Text, works both with parameters and without parameters in SP
    // using CommandType=SP, only works without parameter in SP
    // **************************************************************************************

    public class EasyDataAccess
    {

        public static List<T> ListOfT<T>(string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.ListOfT(sp, parameter);
        }

        public static List<T> ListOfT<T>(string db, string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.ListOfT(db, sp, parameter);
        }

        public static T ValueOfT<T>(string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.ValueOfT(sp, parameter);
        }

        public static T ValueOfT<T>(string db, string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.ValueOfT(db, sp, parameter);
        }
        public static List<T> ListOfT<T>(string sp, object parameter, string type)
        {
            var da = new EasyGoData<T>(DapperCommandType.Get(type));
            return da.ListOfT(sp, parameter);
        }

        public static List<T> ListOfT<T>(string db, string sp, object parameter, string type)
        {
            var da = new EasyGoData<T>(DapperCommandType.Get(type));
            return da.ListOfT(db, sp, parameter);
        }

        public static T ValueOfT<T>(string sp, object parameter, string type)
        {
            var da = new EasyGoData<T>(DapperCommandType.Get(type));
            return da.ValueOfT(sp, parameter);
        }

        public static T ValueOfT<T>(string db, string sp, object parameter, string type)
        {
            var da = new EasyGoData<T>(DapperCommandType.Get(type));
            return da.ValueOfT(db, sp, parameter);
        }

    }

    public class EasyDataAccess<T>
    {
        readonly static string db = DBConnectionHelper.CurrentDB();
 
        public static List<T> ListOfT(string sp, object parameter)
        {
            //var da = new EasyGoData<T>();
            //return da.ListOfT(sp, parameter);
             return ListOfT(db, sp, parameter);

        }

        public static List<T> ListOfT(string db, string sp, object parameter)
        {
           string  type = DapperCommandType.GetDCType(sp);

            return ListOfT(db, sp, parameter, type);
        }

        public static T ValueOfT(string sp, object parameter)
        {
            //var da = new EasyGoData<T>();
            //return da.ValueOfT(sp, parameter);
         
            return ValueOfT(db, sp, parameter );
        }

        public static T ValueOfT(string db, string sp, object parameter)
        {
            //var da = new EasyGoData<T>();
            //return da.ValueOfT(db, sp, parameter);
            string type = DapperCommandType.GetDCType(sp);

            return ValueOfT(db, sp, parameter, type);
        }

        public static string CheckSPandParametersbyCommandType(string sp, object para, string type)
        {
            var da = new EasyGoData<T>();
            var cType = DapperCommandType.Get(type);
            return da.GetSPParamerterStrFromObject(cType, sp, para);
        }


        public static List<T> ListOfT(string sp, object parameter, string type)
        {
            //var da = new EasyGoData<T>(DapperCommandType.Get(type));
            //return da.ListOfT(sp, parameter);
            return ListOfT(db, sp, parameter, type);
        }

        public static List<T> ListOfT(string db, string sp, object parameter, string type)
        {
             type = DapperCommandType.GetDCType(sp);
            var da = new EasyGoData<T>(DapperCommandType.Get(type));
            return da.ListOfT(db, sp, parameter);
        }

        public static T ValueOfT(string sp, object parameter, string type)
        {
        
            //var da = new EasyGoData<T>(DapperCommandType.Get(type));
            //return da.ValueOfT(sp, parameter);

            return ValueOfT(db, sp, parameter, type);
        }

        public static T ValueOfT(string db, string sp, object parameter, string type)
        {
             type = DapperCommandType.GetDCType(sp);

            var da = new EasyGoData<T>(DapperCommandType.Get(type));
            return da.ValueOfT(db, sp, parameter);
        }

 

        public static string GetDapperType(string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.GetDapperCommandType();
        }
        public static string GetDapperType(string sp, object parameter, string type)
        {
            var da = new EasyGoData<T>(DapperCommandType.Get(type));
            return da.GetDapperCommandType();
        }
    }
}


