using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infra.JsonCache.Core
{
    public abstract class CacheSaveHelper
    {
        private string StoragePath = Path.Combine(Directory.GetCurrentDirectory(), "Cache");
        private IDictionary<Type, TypeCode> generateKeys = new Dictionary<Type, TypeCode>();

        internal async Task<TEntity> InsertEntity<TEntity>(TEntity entity)
        {
            var filePath = GetEntityDbPath<TEntity>();
            var result = await GetEntityDbContent<TEntity>();
            result.Add(entity);

            await File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(result));

            return entity;
        }

        internal async Task<IList<TEntity>> InsertEntity<TEntity>(IList<TEntity> entity)
        {
            var filePath = GetEntityDbPath<TEntity>();
            var result = await GetEntityDbContent<TEntity>();

            result.AddRange(entity);

            await File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(result));

            return entity;
        }

        internal async Task<List<TEntity>> GetEntityDbContent<TEntity>()
        {
            var filePath = GetEntityDbPath<TEntity>();
            var text = await File.ReadAllTextAsync(filePath);
            var result = JsonConvert.DeserializeObject<List<TEntity>>(text);
            if (result == null) result = new List<TEntity>();
            return result;
        }

        internal string GetEntityDbPath<TEntity>()
        {
            var fileName = typeof(TEntity).Name;
            var filePath = Path.Combine(StoragePath, $"{fileName}_db.json");
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return filePath;
        }

        internal async Task<IList<TEntity>> OverrideEntities<TEntity>(IList<TEntity> entity)
        {
            var filePath = GetEntityDbPath<TEntity>();

            await File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(entity));

            return entity;
        }


        internal async void CreateLocalStorageFolder()
        {
            if (!File.Exists(StoragePath))
            {
                var directory = Path.GetDirectoryName(StoragePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
        }
    }
}
