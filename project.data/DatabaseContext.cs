using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Threading.Tasks;

namespace project.data
{
    public class DatabaseContext : DbContext
    {
        //SqlConnection conn;
        public DatabaseContext()
                : base("name=DataConnection")
        {

        }
        public dynamic SQLstatement<T>(string spName, object spParams)
        {
            var prmList = spParams as List<SqlParameter>;
            if (prmList != null)
            {
                var prmArr = prmList.ToArray();
                var recSet = Database.SqlQuery<T>(spName, prmArr);
                return recSet;
            }
            else
            {
                var recSet = Database.SqlQuery<T>(spName, spParams);
                return recSet;
            }
            //var recSet = Database.SqlQuery<T>(spName,spParams);
            //return recSet?.ToList() ?? new List<T>();
        }


        public dynamic DoFetch<T>(string spName, object spParams)
        {
            var prmList = spParams as List<SqlParameter>;
            if (prmList != null)
            {
                var prmArr = prmList.ToArray();
                var recSet = Database.SqlQuery<T>(spName, prmArr);
                return recSet?.ToList() ?? new List<T>();
            }
            else
            {
                var recSet = Database.SqlQuery<T>(spName, spParams);
                return recSet?.ToList() ?? new List<T>();
            }
            //var recSet = Database.SqlQuery<T>(spName,spParams);
            //return recSet?.ToList() ?? new List<T>();
        }

        public dynamic DoFetch<T>(string spName)
        {
            var recSet = Database.SqlQuery<T>(spName);
            return recSet?.ToList() ?? new List<T>();
        }

        public int DoExec(string spName, object spParams)
        {
            Database.CommandTimeout = 150;
            int rowsAffected;
            var prmList = spParams as List<SqlParameter>;
            if (prmList != null)
            {
                var prmArr = prmList.ToArray();
                rowsAffected = Database.ExecuteSqlCommand(spName, prmArr);
            }
            else
            {
                rowsAffected = Database.ExecuteSqlCommand(spName, spParams);
            }
            return rowsAffected;
        }

        public class DatabaseContextClass
        {
            public static string PrepareSpCall(string spName, List<SqlParameter> spParams)
            {
                var spCall = spName;
                var i = 0;
                foreach (var p in spParams)
                {
                    var xX = (++i == 1) ? " " : ", ";
                    spCall += $"{xX}{p.ParameterName}";
                }
                return spCall;
            }
        }

    }
}
