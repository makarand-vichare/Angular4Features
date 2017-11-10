﻿using WebApi2.EntityModels.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi2.IRepositories.Core
{
    public interface IBaseRepository<EntityModel> where EntityModel : IdentityColumnEntity
    {
        IDataContext DbContext { get; set; }

        List<EntityModel> GetAll();
        Task<List<EntityModel>> GetAllAsync();
        Task<List<EntityModel>> GetAllAsync(CancellationToken cancellationToken);

        List<EntityModel> PageAll(int skip, int take);
        Task<List<EntityModel>> PageAllAsync(int skip, int take);
        Task<List<EntityModel>> PageAllAsync(CancellationToken cancellationToken, int skip, int take);

        EntityModel Find(params object[] keys);
        EntityModel FindById(object id);
        Task<EntityModel> FindByIdAsync(object id);
        Task<EntityModel> FindByIdAsync(CancellationToken cancellationToken, object id);

        void Add(EntityModel entityModel);
        void Update(EntityModel entityModel);
        void Delete(EntityModel entityModel);
        void Delete(Expression<Func<EntityModel, bool>> predicate);
        void Delete(long id);

        EntityModel GetById(long id);
        EntityModel Get(Expression<Func<EntityModel, bool>> predicate);
        IEnumerable<EntityModel> GetMany(Expression<Func<EntityModel, bool>> predicate);
        bool Contains(Expression<Func<EntityModel, bool>> predicate);
        long Count { get; }

    }
}
