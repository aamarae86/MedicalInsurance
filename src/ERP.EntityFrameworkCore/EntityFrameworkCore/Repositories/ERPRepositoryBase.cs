using Abp.Data;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ERP.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class ERPRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<ERPDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ERPRepositoryBase(
            IDbContextProvider<ERPDbContext> dbContextProvider
            )
            : base(dbContextProvider)
        {
        }

        // Add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="ERPRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class ERPRepositoryBase<TEntity> : ERPRepositoryBase<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        protected ERPRepositoryBase(IDbContextProvider<ERPDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    /// <typeparam name="TPostDto">Post Dto type</typeparam>
    /// <typeparam name="TPostOutput">Post Output type</typeparam>
    public abstract class ERPProcedureRepositoryBase<TEntity, TPrimaryKey, TPostDto, TPostOutput> :
        ERPRepositoryBase<TEntity, TPrimaryKey>//,
        where TEntity : class, IEntity<TPrimaryKey>
        where TPostDto : class
        where TPostOutput : class, new()
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        protected ERPProcedureRepositoryBase(
            IDbContextProvider<ERPDbContext> dbContextProvider,
            IActiveTransactionProvider activeTransactionProvider
            )
            : base(dbContextProvider)
        {
            _transactionProvider = activeTransactionProvider;
        }



        public async Task<IList<TPostOutput>> Execute(TPostDto input, string storedName)
        {
            var parameters = GetSqlParameters(input);
            return await OutputResultAsync(await ExecuteCommandAsync(storedName, parameters));
        }

        private SqlParameter[] GetSqlParameters(TPostDto input)
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

        private async Task<IList<TPostOutput>> OutputResultAsync(DbDataReader reader)
        {
            using (reader)
            {
                var result = new List<TPostOutput>();

                while (await reader.ReadAsync())
                {
                    var item = new TPostOutput();
                    foreach (var property in typeof(TPostOutput).GetProperties())
                        try
                        {
                            property.SetValue(item, reader[property.Name]);
                        }
                        catch (System.Exception ex)
                        {

                        }
                    result.Add(item);
                }
                return result;
            }
        }

        // Add your common methods for all repositories

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

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="ERPRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class ERPProcedureRepositoryBase<TEntity, TPostDto, TPostOutput> :
        ERPProcedureRepositoryBase<TEntity, int, TPostDto, TPostOutput>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
        where TPostDto : class
        where TPostOutput : class, new()
    {
        protected ERPProcedureRepositoryBase(IDbContextProvider<ERPDbContext> dbContextProvider,
            IActiveTransactionProvider activeTransactionProvider)
            : base(dbContextProvider, activeTransactionProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
