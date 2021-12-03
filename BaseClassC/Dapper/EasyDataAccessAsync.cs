using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDapper
{
    public class EasyDataAccessAsync<T>
    {
        readonly string db = DBConnectionHelper.CurrentDB();

        public EasyDataAccessAsync()
        { }
        public async Task<List<T>> ListOfT(string sp, object parameter)
        {
            return await ListOfT(db, sp, parameter);
        }

        public async Task<List<T>> ListOfT(string db, string sp, object parameter)
        {
            string type = DapperCommandType.GetDCType(sp);
            return await ListOfT(db, sp, parameter, type);
        }

        public async Task<T> ValueOfT(string sp, object parameter)
        {
            return await ValueOfT(db, sp, parameter);
        }

        public async Task<T> ValueOfT(string db, string sp, object parameter)
        {

            string type = DapperCommandType.GetDCType(sp);
            return await ValueOfT(db, sp, parameter, type);
        }


        public async Task<List<T>> ListOfT(string sp, object parameter, string type)
        {
            return await ListOfT(db, sp, parameter, type);
        }

        public async Task<List<T>> ListOfT(string db, string sp, object parameter, string type)
        {
            if (sp.Contains("@")) type = "Text";
            var da = new EasyGoDataAsync<T>(DapperCommandType.Get(type));
            return await da.ListOfT(db, sp, parameter);
        }

        public async Task<T> ValueOfT(string sp, object parameter, string type)
        {
            return await ValueOfT(db, sp, parameter, type);
        }

        public async Task<T> ValueOfT(string db, string sp, object parameter, string type)
        {
            if (sp.Contains("@")) type = "Text";
            var da = new EasyGoDataAsync<T>(DapperCommandType.Get(type));
            return await da.ValueOfT(db, sp, parameter);
        }
    }
}


