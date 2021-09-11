using Dapper;
using MyDapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyDapper
{
    public class EasyDataAccess
    {

        public static List<T> ListOfT<T>(string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.ListOfT(sp, parameter);

        }

        public static List<T> ListOfT<T>(string db, string sp, object parameter)
        {
            var da = new EasyGoData<T>(db);
            return da.ListOfT(sp, parameter);

           // var da = new EasyGoData<T>();
           // return da.ListOfT(db, sp, parameter);
        }

        public static T ValueOfT<T>(string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.ValueOfT(sp, parameter);

        }

        public static T ValueOfT<T>(string db, string sp, object parameter)
        {
            var da = new EasyGoData<T>(db);
            return da.ValueOfT(sp, parameter);

        //    var da = new EasyGoData<T>();
        //    return da.ValueOfT(db, sp, parameter);
        }
    }

    public class EasyDataAccess<T>
    {

        public static List<T> ListOfT(string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.ListOfT(sp, parameter);
        }

      public static List<T> ListOfT(string db,string sp, object parameter)
        {
            var da = new EasyGoData<T>(db);
            return da.ListOfT(sp, parameter);
            // var da = new EasyGoData<T>();
            //   return da.ListOfT(db,sp, parameter);
        }

        public static T ValueOfT(string sp, object parameter)
        {
            var da = new EasyGoData<T>();
            return da.ValueOfT(sp, parameter);

        }
  

        public static T ValueOfT(string db,string sp, object parameter)
        {
            var da = new EasyGoData<T>(db);
            return da.ValueOfT(sp, parameter);

         //   var da = new EasyGoData<T>();
         //   return da.ValueOfT(db, sp, parameter);
        }
    }

}


