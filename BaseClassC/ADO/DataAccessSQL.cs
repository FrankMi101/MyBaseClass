using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Security;
using Microsoft.Win32;
using System.Data;
namespace MyADO
{
   

    public struct MyParameterSQL
    {
        public string pName;
        public System.Data.SqlDbType pType;
        public int pLeng;
        public object pValue;
    }
    public class DataSQL
    {
        public DataSQL()
        {
        }

        public static string applicationName;
        public static string dbConnectionSTR;  // = "Data Source=localhost;Initial Catalog=upa;Integrated Security=SspI"
        public static string dbType = "ORA";

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

        public static System.Data.IDbDataParameter SetParameterSQL(System.Data.IDbCommand cmd, string pName, System.Data.SqlDbType pType, int pSize, object pValue)
        {
 
            System.Data.IDbDataParameter mySQLParameter = cmd.CreateParameter();
            mySQLParameter.ParameterName = pName;
            mySQLParameter.DbType = GetDbTypeByName(pType.ToString()  );
            mySQLParameter.Size = pSize;
            mySQLParameter.Value = pValue;
            return mySQLParameter;
        }
       
        private static System.Data.DbType GetDbTypeByName(string typeName)
        {
            System.Data.SqlDbType sqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), typeName, true);

            SqlParameter paraConver = new SqlParameter();
            paraConver.SqlDbType = sqlDbType;
            return paraConver.DbType;
        }

        public static string myValue(string sp, MyParameterSQL[] para, Int16 timeOut)
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
                foreach (MyParameterSQL myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameterSQL(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
                cn.Open();
                myDataReader = cmd.ExecuteReader();
                myDataReader.Read();
                return myDataReader.GetString(0);
            }
            catch (SqlException ex)
            {
                string result = ex.Message;
                return "";
            }
            finally
            {
                cn.Close();
                myDataReader.Dispose();
            }
        }
        public static System.Data.DataSet myDataSet(string sp, MyParameterSQL[] para)
        {
            System.Data.IDbDataAdapter myDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            //   System.Data.IDbDataAdapter myDataAdapter = new System.Data.OleDb.OleDbDataAdapter() ;  
            System.Data.IDbConnection cn = myDbConnection;
            System.Data.DataSet myDataSet1 = new System.Data.DataSet();
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                foreach (MyParameterSQL myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameterSQL(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
                cn.Open();
                myDataAdapter.SelectCommand = cmd;
                myDataAdapter.Fill(myDataSet1);

                return myDataSet1;
            }
            catch (Exception ex)
            {
                string result = ex.Message;
                return null;
            }
            finally
            {
                // System.Data.CommandBehavior.CloseConnection();
                cn.Close();
            }

        }

        public static System.Data.IDataReader myDatalist(string sp, MyParameterSQL[] para)
        {
            //System.Data.IDataReader myDataReader = new  SqlDataReader();
            //   System.Data.IDbDataAdapter myDataAdapter = new System.Data.OleDb.OleDbDataAdapter() ;  
            System.Data.IDbConnection cn = myDbConnection;
           
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                foreach (MyParameterSQL myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameterSQL(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }

                 cn.Open();
                System.Data.IDataReader reader = cmd.ExecuteReader();
                
                return reader;
            }
            catch (Exception ex)
            {
                string result = ex.Message;
                return null;
            }
            finally
            {
                // System.Data.CommandBehavior.CloseConnection();
                cn.Close();
            }

        }

        public static void SaveData(string sp, MyParameterSQL[] para)
        {
            System.Data.IDbConnection cn = myDbConnection;
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                foreach (MyParameterSQL myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameterSQL(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string result = ex.Message;
            }
            finally
            {
                cn.Close();


            }

        }

        public static IList<MyList> myDataList(string sp, MyParameterSQL[] para, Int16 timeOut)
        {
            System.Data.IDataReader myDataReader = null;
            System.Data.IDbConnection cn = myDbConnection;
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.CommandTimeout = timeOut;
                foreach (MyParameterSQL myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameterSQL(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
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

    
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, int leng, string name, string value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type,leng);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, int leng, string name, int value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type,leng);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, int leng, string name, Byte[] value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, int leng, string name, DateTime value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, int leng, string name, float value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }

        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, string name, string value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, string name, int value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type,  string name, Byte[] value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, string name, DateTime value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
        public static void AddParametersSQL(System.Data.SqlClient.SqlCommand myCommand, SqlDbType type, string name, float value)
        {
            System.Data.SqlClient.SqlParameter myPara = new System.Data.SqlClient.SqlParameter(name, type);
            myPara.Value = value;
            myCommand.Parameters.Add(myPara);
        }
    }
}