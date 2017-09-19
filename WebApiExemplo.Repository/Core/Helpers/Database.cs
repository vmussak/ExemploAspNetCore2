using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApiExemplo.Repository.Core.Connection;

namespace WebApiExemplo.Repository.Core.Helpers
{
    public class Database : IDatabase
    {
        private SqlCommand SqlCommand { get; set; }

        private readonly IDatabaseConnection _databaseConnection;
        public Database(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        #region Transaction

        public void OpenTransaction()
        {
            _databaseConnection.OpenTransaction();
        }

        public void OpenTransaction(IsolationLevel isolationLevel)
        {
            _databaseConnection.OpenTransaction(isolationLevel);
        }

        public void CommitTransaction()
        {
            _databaseConnection.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _databaseConnection.RollbackTransaction();
        }

        #endregion

        #region BeginStatements

        public void BeginStatement(object procedureName)
        {
            SqlCommand = new SqlCommand(procedureName.ToString(), _databaseConnection.SqlConnection, _databaseConnection.SqlTransaction)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 10
            };
        }

        public void BeginStatement(object procedureName, int timeOut)
        {
            SqlCommand = new SqlCommand(procedureName.ToString(), _databaseConnection.SqlConnection, _databaseConnection.SqlTransaction)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = timeOut
            };
        }

        #endregion

        #region Add parameters

        public void AddParameter(string parameterName, object parameterValue)
        {
            SqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
        }

        public void AddParameterOutput(string parameterName, object parameterValue, DbType parameterType)
        {
            var parameter = new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.Output,
                Value = parameterValue,
                DbType = parameterType
            };
            SqlCommand.Parameters.Add(parameter);
        }

        public void AddParameterReturn(string parameterName = "@RETURN_VALUE", DbType parameterType = DbType.Int16)
        {
            var parameter = new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.ReturnValue,
                DbType = parameterType
            };

            SqlCommand.Parameters.Add(parameter);
        }

        #endregion

        #region Output parameters

        public int GetOutputParameter()
        {
            return (int)SqlCommand.Parameters["@RETURN_VALUE"].Value;
        }

        public T GetOutputParameter<T>()
        {
            return (T)SqlCommand.Parameters["@RETURN_VALUE"].Value;
        }

        #endregion

        #region DataReader

        public async Task<IDataReader> ExecuteReaderAsync()
        {
            return await ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }

        public async Task<IDataReader> ExecuteReaderAsync(CommandBehavior cb)
        {
            _databaseConnection.OpenConnection();
            return await SqlCommand.ExecuteReaderAsync(cb);
        }

        #endregion

        #region ExecuteNonQuery

        public async Task<int> ExecuteNonQueryAsync()
        {
            _databaseConnection.OpenConnection();
            return await SqlCommand.ExecuteNonQueryAsync();
        }

        public async Task<int> ExecuteNonQueryWithReturnAsync()
        {
            AddParameterReturn();
            _databaseConnection.OpenConnection();
            await SqlCommand.ExecuteNonQueryAsync();
            return int.Parse(SqlCommand.Parameters["@RETURN_VALUE"].Value.ToString());
        }

        #endregion
    }
}
