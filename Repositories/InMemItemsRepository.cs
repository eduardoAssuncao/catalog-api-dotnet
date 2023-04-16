using Catalog.Entities;

namespace Catalog.Repositories
{

    public class InMemItemsRepository : IItemsRepository
    //Repositorio usado para criar uma memória local para teste
    {
        private readonly List<Item> items = new() //readonly é modificado apenas pelo construtor -> usado para manter a imutabilidade
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync() //usado para retornar uma lista de itens
        {
            return await Task.FromResult(items);//retorna a lista de itens
        }

        public async Task<Item> GetItemAsync(Guid id) //usado para retornar um item específico
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);//retorna o item encontrado
        }

        public async Task CreateItemAsync(Item item)//usado para criar um item
        {
            items.Add(item);//adiciona o item na lista
            await Task.CompletedTask;//retorna uma tarefa concluída
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
