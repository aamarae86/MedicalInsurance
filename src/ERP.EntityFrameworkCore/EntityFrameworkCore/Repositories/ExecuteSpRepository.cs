using Abp.Application.Services;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using ERP._System.___SpHelpers;
using ERP._System.__HR._HrOrganizations;
using ERP._System.PostRecords.Dto;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ERP.EntityFrameworkCore.Repositories
{
    public class ExecuteSpRepository : ApplicationService, IExecuteSpRepository
    {
        private readonly IDbContextProvider<ERPDbContext> dbContextProvider;

        public ExecuteSpRepository(IDbContextProvider<ERPDbContext> dbContextProvider)  
        {
            this.dbContextProvider = dbContextProvider;
        }

        private IList<SpinputParameter> MapInputsParametersAsList<TInput>(TInput input)

        {
            var InputList = new List<SpinputParameter>();
            foreach (var prop in input.GetType().GetProperties())
            {
                var val = prop.GetValue(input, null);

                if (prop.PropertyType == typeof(string))
                {
                    InputList.Add(new SpinputParameter { name = prop.Name.ToString(), value = val != null ? prop.GetValue(input, null).ToString() : "" });
                    //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(input, null));
                }
                else if (prop.PropertyType == typeof(DateTime?) || prop.PropertyType == typeof(DateTime))
                {
                    InputList.Add(new SpinputParameter { name = prop.Name.ToString(), value = val != null ? prop.GetValue(input, null).ToString() : "", IsDateTime = true });
                }
                else
                {
                    InputList.Add(new SpinputParameter { name = prop.Name.ToString(), value = val != null ? prop.GetValue(input, null).ToString() : "", IsNumber = true});
                }
            }
            return InputList;
        }

        public IList<TOutput> Execute<TOutput, TInput>(TInput input, string storedName)
         where TOutput : class, new()
         where TInput : class
        {
            IList<TOutput> TOutput_Results = null;

            var Mappingresult = MapInputsParametersAsList(input);

            var loadSp = dbContextProvider.GetDbContext().LoadStoredProc(storedName);

            if (dbContextProvider.GetDbContext().Database.CurrentTransaction != null)
            {
                loadSp.Transaction = dbContextProvider.GetDbContext().Database.CurrentTransaction.GetDbTransaction();
            }

            foreach (var parmeter in Mappingresult)
            {

                if (parmeter.IsNumber)
                {
                    loadSp.WithSqlParam(parmeter.name, Convert.ToInt64(parmeter.value));
                }
                else if (parmeter.IsDateTime)
                {
                    loadSp.WithSqlParam(parmeter.name, string.IsNullOrEmpty(parmeter.value) ? null : parmeter.value);
                }
                else
                {
                    loadSp.WithSqlParam(parmeter.name, parmeter.value);
                }
            }



            loadSp.ExecuteStoredProc((handler) =>
          {
              TOutput_Results = handler.ReadToList<TOutput>();

                // do something with your results.
            });

            return TOutput_Results;
        }
        public async  Task<IList<TOutput>> ExecuteAsync<TOutput, TInput>(TInput input, string storedName)
         where TOutput : class, new()
         where TInput : class
        {
            IList<TOutput> TOutput_Results = null;

            var Mappingresult = MapInputsParametersAsList(input);

            var loadSp = dbContextProvider.GetDbContext().LoadStoredProc(storedName);

            if (dbContextProvider.GetDbContext().Database.CurrentTransaction != null)
            {
                loadSp.Transaction = dbContextProvider.GetDbContext().Database.CurrentTransaction.GetDbTransaction();
            }

            foreach (var parmeter in Mappingresult)
            {

                if (parmeter.IsNumber)
                {
                    loadSp.WithSqlParam(parmeter.name, Convert.ToInt64(parmeter.value));
                }
                else if (parmeter.IsDateTime)
                {
                    loadSp.WithSqlParam(parmeter.name, string.IsNullOrEmpty(parmeter.value) ? null : parmeter.value);
                }
                else
                {
                    loadSp.WithSqlParam(parmeter.name, parmeter.value);
                }
            }



          await  loadSp.ExecuteStoredProcAsync((handler) =>
          {
              TOutput_Results = handler.ReadToList<TOutput>();

                // do something with your results.
            });

            return TOutput_Results;
        }

    }
}
