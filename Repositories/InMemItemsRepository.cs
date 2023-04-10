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

        public IEnumerable<Item> GetItems() //IEnumerable é usado para retornar uma lista de itens
        {
            return items;
        }

        public Item GetItem(Guid id) //Guid é usado para retornar um item específico
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

    }
}
