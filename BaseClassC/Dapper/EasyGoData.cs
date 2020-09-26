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

    public class EasyGoData<T>
    {
        readonly string _conStr = DBConnectionHelper.ConnectionSTR();

        public List<T> ListOfT(string sp, object parameter)
        {

            using (IDbConnection connection = new SqlConnection(_conStr))
            {
                return connection.Query<T>(sp, parameter).ToList();
            }

        }
        public T ValueOfT(string sp, object parameter)
        {

            using (IDbConnection connection = new SqlConnection(_conStr))
            {
                return connection.QuerySingle<T>(sp, parameter);

            }

        }
    }

}
