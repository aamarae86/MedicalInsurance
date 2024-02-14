using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrOrganizations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.___SpHelpers
{
   public interface IExecuteSpRepository :  IApplicationService 
    {
        IList<TOutput>  Execute<TOutput, TInput>(TInput input, string storedName)
            where TOutput : class, new()
            where TInput : class;

        Task<IList<TOutput>> ExecuteAsync<TOutput, TInput>(TInput input, string storedName)
             where TOutput : class, new()
            where TInput : class;
    }

 
}


public class SpinputParameter
{
    public string name { get; set; }
    public string value { get; set; }
    public bool IsNumber { get; set; } = false;
    public bool IsDateTime { get; set; } = false;
}


 
