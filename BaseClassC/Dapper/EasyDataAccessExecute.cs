using System.Collections.Generic;

namespace MyDapper
{
    public class EasyDataAccessExecute
    {
        public static List<T> AnyListOfT<T>(string SP, object parameter)
        {
            try
            {
                var mylist = new EasyGo<T>();
                return mylist.ListOfT(SP, parameter);
            }
            catch
            {
                throw;
            }
        }
        public static T AnyValueOfT<T>(string SP, object parameter)
        {
            try
            {
                var myvalue = new EasyGo<T>();
                return myvalue.ValueOfT(SP, parameter);
            }
            catch
            {
                throw;
            }
        }
    }
    public class EasyDataAccessExecute<T>
    {
        public static List<T> AnyListOfT(string SP, object parameter)
        {
            try
            {
                var mylist = new EasyGo<T>();
                return mylist.ListOfT(SP, parameter);
            }
            catch
            {
                throw;
            }
        }
        public static T AnyValueOfT(string SP, object parameter)
        {
            try
            {
                var myvalue = new EasyGo<T>();
                return myvalue.ValueOfT(SP, parameter);
            }
            catch
            {
                throw;
            }
        }
    }

    public class EasyGo<T>
    {
        public List<T> ListOfT(string sp, object parameter)
        {

            var list = EasyDataAccess<T>.ListOfT(sp, parameter);
            return list;

        }
        public T ValueOfT(string SP, object parameter)
        {

            var result = EasyDataAccess<T>.ValueOfT(SP, parameter);
            return result;

        }
    }

}
