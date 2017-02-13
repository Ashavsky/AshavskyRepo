using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Tasks
{
    public class DatabaseTasks
    {
        private string _connectionString;
        private string _sqlSproc;

        public DatabaseTasks()
        {
            _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            _sqlSproc = ConfigurationManager.AppSettings["ProcedureName"];
        }

        public DataSet SqlResultSet
        {
            get { return ExecuteSpCommandReturnDataSet(_sqlSproc); }
        }

        public DataSet ExecuteSpCommandReturnDataSet(string sqlQuery)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var cmd = CreateSpCommand(sqlQuery, conn, CommandType.StoredProcedure);

                var ds = GetDataSet(cmd);
                return ds;
            }
        }

        public DataSet GetDataSet(SqlCommand cmd)
        {
            DataSet result = new DataSet();

            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(result);
            }

            return result;
        }

        public SqlCommand CreateSpCommand(string procedure, SqlConnection conn, CommandType cmdType)
        {
            var cmd = new SqlCommand
            {
                CommandType = cmdType,
                CommandText = procedure,
                CommandTimeout = 0,
                Connection = conn
            };

            return cmd;
        }
    }
}
