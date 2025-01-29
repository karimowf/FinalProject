using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDbSettings:ConnectionString"];
            var databaseName = configuration["MongoDbSettings:DatabaseName"];

            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }
    }
}
