using Catalog.Dtos;
using Catalog.Entities;
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
        public ActionResult<ItemDto> GetItem(Guid id) //Action result é um tipo de retorno que pode retornar um item ou um erro
        {
            var item = repository.GetItem(id);//retorna o item do repositório

            if (item is null)
            {
                return NotFound();  
            }
            return item.AsDto();//retorna o item convertido para Dto
        }

        [HttpPost]//atributo que indica que o método é um método de POST
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new(){ //cria um novo item
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);//cria o item no repositório

            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item.AsDto()); //retorna o item criado convertido para Dto
        }
    }
}
