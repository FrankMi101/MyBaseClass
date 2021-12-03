using System.Data;

namespace MyDapper
{
    public class DapperCommandType
    {
        public static CommandType Get(string type)
        {
            if (type == "Text") return CommandType.Text;
            else if (type == "TD") return CommandType.TableDirect;
            return CommandType.StoredProcedure;  //  this is async default value SP
        }

        public static string GetDCType(string sql)
        {
            if (sql.ToLower().Contains("@")) return "Text";
            if (sql.ToLower().Contains("select")) return "Text";
            if (sql.ToLower().Contains("update")) return "Text";
            if (sql.ToLower().Contains("insert")) return "Text";
            if (sql.ToLower().Contains("delete")) return "Text";
            return "SP";
        }
    }
}


