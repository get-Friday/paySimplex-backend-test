﻿namespace paySimplex.Domain.Interfaces.Repositories
{
    internal interface IBaseRepository<TEntity, Tkey> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Tkey id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
