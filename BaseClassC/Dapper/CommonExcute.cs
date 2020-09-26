using System.Collections.Generic;

namespace MyDapper
{
    public class CommonExcute<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SP"> store procedure name and @parameters, for example dbo.tcdsb_LTO_PageGeneral_List @Operate,@Para1,@Para1,@Para2,@Para3</param>
        /// <param name="parameter"> store procedure parameters data object. for example List2Item { Operate = "PostingRound", Para0 = "20192020", Para1 = "0529" }</param>
        /// <returns> general list of T class type </returns>
        public static List<T> GeneralList(string SP, object parameter)
        {
            try
            {
                var mylist = new CommonList<T>();
                return mylist.GeneralListOfT(SP, parameter);
            }
            catch
            {
                throw;
            }
        }
        public static List<T> AnyListOfT(string SP, object parameter)
        {
            try
            {
                var mylist = new CommonList<T>();
                return mylist.GeneralListOfT(SP, parameter);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SP"> store procedure name and @parameters. for example dbo.tcdsb_LTO_PagePublish_Operation @Operate, @UserID, @SchoolYear,@SchoolCode,@PositionID, @PositionType</param>
        /// <param name="parameter"> store procedure parameters data object. foxe example PositionPublish {Operate ="Update", UserID ="",SchoolYear="20192020",PositionID="11575"........} </param>
        /// <returns> single text value for example, school name or successfully/Failed </returns>

        public static string GeneralValue(string SP, T parameter)
        {
            var myval = new CommonValue<T>();
            return myval.GeneralValue(SP, parameter);
        }

        public static string AnyValueOfT(string SP, object parameter)
        {
            var myval = new CommonValue<T>();
            return myval.GeneralValue(SP, parameter);
        }
    }

    public class CommonList<T>
    {
        public List<T> GeneralListOfT(string sp, object parameter)
        {

            var list = GeneralDataAccess.ListofT<T>(sp, parameter);
            return list;

        }
    }
    public class CommonValue<T>
    {
        public string GeneralValue(string SP, object parameter)
        {

            var result = GeneralDataAccess.TextValue(SP, parameter);
            return result;

        }
       
    }
}
