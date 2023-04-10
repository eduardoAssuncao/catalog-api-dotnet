using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepository//interface que define os métodos que o repositório deve ter
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        
    }
}
