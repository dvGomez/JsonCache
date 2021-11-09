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

            cs.Clear<User>();

            Console.ReadLine();
        }
    }
}
