using System;
using System.Collections.Generic;
using Infra.JsonCache.Services;
using JsonCache.Models;

namespace JsonCache
{
    class Program
    {
        static void Main(string[] args)
        {
            CacheService cs = new CacheService();

            var user = cs.SaveAsync(new User("Test2", 14)).GetAwaiter().GetResult();
            var findUser = cs.GetByKeyAsync<User>(x => x.Name == "Test").GetAwaiter().GetResult();
            cs.DeleteByKeyAsync<User>(x => x.Name == "Test2").GetAwaiter().GetResult();

            ////cs.ClearAsync<User>();

            Console.ReadLine();
        }
    }
}
