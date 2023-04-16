using Catalog.Repositories;
using Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;//desabilita a adição de Async no final dos métodos
});

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));//registra o serializador do Guid para ser salvo como string no banco de dados
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));//registra o serializador do DateTimeOffset para ser salvo como string no banco de dados

builder.Services.AddSingleton<IMongoClient>(ServiceProvider => //Singleton é usado para criar uma instância única do MongoClient
{
    var settings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();//pega as configurações do appsettings.json
    return new MongoClient(settings.ConnectionString);//retorna uma instância do MongoClient
});

builder.Services.AddSingleton<IItemsRepository, MongoDbItemsRepository>();// Add services to the container. Singleton é usado para criar uma instância única do repositório

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
