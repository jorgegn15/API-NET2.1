using ApiNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApiNetCore.DataAccess
{
    public interface IBBDDContext
    {
        DbSet<ModelItem> ModelItem { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity:class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);

    }
}
