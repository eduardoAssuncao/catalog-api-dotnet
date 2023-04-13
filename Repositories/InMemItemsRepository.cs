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

        public IEnumerable<Item> GetItems() //usado para retornar uma lista de itens
        {
            return items;//retorna a lista de itens
        }

        public Item GetItem(Guid id) //usado para retornar um item específico
        {
            return items.Where(item => item.Id == id).SingleOrDefault();//retorna o item que tem o id igual ao id passado
        }

        public void CreateItem(Item item)//usado para criar um item
        {
            items.Add(item);//adiciona o item na lista
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}
