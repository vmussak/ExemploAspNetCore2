using System.Data;
using System.Data.SqlClient;

namespace WebApiExemplo.Repository.Core.Connection
{
    public interface IDatabaseConnection
    {
        SqlConnection SqlConnection { get; }
        SqlTransaction SqlTransaction { get; }

        void OpenTransaction();
        void OpenTransaction(IsolationLevel isolationLevel);
        void CommitTransaction();
        void RollbackTransaction();
        void Dispose();
        void OpenConnection();
    }
}
