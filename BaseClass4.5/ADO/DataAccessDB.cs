using System;
using System.Collections.Generic;
//using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
//using System.Security;
//using Microsoft.Win32;
//using System.Data;
namespace MyADO
{
    public struct MyParameterDB
    {
        public string pName;
        public System.Data.DbType pType;
        public int pLeng;
        public object pValue;
    }

    public class DataDB
    {

        public DataDB()
        {
        }

        public static string applicationName;
        public static string dbConnectionSTR;  // = "Data Source=localhost;Initial Catalog=upa;Integrated Security=SspI"
        public static string dbType = "SQL";

        public static string dbConnectingSTR
        {
            get
            {
                //if (dbConnectionSTR == "Registry")
                //{ dbConnectionSTR = DeCryptConnectString; }
                return dbConnectionSTR;
            }
        }
        public static System.Data.IDbConnection myDbConnection
        {
            get
            {
                string dbconString = dbConnectionSTR;
                System.Data.IDbConnection myConn;
                switch (dbType)
                {
                    case "SQL":
                        myConn = new SqlConnection(dbconString);
                        break;
                    case "ORA":
                        myConn = new OleDbConnection(dbconString);
                        break;
                    case "Access":
                        myConn = new OleDbConnection(dbconString);
                        break;
                    default:
                        myConn = new SqlConnection(dbconString);
                        break;
                }
                return myConn;

            }

        }

        private static  System.Data.DataSet myDataSetMethod()
        {
            string ConntionSTR = "Data Source=localhost;Initial Catalog=EPA;User ID=appUsers;PWD=appusers;Application Name=EPA";
            System.Data.IDbConnection cn = new SqlConnection(ConntionSTR);
            System.Data.DataSet myDataSet1 = new System.Data.DataSet();

            System.Data.IDbDataAdapter myDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            //  System.Data.IDataReader myDataReaderI = null;
            System.Data.IDbCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            System.Data.IDbDataParameter IDPara = new SqlParameter();
            System.Data.IDbDataParameter myParameter = cmd.CreateParameter();
            cmd.Parameters.Add(IDPara);

            try
            {         
                cn.Open();
                myDataAdapter.SelectCommand = cmd;
                myDataAdapter.Fill(myDataSet1);
                return myDataSet1;
                // myDataReaderI = cmd.ExecuteReader(); return myDataReaderI;
            }
            catch (Exception ex)
            {
                string sm = ex.Message;
                return null;
            }
            finally
            {
                 cn.Close();
            }
        }
        public static System.Data.IDbDataParameter SetParameter(System.Data.IDbCommand cmd, string pName, System.Data.DbType pType, int pSize, object pValue)
        {
            System.Data.IDbDataParameter myParameter = cmd.CreateParameter();
            myParameter.ParameterName = pName;
            myParameter.DbType = pType;
            myParameter.Size = pSize;
            myParameter.Value = pValue;
            return myParameter;
        }
        private static void AddParametersToCMD(System.Data.IDbCommand cmd, MyParameterDB[] para)
        {
            foreach (MyParameterDB myPara in para)
            {
                System.Data.IDbDataParameter IDPara = SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                cmd.Parameters.Add(IDPara);
            }
        }

        public static System.Data.IDataReader myDataReader(string sp, MyParameterDB[] para)
        {
            return myDataReader(sp, para, 0);
        }
        public static System.Data.IDataReader myDataReader(string sp, MyParameterDB[] para, Int16 timeOut)
        {
            System.Data.IDataReader myDataReaderI = null;
            System.Data.IDbConnection cn = myDbConnection;
            System.Data.IDbCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (timeOut > 0)
            { cmd.CommandTimeout = timeOut; }
            try
            {
                AddParametersToCMD(cmd, para);
                cn.Open();
                myDataReaderI = cmd.ExecuteReader();
                return myDataReaderI;
            }
            catch (SqlException ex)
            {
                string result = ex.Message;
                return null;
            }
            finally
            {
                  cn.Close();
               //   myDataReader.Dispose();
            }
        }

        private static object myObj(string sp, MyParameterDB[] para, Int16 timeOut, string dataType)
        {
            System.Data.IDataReader myDataReader = null;
            System.Data.IDbConnection cn = myDbConnection;
            System.Data.IDbCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (timeOut > 0)
            { cmd.CommandTimeout = timeOut; }
            try
            {
                AddParametersToCMD(cmd, para);

                cn.Open();
                myDataReader = cmd.ExecuteReader();
                myDataReader.Read();
                switch (dataType)
                {
                    case "String":
                        return myDataReader.GetString(0);
                    case "DateTime":
                        return myDataReader.GetDateTime(0); //  .GetString(0);
                    case "Boolean":
                        return myDataReader.GetBoolean(0);
                    case "Byte":
                        return myDataReader.GetByte(0);
                    default:
                        return myDataReader.GetString(0);
                }
            }
            catch (SqlException ex)
            {
                string result = ex.Message;
                return null;
            }
            finally
            {
                cn.Close();
             //   myDataReader.Close();
             //   myDataReader.Dispose();
            }
        }
        public static string myValue(string sp, MyParameterDB[] para)
        {
            return myValue(sp, para, 0);
        }
        public static string myValue(string sp, MyParameterDB[] para, Int16 timeOut)
        {
            //  return myDataReader(sp, para, timeOut).GetString(0);
            return myObj(sp, para, timeOut, "String").ToString();
        }
        public static DateTime myDateTime(string sp, MyParameterDB[] para)
        {
            return myDateTime(sp, para, 0);
        }
        public static DateTime myDateTime(string sp, MyParameterDB[] para, Int16 timeOut)
        {
            //  return myDataReader(sp, para, timeOut).GetDateTime(0);
            return (DateTime)myObj(sp, para, timeOut, "DateTime");
        }
        public static Boolean myBool(string sp, MyParameterDB[] para)
        {
            return myBool(sp, para, 0);
        }
        public static Boolean myBool(string sp, MyParameterDB[] para, Int16 timeOut)
        {
            //return myDataReader(sp, para, timeOut).GetBoolean(0);
            return (Boolean)myObj(sp, para, timeOut, "Boolean");
        }
        public static byte myByte(string sp, MyParameterDB[] para)
        {
            return myByte(sp, para);
        }
        public static byte myByte(string sp, MyParameterDB[] para, Int16 timeOut)
        {
            // return myDataReader(sp, para, timeOut).GetByte(0);
            return (Byte)myObj(sp, para, timeOut, "Byte");
        }
        public static IList<MyList> myDataiList(string sp, MyParameterDB[] para)
        {
            return myDataiList(sp, para, 0);
        }
        public static IList<MyList> myDataiList(string sp, MyParameterDB[] para, Int16 timeOut)
        {
            IList<MyList> myList = MyList.LoadListFromiReader(myDataReader(sp, para, timeOut));
            return myList;
        }
        public static System.Data.DataSet myDataSet(string sp, MyParameterDB[] para)
        {
            return myDataSet(sp, para, 0);
        }
        public static System.Data.DataSet myDataSet(string sp, MyParameterDB[] para, Int16 timeOut)
        {
            System.Data.IDbDataAdapter myDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            //   System.Data.IDbDataAdapter myDataAdapter = new System.Data.OleDb.OleDbDataAdapter() ;  
            System.Data.IDbConnection cn = myDbConnection;
            System.Data.DataSet myDataSet1 = new System.Data.DataSet();
            System.Data.IDbCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (timeOut > 0)
            { cmd.CommandTimeout = timeOut; }
            try
            {
                
                foreach (MyParameterDB myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
                cn.Open();
                myDataAdapter.SelectCommand = cmd;
                myDataAdapter.Fill(myDataSet1);

                return myDataSet1;
            }
            catch (Exception ex)
            {
                string sm = ex.Message;
                return null;
            }
            finally
            {
                // System.Data.CommandBehavior.CloseConnection();
                cn.Close();
            }

        }
        public static System.Data.DataTable myDataTable(string sp, MyParameterDB[] para)
        {
            return myDataTable(sp, para, 0);
        }
        public static System.Data.DataTable myDataTable(string sp, MyParameterDB[] para, Int16 timeOut)
        {
            return myDataSet(sp, para, timeOut).Tables[0];
        }

        public static System.Data.DataSet myOLEDataSet(string sp, MyParameterDB[] para)
        {
            System.Data.IDbDataAdapter myDataAdapter = new System.Data.OleDb.OleDbDataAdapter(); //   .SqlClient.SqlDataAdapter();
            //   System.Data.IDbDataAdapter myDataAdapter = new System.Data.OleDb.OleDbDataAdapter() ;  
            System.Data.IDbConnection cn = myDbConnection;
            System.Data.DataSet myDataSet1 = new System.Data.DataSet();
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                foreach (MyParameterDB myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
                cn.Open();
                myDataAdapter.SelectCommand = cmd;
                myDataAdapter.Fill(myDataSet1);

                return myDataSet1;
            }
            catch (Exception ex)
            {
                string sm = ex.Message;
                return null;
            }
            finally
            {
                // System.Data.CommandBehavior.CloseConnection();
                cn.Close();
            }

        }
        public static void SaveData(string sp, MyParameterDB[] para)
        {
            System.Data.IDbConnection cn = myDbConnection;
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                AddParametersToCMD(cmd, para);
                //  foreach (MyParameterDB myPara in para)
                //  {
                //      System.Data.IDbDataParameter IDPara = SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                //      cmd.Parameters.Add(IDPara);
                //  }
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string sm = ex.Message;
            }
            finally
            {
                cn.Close();
            }
        }
        public static Object myDataListObj(string sp, MyParameterDB[] para, Int16 timeOut, Object myListObj)
        {
            System.Data.IDataReader myDataReader = null;
            System.Data.IDbConnection cn = myDbConnection;
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.CommandTimeout = timeOut;
                foreach (MyParameterDB myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
                cn.Open();
                myDataReader = cmd.ExecuteReader();

                IList<MyList> myList = MyList.LoadListFromiReader(myDataReader);

                return myList;

            }
            catch (SqlException ex)
            {
                string result = ex.Message;
                return null;
            }
            finally
            {
                cn.Close();
                myDataReader.Close();
                myDataReader.Dispose();
            }


        }


    }



}