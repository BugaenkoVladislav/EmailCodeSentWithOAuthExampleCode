﻿using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface IRepository<TEntity>
{
    Task<TEntity?> GetEntityFirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    Task<List<TEntity>?> GetEntitiesAsync(Expression<Func<TEntity, bool>> expression);
    Task AddNewEntityAsync(TEntity entity);
    Task DeleteEntityAsync(TEntity entity);
    Task UpdateEntityFromExpressionAsync(TEntity entity,Expression<Func<TEntity, bool>> expression);
}