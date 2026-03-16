using MongoDB.Driver;
using Authentication.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Authentication.Infrastructure.Data;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetSection("MongoDbSettings:ConnectionString").Value);
        _database = client.GetDatabase(configuration.GetSection("MongoDbSettings:DatabaseName").Value);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
}
