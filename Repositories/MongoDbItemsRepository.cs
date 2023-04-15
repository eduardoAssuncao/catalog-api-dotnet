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

        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);//insere um item na coleção
        }

        public void DeleteItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);//cria um filtro para a busca
            itemsCollection.DeleteOne(filter);//deleta um item da coleção
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);//cria um filtro para a busca
            return itemsCollection.Find(filter).SingleOrDefault();//retorna o item encontrado
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();//retorna todos os itens da coleção
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);//cria um filtro para a busca
            itemsCollection.ReplaceOne(filter, item);//atualiza o item
        }
    }
}