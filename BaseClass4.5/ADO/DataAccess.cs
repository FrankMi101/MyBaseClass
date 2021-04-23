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
    public struct MyParameterRS
    {
        public string pName;
        public object pValue;
    }

    public struct MyParameter
    {
        public string pName;
        public System.Data.DbType pType;
        public int pLeng;
        public object pValue;
    }

    public class Data
    {

        public Data()
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
        public static System.Data.IDbDataParameter SetParameter(System.Data.IDbCommand cmd, string pName, System.Data.DbType pType, int pSize, object pValue)
        {
            System.Data.IDbDataParameter myParameter = cmd.CreateParameter();
            myParameter.ParameterName = pName;
            myParameter.DbType = pType;
            myParameter.Size = pSize;
            myParameter.Value = pValue;
            return myParameter;
        }

        public static object myReaderObject(string sp, MyParameter[] para, Int16 timeOut, string dataType)
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
                foreach (MyParameter myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
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
                myDataReader.Dispose();
            }
        }

      
        public static System.Data.IDataReader myDataReader(string sp, MyParameter[] para)
        {
            return myDataReader(sp, para, 0);
        }
        public static System.Data.IDataReader myDataReader(string sp, MyParameter[] para, Int16 timeOut)
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
                foreach (MyParameter myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
                cn.Open();
                myDataReader = cmd.ExecuteReader();
                myDataReader.Read();
                return myDataReader;
            }
            catch (SqlException ex)
            {
                string result = ex.Message;
                return null;
            }
            finally
            {
                cn.Close();
                myDataReader.Dispose();
            }
        }

        public static string myValue(string sp, MyParameter[] para)
        {

            return myValue(sp, para, 0);

        }
        public static string myValue(string sp, MyParameter[] para, Int16 timeOut)
        {
            return myDataReader(sp, para, timeOut).GetString(0);
        }
        public static DateTime myDateTime(string sp, MyParameter[] para)
        {
            return myDateTime(sp, para, 0);
        }
        public static DateTime myDateTime(string sp, MyParameter[] para, Int16 timeOut)
        {
            return myDataReader(sp, para, timeOut).GetDateTime(0);
            //   return (DateTime) myObject(sp, para, timeOut,"DateTime");
        }
        public static Boolean myBool(string sp, MyParameter[] para)
        {
            return myBool(sp, para, 0);
        }
        public static Boolean myBool(string sp, MyParameter[] para, Int16 timeOut)
        {
            // return (Boolean)myObject(sp, para, timeOut, "Boolean");
            return myDataReader(sp, para, timeOut).GetBoolean(0);
        }
        public static byte myByte(string sp, MyParameter[] para)
        {
            return myByte(sp, para, 0);
        }
        public static byte myByte(string sp, MyParameter[] para, Int16 timeOut)
        {
            return myDataReader(sp, para, timeOut).GetByte(0);

        }
        public static IList<MyList> myDataList(string sp, MyParameter[] para)
        {
            return myDataList(sp, para, 0);
        }
        public static IList<MyList> myDataList(string sp, MyParameter[] para, Int16 timeOut)
        {
            IList<MyList> myList = MyList.LoadListFromiReader(myDataReader(sp, para, timeOut));
            return myList;
        }
        public static System.Data.DataSet myDataSet(string sp, MyParameter[] para)
        {
            return myDataSet(sp, para, 0);

        }
        public static System.Data.DataSet myDataSet(string sp, MyParameter[] para, Int16 timeOut)
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
                foreach (MyParameter myPara in para)
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
        public static System.Data.DataTable myDataTable(string sp, MyParameter[] para)
        {
            return myDataTable(sp, para, 0);

        }
        public static System.Data.DataTable myDataTable(string sp, MyParameter[] para, Int16 timeOut)
        {
            return myDataSet(sp, para, timeOut).Tables[0];
        }
        public static void SaveData(string sp, MyParameter[] para)
        {
            System.Data.IDbConnection cn = myDbConnection;
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                foreach (MyParameter myPara in para)
                {
                    System.Data.IDbDataParameter IDPara = SetParameter(cmd, myPara.pName, myPara.pType, myPara.pLeng, myPara.pValue);
                    cmd.Parameters.Add(IDPara);
                }
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
        public static Object myDataListObj(string sp, MyParameter[] para, Int16 timeOut, Object myListObj)
        {
            System.Data.IDataReader myDataReader = null;
            System.Data.IDbConnection cn = myDbConnection;
            try
            {
                System.Data.IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.CommandTimeout = timeOut;
                foreach (MyParameter myPara in para)
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


    public class MyList
    {
        public string myValue { get; set; }
        public string myText { get; set; }

        internal static IList<MyList> iDataReaderToList(IDataReader reader)
        {
            var mylist = new List<MyList>();


            //List<MyList> mylist = reader.Select(r => new Customer
            //{
            //    my = r["id"] is DBNull ? null : r["id"].ToString(),
            //    CustomerName = r["name"] is DBNull ? null : r["name"].ToString()
            //}).ToList();


            //using (IDataReader reader )
            //{
            //    List<MyList> mylist = reader.AutoMap<MyList>()
            //                                     .ToList();
            //}




            while (reader != null && reader.Read())
            {
                mylist.Add(new MyList()
                {
                    myValue = (string)reader[0],
                    myText = (string)reader[1]
                });

            }

            return mylist;

            //if (myDataReader.HasRows)
            //{
            //    AutoMapper.Mapper.CreateMap<IDataReader, MyList>();
            //    return AutoMapper.Mapper.Map<IDataReader, IList<MyList>>(myDataReader);
            //}
        }
        internal static IList<MyList> LoadListFromiReader(IDataReader reader)
        {
            var mylist = new List<MyList>();

            while (reader != null && reader.Read())
            {
                mylist.Add(new MyList()
                {
                    myValue = (string)reader[0],
                    myText = (string)reader[1]
                });

            }

            return mylist;

            //if (myDataReader.HasRows)
            //{
            //    AutoMapper.Mapper.CreateMap<IDataReader, MyList>();
            //    return AutoMapper.Mapper.Map<IDataReader, IList<MyList>>(myDataReader);
            //}
        }
        internal static Object LoadMyListFromiReader(IDataReader reader)
        {
            var mylist = new List<MyList>();

            while (reader != null && reader.Read())
            {
                mylist.Add(new MyList()
                {
                    myValue = (string)reader[0],
                    myText = (string)reader[1]
                });

            }

            return mylist;

        }

    }

}