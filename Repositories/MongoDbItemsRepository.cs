using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string databaseName = "catalog";//nome do banco de dados
        private const string collectionName = "items";//nome da coleção
        private readonly IMongoCollection<Item> itemsCollection;//cria uma coleção de itens
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;//cria um filtro para a busca

        public MongoDbItemsRepository(IMongoClient mongoClient)//injeção de dependência do MongoClient
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);//pega o banco de dados
            itemsCollection = database.GetCollection<Item>(collectionName);//pega a coleção de itens
        }

        public async Task CreateItemAsync(Item item)// async Task é usado para criar um método assíncrono
        {
            await itemsCollection.InsertOneAsync(item);//await é usado para esperar a execução do método assíncrono
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);//cria um filtro para a busca
            await itemsCollection.DeleteOneAsync(filter);//deleta um item da coleção
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);//cria um filtro para a busca
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();//retorna o item encontrado
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();//retorna todos os itens da coleção
        }

        public async Task UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);//cria um filtro para a busca
            await itemsCollection.ReplaceOneAsync(filter, item);//atualiza o item
        }
    }
}