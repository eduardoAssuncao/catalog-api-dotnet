using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]//atributo que indica que o controller é um controller de API
    [Route("items")]//rota para acessar o controller
    public class ItemsController : ControllerBase//herda de ControllerBase
    {
        
        private readonly InMemItemsRepository repository;//cria uma variável para o repositório

        public ItemsController()
        {
            repository = new InMemItemsRepository();//instancia o repositório
        }

        [HttpGet]//atributo que indica que o método é um método de GET
        public IEnumerable<Item> GetItems()//retorna uma lista de itens
        {
            var items = repository.GetItems();
            return items;
        }
    }
}
