using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApiExemplo.Repository.Core.Connection
{
    public class DatabaseConnection : IDatabaseConnection, IDisposable
    {
        public DatabaseConnection()
        {
           // SqlConnection = new SqlConnection($"server={db.Server};Database={db.Database};user id={db.User};password={db.Password}");
        }

        public SqlConnection SqlConnection { get; }

        public SqlTransaction SqlTransaction { get; set; }

        public void OpenTransaction(IsolationLevel isolationLeve)
        {
            OpenConnection();
            SqlTransaction = SqlConnection.BeginTransaction(isolationLeve);
        }

        public void OpenTransaction()
        {
            OpenConnection();
            SqlTransaction = SqlConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            SqlTransaction.Commit();
            SqlTransaction.Dispose();
        }

        public void RollbackTransaction()
        {
            SqlTransaction.Rollback();
            SqlTransaction.Dispose();
        }

        public void Dispose()
        {
            SqlConnection.Close();
        }

        public void OpenConnection()
        {
            if (SqlConnection.State == ConnectionState.Broken)
            {
                SqlConnection.Close();
                SqlConnection.Open();
            }

            if (SqlConnection.State == ConnectionState.Closed)
                SqlConnection.Open();
        }
    }
}
