using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable // When we finish our transactions we want to dispose of our context
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        // Returns the number of changes to our database
        Task<int> Complete();
    }
}