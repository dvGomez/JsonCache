using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infra.JsonCache.Core;
using Newtonsoft.Json;

namespace Infra.JsonCache.Services
{
    public class CacheService : CacheSaveHelper
    {
        public CacheService()
        {
            CreateLocalStorageFolder();
        }

        public async Task<TEntity> Save<TEntity>(TEntity entity)
        {
            return await InsertEntity(entity);
        }

        public async Task<IList<TEntity>> SaveAll<TEntity>(IList<TEntity> entity)
        {
            return await InsertEntity(entity);
        }

        public async Task<IList<TEntity>> GetAll<TEntity>()
        {
            return await GetEntityDbContent<TEntity>();
        }

        public async Task Clear<TEntity>()
        {
            var path = GetEntityDbPath<TEntity>();
            File.Delete(path);
            GetEntityDbPath<TEntity>();
        }
    }
}
