using System.Data;
using System.Threading.Tasks;

namespace WebApiExemplo.Repository.Core.Helpers
{
    public interface IDatabase
    {
        void OpenTransaction();
        void OpenTransaction(IsolationLevel isolationLevel);
        void CommitTransaction();
        void RollbackTransaction();


        void BeginStatement(object procedureName);
        void BeginStatement(object procedureName, int timeOut);


        void AddParameter(string parameterName, object parameterValue);
        void AddParameterOutput(string parameterName, object parameterValue, DbType parameterType);
        void AddParameterReturn(string parameterName = "@RETURN_VALUE", DbType parameterType = DbType.Int16);


        int GetOutputParameter();
        T GetOutputParameter<T>();

        Task<IDataReader> ExecuteReaderAsync();
        Task<IDataReader> ExecuteReaderAsync(CommandBehavior cb);

        Task<int> ExecuteNonQueryAsync();
        Task<int> ExecuteNonQueryWithReturnAsync();
    }
}
