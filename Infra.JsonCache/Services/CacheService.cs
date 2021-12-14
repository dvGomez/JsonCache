using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infra.JsonCache.Core;

namespace Infra.JsonCache.Services
{
    public class CacheService : CacheSaveHelper
    {
        public CacheService()
        {
            CreateLocalStorageFolder();
        }

        public async Task<TEntity> SaveAsync<TEntity>(TEntity entity)
        {
            return await InsertEntity(entity);
        }

        public async Task<IList<TEntity>> SaveAllASync<TEntity>(IList<TEntity> entity)
        {
            return await InsertEntity(entity);
        }

        public async Task<IList<TEntity>> GetAllASync<TEntity>()
        {
            return await GetEntityDbContent<TEntity>();
        }

        public async Task<TEntity> GetByKeyAsync<TEntity>(Func<TEntity, bool> keySelector)
        {
            var filePath = GetEntityDbPath<TEntity>();
            var result = await GetEntityDbContent<TEntity>();

            return result.FirstOrDefault(keySelector);
        }

        public async Task DeleteByKeyAsync<TEntity>(Predicate<TEntity> keySelector)
        {
            var filePath = GetEntityDbPath<TEntity>();
            var result = await GetEntityDbContent<TEntity>();
            result.RemoveAll(keySelector);
            await OverrideEntities(result);
        }

        public async Task ClearAsync<TEntity>()
        {
            var path = GetEntityDbPath<TEntity>();
            File.Delete(path);
            GetEntityDbPath<TEntity>();
        }
    }
}
