using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepository//interface que define os métodos que o repositório deve ter
    {
        Item GetItem(Guid id);//método para retornar um item específico
        IEnumerable<Item> GetItems();//método para retornar uma lista de itens
        void CreateItem(Item item);//método para criar um item
    }
}
