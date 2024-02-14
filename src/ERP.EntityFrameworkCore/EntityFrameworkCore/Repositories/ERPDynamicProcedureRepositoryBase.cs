using Abp.Data;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ERP.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom dynamic  repositories procs of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public class ERPDynamicProcedureRepositoryBase<TEntity, TPrimaryKey> :
        ERPRepositoryBase<TEntity, TPrimaryKey>

        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        protected ERPDynamicProcedureRepositoryBase(
          IDbContextProvider<ERPDbContext> dbContextProvider,
          IActiveTransactionProvider activeTransactionProvider
          ) : base(dbContextProvider)
        {
            _transactionProvider = activeTransactionProvider;
        }

        public async Task<IList<TPostOutput>> Execute<TPostOutput, TPostDto>(TPostDto input, string storedName)
            where TPostOutput : class, new()
            where TPostDto : class
        {
            var parameters = GetSqlParameters(input);
            return await OutputResultAsync<TPostOutput>(await ExecuteCommandAsync(storedName, parameters));
        }

        private SqlParameter[] GetSqlParameters<TPostDto>(TPostDto input) where TPostDto : class
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            var publicFields = typeof(TPostDto).GetProperties();

            foreach (var field in publicFields)
                sqlParameters.Add(
                   new SqlParameter
                   {
                       ParameterName = $"@{field.Name}",
                       Value = field.GetValue(input)
                   });
            return sqlParameters.ToArray();
        }

        private async Task<DbDataReader> ExecuteCommandAsync(string storedName, params SqlParameter[] parameters)
        {
            await EnsureConnectionOpenAsync();

            using (
                    var command = CreateCommand
                    (
                        $"{storedName}",
                        CommandType.StoredProcedure,
                        parameters
                    )
                )
                return await command.ExecuteReaderAsync();
        }

        private async Task<IList<TPostOutput>> OutputResultAsync<TPostOutput>(DbDataReader reader)
            where TPostOutput : class, new()
        {
            using (reader)
            {
                var result = new List<TPostOutput>();

                while (await reader.ReadAsync())
                {
                    var item = new TPostOutput();

                    foreach (var property in typeof(TPostOutput).GetProperties())
                        property.SetValue(item, reader[property.Name]);

                    result.Add(item);
                }
                return result;
            }
        }

        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = Context.Database.GetDbConnection().CreateCommand();

            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        private async Task EnsureConnectionOpenAsync()
        {
            var connection = Context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }
        }

        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
                {
                    {"ContextType", typeof(ERPDbContext) },
                    {"MultiTenancySide", MultiTenancySide }
                });
        }

    }
}
