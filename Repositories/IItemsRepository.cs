using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepository//interface que define os métodos que o repositório deve ter
    {
        Task<Item> GetItemAsync(Guid id);//Task é um tipo de retorno assíncrono, que retorna um item
        Task<IEnumerable<Item>> GetItemsAsync();//método para retornar uma lista de itens
        Task CreateItemAsync(Item item);//método para criar um item
        Task UpdateItemAsync(Item item);//método para atualizar um item
        Task DeleteItemAsync(Guid id);//método para deletar um item
    }
}
