using Catalog.Dtos;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]//atributo que indica que o controller é um controller de API
    [Route("items")]//rota para acessar o controller
    public class ItemsController : ControllerBase//herda de ControllerBase
    {
        
        private readonly IItemsRepository repository;//declaração do repositório

        public ItemsController(IItemsRepository repository)//construtor que recebe o repositório injetado
        {
            this.repository = repository;//atribui o repositório ao atributo
        }

        [HttpGet]//atributo que indica que o método é um método de GET
        public IEnumerable<ItemDto> GetItems()//retorna uma lista de itens
        {
            var items = repository.GetItems().Select( item => item.AsDto());//retorna uma lista de itens convertidos para Dto

            return items;
        }

        [HttpGet("{id}")]//atributo que indica que o método é um método de GET e que recebe um parâmetro
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();  
            }
            return item.AsDto();//retorna o item convertido para Dto
        }
    }
}
