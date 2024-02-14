using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System
{
    public interface IERPDynamicProcedureRepositoryBase<TEntity, TPrimaryKey> : 
        IRepository<TEntity, TPrimaryKey>
        where TEntity :class  , IEntity<TPrimaryKey>
    {
        Task<IList<TPostOutput>> Execute<TPostOutput, TPostDto>(TPostDto input, string storedName)
                where TPostDto :class
                where TPostOutput :class ,new();
    }
}
