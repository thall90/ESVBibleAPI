using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESVBible.Shared.Data.Contexts
{
    public interface IDbContext
    {
        EntityEntry Add(
            [NotNull] object entity);

        ValueTask<EntityEntry> AddAsync(
            [NotNull] object entity,
            CancellationToken cancellationToken = default);

        void AddRange(
            [NotNull] params object[] entities);

        Task AddRangeAsync(
            [NotNull] params object[] entities);

        int SaveChanges();

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken);

        EntityEntry<TEntity> Remove<TEntity>(
            [NotNull] TEntity entity)
            where TEntity : class;

        void RemoveRange(
            [NotNull] IEnumerable<object> entities);

        object Find(
            [NotNull] Type entityType,
            params object[] keyValues);

        ValueTask<object> FindAsync(
            [NotNull] Type entityType,
            params object[] keyValues);

        ValueTask<object> FindAsync(
            [NotNull] Type entityType,
            object[] keyValues,
            CancellationToken cancellationToken);

        ChangeTracker ChangeTracker { get; }

        IModel Model { get; }

        DatabaseFacade Database { get; }

        EntityEntry<TEntity> Entry<TEntity>(
            TEntity entity)
            where TEntity : class;

        EntityEntry Entry(object entry);

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        string ToString();
    }
}