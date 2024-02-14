using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System
{
    public interface IExecuteProcedure<TEntity, TPrimaryKey, TPostDto, TPostOutput> : IRepository<TEntity, TPrimaryKey>
         where TPostDto : class
         where TPostOutput : class,new()
         where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<IList<TPostOutput>> Execute(TPostDto input,string storedName);
    }
}
